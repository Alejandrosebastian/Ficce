using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FICCE.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        public int año { get; set; }
        public DateTime dia_inicio { get; set; }
        public DateTime dia_fin { get; set; }
        public int precio_estan { get; set; }


    }
}
