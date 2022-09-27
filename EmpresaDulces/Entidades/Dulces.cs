using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpresaDulces.Entidades
{
    public class Dulces
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido impotantisimo ")]
        [StringLength(maximumLength:15, ErrorMessage = "El {0} esta fuera del rango que es 15, porfavor corrijalo")]
        public string NombreDelDulce { get; set; }

        [NotMapped]
        [Range(5,1000, ErrorMessage = "El requerimiento {0} no esta dentro del rango pedido, intente again")]
        public int GramosDulce { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "{0} obligatorio please")]
        public string Caducidad { get; set; }
        public List<InformacionDulce> InfoDulce { get; set; }
    }
}
