using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class BankAccountResult
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string? BankName { get; set; }
        public string? URL { get; set; }
        public string? Description { get; set; }
        public string? CardNumber { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public BankArgs Bank { get; set; }
    }
}
