using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FICCE.Models
{
    public class Estantes
    {
        public int EstantesId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Escriba el ancho del estante")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "El ancho del estante debe estar entre 1 y 10 caracteres")]
        public int Ancho { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Escriba el lagor del estante")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "El largo del estante debe estar entre 1 y 10 caracteres")]
        public int Largo { get; set; }
        //Relaciones
        public int PlantaId { get; set; }
        public Planta Planta { get; set; }


    }
}
