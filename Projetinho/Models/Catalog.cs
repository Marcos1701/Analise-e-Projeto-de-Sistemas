using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projetinho.Models
{
    public class Catalog
    {

        [Display(Name = "Código")]
        public int Id {get; set;}

        [Required(ErrorMessage = "Nome do Autor é obrigatório")]
        [StringLength(30, ErrorMessage = "O Nome não pode ter mais de 30 caracteres.")]
        [Display(Name = "Nome do Autor")]
        public string Authorname {get; set;}

        [Display(Name = "Quantidade de Copias")]
        public int? Quantitycopies {get; set;}

        public virtual ICollection<Books> Books {get; set;}

        public Catalog() {
            Books = new List<Books>();
        }

        public Catalog(string authorname, int quantitycopies) {
            Authorname = authorname;
            Quantitycopies = quantitycopies;
        }

        public void Addbk(Books books)
        {
            foreach (Books bk in Books) {
                if (bk.Bookname == books.Bookname) {
                    bk.Addexemplebk(books.Bookquantity);
                    return;
                }
            }
            Books.Add(books);
        }

        public void Removebk(Books books)
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

        public void Updateinfo(string authorname, int quantitycopies) {
            Authorname = authorname;
            Quantitycopies = quantitycopies;
        }

        public Books? Searchbk(string bookname) {
            foreach (Books bk in Books) {
                if (bk.Bookname == bookname) {
                    return bk;
                }
            }
            return null;
        }
    }
}