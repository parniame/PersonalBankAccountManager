using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataTransferObject
{
    public class TransactionPlanResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsWithdrawl { get; set; }
        public bool IsPaid { get; set; }
        public DateTime TillThisDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string? Description { get; set; }
        public TransactionArgs? Transaction { get; set; }
    }
}
