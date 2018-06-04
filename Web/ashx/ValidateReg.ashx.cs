using System;
using System.Collections.Generic;
using System.Web;

namespace book_shop.Web.ashx
{
    /// <summary>
    /// ValidateReg 的摘要说明
    /// </summary>
    public class ValidateReg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}