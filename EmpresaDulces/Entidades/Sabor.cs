namespace EmpresaDulces.Entidades
{
    public class Sabor
    {
        public int Id { get; set; } 
        public string Taste { get; set; }
        public int TasteId { get; set; }
        public Dulces Dulces { get; set; }  

    }
}
