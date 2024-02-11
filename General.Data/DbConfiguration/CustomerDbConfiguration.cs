using General.Domain.ViewModels.KsStad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace General.Data.DbConfiguration
{
    public class CustomerDbConfiguration : IEntityTypeConfiguration<KsCustomerEntity>
    {
        public void Configure(EntityTypeBuilder<KsCustomerEntity> builder)
        {
            builder.ToTable("KsCustomers");

            builder.HasMany(z => z.Orders).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerFK).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(z => z.Address).WithOne(x => x.KsCustomer).HasForeignKey(x => x.KsCustomerFk).OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
