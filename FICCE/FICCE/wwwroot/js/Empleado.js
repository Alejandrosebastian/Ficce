class ClaseEmpleado {
    constructor(empresa, nombre, apellido, correo, telefono_contacto, telefono_movil, direccion,id,accion) {
        this.empresa = empresa;
        this.nombre = nombre;
        this.apellido = apellido;
        this.correo = correo;
        this.telefono_contacto = telefono_contacto;
        this.telefono_movil = telefono_movil;
        this.direccion = direccion;
        this.id = id;
        this.accion = accion;
    }
    GuardarEmpleado(id) {
        this.empresa = empresa;
        this.nombre = nombre;
        this.apellido = apellido;
        this.correo = correo;
        this.telefono_contacto = telefono_contacto;
        this.telefono_movil = telefono_movil;
        this.direccion = direccion;
        var accion = this.accion;
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { empresa, nombre, apellido, correo, telefono_contacto, telefono_movil, direccion },
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
                data: { id, empresa, nombre, apellido, correo, telefono_contacto, telefono_movil, direccion },
                success: (respuesta) => {
                    if (respuesta[0].code == 'save') {
                        this.limpiarcajas();
                    }
                }
            });
        }
    }

    ListadeEmpleado() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ListaEmpleado').html(val[0]);
                });
            }
        });
    }
    CargarEmpleado(id) {
        var accion = this.accion;

        $.post(
            accion,
            { id },
            (respuesta) => {
                console.log(respuesta);
                document.getElementById('empresa').value = respuesta[0].empresaId;
                document.getElementById('nombre').value = respuesta[0].nombre;
                document.getElementById('apellido').value = respuesta[0].apellido;
                document.getElementById('correo').value = respuesta[0].correo;
                document.getElementById('telefono_contacto').value = respuesta[0].telefono_convencional;
                document.getElementById('telefono_movil').value = respuesta[0].telefono_movil;
                document.getElementById('direccion').value = respuesta[0].direccion;
                document.getElementById('id').value = respuesta[0].empleadoId;
                //localStorage.setItem("sexoId", JSON.respuesta[0].sexoId);

            }
        );


    }
    EliminarEmpleado(id) {
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
    ImprimirEmpleado() {
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
        document.getElementById('empresa').value = '';
        document.getElementById('nombre').value = '';
        document.getElementById('apellido').value = '';
        document.getElementById('correo').value = '';
        document.getElementById('telefono_contacto').value = '';
        document.getElementById('telefono_movil').value = '';
        document.getElementById('direccion').value = '';
        document.getElementById('id').value = '';
        //$('#sexo').value = '';
        $('#IngresoEmpleado').modal('hide');
        ListaEmpleado();
    }
}