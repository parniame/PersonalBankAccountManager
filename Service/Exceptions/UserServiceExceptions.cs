using Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{

    public class UserServiceExceptions : BaseException
    {
        public UserServiceExceptions(string message, int sequence) : base(message)
        {
            Code = "UserServiceError_" + sequence;
        }
    }

    public class DuplicateUserNameException : UserServiceExceptions
    {
        public DuplicateUserNameException(string userName) : base($" از قبل وجود دارد\u200E[{userName}] \u200E کاربر با این نام کاربری\u200E", 1)
        {
           
        }
    }
    public class UserDoseNotExistException : UserServiceExceptions
    {
        public UserDoseNotExistException(string userName) : base($" از قبل وجود ندارد\u200E[{userName}]\u200E کاربر با این نام کاربری\u200E", 1)
        {
           
        }
    }


   
}

