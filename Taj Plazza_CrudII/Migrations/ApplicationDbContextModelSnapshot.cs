﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Taj_Plazza.Core.DataAcess;

#nullable disable

namespace TajPlazzaCrudII.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Taj_Plazza_CrudII.Models.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Taj_Plazza_CrudII.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Domicile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Num_Telephone")
                        .HasColumnType("int");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Taj_Plazza_CrudII.Models.OptionAjouter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prix")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Taj_Plazza_CrudII.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date_D_Evenement")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_De_Reservation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom_D_Evenement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nombre_De_Personne")
                        .HasColumnType("int");

                    b.Property<int>("clientId")
                        .HasColumnType("int");

                    b.Property<int>("statut")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("clientId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Taj_Plazza_CrudII.Models.Reservation_OptionAjouter", b =>
                {
                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("OptionAjouterId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("ReservationId", "OptionAjouterId");

                    b.HasIndex("OptionAjouterId");

                    b.ToTable("reservation_OptionAjouters");
                });

            modelBuilder.Entity("Taj_Plazza_CrudII.Models.OptionAjouter", b =>
                {
                    b.HasOne("Taj_Plazza_CrudII.Models.Categorie", "categorie")
                        .WithMany("OptionAjouters")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categorie");
                });

            modelBuilder.Entity("Taj_Plazza_CrudII.Models.Reservation", b =>
                {
                    b.HasOne("Taj_Plazza_CrudII.Models.Client", "client")
                        .WithMany("Reservations")
                        .HasForeignKey("clientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");
                });

            modelBuilder.Entity("Taj_Plazza_CrudII.Models.Reservation_OptionAjouter", b =>
                {
                    b.HasOne("Taj_Plazza_CrudII.Models.OptionAjouter", "optionAjouter")
                        .WithMany("reservation_OptionAjouters")
                        .HasForeignKey("OptionAjouterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Taj_Plazza_CrudII.Models.Reservation", "reservation")
                        .WithMany("reservation_OptionAjouters")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("optionAjouter");

                    b.Navigation("reservation");
                });

            modelBuilder.Entity("Taj_Plazza_CrudII.Models.Categorie", b =>
                {
                    b.Navigation("OptionAjouters");
                });

            modelBuilder.Entity("Taj_Plazza_CrudII.Models.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Taj_Plazza_CrudII.Models.OptionAjouter", b =>
                {
                    b.Navigation("reservation_OptionAjouters");
                });

            modelBuilder.Entity("Taj_Plazza_CrudII.Models.Reservation", b =>
                {
                    b.Navigation("reservation_OptionAjouters");
                });
#pragma warning restore 612, 618
        }
    }
}
