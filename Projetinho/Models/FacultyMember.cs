using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using New_Project_Dotnet.Models;

namespace Projetinho.Models
{
    public class FacultyMember : Member
    {

        [Display(Name = "Nome da Faculdade")]
        public string Facultycoll {get; set;}

        public FacultyMember(string name, string address, int contact, Libraian libraian, string facultycoll) : base( name,  address, contact , libraian) {
            Name = name;
            Address = address;
            Contact = contact;
            Books = new List<Books>();
            Libraian = libraian;
            Facultycoll = facultycoll;
        }

        void checkoutbk(){

        }
    }
}