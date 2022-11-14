using AutoMapper;
using Loja_Business.Repository.IRepository;
using Loja_DataAccess;
using Loja_DataAccess.Data;
using Loja_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Business.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProdutoRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProdutoDTO> Create(ProdutoDTO objDTO)
        {
            var obj = _mapper.Map<ProdutoDTO, Produto>(objDTO);
            obj.DataCriacao = DateTime.Now;
            var addedObj = _db.Produtos.Add(obj);            
            await _db.SaveChangesAsync();

            return _mapper.Map<Produto, ProdutoDTO>(addedObj.Entity);
        }
        public async Task<int> Delete(int id)
        {
            var obj = await _db.Produtos.FirstOrDefaultAsync(x => x.Id== id);
            if (obj != null) 
            {
                _db.Produtos.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<ProdutoDTO> Get(int id)
        {
            var obj = await _db.Produtos.Include(u=>u.Categoria).FirstOrDefaultAsync(x => x.Id == id);
            if(obj != null)
            {
                return _mapper.Map<Produto,ProdutoDTO>(obj);
            }
            return new ProdutoDTO();
        }
        public async Task<IEnumerable<ProdutoDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoDTO>>(_db.Produtos.Include(u => u.Categoria));
        }
        public async Task<ProdutoDTO> Update(ProdutoDTO objDTO)
        {
            var objFromDb = await _db.Produtos.FirstOrDefaultAsync(x => x.Id ==objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Nome= objDTO.Nome;
                objFromDb.Descricao= objDTO.Descricao;
                objFromDb.ImageUrl = objDTO.ImageUrl;
                objFromDb.CategoriaId= objDTO.CategoriaId;
                objFromDb.Color= objDTO.Color;
                objFromDb.FavoritosShop= objDTO.FavoritosShop;
                objFromDb.FavoritosCliente= objDTO.FavoritosCliente;

                _db.Produtos.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Produto, ProdutoDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}
