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
    public class EventosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private EventoModels claseEvento;

        public EventosController(ApplicationDbContext context)
        {
            _context = context;
            claseEvento = new EventoModels(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Evento.ToListAsync());
        }

        public List<IdentityError> ControladorGuardaEvento(string ciudad, DateTime fecha_ini, DateTime fecha_fin, int valor)
        {
            return claseEvento.ModeloGrabaEvento(ciudad, fecha_ini, fecha_fin, valor);
        }

        public List<object[]> ControladorListaEvento()
        {
            return claseEvento.ModeloListaEvento();
        }
        public List<Evento> ControladorUnEvento(int id)
        {
            //var sexo = _context.Sexos.Where(s => s.SexoId == sexoId).ToList();
            var res = (from s in _context.Evento
                       where s.EventoId == id
                       select s).ToList();
            return res;
        }

        public List<IdentityError> ControladorEditaEvento(int id, string ciudad, DateTime fecha_ini, DateTime fecha_fin, int valor)
        {
            return claseEvento.ModeloEditarEvento(id, ciudad, fecha_ini, fecha_fin, valor);
        }
        public List<IdentityError> ControladorEliminarEvento(int id)
        {
            return claseEvento.ModeloEliminarEvento(id);
        }
        public List<object[]> ContronladorImprimirEvento()
        {
            return claseEvento.ModeloImpresion();
        }
    }
}
