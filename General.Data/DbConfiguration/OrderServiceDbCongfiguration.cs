using General.Domain.ViewModels.KsStad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace General.Data.DbConfiguration
{
    public class OrderServiceDbCongfiguration : IEntityTypeConfiguration<KsOrderServiceEntity>
    {
        public void Configure(EntityTypeBuilder<KsOrderServiceEntity> builder)
        {
            builder.ToTable("KsCustomer_Order_Services");
            builder.HasMany(z => z.AdditionalServices).WithOne(x => x.Service).HasForeignKey(x => x.OrderServiceFK).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(z => z.WindowTypes).WithOne(x => x.Service).HasForeignKey(x => x.OrderServiceFK).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
