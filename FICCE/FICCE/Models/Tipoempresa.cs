﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FICCE.Data;
using Microsoft.AspNetCore.Identity;
using FICCE.Models;

namespace FICCE.Models
{
    public class Tipoempresa
    {
         

        public int TipoempresaId { get; set; }
        public string  Nombre { get; set; }
        public string Detalle { get; set; }

        
    }
}
