﻿using Abstraction.Domain;
using Abstraction.Service.Exceptions;
using DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Persistence.Repositories;
using Service.Exceptions;
using Service.FileValidate;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceClasses
{
    public class BankService : ServiceBase<Bank>, IBankService
    {
        private readonly IBaseRepository<Bank> _baseRepository;
        private readonly IBaseRepository<BankAccount> _bankAccountRepository;
        private readonly IPictureService _pictureService;
        public BankService(IBaseRepository<Bank> baseRepository, IPictureService pictureService, IBaseRepository<BankAccount> bankAccountRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _pictureService = pictureService;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<bool> CreateAsync(BankCommand bankDTO, IFormFile? file)

        {
            if (file != null)
            {
                var fullAddress = await _pictureService.AddFileAsync(file);
                //Create Picture Object
                bankDTO.Picture = new PictureArgs { FileAddress = fullAddress };
            }

            return await CreateUniqueAsync(bankDTO, "Name", "بانک");
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            //Check if Id valid
            if (new Guid() != Id)
            {
                var check = await _baseRepository.GetByIdAsync(Id, x => x.Include(x => x.Picture), true);
                if (check != null)
                {

                    //delete bank from bankAcccounts
                    var bankAccounts = _bankAccountRepository.GetAll(x => x.BankId == Id, false).ToList();
                    if(bankAccounts.Any())
                    {
                        foreach (var bankAccount in bankAccounts)
                        {
                            bankAccount.BankId = null;
                        }
                        await _bankAccountRepository.CommitAsync();
                    }
                    var result = await _baseRepository.DeleteAsync(Id);
                    if (result)
                    {
                        if (check.Picture != null)
                        {
                            //delete File
                            await _pictureService.DeleteAsync(check.Picture.Id, check.Picture.FileAddress);
                        }

                    }

                    return result;



                }
            }

            throw new ItemNotFoundException("بانک");
        }
    }

}
