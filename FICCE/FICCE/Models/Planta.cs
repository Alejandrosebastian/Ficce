using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FICCE.Models
{
    public class Planta
    {
        public int PlantaId { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public int EdificioId { get; set; }
        public Edificio Edificio { get; set; }

    }
}
