$(document).ready(function () {
    $("#Telefone").inputmask("(999) 99999-9999");  
 
});
function ExcluirTipoContato(id) {

    $.ajax({
        url: '/tipoContato/Delete/'+id,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        async: true,
        dataType: 'json',
        success: function (dados) {
            alert(dados.Mensagem)
        },
        error: function (dados) {
            alert(dados.Mensagem)
        }
    });
}




