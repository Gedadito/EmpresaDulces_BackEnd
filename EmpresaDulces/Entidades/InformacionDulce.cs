using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmpresaDulces.Validaciones;

namespace EmpresaDulces.Entidades
{
    public class InformacionDulce
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio, necesario, importante, porfavor pongalo")]
        [StringLength(maximumLength: 15, ErrorMessage = "El campo {0} solo puede tener 15 caracteres")]
        [PrimeraLetraMayuscula]
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

        [NotMapped]
        public int Menor { get; set; }

        [NotMapped]
        public int Mayor { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(MarcaDeDulce))
            {
                var primeraLetra = MarcaDeDulce[0].ToString();

                if(primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new ValidationResult("la primera letra debe ser mayuscula",
                           new String[] { nameof(MarcaDeDulce) });
                }
            }

            if (Menor > Mayor)
            {
                yield return new ValidationResult("Este valor no puede ser mayor a Mayor",
                    new String[] { nameof(Menor) });
            }
        }
    }
}
