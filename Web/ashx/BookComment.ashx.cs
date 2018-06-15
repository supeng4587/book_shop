using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace book_shop.Web.ashx
{
    /// <summary>
    /// BookComment 的摘要说明
    /// </summary>
    public class BookComment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            switch (action)
            {
                case "add":
                    AddComment(context);
                    break;
                case "load":
                    break;
                default:
                    break;
            }
        }

        private void AddComment(HttpContext context)
        {
            Model.BookCommentModel bookComment = new Model.BookCommentModel();
            bookComment.BookId = Convert.ToInt32(context.Request["bookId"]);
            bookComment.Msg = context.Request["msg"];
            bookComment.CreateDateTime = System.DateTime.Now;
            BLL.BookCommentBLL bookCommentManager = new BLL.BookCommentBLL();
            if (bookCommentManager.Add(bookComment) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("no");
            }
        }

        private void LoadComment(HttpContext context)
        {
            Model.BookCommentModel bookComment = new Model.BookCommentModel();
            bookComment.BookId = Convert.ToInt32(context.Request["bookId"]);
            BLL.BookCommentBLL bookCommentManager = new BLL.BookCommentBLL();
            bookCommentManager.GetList
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