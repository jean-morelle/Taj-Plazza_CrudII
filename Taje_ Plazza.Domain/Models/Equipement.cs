using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje__Plazza.Domain.Models
{
    public class Equipement :BaseEntiy
    {
        public string Nom { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int QuantiteDisponible { get; set; } 
        public ICollection<Espace> Espaces { get; set;} = new List<Espace>();
        public ICollection<LocationDEquipement>LocationDEquipements { get; set;}= new List<LocationDEquipement>();
        public ICollection<MaintenanceDEquipement> MaintenanceDEquipements { get; set; } = new List<MaintenanceDEquipement>();
    }
}
