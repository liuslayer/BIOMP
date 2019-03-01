using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Security;

namespace BIOMP.Web.WebAttribute
{
    /// <summary>
    /// 异常处理的特性
    /// </summary>
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 方法执行前
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Console.WriteLine(actionContext.Request.RequestUri.AbsoluteUri);
            //就是完成数据格式的检测
            //actionContext.ModelState.IsValid 方法执行前完成检测
            //actionContext.Response
            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// 方法执行后
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //跨域的东西来试一下   修改下response
            //actionExecutedContext.Response
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            actionExecutedContext.Response.Headers.Add("Custom", "*");
            actionExecutedContext.Response.Headers.Add("Eleven", "*");
            actionExecutedContext.Response.Headers.Add("Ruanmou", "*");
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}