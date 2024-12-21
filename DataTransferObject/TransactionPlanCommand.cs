using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class TransactionPlanCommand
    {
       
        public Guid Id { get; set; }
        public string UniqueName { get; set; }
        public decimal Amount { get; set; }
        public bool IsWithdrawl { get; set; }
        public DateTime TillThisDate { get; set; }
        public string? Description { get; set; }
       
        public Guid UserId { get; set; }
    }
}
