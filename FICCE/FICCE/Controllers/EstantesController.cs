﻿using System;
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
    public class EstantesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private EstantesModels claseEstantes;

        public EstantesController(ApplicationDbContext context)
        {
            _context = context;
            claseEstantes = new EstantesModels(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Evento.ToListAsync());
        }

        public List<IdentityError> ControladorGuardaEstantes(int Ancho, int Largo, string Ubicacion, int Evento, int Planta)
        {
            return claseEstantes.ClaseGurdarEstantes(Ancho,Largo, Ubicacion, Evento,Planta);
        }

        public List<object[]> ControladorListaEstantes()
        {
            return claseEstantes.ModeloListaEstante();
        }
        public List<Evento> ControladorUnEvento(int id)
        {
            //var sexo = _context.Sexos.Where(s => s.SexoId == sexoId).ToList();
            var res = (from s in _context.Evento
                       where s.EventoId == id
                       select s).ToList();
            return res;
        }

        public List<IdentityError> ControladorEditaEstantes(int id, int Ancho, int Largo, string Ubicacion, int Evento, int Planta)
        {
            return claseEstantes.ModeloEditarEstante(Ancho, Largo, Ubicacion, Evento, Planta,id);
        }
        //public List<IdentityError> ControladorEliminarEvento(int id)
        //{
        //    return claseEstantes.ModeloEliminarEvento(id);
        //}
        //public List<object[]> ContronladorImprimirEvento()
        //{
        //    return claseEstantes.ModeloImpresion();
        //}
    }
}

