﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MP.Model.AcountIM
{
    /// <summary>
    /// Model pro změnu hesla
    /// </summary>
    public class ChangePasswordIM
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
