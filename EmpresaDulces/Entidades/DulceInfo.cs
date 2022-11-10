namespace EmpresaDulces.Entidades
{
    public class DulceInfo
    {
        public int DulceId { get; set; }
        public int InfoId { get; set; }
        public int Orden { get; set; }
        public Dulces Dulces { get; set; }
        public InformacionDulce InformacionDulce { get; set;}
    }
}
