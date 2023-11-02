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

        [Display(Name = "Nome da Livraria")]
        public String Name {get; set;}

        [Display(Name = "Endereco")]
        public String Address {get; set;}

        [Display(Name = "Contato")]
        public int mobileno {get; set;} // mobileno = mobile number

        public virtual ICollection<Books> Books {get; set;}

        public virtual ICollection<Member> Members {get; set;}


        // void Updateinfo() {

        // }

        // void Issuebooks() {
            
        // }

        // void Memberinfo() {

        // }

        // void searchbk() {

        // }

        // void returnbk() {

        // }
        
        // implementando metodos
        public Libraian() {
            Books = new HashSet<Books>();
            Members = new HashSet<Member>();
        }

        public Libraian(string name, string address, int mobileno) {
            Name = name;
            Address = address;
            this.mobileno = mobileno;
        }

        public override string ToString() {
            return "Nome da Livraria: " + Name + "\nEndereco: " + Address + "\nContato: " + mobileno;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            Libraian objAsLibraian = obj as Libraian;
            if (objAsLibraian == null) {
                return false;
            }
            else {
                return Equals(objAsLibraian);
            }
        }

        // update info = atualizar informacao
        public void Updateinfo(string name, string address, int mobileno) {
            Name = name;
            Address = address;
            this.mobileno = mobileno;
        }

        // issue books = emprestar livros
        public void Issuebooks(String bookname, Member member) {
            Books book = searchbk(bookname);

            if(book == null) {
                Console.WriteLine("Livro nao encontrado");
                return;
            }

            if (book.Bookquantity > 0) {
                book.Bookquantity--;
                member.Books.Add(book);
                return;
            }
            
            Console.WriteLine("Livro nao disponivel");
        }

        // member info = informacao do membro
        public void Memberinfo(Member member) {
            Console.WriteLine(member.ToString());
        }

        // search bk = procurar livro
        public Books searchbk(string bookname) {
            foreach (Books book in Books) {
                if (book.Bookname == bookname) {
                    return book;
                }
            }
            Console.WriteLine("Livro nao encontrado");
            return null;
        }

        // return bk = devolver livro
        public void returnbk(Books book, Member member) {
            if (member.Books.Contains(book)) {
                book.Bookquantity++;
                member.Books.Remove(book);
                return;
            }
            
            Console.WriteLine("Livro nao encontrado");
            
        }
    }
}