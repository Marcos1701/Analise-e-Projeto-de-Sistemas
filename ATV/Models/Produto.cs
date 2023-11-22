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
        
        [Required(ErrorMessage = "Informe a descrição do produto", AllowEmptyStrings = false)]
        public string Descricao { get; set; }

        [Display(Name = "Endereço da Imagem")]
        [Required(ErrorMessage = "Informe a senha do usuário", AllowEmptyStrings = false)]
        public string PathImagem { get; set; }
        
        public int Quantidade { get; set; }

        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Selecione a Categoria do Produto")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "O Produto deve possuir uma Categoria!")]
        [Display(Name = "Categoria do Produto")]
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Carrinho>? Carrinho { get; set; }
    }
}