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
        public TransactionPlanService(IBaseRepository<TransactionPlan> baseRepository, IUserService userService) : base(baseRepository)
        {
            _userService = userService;
            _baseRepository = baseRepository;
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

    }

}
