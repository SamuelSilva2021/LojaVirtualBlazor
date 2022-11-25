using System.ComponentModel.DataAnnotations;

namespace LojaVirtual_Client.ViewModels
{
    public class DetalhesVM
    {
        public DetalhesVM()
        {
            Preco = new();
            Count = 1;
        }
        [Range(1, int.MaxValue, ErrorMessage ="Por favor entre com um valor maior que 0")]
        public int Count { get; set; }
        [Required]
        public int Preco { get; set; }
    }
}
