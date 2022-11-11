using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual_Models.LojaVirtualModels
{
    public class Demo_Produto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<Demo_ProdutoProp> ProdutoProperties { get; set; }
    }
}
