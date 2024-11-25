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


    public class BankDomainException : BaseException
    {
        public BankDomainException(string message, int sequence) : base(message)
        {
            Code = $"BankDomain_{sequence}";
        }
    }



    public class BaseEmptyArgumentException : BankDomainException
    {
        public BaseEmptyArgumentException(string argument, int sequence) : base($"{argument} can't be emtpy.", sequence)
        {
        }
    }

    public class EmptyDomainNameException : BaseEmptyArgumentException
    {
        public EmptyDomainNameException() : base("Bank title", 1)
        {
           
        }
    }

}





