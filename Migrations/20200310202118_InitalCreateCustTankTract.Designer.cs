﻿// <auto-generated />
using DeliverPlan.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeliverPlan.Migrations
{
    [DbContext(typeof(DeliverPlanContext))]
    [Migration("20200310202118_InitalCreateCustTankTract")]
    partial class InitalCreateCustTankTract
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeliverPlan.Models.Tank", b =>
                {
                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("CustomerID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Level")
                        .HasColumnType("float");

                    b.HasKey("Tag");

                    b.HasIndex("CustomerID");

                    b.ToTable("Tank");
                });

            modelBuilder.Entity("DeliverPlan.Models.Tractor", b =>
                {
                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.HasKey("Tag");

                    b.ToTable("Tractor");
                });

            modelBuilder.Entity("DeliverPlann.Models.Customer", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("DeliverPlan.Models.Tank", b =>
                {
                    b.HasOne("DeliverPlann.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}