using ConstanceRepo.Domain;
using Microsoft.EntityFrameworkCore;

namespace ConstanceRepo.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Estado> Estado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ConstanceDB;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }        

    }
}
