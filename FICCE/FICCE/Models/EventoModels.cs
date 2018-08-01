using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FICCE.Data;
using FICCE.Models;

namespace FICCE.Models
{
    public class EventoModels
    {
        private ApplicationDbContext _contexto;

        public EventoModels(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public List<IdentityError> ModeloGrabaEvento(string ciudad, DateTime fecha_ini, DateTime fecha_fin, int valor)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var Objetoedificio = new Evento
            {
                Ciudad = ciudad,
                dia_fin = fecha_ini,
                dia_inicio = fecha_ini,
                precio_estan = valor
            };
            try
            {
                _contexto.Evento.Add(Objetoedificio);
                _contexto.SaveChanges();
                dato = new IdentityError
                {
                    Code = "save",
                    Description = "save"
                };
            }
            catch (Exception ex)
            {
                dato = new IdentityError
                {
                    Code = ex.Message,
                    Description = ex.Message
                };
            }
            Lista.Add(dato);
            return Lista;

        }
        public List<object[]> ModeloListaEvento()
        {
            string resultado = "";
            List<object[]> listaresultado = new List<object[]>();
            var evento = (from e in _contexto.Evento
                            select new
                            {
                                e.Ciudad,
                                e.dia_inicio,
                                e.dia_fin,
                                e.precio_estan,
                                e.EventoId
                            }).OrderBy(e => e.Ciudad).ToList();
            foreach (var item in evento)
            {
                resultado += "<tr>" +
                    "<td>" + item.Ciudad + "</td>" +
                    "<td>" + item.dia_inicio + "</td>" +
                    "<td>" + item.dia_fin + "</td>" +
                    "<td>" + item.precio_estan + "</td>" +
                    "<td>" +
                    "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoEvento' onclick='CargaEdificio(" + item.EventoId + ")'>Editar</a>" +
                    "<a class='btn btn-info' data-toggle='modal' data-target='#ImpresionEvento' onclick='CargaParaImpresionEvento();'>Imprimir</a>" +
                    "<a class='btn btn-danger' onclick='eliminaEvento(" + item.EventoId + ")'>Eliminar</a>" +
                    "</td>"
                    + "</tr>";
            }
            object[] datos = { resultado };
            listaresultado.Add(datos);
            return listaresultado;
        }
        //{
        //    int count = 0, cant, numRegistros = 0, inicio = 0;
        //    int registro_por_pagina = 2, can_paginas,pagina;
        //    string dataFilter = "", paginador = "";
        //    IEnumerable<Sexo> query;
        //    List<Sexo> sexo = null;
        //    switch (orden)
        //    {
        //        case "az":
        //            sexo = _contexto.Sexos.OrderBy(s => s.Detalle).ToList();
        //            break;
        //        case "za":
        //            sexo = _contexto.Sexos.OrderByDescending(s => s.Detalle).ToList();
        //            break;
        //    }
        //    numRegistros = sexo.Count;
        //    inicio = (numeropagina - 1) * registro_por_pagina;
        //    can_paginas = (numRegistros / registro_por_pagina);
        //    if(valor == "null")
        //    {
        //        query = sexo.Skip(inicio).Take(registro_por_pagina);
        //    }
        //    else
        //    {
        //        query = sexo.Where(s => s.Detalle.StartsWith(valor)).Take(registro_por_pagina);
        //        //cadena =cliente.where(c=> c.nombre.StarWith(valor)
        //        // || c.Apellido.starwith(valor) || c.Direccion.starwith(valor)).skip(inicio).take(registro);
        //    }
        //    cant = query.Count();
        //    List<object[]> ListaSexos = new List<object[]>();
        //    var resultado = _contexto.Sexos.ToList();
        //    //var resultado = from s in _contexto.Sexos select s;
        //    //var resultado = from s in _contexto.Sexos select new { s.Detalle, s.SexoId };
        //    var html = "";
        //    foreach (var item in query)
        //    {
        //        html += "<tr class='info'>" +
        //            "<td>" + item.Detalle + "</td>" +
        //            "<td>" + "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoSexos' onclick='CargaSexo(" + item.SexoId + ")'>Editar</a>" +
        //            "<a class='btn btn-info' data-toggle='modal' data-target='#ImpresionSexos' onclick='CargaParaImpresion();'>Imprimir</a>" +
        //            "<a class='btn btn-danger' onclick='eliminaSexo(" + item.SexoId + ")'>Eliminar</a>" +

        //            "</td></tr>";
        //    }
        //    if (valor == "null")
        //    {
        //        if (numeropagina > 1)
        //        {
        //            pagina = numeropagina + 1;
        //            paginador += "<a class='btn btn-default onclick = 'ListaSexos(" + 1 + "," + '"' + orden + '"' + ")'><<<</a>" + '< a class="btn btn-default" onclick="ListaSexo(' + pagina + ",'',orden"')"><</a>';
        //        }
        //    }
        //    object[] dato = { html };
        //    ListaSexos.Add(dato);
        //    return ListaSexos;
        //}

        public List<IdentityError> ModeloEditarEvento(int id, string ciudad, DateTime fecha_ini, DateTime fecha_fin, int valor)
        {
            List<IdentityError> ListaEditar = new List<IdentityError>();
            IdentityError regresa = new IdentityError();
            var evento = new Evento
            {
                Ciudad = ciudad,
                dia_fin = fecha_fin,
                dia_inicio = fecha_ini,
                precio_estan = valor,
                EventoId = id
            };
            try
            {
                _contexto.Evento.Update(evento);
                _contexto.SaveChanges();
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

        public List<IdentityError> ModeloEliminarEvento(int id)
        {
            List<IdentityError> ListaEliminar = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var evento = new Evento { EventoId = id };
            try
            {
                _contexto.Evento.Remove(evento);
                _contexto.SaveChanges();
                dato = new IdentityError
                {
                    Code = "Save",
                    Description = "Save"
                };
            }
            catch (Exception ex)
            {
                dato = new IdentityError
                {
                    Code = ex.Message,
                    Description = ex.Message
                };
            }
            ListaEliminar.Add(dato);
            return ListaEliminar;
        }
        public List<object[]> ModeloImpresion()
        {
            List<object[]> lista = new List<object[]>();
            string dato = "";
            var respuesta = _contexto.Evento.OrderBy(s => s.Ciudad).ToList();
            foreach (var item in respuesta)
            {
                dato += "<tr class='info'><td>" + item.Ciudad + "</td> <td>" + item.dia_inicio + "</td><td>" + item.dia_fin + "</td><td>"+ item.precio_estan+"</td></tr>";
            }
            object[] objeto = { dato };
            lista.Add(objeto);
            return lista;
        }
    }
}
