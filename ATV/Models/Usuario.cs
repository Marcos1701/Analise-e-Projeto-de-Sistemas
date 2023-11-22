using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATV.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }

        [Display(Name = "Senha")]
        public string Password { get; set; }
        
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public int Email { get; set; }

        public virtual Carrinho Carrinho {get; set;}
    }
}