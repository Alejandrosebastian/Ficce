using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FICCE.Data;
using FICCE.Models;
using Microsoft.AspNetCore.Identity;

namespace FICCE.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private EmpleadoModels claseEmpleado;

        public EmpleadosController(ApplicationDbContext context)
        {
            _context = context;
            claseEmpleado = new EmpleadoModels(context);
        }


        // GET: Sexos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleado.ToListAsync());
        }

        public List<IdentityError> ControladorGuardaEmpleado(int empresa, string nombre, string apellido, string correo, string telefono_contacto, string telefono_movil, string direccion)
        {
            return claseEmpleado.ModeloGrabaEmpleado(empresa, nombre, apellido, correo, telefono_contacto, telefono_movil, direccion);
        }

        public List<object[]> ControladorListaEmpleado()
        {
            return claseEmpleado.ModeloListaEmpleado();
        }
        public List<Empleado> ControladorUnEdificio(int id)
        {
            //var sexo = _context.Sexos.Where(s => s.SexoId == sexoId).ToList();
            var respuesta = (from s in _context.Empleado
                             where s.EmpleadoId == id
                             select s).ToList();
            return respuesta;
        }

        public List<IdentityError> ControladorEditaEdificio(int id, int empresa, string nombre, string apellido, string correo, string telefono_contacto, string telefono_movil, string direccion)
        {
            return claseEmpleado.ModeloEditarEmpleado(id, empresa, nombre, apellido, correo, telefono_contacto, telefono_movil, direccion);
        }
        public List<IdentityError> ControladorEliminarEmpleado(int id)
        {
            return claseEmpleado.ModeloEliminarEmpleado(id);
        }
        public List<object[]> ContronladorImprimirEmpleado()
        {
            return claseEmpleado.ModeloImpresion();
        }
    }
}
