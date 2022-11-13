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
        public CategoriaDTO Create(CategoriaDTO objDTO);
        public CategoriaDTO Update(CategoriaDTO objDTO);
        public int Delete(int id);
        public CategoriaDTO Get(int id);
        public IEnumerable<CategoriaDTO> GetAll();
    }
}
