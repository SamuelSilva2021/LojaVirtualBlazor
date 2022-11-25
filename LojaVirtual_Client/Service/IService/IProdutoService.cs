using Loja_Models;

namespace LojaVirtual_Client.Service.IService
{
    public interface IProdutoService
    {
        public Task<IEnumerable<ProdutoDTO>> GetAll();
        public Task<ProdutoDTO> Get(int produtoId);
    }
}
