﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public enum LoginResult
    {
        DuplicatedSesion,
        InvalidUsername,
        InvalidPassword,
        InvalidDV,
        InvalidStatus,
        ValidUser
    }
}
