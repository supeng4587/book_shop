using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace book_shop.Web.AdminManager
{
    public partial class AddCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string msg = Request["txtMsg"];
                msg = msg.Trim();
                string[] words = msg.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                BLL.Articel_WordsBLL articelWordManager = new BLL.Articel_WordsBLL();
                foreach (var item in words)
                {
                    string[] w = item.Split('=');
                    Model.Articel_WordsModel articelWord = new Model.Articel_WordsModel();
                    articelWord.WordPattern = w[0];
                    switch (w[1])
                    {
                        case "{BANNED}":
                            articelWord.IsForbid = true;
                            break;
                        case "{MOD}":
                            articelWord.IsMod = true;
                            break;
                        default:
                            articelWord.ReplaceWord = w[1];
                            break;
                    }
                    articelWordManager.Add(articelWord);
                }
            }
        }
    }
}