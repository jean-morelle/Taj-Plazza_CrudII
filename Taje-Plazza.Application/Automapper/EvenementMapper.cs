using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;
using Taje_Plazza.Application.DTOs;

namespace Taje_Plazza.Application.Automapper
{
    public static class EvenementMapper
    {
        public static EvenementDto ToEvenementDto (this Evenement evenement)
        {
            return new EvenementDto
            {
                Id = evenement.Id,
                ClientId = evenement.ClientId,
                Status = evenement.Status,
                NomEvenement = evenement.NomEvenement,
                Description = evenement.Description,
                DateDebut = evenement.DateDebut,
                DateFin = evenement.DateFin,
                Place = evenement.Place,
            };
        }
    }
}
