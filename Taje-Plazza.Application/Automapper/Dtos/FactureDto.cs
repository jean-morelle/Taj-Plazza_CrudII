using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taje_Plazza.Application.Automapper.Dtos
{
    public class FactureDto
    {
        [Required]
        public DateTime InvoiceDate { get; set; }

        public string? PaymentStatus { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
