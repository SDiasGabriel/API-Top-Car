using API_Top_Car.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Top_Car.Data.Map
{
    public class CadastroMap : IEntityTypeConfiguration<CadastrosModel>
    {
        public void Configure(EntityTypeBuilder<CadastrosModel> builder)
        {
            builder.HasKey(x => x.IdCadastro);
            builder.Property(x => x.CPF).HasMaxLength(11);
            builder.Property(x => x.CNPJ).HasMaxLength(16);
        }
    }
}
