using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Projetinho.Models;
namespace New_Project_Dotnet.Models

{
    public class Member
    {

        [Display(Name = "Código")]
        public int Id {get; set;}

        [Display(Name = "Nome")]
        public String Name {get; set;}

        [Display(Name = "Endereco")]
        public String Address {get; set;}

        [Display(Name = "Contato")]
        public int Contact {get; set;}

        public virtual Libraian Libraian {get; set;}
        public virtual ICollection<Books> Books {get; set;}

        public Member(string name, string address, int contact , Libraian libraian) {
            Name = name;
            Address = address;
            Contact = contact;
            Books = new List<Books>();
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