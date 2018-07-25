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
    public class EdificiosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private EdificioModels claseEdificio;

        public EdificiosController(ApplicationDbContext context)
        {
            _context = context;
            claseEdificio = new EdificioModels(context);
        }


        // GET: Sexos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Edificio.ToListAsync());
        }

        public List<IdentityError> ControladorGuardaEdificio(int evento, string nombre, string ubicacion)
        {
            return claseEdificio.ModeloGrabaEdificio(evento, nombre, ubicacion);
        }

        public List<object[]> ControladorListaEdificio()
        {
            return claseEdificio.ModeloListaEdificio();
        }
        public List<Edificio> ControladorUnEdificio(int id)
        {
            //var sexo = _context.Sexos.Where(s => s.SexoId == sexoId).ToList();
            var respuesta = (from s in _context.Edificio
                        where s.EdificioId == id
                        select s).ToList();
            return respuesta;
        }

        public List<IdentityError> ControladorEditaEdificio(int id, int evento, string nombre, string ubicacion)
        {
            return claseEdificio.ModeloEditarEdificio(id, evento, nombre, ubicacion);
        }
        public List<IdentityError> ControladorEliminarEdificio(int id)
        {
            return claseEdificio.ModeloEliminarEdificio(id);
        }
        public List<object[]> ContronladorImprimirEdificio()
        {
            return claseEdificio.ModeloImpresion();
        }
    }
}
