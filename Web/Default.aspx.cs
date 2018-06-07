using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Threading;

namespace book_shop.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Path.Combine();
            //HttpRuntime.AppDomainAppPath;
            //Request.MapPath();
            
            Thread thread1 = new Thread(GetFilePath);
            thread1.IsBackground = true;
            thread1.Start(HttpContext.Current);
        }

        protected void GetFilePath(object context)
        {
            //string filePath = Request.MapPath("/Images/body.jpg");
            Common.WebCommon.GetFilePath(context);
        }
    }
}
