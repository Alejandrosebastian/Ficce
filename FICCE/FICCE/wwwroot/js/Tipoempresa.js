class Clasetipoempresa {
    constructor(Detalle, Nombre, accion) {
        this.Detalle = Detalle;
        this.Nombre = Nombre;
        this.accion = accion;
    }
    Guardatipoempresa(id) {
        var Detalle = this.Detalle;
        var Nombre = thi.Nombre;
        var accion = this.accion;
        var resultado = '';
        if (id == '0') {
            $.ajax({
                type: "POST",
                url: accion,
                data: { Detalle, Nombre },
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
                data: { id, Detalle, Nombre },
                success: (respuesta) => {
                    if (respuesta[0].code == "save") {
                        this.limpiarcajas();
                    }
                }
            });
        }
    }
    limpiarcajas() {
        document.getElementById('Detalle').value = '';
        document.getElementById('Nombre').value = '';
        docuement.getElementById('TipoempresaId').value = '';
        $('#IngresoTipoempresa').modal('hide');
        
    }
}