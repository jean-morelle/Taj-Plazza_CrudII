using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.DTOs.ClientDto;
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
 