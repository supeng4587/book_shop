using System;
using System.Collections.Generic;
using System.Web;

namespace book_shop.Web.ashx
{
    /// <summary>
    /// ValidateReg 的摘要说明
    /// </summary>
    public class ValidateReg : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        BLL.UsersBLL userBLL = new BLL.UsersBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            #region 已用switch替换
            //if (action == "mail")//检查邮箱
            //{
            //    CheckUserMail(context);
            //}
            //else if (action == "code")//检查验证码
            //{
            //    CheckUserValidateCode(context);
            //}else if (action == "name")
            //{
            //    CheckUserName(context);
            //}
            //else
            //{

            //} 
            #endregion
            switch (action)
            {
                case "mail": CheckUserMail(context);
                    break;
                case "code": CheckUserValidateCode(context);
                    break;
                case "name": CheckUserName(context);
                    break;
                default: SwitchDefault(context);
                    break;
            }
        }

        #region 校验邮箱
        protected void CheckUserMail(HttpContext context)
        {
            string userMail = context.Request["userMail"];
            if (userBLL.CheckUserMail(userMail))
            {
                context.Response.Write("邮箱已被占用");
            }
            else
            {
                context.Response.Write("邮箱可用");
            }
        }
        #endregion
        #region 检验验证码
        protected void CheckUserValidateCode(HttpContext context)
        {
            string validateCode = context.Request["validateCode"];
            if (Common.WebCommon.CheckValidateCode(validateCode))
            {
                context.Response.Write("验证码正确");
            }
            else
            {
                context.Response.Write("验证码错误");
            }
        }
        #endregion
        #region 检验用户名
        protected void CheckUserName(HttpContext context)
        {
            string userName = context.Request["userName"];
            if (userBLL.ValidateUserName(userName))
            {
                context.Response.Write("用户名已被占用");
            }else
            {
                context.Response.Write("用户名可用");
            }
        }
        #endregion
        #region default
        protected void SwitchDefault(HttpContext context)
        {
            context.Response.Write("未知业务");
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}