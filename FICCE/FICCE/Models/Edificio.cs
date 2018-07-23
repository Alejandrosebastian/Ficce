using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FICCE.Models
{
    public class Edificio
    {
        public int EdificioId { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

    }
}
