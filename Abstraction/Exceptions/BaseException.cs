using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(string message) : base(message)
        {

        }

        public string Code { get; set; }
    }

}
