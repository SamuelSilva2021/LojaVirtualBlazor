using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_DataAccess
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set;}
        public string? Cor { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set;}
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public double ValorCompra { get; set; }
        public double PrecoVenda { get; set; }
        public string? Observacao { get; set; }

    }
}
