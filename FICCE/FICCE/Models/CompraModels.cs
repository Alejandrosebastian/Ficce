using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FICCE.Data;
using FICCE.Models;

namespace FICCE.Models
{
    public class CompraModels
    {
        private ApplicationDbContext _contexto;

        public CompraModels(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public List<IdentityError> ModeloGrabaCompra(Boolean activo , int estante, int empresa, string imagen)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var Objetocompra = new Compra
            {
                Activo = activo,
                EstantesId = estante,
                EmpresaId = empresa,
                imagen = imagen
            };
            try
            {
                _contexto.Compra.Add(Objetocompra);
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
        public List<object[]> ModeloListaCompra()
        {
            string resultado = "";
            List<object[]> listaresultado = new List<object[]>();
            var compra = (from c in _contexto.Compra
                            join em in _contexto.Empresa on c.EmpresaId equals em.EmpresaId
                            select new
                            {
                                c.Activo,
                                c.CompraId,
                                c.EstantesId,
                                em.Nombre,
                                c.imagen
                            }).OrderBy(c => c.CompraId).ToList();
            foreach (var item in compra)
            {
                resultado += "<tr>" +
                    "<td>" + item.Activo + "</td>" +
                    "<td>" + item.EstantesId + "</td>" +
                    "<td>" + item.Nombre + "</td>" +
                    "<td>" + item.imagen + "</td>" +
                    "<td>" +
                    "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoCompra' onclick='CargaCompra(" + item.CompraId + ")'>Editar</a>" +
                    "<a class='btn btn-info' data-toggle='modal' data-target='#ImpresionCompra' onclick='CargaParaCompra();'>Imprimir</a>" +
                    "<a class='btn btn-danger' onclick='eliminaCompra(" + item.CompraId + ")'>Eliminar</a>" +
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

        public List<IdentityError> ModeloEditarCompra(int id,Boolean activo , int estante, int empresa, string imagen)
        {
            List<IdentityError> ListaEditar = new List<IdentityError>();
            IdentityError regresa = new IdentityError();
            var compra = new Compra
            {
                Activo = activo, 
                EstantesId = estante,
                EmpresaId = empresa,
                imagen = imagen,
                CompraId = id
            };
            try
            {
                _contexto.Compra.Update(compra);
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

        public List<IdentityError> ModeloEliminarCompra(int id)
        {
            List<IdentityError> ListaEliminar = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var compra = new Compra { CompraId = id };
            try
            {
                _contexto.Compra.Remove(compra);
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
            var respuesta = _contexto.Compra.OrderBy(s => s.CompraId).ToList();
            foreach (var item in respuesta)
            {
                dato += "<tr class='info'><td>" + item.Activo + "</td> <td>" + item.CompraId + "</td> <td>" + item.EstantesId + "</td><td>" + item.EmpresaId + "</td><td>" + item.imagen + "</td></tr>";
            }
            object[] objeto = { dato };
            lista.Add(objeto);
            return lista;
        }
    }
}
