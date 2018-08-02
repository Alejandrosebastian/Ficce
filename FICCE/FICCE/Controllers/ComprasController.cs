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
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace FICCE.Controllers
{
    public class ComprasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private CompraModels claseCompra;

        private readonly IHostingEnvironment _appEnvironment;

        public ComprasController(ApplicationDbContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            claseCompra = new CompraModels(context);
            _appEnvironment = appEnvironment;
        }

        // GET: Sexos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Compra.ToListAsync());
        }
        public async Task<IActionResult> Upload_Image(IFormFile file)

        {

            if (file == null || file.Length == 0) return Content("file not selected");

            string path_Root = _appEnvironment.WebRootPath;
            string path_to_Images = path_Root + "\\Images\\" + file.FileName;

            using (var stream = new FileStream(path_to_Images, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            ViewData["FilePath"] = path_to_Images;
            return View();

            //para obtener nombre file.filename

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

