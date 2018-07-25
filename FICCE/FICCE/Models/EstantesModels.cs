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
        public EstantesModels(ApplicationDbContext contexto)
        {
            _contexo = contexto;
        }
        public List<IdentityError> ClaseGurdarEstantes(int Ancho, int Largo, int Evento, int Planta)
        {
            List<IdentityError> lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var objetoestante = new Estantes
            {
                Ancho = Ancho,
                Largo = Largo,
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
                             e.EstantesId
                         }).OrderBy(e => e.Ancho).ToList();
            foreach( var item in estan)
            {
                html +="<tr class ='info>"+
                    "<td>"+ item.Ancho+ "</td>" +
                    "<td>" + item.Largo + "</td>" +
                    "<td>" + item.Evento + "</td>" +
                    "<td>" + item.Planta+ "</td>" +
                     "<td>" + "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoInmueble' onclick='CargaEstante(" + item.EstantesId + ")'>Editar</a>"+
                     "</td></tr>";
            }
            object[] dato = { html };
            ListaEstante.Add(dato);
            return ListaEstante;
        }
      

    }
}
