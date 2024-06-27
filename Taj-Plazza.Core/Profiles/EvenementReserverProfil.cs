using AutoMapper;
using Taj_Plazza.Core.DTOs;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Profiles
{
    public class EvenementReserverProfil : Profile
    {
        public EvenementReserverProfil()
        {
            // --- Source => Destination

            CreateMap<EvenementReserver,AddEvenemntReserverDto>();

            CreateMap<EvenementReserver, ReadEvenementReserverDto>();
            
        }
    }
}
