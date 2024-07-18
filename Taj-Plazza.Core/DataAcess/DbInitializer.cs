using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.DataAcess
{
    public class DbInitializer
    {
        public static void EnsureSeedData(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            if (context.Clients != null && context.Clients.Any())
                return;

            var customers = GetCustomers().ToArray();
            context.Clients.AddRange(customers);
            context.SaveChanges();
        }

        public static List<Client> GetCustomers()
        {
            var customers = new List<Client>
            {
                new Client
                {
                    NomComplete = "John Doe",
                    Domicile = "123 Rad road",
                    Email = "user@gmail.com",
                    Telephone = "01151234567"
                },
                new Client
                {
                    NomComplete = "John Smith",
                    Domicile = "456 Well Avenue",
                    Email = "user@gmail.com",
                    Telephone = "01151234789"
                },
                new Client()
                {
                    NomComplete = "Andy Doe",
                    Domicile = "33 Nem road",
                    Email = "user@gmail.com",
                    Telephone = "01151234567"
                },
                new Client()
                {
                    NomComplete = "Tom Smith",
                    Domicile = "12A Well Avenue",
                    Email = "user@gmail.com",
                    Telephone = "01151234789"
                },
                new Client()
                {
                    NomComplete = "Bryan Bob",
                    Domicile = "123B Rad road",
                    Email = "user@gmail.com",
                    Telephone = "01151234567"
                },
                new Client()
                {
                    NomComplete = "Kate Nate",
                    Domicile = "456 Torn Avenue",
                    Email = "user@gmail.com",
                    Telephone = "01151234789"
                },
                new Client()
                {
                    NomComplete = "Ekua Johnson",
                    Domicile = "149 Broxow road",
                    Email = "user@gmail.com",
                    Telephone = "01151234567"
                },
                new Client()
                {
                    NomComplete = "Elton Dave",
                    Domicile = "33A Bell Avenue",
                    Email = "user@gmail.com",
                    Telephone = "01151234789"
                },
                new Client()
                {
                    NomComplete = "Justin Sam",
                    Domicile = "123 Radford road",
                    Email = "user@gmail.com",
                    Telephone = "01151234567"
                },
                new Client()
                {
                    NomComplete = "Scottie Adjevi",
                    Domicile = "456 Bee Avenue",
                    Email = "user@gmail.com",
                    Telephone = "01151234789"
                }
            };

            return customers;
        }
    }
}
