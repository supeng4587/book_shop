using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_shop.BLL
{
    public partial class CartBLL
    {
        /// <summary>
        /// 根据用户编号和商品编号得到一个购物车对象实体
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public book_shop.Model.CartModel GetModel(int userId,int bookId)
        {
            return dal.GetModel(userId, bookId);
        }

    }
}
