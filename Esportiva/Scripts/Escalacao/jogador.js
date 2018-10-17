$(function () {
    $('a').tooltip();
    $(document).on('click', '#btn-novo-jogador', function () {
        $('#modal-jogador').modal();
    });

    $(document).on('click', 'a[data-opcao="editar-jogador"]', function () {
        $('#btn-salvar-jogador').text('Editar');
        $('#txtNome').val($(this).data('nome'));
        $('#txtSobrenome').val($(this).data('sobrenome'));
        $('#txtCamisa').val($(this).data('camisa'));
        $('#txtPosicao').val($(this).data('posicao'));
        $('#txtApelido').val($(this).data('apelido'));
        $('#txtAltura').val($(this).data('altura'));

        $('#txtCodigoDoJogador').val($(this).data('codigo'));
        $('#txtCodigoJogador').val($(this).data('codigo-jogador'));
        $('#modal-jogador').modal();
    });

    $(document).on('click', '#btn-salvar-jogador', function () {
        if (validaForm()) {
            let url = "/Escalacao/CadastraJogador/"
            if ($(this).text() == "Editar") {
                url = "/Escalacao/EditarJogador/"
            }
            
            $.post(url, {
                "CodigoTime": $('#txtCodigoJogador').val(),
                "Id": $('#txtCodigoDoJogador').val(),
                "Nome": $("#txtNome").val(),
                "Sobrenome": $("#txtSobrenome").val(),
                "Posicao": $("#txtPosicao").val(),
                "DataNascimento": $("#txtNascimento").val(),
                "NumeroCamisa": $("#txtCamisa").val(),
                "Apelido": $("#txtApelido").val(),
                "Altura": $("#txtAltura").val()
            }, function (retorno) {
                if (retorno.Sucesso) {
                    MensagemSucesso(retorno.Mensagem);
                    setTimeout(function () {
                        location.reload();
                    }, 1000);
                } else {
                    MensagemErroPersonalizada(retorno.Mensagem);
                }
            });
        }
    });

    const validaForm = function () {
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