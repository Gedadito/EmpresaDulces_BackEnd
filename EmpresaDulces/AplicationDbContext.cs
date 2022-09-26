using EmpresaDulces.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EmpresaDulces
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Dulces> Dulces { get; set; }

        public DbSet<InformacionDulce> InformacionDulces { get; set; }  
    }
}
