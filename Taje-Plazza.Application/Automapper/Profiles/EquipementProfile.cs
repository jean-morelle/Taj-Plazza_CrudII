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
    public class EquipementProfile:Profile
    {
        public EquipementProfile()
        {
            CreateMap<Equipement, EquipementReadDto>();
            CreateMap<EquipementReadDto, Equipement>();
            CreateMap<AddEquipementDto, Equipement>();
            CreateMap<Equipement,AddEquipementDto>();
            CreateMap<Equipement, UpdateEquipementDto>();
            CreateMap<UpdateEquipementDto,Equipement>();
        }
    }
}
