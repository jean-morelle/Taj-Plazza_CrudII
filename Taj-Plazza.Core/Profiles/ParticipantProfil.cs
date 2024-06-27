using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.DTOs.ParticipantDto;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Profiles
{
    public class ParticipantProfil :Profile
    {
        // Source => Destination

        public ParticipantProfil()
        {
            CreateMap<Participant,AddParticipantDto>();

            CreateMap<Participant,ReadParticipantDto>();
        }
    }
}
