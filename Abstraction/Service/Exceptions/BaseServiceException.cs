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
    public ItemNotFoundException(string itemName) : base($" این {itemName} وجود ندارد  ")
    {
        Code += 404;
    }
}


public class DuplicateUniquePropertyException : BaseServiceException
{
    public DuplicateUniquePropertyException(string objName) : base($"این  {objName} از قبل موجود است ")
    {
        
        Code += 403;
    }
}
public class CodeErrorException : BaseServiceException
{
    public CodeErrorException() : base("در انجام عملیات مشکلی وجود دارد")
    {
        
        Code += 402;
    }
}


