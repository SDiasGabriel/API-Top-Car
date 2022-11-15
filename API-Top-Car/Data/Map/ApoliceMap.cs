using API_Top_Car.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Top_Car.Data.Map
{
    public class ApoliceMap : IEntityTypeConfiguration<ApoliceModel>
    {
        public void Configure(EntityTypeBuilder<ApoliceModel> builder)
        {
            builder.HasKey(x => x.IdApolice);
            builder.Property(x => x.CPFCliente).IsRequired().HasMaxLength(12);
            builder.Property(x => x.Status).IsRequired();   
        }
    }
}
