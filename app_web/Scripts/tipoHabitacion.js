window.onload = function () {
    ListarTipoHabitacion();
}


function ListarTipoHabitacion() {
    pintar({
        url: "TipoHabitacion/listar",
        id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadId:"id"
    }, {
        busqueda: true,
        url: "TipoHabitacion/FiltrarTipoHabitacionNombre",
        nombreparametro: "nombreHabitacion",
        type: "text",
        id: "txtnombretipoHabitacion",
        placeholder: "Buscar por nombre",
        editar: true,
        eliminar: true,
        propiedadId: "id"
    })
}

function ListarTipoHabitacion1() {
    pintar({
        url: "TipoHabitacion/listar",
        id: "divTabla",
        cabeceras:["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    })
}


function GuardarDatos() {
    let frmTipoHabitacion = document.getElementById("frmTipoHabitacion");
    let frm = new FormData(frmTipoHabitacion);
    fetchPostText("TipoHabitacion/GuardarDatos", frm, function (res) {
          if (res == '1') {
              ListarTipoHabitacion1();
              LimpiarTextos("frmTipoHabitacion");
              $("#modalTipoHabitacion").modal("hide");
          }
    })

    //fetch("TipoHabitacion/GuardarDatos", {
    //    method: "POST",
    //    body: frm
    //}).then(res => res.text())
    //    .then(res => {
    //        if (res == '1') {
    //            ListarTipoHabitacion1();
    //        }
    //    })
}

function editarRegistro(id) {
    //fetchGet("TipoHabitacion/RecuperarTipoHabitacion/?id=" + id, function (res) {
    //    setName("id", res.id);
    //    setName("nombre",res.nombre);
    //    setName("descripcion",res.descripcion);
    //})
    $("#modalTipoHabitacion").modal("show");
    RecuperarGenerico("TipoHabitacion/RecuperarTipoHabitacion/?id=" + id,"frmTipoHabitacion");

}

function eliminarRegistro(id) {
    Confirmacion('Está seguro que quiere eliminar ...!!', 'Eliminar registro', function (res) {
        fetchGetTexto("TipoHabitacion/EliminarDatos/?id=" + id, function (rpta) {
            if (rpta == "1") {
                Correcto("Ee eliminó correctamente");
                ListarTipoHabitacion1();
            }
        })
    })
}

//function ListarTipoHabitacion() {
//    pintar({
//        url: "tipoHabitacion/listar",
//        id: "divTabla",
//        cabeceras:["Id", "Nombre", "Descripcion"],
//        propiedades:["id","nombre","descripcion"]
//    })
//}

//function Buscar() {
//    let txtnombreTipoHabitacion = get("txtnombreTipoHabitacion");
//    pintar({
//        url: "tipoHabitacion/FiltrarTipoHabitacionNombre/?nombreHabitacion=" + txtnombreTipoHabitacion,
//        id: "divTabla",
//        cabeceras: ["Id", "Nombre", "Descripcion"],
//        propiedades: ["id", "nombre", "descripcion"]
//    })
//}