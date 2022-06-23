window.onload = function () {
    ListarCategoria();
}

function ListarCategoria() {
    pintar({
        url: "Categoria/ListarCategoria",
        id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    }, {
        busqueda: true,
        url: "Categoria/FiltrarCategoria",
        nombreparametro: "nombreCategoria",
        type: "text",
        button: false,
        id: "txtnombrecategoria",
        placeholder: "Buscar por nombre",
        editar: true,
        eliminar: true,
        propiedadId: "id"
    })
}

function ListarCategoria1() {
    pintar({
        url: "Categoria/ListarCategoria",
        id: "divTabla",
        cabeceras: ["Id", "Nombre", "Descripcion"],
        propiedades: ["id", "nombre", "descripcion"],
        editar: true,
        eliminar: true,
        propiedadId: "id"
    })
}

function GuardarDatos() {
    let frmCama = document.getElementById("frmCategoria");
    let frm = new FormData(frmCama);
    fetchPostText("Categoria/GuardarDatos", frm, function (res) {
        if (res == '1') {
            ListarCategoria1();
            LimpiarTextos("frmCategoria");
            $("#modalCategoria").modal("hide");
        }
    })
}

function editarRegistro(id) {
    $("#modalCategoria").modal("show");
    RecuperarGenerico("Categoria/RecuperarCategoria/?id=" + id, "frmCategoria");
}

function eliminarRegistro(id) {
    Confirmacion('Está seguro que quiere eliminar ...!!', 'Eliminar registro', function (res) {
        fetchGetTexto("Categoria/EliminarCategoria/?id=" + id, function (rpta) {
            if (rpta == "1") {
                Correcto("Ee eliminó correctamente");
                ListarCategoria1();
            }
        })
    })
}