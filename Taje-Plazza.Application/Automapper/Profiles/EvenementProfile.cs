using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;
using Taje_Plazza.Application.DTOs;

namespace Taje_Plazza.Application.Automapper.Profiles
{
    public class EvenementProfile :Profile
    {
        public EvenementProfile()
        {
            //--Source => Destination
            CreateMap<EvenementDto, Evenement>();

            CreateMap<Evenement,EvenementDto>();
        }
    }
}
