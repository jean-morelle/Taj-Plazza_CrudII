using System;
using System.ComponentModel.DataAnnotations;

namespace Taje_Plazza.Domain.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        
        public DateTime DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public bool EstActif { get; set; } = true;

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            DateCreation = DateTime.Now;
            EstActif = true;
        }
    }
} 