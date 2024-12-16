using Abstraction.Domain;
using Abstraction.Service.Exceptions;
using DataTransferObject;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

using Service.ServiceInterfaces;



namespace Service.ServiceClasses
{
    public class TransactionPlanService : ServiceBase<TransactionPlan>, ITransactionPlanService
    {
        private readonly IBaseRepository<TransactionPlan> _baseRepository;
        private readonly IUserService _userService;
        private readonly ITransactionService _transactionService;
        public TransactionPlanService(IBaseRepository<TransactionPlan> baseRepository, IUserService userService, ITransactionService transactionService) : base(baseRepository)
        {
            _userService = userService;
            _baseRepository = baseRepository;
            _transactionService = transactionService;
        }

        public override async Task<bool> CreateAsync<TransactionPlanCommand>(TransactionPlanCommand transactionPlanCommand)
        {
            return await CreateUniqueAsync(transactionPlanCommand, "Name", "پلنر تراکنش");
        }
        public async Task<List<DTO>> GetAllAsync<DTO>(Guid userId)
        where DTO : class
        {
            //check user
            var user = await _userService.GetCurrentUserAsync(userId.ToString());
            if (user == null)
            {
                throw new ItemNotFoundException("نام کاربری");
            }
            var entities =  _baseRepository.GetAll(x => x.UserId == userId, true);
            if(entities == null)
            {
                return new List<DTO>();
            }
             
            var results = await entities.ProjectToType<DTO>().ToListAsync();
            return results;

        }
        public async Task<bool> DeleteAsync(Guid Id, Guid userId)
        {
            //Check if Id valid
            if (new Guid() != Id)
            {
                var check = await _baseRepository.GetByIdAsync(Id);
                if (check != null)
                {
                    if (check.UserId == userId)
                    {

                        var result = await _transactionService.DeletePlannerAsync(Id);
                        return await _baseRepository.DeleteAsync(Id);
                    }
                    throw new CodeErrorException();

                }
            }

            throw new ItemNotFoundException("پلنر تراکنش ");
        }
        public async Task<DTO?> GetByIdAsync<DTO>(Guid Id, Guid userId, bool readOnly = true)
           where DTO : class
        {
            //check user
            var user = await _userService.GetCurrentUserAsync(userId.ToString());
            if (user == null)
            {
                throw new ItemNotFoundException("نام کاربری");
            }
            //Check if Id valid
            if (new Guid() != Id)
            {
                var check = await _baseRepository.GetByIdAsync(Id);
                if (check != null)
                {
                    if (check.UserId == userId)
                    {
                        var entity = await _baseRepository.GetByIdAsync(Id, readOnly);

                        var test = MapToDTO<DTO>(entity);
                        return entity == null ? null : MapToDTO<DTO>(entity);
                    }
                    throw new CodeErrorException();
                }
            }
            throw new ItemNotFoundException("پلنر تراکنش ");
        }

    }

}
