using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace book_shop.DAL
{
    public partial class UsersDAL
    {
        /// <summary>
        /// 根据用户名，得到一个对象实体
        /// </summary>
        public book_shop.Model.UsersModel GetModel(string userName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,LoginId,LoginPwd,Name,Address,Phone,Mail,UserStateId from Users ");
            strSql.Append(" where LoginId=@LoginId");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginId", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = userName;

            book_shop.Model.UsersModel model = new book_shop.Model.UsersModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public int CheckUserMail(string mail)
        {
            string sql = "select count(*) from users where mail=@mail";
            SqlParameter[] parameters ={
                new SqlParameter("@mail",SqlDbType.NVarChar,100)
            };
            parameters[0].Value = mail;
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql, parameters));
        }
    }
}
