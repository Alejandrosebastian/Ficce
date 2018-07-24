﻿using System;
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
    public class EstantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estantes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Estantes.Include(e => e.Evento).Include(e => e.Planta);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Estantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estantes = await _context.Estantes
                .Include(e => e.Evento)
                .Include(e => e.Planta)
                .SingleOrDefaultAsync(m => m.EstantesId == id);
            if (estantes == null)
            {
                return NotFound();
            }

            return View(estantes);
        }

        // GET: Estantes/Create
        public IActionResult Create()
        {
<<<<<<< HEAD
            ViewData["EventoId"] = new SelectList(_context.Evento, "EventoId", "EventoId");
            ViewData["PlantaId"] = new SelectList(_context.Planta, "PlantaId", "Nombre");
=======
            ViewData["EventoId"] = new SelectList(_context.Set<Evento>(), "EventoId", "EventoId");
            ViewData["PlantaId"] = new SelectList(_context.Set<Planta>(), "PlantaId", "PlantaId");
>>>>>>> 10c4f1ce8e6330c4e774a2daa4b01eff97f1bd60
            return View();
        }

        // POST: Estantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<IActionResult> Create([Bind("EstantesId,Ancho,Largo,EventoId,PlantaId")] Estantes estantes)
=======
        public async Task<IActionResult> Create([Bind("EstantesId,NumeroEstan,LargoAncho,EventoId,PlantaId")] Estantes estantes)
>>>>>>> 10c4f1ce8e6330c4e774a2daa4b01eff97f1bd60
        {
            if (ModelState.IsValid)
            {
                _context.Add(estantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
<<<<<<< HEAD
            ViewData["EventoId"] = new SelectList(_context.Evento, "EventoId", "EventoId", estantes.EventoId);
            ViewData["PlantaId"] = new SelectList(_context.Planta, "PlantaId", "Nombre", estantes.PlantaId);
=======
            ViewData["EventoId"] = new SelectList(_context.Set<Evento>(), "EventoId", "EventoId", estantes.EventoId);
            ViewData["PlantaId"] = new SelectList(_context.Set<Planta>(), "PlantaId", "PlantaId", estantes.PlantaId);
>>>>>>> 10c4f1ce8e6330c4e774a2daa4b01eff97f1bd60
            return View(estantes);
        }

        // GET: Estantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estantes = await _context.Estantes.SingleOrDefaultAsync(m => m.EstantesId == id);
            if (estantes == null)
            {
                return NotFound();
            }
<<<<<<< HEAD
            ViewData["EventoId"] = new SelectList(_context.Evento, "EventoId", "EventoId", estantes.EventoId);
            ViewData["PlantaId"] = new SelectList(_context.Planta, "PlantaId", "Nombre", estantes.PlantaId);
=======
            ViewData["EventoId"] = new SelectList(_context.Set<Evento>(), "EventoId", "EventoId", estantes.EventoId);
            ViewData["PlantaId"] = new SelectList(_context.Set<Planta>(), "PlantaId", "PlantaId", estantes.PlantaId);
>>>>>>> 10c4f1ce8e6330c4e774a2daa4b01eff97f1bd60
            return View(estantes);
        }

        // POST: Estantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<IActionResult> Edit(int id, [Bind("EstantesId,Ancho,Largo,EventoId,PlantaId")] Estantes estantes)
=======
        public async Task<IActionResult> Edit(int id, [Bind("EstantesId,NumeroEstan,LargoAncho,EventoId,PlantaId")] Estantes estantes)
>>>>>>> 10c4f1ce8e6330c4e774a2daa4b01eff97f1bd60
        {
            if (id != estantes.EstantesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstantesExists(estantes.EstantesId))
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
<<<<<<< HEAD
            ViewData["EventoId"] = new SelectList(_context.Evento, "EventoId", "EventoId", estantes.EventoId);
            ViewData["PlantaId"] = new SelectList(_context.Planta, "PlantaId", "Nombre", estantes.PlantaId);
=======
            ViewData["EventoId"] = new SelectList(_context.Set<Evento>(), "EventoId", "EventoId", estantes.EventoId);
            ViewData["PlantaId"] = new SelectList(_context.Set<Planta>(), "PlantaId", "PlantaId", estantes.PlantaId);
>>>>>>> 10c4f1ce8e6330c4e774a2daa4b01eff97f1bd60
            return View(estantes);
        }

        // GET: Estantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estantes = await _context.Estantes
                .Include(e => e.Evento)
                .Include(e => e.Planta)
                .SingleOrDefaultAsync(m => m.EstantesId == id);
            if (estantes == null)
            {
                return NotFound();
            }

            return View(estantes);
        }

        // POST: Estantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estantes = await _context.Estantes.SingleOrDefaultAsync(m => m.EstantesId == id);
            _context.Estantes.Remove(estantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstantesExists(int id)
        {
            return _context.Estantes.Any(e => e.EstantesId == id);
        }
    }
}
