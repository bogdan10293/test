using General.Domain.ViewModels.KsStad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace General.Data.DbConfiguration
{
    public class KsServiceDbConfiguration : IEntityTypeConfiguration<KsServiceViewModel>
    {
        public void Configure(EntityTypeBuilder<KsServiceViewModel> builder)
        {
            builder.ToTable("KsServices");

            builder.HasMany(z => z.AdditionalServices).WithOne(x => x.Service).HasForeignKey(x => x.ServiceFk).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(o => o.WindowTypes).WithOne(c => c.Service).HasForeignKey(x => x.ServiceFk).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
