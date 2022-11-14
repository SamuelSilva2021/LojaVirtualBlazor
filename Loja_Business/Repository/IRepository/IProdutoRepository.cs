using Loja_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Business.Repository.IRepository
{
    public interface IProdutoRepository
    {
        public Task<ProdutoDTO> Create(ProdutoDTO objDTO);
        public Task<ProdutoDTO> Update(ProdutoDTO objDTO);
        public Task<int> Delete(int id);
        public Task<ProdutoDTO> Get(int id);
        public Task<IEnumerable<ProdutoDTO>> GetAll();
    }
}
