using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taje__Plazza.Domain.Models
{
    public class Personnel:Utilisateur
    {
       
        [Required]
        public string? StaffRole { get; set; }

        public string? Phone { get; set; }
    }
}

