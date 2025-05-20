using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taje__Plazza.Domain.Models;

namespace Taje__Plazza.Domain.Interface
{
    public interface IClientServices
    {
        Task<IEnumerable<Client>> ObtenirTousLesClientsAsync();
        Task<Client> ObtenirClientParIdAsync(Guid clientId);
        Task<Client> ObtenirClientParNomAsync(string nom);
        Task AjouterClientAsync(Client client);
        Task ModifierClientAsync(Client client);
        Task SupprimerClientAsync(Guid clientId);
        Task SaveChangeAsync();
    }
}
