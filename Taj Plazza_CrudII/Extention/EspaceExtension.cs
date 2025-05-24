using Taje__Plazza.Domain.Models;
using Taje_Plazza.Application.Automapper.DTOs;

namespace Taj_Plazza_CrudII.Extention
{
    public static class EspaceExtension
    {
       public static IEnumerable<EspaceReadDto>ConvertToDto(this IEnumerable<Espace>espaces,IEnumerable<Equipement> equipements)
        {
            var result = from espace in espaces
                         join equipement in equipements
                         on espace.EquipementId equals equipement.Id
                         select new EspaceReadDto
                         {
                             Id = espace.Id,
                             Nom = espace.Nom,
                             Type = espace.TypeEspace,
                             Capacite = espace.Capacite,
                             NomEquipement = equipement.Nom,
                             TypeEquipement = equipement.Type,
                         };
                   return result;    
        }
        public static EspaceReadDto ConvertTDto(this Espace espace ,Equipement equipement)
        {
            return new EspaceReadDto
            {
             Id = espace.Id,
             Nom = espace.Nom,
             Capacite = espace.Capacite,
             Type = espace.TypeEspace,
             NomEquipement = equipement.Nom,
             TypeEquipement = equipement.Type,
            };
        }
        public static Espace ConvertToEntity( this AddEspaceDto addEspaceDto)
        {
            return new Espace
            {
                Nom = addEspaceDto.Nom,
                Capacite = addEspaceDto.Capacite,
                TypeEspace = addEspaceDto.TypeEspace,
            };
        }
        public static void UpdateFromDto(this Espace espace,UpdateEspaceDto updateEspace)
        {
            espace.Id = updateEspace.Id;
            espace.EquipementId = updateEspace.EquipementId;
            espace.Nom =updateEspace.Nom;
            espace.Capacite = updateEspace.Capacite;
            espace.TypeEspace=updateEspace.TypeEspace;
        }
    }
}
