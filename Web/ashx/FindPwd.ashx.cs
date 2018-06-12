using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_shop.Web.ashx
{
    /// <summary>
    /// FindPwd 的摘要说明
    /// </summary>
    public class FindPwd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userName = context.Request["name"];
            string userMail = context.Request["mail"];
            BLL.UsersBLL userManager = new BLL.UsersBLL();
            Model.UsersModel userInfo = userManager.GetModel(userName);
            if (userInfo != null)
            {
                if (userMail == userInfo.Mail)
                {
                    userManager.FindUserPwd(userInfo);
                    context.Response.Write("找回密码邮件已发送，请查收.");
                }else
                {
                    context.Response.Write("找回密码邮箱不正确，请重新填写");
                }

            }else
            {
                context.Response.Write("无此用户");
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