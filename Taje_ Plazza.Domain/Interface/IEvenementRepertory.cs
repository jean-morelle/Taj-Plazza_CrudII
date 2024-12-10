using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taje__Plazza.Domain.Interface
{
    public interface IEvenementRepertory
    {
        Task<List<Evenement>> GetAllEvenementAsync();
        Task<Evenement>GetEvenementByIdAsync(int evenementId);

        Task DeleteEvenementAsync(int evenementId);
        Task AddEvenementAsync (Evenement addEvenement);   
        
        Task UpdateEvenementAsync(Evenement updateEvenement);

        Task<List<Evenement>> GetClientEvenementAsync(int clientId);
    }
}
