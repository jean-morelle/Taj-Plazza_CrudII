using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.DTOs.UtilisateurDto;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Profiles
{
    public class UtilisateurProfil : Profile
    {
        public UtilisateurProfil()
        {
            //-- Source => Destination

            CreateMap<Utilisateur,AddUtilisateurDto>();

            CreateMap<Utilisateur, ReadUtilisateurDto>();
        }
    }
}
