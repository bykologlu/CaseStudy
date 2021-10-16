using Core.Utilities.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.AspMVC.Filters
{
    public class ModelStateFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var modelState = filterContext.Controller.ViewData.ModelState;

            if (!modelState.IsValid)
            {
                var errors = modelState.Values.SelectMany(v => v.Errors).Select(j => j.ErrorMessage).ToList();
                var result = new ErrorResponse(string.Join("<br/>", errors));

                ContentResult content = new ContentResult();
                content.ContentType = "application/json";
                content.Content = JsonConvert.SerializeObject(result);
                filterContext.Result = content;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}