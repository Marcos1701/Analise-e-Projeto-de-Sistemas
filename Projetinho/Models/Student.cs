using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projetinho.Models
{
    public class Student : Member
    {
        [Display(Name = "Nome da Faculdade")]
        public String studentcoll {get; set;} // studentcoll = student college

        void checkoutbk(){

        }

        void returnbk(){

        }
    }
}