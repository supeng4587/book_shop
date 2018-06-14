using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace book_shop.Web.Member
{
    public partial class BookList : System.Web.UI.Page
    {
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        BLL.SettingsBLL setting = new BLL.SettingsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBookList();
            }
        }


        protected void BindBookList()
        {
            int pageIndex;
            if(!int.TryParse(Request["pageIndex"],out pageIndex))
            {
                pageIndex = 1;
            }

            int pageSize;
            if(int.TryParse(setting.GetValue("pageSize"),out pageSize))
            {
                pageSize = 5;
            }

            BLL.BooksBLL bookManager = new BLL.BooksBLL();
            int pageCount = bookManager.GetPageCount(pageSize);
            PageCount = pageCount;
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;
            PageIndex = pageIndex;

            this.BookListRepeater.DataSource = bookManager.GetPageList(pageIndex, pageSize);
            this.BookListRepeater.DataBind();

            //BLL.BooksBLL bookManager = new BLL.BooksBLL();
            //this.BookListRepeater.DataSource = bookManager.GetModelList("");
            //this.BookListRepeater.DataBind();
        }

        public string CutString(string str,int lenght)
        {
            return str.Length > lenght ? str.Substring(0, lenght) + "......" : str;
        }

        public string GetString(object obj)
        {
            DateTime time = Convert.ToDateTime(obj);
            return "/HtmlPage/" + time.Year+"/";

        }
    }
}