﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Taj_Plazza.Core.DataAcess;

#nullable disable

namespace TajPlazza.Core.Migrations
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

            modelBuilder.Entity("Taj_Plazza.Core.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Domicile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomComplete")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Taj_Plazza.Core.Models.Evenement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateDebut")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DateFin")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomEvenement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Evenements");
                });

            modelBuilder.Entity("Taj_Plazza.Core.Models.EvenementReserver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Activites")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("DateDebut")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DateFin")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("EvenementId")
                        .HasColumnType("int");

                    b.Property<string>("LieuEvenement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EvenementId");

                    b.ToTable("EvenementReservers");
                });

            modelBuilder.Entity("Taj_Plazza.Core.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateDeReservation")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("EvenementId")
                        .HasColumnType("int");

                    b.Property<int>("NombreDePersonne")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EvenementId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Taj_Plazza.Core.Models.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("Taj_Plazza.Core.Models.Evenement", b =>
                {
                    b.HasOne("Taj_Plazza.Core.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Taj_Plazza.Core.Models.EvenementReserver", b =>
                {
                    b.HasOne("Taj_Plazza.Core.Models.Evenement", "Evenement")
                        .WithMany()
                        .HasForeignKey("EvenementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evenement");
                });

            modelBuilder.Entity("Taj_Plazza.Core.Models.Reservation", b =>
                {
                    b.HasOne("Taj_Plazza.Core.Models.Client", null)
                        .WithMany("Reservations")
                        .HasForeignKey("ClientId");

                    b.HasOne("Taj_Plazza.Core.Models.Evenement", "Evenement")
                        .WithMany()
                        .HasForeignKey("EvenementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Taj_Plazza.Core.Models.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evenement");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("Taj_Plazza.Core.Models.Client", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
