using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Modelo.Domain.Entities;
using Modelo.Infra.Data.Mapping;
using System.Configuration;

namespace Modelo.Infra.Data.Context
{
    public class SQLServerContext : DbContext
    {
        public IConfiguration Configuration { get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options)
        { }

        public DbSet<Patrimonio> Patrimonios { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patrimonio>(new PatrimonioMapping().Configure);
            modelBuilder.Entity<Marca>(new MarcaMapping().Configure);
        }
    }
}
