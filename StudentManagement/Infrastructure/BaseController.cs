using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure
{
    public class BaseController : Controller
    {
        public BaseController()
        {

        }

        protected internal bool IsAjaxRequest(ActionExecutingContext context)
        {
            string RequestedWithHeader = "X-Requested-With";
            string XmlHttpRequest = "XMLHttpRequest";
            if (context == null)
            {
                throw new ArgumentNullException("request");
            }
            if (context.HttpContext.Request.Headers != null)
            {
                return context.HttpContext.Request.Headers[RequestedWithHeader] == XmlHttpRequest;
            }
            return false;
        }


        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //base.OnActionExecuting(context);
            ViewBag.Layout = IsAjaxRequest(context) ? "" : "~/Views/Shared/_Layout - Copy.cshtml";
            await next();
        }
    }
}
