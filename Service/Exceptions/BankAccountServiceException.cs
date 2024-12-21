using Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class BankAccountServiceException : BaseException
    {
        public BankAccountServiceException(string message,int sequence) : base(message)
        {
            Code = "BankAccountServiceError_" + sequence;
        }
    }
    public class OverdraftException : BankAccountServiceException
    {
        public OverdraftException(decimal amount) : base($"  در حساب تنها {amount} مقدار پول موجود است.", 1)
        {
        }
    }
    public class NoBankAccountException : BankAccountServiceException
    {
        public NoBankAccountException() : base($"ابتدا یک حساب بانکی ایجاد کنید", 1)
        {
        }
    }
    public class NoTransactionException : BankAccountServiceException
    {
        public NoTransactionException() : base($"ابتدا یک تراکنش  ایجاد کنید", 1)
        {
        }
    }
}
//public class PictureServiceException : BaseException
//{
//    public PictureServiceException(string message, int sequence) : base(message)
//    {
//        Code = "PictureServiceError_" + sequence;
//    }
//}


//public class OnlyImageFormat : PictureServiceException
//{
//    public OnlyImageFormat() : base($"تنها فرمت jpg و png و gif و jpeg قابل قبول است", 1)
//    {

//    }
//}