using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Models
{
    public class ProdutoDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Por favor, digite um nome para o produto")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor, escolhar uma descrição para o produto")]
        public string Descricao { get; set; }
        public string Cor { get; set; }
        public string ImageUrl { get; set; }
        [Range(1,int.MaxValue, ErrorMessage ="Por favor, selecione uma categoria")]
        public int CategoriaId { get; set; }
        public CategoriaDTO Categoria { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        [Required(ErrorMessage = "Favor preencher o preço de compra")]
        public double ValorCompra { get; set; }
        [Required(ErrorMessage = "Favor preencher o preço de venda")]
        public double PrecoVenda { get; set; }
        public string? Observacao { get; set; }
    }
}
