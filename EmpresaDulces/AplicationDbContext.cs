using EmpresaDulces.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EmpresaDulces
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Dulces> TipoDulce { get; set; }
    }
}
