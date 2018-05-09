using MarketTest.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MarketTest.DAL.Configurations
{
    public class ProductConfigurations: IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(x => x.Code);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Category).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Description);
        }
    }
}
