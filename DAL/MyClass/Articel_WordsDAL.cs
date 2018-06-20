using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_shop.DAL
{
    public partial class Articel_WordsDAL
    {

        /// <summary>
        /// 获取所有的禁用词
        /// </summary>
        /// <returns></returns>
        public List<string> GetForbidWord()
        {
            string sql = "SELECT [WordPattern] FROM dbo.Articel_Words WHERE [IsForbid]=1";
            List<string> list = null;
            using(SqlDataReader dr = DbHelperSQL.ExecuteReader(sql))
            {
                if (dr.HasRows)
                {
                    list = new List<string>();
                    while (dr.Read())
                    {
                        list.Add(dr["WordPattern"].ToString());
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 获取所有的审查词
        /// </summary>
        /// <returns></returns>
        public List<string> GetModWord()
        {
            string sql = "SELECT [WordPattern] FROM dbo.Articel_Words WHERE [IsMod] = 1";
            List<string> list = null;
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(sql))
            {
                if (dr.HasRows)
                {
                    list = new List<string>();
                    while (dr.Read())
                    {
                        list.Add(dr["WordPattern"].ToString());
                    }
                }
            }
            return list;
        }
    }
}
