// Write your JavaScript code.

var Guardaestante = () => {
    var Ancho = document.getElementById('Ancho').value;
    var Largo = docuement.getElementById('Largo').value;
    var Evento = document.getElementById('Evento').value;
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

$().ready(() => {
    //mostrardatosjs();
    // listaClientes(1,'null');
    ListaEdificio();
    //SiteListaIndex(1);
});
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


