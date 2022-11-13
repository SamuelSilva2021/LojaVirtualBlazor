using AutoMapper;
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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoriaRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        //Cria nova categoria
        public CategoriaDTO Create(CategoriaDTO objDTO)
        {
            //Mapeamento antigo do objDTO para categoria, abaixo implementei um método mais moderno utilizando o AutoMapper

            //Categoria categoria = new Categoria()
            //{
            //    Id = objDTO.Id,
            //    Nome = objDTO.Nome,
            //    DataCriacao = DateTime.Now,
            //};

            //Método mais moderno para mapear
            var obj = _mapper.Map<CategoriaDTO, Categoria>(objDTO);

            var addedObj = _db.Categorias.Add(obj);
            obj.DataCriacao = DateTime.Now;
            _db.SaveChanges();

            return _mapper.Map<Categoria, CategoriaDTO>(addedObj.Entity);
        }

        public int Delete(int id)
        {
            var obj = _db.Categorias.FirstOrDefault(x => x.Id== id);
            if (obj != null) 
            {
                _db.Categorias.Remove(obj);
                return _db.SaveChanges();
            }
            return 0;
        }

        public CategoriaDTO Get(int id)
        {
            var obj = _db.Categorias.FirstOrDefault(x => x.Id == id);
            if(obj != null)
            {
                return _mapper.Map<Categoria,CategoriaDTO>(obj);
            }
            return new CategoriaDTO();
        }

        public IEnumerable<CategoriaDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaDTO>>(_db.Categorias);
        }

        public CategoriaDTO Update(CategoriaDTO objDTO)
        {
            var objFromDb = _db.Categorias.FirstOrDefault(x => x.Id ==objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Nome= objDTO.Nome;
                _db.Update(objFromDb);
                _db.SaveChanges();
                return _mapper.Map<Categoria, CategoriaDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}
