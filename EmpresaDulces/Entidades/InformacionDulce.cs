using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmpresaDulces.Validaciones;

namespace EmpresaDulces.Entidades
{
    public class InformacionDulce
    {
        public int Id { get; set; }

        [Required]
        [PrimeraLetraMayuscula]
        public string MarcaDeDulce   { get; set; }

        public List<DulceInfo> DulceInfos { get; set; }

        //public List<Sabor> Sabores { get; set; }

       
    }
}
