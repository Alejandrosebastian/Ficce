using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FICCE.Models
{
    public class Planta
    {
        public int PlantaId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre del piso")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de la planta debe estar entre 3 y 50 caracteres")]
        pusblic string Nombre { get; set; }
        public int EdificioId { get; set; }
        public Edificio Edificio { get; set; }

    }
}
