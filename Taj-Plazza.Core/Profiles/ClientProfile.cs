using AutoMapper;
using Taj_Plazza.Core.Models;
using Taj_Plazza.Core.Models.Dto;

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
