using Taje__Plazza.Domain.Models;
using Taje_Plazza.Application.Automapper.DTOs;

namespace Taj_Plazza_CrudII.Extention
{
    public static class ClientExtension
    {
        public static IEnumerable<ClientReadDto> ConvertTodto(this IEnumerable<Client> clients)
        {
            return (
              from client in clients
              select new ClientReadDto
              {
                  Id = client.Id,
                  Nom = client.Nom,
                  Prenom = client.Prenom,
                  Adresse = client.Adresse,
                  NumeroDeTelephone = client.NumeroDeTelephone,
                  Email = client.Email,
              }).ToList();
        }
        public static Client ConvertToDto(ClientReadDto client)
        {

            return new Client
            {
                Id = client.Id,
                Nom = client.Nom,
                Prenom = client.Prenom,
                Adresse = client.Adresse,
                NumeroDeTelephone = client.NumeroDeTelephone,
            };
        }

        public static void UpdateFromDto(this Client client, UpdateClientDto dto)
        {
            client.Nom = dto.Nom;
            client.Prenom = dto.Prenom;
            client.Email = dto.Email;
            client.NumeroDeTelephone = dto.NumeroDeTelephone;
            client.Adresse = dto.Adresse;
        }
        public static Client ConvertToEntity(this AddClientDto dto)
        {
            return new Client
            {
                //Id = Guid.NewGuid(), 
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Email = dto.Email,
                NumeroDeTelephone = dto.NumeroDeTelephone,
                Adresse = dto.Adresse
            };
        }

    }
}
