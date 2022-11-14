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
        public bool FavoritosShop { get; set;}
        public bool FavoritosCliente { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }
        public int CategoriaId { get; set; }
        [ForeignKey("CategoryId")]
        public Categoria Categoria { get; set;}
        public DateTime DataCriacao { get; set; }
    }
}
