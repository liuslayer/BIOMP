using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace BIOMP.Web.WebAttribute
{
    /// <summary>
    /// 全局异常处理
    /// </summary>
    public class GlobalExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// 判断是不是要异常处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return context.Request.RequestUri.AbsoluteUri.Contains("api")
                && base.ShouldHandle(context);
        }

        /// <summary>
        /// 具体怎么处理
        /// </summary>
        /// <param name="context"></param>
        public override void Handle(ExceptionHandlerContext context)
        {
            Console.WriteLine(context.Exception.Message);

            context.Result = new ResponseMessageResult(context.Request.CreateResponse(
               HttpStatusCode.OK, new
               {
                   Result = false,
                   Msg = "请联系管理员 Global~"
               }));
        }

    }
}