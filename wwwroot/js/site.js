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
            $("#FotoModal").attr("src", response.imagenSerie);
            $("#TextoModal").html("Fecha de ingreso: " + response.FechaDeIngreso + "<br>" + "Cantidad disponible: " + response.CantidadDisponible + " rollos " + "<br>" + "Peso: " + response.Peso + "Kg");
        }
    });
}