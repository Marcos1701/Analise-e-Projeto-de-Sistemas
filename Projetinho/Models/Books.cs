using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New_Project_Dotnet.Models
{
    public class Books
    {
        [Display(Name = "Nome do Autor")]
        String Authorname;

        [Display(Name = "Nome do Livro")]
        String Bookname;

        [Display(Name = "Quantidade de Livros")]
        int Bookquantity;

        void removefirmcatalog() {

        }
        void addtocatalog() {
            
        }
    }
}