using Abstraction.Domain;
using Abstraction.Service.Exceptions;
using DataTransferObject;

using Models.Entities;

using Service.ServiceInterfaces;



namespace Service.ServiceClasses
{
    public class TransactionPlanService : ServiceBase<TransactionPlan>, ITransactionPlanService
    {
        private readonly IBaseRepository<TransactionPlan> _baseRepository;
        public TransactionPlanService(IBaseRepository<TransactionPlan> baseRepository) : base(baseRepository)
        {
        }

        public override async Task<bool> CreateAsync<TransactionPlanCommand>(TransactionPlanCommand transactionPlanCommand)
        {
            return await CreateUniqueAsync(transactionPlanCommand, "Name", "پلنر تراکنش");
        }

    }

}
