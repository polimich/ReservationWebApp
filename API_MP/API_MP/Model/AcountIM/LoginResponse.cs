using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MP.Model.AcountIM
{
    public class LoginResponse
    {
        public string Name { get; set; }
        public AuthorizationToken Token { get; set; }
        public string Role { get; set; }
        public string UserId { get; set; }
        public string WhatITeach { get; set; }
    }
}
