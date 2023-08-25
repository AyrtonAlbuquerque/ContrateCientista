﻿// <auto-generated />
using System;
using Api.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Domain.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Api.Domain.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Extra")
                        .HasColumnType("text");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Api.Domain.Model.Equipment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Area")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("LaboratoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LaboratoryId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("Api.Domain.Model.Laboratory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("Certificates")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("FoundationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ResponsibleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ResponsibleId");

                    b.ToTable("Laboratory");
                });

            modelBuilder.Entity("Api.Domain.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Department")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Api.Domain.Model.SocialMedia", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int?>("LaboratoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LaboratoryId");

                    b.ToTable("SocialMedia");
                });

            modelBuilder.Entity("Api.Domain.Model.Software", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Area")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("LaboratoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LaboratoryId");

                    b.ToTable("Software");
                });

            modelBuilder.Entity("Api.Domain.Model.Equipment", b =>
                {
                    b.HasOne("Api.Domain.Model.Laboratory", "Laboratory")
                        .WithMany("Equipments")
                        .HasForeignKey("LaboratoryId");

                    b.Navigation("Laboratory");
                });

            modelBuilder.Entity("Api.Domain.Model.Laboratory", b =>
                {
                    b.HasOne("Api.Domain.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Api.Domain.Model.Person", "Responsible")
                        .WithMany()
                        .HasForeignKey("ResponsibleId");

                    b.Navigation("Address");

                    b.Navigation("Responsible");
                });

            modelBuilder.Entity("Api.Domain.Model.SocialMedia", b =>
                {
                    b.HasOne("Api.Domain.Model.Laboratory", "Laboratory")
                        .WithMany()
                        .HasForeignKey("LaboratoryId");

                    b.Navigation("Laboratory");
                });

            modelBuilder.Entity("Api.Domain.Model.Software", b =>
                {
                    b.HasOne("Api.Domain.Model.Laboratory", "Laboratory")
                        .WithMany("Softwares")
                        .HasForeignKey("LaboratoryId");

                    b.Navigation("Laboratory");
                });

            modelBuilder.Entity("Api.Domain.Model.Laboratory", b =>
                {
                    b.Navigation("Equipments");

                    b.Navigation("Softwares");
                });
#pragma warning restore 612, 618
        }
    }
}
