using System.ComponentModel.DataAnnotations;

namespace EmpresaDulces.DTOs
{
    public class TiposDeDulcesCreacionDTO
    {
        

        [Required(ErrorMessage = "El campo {0} es requerido impotantisimo ")]
        [StringLength(maximumLength: 15, ErrorMessage = "El {0} esta fuera del rango que es 15, porfavor corrijalo")]
        public string NombreDelDulce { get; set; }
    }
}
