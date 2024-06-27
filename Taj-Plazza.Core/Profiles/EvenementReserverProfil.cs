using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.DTOs.EvenementDto;
using Taj_Plazza.Core.DTOs.EvenementReserverDto;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Profiles
{
    public class EvenementReserverProfil : Profile
    {
        public EvenementReserverProfil()
        {
            // --- Source => Destination

            CreateMap<EvenementReserver,AddEvenemntReserver>();

            CreateMap<EvenementReserver, ReadEvenementReserverDto>();
            
        }
    }
}
