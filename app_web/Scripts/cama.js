window.onload = function () {
    ListarCama();
}

function ListarCama() {
    pintar({
        url: "Cama/listar",
        id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    }, {
        busqueda: true,
        url:"Cama/FiltrarCama",
        nombreparametro: "nombrecama",
        type: "text",
        button:false,
        id: "txtnombrecama",
        placeholder: "Buscar por nombre",
        editar: true,
        eliminar: true,
        propiedadId: "id"
    })
}

function ListarCama1() {
    pintar({
        url: "Cama/listar",
        id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    })
}

function GuardarDatos() {
    let frmCama = document.getElementById("frmCama");
    let frm = new FormData(frmCama);
    fetchPostText("Cama/GuardarDatos", frm, function (res) {
        if (res == '1') {
            ListarCama1();
            LimpiarTextos("frmCama");
            $("#modalCama").modal("hide");
        }
    })
}

function editarRegistro(id) {
    $("#modalCama").modal("show");
    RecuperarGenerico("Cama/RecuperarCama/?id=" + id, "frmCama");
}

function eliminarRegistro(id) {
    Confirmacion('Está seguro que quiere eliminar ...!!', 'Eliminar registro', function (res) {
        fetchGetTexto("Cama/EliminarCama/?id=" + id, function (rpta) {
            if (rpta == "1") {
                Correcto("Ee eliminó correctamente");
                ListarCama1();
            }
        })
    })
}