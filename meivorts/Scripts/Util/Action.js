
//Exclui itens via Ajax
function Excluir(id, pagina) {

    $.ajax({
        url: '/' + pagina + '/Delete/' + id,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        async: true,
        dataType: 'json',
        success: function (dados) {
            alert(dados.Mensagem);
            location.reload();

        },
        error: function (dados) {
            alert(dados.Mensagem);
            location.reload();

        }
    });
}




