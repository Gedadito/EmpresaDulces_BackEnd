using EmpresaDulces.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace EmpresaDulces.DTOs
{
    public class InfoDulceCreacionDTO
    {
        [Required]
        [PrimeraLetraMayuscula]
        public string MarcaDeDulce { get; set; }

        public List<int> MarcaId    { get; set; }
    }
}
