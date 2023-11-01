using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace New_Project_Dotnet.Models
{
    public class Books
    {
        [Display(Name = "Nome do Autor")]
        String  Authorname;

        [Display(Name = "Quantidade de Livros")]
        int  Noofbooks;

        void removefirmcatalog() {

        }
        void addtocatalog() {
            
        }
    }
}