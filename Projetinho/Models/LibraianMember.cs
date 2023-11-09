using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projetinho.Models
{
    public class LibraianMember
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [ForeignKey("LibraianId")]
        public int LibraianId { get; set; }

        [Display(Name = "Código do Bibliotecário")]
        public Libraian? Libraian { get; set; }

        [ForeignKey("MemberId")]
        public int MemberId { get; set; }

        [Display(Name = "Código do Membro")]
        public Member? Member { get; set; }
    }
}