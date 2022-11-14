using LojaVirtual_Server.Service.IService;
using Microsoft.AspNetCore.Components.Forms;

namespace LojaVirtual_Server.Service
{
    public class FileUpLoad : IFileUpLoad
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileUpLoad(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public bool DeleteFile(string arquivoPath)
        {
            if(File.Exists(_webHostEnvironment.WebRootPath+arquivoPath))
            {
                File.Delete(_webHostEnvironment.WebRootPath+ arquivoPath);
                return true;
            }
            return false;
        }
        //Método para fazer upload dos arquivos de imagem
        public async Task<string> UploadFiles(IBrowserFile arquivo)
        {
            FileInfo arquivoInfo = new(arquivo.Name);
            var arquivoNome = Guid.NewGuid().ToString()+arquivoInfo.Extension;
            var pastaDosArquivos = $"{_webHostEnvironment.WebRootPath}\\images\\produto";
            if(!Directory.Exists(pastaDosArquivos))
            {
                Directory.CreateDirectory(pastaDosArquivos);
            }
            var arquivoPath = Path.Combine(pastaDosArquivos, arquivoNome);

            await using FileStream fs = new FileStream(arquivoPath, FileMode.Create);
            await arquivo.OpenReadStream().CopyToAsync(fs);

            var fullPath = $"/images/produto/{arquivoNome}";
            return fullPath;
        }
    }
}
