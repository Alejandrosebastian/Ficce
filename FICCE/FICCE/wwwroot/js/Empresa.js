class ClaseEmpresa {
    constructor(tipo, nombre, direccion,correo, persono, contacto, convencional, extencion, id, accion) {
        this.tipo = tipo;
        this.nombre = nombre;
        this.direccion = direccion;
        this.correo = correo;
        this.persono = persono;
        this.contacto = contacto;
        this.convencional = convencional;
        this.extencion = extencion;
        this.id = id;
        this.accion = accion;
    }
    GuardarEmpresa(id) {
        var tipo = this.tipo;
        var nombre = this.nombre;
        var direccion = this.direccion;
        var correo = this.correo;
        var persono = this.persono;
        var contacto = this.contacto;
        var convencional = this.convencional;
        var extencion = this.extencion;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { tipo, nombre, direccion, correo, persono, contacto, convencional, extencion },
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
                data: { id, tipo, nombre, direccion, correo, persono, contacto, convencional, extencion },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        }
    }

    ListadeEmpresa() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ListaEmpresa').html(val[0]);
                });
            }
        });
    }
    CargarEmpresa(id) {
        var accion = this.accion;

        $.post(
            accion,
            { id },
            (respuesta) => {
                console.log(respuesta);
                document.getElementById('tipo').value = respuesta[0].tipoId;
                document.getElementById('nombre').value = respuesta[0].nombre;
                document.getElementById('direccion').value = respuesta[0].direccion;
                document.getElementById('correo').value = respuesta[0].correo;
                document.getElementById('persono').value = respuesta[0].persona_responsable;
                document.getElementById('contacto').value = respuesta[0].telefono_contacto;
                document.getElementById('convencional').value = respuesta[0].telefono_convencional;
                document.getElementById('extencion').value = respuesta[0].extenencion_telefono;
                document.getElementById('id').value = respuesta[0].empresaId;
                //localStorage.setItem("sexoId", JSON.respuesta[0].sexoId);

            }
        );


    }
    EliminarEmpresa(id) {
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
    ImprimirEmpresa() {
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
        document.getElementById('tipo').value = '';
        document.getElementById('nombre').value = '';
        document.getElementById('direccion').value = '';
        document.getElementById('correo').value = '';
        document.getElementById('persono').value = '';
        document.getElementById('contacto').value = '';
        document.getElementById('convencional').value = '';
        document.getElementById('extencion').value = '';
        //$('#sexo').value = '';
        $('#IngresoEmpresa').modal('hide');
        ListaEmpresa();
    }
}