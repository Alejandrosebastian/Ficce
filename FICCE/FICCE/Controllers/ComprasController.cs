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
    public class ComprasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private CompraModels claseCompra;

        public ComprasController(ApplicationDbContext context)
        {
            _context = context;
            claseCompra = new CompraModels(context);
        }

        // GET: Sexos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Compra.ToListAsync());
        }

        public List<IdentityError> ControladorGuardaCompra(Boolean activo, int estante, int empresa, string imagen)
        {
            return claseCompra.ModeloGrabaCompra(activo, estante, empresa, imagen);
        }

        public List<object[]> ControladorListaCompra()
        {
            return claseCompra.ModeloListaCompra();
        }
        public List<Edificio> ControladorUnEdificio(int id)
        {
            //var sexo = _context.Sexos.Where(s => s.SexoId == sexoId).ToList();
            var respuesta = (from s in _context.Edificio
                             where s.EdificioId == id
                             select s).ToList();
            return respuesta;
        }

        public List<IdentityError> ControladorEditaCompra(int id, Boolean activo, int estante, int empresa, string imagen)
        {
            return claseCompra.ModeloEditarCompra(id, activo, estante, empresa, imagen);
        }
        public List<IdentityError> ControladorEliminarCompra(int id)
        {
            return claseCompra.ModeloEliminarCompra(id);
        }
        public List<object[]> ContronladorImprimirCompra()
        {
            return claseCompra.ModeloImpresion();
        }
    }
}
