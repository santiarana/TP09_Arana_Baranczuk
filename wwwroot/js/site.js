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

function Editar(IdP, cantidad) {
    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Home/Update',
        data: { IdProducto: IdP },
        success: function(response) {
            $("#Stock").html("<form method='post' href = /Home/Update new{CantidadDisponible=@ViewBag.ListaProductos.CantidadDisponible})'> <div class='form-group'><input type='text' id='CantidadDisponible' name='CantidadDisponible' required></br> </div><button type='submit' class='btn btn-primary'>Confirmar</button></form>");
        }
    });
}