using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATV.Models
{
    public class Produto
    {
        public int Id { get; set; }
        
        public string Descricao { get; set; }

        public string PathImagem { get; set; }
        
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "O Produto deve possuir uma Categoria!")]
        [Display(Name = "Categoria do Produto")]
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Carrinho>? Carrinho { get; set; }
    }
}