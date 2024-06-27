using AutoMapper;
using Taj_Plazza.Core.DTOs;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Profiles
{
    public class ClientProfil : Profile
    {
        public ClientProfil()
        {
            //--Source => Destination
            CreateMap<AddClientDto, Client>();

            CreateMap<Client,ReadClientDto>();

        }
    }
}
 