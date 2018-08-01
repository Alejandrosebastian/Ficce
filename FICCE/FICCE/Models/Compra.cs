using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FICCE.Models
{
    public class Compra
    {
        public int CompraId { get; set; }
        public Boolean Activo { get; set; }
        public int EstantesId { get; set; }
        public Estantes Estantes { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public string imagen {get; set;}
        
    }
}
