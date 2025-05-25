using Taje__Plazza.Domain.Models;
using Taje_Plazza.Application.Automapper.DTOs;

namespace Taj_Plazza_CrudII.Extention
{
    public static class EspaceExtention
    {
        public static IEnumerable<EspaceReadDto> ConvertToDto(this IEnumerable<Espace> espaces, IEnumerable<Equipement> equipements)
        {
            var result = (
                from espace in espaces
                join equipement in equipements on espace.EquipementId equals equipement.Id
                select new EspaceReadDto
                {
                    Id = espace.Id,
                    Nom = espace.Nom,
                    Capacite = espace.Capacite,
                    Type = espace.TypeEspace,
                    NomEquipement = equipement.Nom,
                    TypeEquipement = equipement.Type
                }).ToList();
            return result;
 
        }
        public static EspaceReadDto ConvertTo ( this Espace espace, Equipement equipement)
        {
           return (
                new EspaceReadDto
                {
                    Id = espace.Id,
                    Nom = espace.Nom,
                    Capacite = espace.Capacite,
                    Type = espace.TypeEspace,
                    NomEquipement = equipement.Nom,
                    TypeEquipement = equipement.Type
                });
        }
    }
}
