using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace book_shop.Web
{
    public partial class ShowMsg : System.Web.UI.Page
    {
        public string Msg { get; set; }
        public string PageTitle { get; set; }
        public string Url { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Msg = string.IsNullOrEmpty(Request["msg"]) ? "暂无信息" : Request["msg"];
            PageTitle = string.IsNullOrEmpty(Request["txt"]) ? "商品列表" : Request["txt"];
            Url = string.IsNullOrEmpty(Request["redirect"]) ? "/BookList.aspx" : Request["redirect"];
        }
    }
}