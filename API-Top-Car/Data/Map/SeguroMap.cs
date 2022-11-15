using API_Top_Car.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Top_Car.Data.Map
{
    public class SeguroMap : IEntityTypeConfiguration<SegurosModel>
    {
        public void Configure(EntityTypeBuilder<SegurosModel> builder)
        {
            builder.HasKey(x => x.CodigoID);
            builder.Property(x => x.TipoSeguro).IsRequired().HasMaxLength(50);
            builder.Property(x => x.statusSeguro).IsRequired();
            builder.Property(x => x.Vin).IsRequired().HasMaxLength(50);
        }
    }
}
