using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Common
{
    public class WebCommon
    {
        /// <summary>
        /// 线程内唯一对象 CallContext
        /// </summary>
        /// <param name="obj"></param>
        public static void GetFilePath(object obj)
        {
            HttpContext context = (HttpContext)obj;
            string filePath = context.Request.MapPath("/Images/body.jpg");
            string filePath1 = HostingEnvironment.MapPath("/Images/body.jpg");
        }

        /// <summary>
        /// 完成验证码校验
        /// </summary>
        /// <returns></returns>
        public static bool CheckValidateCode(string validateCode)
        {
            bool isSucess = false;
            if (HttpContext.Current.Session["vCode"] != null)
            {
                string txtCode = validateCode;
                string sysCode = HttpContext.Current.Session["vCode"].ToString();
                if (sysCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
                {
                    isSucess = true;
                    //Session["vCode"] = null;
                }
                HttpContext.Current.Session["vCode"] = null;//验证对不对都把session清了
            }
            return isSucess;
        }

        /// <summary>
        /// 跳转页面的Get请求
        /// </summary>
        public static void RedirectPage()
        {
            HttpContext.Current.Response.Redirect("/Member/Login.aspx?returnUrl=" + HttpContext.Current.Request.Url.ToString());
        }

        /// <summary>
        /// 对字符串进行MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMd5String(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] md5Buffer = md5.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            foreach (var item in md5Buffer)
            {
                sb.Append(item.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 对时间差进行字符串化处理
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static string GetTimeSpan(TimeSpan ts)
        {
            if (ts.TotalDays >= 365)
            {
                return Math.Floor(ts.TotalDays / 365) + "年前";
            }
            else if (ts.TotalDays >= 30)
            {
                return Math.Floor(ts.TotalDays / 30) + "月前";
            }
            else if (ts.TotalHours >= 24)
            {
                return Math.Floor(ts.TotalDays) + "天前";
            }
            else if (ts.TotalHours >= 1)
            {
                return Math.Floor(ts.TotalHours) + "小时前";
            }
            else if (ts.TotalMinutes > 1)
            {
                return Math.Floor(ts.TotalMinutes) + "分钟前";
            }
            else
            {
                return "刚刚";
            }
        }

        /// <summary>
        /// 将UBB编码转换成HTML编码
        /// </summary>
        /// <param name="argString"></param>
        /// <returns></returns>
        public static string UbbToHtml(string argString)
        {
            string tString = argString;
            if (tString != "")
            {
                Regex tRegex;
                bool tState = true;
                //替换掉了危险字符防止跨站脚本攻击，同样text位置都应该有此类的替换
                tString = tString.Replace("&", "&amp;");
                tString = tString.Replace(">", "&gt;");
                tString = tString.Replace("<", "&lt;");
                tString = tString.Replace("\"", "&quot;");
                tString = Regex.Replace(tString, @"\[br\]", "<br />", RegexOptions.IgnoreCase);
                string[,] tRegexAry = {
          {@"\[p\]([^\[]*?)\[\/p\]", "$1<br />"},
          {@"\[b\]([^\[]*?)\[\/b\]", "<b>$1</b>"},
          {@"\[i\]([^\[]*?)\[\/i\]", "<i>$1</i>"},
          {@"\[u\]([^\[]*?)\[\/u\]", "<u>$1</u>"},
          {@"\[ol\]([^\[]*?)\[\/ol\]", "<ol>$1</ol>"},
          {@"\[ul\]([^\[]*?)\[\/ul\]", "<ul>$1</ul>"},
          {@"\[li\]([^\[]*?)\[\/li\]", "<li>$1</li>"},
          {@"\[code\]([^\[]*?)\[\/code\]", "<div class=\"ubb_code\">$1</div>"},
          {@"\[quote\]([^\[]*?)\[\/quote\]", "<div class=\"ubb_quote\">$1</div>"},
          {@"\[color=([^\]]*)\]([^\[]*?)\[\/color\]", "<font style=\"color: $1\">$2</font>"},
          {@"\[hilitecolor=([^\]]*)\]([^\[]*?)\[\/hilitecolor\]", "<font style=\"background-color: $1\">$2</font>"},
          {@"\[align=([^\]]*)\]([^\[]*?)\[\/align\]", "<div style=\"text-align: $1\">$2</div>"},
          {@"\[url=([^\]]*)\]([^\[]*?)\[\/url\]", "<a href=\"$1\">$2</a>"},
          {@"\[img\]([^\[]*?)\[\/img\]", "<img src=\"$1\" />"}
        };
                while (tState)
                {
                    tState = false;
                    for (int ti = 0; ti < tRegexAry.GetLength(0); ti++)
                    {
                        tRegex = new Regex(tRegexAry[ti, 0], RegexOptions.IgnoreCase);
                        if (tRegex.Match(tString).Success)
                        {
                            tState = true;
                            tString = Regex.Replace(tString, tRegexAry[ti, 0], tRegexAry[ti, 1], RegexOptions.IgnoreCase);
                        }
                    }
                }
            }
            return tString;
        }
    }
}
