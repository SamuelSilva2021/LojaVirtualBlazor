using Loja_Business.Repository.IRepository;
using Loja_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loja_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _produtoRepository.GetAll());
        }

        [HttpGet("{produtoId}")]
        public async Task<IActionResult>Get(int? produtoId)
        {
            if(produtoId==null || produtoId == 0) 
            {
                return BadRequest(new ErrorModelDTO()
                {
                    MensagemErro="Id inválido",
                    StatusCode=StatusCodes.Status400BadRequest
                });
            }
            var produto = await _produtoRepository.Get(produtoId.Value);

            if(produto == null)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    MensagemErro = "Id inválido",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }
            return Ok(produto);
        }
    }
}
