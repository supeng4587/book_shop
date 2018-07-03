using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_shop.Model
{
    public partial class CartModel
    {
        private UsersModel _user = new UsersModel();
        private BooksModel _book = new BooksModel();

        public UsersModel User
        {
            set { _user = value; }
            get { return _user; }
        }

        public BooksModel Book
        {
            set { _book = value; }
            get { return _book; }
        }
    }
}
