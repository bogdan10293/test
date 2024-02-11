using General.Domain.Joins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace General.Data.DbConfiguration
{
    public class CustomerProjectDbConfiguration : IEntityTypeConfiguration<KsCustomerProjectJoin>
    {
        public void Configure(EntityTypeBuilder<KsCustomerProjectJoin> builder)
        {
            builder.ToTable("Customer_Projects");

            builder.HasKey(e => new { e.KsCustomerId, e.KsProjectId });
            builder.HasOne(z => z.KsCustomer).WithMany(d => d.KsCustomerProjectJoins).HasForeignKey(z => z.KsCustomerId);
            builder.HasOne(c => c.KsProject).WithMany(d => d.KsCustomerProjectJoins).HasForeignKey(x => x.KsProjectId);
        }
    }
}
