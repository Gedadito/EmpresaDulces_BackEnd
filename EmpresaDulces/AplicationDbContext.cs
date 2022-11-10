using EmpresaDulces.Entidades;
using Microsoft.EntityFrameworkCore;

namespace EmpresaDulces
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DulceInfo>()
                .HasKey(a1 => new { a1.DulceId, a1.InfoId }); 
        }

        public DbSet<Dulces> Dulces { get; set; }

        public DbSet<InformacionDulce> InformacionDulces { get; set; }  

        public DbSet<Sabor> Sabores { get; set;}

        public DbSet<DulceInfo> DulceInfos { get; set; }
    }
}
