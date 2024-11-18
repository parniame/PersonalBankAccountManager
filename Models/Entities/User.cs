
using Abstraction.Domain;
using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class User : IdentityUser<Guid>, ITraceble<User>, ITimeTraceble
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        public DateTime? DateCreated { get; set; }
        public Guid? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid? UpdatorID { get; set; }
        public User? Updator { get; set; }
       
        //public virtual ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
        //public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        //public virtual ICollection<TransactionPlan> TransactionPlans { get; set; } = new List<TransactionPlan>();

    }
}
