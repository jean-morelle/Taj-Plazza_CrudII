using System.Runtime.CompilerServices;
using Taje__Plazza.Domain.Models;
using Taje_Plazza.Application.Automapper.DTOs;

namespace Taj_Plazza_CrudII.Extention
{
    public static class EvenementExtension
    {


        public static IEnumerable<EvenementReadDto> ConvertToDto(
          this IEnumerable<Evenement> evenements,
         IEnumerable<Client> clients,IEnumerable<Espace>espaces)
         
        {
            var result = (
                from evenement in evenements
                join client in clients on evenement.ClientId equals client.Id
                join espace in espaces on evenement.EspaceId equals espace.Id
                select new EvenementReadDto
                {
                    Id = evenement.Id,
                    NomDuClient = client.Nom.ToUpper(),
                    PrenomDuClient = client.Prenom,
                    NomDesEspace = espace.Nom,
                    TypeEspace = espace.TypeEspace,
                    Capacite = espace.Capacite.ToString(),
                    NomEvenement = evenement.Nom,
                    DateEvenement = evenement.DateEvenement.ToLocalTime(),
                    DateDebut = evenement.DateDebut.ToLocalTime(),
                    DateFin = evenement.DateFin.ToLocalTime(),
                    TypeEvenement = evenement.TypeEvenement
                }).ToList();

            return result;
        }

        public static EvenementReadDto ConvertToDto(this Evenement evenement, Client client,Espace espace)
        {
            return new EvenementReadDto
            {
                Id = evenement.Id,
                NomDuClient = client.Nom.ToUpper(),
                PrenomDuClient = client.Prenom,
                NomDesEspace = espace.Nom,
                TypeEspace = espace.TypeEspace,
                NomEspace = espace.Nom.ToUpper(),
                Capacite = espace.Capacite.ToString(),
                NomEvenement = evenement.Nom,
                DateEvenement = evenement.DateEvenement.ToLocalTime(),
                DateDebut = evenement.DateDebut.ToLocalTime(),
                DateFin = evenement.DateFin.ToLocalTime(),
                TypeEvenement = evenement.TypeEvenement,
            };
        }
        public static Evenement ConvertToEntity(this AddEvenementDto evenementDto)
        {
            return new Evenement
            {
               
                ClientId = evenementDto.ClientId,
                EspaceId = evenementDto.EspaceId,
                Nom = evenementDto.NomEvenement,
                DateEvenement = evenementDto.DateEvenement.ToUniversalTime(),
                DateDebut = evenementDto.DateDebut.ToUniversalTime(),
                DateFin = evenementDto.DateFin.ToUniversalTime(),
                TypeEvenement = evenementDto.TypeEvenement,
            };
        }
        public static void UpdateFromDto(this Evenement evenement, UpdateEvenementDto dto)
        {
            evenement.ClientId = dto.ClientId;
            evenement.EspaceId = dto.EspaceId;
            evenement.Nom = dto.Nom;
            evenement.DateEvenement = dto.DateEvenement.ToUniversalTime();
            evenement.DateDebut = dto.DateDebut.ToUniversalTime();
            evenement.DateFin = dto.DateFin.ToUniversalTime();
            evenement.TypeEvenement = dto.TypeEvenement;
        }
    }
}
