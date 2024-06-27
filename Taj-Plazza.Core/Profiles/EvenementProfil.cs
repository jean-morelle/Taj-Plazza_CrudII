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
    public class EvenementProfil : Profile
    {
        public EvenementProfil()
        {
            //-- source => Destination
            CreateMap<Evenement, AddEvenementDto>();

            CreateMap<Evenement, ReadEvenementDto>();
        }
    }
}
