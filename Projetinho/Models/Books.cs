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
        
        [Required(ErrorMessage = "Nome do Autor é obrigatório")]
        [StringLength(30, ErrorMessage = "O Nome não pode ter mais de 30 caracteres.")]
        [Display(Name = "Nome do Autor")]
        public string? Authorname {get; set;}

        [Required(ErrorMessage = "Título do livro é obrigatório")]
        [Display(Name = "Título do Livro")]
        public string Bookname {get; set;}

        [Display(Name = "Quantidade de Livros")]
        public int Bookquantity {get; set;}

        [Required]
        [ForeignKey("CatalogId")]
        [Display(Name = "Catálogo")]
        public int? CatalogId {get; set;}

        [Display(Name = "Catálogo")]
        public virtual Catalog? Catalog {get; set;}

        [Required]
        [ForeignKey("LibraianId")]
        [Display(Name = "Bibliotecário")]
        public int? LibraianId {get; set;}

        [Display(Name = "Bibliotecário")]
        public virtual Libraian? Libraian {get; set;}

        public Books() {}

        public Books(string authorname, string bookname, int bookquantity, Catalog catalog, Libraian libraian) {
            if(bookquantity < 0) {
                throw new Exception("Quantidade de livros não pode ser negativa");
            }
            Authorname = authorname;
            Bookname = bookname;
            Bookquantity = bookquantity;
            Catalog = catalog;
            Libraian = libraian;
        }

        public override string ToString() {
            return "Nome do Autor: " + Authorname + "\nNome do Livro: " + Bookname + "\nQuantidade de Livros: " + Bookquantity;
        }
        
        public void Addbk() {
            Catalog?.Addbk(this);
        }

        public void Removebk() {
            Catalog?.Removebk(this);
        }

        public void Addexemplebk(int quantity) { // exemplebk = exemplar de livro
            Bookquantity += quantity;
        }

        public void Removeexemplebk(int quantity) {
            Bookquantity -= quantity;
        }
    }
}