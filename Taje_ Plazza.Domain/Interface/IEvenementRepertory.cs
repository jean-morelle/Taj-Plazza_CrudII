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
        Task<List<Evenement>> GetAllEvenement();
        Task<Evenement>GetEvenementById(int evenementId);

        Task DeleteEvenement(int evenementId);
        Task AddEvenement (Evenement addEvenement);   
        
        Task UpdateEvenement (Evenement updateEvenement);

        Task<List<Evenement>> GetClientById(int clientId);
    }
}
