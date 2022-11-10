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

        public List<Sabor> Sabores { get; set; }

        public List<DulceInfo> DulceInfos { get; set; }

    }
}
