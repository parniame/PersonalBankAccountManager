using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class TransactionResult
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        
        public bool IsWithdrawl { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public Guid? CategoryId { get; set; }
        
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public CategoryArgs? Category { get; set; }
        public TransactionPlanArgs? TransactionPlan{ get; set; }
        public BankAccountArgs BankAccount { get; set; }
        

    }
}
