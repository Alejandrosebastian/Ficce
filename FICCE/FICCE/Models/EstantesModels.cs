using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FICCE.Models;
using FICCE.Data;

namespace FICCE.Models
{
    public class EstantesModels
    {
        private ApplicationDbContext _contexo;
        private Evento claselistaEvento;
        private Planta claselistaplanta;
        public EstantesModels(ApplicationDbContext contexto)
        {
            _contexo = contexto;
            claselistaEvento = new Evento();
            claselistaplanta = new Planta();
        }
        public List<Evento> ClaseModeloEvento()
        {
            return _contexo.Evento.OrderBy(e => e.Ciudad).ToList();
        }
        public List<Planta> ClasemodeloPLanta()
        {
            return _contexo.Planta.OrderBy(p => p.Nombre).ToList();
        }
        
        public List<IdentityError> ClaseGurdarEstantes(int Ancho, int Largo,string Ubicacion, int Evento, int Planta)
        {
            List<IdentityError> lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var objetoestante = new Estantes
            {
                Ancho = Ancho,
                Largo = Largo,
                Ubicacion = Ubicacion,
                EventoId = Evento,
                PlantaId = Planta
            };
            try
            {
                _contexo.Estantes.Add(objetoestante);
                _contexo.SaveChanges();
                dato = new IdentityError
                {
                    Code = "save",
                    Description = "save"
                };
            }
            catch (Exception ex)
            {
                dato = new IdentityError { 
                Code = ex.Message,
                    Description = ex.Message
            };
        }
            lista.Add(dato);
            return lista;

        }
        public List<object[]> ModeloListaEstante()
        {
            List<object[]> ListaEstante = new List<object[]>();
            var resultado = _contexo.Estantes.ToList();
            var html = "";
            var estan = (from e in _contexo.Estantes
                         select new
                         {
                             e.Ancho,
                             e.Largo,
                             e.Evento,
                             e.Planta,
                             e.EstantesId,
                             e.Ubicacion
                         }).OrderBy(e => e.Ancho).ToList();
            foreach( var item in estan)
            {
                html +="<tr class ='info>"+
                    "<td>"+ item.Ancho+ "</td>" +
                    "<td>" + item.Largo + "</td>" +
                    "<td>" + item.Ubicacion + "</td>" +
                    "<td>" + item.Evento + "</td>" +
                    "<td>" + item.Planta+ "</td>" +
                    
                     "<td>" + "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoInmueble' onclick='CargaEstante(" + item.EstantesId + ")'>Editar</a>"+
                     "</td></tr>";
            }
            object[] dato = { html };
            ListaEstante.Add(dato);
            return ListaEstante;
        }
        public List<IdentityError> ModeloEditarEstante(int Ancho, int Largo, string Ubicacion, int Evento, int Planta,int id)
        {
            List<IdentityError> ListaEditar = new List<IdentityError>();
            IdentityError regresa = new IdentityError();
            var estante = new Estantes
            {
                Ancho = Ancho,
                Largo = Largo,
                Ubicacion = Ubicacion,
                EventoId = Evento,
                PlantaId = Planta,
                EstantesId = id
            };
            try
            {
                _contexo.Estantes.Update(estante);
                _contexo.SaveChanges();
                regresa = new IdentityError
                {
                    Code = "save",
                    Description = "save"
                };
            }
            catch (Exception ex)
            {
                regresa = new IdentityError
                {
                    Code = ex.Message,
                    Description = ex.Message
                };
            }
            ListaEditar.Add(regresa);
            return ListaEditar;
        }

    }
}
