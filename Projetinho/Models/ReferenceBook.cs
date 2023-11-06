using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projetinho.Models
{
    public class ReferenceBook : Books
    {
        public ReferenceBook() {}

        public ReferenceBook(string authorname, string bookname, int bookquantity, Catalog catalog, Libraian libraian) : base(authorname, bookname, bookquantity, catalog, libraian) {
            Authorname = authorname;
            Bookname = bookname;
            Bookquantity = bookquantity;
            Catalog = catalog;
            Libraian = libraian;
        }

        public Books? Searchrefbk(string bookname) {
            foreach (Books bk in Catalog.Books) {
                if (bk.Bookname == bookname) {
                    Console.WriteLine(bk.ToString());
                    return bk;
                }
            }
            Console.WriteLine("Livro não encontrado");
            return null;
        }
        
    }
}