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
            modelBuilder.Entity<Personnel>()
                  .HasOne(p => p.Utilisateur)
                  .WithMany(u => u.Personnels)
                  .HasForeignKey(p => p.UtilisateurId)
                  .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.Utilisateur)
                .WithMany(u => u.Clients)
                .HasForeignKey(c => c.UtilisateurId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.ClientId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Evenement)
                .WithMany(e => e.Reservations)
                .HasForeignKey(r => r.EvenementId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Evenement>()
                .HasOne(e => e.Client)
                .WithMany(c => c.Evenements)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Evenement>()
                .HasOne(f => f.Espace)
                .WithMany(r => r.Evenements)
                .HasForeignKey(f => f.EspaceId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Facture>()
                .HasOne(e => e.Reservation)
                .WithMany(r => r.Factures)
                .HasForeignKey(e => e.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MaintenanceDEquipement>()
                .HasOne(x => x.Equipement)
                 .WithMany(f => f.MaintenanceDEquipements)
                   .HasForeignKey(x => x.EquipementId)
                     .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<LocationDEquipement>()
                .HasOne(e => e.Equipement)
                 .WithMany(x => x.LocationDEquipements)
                  .HasForeignKey(f => f.EquipementId)
                   .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<LocationDEquipement>()
                .HasOne(x => x.Evenement)
                 .WithMany(f => f.LocationDequipements)
                  .HasForeignKey(u => u.EvenementId)
                   .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Espace>()
                .HasOne(x => x.Equipement)
                 .WithMany(x => x.Espaces)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
