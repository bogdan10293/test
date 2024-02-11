using General.Domain.Joins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace General.Data.DbConfiguration
{
    public class EmployeeProjectDbConfiguration : IEntityTypeConfiguration<KsEmployeeProjectJoin>
    {
        public void Configure(EntityTypeBuilder<KsEmployeeProjectJoin> builder)
        {
            builder.ToTable("KsEmployee_Projects");
            builder.HasKey(x => new { x.KsEmployeeId, x.KsProjectId });
            builder.HasOne(z => z.KsEmployee).WithMany(x => x.KsEmployeeProjectJoins).HasForeignKey(c => c.KsProjectId);
            builder.HasOne(c => c.KsProject).WithMany(z => z.KsEmployeeProjectJoins).HasForeignKey(c => c.KsEmployeeId);
        }
    }
}
