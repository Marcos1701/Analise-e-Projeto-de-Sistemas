using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Projetinho.Models

{
    public class Member
    {

        [Display(Name = "Código")]
        public int Id {get; set;}

        [Required]
        [Display(Name = "Nome")]
        public string? Name {get; set;}

        [Required]
        [Display(Name = "Endereco")]
        public string? Address {get; set;}

        [Required]
        [Display(Name = "Contato")]
        public int Contact {get; set;}

        public virtual Libraian? Libraian {get; set;}
        public virtual ICollection<Books>? Books {get; set;}

        public Member() {
            Books = new List<Books>();
        }

        public Member(string name, string address, int contact , Libraian libraian) {
            Name = name;
            Address = address;
            Contact = contact;
            Libraian = libraian;
        }

        // request for book = solicitar livro
        void Requestforbk(String bookname){
            Libraian.Issuebooks(bookname, this);
        }

        // return book = retornar livro

        void Returnbk(Books book){
            Libraian.Returnbk(book, this);
        }
    }
}