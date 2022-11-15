using API_Top_Car.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Top_Car.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClientesModel>
    {
        public void Configure(EntityTypeBuilder<ClientesModel> builder)
        {
            builder.HasKey(x => x.IdClientes);
            builder.Property(x => x.statusCliente).IsRequired();
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Rua).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(X => X.Idade).IsRequired().HasMaxLength(3);
            builder.Property(x => x.NumeroCasa).IsRequired().HasMaxLength(6);
            builder.Property(x => x.CPF).IsRequired().HasMaxLength(11);
        }
    }
}
