using General.Domain.ViewModels.KsStad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace General.Data.DbConfiguration
{
    public class OrderDbConfiguration : IEntityTypeConfiguration<KsOrderEntity>
    {
        public void Configure(EntityTypeBuilder<KsOrderEntity> builder)
        {
            builder.ToTable("KsCustomer_Orders");

            builder.HasMany(z => z.OrderServices).WithOne(x => x.Order).HasForeignKey(x => x.OrderFK).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
