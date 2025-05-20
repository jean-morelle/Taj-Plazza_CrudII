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
    public class ClientProfile:Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientReadDto,Client>();
            CreateMap<Client, ClientReadDto>();
            CreateMap<AddClientDto, Client>();
            CreateMap<Client, AddClientDto>();
            CreateMap<UpdateClientDto, Client>();
            CreateMap<Client, UpdateClientDto>();
        }
    }
}
