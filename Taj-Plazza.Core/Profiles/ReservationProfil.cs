using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.DTOs.ReservationDto;
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
