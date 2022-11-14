using Microsoft.AspNetCore.Components.Forms;

namespace LojaVirtual_Server.Service.IService
{
    public interface IFileUpLoad
    {
        Task<string> UploadFiles(IBrowserFile arquivos);
        bool DeleteFile(string arquivoPath);
    }
}
