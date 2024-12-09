using Abstraction.Service.Exceptions;
using DataTransferObject;
using Hangfire;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using PersonalBankAccountManager.Controllers;
using System.Security.Claims;

namespace PersonalBankAccountManager.Resources.Utilities
{
    public  class Utilities 
    {
        public static TResult MapToCustom<TSource, TResult>(TSource src)
        {
            return src.Adapt<TResult>();
        }
        public static List<TResult> ProjectToCustom<TSource, TResult>(List<TSource> src)
        {
            return src.AsQueryable().ProjectToType<TResult>().ToList();
        }

       

    }
}
