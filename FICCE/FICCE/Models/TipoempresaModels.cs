using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using FICCE.Data;
using FICCE.Models;

namespace FICCE.Models
{
    public class TipoempresaModels
    {
        private ApplicationDbContext _contexto;
        public TipoempresaModels(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<IdentityError> ModeloGuardatipoempres(string Detalle, string Nombre)
        {
            List<IdentityError> lista = new List<IdentityError>();
            IdentityError datos = new IdentityError();
            var objetotipoempre = new Tipoempresa
            {
                Detalle = Detalle,
                Nombre = Nombre
            };
            try
            {
                _contexto.Tipoempresa.Add(objetotipoempre);
                _contexto.SaveChanges();
                datos = new IdentityError
                {
                    Code = "save",
                    Description = "save"
                };
            }
            catch (Exception ex)
            {
                datos = new IdentityError
                {
                    Code = ex.Message,
                    Description = ex.Message
                };
                
            }
            lista.Add(datos);
            return lista;
        }
        public List<object[]> ModeloListatipoempresa()
        {
            List<object[]> listatipoempresa = new List<object[]>();
            var resultado = _contexto.Tipoempresa.ToList();
            string html = "";
            foreach (var item in resultado)
            {
                html +="<tr>"+
                    "<td>"+ item.Detalle +"</td>"+
                    "<td>" + item.Nombre + "</td>" +

            }
        }

    }
}
