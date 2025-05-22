using Taje__Plazza.Domain.Models;
using Taje_Plazza.Application.Automapper.DTOs;

namespace Taj_Plazza_CrudII.Extention
{
    public  static class EquipementExtension
    {
        public static IEnumerable<EquipementReadDto> ConvertToDto(this IEnumerable<Equipement> equipements)
        {
            return (
                from equipement in equipements
                select new EquipementReadDto
                {
                    Id = equipement.Id,
                    Nom =equipement.Nom,
                    Type =equipement.Type,
                    QuantiteDisponible = equipement.QuantiteDisponible,
                }).ToList();    
        }
        public static Equipement ConvertToDto(this Equipement equipement)
        {

            return new Equipement
            {
                Id = equipement.Id,
                Nom = equipement.Nom,
                Type = equipement.Type,
                QuantiteDisponible =equipement.QuantiteDisponible  
            };
        }
        public static void UpdateFromDto(this Equipement equipement, UpdateEquipementDto dto)
        {
            equipement.Id = dto.Id;
            equipement.Nom = dto.Nom;
            equipement.Type = dto.Type;
            equipement.QuantiteDisponible = dto.QuantiteDisponible;   
        }
        public static Equipement ConvertToEntity(this AddEquipementDto dto)
        {
            return new Equipement
            { 
                Nom = dto.Nom,
                Type = dto.Type,
                QuantiteDisponible =dto.QuantiteDisponible,
            };
        }
    }
}
