using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maticsoft.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace book_shop.DAL
{
    public partial class BooksDAL
    {
        public int GetCordCount()
        {
            string sql = "SELECT COUNT(*) FROM Books";
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql));
        }

        public DataSet GetPageList(int start, int end)
        {
            string sql = "SELECT t.* FROM(SELECT *,row_number()over(order by id) as num FROM Books) as t WHERE t.num>=@start AND t.num<=@end";
            SqlParameter[] parameters = {
                    new SqlParameter("@start", SqlDbType.Int, 32),
                    new SqlParameter("@end", SqlDbType.Int, 32)};
            parameters[0].Value = start;
            parameters[1].Value = end;

            return DbHelperSQL.Query(sql, parameters);
        }
    }
}
