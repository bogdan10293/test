using General.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace General.Data.DbConfiguration
{
    public class EmployeeServiceDbConfiguration : IEntityTypeConfiguration<EmployeeServiceJoin>
    {
        public void Configure(EntityTypeBuilder<EmployeeServiceJoin> builder)
        {
            builder.ToTable("Employee_services");

            //Service Join
            builder.HasKey(ed => new { ed.EmployeeId, ed.ServiceId });
            builder.HasOne(ed => ed.KsEmployee).WithMany(d => d.EmployeeServiceJoins).HasForeignKey(ed => ed.EmployeeId);
            builder.HasOne(ed => ed.Service).WithMany(e => e.EmployeeServiceJoins).HasForeignKey(ed => ed.ServiceId);
        }
    }
}

