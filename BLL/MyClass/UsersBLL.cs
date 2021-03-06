﻿using book_shop.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

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
        public int Add(UsersModel model, out string msg)
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
                    msg = "Login success";
                    isSuccess = true;
                }
                else
                {
                    msg = "Password is eror";
                }
            }
            else
            {
                msg = "The user does not exist";
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

        /// <summary>
        /// 找回用户密码
        /// </summary>
        /// <param name="userInfo"></param>
        public void FindUserPwd(Model.UsersModel userInfo)
        {
            BLL.SettingsBLL settingBLL = new SettingsBLL();
            //1.系统产生一个新的密码，然后更新数据库，再将新的密码发送到用户的邮箱中
            string newPwd = Guid.NewGuid().ToString().Substring(0, 4);
            userInfo.LoginPwd = newPwd;//一定要将系统产生的系密码加密后更新到数据库，但是发送到用户邮箱的密码一定是明文的
            dal.Update(userInfo);
            MailMessage mailMsg = new MailMessage();
            mailMsg.From = new MailAddress(settingBLL.GetValue("SysMailAddress"), "苏鹏");
            mailMsg.To.Add(new MailAddress(userInfo.Mail, "新浪收件人supeng"));
            mailMsg.Subject = "在商城网站中的用户";
            StringBuilder sb = new StringBuilder();
            sb.Append("用户名是：" + userInfo.LoginId);
            sb.Append("新密码是：" + userInfo.LoginPwd);
            mailMsg.Body = sb.ToString();
            SmtpClient client = new SmtpClient(settingBLL.GetValue("SysMailSMTP"), int.Parse(settingBLL.GetValue("SysMailSMTPPort")));
            client.Credentials = new NetworkCredential(settingBLL.GetValue("SysMailUserName"), settingBLL.GetValue("SysMailUserPass"));
            client.Send(mailMsg);//短时间内发送大量邮件时容易阻塞，所以可以将要发送的邮件先发送到队列中
        }


        public bool ValidateUserLogin()
        {
            bool result = false;
            HttpContext current = HttpContext.Current;
            if (current.Session["userInfo"] != null)
            {
                result= true;
            }
            else
            {
                if (current.Request.Cookies["cp1"] != null && current.Request.Cookies["cp2"] != null)
                {

                    string userName = current.Request.Cookies["cp1"].Value;
                    string userPwd = current.Request.Cookies["cp2"].Value;
                    Model.UsersModel userInfo = GetModel(userName);
                    if (userInfo != null)
                    {
                        if (userPwd == Common.WebCommon.GetMd5String(Common.WebCommon.GetMd5String(userInfo.LoginPwd)))
                        {
                            current.Session["userInfo"] = userInfo;
                            result= true;
                        }
                    }
                    else
                    {
                        current.Response.Cookies["cp1"].Expires = DateTime.Now.AddDays(-1);
                        current.Response.Cookies["cp2"].Expires = DateTime.Now.AddDays(-1);
                    }
                }
            }
            return result;
        }
    }
}
