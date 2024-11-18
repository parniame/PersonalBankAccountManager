using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(string message, int sequence) : base(message)
        {
            Code = $"Domain_{sequence}";
        }

        public string Code { get; set; }
    }
    
    public class BaseEmptyArgumentException : BaseException
    {
        public BaseEmptyArgumentException(string argument, int sequence) : base($"{argument} can't be emtpy.", sequence)
        {
        }
    }

}
