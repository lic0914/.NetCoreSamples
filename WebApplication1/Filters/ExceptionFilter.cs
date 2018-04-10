using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.Redirect("/home/error?msg="+ HttpUtility.UrlEncode(context.Exception.Message));
            context.ExceptionHandled = true;
        }
    }
}
