using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FICCE.Models
{
    public class Estantes
    {
        public int EstantesId { get; set; }
        public int NumeroEstan { get; set; }
        public string LargoAncho { get; set; }
        //Relaciones
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
        public int PlantaId { get; set; }
        public Planta Planta { get; set; }


    }
}
