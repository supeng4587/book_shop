using book_shop.Web.ViewModel;
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
        BLL.BookCommentBLL bookCommentManager = new BLL.BookCommentBLL();
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
                    LoadComment(context);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="context"></param>
        private void AddComment(HttpContext context)
        {
            BLL.Articel_WordsBLL articelWordManger = new BLL.Articel_WordsBLL();
            string msg = context.Request["msg"];
            bool isPass;
            //判断是否含有禁用词
            if (articelWordManger.CheckForbid(msg))
            {
                context.Response.Write("no:评论中含有禁用词");
            }
            else if (articelWordManger.CheckMod(msg)) 
            {
                isPass = false;
            }
            else
            {
                isPass = true
            }
            Model.BookCommentModel bookComment = new Model.BookCommentModel();
            bookComment.BookId = Convert.ToInt32(context.Request["bookId"]);
            bookComment.Msg = msg;
            bookComment.CreateDateTime = System.DateTime.Now;
            bookComment.isPass = isPass;
            if (bookCommentManager.Add(bookComment) > 0)
            {
                context.Response.Write("ok:评论成功");
            }
            else
            {
                context.Response.Write("no:评论失败");
            }
        }

        /// <summary>
        /// 加载评论
        /// </summary>
        /// <param name="context"></param>
        private void LoadComment(HttpContext context)
        {
            Model.BookCommentModel bookComment = new Model.BookCommentModel();
            bookComment.BookId = Convert.ToInt32(context.Request["bookId"]);
            List<Model.BookCommentModel> list = bookCommentManager.GetModelList("BookId = " + bookComment.BookId);
            List<BookCommentViewModel> newList = new List<BookCommentViewModel>();
            foreach (var item in list)
            {
                ViewModel.BookCommentViewModel viewModel = new BookCommentViewModel();
                viewModel.Msg = item.Msg;
                viewModel.CreateDateTime = Common.WebCommon.GetTimeSpan(System.DateTime.Now - item.CreateDateTime);//获取时间差
                newList.Add(viewModel);
            }
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            context.Response.Write(js.Serialize(newList));
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