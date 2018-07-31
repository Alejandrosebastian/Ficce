using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FICCE.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using FICCE.Models;

namespace FICCE.Models
{
    public class Tipoempresa
    {
       

        public int TipoempresaId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre de la Empresa")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "El tipo de la empresa debe estar entre 3 y 220 caracteres")]
        public string  Nombre { get; set; }
        public string Detalle { get; set; }

        
    }
}
