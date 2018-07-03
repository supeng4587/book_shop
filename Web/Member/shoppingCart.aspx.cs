using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace book_shop.Web.Member
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        public List<Model.CartModel> CartList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.UsersBLL usersManager = new BLL.UsersBLL();
                if (usersManager.ValidateUserLogin())
                {
                    BindCartList();
                }
                else
                {
                    Common.WebCommon.RedirectPage();
                }
            }
        }

        protected void BindCartList()
        {
            BLL.CartBLL cartManager = new BLL.CartBLL();
            CartList = cartManager.GetModelList(" UserId = " + ((Model.UsersModel)Session["userInfo"]).Id);
        }
    }
}