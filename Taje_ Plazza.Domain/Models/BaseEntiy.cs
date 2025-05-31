using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje__Plazza.Domain.Models
{
    public abstract class BaseEntiy
    {
        [Key]
        public Guid Id { get; set; }
    }
}
