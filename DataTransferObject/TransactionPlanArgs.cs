using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class TransactionPlanArgs
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsWithdrawl { get; set; }
        public DateTime TillThisDate { get; set; }
    }
}
