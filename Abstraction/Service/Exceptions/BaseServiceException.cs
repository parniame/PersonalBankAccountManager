using Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Service.Exceptions;

public class BaseServiceException : BaseException
{
    public BaseServiceException(string message) : base(message)
    {
        Code = "ServiceException_";
    }
}


public class ItemNotFoundException : BaseServiceException
{
    public ItemNotFoundException(string itemName) : base($"وجود ندارد {itemName}  ")
    {
        Code += 404;
    }
}


public class DuplicateUniquePropertyException : BaseServiceException
{
    public DuplicateUniquePropertyException(string objName) : base($"از قبل موجود است  \u200E{objName}\u200E")
    {
        
        Code += 403;
    }
}
public class CodeErrorException : BaseServiceException
{
    public CodeErrorException() : base("در کد مشکلی وجود دارد")
    {
        
        Code += 402;
    }
}


