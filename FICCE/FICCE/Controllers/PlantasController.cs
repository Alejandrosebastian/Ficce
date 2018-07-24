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
    public class PlantasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlantasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plantas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Planta.Include(p => p.Edificio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Plantas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planta = await _context.Planta
                .Include(p => p.Edificio)
                .SingleOrDefaultAsync(m => m.PlantaId == id);
            if (planta == null)
            {
                return NotFound();
            }

            return View(planta);
        }

        // GET: Plantas/Create
        public IActionResult Create()
        {
            ViewData["EdificioId"] = new SelectList(_context.Edificio, "EdificioId", "Nombre");
            return View();
        }

        // POST: Plantas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlantaId,Nombre,EdificioId")] Planta planta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EdificioId"] = new SelectList(_context.Edificio, "EdificioId", "Nombre", planta.EdificioId);
            return View(planta);
        }

        // GET: Plantas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planta = await _context.Planta.SingleOrDefaultAsync(m => m.PlantaId == id);
            if (planta == null)
            {
                return NotFound();
            }
            ViewData["EdificioId"] = new SelectList(_context.Edificio, "EdificioId", "Nombre", planta.EdificioId);
            return View(planta);
        }

        // POST: Plantas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlantaId,Nombre,EdificioId")] Planta planta)
        {
            if (id != planta.PlantaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantaExists(planta.PlantaId))
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
            ViewData["EdificioId"] = new SelectList(_context.Edificio, "EdificioId", "Nombre", planta.EdificioId);
            return View(planta);
        }

        // GET: Plantas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planta = await _context.Planta
                .Include(p => p.Edificio)
                .SingleOrDefaultAsync(m => m.PlantaId == id);
            if (planta == null)
            {
                return NotFound();
            }

            return View(planta);
        }

        // POST: Plantas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planta = await _context.Planta.SingleOrDefaultAsync(m => m.PlantaId == id);
            _context.Planta.Remove(planta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantaExists(int id)
        {
            return _context.Planta.Any(e => e.PlantaId == id);
        }
    }
}
