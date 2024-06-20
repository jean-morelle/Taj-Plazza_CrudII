using Microsoft.EntityFrameworkCore;
using Taj_Plazza_CrudII.Models;

namespace Taj_Plazza_CrudII.DataAcess
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
                
        }

        public DbSet<Categorie> Categories { get; set; }

        public DbSet <Client> Clients { get; set; }

        public DbSet <Reservation> Reservations { get; set; }

        public DbSet <OptionAjouter> Options { get; set; }

        public DbSet<Reservation_OptionAjouter> reservation_OptionAjouters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de la relation one-to-many entre Client et Reservation
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Reservations)
                .WithOne(r => r.client)
                .HasForeignKey(r => r.clientId);
                

            // Configuration de la relation one-to-many entre Categorie et OptionAjouter
            modelBuilder.Entity<Categorie>()
                .HasMany(c => c.OptionAjouters)
                .WithOne(o => o.categorie)
                .HasForeignKey(o => o.CategorieId);

            // Configuration de la relation many-to-many entre Reservation et OptionAjouter
            modelBuilder.Entity<Reservation_OptionAjouter>()
                .HasKey(ro => new { ro.ReservationId, ro.OptionAjouterId });

            modelBuilder.Entity<Reservation_OptionAjouter>()
                .HasOne(ro => ro.reservation)
                .WithMany(r => r.reservation_OptionAjouters)
                .HasForeignKey(ro => ro.ReservationId);

            modelBuilder.Entity<Reservation_OptionAjouter>()
                .HasOne(ro => ro.optionAjouter)
                .WithMany(o => o.reservation_OptionAjouters)
                .HasForeignKey(ro => ro.OptionAjouterId);
        }
    }
}
