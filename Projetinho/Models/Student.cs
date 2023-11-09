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
        [Required(ErrorMessage = "Nome da Faculdade é obrigatório.")]
        [Display(Name = "Nome da Faculdade")]
        public string? Studentcoll {get; set;} // studentcoll = student college

        public Student() {}

        public Student(string name, string address, int contact, string studentcoll) : base(name, address, contact)
        {
            Studentcoll = studentcoll;
        }
    }
}