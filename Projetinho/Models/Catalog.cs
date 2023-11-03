using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New_Project_Dotnet.Models
{
    public class Catalog
    {

        [Display(Name = "Nome do Catalogo")]
        public string Catalogname {get; set;}

        public virtual ICollection<Books> Books {get; set;}

        public Catalog(string catalogname) {
            Catalogname = catalogname;
            Books = new List<Books>();
        }

        internal void Addbk(Books books)
        {
            foreach (Books bk in Books) {
                if (bk.Bookname == books.Bookname) {
                    bk.Addexemplebk(books.Bookquantity);
                    return;
                }
            }
            Books.Add(books);
        }

        internal void Removebk(Books books)
        {
            
            foreach (Books bk in Books) {
                if (bk.Bookname == books.Bookname) {
                    bk.Removeexemplebk(books.Bookquantity);
                    if (bk.Bookquantity == 0) {
                        Books.Remove(bk);
                    }
                    return;
                }
            }
        }
    }
}