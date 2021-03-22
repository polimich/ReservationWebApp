using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MP.Model
{
    /// <summary>
    /// Model pro přihlašování uživatele
    /// </summary>
    public class AccountLoginIM
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

