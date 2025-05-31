using Microsoft.EntityFrameworkCore;
using Taj_Plazza.Core.Models;
using Taje__Plazza.Domain.Models;

namespace Taj_Plazza.Core.DataAcess
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Equipement> Equipements { get; set; }
        public DbSet<LocationDEquipement> LocationDEquipements { get; set; }
        public DbSet<MaintenanceDEquipement> MaintenanceDEquipements { get; set; }
        public DbSet<Espace> Espaces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Exemple : Relation One-to-Many entre Client et Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.ClientId);

            // Exemple : Relation One-to-Many entre Space et Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Space)
                .WithMany(s => s.Reservations)
                .HasForeignKey(r => r.SpaceId);

            modelBuilder.Entity<Facture>()
        .HasOne(f => f.Reservation)
        .WithMany(r => r.Invoices)
        .HasForeignKey(f => f.ReservationId)
        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Facture>()
                .HasOne(f => f.Client)
                .WithMany(c => c.Invoices)
                .HasForeignKey(f => f.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Facture>()
                .HasOne(f => f.Space)
                .WithMany(s => s.Invoices)
                .HasForeignKey(f => f.SpaceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Facture>()
       .Property(f => f.TotalAmount)
       .HasColumnType("decimal(18,2)"); // Définit la précision et l’échelle

            modelBuilder.Entity<Reservation>()
                .Property(r => r.AmountPaid)
                .HasColumnType("decimal(18,2)"); // Évite le troncage des valeurs
        }
    }
}
