using AutoMapper;
using Taj_Plazza.Core.DTOs;
using Taj_Plazza.Core.Models;

namespace Taj_Plazza.Core.Profiles
{
    public class ClientProfile :Profile
    {
        public ClientProfile()
        {
            //--Source => Destination
            CreateMap<ClientCreateDto, Client>();
        }
    }
}
