using Loja_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Business.Repository.IRepository
{
    public interface ICategoriaRepository
    {
        public Task<CategoriaDTO> Create(CategoriaDTO objDTO);
        public Task<CategoriaDTO> Update(CategoriaDTO objDTO);
        public Task<int> Delete(int id);
        public Task<CategoriaDTO> Get(int id);
        public Task<IEnumerable<CategoriaDTO>> GetAll();
    }
}
