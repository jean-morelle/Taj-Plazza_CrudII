using Microsoft.EntityFrameworkCore;
using Taj_Plazza.Core.Models;
using Taje_Plazza.Domain.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Taje__Plazza.Domain.Models;

namespace Taj_Plazza.Core.DataAcess
{
    public class ApplicationDbContext : DbContext
    {
        private static ValueComparer<List<string>> ListStringComparer => new ValueComparer<List<string>>(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Espace> Espaces { get; set; }
        public DbSet<Equipement> Equipements { get; set; }
        public DbSet<LocationEquipement> LocationsEquipements { get; set; }
        public DbSet<MaintenanceEquipement> MaintenancesEquipements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration des propriétés List<string>
            modelBuilder.Entity<Reservation>()
                .Property(r => r.Options)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null))
                .Metadata.SetValueComparer(ListStringComparer);

            modelBuilder.Entity<Reservation>()
                .Property(r => r.ServicesSupplementaires)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null))
                .Metadata.SetValueComparer(ListStringComparer);

            modelBuilder.Entity<Personnel>()
                .Property(p => p.Competences)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null))
                .Metadata.SetValueComparer(ListStringComparer);

            modelBuilder.Entity<Personnel>()
                .Property(p => p.Certifications)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null))
                .Metadata.SetValueComparer(ListStringComparer);

            // Configuration des propriétés décimales de Facture
            modelBuilder.Entity<Facture>(entity =>
            {
                entity.Property(f => f.MontantTotal).HasColumnType("decimal(18,2)");
                entity.Property(f => f.MontantRestantDu).HasColumnType("decimal(18,2)");
            });

            // Configuration de l'héritage TPH (Table Per Hierarchy)
            modelBuilder.Entity<Utilisateur>()
                .HasDiscriminator<string>("TypeUtilisateur")
                .HasValue<Utilisateur>("Utilisateur")
                .HasValue<Client>("Client")
                .HasValue<Personnel>("Personnel");

            // Configuration des propriétés de Utilisateur
            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Nom).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Prenom).IsRequired().HasMaxLength(50);
                entity.Property(u => u.MotDePasse).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Role).IsRequired().HasMaxLength(50);
                entity.HasIndex(u => u.Email).IsUnique();
            });

            // Configuration Client
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(c => c.NumeroClient).IsRequired().HasMaxLength(50);
                entity.Property(c => c.Adresse).HasMaxLength(200);
                entity.Property(c => c.Preferences).HasMaxLength(500);
            });

            // Configuration Personnel
            modelBuilder.Entity<Personnel>(entity =>
            {
                entity.Property(p => p.Poste).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Departement).IsRequired().HasMaxLength(50);
                entity.Property(p => p.NumeroEmploye).HasMaxLength(50);
                entity.Property(p => p.Notes).HasMaxLength(500);
                entity.Property(p => p.SalaireBase).HasColumnType("decimal(18,2)");
            });

            // Configuration Espace
            modelBuilder.Entity<Espace>(entity =>
            {
                entity.Property(e => e.Nom).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Type).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Localisation).HasMaxLength(200);
                entity.Property(e => e.Caracteristiques).HasMaxLength(500);
                entity.Property(e => e.TarifHoraire).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TarifJournalier).HasColumnType("decimal(18,2)");
            });

            // Configuration Equipement
            modelBuilder.Entity<Equipement>(entity =>
            {
                entity.Property(e => e.Nom).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Type).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.NumeroSerie).HasMaxLength(50);
                entity.Property(e => e.Marque).HasMaxLength(100);
                entity.Property(e => e.Modele).HasMaxLength(100);
                entity.Property(e => e.TarifJournalier).HasColumnType("decimal(18,2)");
            });

            // Relations Reservation
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasOne(r => r.Client)
                    .WithMany(c => c.Reservations)
                    .HasForeignKey(r => r.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.Espace)
                    .WithMany(e => e.Reservations)
                    .HasForeignKey(r => r.EspaceId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(r => r.Statut).IsRequired().HasMaxLength(50);
                entity.Property(r => r.MotifAnnulation).HasMaxLength(500);
                entity.Property(r => r.NotesSpeciales).HasMaxLength(1000);
                entity.Property(r => r.MontantTotal).HasColumnType("decimal(18,2)");
                entity.Property(r => r.MontantPaye).HasColumnType("decimal(18,2)");
            });

            // Relations LocationEquipement
            modelBuilder.Entity<LocationEquipement>(entity =>
            {
                entity.HasOne(l => l.Reservation)
                    .WithMany(r => r.EquipementsReserves)
                    .HasForeignKey(l => l.ReservationId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(l => l.Equipement)
                    .WithMany(e => e.Locations)
                    .HasForeignKey(l => l.EquipementId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(l => l.Statut).IsRequired().HasMaxLength(50);
                entity.Property(l => l.MotifAnnulation).HasMaxLength(500);
                entity.Property(l => l.Commentaires).HasMaxLength(500);
                entity.Property(l => l.MontantLocation).HasColumnType("decimal(18,2)");
            });

            // Relations MaintenanceEquipement
            modelBuilder.Entity<MaintenanceEquipement>(entity =>
            {
                entity.HasOne(m => m.Equipement)
                    .WithMany(e => e.Maintenances)
                    .HasForeignKey(m => m.EquipementId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.Personnel)
                    .WithMany(p => p.MaintenancesEffectuees)
                    .HasForeignKey(m => m.PersonnelId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(m => m.Type).IsRequired().HasMaxLength(50);
                entity.Property(m => m.Statut).IsRequired().HasMaxLength(50);
                entity.Property(m => m.Description).HasMaxLength(1000);
                entity.Property(m => m.Resultats).HasMaxLength(500);
                entity.Property(m => m.Recommandations).HasMaxLength(500);
                entity.Property(m => m.CoutMaintenance).HasColumnType("decimal(18,2)");
            });
        }
    }
}
