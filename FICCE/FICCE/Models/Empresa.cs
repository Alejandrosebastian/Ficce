using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FICCE.Models
{
    public class Empresa
    {
        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public string telefono_contacto { get; set; }
        public string telefono_convencional { get; set; }
        public string extenencion_telefono { get; set; }
        public string persona_responsable { get; set; }
        public int TipoempresaId { get; set; }
        public Tipoempresa Tipoempresa { get; set; }
    }
}
