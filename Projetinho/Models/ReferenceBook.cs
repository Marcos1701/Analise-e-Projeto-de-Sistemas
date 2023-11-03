using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using New_Project_Dotnet.Models;

namespace Projetinho.Models
{
    public class ReferenceBook : Books
    {

        public ReferenceBook(string authorname, string bookname, int bookquantity, Catalog catalog) : base(authorname, bookname, bookquantity, catalog) {
            Authorname = authorname;
            Bookname = bookname;
            Bookquantity = bookquantity;
            Catalog = catalog;
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