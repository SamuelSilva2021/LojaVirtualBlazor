using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Models
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor preencha o nome da categoria")]
        public string Nome { get; set; }
    }
}
