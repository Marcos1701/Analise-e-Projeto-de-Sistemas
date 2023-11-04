using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projetinho.Models
{
    public class GeneralBook : Books
    {

        public GeneralBook() {}

        public GeneralBook(string authorname, string bookname, int bookquantity, Catalog catalog) : base(authorname, bookname, bookquantity, catalog) {
            Authorname = authorname;
            Bookname = bookname;
            Bookquantity = bookquantity;
            Catalog = catalog;
        }
    }
}