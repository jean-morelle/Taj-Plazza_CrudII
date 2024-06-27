using AutoMapper;
using Taj_Plazza.Core.DTOs;
using Taj_Plazza.Core.Models;

namespace TTaj_Plazza.Core.Models.Profiles
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
