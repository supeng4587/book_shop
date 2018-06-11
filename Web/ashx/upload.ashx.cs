using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace book_shop.Web.ashx
{
    /// <summary>
    /// upload 的摘要说明
    /// </summary>
    public class upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string action = context.Request["action"];
            switch (action)
            {
                case "upload":
                    ProcessFileUpload(context);
                    break;
                case "cut":
                    ProcessCutPhoto(context);
                    break;
                default:
                    context.Response.Write("参数错误!!");
                    break;
            }
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="context"></param>
        private void ProcessFileUpload(HttpContext context)
        {
            HttpPostedFile file = context.Request.Files["Filedata"];
            if (file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                string fileExt = Path.GetExtension(fileName);
                if (fileExt == ".jpg")
                {
                    string dir = "/ImageUpload/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                    if (!Directory.Exists(context.Request.MapPath(dir)))
                    {
                        Directory.CreateDirectory(context.Request.MapPath(dir));
                    }
                    string newfileName = Guid.NewGuid().ToString();
                    string fullDir = dir + newfileName + fileExt;
                    file.SaveAs(context.Request.MapPath(fullDir));
                    using (Image img = Image.FromFile(context.Request.MapPath(fullDir)))
                    {
                        context.Response.Write(fullDir + ":" + img.Width + ":" + img.Height);
                    }

                    //file.SaveAs(context.Request.MapPath("/ImageUpload/"+fileName));
                    //context.Response.Write("/ImageUpload/" + fileName);
                }
            }
        }

        /// <summary>
        /// 截取图片
        /// </summary>
        /// <param name="context"></param>
        private void ProcessCutPhoto(HttpContext context)
        {
            string stringX = context.Request["x"];
            string stringY = context.Request["y"];

            int x = Convert.ToInt32(stringX);
            int y = (int)Convert.ToDouble(stringY);//string过来的如果是double，convert.toint32转换不过去，但也不报错
            int width = Convert.ToInt32(context.Request["width"]);
            int height =Convert.ToInt32(context.Request["height"]);
            string imgSrc = context.Request["imgSrc"]; //通过隐藏域获取上传成功的文件路径
            using (Bitmap map = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(map))
                {
                    using (Image img = Image.FromFile(context.Request.MapPath(imgSrc)))
                    {
                        //img：要操作的图片
                        //第一个矩形：要画图的尺寸
                        //第二个矩形：截取原图上的区域
                        //绘画的单位
                        g.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
                        string newFileName = Guid.NewGuid().ToString();
                        string fullDir = "/ImageUpload/" + newFileName + ".jpg";
                        map.Save(context.Request.MapPath(fullDir), System.Drawing.Imaging.ImageFormat.Jpeg);
                        context.Response.Write(fullDir);
                    }

                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}