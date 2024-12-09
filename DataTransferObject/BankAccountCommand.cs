using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class BankAccountCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public Guid BankId { get; set; }
        public string? Description { get; set; }
        public string? CardNumber { get; set; }

        public BankCommand Bank { get; set; }
    }
}
