using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FICCE.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        [Display(Name = "Nombre de la Feria")]      
        public string Ciudad { get; set; }
        [Display(Name = "Fecha de inicio de la feria")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM}", ApplyFormatInEditMode = true)]
        public DateTime dia_inicio { get; set; }
        [Display(Name = "Fecha de fin de la feria")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM}", ApplyFormatInEditMode = true)]
        public DateTime dia_fin { get; set; }
        public int precio_estan { get; set; }


    }
}
