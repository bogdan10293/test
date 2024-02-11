﻿// <auto-generated />
using System;
using General.Data.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace General.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210729135314_cleared_service_db")]
    partial class cleared_service_db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("General.Domain.Joins.KsCustomerProjectJoin", b =>
                {
                    b.Property<int>("KsCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("KsProjectId")
                        .HasColumnType("int");

                    b.HasKey("KsCustomerId", "KsProjectId");

                    b.HasIndex("KsProjectId");

                    b.ToTable("Customer_Projects");
                });

            modelBuilder.Entity("General.Domain.Joins.KsEmployeeProjectJoin", b =>
                {
                    b.Property<int>("KsEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("KsProjectId")
                        .HasColumnType("int");

                    b.HasKey("KsEmployeeId", "KsProjectId");

                    b.HasIndex("KsProjectId");

                    b.ToTable("KsEmployee_Projects");
                });

            modelBuilder.Entity("General.Domain.Joins.KsSupervisorProjectJoin", b =>
                {
                    b.Property<int>("KsProjectId")
                        .HasColumnType("int");

                    b.Property<int>("KsSupervisorId")
                        .HasColumnType("int");

                    b.Property<string>("SupervisorRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KsProjectId", "KsSupervisorId");

                    b.HasIndex("KsSupervisorId");

                    b.ToTable("KsSupervisor_Projects");
                });

            modelBuilder.Entity("General.Domain.ViewModels.EmployeeServiceJoin", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Employee_services");
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsAddressViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBillingAddress")
                        .HasColumnType("bit");

                    b.Property<int>("KsCustomerFk")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KsCustomerFk");

                    b.ToTable("KsCustomerAddress");
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsCustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerMode")
                        .HasColumnType("int");

                    b.Property<string>("CustomerNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GlnNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoiceType")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VatNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("KsCustomers");
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsEmployeeViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("KsSupervisorFK")
                        .HasColumnType("int");

                    b.Property<int?>("KsSupervisorId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalIdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.Property<int>("TangellaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KsSupervisorId");

                    b.ToTable("KsEmployees");
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsOrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerFK")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerFK");

                    b.ToTable("KsCustomer_Orders");
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsOrderServiceAdditionalEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderServiceFK")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Rut")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("OrderServiceFK");

                    b.ToTable("KsCustomer_Order_Service_Additionals");
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsOrderServiceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("MainServiceType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderFK")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderFK");

                    b.ToTable("KsCustomer_Order_Services");
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsOrderServiceWindowTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfWindowSides")
                        .HasColumnType("int");

                    b.Property<int>("OrderServiceFK")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderServiceFK");

                    b.ToTable("KsCustomer_Order_Service_WindowTypes");
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsProjectViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkAddressZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KsProjects");
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsServiceAdditionalViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Rut")
                        .HasColumnType("bit");

                    b.Property<int>("ServiceFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceFk");

                    b.ToTable("KsAdditionalServices");
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsServiceViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainServiceType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<bool>("Rut")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("KsServices");
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsSupervisorRoleViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KsSupervisorRoles");
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsSupervisorViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("KsSupervisors");
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsWindowTypeViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfWindowSides")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ServiceFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceFk");

                    b.ToTable("KsWindowTypes");
                });

            modelBuilder.Entity("General.Domain.Joins.KsCustomerProjectJoin", b =>
                {
                    b.HasOne("General.Domain.ViewModels.KsStad.KsCustomerEntity", "KsCustomer")
                        .WithMany("KsCustomerProjectJoins")
                        .HasForeignKey("KsCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("General.Domain.ViewModels.KsStad.KsProjectViewModel", "KsProject")
                        .WithMany("KsCustomerProjectJoins")
                        .HasForeignKey("KsProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("General.Domain.Joins.KsEmployeeProjectJoin", b =>
                {
                    b.HasOne("General.Domain.ViewModels.KsStad.KsProjectViewModel", "KsProject")
                        .WithMany("KsEmployeeProjectJoins")
                        .HasForeignKey("KsEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("General.Domain.ViewModels.KsStad.KsEmployeeViewModel", "KsEmployee")
                        .WithMany("KsEmployeeProjectJoins")
                        .HasForeignKey("KsProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("General.Domain.Joins.KsSupervisorProjectJoin", b =>
                {
                    b.HasOne("General.Domain.ViewModels.KsStad.KsProjectViewModel", "KsProject")
                        .WithMany("KsSupervisorProjectJoins")
                        .HasForeignKey("KsProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("General.Domain.ViewModels.KsStad.KsSupervisorViewModel", "KsSupervisor")
                        .WithMany("KsSupervisorProjectJoins")
                        .HasForeignKey("KsSupervisorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("General.Domain.ViewModels.EmployeeServiceJoin", b =>
                {
                    b.HasOne("General.Domain.ViewModels.KsStad.KsEmployeeViewModel", "KsEmployee")
                        .WithMany("EmployeeServiceJoins")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("General.Domain.ViewModels.KsStad.KsServiceViewModel", "Service")
                        .WithMany("EmployeeServiceJoins")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsAddressViewModel", b =>
                {
                    b.HasOne("General.Domain.ViewModels.KsStad.KsCustomerEntity", "KsCustomer")
                        .WithMany("Address")
                        .HasForeignKey("KsCustomerFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsEmployeeViewModel", b =>
                {
                    b.HasOne("General.Domain.ViewModels.KsStad.KsSupervisorViewModel", "KsSupervisor")
                        .WithMany("KsEmployees")
                        .HasForeignKey("KsSupervisorId");
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsOrderEntity", b =>
                {
                    b.HasOne("General.Domain.ViewModels.KsStad.KsCustomerEntity", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsOrderServiceAdditionalEntity", b =>
                {
                    b.HasOne("General.Domain.ViewModels.KsStad.KsOrderServiceEntity", "Service")
                        .WithMany("AdditionalServices")
                        .HasForeignKey("OrderServiceFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsOrderServiceEntity", b =>
                {
                    b.HasOne("General.Domain.ViewModels.KsStad.KsOrderEntity", "Order")
                        .WithMany("OrderServices")
                        .HasForeignKey("OrderFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsOrderServiceWindowTypeEntity", b =>
                {
                    b.HasOne("General.Domain.ViewModels.KsStad.KsOrderServiceEntity", "Service")
                        .WithMany("WindowTypes")
                        .HasForeignKey("OrderServiceFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsServiceAdditionalViewModel", b =>
                {
                    b.HasOne("General.Domain.ViewModels.KsStad.KsServiceViewModel", "Service")
                        .WithMany("AdditionalServices")
                        .HasForeignKey("ServiceFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("General.Domain.ViewModels.KsStad.KsWindowTypeViewModel", b =>
                {
                    b.HasOne("General.Domain.ViewModels.KsStad.KsServiceViewModel", "Service")
                        .WithMany("WindowTypes")
                        .HasForeignKey("ServiceFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
