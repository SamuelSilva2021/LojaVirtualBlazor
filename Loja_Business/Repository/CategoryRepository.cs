using Loja_Business.Repository.IRepository;
using Loja_DataAccess;
using Loja_DataAccess.Data;
using Loja_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Business.Repository
{
    internal class CategoryRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        //Cria nova categoria
        public CategoriaDTO Create(CategoriaDTO objDTO)
        {
            Categoria categoria = new Categoria()
            {
                Id = objDTO.Id,
                Nome = objDTO.Nome,
                DataCriacao = DateTime.Now,
            };

            _db.Categorias.Add(categoria);
            _db.SaveChanges();

            return new CategoriaDTO()
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
            };
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CategoriaDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoriaDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CategoriaDTO Update(CategoriaDTO objDTO)
        {
            throw new NotImplementedException();
        }
    }
}
