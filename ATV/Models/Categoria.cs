using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATV.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria", AllowEmptyStrings = false)]        
        public string Nome { get; set; }

        [Display(Name ="Produdos da Categoria")]
        public virtual ICollection<Produto>? Produtos {get; set;}

    }
}