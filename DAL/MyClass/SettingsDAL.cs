using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maticsoft.DBUtility;

namespace book_shop.DAL
{
    public partial class SettingsDAL
    {
        public book_shop.Model.SettingsModel GetModel(string key)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name,Value from Settings ");
            strSql.Append(" where Name=@name");
            SqlParameter[] parameters = {
                    new SqlParameter("@name", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = key;

            book_shop.Model.SettingsModel model = new book_shop.Model.SettingsModel();
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
    }
}
