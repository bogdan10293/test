using General.Data.DbConfiguration;
using General.Domain.Joins;
//using General.Domain.Joins;
using General.Domain.ViewModels;
//using General.Domain.ViewModels.JIffyTidyViewModels;
using General.Domain.ViewModels.KsStad;
using Microsoft.EntityFrameworkCore;

namespace General.Data.Core
{
    public class DataContext:DbContext
    {
        public DataContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                connectionString: "Server=localhost\\SQLEXPRESS;Database=Ksstad;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeServiceDbConfiguration());
            modelBuilder.ApplyConfiguration(new KsServiceDbConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectDbConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerDbConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerProjectDbConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDbConfiguration());
            modelBuilder.ApplyConfiguration(new OrderServiceDbCongfiguration());
            modelBuilder.ApplyConfiguration(new SupervisorProjectDbConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        // Customer DbSets
        public DbSet<KsCustomerEntity> KsCustomers { get; set; }
        public DbSet<KsAddressViewModel> KsCustomerAddress { get; set; }
        public DbSet<KsCustomerProjectJoin> KsCustomerProjectJoins { get; set; }

        // Order DbSets
        public DbSet<KsOrderEntity> KsCustomer_Orders { get; set; }
        public DbSet<KsOrderServiceEntity> KsCustomer_Order_Services { get; set; }
        public DbSet<KsOrderServiceAdditionalEntity> KsCustomer_Order_Service_Additionals { get; set; }
        public DbSet<KsOrderServiceWindowTypeEntity> KsCustomer_Order_Service_WindowTypes { get; set; }

        // Service DbSet
        public DbSet<KsServiceViewModel> KsServices { get; set; }
        public DbSet<KsServiceAdditionalViewModel> KsAdditionalServices { get; set; }
        public DbSet<KsWindowTypeViewModel> KsWindowTypes { get; set; }

        // Project DbSets
        public DbSet<KsProjectViewModel> KsProjects { get; set; }
        public DbSet<KsSupervisorProjectJoin> KsSupervisorProjectJoins { get; set; }
        public DbSet<KsSupervisorRoleViewModel> KsSupervisorRoles { get; set; }

        // Employee DbSets
        public DbSet<KsEmployeeProjectJoin> KsEmployeeProjectJoins { get; set; }
        public DbSet<EmployeeServiceJoin> EmployeeServiceJoins { get; set; }
        public DbSet<KsEmployeeViewModel> KsEmployees { get; set; }
        public DbSet<KsSupervisorViewModel> KsSupervisors { get; set; }
        //public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
