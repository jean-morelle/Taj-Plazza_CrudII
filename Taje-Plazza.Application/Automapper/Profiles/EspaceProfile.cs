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
    public class EspaceProfile:Profile
    {
        public EspaceProfile()
        {
            CreateMap<Espace, EspaceReadDto>();
            CreateMap<EspaceReadDto, Espace>();
            CreateMap<Espace,AddEspaceDto>();
            CreateMap<AddEspaceDto, Espace>();
            CreateMap<Espace, UpdateEspaceDto>();
            CreateMap<UpdateEspaceDto,Espace>();
            
        }
    }
}
