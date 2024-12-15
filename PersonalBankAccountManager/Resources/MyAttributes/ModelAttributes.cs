using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace PersonalBankAccountManager.Resources.MyAttributes
{
    public class SetTempDataModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var tempData = filterContext.HttpContext.RequestServices.GetRequiredService<ITempDataDictionary>();
            var viewData = filterContext.HttpContext.RequestServices.GetRequiredService<ViewDataDictionary>();


            tempData["ModelState"] =
               viewData.ModelState;
        }
    }

    public class RestoreModelStateFromTempDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var tempData = filterContext.HttpContext.RequestServices.GetRequiredService<ITempDataDictionary>();
            var viewData = filterContext.HttpContext.RequestServices.GetRequiredService<ViewDataDictionary>();
            if (tempData.ContainsKey("ModelState"))
            {
                viewData.ModelState.Merge(
                    (ModelStateDictionary)tempData["ModelState"]);
            }
        }
    }
}
