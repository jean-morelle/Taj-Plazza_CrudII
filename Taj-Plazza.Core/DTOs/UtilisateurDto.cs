﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taj_Plazza.Core.DTOs
{
    public class UtilisateurDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
