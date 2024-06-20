using AutoMapper;
using Taj_Plazza_CrudII.Dto;
using Taj_Plazza_CrudII.Models;

namespace Taj_Plazza_CrudII.Profiles
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
