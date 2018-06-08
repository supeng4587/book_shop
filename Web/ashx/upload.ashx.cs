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

            HttpPostedFile postedFile = context.Request.Files["FileData"];
            if (postedFile != null)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                string fileExt = Path.GetExtension(postedFile.FileName);
                if (fileExt == ".jpg")
                {
                    string dir = "/ImageUpload/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                    if (!Directory.Exists(context.Request.MapPath(dir)))
                    {
                        Directory.CreateDirectory(context.Request.MapPath(dir));
                    }
                    string newFileName = Guid.NewGuid().ToString();
                    string fullPath = dir + newFileName + fileExt;
                    postedFile.SaveAs(context.Request.MapPath(fullPath));
                    context.Response.Write(fullPath);
                }
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

        private void ProcessCutPhoto(HttpContext context)
        {
            int x = Convert.ToInt32(context.Request["x"]);
            int y = Convert.ToInt32(context.Request["y"]);
            int width = Convert.ToInt32(context.Request["width"]);
            int height = Convert.ToInt32(context.Request["height"]);
            string imgSrc = context.Request["imgSrc"]; //通过隐藏域获取上传成功的文件路径
            using(Bitmap map =new Bitmap(width, height))
            {
                using(Graphics g = Graphics.FromImage(map))
                {
                    using(Image img = Image.FromFile(context.Request["imgSrc"]))
                    {
                        //img：要操作的图片
                        //第一个矩形：要画图的尺寸
                        //第二个矩形：截取原图上的区域
                        //绘画的单位
                        g.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
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