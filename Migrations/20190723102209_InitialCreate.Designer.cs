﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt.DB;

namespace Projekt.Migrations
{
    [DbContext(typeof(TellContext))]
    [Migration("20190723102209_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projekt.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("Currency");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("FullPriceWithTax");

                    b.Property<int>("PhoneId");

                    b.Property<decimal>("Tax");

                    b.HasKey("Id");

                    b.HasIndex("PhoneId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Projekt.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("LocationId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Projekt.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Projekt.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Projekt.Models.Operator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DialingNumber");

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("Projekt.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("RegistrationDate");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("Projekt.Models.PhoneOperator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<int>("OperatorId");

                    b.Property<string>("Sim");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("OperatorId");

                    b.ToTable("PhoneOperators");
                });

            modelBuilder.Entity("Projekt.Models.Bill", b =>
                {
                    b.HasOne("Projekt.Models.Phone", "Phone")
                        .WithMany()
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Projekt.Models.Client", b =>
                {
                    b.HasOne("Projekt.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Projekt.Models.Location", b =>
                {
                    b.HasOne("Projekt.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Projekt.Models.Operator", b =>
                {
                    b.HasOne("Projekt.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Projekt.Models.Phone", b =>
                {
                    b.HasOne("Projekt.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Projekt.Models.PhoneOperator", b =>
                {
                    b.HasOne("Projekt.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Projekt.Models.Operator", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
