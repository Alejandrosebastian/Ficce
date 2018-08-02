// Write your JavaScript code.
$().ready(() => {
    //mostrardatosjs();
    // listaClientes(1,'null');
    //ListaEdificio();
    ListaPlanta();
    ListaEvento();
    ListaEmpresa();
    ListaEmpleado();
    //SiteListaIndex(1);
});
var Guardaestante = () => {
    var Ancho = document.getElementById('Ancho').value;
    var Largo = docuement.getElementById('Largo').value;
    var Eventos = document.getElementById('EventoId');
    var Evento = Eventos.options[formulas.selectdIndex].value;
    var Planta = document.getElementById('Planta').valuel;
    var EstanteId = docuemnt.getElementById('Id').valuel;

    if (EstanteId == '') {
        EstanteId == 0;
        var accion = 'Estantes/ControladorGuardaEstantes';

    } else {
        var accion = 'Estantes/ControladorGuardaEstantes';
    }
    var graba = new ClaseEstante(Ancho, Largo, Evento, Planta, accion);
    graba.Guardaestante(EstanteId)
}


var grabaEdificio = () => {
    var evento = document.getElementById('evento').value;
    var nombre = document.getElementById('nombre').value;
    var ubicacion = document.getElementById('ubicacion').value;
    var id = document.getElementById('id').value;


    if (id == '') {
        id == 0;
        var accion = 'Edificios/ControladorGuardaEdificio';
    }
    else {
        var accion = 'Edificios/ControladorEditaEdificio';
    }
    var graba = new ClaseEdificio(evento,nombre,ubicacion,'', accion);
    graba.GuardarEdificio(id);
}
var grabaTipoempresa = () => {
    var Nombre = document.getElementById('Nombre').value;
    var Detalle = document.getElementById('Detalle').value;
    var TipoempresaId = document.getElementById('TipoempresaId').value;
    var accion = 'Tipoempresa/Controladorguardatipoempresa';
    var graba = new  Clasetipoempresa(Nombre, Detalle, accion);
    if (TipoempresaId == '') {
        TipoempresaId = '0';
        var accion = 'Tipoempresas/Controladorguardatipoempresa';
    } else {
        var accion = 'Tipoempresas/Controladorguardatipoempresa';
    }
    var graba = new Clasetipoempresa(Nombre, Detalle, accion);
    graba.Guardatipoempresa(TipoempresaId);

}
var Listatipoempresa = () => {
    var accion = 'Tipoempresas/Controladorlistatipo';
    var Estantes = new Clasetipoempresa('', '', accion);
    Estantes.listatipoempresa();
}

var ListaEdificio = () => {
    var accion = 'Edificios/ControladorListaEdificio';
    var sexo = new ClaseEdificio('','','','', accion);
    sexo.ListadeEdificio();
}
var CargaEdificio = (id) => {
    var accion = 'Edificios/ControladorUnEdificio';
    var unsexo = new ClaseEdificio('','','','', accion);
    unsexo.CargarEdificio(id);
}
var eliminaSexo = (id) => {
    var accion = 'Edificios/ControladorEliminarEdificio';
    var eliminaedificio = new ClaseEdificio('','','','', accion);
    var res = confirm('Desea eliminar el registro');
    if (res == true) {
        eliminaEdificio.EliminarEdificio(id);
        alert('registro eliminado');
    } else { alert('usted canselo la elimnacion del registro'); }
}
var CargaParaImpresionEdificio = () => {
    var accion = 'Edificios/ContronladorImprimirEdificio';
    var carga = new ClaseEdificio('','','','', accion);
    carga.ImprimirEdificio();

}
var Impresion = () => {
    var contenido = document.getElementById('areaImprimir').innerHTML;
    var contenidooriginial = document.body.innerHTML;
    document.body.innerHTML = contenido;
    window.print();
}

var listaestantes = () => {
    var accion = 'Estantes/'
}

var grabaEvento = () => {
    var ciudad = document.getElementById('ciudad').value;
    var fecha_ini = document.getElementById('inicio').value;
    var fecha_fin = document.getElementById('fin').value;
    var valor = document.getElementById('valor').value;
    var id = document.getElementById('id').value;


    if (id == '') {
        id == 0;
        var accion = 'Eventos/ControladorGuardaEvento';
    }
    else {
        var accion = 'Eventos/ControladorEditaEvento';
    }
    var graba = new ClaseEvento(ciudad, fecha_ini, fecha_fin, valor, '', accion);
    graba.GuardarEvento(id);
}

var ListaEvento = () => {
    var accion = 'Eventos/ControladorListaEvento';
    var sexo = new ClaseEvento('', '', '', '', '', accion);
    sexo.ListadeEvento();
}
var CargaEvento = (id) => {
    var accion = 'Eventos/ControladorUnEvento';
    var unsexo = new ClaseEvento('', '', '', '', '', accion);
    unsexo.CargarEvento(id);
}
var eliminaEvento = (id) => {
    var accion = 'Eventos/ControladorEliminarEdificio';
    var eliminaedificio = new ClaseEdificio('', '', '', '', '', accion);
    var res = confirm('Desea eliminar el registro');
    if (res == true) {
        eliminaEvento.EliminarEvento(id);
        alert('registro eliminado');
    } else { alert('usted canselo la elimnacion del registro'); }
}
var CargaParaImpresionEvento = () => {
    var accion = 'Eventos/ContronladorImprimirEdificio';
    var carga = new ClaseEvento('', '', '', '', '', accion);
    carga.ImprimirEvento();

}
var grabaPlanta = () => {
    var edificio = document.getElementById('edificio').value;
    var nombre = document.getElementById('nombre').value;
    var id = document.getElementById('id').value;


    if (id == '') {
        id == 0;
        var accion = 'Plantas/ControladorGuardaPlanta';
    }
    else {
        var accion = 'Plantas/ControladorEditaPlanta';
    }
    var graba = new ClasePlanta(edificio, nombre, '', accion);
    graba.GuardarPlanta(id);
}

var ListaPlanta = () => {
    var accion = 'Plantas/ControladorListaPlanta';
    var sexo = new ClasePlanta('', '', '', accion);
    sexo.ListadePlanta();
}
var CargaPlanta = (id) => {
    var accion = 'Plantas/ControladorUnPlanta';
    var unsexo = new ClasePlanta('', '', '', accion);
    unsexo.CargarPlanta(id);
}
var eliminaPlanta = (id) => {
    var accion = 'Plantas/ControladorEliminarPlanta';
    var eliminaPlanta = new ClasePlanta('', '', '', accion);
    var res = confirm('Desea eliminar el registro');
    if (res == true) {
        eliminaPlanta.EliminarPlanta(id);
        alert('registro eliminado');
    } else { alert('usted canselo la elimnacion del registro'); }
}
var CargaParaImpresionPlanta = () => {
    var accion = 'Plantas/ContronladorImprimirPlanta';
    var carga = new ClasePlanta('', '', '', accion);
    carga.ImprimirPlanta();

}
var grabaEmpresa = () => {
    var tipo = document.getElementById('tipo').value;
    var direccion = document.getElementById('direccion').value;
    var nombre = document.getElementById('nombre').value;
    var correo = document.getElementById('correo').value;
    var persono = document.getElementById('persono').value;
    var contacto = document.getElementById('contacto').value;
    var convencional = document.getElementById('convencional').value;
    var extencion = document.getElementById('extencion').value;
    var id = document.getElementById('id').value;


    if (id == '') {
        id == 0;
        var accion = 'Empresas/ControladorGuardaEmpresa';
    }
    else {
        var accion = 'Empresas/ControladorEditaEmpresa';
    }
    var graba = new ClaseEmpresa(tipo, nombre, direccion, correo, persono, contacto, convencional, extencion, '', accion);
    graba.GuardarEmpresa(id);
}

var ListaEmpresa = () => {
    var accion = 'Empresas/ControladorListaEmpresa';
    var sexo = new ClaseEmpresa('', '', '', '', '', '', '', '', '', accion);
    sexo.ListadeEmpresa();
}
var CargaEmpresa = (id) => {
    var accion = 'Empresas/ControladorUnEmpresa';
    var unsexo = new ClaseEmpresa('', '', '', '', '', '', '', '', '', accion);
    unsexo.CargarEmpresa(id);
}
var eliminaEmpresa = (id) => {
    var accion = 'Edificios/ControladorEliminarEmpresa';
    var eliminaempresa = new ClaseEmpresa('', '', '', '', '', '', '', '', '', accion);
    var res = confirm('Desea eliminar el registro');
    if (res == true) {
        eliminaEmpresa.EliminarEmpresa(id);
        alert('registro eliminado');
    } else { alert('usted canselo la elimnacion del registro'); }
}
var CargaParaImpresionEmpresa = () => {
    var accion = 'Edificios/ContronladorImprimirEmpresa';
    var carga = new ClaseEmpresa('', '', '', '', '', '', '', '', '', accion);
    carga.ImprimirEmpresa();

}
var grabaCompra = () => {
    var activo = document.getElementById('activo').value;
    var estante = document.getElementById('estante').value;
    var empresa = document.getElementById('empresa').value;
    var imagen = document.getElementById('imagen').value;
    var id = document.getElementById('id').value;


    if (id == '') {
        id == 0;
        var accion = 'Compras/ControladorGuardaCompra';
    }
    else {
        var accion = 'Compras/ControladorEditaCompra';
    }
    var graba = new ClaseCompra(activo, estante, empresa, imagen, '', accion);
    graba.GuardarCompra(id);
}

var ListaCompra = () => {
    var accion = 'Compras/ControladorListaCompra';
    var sexo = new ClaseCompra('', '', '', '', '', accion);
    sexo.ListadeCompra();
}
var CargaCompra = (id) => {
    var accion = 'Compras/ControladorUnCompra';
    var unsexo = new ClaseCompra('', '', '', '', '', accion);
    unsexo.CargarCompra(id);
}
var eliminaCompra = (id) => {
    var accion = 'Compras/ControladorEliminarCompra';
    var eliminacompra = new ClaseCompra('', '', '', '', '', accion);
    var res = confirm('Desea eliminar el registro');
    if (res == true) {
        eliminacompra.EliminarCompra(id);
        alert('registro eliminado');
    } else { alert('usted canselo la elimnacion del registro'); }
}
var CargaParaImpresionCompra = () => {
    var accion = 'Compras/ContronladorImprimirCompra';
    var carga = new ClaseCompra('', '', '', '', '', accion);
    carga.ImprimirEdificio();

}

var grabaEmpleado = () => {
    var nombre = document.getElementById('nombre').value;
    var apellido = document.getElementById('apellido').value;
    var direccion = document.getElementById('direccion').value;
    var correo = document.getElementById('correo').value;
    var convencional = document.getElementById('telefono_contacto').value;
    var movil = document.getElementById('telefono_movil').value;
    var id = document.getElementById('id').value;


    if (id == '') {
        id == 0;
        var accion = 'Empleados/ControladorGuardaEmpleado';
    }
    else {
        var accion = 'Empleados/ControladorEditaEmpleado';
    }
    var graba = new ClaseEmpleado(nombre, apellido, direccion, correo, convencional, movil, '', accion);
    graba.GuardarEmpleado(id);
}

var ListaEmpleado = () => {
    var accion = 'Empleados/ControladorListaEmpleado';
    var sexo = new ClaseEmpleado('', '', '', '', '', '', '', accion);
    sexo.ListadeEmpleado();
}
var CargaEmpleado = (id) => {
    var accion = 'Empleados/ControladorUnEmpleado';
    var unsexo = new ClaseEmpleado('', '', '', '', '', '', '', accion);
    unsexo.CargarEmpleado(id);
}
var eliminaEmpleado = (id) => {
    var accion = 'Compras/ControladorEliminarEmpleado';
    var eliminaempleado = new ClaseEmpleado('', '', '', '', '', '', '', accion);
    var res = confirm('Desea eliminar el registro');
    if (res == true) {
        eliminaemplead.EliminarEmpleado(id);
        alert('registro eliminado');
    } else { alert('usted canselo la elimnacion del registro'); }
}
    var CargaParaImpresionEmpleado = () => {
        var accion = 'Compras/ContronladorImprimirEmpleado';
        var carga = new ClaseEmpleado('', '', '', '', '', '', '', accion);
        carga.ImprimirEmpleado();

    }

        var listaeventos = () => {
            var accion = 'Eventos/ControladorListaEvento';
            var eventos = new ClaseEvento('', '', '', '', '', accion);
            eventos.claselistaevento();
        }


    