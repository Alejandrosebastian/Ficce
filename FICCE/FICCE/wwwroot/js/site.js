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