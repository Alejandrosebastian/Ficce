using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FICCE.Data;
using FICCE.Models;

namespace FICCE.Models
{
    public class EmpresaModels
    {
        private ApplicationDbContext _contexto;

        public EmpresaModels(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public List<IdentityError> ModeloGrabaEmpresa(int tipo, string nombre, string direccion,string correo,string persono,string contacto,string convencional, string extencion)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var Objetoempresa = new Empresa
            {
                TipoempresaId = tipo,
                Nombre = nombre,
                direccion = direccion,
                correo = correo,
                persona_responsable = persono,
                telefono_contacto = contacto,
                telefono_convencional = convencional,
                extenencion_telefono = extencion
            };
            try
            {
                _contexto.Empresa.Add(Objetoempresa);
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
        public List<object[]> ModeloListaEmpresa()
        {
            string resultado = "";
            List<object[]> listaresultado = new List<object[]>();
            var empresa = (from e in _contexto.Empresa
                            join t in _contexto.Tipoempresa on e.TipoempresaId equals t.TipoempresaId
                            select new
                            {
                                e.EmpresaId,
                                e.Nombre,
                                e.direccion,
                                e.correo,
                                e.persona_responsable,
                                e.telefono_contacto,
                                e.extenencion_telefono,
                                e.telefono_convencional,
                                t.Detalle
                            }).OrderBy(e => e.Nombre).ToList();
            foreach (var item in empresa)
            {
                resultado += "<tr>" +
                    "<td>" + item.Nombre + "</td>" +
                    "<td>" + item.direccion + "</td>" +
                    "<td>" + item.correo + "</td>" +
                    "<td>" + item.persona_responsable + "</td>" +
                    "<td>" + item.telefono_convencional + "</td>" +
                    "<td>" + item.extenencion_telefono + "</td>" +
                    "<td>" + item.telefono_contacto + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" +
                    "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoEmpresa' onclick='CargaEmpresa(" + item.EmpresaId + ")'>Editar</a>" +
                    "<a class='btn btn-info' data-toggle='modal' data-target='#ImpresionEmpresa' onclick='CargaParaImpresionEmpresa();'>Imprimir</a>" +
                    "<a class='btn btn-danger' onclick='eliminaEdificio(" + item.EmpresaId + ")'>Eliminar</a>" +
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

        public List<IdentityError> ModeloEditarEmpresa(int id, int tipo, string nombre, string direccion, string correo, string persono, string contacto, string convencional, string extencion)
        {
            List<IdentityError> ListaEditar = new List<IdentityError>();
            IdentityError regresa = new IdentityError();
            var empresa = new Empresa
            {
                TipoempresaId = tipo,
                Nombre = nombre,
                direccion = direccion,
                correo = correo,
                persona_responsable = persono,
                telefono_contacto = contacto,
                telefono_convencional = convencional,
                extenencion_telefono = extencion,
                EmpresaId = id
            };
            try
            {
                _contexto.Empresa.Update(empresa);
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

        public List<IdentityError> ModeloEliminarEmpresa(int id)
        {
            List<IdentityError> ListaEliminar = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var empresa = new Empresa { EmpresaId = id };
            try
            {
                _contexto.Empresa.Remove(empresa);
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
            var respuesta = _contexto.Empresa.OrderBy(s => s.Nombre).ToList();
            foreach (var item in respuesta)
            {
                dato += "<tr class='info'><td>" + item.EmpresaId + "</td> <td>" + item.Nombre + "</td><td>" + item.direccion + "</td><td>" + item.correo + "</td><td>" + item.persona_responsable + "</td><td>" + item.telefono_convencional + "</td><td>" + item.extenencion_telefono + "</td><td>" + item.telefono_contacto + "</td><td>" + item.TipoempresaId + "</td></tr>";
            }
            object[] objeto = { dato };
            lista.Add(objeto);
            return lista;
        }
    }
}
