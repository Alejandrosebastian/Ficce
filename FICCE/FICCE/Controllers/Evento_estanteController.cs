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
    public class Evento_estanteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Evento_estanteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Evento_estante
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Evento_estante.Include(e => e.Estantes).Include(e => e.Evento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Evento_estante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento_estante = await _context.Evento_estante
                .Include(e => e.Estantes)
                .Include(e => e.Evento)
                .SingleOrDefaultAsync(m => m.Evento_estanteId == id);
            if (evento_estante == null)
            {
                return NotFound();
            }

            return View(evento_estante);
        }

        // GET: Evento_estante/Create
        public IActionResult Create()
        {
            ViewData["EstantesId"] = new SelectList(_context.Estantes, "EstantesId", "EstantesId");
            ViewData["EventoId"] = new SelectList(_context.Evento, "EventoId", "EventoId");
            return View();
        }

        // POST: Evento_estante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Evento_estanteId,EventoId,EstantesId")] Evento_estante evento_estante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evento_estante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstantesId"] = new SelectList(_context.Estantes, "EstantesId", "EstantesId", evento_estante.EstantesId);
            ViewData["EventoId"] = new SelectList(_context.Evento, "EventoId", "EventoId", evento_estante.EventoId);
            return View(evento_estante);
        }

        // GET: Evento_estante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento_estante = await _context.Evento_estante.SingleOrDefaultAsync(m => m.Evento_estanteId == id);
            if (evento_estante == null)
            {
                return NotFound();
            }
            ViewData["EstantesId"] = new SelectList(_context.Estantes, "EstantesId", "EstantesId", evento_estante.EstantesId);
            ViewData["EventoId"] = new SelectList(_context.Evento, "EventoId", "EventoId", evento_estante.EventoId);
            return View(evento_estante);
        }

        // POST: Evento_estante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Evento_estanteId,EventoId,EstantesId")] Evento_estante evento_estante)
        {
            if (id != evento_estante.Evento_estanteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento_estante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Evento_estanteExists(evento_estante.Evento_estanteId))
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
            ViewData["EstantesId"] = new SelectList(_context.Estantes, "EstantesId", "EstantesId", evento_estante.EstantesId);
            ViewData["EventoId"] = new SelectList(_context.Evento, "EventoId", "EventoId", evento_estante.EventoId);
            return View(evento_estante);
        }

        // GET: Evento_estante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento_estante = await _context.Evento_estante
                .Include(e => e.Estantes)
                .Include(e => e.Evento)
                .SingleOrDefaultAsync(m => m.Evento_estanteId == id);
            if (evento_estante == null)
            {
                return NotFound();
            }

            return View(evento_estante);
        }

        // POST: Evento_estante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento_estante = await _context.Evento_estante.SingleOrDefaultAsync(m => m.Evento_estanteId == id);
            _context.Evento_estante.Remove(evento_estante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Evento_estanteExists(int id)
        {
            return _context.Evento_estante.Any(e => e.Evento_estanteId == id);
        }
    }
}
