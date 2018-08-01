using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FICCE.Data;
using FICCE.Models;

namespace FICCE.Models
{
    public class EmpleadoModels
    {
        private ApplicationDbContext _contexto;

        public EmpleadoModels(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public List<IdentityError> ModeloGrabaEmpleado(int empresa, string nombre,string apellido,string correo,string telefono_contacto, string telefono_movil, string direccion)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var Objetoempleado = new Empleado
            {
                EmpresaId = empresa,
                Nombre = nombre,
                Apellido = apellido,
                Correo = correo,
                Telefono_convencional = telefono_contacto,
                telefono_movil = telefono_movil,
                direccion = direccion
            };
            try
            {
                _contexto.Empleado.Add(Objetoempleado);
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
        public List<object[]> ModeloListaEmpleado()
        {
            string resultado = "";
            List<object[]> listaresultado = new List<object[]>();
            var edificio = (from e in _contexto.Empleado
                            join em in _contexto.Empresa on e.EmpresaId equals em.EmpresaId
                            select new
                            {
                                e.EmpleadoId,
                                em.EmpresaId,
                                e.Nombre,
                                e.Apellido,
                                e.Correo,
                                e.Telefono_convencional,
                                e.telefono_movil,
                                e.direccion
                            }).OrderBy(e => e.Apellido).ToList();
            foreach (var item in edificio)
            {
                resultado += "<tr>" +
                    "<td>" + item.Nombre + "</td>" +
                    "<td>" + item.Apellido + "</td>" +
                    "<td>" + item.Correo + "</td>" +
                    "<td>" + item.Telefono_convencional + "</td>" +
                    "<td>" + item.telefono_movil + "</td>" +
                    "<td>" + item.direccion+ "</td>" +
                    "<td>" + item.EmpresaId + "</td>" +
                    "<td>" +
                    "<a class='btn btn-success' data-toggle='modal' data-target='#IngresoEmpresa' onclick='CargaEmpresa(" + item.EmpleadoId + ")'>Editar</a>" +
                    "<a class='btn btn-info' data-toggle='modal' data-target='#ImpresionEmpresa' onclick='CargaParaImpresion();'>Imprimir</a>" +
                    "<a class='btn btn-danger' onclick='eliminaEdificio(" + item.EmpleadoId + ")'>Eliminar</a>" +
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

        public List<IdentityError> ModeloEditarEmpleado(int id, int empresa, string nombre, string apellido, string correo, string telefono_contacto, string telefono_movil, string direccion)
        {
            List<IdentityError> ListaEditar = new List<IdentityError>();
            IdentityError regresa = new IdentityError();
            var empre = new Empleado
            {
                EmpresaId = empresa,
                Nombre = nombre,
                Apellido = apellido,
                Correo = correo,
                Telefono_convencional = telefono_contacto,
                telefono_movil = telefono_movil,
                direccion = direccion,
                EmpleadoId = id
            };
            try
            {
                _contexto.Empleado.Update(empre);
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

        public List<IdentityError> ModeloEliminarEmpleado(int id)
        {
            List<IdentityError> ListaEliminar = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var empleado = new Empleado { EmpleadoId = id };
            try
            {
                _contexto.Empleado.Remove(empleado);
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
            var respuesta = _contexto.Empleado.OrderBy(s => s.Nombre).ToList();
            foreach (var item in respuesta)
            {
                dato += "<tr class='info'><td>" + item.EmpleadoId + "</td> <td>" + item.Nombre + "</td><td>" + item.Apellido + "</td><td>" + item.direccion + "</td><td>" + item.Correo + "</td><td>" + item.Telefono_convencional + "</td><td>" + item.telefono_movil + "</td><td>" + item.EmpresaId + "</td></tr>";
            }
            object[] objeto = { dato };
            lista.Add(objeto);
            return lista;
        }
    }
}
