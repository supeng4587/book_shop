using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Web.Hosting;

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
    }
}
