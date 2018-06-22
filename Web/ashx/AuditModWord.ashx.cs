using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace book_shop.Web.ashx
{
    /// <summary>
    /// AuditModWord 的摘要说明
    /// </summary>
    public class AuditModWord : IHttpHandler
    {
        BLL.BookCommentBLL bookCommentManager = new BLL.BookCommentBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (context.Request["action"])
            {
                case "pass":
                    context.Response.Write(audit(Convert.ToInt32(context.Request["id"])));
                    break;
                case "delete":
                    context.Response.Write(delete(Convert.ToInt32(context.Request["id"])));
                    break;
                default:
                    break;
            }
        }

        private string audit(int id)
        {
            Model.BookCommentModel model = bookCommentManager.GetModel(id);
            model.IsPass = true;
            if (bookCommentManager.Update(model))
            {
                return "{\"state\":\"ok\",\"measage\":\"审核通过\"}";
            }
            else
            {
                return "{\"state\":\"no\",\"measage\":\"更新失败\"}";
            }
        }

        private string delete(int id)
        {
            if (bookCommentManager.Delete(id))
            {
                return "{\"state\":\"ok\",\"measage\":\"消息已删除\"}";
            }
            else
            {
                return "{\"state\":\"no\",\"measage\":\"删除失败\"}";
            }
        }

        protected List<Model.BookCommentModel> fromDsChangeToList(DataSet ds)
        {
            List<Model.BookCommentModel> list = new List<Model.BookCommentModel>();
            if (ds.Tables["ds"] != null && ds.Tables["ds"].Rows.Count > 0)
            {
                foreach (DataRow item in ds.Tables["ds"].Rows)
                {
                    Model.BookCommentModel bcm = new Model.BookCommentModel();
                    bcm.Id = Convert.ToInt32(item["Id"]);
                    bcm.Msg = item["Msg"].ToString();
                    bcm.CreateDateTime = Convert.ToDateTime(item["CreateDateTime"]);
                    bcm.BookId = Convert.ToInt32(item["BookId"]);
                    bcm.IsPass = Convert.ToBoolean(item["IsPass"]);

                    list.Add(bcm);
                }
            }
            return list;
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