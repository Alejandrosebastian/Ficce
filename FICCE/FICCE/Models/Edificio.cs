using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FICCE.Models
{
    public class Edificio
    {
        public int EdificioId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre del edificio")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "El nombre del edificio debe estar entre 3 y 220 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "La direccion del edificio ")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "La direccion del edificio debe estar entre 3 y 220 caracteres")]
        public string Ubicacion { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

    }
}
