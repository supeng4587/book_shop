using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace book_shop.Web.Member
{
    public partial class Login : System.Web.UI.Page
    {
        BLL.UsersBLL UserManager = new BLL.UsersBLL();
        public string Msg { get; set; }
        public string ReturnUrl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                userLogin();
            }else
            {
                ReturnUrl = Request["returnUrl"];
                //校验cookie中是否有值
                CheckCookieInfo();
            }
        }

        /// <summary>
        /// 校验cookie值
        /// </summary>
        private void CheckCookieInfo()
        {
            if (Request.Cookies["cp1"] != null && Request.Cookies["cp2"] != null)
            {
                string userName = Request.Cookies["cp1"].Value;
                string userPwd = Request.Cookies["cp2"].Value;
                Model.UsersModel userInfo = UserManager.GetModel(userName);
                if (userInfo != null)
                {
                    if (userPwd == Common.WebCommon.GetMd5String(Common.WebCommon.GetMd5String(userInfo.LoginPwd)))
                    {
                        Session["userInfo"] = userInfo;
                        if (!string.IsNullOrEmpty(Request["returnUrl"]))
                        {
                            Response.Redirect(Request["returnUrl"]);
                        }else
                        {
                            Response.Redirect("/Default.aspx");
                        }
                    }
                }
                Response.Cookies["cp1"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["cp2"].Expires = DateTime.Now.AddDays(-1);
            }
        }

        private void userLogin()
        {
            string userName = Request["txtLoginId"];
            string txtLoginPwd = Request["txtLoginPwd"];
            Model.UsersModel userInfo = new Model.UsersModel();
            string msg = string.Empty;
           
            if(UserManager.CheckUserInfo(userName,txtLoginPwd,out msg,out userInfo))
            {
                Session["userInfo"] = userInfo;
                //用户是否选择了自动登陆
                if (!string.IsNullOrEmpty(Request["cbAutoLogin"]))
                {
                    HttpCookie cookie1 = new HttpCookie("cp1",userName);
                    HttpCookie cookie2 = new HttpCookie("cp2", Common.WebCommon.GetMd5String(Common.WebCommon.GetMd5String(txtLoginPwd)));
                    cookie1.Expires = DateTime.Now.AddDays(7);
                    cookie2.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(cookie1);
                    Response.Cookies.Add(cookie2);
                }
                if (string.IsNullOrEmpty(Request["hiddenReturnUrl"]))
                {
                    Response.Redirect("/Default.aspx");
                }
                else
                {
                    Response.Redirect(Request["hiddenReturnUrl"]);
                }
                
            }else
            {
                Msg = msg;
            }
        }
    }
}