using Mapster;
using PersonalBankAccountManager.Resources.Mapster;

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
            var test1 = src.AsQueryable();
            var test2 = test1.ProjectToType<TResult>();
            return src.AsQueryable().ProjectToType<TResult>().ToList();
        }

       

    }
}
