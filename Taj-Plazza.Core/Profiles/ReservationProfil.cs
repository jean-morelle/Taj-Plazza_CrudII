using AutoMapper;
using Taj_Plazza.Core.DTOs;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Profiles
{
    public class ReservationProfil : Profile
    {

        public ReservationProfil()
        {
            // --Source => Destination

            CreateMap<Reservation,AddReservationDto>();

            CreateMap<Reservation,ReadReservationDto>();
        }
    }
}
