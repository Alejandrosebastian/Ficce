class ClaseEvento {
    constructor(ciuadad,fecha_ini,fecha_fin,valor, id, accion) {
        this.ciudad = ciuadad;
        this.fecha_ini = fecha_ini;
        this.fecha_fin = fecha_fin;
        this.valor = valor;
        this.id = id;
        this.accion = accion;
    }
    GuardarEvento(id) {
        var ciudad = this.ciudad;
        var fecha_ini = this.fecha_ini;
        var fecha_fin = this.fecha_fin;
        var valor = this.valor;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { ciudad,fecha_ini,fecha_fin,valor },
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
                data: { id, ciudad, fecha_ini, fecha_fin,valor },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        }
    }

    ListadeEvento() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ListaEvento').html(val[0]);
                });
            }
        });
    }
   
    CargarEvento(id) {
        var accion = this.accion;

        $.post(
            accion,
            { id },
            (respuesta) => {
                console.log(respuesta);
                document.getElementById('ciudad').value = respuesta[0].ciudad;
                document.getElementById('inicio').value = respuesta[0].dia_inicio;
                document.getElementById('fin').value = respuesta[0].dia_fin;
                document.getElementById('valor').value = respuesta[0].precio_estan;
                document.getElementById('id').value = respuesta[0].eventoId;
                //localStorage.setItem("sexoId", JSON.respuesta[0].sexoId);

            }
        );


    }
    EliminarEvento(id) {
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
        document.getElementById('ciudad').value = '';
        document.getElementById('inicio').value = '';
        document.getElementById('fin').value = '';
        document.getElementById('valor').value = '';
        document.getElementById('id').value = '';
        //$('#sexo').value = '';
        $('#IngresoEvento').modal('hide');
        ListaEvento();
    }
}