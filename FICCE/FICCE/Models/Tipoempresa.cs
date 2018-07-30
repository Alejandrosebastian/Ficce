using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FICCE.Data;
using Microsoft.AspNetCore.Identity;

namespace FICCE.Models
{
    public class Tipoempresa
    {
        private ApplicationDbContext context;

        public Tipoempresa(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int TipoempresaId { get; set; }
        public string  Nombre { get; set; }
        public string Detalle { get; set; }

        internal List<IdentityError> ModeloGuardatipoempres(string detalle, string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
