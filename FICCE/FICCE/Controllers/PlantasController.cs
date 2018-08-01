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
    public class PlantasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private PlantaModels clasePlanta;

        public PlantasController(ApplicationDbContext context)
        {
            _context = context;
            clasePlanta = new PlantaModels(context);
        }

        // GET: Plantas
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Planta.Include(p => p.Edificio);
            return View(await _context.Planta.ToListAsync());

        }

        public List<IdentityError> ControladorGuardaPlanta(int edificio, string nombre)
        {
            return clasePlanta.ModeloGrabaPlanta(edificio, nombre);
        }

        public List<object[]> ControladorListaPlanta()
        {
            return clasePlanta.ModeloListaPlanta();
        }
        public List<Planta> ControladorUnPlanta(int id)
        {
            //var sexo = _context.Sexos.Where(s => s.SexoId == sexoId).ToList();
            var respuesta = (from s in _context.Planta
                             where s.PlantaId == id
                             select s).ToList();
            return respuesta;
        }

        public List<IdentityError> ControladorEditaPlanta(int id, int edificio, string nombre)
        {
            return clasePlanta.ModeloEditarPlanta(id, edificio, nombre);
        }
        public List<IdentityError> ControladorEliminarPlanta(int id)
        {
            return clasePlanta.ModeloEliminarPlanta(id);
        }
        public List<object[]> ContronladorImprimirPlanta()
        {
            return clasePlanta.ModeloImpresion();
        }
    }
}
