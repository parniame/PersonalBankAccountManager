



using Abstraction.Domain;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{

    public class Bank: BaseEntity
    {
        public string Name { get; private set; }

        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new EmptyDomainNameException();
        }


        //public Guid BankAccountId { get; set; }


        //public Bank(string name)
        //{
        //    if (string.IsNullOrEmpty(name))
        //        throw new ArgumentNullException(nameof(name));


        //    Name = name;

        //}

        //protected override IEnumerable<object?> GetEqualityComponents()
        //{
        //    yield return Name;

        //}
        //public Guid AvatarId { get; set; }
    }
}
