using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace New_Project_Dotnet.Models
{
    public class Member
    {

        [Display(Name = "Código")]
        public int Id {get; set;}

        [Display(Name = "Nome")]
        public String name {get; set;}

        [Display(Name = "Endereco")]
        public String address {get; set;}

        [Display(Name = "Contato")]
        public int contact {get; set;}

        public virtual Libraian libraian {get; set;}
        public virtual ICollection<Books> Books {get; set;}

        // request for book = solicitar livro
        void requestforbk(String bookname){
            Books book = libraian.searchbk(bookname);
            libraian.Issuebooks(book, this);
        }

        void returnbk(String bookname){
            Books book = libraian.searchbk(bookname);
            libraian.returnbk(book, this);
        }
    }
}