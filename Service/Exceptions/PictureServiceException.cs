﻿using Abstraction.Exceptions;
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
    

    public class OnlyImageFormat : PictureServiceException
    {
        public OnlyImageFormat() : base($"تنها فرمت jpg و png و gif و jpeg قابل قبول است", 1)
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
