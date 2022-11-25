using Loja_Models;
using LojaVirtual_Client.Service.IService;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace LojaVirtual_Client.Service
{

    public class ProdutoService : IProdutoService
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;
        private string BaseServerUrl;

        public ProdutoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            //Instancia do endereço do servidor que está em wwwroot/appsettings.json
            BaseServerUrl= _configuration.GetSection("BaseServerUrl").Value;
            
        }
        public async Task<ProdutoDTO> Get(int produtoId)
        {
            var response = await _httpClient.GetAsync($"/api/produto/{produtoId}");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var produto = JsonConvert.DeserializeObject<ProdutoDTO>(content);
                produto.ImageUrl = BaseServerUrl + produto.ImageUrl;
                return produto;
            }
            else
            {
                var erroModel = JsonConvert.DeserializeObject<ErrorModelDTO>(content);
                throw new Exception(erroModel.MensagemErro);
            }
            
        }

        public async Task<IEnumerable<ProdutoDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/produto");
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var produtos = JsonConvert.DeserializeObject<IEnumerable<ProdutoDTO>>(content);
                foreach (var produto in produtos)
                {
                    produto.ImageUrl = BaseServerUrl + produto.ImageUrl;
                }
                return produtos;
            }
            return new List<ProdutoDTO>();
        }
    }
}
