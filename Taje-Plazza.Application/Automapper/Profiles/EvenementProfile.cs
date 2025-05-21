using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Application.Automapper.DTOs;

namespace Taje_Plazza.Application.Automapper.Profiles
{
    public class EvenementProfile:Profile
    {
        public EvenementProfile()
        {
            CreateMap<EvenementReadDto, Evenement>();
            CreateMap<Evenement,EvenementReadDto>();
            CreateMap<AddEvenementDto,Evenement>();
            CreateMap<Evenement,AddEvenementDto>();
            CreateMap<UpdateEvenementDto, Evenement>();
            CreateMap<Evenement,UpdateEvenementDto>();

        }
    }
}
