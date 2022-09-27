using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpresaDulces.Entidades
{
    public class InformacionDulce
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio, necesario, importante, porfavor pongalo")]
        public string MarcaDeDulce   { get; set; }

        [Required(ErrorMessage = "Ponga el {0} porfavor :)")]
        public int DulceId { get; set; }

        [NotMapped]
        [StringLength(maximumLength:20, ErrorMessage = "El campo {0} esta fuera del rango")]
        public string Sabor { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "{0} obligatorio please")]
        public int SaborId { get; set; }

        public Dulces Dulces { get; set; }
    }
}
