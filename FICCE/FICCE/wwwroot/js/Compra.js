class ClaseCompra {
    constructor(activo, estante, empresa, imagen, id, accion) {
        this.activo = activo;
        this.estante = estante;
        this.empresa = empresa;
        this.imagen = imagen;
        this.id = id;
        this.accion = accion;
    }
    GuardarCompra(id) {
        var activo = this.activo;
        var estante = this.estante;
        var empresa = this.empresa;
        var imagen = this.imagen;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { activo,estante, empresa, imagen },
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
                data: { id, activo, estante, empresa, imagen },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        }
    }

    ListadeCompra() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ListaCompra').html(val[0]);
                });
            }
        });
    }
    CargarCompra(id) {
        var accion = this.accion;

        $.post(
            accion,
            { id },
            (respuesta) => {
                console.log(respuesta);
                document.getElementById('activo').value = respuesta[0].activo;
                document.getElementById('estante').value = respuesta[0].estanteId;
                document.getElementById('empresa').value = respuesta[0].empresa;
                document.getElementById('imagen').value = respuesta[0].imagen;
                document.getElementById('id').value = respuesta[0].compraId;
                //localStorage.setItem("sexoId", JSON.respuesta[0].sexoId);

            }
        );


    }
    EliminarCompra(id) {
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
    ImprimirCompra() {
        var accion = this.accion;
        $.post(accion, {},
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#CuerpoCompra').html(respuesta[0]);
                });
            }
        );
    }

    limpiarcajas() {
        document.getElementById('activo').value = '';
        document.getElementById('estante').value = '';
        document.getElementById('empresa').value = '';
        document.getElementById('imagen').value = '';
        document.getElementById('id').value = '';
        //$('#sexo').value = '';
        $('#IngresoCompra').modal('hide');
        ListaCompra();
    }
}