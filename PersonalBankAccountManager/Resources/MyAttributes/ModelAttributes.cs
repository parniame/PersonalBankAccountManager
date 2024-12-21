//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;

//namespace PersonalBankAccountManager.Resources.MyAttributes
//{
    
//    public class SetTempDataModelStateAttribute : ActionFilterAttribute
//    {
//        //private readonly IHttpContextAccessor _httpContextAccessor;
//        //private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;

//        //public SetTempDataModelStateAttribute(IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
//        //{
//        //    _httpContextAccessor = httpContextAccessor;
//        //    _tempDataDictionaryFactory = tempDataDictionaryFactory;
//        //}



//        //public readonly ControllerBase _controllerBase ;
//        //public SetTempDataModelStateAttribute(ControllerBase controller)
//        //{
//        //    _controllerBase = controller;
//        //}
//        public override void OnActionExecuted(ActionExecutedContext filterContext)
//        {
//            base.OnActionExecuted(filterContext);
//            //var _tempDataDictionaryFactory = filterContext.HttpContext.RequestServices.GetRequiredService<TempDataDictionaryFactory>();
//            //var _httpContextAccessor = filterContext.HttpContext.RequestServices.GetRequiredService<HttpContextAccessor>();
//            //var test = _tempDataDictionaryFactory.GetTempData(_httpContextAccessor.HttpContext);
//            var viewData = filterContext.HttpContext.RequestServices.GetRequiredService<ViewDataDictionary>();
//            var tempData = filterContext.HttpContext.RequestServices.GetRequiredService<ITempDataDictionary>();

//            tempData["ModelState"] =
//               viewData.ModelState;
//        }
//    }

//    public class RestoreModelStateFromTempDataAttribute : ActionFilterAttribute
//    {
//        public override void OnActionExecuting(ActionExecutingContext filterContext)
//        {
//            base.OnActionExecuting(filterContext);

//            var tempData = filterContext.HttpContext.RequestServices.GetRequiredService<ITempDataDictionary>();
//            var viewData = filterContext.HttpContext.RequestServices.GetRequiredService<ViewDataDictionary>();
//            if (tempData.ContainsKey("ModelState"))
//            {
//                viewData.ModelState.Merge(
//                    (ModelStateDictionary)tempData["ModelState"]);
//            }
//        }
//    }
//    public class UpdateDateActionFilter : IActionFilter
//    {
//        public void OnActionExecuting(ActionExecutingContext context)
//        {
//            // Do something before the action executes.
//        }

//        public void OnActionExecuted(ActionExecutedContext context)
//        {
//            // Do something after the action executes.
//        }
//    }
//}
//using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using Newtonsoft.Json;

//public static class TempDataExtensions
//{
//    public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
//    {
//        tempData[key] = System.Text.Json.JsonSerializer.Serialize(value);
//    }

//    public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
//    {
//        object o;
//        tempData.TryGetValue(key, out o);
//        return o == null ? null : System.Text.Json.JsonSerializer.Deserialize<T>((string)o);
//    }
//}
