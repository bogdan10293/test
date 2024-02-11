using General.Domain.Joins;
using General.Domain.ViewModels.KsStad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace General.Data.DbConfiguration
{
    public class SupervisorProjectDbConfiguration : IEntityTypeConfiguration<KsSupervisorProjectJoin>
    {
        public void Configure(EntityTypeBuilder<KsSupervisorProjectJoin> builder)
        {
            builder.ToTable("KsSupervisor_Projects");

            builder.HasKey(z => new { z.KsProjectId, z.KsSupervisorId });
            builder.HasOne(x => x.KsProject).WithMany(c => c.KsSupervisorProjectJoins).HasForeignKey(z => z.KsProjectId);
            builder.HasOne(c => c.KsSupervisor).WithMany(z => z.KsSupervisorProjectJoins).HasForeignKey(z => z.KsSupervisorId);
        }
    }
}
