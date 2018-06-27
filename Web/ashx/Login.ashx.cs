using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_shop.Web.ashx
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            BLL.UsersBLL UserManager = new BLL.UsersBLL();
            context.Response.ContentType = "text/plain";
            string userName = context.Request["txtLoginId"];
            string txtLoginPwd = context.Request["txtLoginPwd"];
            Model.UsersModel userInfo = new Model.UsersModel();
            string msg = string.Empty;

            if (UserManager.CheckUserInfo(userName, txtLoginPwd, out msg, out userInfo))
            {
                context.Session["userInfo"] = userInfo;
                //用户是否选择了自动登陆
                if (!string.IsNullOrEmpty(context.Request["cbAutoLogin"]))
                {
                    HttpCookie cookie1 = new HttpCookie("cp1", userName);
                    HttpCookie cookie2 = new HttpCookie("cp2", Common.WebCommon.GetMd5String(Common.WebCommon.GetMd5String(txtLoginPwd)));
                    cookie1.Expires = DateTime.Now.AddDays(7);
                    cookie2.Expires = DateTime.Now.AddDays(7);
                    context.Response.Cookies.Add(cookie1);
                    context.Response.Cookies.Add(cookie2);
                }
                if (string.IsNullOrEmpty(context.Request["hiddenReturnUrl"]))
                {
                    context.Response.Write("{\"action\":\"pass\",\"message\":\"/Default.aspx\"}");
                }
                else
                {
                    context.Response.Write("{\"action\":\"pass\",\"message\":\"" + context.Request["hiddenReturnUrl"]+"\"}");
                }

            }
            else
            {
                context.Response.Write("{\"action\":\"notThrough\",\"message\":\""+ msg+"\"}");
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