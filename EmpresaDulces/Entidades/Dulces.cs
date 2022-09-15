namespace EmpresaDulces.Entidades
{
    public class Dulces
    {
        public int Id { get; set; }

        public string NombreDelDulce { get; set; }

        public List<InformacionDulce> InfoDulce { get; set; }
    }
}
