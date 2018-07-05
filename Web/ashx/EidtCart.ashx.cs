using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_shop.Web.ashx
{
    /// <summary>
    /// EidtCart 的摘要说明
    /// </summary>
    public class EidtCart : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int cartId = Convert.ToInt32(context.Request["cartId"]);
            int count = Convert.ToInt32(context.Request["Count"]);

            BLL.CartBLL cartManager = new BLL.CartBLL();
            Model.CartModel cartModel = cartManager.GetModel(cartId);
            if (cartModel != null)
            {
                cartModel.Count = count;
                if (cartManager.Update(cartModel))
                {
                    context.Response.Write("ok");
                }
                else
                {
                    context.Response.Write("no");
                }
            }
            else
            {
                context.Response.Write("no");
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}