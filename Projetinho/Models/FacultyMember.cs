using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projetinho.Models
{
    public class FacultyMember : Member
    {

        [Display(Name = "Nome da Faculdade")]
        public string? Facultycoll {get; set;}

        public FacultyMember() {
            GeneralBooks = new List<GeneralBook>();
            Libraians = new List<Libraian>();
        }

        public FacultyMember(string name, string address, int contact, string facultycoll) : base( name,  address, contact) {
            Name = name;
            Address = address;
            Contact = contact;
            Facultycoll = facultycoll;
        }

        void checkoutbk(){

        }
    }
}