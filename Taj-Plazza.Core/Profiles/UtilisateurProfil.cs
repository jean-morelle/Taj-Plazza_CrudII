using AutoMapper;
using Taj_Plazza.Core.DTOs;
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
