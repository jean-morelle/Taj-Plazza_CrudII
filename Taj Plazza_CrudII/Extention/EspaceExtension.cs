using Taje__Plazza.Domain.Models;
using Taje_Plazza.Application.Automapper.DTOs;

namespace Taj_Plazza_CrudII.Extention
{
    public static class EspaceExtension
    {
        public static IEnumerable<EspaceReadDto> ConvertToDto(this IEnumerable<Espace> espaces, IEnumerable<Equipement> equipements)
        {
            Console.WriteLine("=== DEBUG INFO ===");
            Console.WriteLine($"Nombre d'espaces: {espaces.Count()}");
            Console.WriteLine($"Nombre d'équipements: {equipements.Count()}");

            foreach (var espace in espaces)
            {
                Console.WriteLine($"Espace {espace.Nom} - EquipementId: {espace.EquipementId}");
            }

            foreach (var eq in equipements)
            {
                Console.WriteLine($"Equipement ID: {eq.Id}, Nom: {eq.Nom}, Type: {eq.Type}");
            }

            var result = espaces.GroupJoin(
                equipements,
                espace => espace.EquipementId,
                equipement => equipement.Id,
                (espace, matchingEquipements) => new EspaceReadDto
                {
                    Id = espace.Id,
                    Nom = espace.Nom,
                    Capacite = espace.Capacite,
                    TypeEspace = espace.TypeEspace,
                    NomEquipement = matchingEquipements.FirstOrDefault()?.Nom ?? "NOT FOUND",
                    TypeEquipement = matchingEquipements.FirstOrDefault()?.Type ?? "NOT FOUND"
                }).ToList();

            return result;
        }





        public static EspaceReadDto ConvertTDto(this Espace espace ,Equipement equipement)
        {
            return new EspaceReadDto
            {
             Id = espace.Id,
             Nom = espace.Nom,
             Capacite = espace.Capacite,
             TypeEspace = espace.TypeEspace,
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
