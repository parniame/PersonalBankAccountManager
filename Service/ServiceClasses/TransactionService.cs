using Abstraction.Domain;
using Abstraction.Service.Exceptions;
using DataTransferObject;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Spreadsheet;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Persistence.Repositories;
using Service.Exceptions;
using Service.FileValidate;
using Service.ServiceInterfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceClasses
{

    public class TransactionService : ServiceBase<Transaction>, ITransactionService
    {
        private readonly IBaseRepository<Transaction> _transactionRepository;
        private readonly IUserService _userService;
        private readonly IPictureService _pictureService;
        

        public TransactionService(IBaseRepository<Transaction> transactionRepository, IUserService userService, IPictureService pictureService) : base(transactionRepository)
        {
            _transactionRepository = transactionRepository;
            _userService = userService;
            _pictureService = pictureService;
            
        }
        public async Task<bool> CreateAsync(TransactionCommand transactionCommand, IFormFile? file)

        {
            if (file != null)
            {
                var fullAddress = await _pictureService.AddFileAsync(file);
                //Create Picture Object
                transactionCommand.Picture = new PictureArgs { FileAddress = fullAddress };
            }

            return await CreateUniqueAsync(transactionCommand, "TransactionPlanId", "پرداخت پلنر تراکنش");
        }

        public async Task<bool> DeleteAnyTransactionWithThisBankAccountAsync(Guid bankAccountId)
        {
            return await _transactionRepository.DeleteListAsync(x => x.BankAccountId == bankAccountId); ;
        }
        

        public async Task<bool> DeleteAsync(Guid Id, Guid userId)
        {
            //Check if Id valid
            if (new Guid() != Id)
            {
                var check = await _transactionRepository.GetByIdAsync(Id,x => x.Include(x => x.TransActionDocument),true);
                if (check != null)
                {
                    if (check.UserId == userId)
                    {
                        var result =  await _transactionRepository.DeleteAsync(Id);
                        if (result)
                        {
                            if (check.TransActionDocument != null)
                            {
                                //delete File
                                await _pictureService.DeleteAsync(check.TransActionDocument.Id, check.TransActionDocument.FileAddress);
                            }

                        }

                        return result;

                        
                        
                    }
                    throw new CodeErrorException();

                }
            }

            throw new ItemNotFoundException("تراکنش");
        }
        public async Task<List<DTO>> GetAllAsync<DTO>(Guid userId)
                where DTO : class
        {
            //check user
            var user = await _userService.GetUserAsync(userId.ToString());
            if (user == null)
            {
                throw new ItemNotFoundException("نام کاربری");
            }

            var entities = _transactionRepository.GetAll(x => x.UserId == userId, true);
            if (!entities.Any())
            {
                throw new NoTransactionException();
            }

            var results = await entities.ProjectToType<DTO>().ToListAsync();
            return results;


        }

        public async Task<DTO?> GetByIdAsync<DTO>(Guid Id, Guid userId, bool readOnly = true)
        where DTO : class
        {
            //check user
            var user = await _userService.GetUserAsync(userId.ToString());
            if (user == null)
            {
                throw new ItemNotFoundException("نام کاربری");
            }
            //Check if Id valid
            if (new Guid() != Id)
            {
                var check = await _transactionRepository.GetByIdAsync(Id);
                if (check != null)
                {
                    if (check.UserId == userId)
                    {
                        var entity = await _transactionRepository.GetByIdAsync(Id, x => x.Include(x => x.BankAccount).Include(x => x.BankAccount.Bank).Include(x => x.BankAccount.Bank.Picture).Include(x => x.Category).Include(x => x.TransactionPlan).Include(x => x.TransActionDocument).Include(x => x.TransActionDocument), readOnly);

                        var test = MapToDTO<DTO>(entity);
                        return entity == null ? null : MapToDTO<DTO>(entity);
                    }
                    throw new CodeErrorException();
                }
            }
            throw new ItemNotFoundException("تراکنش ");
        }

        public async Task<bool> UpdateAsync(TransactionCommand dto, IFormFile? file, bool keepFile)
        {
            var dtoCheck = await _transactionRepository.GetByIdAsync(dto.Id);
            if (dtoCheck != null)
            {
                if (dtoCheck.UserId == dto.UserId)
                {
                    //ignore list
                    var list = new List<string>{
                                                "UserId",
                                                "Amount",

                                                "IsWithdrawl",
                                                "TransactionPlanId",
                                                "BankAccountId"


                                            };

                    //user : dosn't have a file/have a file which dosn't want to keep
                    if (!keepFile)
                    {
                        //has File : 1) wants to delete 2)first delete and  then update
                        if (dto.Picture != null)
                        {
                            //delete File-
                             await _pictureService.DeleteAsync(dto.Picture.Id, dto.Picture.FileAddress);
                            //second user will have it's new file in '183'
                        }

                    }//has file  wants to keep
                    else
                    {
                        list.Add("PictureId");
                    }


                    //User : 1)add file 2) has deleted the old one and wants to add file
                    if (file != null)
                    {
                        var fullAddress = await _pictureService.AddFileAsync(file);
                        //Create Picture Object
                        dto.Picture = new PictureArgs { FileAddress = fullAddress };
                    }
                    var entity = MapToEntity(dto);
                    entity.DateUpdated = DateTime.Now;
                    entity.PictureId = null;
                    var result = await _transactionRepository.UpdateAsync(entity, list);
                    return result;
                }
            }
            throw new CodeErrorException();
        }

        private async Task<IQueryable<Transaction>> GetAllTimeFilterdAsync(Guid userId, DateTime? from, DateTime? to)

        {

            IQueryable<Transaction> entities;
            if (from.HasValue || to.HasValue)
            {

                if (to.HasValue && from.HasValue)
                {
                    entities = _transactionRepository.GetAll(x => x.UserId == userId & x.DateCreated > from.Value & x.DateCreated < to.Value, true);
                }
                else if (from.HasValue)
                {
                    entities = _transactionRepository.GetAll(x => x.UserId == userId & x.DateCreated > from.Value, true);
                }
                else
                {
                    entities = _transactionRepository.GetAll(x => x.UserId == userId & x.DateCreated < to.Value, true);

                }

                return entities;

            }
            throw new CodeErrorException();



        }
        public async Task<dynamic> GetComareAsync<DTO>(Guid userId, DateTime? from, DateTime? to, bool isWithList = true)
        where DTO : class
        {
            //check user
            var user = await _userService.GetUserAsync(userId.ToString());
            if (user == null)
            {
                throw new ItemNotFoundException("نام کاربری");
            }
            CompareTransaction comareArgs = new CompareTransaction()
            {
                CountAll = 0,
                CountAmountIn = 0,
                CountAmountOut = 0,
                AmountIn = 0,
                AmountOut = 0,
                TotalAmount = 0,
            };

            IQueryable<Transaction> entities;
            if (from.HasValue || to.HasValue)
            {

                entities = await GetAllTimeFilterdAsync(userId, from, to);

            }

            else
            {
                entities = _transactionRepository.GetAll(x => x.UserId == userId, true);
            }
            if (entities.Any())
            {
                var list = entities.ToList();

                foreach (var entity in list)
                {
                    comareArgs.CountAll += 1;
                    if (entity.IsWithdrawl)
                    {
                        comareArgs.AmountIn += entity.Amount;
                        comareArgs.TotalAmount += entity.Amount;
                        comareArgs.CountAmountIn += 1;
                    }
                    else
                    {
                        comareArgs.AmountOut += entity.Amount;
                        comareArgs.TotalAmount -= entity.Amount;
                        comareArgs.CountAmountOut += 1;
                    }
                }
            }
            dynamic obj = new ExpandoObject();
            obj.Compare = comareArgs;
            if (isWithList)
                obj.List = await entities.ProjectToType<DTO>().ToListAsync();
            return obj;

        }
        public async Task<TransactionLists> GetChartListAsync(Guid userId)
        {

            //check user
            var user = await _userService.GetUserAsync(userId.ToString());
            if (user != null)
            {
                var entities = _transactionRepository.GetAll(x => x.UserId == userId, true);
                if (entities.Any())
                {
                    var times = new List<DateTime>();
                    var amounts = new List<decimal>();
                    //var withdrawls = new List<decimal>();
                    //var settlements = new List<decimal>();
                    foreach (Transaction entity in entities)
                    {
                        times.Add(entity.DateCreated);
                        if (entity.IsWithdrawl)
                        {
                            amounts.Add(entity.Amount);
                        }
                        else
                        {
                            amounts.Add(-entity.Amount);
                        }
                    }
                    return new TransactionLists()
                    {
                        //Withdrawls = withdrawls,
                        //Settlments = settlements,
                        Amounts = amounts,
                        Times = times
                    };
                }

            }
            return new TransactionLists()
            {
                Amounts = new List<decimal>(),
                Times = new List<DateTime> { DateTime.Now },

            };



        }
        public async Task<TransactionCategoryLists> GetTransactionWithCategoriesChartAsync(Guid userId)
        {
            //check user
            var user = await _userService.GetUserAsync(userId.ToString());
            if (user != null)
            {
                var entities = _transactionRepository.GetAll(x => x, x => x.UserId == userId, x => x.Include(x => x.Category), true);
                var withdrawls = entities.Where(x => x.IsWithdrawl == false).Select(x => (x.Category != null ? x.Category.Name : "بدون کتگوری")).ToArray();
                var settlments = entities.Where(x => x.IsWithdrawl == true).Select(x => (x.Category != null ? x.Category.Name : "بدون کتگوری")).ToArray();
                if (entities.Any())
                {
                    var counts1 = new List<int>();
                    List<string> categories1 = new List<string>();
                    var counts2 = new List<int>();
                    List<string> categories2 = new List<string>();
                    // To get a Dictionary<string, int>
                    var groupedWithdrawls = withdrawls
                        .GroupBy(s => s)
                        .Select(g => (g.Key != null ? new { CategoryName = g.Key, Count = g.Count() } : new { CategoryName = "بدون کتگوری", Count = g.Count() }));
                    var groupedSettlments = settlments
                       .GroupBy(s => s)
                       .Select(g => (g.Key != null ? new { CategoryName = g.Key, Count = g.Count() } : new { CategoryName = "بدون کتگوری", Count = g.Count() }));

                    foreach (var element in groupedWithdrawls)
                    {
                        counts1.Add(element.Count);
                        categories1.Add(element.CategoryName);
                    }
                    foreach (var element in groupedSettlments)
                    {
                        counts2.Add(element.Count);
                        categories2.Add(element.CategoryName);
                    }
                    return new TransactionCategoryLists()
                    {

                        Counts = [counts1, counts2],
                        Categories = [categories1, categories2],
                    };
                }

            }
            return new TransactionCategoryLists()
            {
                Counts = new List<List<int>>(),
                Categories = new List<List<string>>(),

            };
        }


    }

}

