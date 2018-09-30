$(function () {
    if ($('#mensagem-retorno').html().length > 0) {
        MensagemErroPersonalizada($('#mensagem-retorno').html());
    }

    $(document).on('click', '#btn-nova-conta', function () {
        if (ValidaModalConta()) {
            $.post("/Autenticacao/Cadastrar/", {
                "Usuario": $("#txtNovoUsuario").val(),
                "Senha": $("#txtNovaSenha").val()
            }, function (retorno) {
                if (retorno.Sucesso) {
                    MensagemSucesso(retorno.Mensagem);
                    $("#txtUsuario").val($("#txtNovoUsuario").val());
                    $("#txtSenha").val($("#txtNovaSenha").val());
                    $('.close span').trigger('click');

                } else {
                    MensagemErroPersonalizada(retorno.Mensagem);
                }
            })
        }
    });

    const ValidaModalConta = function () {
        let user = $('#txtNovoUsuario');
        let senha = $('#txtNovaSenha');

        if (user.val() == "") {
            MensagemErroPersonalizada("Por favor digite o usuário");
            user.focus();
        } else if (senha.val() == "") {
            MensagemErroPersonalizada("Por favor digite a senha");
            senha.focus();
        } else {
            return true;
        }

        return false;
    }
});