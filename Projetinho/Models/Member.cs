using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace New_Project_Dotnet.Models
{
    public class Member
    {

        [Display(Name = "Nome")]
        String Mname;

        [Display(Name = "Endereco")]
        String Maddress;

        [Display(Name = "Numero")]
        int Mno;

        void mrequestforbk(){

        }

        void mreturnbk(){

        }
    }
}