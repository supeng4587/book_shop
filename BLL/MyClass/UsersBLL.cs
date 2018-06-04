using book_shop.Model;
using System;
using System.Collections.Generic;
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
    }
}
