using API_Top_Car.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Top_Car.Data.Map
{
    public class AutoMovelMap : IEntityTypeConfiguration<AutomoveisModel>
    {
        public void Configure(EntityTypeBuilder<AutomoveisModel> builder)
        {
            builder.HasKey(x => x.IdVeiculo);
            builder.Property(x => x.Vin).IsRequired().HasMaxLength(20);
            builder.Property(x => x.MarcaVeiculos).IsRequired().HasMaxLength(20);
            builder.Property(x => x.CorVeiculo).IsRequired().HasMaxLength(30);
            builder.Property(x => x.AnoFabricacao).IsRequired().HasMaxLength(10);
            builder.Property(x => x.ModeloVeiculo).IsRequired().HasMaxLength(15);
        }
    }
}
