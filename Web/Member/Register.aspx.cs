using book_shop.Web.Enum;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace book_shop.Web.Member
{
    public partial class Register1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Common.WebCommon.CheckValidateCode(Request["txtCode"]))//完成验证码校验
                {
                    AddUserInfo();
                }
            }
        }

        #region 完成用户注册
        protected void AddUserInfo()
        {
            Model.UsersModel usersModel = new Model.UsersModel();
            usersModel.LoginId = Request["txtName"];
            usersModel.LoginPwd = Request["txtPwd"];
            usersModel.Name = Request["txtRealName"];
            usersModel.Mail = Request["txtEmail"];
            usersModel.Address = Request["txtAddress"];
            usersModel.Phone = Request["txtPhone"];
            usersModel.UserStateId = Convert.ToInt32(UsersStateEnum.NormalState);

            BLL.UsersBLL usersBLL = new BLL.UsersBLL();
            string msg = string.Empty;
            if (usersBLL.Add(usersModel, out msg) > 0)
            {
                Session["userInfo"] = usersModel;
                string returnUrl = Request["returnUrl"];
                if (string.IsNullOrEmpty(returnUrl))
                {
                    Response.Redirect("/Default.aspx");
                }else
                {
                    Response.Redirect(returnUrl);
                }
                
            }
            else
            {
                Response.Redirect("/ShowMsg.aspx?msg=" + msg+"&txt=首页"+ "&redirect=/Default.aspx");
            }
        }
        //没写服务端信息校验
        #endregion
        #region 完成验证码校验

        //protected bool CheckSession()
        //{
        //    bool isSucess = false;
        //    if (Session["vCode"] != null)
        //    {
        //        string txtCode = Request["txtCode"];
        //        string sysCode = Session["vCode"].ToString();
        //        if (sysCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            isSucess = true;
        //            //Session["vCode"] = null;
        //        }
        //        Session["vCode"] = null;//验证对不对都把session清了
        //    }
        //    return isSucess;
        //}
        #endregion
    }
}