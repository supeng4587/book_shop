﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace book_shop.Web
{
    public partial class BookDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Context.Response.Write(Context.Request["id"]);
        }
    }
}