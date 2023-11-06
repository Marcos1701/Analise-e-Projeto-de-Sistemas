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

        [Required]
        [Display(Name = "Nome da Faculdade")]
        public string? Studentcoll {get; set;} // studentcoll = student college

        public Student() {
            GeneralBooks = new List<GeneralBook>();
            Libraians = new List<Libraian>();
        }

        public Student(string name, string address, int contact, string studentcoll) : base(name, address, contact)
        {
            Name = name;
            Address = address;
            Contact = contact;
            Studentcoll = studentcoll;
        }
    }
}