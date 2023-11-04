using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projetinho.Models
{
    public class Books
    {

        [Display(Name = "Código")]
        public int Id {get; set;}
        
        [Required]
        [Display(Name = "Nome do Autor")]
        public string? Authorname {get; set;}

        [Required]
        [Display(Name = "Nome do Livro")]
        public string? Bookname {get; set;}

        [Display(Name = "Quantidade de Livros")]
        public int Bookquantity {get; set;}

        public Books() {}

        [Required]
        public virtual Catalog? Catalog {get; set;}

        public Books(string authorname, string bookname, int bookquantity, Catalog catalog) {
            if(bookquantity < 0) {
                throw new Exception("Quantidade de livros não pode ser negativa");
            }
            Authorname = authorname;
            Bookname = bookname;
            Bookquantity = bookquantity;
            Catalog = catalog;
        } 

        public override string ToString() {
            return "Nome do Autor: " + Authorname + "\nNome do Livro: " + Bookname + "\nQuantidade de Livros: " + Bookquantity;
        }
        
        public void Addbk() {
            Catalog.Addbk(this);
        }

        public void Removebk() {
            Catalog.Removebk(this);
        }

        public void Addexemplebk(int quantity) { // exemplebk = exemplar de livro
            Bookquantity += quantity;
        }

        public void Removeexemplebk(int quantity) {
            Bookquantity -= quantity;
        }
    }
}