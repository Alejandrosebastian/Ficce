using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FICCE.Models
{
    public class Evento_estante
    {
        public int Evento_estanteId { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
        public int EstantesId { get; set; }
        public Estantes Estantes { get; set; }
    }
}
