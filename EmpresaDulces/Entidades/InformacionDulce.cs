namespace EmpresaDulces.Entidades
{
    public class InformacionDulce
    {
        public int Id { get; set; }

        public string NombreDelDulce { get; set; } 
        
        public string MarcaDeDulce   { get; set; }

        public int DulceId { get; set; }

        public Dulces Dulces { get; set; }
    }
}
