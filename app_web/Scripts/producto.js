window.onload = function () {
    ListarProducto();
    llenarComboMarca();
    llenarComboCategoria();
}
function ListarProducto() {
    pintar({
        url: "Producto/ListarProducto",
        id: "divTabla",
        cabeceras: ["Id producto", "Categoria", "Marca", "Nombre","Precio","Stock","Denominacion"],
        propiedades: ["iidproducto","nombrecategoria" , "nombremarca", "nombre","precio","stock","denominacion"]
    })
}

function Buscar() {
    let nombreProducto = get('txtnombreproducto');
    pintar({
        url: "Producto/FiltrarProductoPorNombre/?nombreProducto=" + nombreProducto,
        id: "divTabla",
        cabeceras: ["Id producto", "Categoria", "Marca", "Nombre",  "Precio", "Stock", "Denominacion"],
        propiedades: ["iidproducto", "nombrecategoria", "nombremarca", "nombre", "precio", "stock", "denominacion"]
    })
}

function llenarComboMarca() {
    fetchGet("Marca/ListarMarca", function (data) {
        llenarCombo(data,"cboLLenarMarca","nombre","id");
    })
}

function llenarComboCategoria() {
    fetchGet("Categoria/ListarCategoria", function (data) {
        llenarCombo(data, "cboLLenarCategoria", "nombre", "id");
    })
}