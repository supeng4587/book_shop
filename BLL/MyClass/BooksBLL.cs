using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace book_shop.BLL
{
    public partial class BooksBLL
    {
        /// <summary>
        /// 获取分页pageCount
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            int recordCount = dal.GetCordCount();
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }

        /// <summary>
        /// 指定数据范围，获取分页pageList
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Model.BooksModel> GetPageList(int pageIndex,int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            DataSet ds = dal.GetPageList(start, end);
            return DataTableToList(ds.Tables[0]);
        }

        public void CreateHtmlePage(int id)
        {
            Model.BooksModel booksInfo = dal.GetModel(id);
            //获取模板文件
            string template = HttpContext.Current.Request.MapPath("/Template/BookTemplate.html");
            string fileContent = File.ReadAllText(template);
            fileContent = fileContent.Replace("$title", booksInfo.Title).Replace("$author", booksInfo.Author).Replace("$unitprice", booksInfo.UnitPrice.ToString("0.00")).Replace("$isbn", booksInfo.ISBN).Replace("$content", booksInfo.ContentDescription);
            string dir = "/HtmlPage/" + booksInfo.PublishDate.Year + "/" ;
            Directory.CreateDirectory(Path.GetDirectoryName(HttpContext.Current.Request.MapPath(dir)));
            string fullDir = dir + booksInfo.Id + ".html";
            File.WriteAllText(HttpContext.Current.Request.MapPath(fullDir), fileContent, System.Text.Encoding.UTF8);
        }
    }
}
