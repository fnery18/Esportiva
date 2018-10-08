$(function () {
    $('a').tooltip();

    $(document).on('click', '#btn-novo-jogador', function () {
        $('#modal-jogador').modal();
    });

    $(document).on('click', '#btn-salvar-jogador', function () {
        if (validaForm()) {
            $.post('/Escalacao/CadastraJogador/',
                {

                }, function () {
                    
                });
        }
    });

    const validaForm = function(){
        let nome = $('#txtNome');
        let sobrenome = $('#txtSobrenome');
        let nascimento = $('#txtNascimento');
        let posicao = $('#txtPosicao');
        let numero = $('#txtCamisa');
        let apelido = $('#txtApelido');
        let Altura = $('#txtAltura');

        if (nome.val() == "") {
            MensagemErroPersonalizada("Por favor digite um nome");
            nome.focus();
        }
        else if (sobrenome.val() == "") {
            MensagemErroPersonalizada("Por favor digite um Sobrenome");
            sobrenome.focus();
        }
        else if (nascimento.val() == "") {
            MensagemErroPersonalizada("Por favor digite a data de nascimento");
            nascimento.focus();
        }
        else if (posicao.val() == "") {
            MensagemErroPersonalizada("Por favor digite a posição do jogador");
            posicao.focus();
        }
        else if (numero.val() == "") {
            MensagemErroPersonalizada("Por favor digite o número da camisa");
            numero.focus();
        }
        else if (apelido.val() == "") {
            MensagemErroPersonalizada("Por favor digite o apelido");
            apelido.focus();
        }
        else if (Altura.val() == "") {
            MensagemErroPersonalizada("Por favor digite a altura");
            Altura.focus();
        }
        else {
            return true;
        }

        return false;
    }
});