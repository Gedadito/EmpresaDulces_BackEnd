using System.ComponentModel.DataAnnotations;

namespace EmpresaDulces.DTOs
{
    public class ModificarAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
