using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projetinho.Models
{
    public class GeneralBook : Books
    {

        [ForeignKey("MemberId")]
        public int? MemberId {get; set;}

        [Display(Name = "Nome do Membro")]
        public virtual Member? Member {get; set;}

        public GeneralBook() {}

        public GeneralBook(string authorname, string bookname, int bookquantity, Catalog catalog, Libraian libraian) : base(authorname, bookname, bookquantity, catalog, libraian) {
            Authorname = authorname;
            Bookname = bookname;
            Bookquantity = bookquantity;
            Catalog = catalog;
            Libraian = libraian;
        }
    }
}