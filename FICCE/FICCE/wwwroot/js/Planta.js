class ClasePlanta {
    constructor(edificio, nombre, id, accion) {
        this.edificio = edificio;
        this.nombre = nombre;
        this.id = id;
        this.accion = accion;
    }
    GuardarPlanta(id) {
        var edificio = this.edificio;
        var nombre = this.nombre;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { edificio, nombre },
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
                data: { id, edificio, nombre },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        }
    }

    ListadePlanta() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ListaPlanta').html(val[0]);
                });
            }
        });
    }
    CargarPlanta(id) {
        var accion = this.accion;

        $.post(
            accion,
            { id },
            (respuesta) => {
                console.log(respuesta);
                document.getElementById('edificio').value = respuesta[0].edificioId;
                document.getElementById('nombre').value = respuesta[0].nombre;
                document.getElementById('id').value = respuesta[0].plantaId;
                //localStorage.setItem("sexoId", JSON.respuesta[0].sexoId);

            }
        );


    }
    EliminarPlanta(id) {
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
    ImprimirPlanta() {
        var accion = this.accion;
        $.post(accion, {},
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#CuerpoImpresionPlanta').html(respuesta[0]);
                });
            }
        );
    }

    limpiarcajas() {
        document.getElementById('nombre').value = '';
        document.getElementById('edificio').value = '';
        document.getElementById('id').value = '';
        //$('#sexo').value = '';
        $('#IngresoPlanta').modal('hide');
        ListaEdificio();
    }
}