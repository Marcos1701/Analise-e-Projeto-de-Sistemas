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
        [Required(ErrorMessage = "Nome da Faculdade é obrigatório.")]
        [Display(Name = "Nome da Faculdade")]
        public string? Facultycoll {get; set;}

        public FacultyMember() {}

        public FacultyMember(string name, string address, int contact, string facultycoll) : base(name,  address, contact) {
            Facultycoll = facultycoll;
        }
    }
}