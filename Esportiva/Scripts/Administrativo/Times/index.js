$(function () {
    $('a').tooltip();

    $(document).on('click', '#btn-novo-time', function () {
        $('#modal-time').modal();
    });

    $(document).on('click', '#btn-salvar-time', function () {
        if (validaCamposTime()) {
            $.post("/Administrativo/CadastrarTime/", {
                "Nome": $("#txtNome").val(),
                "Sigla": $("#txtSigla").val(),
                "Cor1": $("#txtCor1").val(),
                "Cor2": $("#txtCor2").val(),
                "Cor3": $("#txtCor3").val(),
                "Nacionalidade": $("#txtNacionalidade").val(),
                "DataFundacao": $("#txtFundacao").val(),
                "nomeAntigo": $('#txtNomeAntigo').val()
            }, function (retorno) {
                if (retorno.Sucesso) {
                    $("#meus-times").load("/Administrativo/Time/ #meus-times");
                    $('.close').trigger('click');
                    MensagemSucesso(retorno.Mensagem);
                    $('#btn-novo-time').remove();

                    setTimeout(function () {
                        location.reload();
                    }, 1000)

                } else {
                    MensagemErroPersonalizada(retorno.Mensagem);
                }
            })

        }
    });

    $(document).on('click', 'a[data-opcao="excluir-time"]', function () {
        $('#id-time').val($(this).data("id"));
        $('#modal-excluir').modal();
    });

    $(document).on('click', '#btn-excluir-time', function () {
        excluirTime($('#id-time').val());
    });

    const excluirTime = function (id) {
        $.post("/Administrativo/ExcluirTime/", {
            "codigoTime": id
        }, function (retorno) {
            if (retorno.Sucesso) {
                $("#meus-times").load("/Administrativo/Time/ #meus-times");
                $('.close').trigger('click');
                MensagemSucesso("Time Excluido com sucesso!");
                $('#qtd-time').val(eval($('#qtd-time').val() - 1));
                if ($('#qtd-time').val() === '0') {
                    location.reload();
                }
            }
            else {
                MensagemErro();
            }
        })
    }

    const validaCamposTime = function () {
        let nome = $('#txtNome');
        let nacionalidade = $('#txtNacionalidade');
        let fundacao = $('#txtFundacao');
        let sigla = $('#txtSigla');

        if (nome.val() == "") {
            MensagemErroPersonalizada("Por favor digite o nome");
            nome.focus();
        } else if (nacionalidade.val() == "") {
            MensagemErroPersonalizada("Por favor digite a nacionalidade");
            nacionalidade.focus();
        } else if (fundacao.val() == "") {
            MensagemErroPersonalizada("Por favor digite a data de fundação");
            fundacao.focus();
        } else if (sigla.val() == "") {
            MensagemErroPersonalizada("Por favor digite a sigla");
            sigla.focus();
        } else if (sigla.val().length > 4) {
            MensagemErroPersonalizada("Por favor digite uma sigla de até 4 caracteres");
            sigla.focus();
        } else {
            return true;
        }

        return false;
    }
});