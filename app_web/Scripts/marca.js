window.onload = function () {
    ListarMarca();
}

function ListarMarca() {
    pintar({
        url: "Marca/listarMarca",
        id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    }, {
        busqueda: true,
        url: "Marca/FiltrarMarca",
        nombreparametro: "nombreMarca",
        type: "text",
        id: "txtnombremarca",
        placeholder: "Buscar por nombre",
        editar: true,
        eliminar: true,
        propiedadId: "id"
    })
}


function ListarMarca1() {
    pintar({
        url: "Marca/listarMarca",
        id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    })
}



function GuardarDatos() {
    let frmCama = document.getElementById("frmMarca");
    let frm = new FormData(frmCama);
    fetchPostText("Marca/GuardarDatos", frm, function (res) {
        if (res == '1') {
            ListarMarca1();
            LimpiarTextos("frmMarca");
            $("#modalMarca").modal("hide");
        }
    })
}

function editarRegistro(id) {
    $("#modalMarca").modal("show");
    RecuperarGenerico("Marca/RecuperarMarca/?id=" + id, "frmMarca");
}

function eliminarRegistro(id) {
    Confirmacion('Está seguro que quiere eliminar ...!!', 'Eliminar registro', function (res) {
        fetchGetTexto("Marca/EliminarMarca/?id=" + id, function (rpta) {
            if (rpta == "1") {
                Correcto("Ee eliminó correctamente");
                ListarMarca1();
            }
        })
    })
}