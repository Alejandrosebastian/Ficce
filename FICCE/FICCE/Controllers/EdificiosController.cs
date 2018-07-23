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
    public class EdificiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EdificiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Edificios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Edificio.Include(e => e.Evento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Edificios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edificio = await _context.Edificio
                .Include(e => e.Evento)
                .SingleOrDefaultAsync(m => m.EdificioId == id);
            if (edificio == null)
            {
                return NotFound();
            }

            return View(edificio);
        }

        // GET: Edificios/Create
        public IActionResult Create()
        {
            ViewData["EventoId"] = new SelectList(_context.Set<Evento>(), "EventoId", "EventoId");
            return View();
        }

        // POST: Edificios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EdificioId,Nombre,Ubicacion,EventoId")] Edificio edificio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(edificio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoId"] = new SelectList(_context.Set<Evento>(), "EventoId", "EventoId", edificio.EventoId);
            return View(edificio);
        }

        // GET: Edificios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edificio = await _context.Edificio.SingleOrDefaultAsync(m => m.EdificioId == id);
            if (edificio == null)
            {
                return NotFound();
            }
            ViewData["EventoId"] = new SelectList(_context.Set<Evento>(), "EventoId", "EventoId", edificio.EventoId);
            return View(edificio);
        }

        // POST: Edificios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EdificioId,Nombre,Ubicacion,EventoId")] Edificio edificio)
        {
            if (id != edificio.EdificioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(edificio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EdificioExists(edificio.EdificioId))
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
            ViewData["EventoId"] = new SelectList(_context.Set<Evento>(), "EventoId", "EventoId", edificio.EventoId);
            return View(edificio);
        }

        // GET: Edificios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edificio = await _context.Edificio
                .Include(e => e.Evento)
                .SingleOrDefaultAsync(m => m.EdificioId == id);
            if (edificio == null)
            {
                return NotFound();
            }

            return View(edificio);
        }

        // POST: Edificios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var edificio = await _context.Edificio.SingleOrDefaultAsync(m => m.EdificioId == id);
            _context.Edificio.Remove(edificio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EdificioExists(int id)
        {
            return _context.Edificio.Any(e => e.EdificioId == id);
        }
    }
}
