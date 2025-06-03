using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Application.Automapper.Dtos;
using Taje_Plazza.Domain.Models;

namespace Taje_Plazza.Application.Automapper.Profils
{
    public class TajjProfile: Profile
    {
        public TajjProfile()
        {
            // CreateMap<Source, Destination>();
            // Add your mappings
            CreateMap<Client,ClientDto>();
            CreateMap<ClientDto, Client>();
            CreateMap<Equipement,EquipementDto>();
            CreateMap<EquipementDto,Equipement>();
            CreateMap<Espace,EspaceDto>();
            CreateMap<EspaceDto, Espace>();
            CreateMap<Facture, FactureDto>();
            CreateMap<FactureDto, Facture>();
            CreateMap<Evenement,EvenementDto>();
            CreateMap<EvenementDto, Evenement>(); 

        }
    }
  
}
