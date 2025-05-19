using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje__Plazza.Domain.Models
{
    public class Espace
    {
        public Guid Id { get; set; }
        public Guid EquipementId { get; set; }
        public Equipement Equipement { get; set; } = new Equipement();
        public string Nom { get; set; } = string.Empty;
        public string Capacite { get; set; } = string.Empty;
        public string TypeEspace { get; set; } = string.Empty;
        public ICollection<Evenement> Evenements { get; set;} = new List<Evenement>();
    }
}
