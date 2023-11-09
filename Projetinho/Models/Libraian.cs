using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projetinho.Models
{
    public class Libraian
    {

        [Display(Name = "Código")]
        public int Id {get; set;}
        
        [Required(ErrorMessage = "Nome da Livraria é obrigatório")]
        [StringLength(30, ErrorMessage = "O Nome não pode ter mais de 30 caracteres.")]
        [Display(Name = "Nome da Livraria")]
        public string? Name {get; set;}

        [Required(ErrorMessage = "Endereço é obrigatório")]
        [Display(Name = "Endereço")]
        public string? Address {get; set;}

        [Required(ErrorMessage = "Número do Contato é obrigatório")]
        [Display(Name = "Contato")]
        public int Mobileno {get; set;} // mobileno = mobile number

        public virtual ICollection<Books>? Books {get; set;}
        public virtual ICollection<Member>? Members {get; set;}
        public virtual ICollection<Alert>? Alerts {get; set;}
        
        // implementando metodos

        public Libraian() {
            Books = new List<Books>();
            Members = new List<Member>();
            Alerts = new List<Alert>();
        }

        public Libraian(string name, string address, int mobileno) {
            Name = name;
            Address = address;
            Mobileno = mobileno;
        }

        public override string ToString() {
            return "Nome da Livraria: " + Name + "\nEndereco: " + Address + "\nContato: " + Mobileno;
        }

        // update info = atualizar informacao
        public void Updateinfo(string name, string address, int mobileno) {
            Name = name;
            Address = address;
            Mobileno = mobileno;
        }

        // issue books = emprestar livros
        public void Issuebooks(string bookname, Member member) {
            GeneralBook? book = (GeneralBook?)Searchbk(bookname);

            if(book == null) {
                Console.WriteLine("Livro nao encontrado");
            }

            if (book.Bookquantity > 0) {
                book.Bookquantity--;
                member.GeneralBooks.Add(book);
            }
            Console.WriteLine("Livro nao disponivel");
        }

        // member info = informacao do membro
        public void Memberinfo(Member member) {
            Console.WriteLine(member.ToString());
        }

        // search bk = procurar livro
        public Books? Searchbk(string bookname) {
            foreach (Books book in Books) {
                if (book.Bookname == bookname) {
                    return book;
                }
            }
            Console.WriteLine("Livro nao encontrado");
            return null;
        }

        // return bk = devolver livro
        public void Returnbk(Books book, Member member) {
            if (member.GeneralBooks.Contains(book)) {
                book.Bookquantity++;
                member.GeneralBooks.Remove((GeneralBook)book);
            }
            Console.WriteLine("Livro nao encontrado");
        }
    }
}