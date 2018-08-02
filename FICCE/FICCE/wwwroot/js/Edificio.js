class ClaseEdificio {
    constructor(evento,nombre,ubicacion,id, accion) {
        this.evento = evento;
        this.nombre = nombre;
        this.ubicacion = ubicacion;
        this.id = id;
        this.accion = accion;
    }
    GuardarEdificio(id) {
        var evento = this.evento;
        var nombre = this.nombre;
        var ubicacion = this.ubicacion;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { evento, nombre, ubicacion },
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
                data: { id, evento,nombre,ubicacion },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        }
    }
    //claselistaevento() {
    //    var accion = this.accion;
    //    var contador = 1;
    //    $.ajax({
    //        type: "POST",
    //        url: accion,
    //        data: {};
    //        success: (respuesta) => {
    //            for (var i = 0; <respuesta.length; i++) {
    //                document.getElementById('Ciudad').options[contador] = new Option(respuesta[i].ciudad, respuesta[i].ciudad);
    //                contador++
    //            }
    //        }
    //    });
    //}

    ListadeEdificio() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ListaEdificio').html(val[0]);
                });
            }
        });
    }
    CargarEdificio(id) {
        var accion = this.accion;

        $.post(
            accion,
            { id },
            (respuesta) => {
                console.log(respuesta);
                document.getElementById('evento').value = respuesta[0].eventoId;
                document.getElementById('nombre').value = respuesta[0].nombre;
                document.getElementById('ubicacion').value = respuesta[0].ubicacion;
                document.getElementById('id').value = respuesta[0].edificioId;
                //localStorage.setItem("sexoId", JSON.respuesta[0].sexoId);

            }
        );


    }
    EliminarEdificio(id) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { id },
            success: (respuesta) => {
                if (respuesta[0].code == 'Save') {
                    this.limpiarcajas();
                }
            }
        });
    }
    ImprimirEdificio() {
        var accion = this.accion;
        $.post(accion, {},
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#CuerpoImpresion').html(respuesta[0]);
                });
            }
        );
    }

    limpiarcajas() {
        document.getElementById('nombre').value = '';
        document.getElementById('ubicacion').value = '';
        document.getElementById('evento').value = '';
        document.getElementById('id').value = '';
        //$('#sexo').value = '';
        $('#IngresoEdificio').modal('hide');
        ListaEdificio();
    }
}