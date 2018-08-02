
class ClaseEstante {
    constructor(Ancho, Largo, Evento, Planta,id, accion) {
        this.Ancho = Ancho;
        this.Largo = Largo;
        this.Evento = Evento;
        this.Planta = Planta;
        this.id = id;
        this.accion = accion;

    }
    GuardaEstante(id) {
        if (this.Ancho == '') {
            document.getElementById('Ancho').focus();
        } else {
            if (this.Largo == '') {
                document.getElementById('Largo').focus();
            } else {
                if (this.Evento == '0') {
                    document.getElementById('Evento').focus();
                } else {
                    if (this.Ubicacion =='') {
                        document.getElementById('Ubicacion').focus();

                    } else {
                    if (this.Planta == '0') {
                        document.getElementById('Planta').focus();
                    } else {
                        var Ancho = this.Ancho;
                        var Largo = this.Largo;
                        var Evento = this.Evento;
                        var Planta = this.Planta;
                        var accion = this.accion;
                        var valor = '';
                        $.ajax({
                            type: "POST",
                            url: accion,
                            data: {
                                Ancho,
                                Largo,
                                Ubicacion,
                                Evento,
                                Planta
                            },
                            success: (respuesta) => {
                                $.each(respuesta, (contador, val) => {
                                    valor = val.code;
                                });
                                if (valor === 'save') {
                                    $('#IngresoEstante').modal('hide');

                                } else {
                                    alert(valor);

                                }
                                alert(valor);
                            }
                        });
                        }
                    }
                }
            }
        }
        
    }
    claselistaeventos() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data:{},
            success: (respuesta) => {
                console.log(respuesta);
                if (0 < respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('EventoId').options[contador] = new Option(respuesta[i].ciudad, respuesta[i].eventoId);
                        contador++
                    }
                }
            }
        });
    }
    claselistaplanta() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data:{},
            success: (respuesta) => {
                console.log(respuesta);
                if (0 < respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('PlantaId').options[contador] = new Option(respuesta[i].nombre, respuesta[i].plantaId);
                        contador++
                    }
                }
            }
        });

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