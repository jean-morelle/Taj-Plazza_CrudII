using Microsoft.EntityFrameworkCore;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.DataAcess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        public DbSet<Evenement> Evenements { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<EvenementReserver> EvenementReservers { get; set; }
     
        public DbSet<Categorie> Categories { get; set; }
    }
}
