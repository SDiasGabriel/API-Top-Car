using API_Top_Car.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Top_Car.Data.Map
{
    public class ApoliceMap : IEntityTypeConfiguration<ApoliceModel>
    {
        public void Configure(EntityTypeBuilder<ApoliceModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
