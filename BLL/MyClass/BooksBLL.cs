using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_shop.BLL
{
    public partial class BooksBLL
    {
        public int GetPageCount(int pageSize)
        {
            int recordCount = dal.GetCordCount();
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
            return pageCount;
        }

        public List<Model.BooksModel> GetPageList(int pageIndex,int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            DataSet ds = dal.GetPageList(start, end);
            return DataTableToList(ds.Tables[0]);
        }
    }
}
