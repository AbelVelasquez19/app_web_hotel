function get(id) {
    return document.getElementById(id).value;
}

function set(id, valor) {
    document.getElementById(id).value=valor;
}

function Error(texto="Ocurrio un error") {
    Swal.fire({
        icon: 'error',
        title: 'Error',
        text: texto,
    })
}

function Correcto(texto = "Se realizo correctamente") {
    Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: texto,
        showConfirmButton: false,
        timer: 1500
    })
}

function Confirmacion(texto = 'Desea guardar los cambios?',title="Confirmacion",callback) {
    return Swal.fire({
        title: title,
        text: texto,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si',
        cancelButtonText: 'NO'
    }).then((result) => {
        if (result.isConfirmed) {
            callback();
            //Swal.fire(
            //    'Deleted!',
            //    'Your file has been deleted.',
            //    'success'
            //)
        }
    })
}

function setName(id, valor) {
    document.getElementsByName(id)[0].value = valor;
}

function LimpiarTextos(idFrm,excepciones=[]) {
    let elemento = document.querySelectorAll("#" + idFrm + " [name]");
    for (let i = 0; i < elemento.length; i++) {

        if (!excepciones.includes(elemento[i].name))
        elemento[i].value = "";
    }
}

let objConfiguracionGlobal;
let objBusquedaGloblal;
function pintar(objConfiguracion,objBusqueda) {

    //url absoluta
    let raiz = document.getElementById('hdfOculto').value;
    let urlAbsuluta = window.location.protocol + "//" + window.location.host + raiz + objConfiguracion.url;
    fetch(urlAbsuluta)
        .then(res => res.json())
        .then(res => {
            let contenido = "";
            if (objBusqueda != undefined && objBusqueda.busqueda == true) {
                if (objBusqueda.placeholder == undefined)
                    objBusqueda.placeholder = 'Ingrese un valor'
                if (objBusqueda.id == undefined)
                    objBusqueda.id = 'txtbusqueda'
                if (objBusqueda.type == undefined)
                    objBusqueda.type = 'text'
                if (objConfiguracion.id == undefined)
                    objConfiguracion.id = 'divTabla'
                if (objBusqueda.button == undefined)
                    objBusqueda.button = true
                if (objConfiguracion.editar == undefined)
                    objConfiguracion.editar = false
                if (objConfiguracion.eliminar == undefined)
                    objConfiguracion.eliminar = false
                if (objConfiguracion.propiedadId == undefined)
                    objConfiguracion.propiedadId = "id"
                //asignar valores globales un valor
                objConfiguracionGlobal = objConfiguracion;
                objBusquedaGloblal = objBusqueda;
                contenido += `
                <div class="row mb-3">
                    <div class="col-md-12 d-flex justify-content-end">
                        <form class="form-inline"> `;
                contenido += `<input class="form-control mr-sm-2" type = "${objBusqueda.type}" id = "${objBusqueda.id}" ${objBusqueda.button == true ? " " : "onkeyup='Buscar();'" } placeholder = "${objBusqueda.placeholder}" aria - label="Buscar" >`;
                if (objBusqueda.button == true) {
                    contenido += `<button class="btn btn-outline-success my-2 my-sm-0" type = "button" onclick = "Buscar()" > Buscar</button >`;
                }
                contenido += `</form>
                    </div>
                </div>`;
            }
            contenido += "<div id='divContenedor'>";
            contenido += generarTabla(objConfiguracion,res);
            contenido += "</div>";
            document.getElementById(objConfiguracion.id).innerHTML = contenido;

        });
}


function generarTabla(objConfiguracion, res) {
    let contenido = "";
    contenido += "<table class='table table-bordered table-sm'>";
    contenido += "<tr>"
    for (let j = 0; j < objConfiguracion.cabeceras.length; j++) {
        contenido += "<th>" + objConfiguracion.cabeceras[j] + "</th>"
    }
    if (objConfiguracion.editar == true || objConfiguracion.eliminar == true) {
        contenido += "<th>Opcion</th>";
    }
    contenido += "</tr>"
    let fila;
    let propiedadActual;
    for (let i = 0; i < res.length; i++) {
        fila = res[i];
        contenido += "<tr>";
        for (let j = 0; j < objConfiguracion.propiedades.length; j++) {
            propiedadActual = objConfiguracion.propiedades[j];
            contenido += "<td>" + fila[propiedadActual] + "</td>";
        }
        if (objConfiguracion.editar == true || objConfiguracion.eliminar == true) {
            contenido += "<td>";
            if (objConfiguracion.editar == true) {
                contenido += `<button type="button" class="btn btn-primary" onclick="editarRegistro(${fila[objConfiguracion.propiedadId]})" btn-sm ml-3"><i class='fas fa-edit'></i></button>`;
            }
            if (objConfiguracion.eliminar == true) {
                contenido += ` <button type="button" class="btn btn-danger" onclick="eliminarRegistro(${fila[objConfiguracion.propiedadId]})" btn-sm ml-3"><i class='fas fa-trash-alt'></i></button>`;
            }
            contenido += "</td>";
        }
        contenido += "</<tr>";
    }
    contenido += "</table>";
    return contenido;
}

function fetchGet(url,callback) {
    let raiz = document.getElementById('hdfOculto').value;
    let urlAbsuluta = window.location.protocol + "//" + window.location.host + raiz + url;
    fetch(urlAbsuluta).then(res => res.json())
        .then(res => {
            callback(res)
        }).catch(err => {
            console.log(err)
        })
}

function fetchGetTexto(url, callback) {
    let raiz = document.getElementById('hdfOculto').value;
    let urlAbsuluta = window.location.protocol + "//" + window.location.host + raiz + url;
    fetch(urlAbsuluta).then(res => res.text())
        .then(res => {
            callback(res)
        }).catch(err => {
            console.log(err)
        })
}

function fetchPostText(url,frm, callback) {
    let raiz = document.getElementById('hdfOculto').value;
    let urlAbsuluta = window.location.protocol + "//" + window.location.host + raiz + url;
    fetch(url, {
        method: "POST",
        body: frm
    }).then(res => res.text())
        .then(res => {
            callback(res);
        }).catch(err => {
            console.log(err);
        })
}

function Buscar() {
    let objConf = objConfiguracionGlobal;
    let objBus = objBusquedaGloblal;
    //id del control
    let valor = get(objBus.id);
    fetchGet(`${objBus.url}/?${objBus.nombreparametro}=` + valor, function (res) {
        let rpta = generarTabla(objConf, res);
        document.getElementById("divContenedor").innerHTML = rpta;
    })
    /*fetch(`${objBus.url}/?${objBus.nombreparametro}=` + valor)
        .then(res => res.json())
        .then(res => {
            let rpta = generarTabla(objConf, res);
            document.getElementById("divContenedor").innerHTML = rpta;
        });
    pintar({
        url: `${objBus.url}/?${objBus.nombreparametro}=` + valor,
        id: objConf.id,
        cabeceras: objConf.cabeceras,
        propiedades: objConf.propiedades
    }, objBus)]*/
}

function RecuperarGenerico(url,idFrm, excepciones = []) {
    let elemento = document.querySelectorAll("#" + idFrm + " [name]");
    let nombreName;
    fetchGet(url, function (res) {
        for (let i = 0; i < elemento.length; i++) {
            nombreName = elemento[i].name;
            if (!excepciones.includes(elemento[i].name))
                setName(nombreName, res[nombreName]);
        }
    })
}

function llenarCombo(data,id,propiedadMostar,propiedadId) {
    let contenido = "";
    let elemento;
    contenido +="<option value=''>--Selecione--</option>";
    for (let j = 0; j < data.length; j++) {
        elemento = data[j];
        contenido += "<option value='" + elemento[propiedadId] +"'>" + elemento[propiedadMostar] + "</option>";
    }
    contenido += "";
    document.getElementById(id).innerHTML = contenido;
}