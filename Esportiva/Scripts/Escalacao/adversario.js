$(function () {
    $(document).on('click', '#btn-novo-adversario', function () {
        $('#cores-time').hide();
        $('#modal-time').modal();
    });
    $(document).on('click', 'a[data-opcao="excluir-adversario"]', function () {
        var id = $(this).data('id');
        $('#id-time-exclusao').val(id);
        $('#modal-excluir').modal();
    });

    $(document).on('click', '#btn-excluir-time', function () {
        $.post("/Administrativo/ExcluirTime/", {
            "codigoTime": $('#id-time-exclusao').val(),
            "adversario": true
        }, function (retorno) {
            if (retorno.Sucesso) {
                $("#partial-adversarios").load(`/Escalacao/Adversarios?codigoTime=${$('#codigo-time').val()} #partial-adversarios`);
                $('.close').trigger('click');
                MensagemSucesso("Time Excluido com sucesso!");
                habilitaTooltip();
            }
            else {
                MensagemErro();
            }
        })
    });


    
    $(document).on('click', '#btn-salvar-time', function () {
        if(validaCampos()){
            $.post("/Administrativo/CadastrarTime/", {
                "Nome": $("#txtNome").val(),
                "Sigla": $("#txtSigla").val(),
                "Nacionalidade": $("#txtNacionalidade").val(),
                "DataFundacao": $("#txtFundacao").val(),
                "nomeAntigo": null,
                "Adversario": true,
                "Cor1": '#000',
                "Cor2": '#000',
                "Cor3": '#000',
            }, function (retorno) {
                if (retorno.Sucesso) {
                    $("#partial-adversarios").load(`/Escalacao/Adversarios?codigoTime=${$('#codigo-time').val()} #partial-adversarios`);
                    $('.close').trigger('click');
                    MensagemSucesso(retorno.Mensagem);
                    habilitaTooltip();
                } else {
                    MensagemErroPersonalizada(retorno.Mensagem);
                }
            })
        }
    });

    const validaCampos = function () {
        var nome = $('#txtNome');
        var dataF = $('#txtFundacao');
        var nacionalidade = $('#txtNacionalidade');
        var sigla = $('#txtSigla');

        if (nome.val() == "") {
            MensagemErroPersonalizada("Por favor digite o nome");
            nome.focus();
        } else if (dataF.val() == "") {
            MensagemErroPersonalizada("Por favor digite a data");
            dataF.focus();
        } else if (nacionalidade.val() == "") {
            MensagemErroPersonalizada("Por favor digite a nacionalidade");
            nacionalidade.focus();
        } else if (sigla.val() == "") {
            MensagemErroPersonalizada("Por favor digite a sigla");
            sigla.focus();
        } else
            return true;

        return false;
    }    
})