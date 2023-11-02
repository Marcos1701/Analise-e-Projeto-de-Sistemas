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
        public String facultycoll {get; set;}

        void checkoutbk(){

        }
    }
}