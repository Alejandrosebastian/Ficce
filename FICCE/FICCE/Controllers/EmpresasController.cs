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
    public class EmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private EmpresaModels claseEmpresa;

        public EmpresasController(ApplicationDbContext context)
        {
            _context = context;
            claseEmpresa = new EmpresaModels(context);
        }

        // GET: Sexos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empresa.ToListAsync());
        }

        public List<IdentityError> ControladorGuardaEmpresa(int tipo, string nombre, string direccion, string correo, string persono, string contacto, string convencional, string extencion)
        {
            return claseEmpresa.ModeloGrabaEmpresa(tipo, nombre, direccion, correo, persono, contacto, convencional, extencion);
        }

        public List<object[]> ControladorListaEmpresa()
        {
            return claseEmpresa.ModeloListaEmpresa();
        }
        public List<Empresa> ControladorUnEmpresa(int id)
        {
            //var sexo = _context.Sexos.Where(s => s.SexoId == sexoId).ToList();
            var respuesta = (from s in _context.Empresa
                             where s.EmpresaId == id
                             select s).ToList();
            return respuesta;
        }

        public List<IdentityError> ControladorEditaEmpresa(int id, int tipo, string nombre, string direccion, string correo, string persono, string contacto, string convencional, string extencion)
        {
            return claseEmpresa.ModeloEditarEmpresa(id, tipo, nombre, direccion, correo, persono, contacto, convencional, extencion);
        }
        public List<IdentityError> ControladorEliminarEmpresa(int id)
        {
            return claseEmpresa.ModeloEliminarEmpresa(id);
        }
        public List<object[]> ContronladorImprimirEmpresa()
        {
            return claseEmpresa.ModeloImpresion();
        }
    }
}
