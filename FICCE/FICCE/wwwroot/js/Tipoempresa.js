

class Clasetipoempresa {
    constructor(Detalle, Nombre, accion) {
        this.Detalle = Detalle;
        this.Nombre = Nombre;
        this.accion = accion;
    }
    Guardatipoempresa(id) {
        var Nombre = this.Nombre;
        var Detalle = this.Detalle;
        var accion = this.accion;
        var resultado = '';
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { Nombre,Detalle },
                succes: (respuesta) => {
                    if (respuesta[0].code == "save") {
                        this.limpiarcajas();
                    }
                }
            });
        } else {
            $.ajax({
                type: "POST",
                url: accion,
                data: { id,Nombre,Detalle },
                success: (respuesta) => {
                    if (respuesta[0].code == "save") {
                        this.limpiarcajas();
                    }
                }
            });
        }
    }
    listatipoempresa() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#ListaTipoempresa').html(val[0]);
                });
            }
        });
    }
    limpiarcajas() {
        document.getElementById('Nombre').value = '';
        document.getElementById('Detalle').value = '';
        docuement.getElementById('TipoempresaId').value = '';
        $('#IngresoTipoempresa').modal('hide');

        
    }
}