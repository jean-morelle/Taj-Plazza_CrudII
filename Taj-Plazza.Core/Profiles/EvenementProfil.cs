using AutoMapper;
using Taj_Plazza.Core.DTOs;
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
