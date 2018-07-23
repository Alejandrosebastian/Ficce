using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FICCE.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Nombre del empleado")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "El nombre del medicamento debe estar entre 3 y 220 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Apellido del empleado")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "El apellido del empleado debe estar entre 3 y 220 caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Correo electronico de empleado")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "El correo del empleado debe estar entre 3 y 220 caracteres")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "direccion del empleado")]
        [StringLength(220, MinimumLength = 3, ErrorMessage = "La direccion del empleado debe estar entre 3 y 220 caracteres")]
        public string direccion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Telefono convencional de contacto")]
        [StringLength(10, MinimumLength = 7, ErrorMessage = "El telefono del empleado debe estar entre 7 y 10 caracteres")]
        public string Telefono_convencional { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Telefono movil del empleado")]
        [StringLength(10, MinimumLength = 7, ErrorMessage = "El telefono movil del empleado debe estar entre 7 y 10 caracteres")]
        public string telefono_movil { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

    }
}
