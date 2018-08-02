import { lchmod } from "fs";

class ClaseEstante {
    constructor(Ancho, Largo, Evento, Planta, accion) {
        this.Ancho = Ancho;
        this.Largo = Largo;
        this.Evento = Evento;
        this.Planta = Planta;
        this.accion = accion;

    }
    GuardaEstante(id) {
        var Ancho = this.Ancho;
        var Largo = this.Largo;
        var Evento = this.Evento;
        var Planta = this.Planta;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { Ancho, Largo, Evento, Planta },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        } else {
             $.ajax({
                 type: "POST",
                 url: accion,
                 data: { id, Ancho, Largo, Evento, Planta },
                 success: (respuesta) => {
                     if (respuesta[0].code == 'save') {
                         this.limpiarcajas();


                     }
                 }
             });
                    
                      
        }
        
    }
    limpiarcajas() {
        document.getElementById('Ancho').value = '';
        document.getElementById('Largo').value = '';
        document.getElementById('Evento').value = '';
        document.getElementById('Planta').value = '';
        document.getElementById('id').value = '';
        $('#IngresoEstante').modal('hide');
        ListaEstante();
    }
}