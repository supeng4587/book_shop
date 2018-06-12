using book_shop.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace book_shop.BLL
{
    public partial class UsersBLL
    {
        /// <summary>
        /// 添加一条数据并返回消息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int Add(UsersModel model,out string msg)
        {
            int success = -1;
            if (ValidateUserName(model.LoginId))
            {
                msg = "此用户名已被占用";
            }
            else
            {
                msg = "添加成功";
                success = dal.Add(model);
            }
            return success;
        }

        #region 检查用户名
        /// <summary>
        /// 检查用户名
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ValidateUserName(string userName)
        {
            return dal.GetModel(userName) != null ? true : false;
        }
        #endregion

        #region 检查邮箱
        /// <summary>
        /// 根据邮箱返回是否被占用
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public bool CheckUserMail(string mail)
        {
            return dal.CheckUserMail(mail) > 0 ? true : false;
        }
        #endregion

        /// <summary>
        /// 校验用户信息并返回消息和user对象
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <param name="msg"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CheckUserInfo(string userName, string userPwd, out string msg, out Model.UsersModel user)
        {
            bool isSuccess = false;
            user = dal.GetModel(userName);
            if (user != null)
            {
                if (userPwd == user.LoginPwd)
                {
                    msg = "登陆成功";
                    isSuccess = true;
                }
                else
                {
                    msg = "用户密码错误。";
                }
            }
            else
            {
                msg = "此用户不存在。";
            }

        return isSuccess;
        }

        /// <summary>
        /// 根据用户名找用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Model.UsersModel GetModel(string userName)
        {
            return dal.GetModel(userName);
        }


        public void FindUserPwd(Model.UsersModel userInfo)
        {
            //1.系统产生一个新的密码，然后更新数据库，再将新的密码发送到用户的邮箱中
            string newPwd = Guid.NewGuid().ToString().Substring(0, 8);
            userInfo.LoginPwd = newPwd;//一定要将系统产生的系密码加密后更新到数据库，但是发送到用户邮箱的密码一定是明文的
            dal.Update(userInfo);
            MailMessage mailMsg = new MailMessage("mailsupeng@126.com", "苏鹏");
            mailMsg.To.Add(new MailAddress(userInfo.Mail,"新浪收件人supeng"));
            mailMsg.Subject = "在商城网站中的用户";
            StringBuilder sb = new StringBuilder();
            sb.Append("用户名是：" + userInfo.LoginId);
            sb.Append("新密码是：" + userInfo.LoginPwd);
            mailMsg.Body =sb.ToString();
            SmtpClient client = new SmtpClient("smtp.126.com");
            client.Credentials = new NetworkCredential("mailsupeng", "supeng4587");
            client.Send(mailMsg);
        }
    }
}
