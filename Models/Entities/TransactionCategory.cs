
using Abstraction.Domain;
using Domain;
//using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class TransactionCategory : BaseEntity 
    {
        public bool IsWithdrawl { get; set; }
        public string Name { get; set; }
        public Guid? CreatorID { get; set; }
        public Guid? UpdatorID { get; set; }

        public User? Creator { get; set; }
        public User? Updator { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
