﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface IProvincia : IEntity
    {
        string Nombre { get; set; }
    }
}
