
using Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class BankAccount : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public Guid? BankId { get; set; }
        public string? Description { get; set; }
        public string? CardNumber  { get; set; }

        public User User { get; set; }
        public Bank Bank { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
