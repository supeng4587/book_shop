using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_shop.Web.ashx
{
    /// <summary>
    /// ProductCart 的摘要说明
    /// </summary>
    public class ProductCart : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BLL.UsersBLL userManager = new BLL.UsersBLL();
            if (userManager.ValidateUserLogin())
            {

            }else
            {
                context.Response.Write("{\"state\":\"notLogin\",\"message\":\"您还没有登陆\"}");
            }

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