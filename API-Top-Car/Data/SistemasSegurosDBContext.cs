using API_Top_Car.Data.Map;
using API_Top_Car.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Top_Car.Data
{
    public class SistemasSegurosDBContext : DbContext
    {
        public  SistemasSegurosDBContext(DbContextOptions<SistemasSegurosDBContext> options) : base(options)
        {

        }
        public DbSet<ApoliceModel> Apolices { get; set; }
        public DbSet<AutomoveisModel> Automoveis { get; set; }
        public DbSet<CadastrosModel> Cadastros { get; set; }
        public DbSet<ClientesModel> Clientes { get; set; }
        public DbSet<SegurosModel> Seguros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApoliceMap());
            modelBuilder.ApplyConfiguration(new AutoMovelMap());
            modelBuilder.ApplyConfiguration(new CadastroMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new SeguroMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
