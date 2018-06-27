using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_shop.DAL
{
    public partial class CartDAL
    {
        /// <summary>
        /// 根据用户编号和商品编号得到一个购物车对象实体
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public book_shop.Model.CartModel GetModel(int userId,int bookId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,UserId,BookId,Count from Cart ");
            strSql.Append(" where UserId=@userId and BookId=@bookId");
            SqlParameter[] parameters = {
                    new SqlParameter("@userId", SqlDbType.Int,4),
                    new SqlParameter("@bookId",SqlDbType.Int,4)
            };
            parameters[0].Value = userId;
            parameters[1].Value = bookId;

            book_shop.Model.CartModel model = new book_shop.Model.CartModel();
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
