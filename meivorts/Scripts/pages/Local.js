// show or hide form by checkBox
function showEnderecoForm(valor) {

    if (valor == 0) {
        $("#enderecoForm").show();
        $("#showEndereco").val(1);
    } else {
        $("#enderecoForm").hide();
        $("#showEndereco").val(0);
    }
}