using Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class PictureServiceException : BaseException
    {
        public PictureServiceException(string message, int sequence) : base(message)
        {
            Code = "PictureServiceError_" + sequence;
        }
    }
    

    public class OnlyJPGFormat : PictureServiceException
    {
        public OnlyJPGFormat() : base($" تنها فرمت jpg قابل قبول است  ", 1)
        {

        }
    }
    public class InvalidImage : PictureServiceException
    {
        public InvalidImage() : base($"عکس  وارد شده خراب است", 1)
        {

        }
    }
}
