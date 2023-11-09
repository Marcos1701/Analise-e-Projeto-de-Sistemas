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

        [Required(ErrorMessage = "Nome do Membro é obrigatório")]
        [StringLength(30, ErrorMessage = "O Nome não pode ter mais de 30 caracteres.")]
        [Display(Name = "Nome")]
        public string? Name {get; set;}

        [Display(Name = "Endereço")]
        public string? Address {get; set;}

        [Required(ErrorMessage = "Número de Contato é obrigatório")]
        [Display(Name = "Contato")]
        public int Contact {get; set;}

        public virtual ICollection<GeneralBook>? GeneralBooks {get; set;}
        public virtual ICollection<Libraian>? Libraians {get; set;}

        public virtual Libraian? Libraian {get; set;}

        public Member() {
            GeneralBooks = new List<GeneralBook>();
            Libraians = new List<Libraian>();
        }

        public Member(string name, string address, int contact) {
            Name = name;
            Address = address;
            Contact = contact;
        }

        // request for book = solicitar livro
        public void Requestforbk(string bookname){
            Libraian.Issuebooks(bookname, this);
        }

        // return book = retornar livro

        public void Returnbk(Books book){
            Libraian.Returnbk(book, this);
        }
    }
}