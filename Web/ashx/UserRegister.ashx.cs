using book_shop.Web.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_shop.Web.ashx
{
    /// <summary>
    /// UserRegister 的摘要说明
    /// </summary>
    public class UserRegister : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Model.UsersModel usersModel = new Model.UsersModel();
            usersModel.LoginId = context.Request["txtName"];
            usersModel.LoginPwd = context.Request["txtPwd"];
            usersModel.Name = context.Request["txtRealName"];
            usersModel.Mail = context.Request["txtEmail"];
            usersModel.Address = context.Request["txtAddress"];
            usersModel.Phone = context.Request["txtPhone"];
            usersModel.UserStateId = Convert.ToInt32(UsersStateEnum.NormalState);

            BLL.UsersBLL usersBLL = new BLL.UsersBLL();
            string msg = string.Empty;
            if (usersBLL.Add(usersModel, out msg) > 0)
            {
                context.Session["userInfo"] = usersModel;
                context.Response.Write("ok:"+msg);
            }
            else
            {
                context.Response.Write("no:"+msg);
            }
        }

        //没写服务端信息校验

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}