using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_MP.Model
{
    /// <summary>
    /// Model uživatele rozšiřující základního IdentityUsera
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string WhatITeach { get; set; }
    }
}
