using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace book_shop.Web.AdminManager
{
    public partial class AuditModWord : System.Web.UI.Page
    {
        public List<Model.BookCommentModel> List { get; set; }
        BLL.BookCommentBLL bookCommentManager = new BLL.BookCommentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = bookCommentManager.GetList("IsPass = 0");
            List = fromDsChangeToList(ds);

            //if (IsPostBack)
            //{
            //    switch (Request["action"])
            //    {
            //        case "pass":
            //            Response.Write(audit(Convert.ToInt32(Request["id"])));
            //            break;
            //        case "delete":
            //            Response.Write(delete(Convert.ToInt32(Request["id"])));
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }

        private string audit(int id)
        {
            Model.BookCommentModel model = bookCommentManager.GetModel(id);
            model.IsPass = true;
            if (bookCommentManager.Update(model))
            {
                return "{ok:审核通过}";
            }
            else
            {
                return "no:更新失败";
            }
        }

        private string delete(int id)
        {
            if (bookCommentManager.Delete(id))
            {
                return "ok:消息已删除";
            }
            else
            {
                return "no:删除失败";
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
    }
}