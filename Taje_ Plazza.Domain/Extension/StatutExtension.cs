using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taj_Plazza.Core.Models;

namespace Taje__Plazza.Domain.Extension
{
    public static class StatutExtension
    {
        public static string ToStatutLabel(this ReservationStatus reservationStatus)
        {
            return reservationStatus switch
            {
                ReservationStatus.Réservation => "Réservation",
                ReservationStatus.Confirmation => "Confirmation",
                ReservationStatus.Annulation => "Annulation",
                _ => "Inconnu"
            };
        }
    }
}
