using System.ComponentModel.DataAnnotations;

namespace EmpresaDulces.DTOs
{
    public class TiposDeDulcesDTO
    {
        public int Id { get; set; }
        public string NombreDelDulce { get; set; }
        public List<InfoDulceDTO> infoDulceDTO { get; set; }    

        //public List<SaborDTO> Sabores  { get; set; }

    }
}
