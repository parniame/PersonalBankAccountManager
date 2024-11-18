using Abstraction.Exceptions;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    
  

    public class EmptyDomainNameException : BaseEmptyArgumentException
    {
        public EmptyDomainNameException() : base("Bank title", 1)
        {
            Code = $"BankDomain_{1}";
        }
    }

}





