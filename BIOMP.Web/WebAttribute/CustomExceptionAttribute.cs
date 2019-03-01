using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Security;

namespace BIOMP.Web.WebAttribute
{
    /// <summary>
    /// 异常处理的特性
    /// </summary>
    public class CustomExceptionAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 方法会在出现异常时触发  
        /// 1 日志一下
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Console.WriteLine($"{actionExecutedContext.Request.RequestUri.AbsoluteUri}:{actionExecutedContext.Exception.Message}");

            //把当前请求的返回指定一下
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                HttpStatusCode.OK, new
                {
                    Result = false,
                    Msg = "请联系管理员~"
                });

            //base.OnException(actionExecutedContext);
        }
    }
}