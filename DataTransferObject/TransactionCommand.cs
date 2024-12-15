using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class TransactionCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsWithdrawl { get; set; }
        public string Title { get; set; }
        public Guid BankAccountId { get; set; }
        public decimal Amount { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Description { get; set; }
        public Guid? TransactionPlanId { get; set; }
        public Guid? SecondBankAccountId { get; set; }
        
    }
}
