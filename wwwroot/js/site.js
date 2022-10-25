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

function Password(IdU, clave) {
    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Home/AgregarProducto',
        data: { IdUsuario: IdU },
        success: function(response) {
            $(document).ready(function() {
                $("#TextoModal").html("Clave:  <input type=number id=CantidadDisponible name=CantidadDisponible required></br>")
                $("#botonenviar").click(function() { // Con esto establecemos la acción por defecto de nuestro botón de enviar.
                    if (validaForm()) { // Primero validará el formulario.
                        $.post("enviar.php", $("#formdata").serialize(), function(res) {
                            $("#formulario").fadeOut("slow"); // Hacemos desaparecer el div "formulario" con un efecto fadeOut lento.
                            if (res == 1) {
                                $("#exito").delay(500).fadeIn("slow"); // Si hemos tenido éxito, hacemos aparecer el div "exito" con un efecto fadeIn lento tras un delay de 0,5 segundos.
                            } else {
                                $("#fracaso").delay(500).fadeIn("slow"); // Si no, lo mismo, pero haremos aparecer el div "fracaso"
                            }
                        });
                    }
                });
            });
        }
    });
}