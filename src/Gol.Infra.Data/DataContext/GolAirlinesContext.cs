using Gol.Domain.Entities;
using Gol.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Gol.Infra.Data.DataContext
{
    public class GolAirlinesContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\OneDrive\Documentos\golairlines_db.mdf;Integrated Security=True;Connect Timeout=30");
        }

        public DbSet<Airplane> Airplanes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AirplaneMap());
        }
    }
}
