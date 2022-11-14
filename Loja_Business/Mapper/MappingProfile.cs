using AutoMapper;
using Loja_DataAccess;
using Loja_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //Reverse map já faz com que seja feito o mapeamento reverso
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            //CreateMap<CategoriaDTO, Categoria>();
        }
    }
}
