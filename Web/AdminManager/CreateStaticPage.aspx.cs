using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace book_shop.Web.AdminManager
{
    public partial class CreateStaticPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                BLL.BooksBLL bookManage = new BLL.BooksBLL();
                List<Model.BooksModel> list = bookManage.GetModelList("");
                foreach (var item in list)
                {
                    bookManage.CreateHtmlePage(item.Id);
                }
            }
        }
    }
}