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
        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }
    }
}
