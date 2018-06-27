using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_shop.Web.ashx
{
    /// <summary>
    /// ProductCart 的摘要说明
    /// </summary>
    public class ProductCart : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BLL.UsersBLL userManager = new BLL.UsersBLL();
            if (userManager.ValidateUserLogin())
            {
                int bookId = Convert.ToInt32(context.Request["bookId"]);

                //
                BLL.BooksBLL bookManger = new BLL.BooksBLL();
                Model.BooksModel bookModel = bookManger.GetModel(bookId);
                if (bookModel != null)
                {
                    int userId = ((Model.UsersModel)context.Session["userInfo"]).Id;
                    BLL.CartBLL cartManager = new BLL.CartBLL();
                    Model.CartModel cartModel = cartManager.GetModel(userId, bookId);
                    if (cartModel != null)
                    {
                        cartModel.Count += 1;
                        cartManager.Update(cartModel);
                    }
                    else
                    {
                        cartModel = new Model.CartModel();
                        cartModel.Count = 1;
                        cartModel.UserId = userId;
                        cartModel.BookId = bookId;
                        cartManager.Add(cartModel);
                    }
                    context.Response.Write("{\"action\":\"have\",\"message\":\"已添加到购物车\"}");
                }
                else
                {
                    context.Response.Write("{\"action\":\"notHave\",\"message\":\"无此商品\"}");
                }

                //context.Response.Write("{\"action\":\"ok\",\"message\":\"登录成功\"}");
            }else
            {
                context.Response.Write("{\"action\":\"notLogin\",\"message\":\"您还没有登陆\"}");
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