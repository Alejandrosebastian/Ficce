using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FICCE.Data;
using FICCE.Models;

namespace FICCE.Controllers
{
    public class TipoempresasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoempresasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tipoempresas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipoempresa.ToListAsync());
        }

        // GET: Tipoempresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoempresa = await _context.Tipoempresa
                .SingleOrDefaultAsync(m => m.TipoempresaId == id);
            if (tipoempresa == null)
            {
                return NotFound();
            }

            return View(tipoempresa);
        }

        // GET: Tipoempresas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipoempresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoempresaId,Nombre,Detalle")] Tipoempresa tipoempresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoempresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoempresa);
        }

        // GET: Tipoempresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoempresa = await _context.Tipoempresa.SingleOrDefaultAsync(m => m.TipoempresaId == id);
            if (tipoempresa == null)
            {
                return NotFound();
            }
            return View(tipoempresa);
        }

        // POST: Tipoempresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoempresaId,Nombre,Detalle")] Tipoempresa tipoempresa)
        {
            if (id != tipoempresa.TipoempresaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoempresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoempresaExists(tipoempresa.TipoempresaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoempresa);
        }

        // GET: Tipoempresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoempresa = await _context.Tipoempresa
                .SingleOrDefaultAsync(m => m.TipoempresaId == id);
            if (tipoempresa == null)
            {
                return NotFound();
            }

            return View(tipoempresa);
        }

        // POST: Tipoempresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoempresa = await _context.Tipoempresa.SingleOrDefaultAsync(m => m.TipoempresaId == id);
            _context.Tipoempresa.Remove(tipoempresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoempresaExists(int id)
        {
            return _context.Tipoempresa.Any(e => e.TipoempresaId == id);
        }
    }
}
