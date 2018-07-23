using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FICCE.Models
{
    public class Empresa
    {
        public int EmpresaId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre de la Empresa")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "El nombre de la empresa debe estar entre 3 y 220 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Direccion de la empresa")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "La direccion de la empresa debe estar entre 3 y 220 caracteres")]
        public string direccion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Correo de la empresa")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El corre de la empresa debe estar entre 3 y 100 caracteres")]
        public string correo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Telefono de contacto del encargado de la compra")]
        [StringLength(10, MinimumLength = 7, ErrorMessage = "El telefono de contacto debe estar entre 7 y 10 caracteres")]
        public string telefono_contacto { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Numero de la empresa")]
        [StringLength(10, MinimumLength = 7, ErrorMessage = "El numero de la empresa debe estar entre 7 y 10 caracteres")]
        public string telefono_convencional { get; set; }
        [Display(Name = "Extencion del telefono de contacto si tiene")]
        [StringLength(7, MinimumLength = 3, ErrorMessage = "Extencion del telefono debe estar entre 3 y 7 caracteres")]
        public string extenencion_telefono { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre de la persono de referencia")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "El nombre de la persono de referencia debe estar entre 3 y 220 caracteres")]
        public string persona_responsable { get; set; }
        public int TipoempresaId { get; set; }
        public Tipoempresa Tipoempresa { get; set; }
    }
}
