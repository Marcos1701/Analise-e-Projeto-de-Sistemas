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
            Books = new List<Books>();
        }

        public Student(string name, string address, int contact, Libraian libraian, string studentcoll) : base(name, address, contact, libraian)
        {
            Name = name;
            Address = address;
            Contact = contact;
            Libraian = libraian;
            Studentcoll = studentcoll;
        }
    }
}