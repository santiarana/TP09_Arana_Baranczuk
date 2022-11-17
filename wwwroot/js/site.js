// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function MostrarProducto(IdP, nombre) {
    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Home/VerDetalleProductoAjax',
        data: { IdProducto: IdP },
        success: function(response) {
            $("#TituloModal").html(nombre);
            $("#TextoModal").html("Fecha de ingreso: " + response.fechaDeIngreso + "<br>" + "Cantidad disponible: " + response.cantidadDisponible + " rollos " + "<br>" + "Peso: " + response.peso + "Kg");
        }
    });
}

function CargarModalModificacion(IdP) {
    console.log("modal: " + IdP.toString());
    $("#submitStock").val(IdP);
}

function Editar(IdP, cantidad) {
    console.log(IdP);
    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Home/Update',
        data: { IdProducto: IdP, CantidadDisponible: cantidad },
        success: function(response) {
            //$("#Stock").attr('href', "/Home/Update?CantidadDisponible=" + cantidad.toString());
        }
    });
}