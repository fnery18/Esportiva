$(function () {
    $(document).on('click', '#btn-nova-partida', function () {
        limpaModal();
        $('#modal-partida').modal();
        
    });

    $(document).on('click', '#btn-salvar-partida', function () {
        if (validaCamposPartida()) {
            $.post("/Administrativo/CadastrarPartida/", {
                "NomePartida": $("#select-time option:selected").text() + ` x ` + $("#select-time-adversario option:selected").text(),
                "LocalCompeticao": $("#txtLocal").val(),
                "DataPartida": $("#txtData").val(),
                "Competicao": $("#txtCompeticao").val(),
                "IdTime2": $("#select-time-adversario").val(),
                "IdTime1": $("#select-time").val()
            }, function (retorno) {
                if (retorno.Sucesso) {
                    $("#partial-partidas").load(`/Administrativo/Partidas?codigoTime=${$("#select-time").val()} #partial-partidas`);
                    $('.close').trigger('click');
                    MensagemSucesso(retorno.Mensagem);
                } else {
                    MensagemErroPersonalizada(retorno.Mensagem);
                }
            })
        }
    });



    $(document).on('click', '#btn-excluir-partida', function () {
        $.post("/Administrativo/ExcluirPartida/", {
            "codigoPartida": $('#id-partida').val()
        }, function (retorno) {
            if (retorno.Sucesso) {
                $("#partial-partidas").load(`/Administrativo/Partidas?codigoTime=${$('#codigo-time').val()} #partial-partidas`);
                $('.close').trigger('click');
                MensagemSucesso("Partida Excluida com sucesso!");
            }
            else {
                MensagemErroPersonalizada(retorno.Mensagem);
            }
        })
    });

    $(document).on('click', 'a[data-opcao="excluir-partida"]', function () {
        $('#id-partida').val($(this).data("id"));
        $('#modal-excluir-partida').modal();
    });

    const limpaModal = function (){
        $('#txtLocal').val("");
        $('#txtData').val("");
        $('#txtCompeticao').val("");
        $('#select-time-adversario').prop('selectedIndex', 0);
        $('#select-time').prop('selectedIndex', 0);
    }

    const validaCamposPartida = function () {
        let local = $('#txtLocal');
        let dataP = $('#txtData');
        let competicao = $('#txtCompeticao');
        let adversario = $('#select-time-adversario');
        let time = $('#select-time');

        
        if (local.val() == "") {
            MensagemErroPersonalizada("Por favor digite o local");
            local.focus();
        } else if (dataP.val() == "") {
            MensagemErroPersonalizada("Por favor digite a data da partida");
            dataP.focus();
        } else if (competicao.val() == "") {
            MensagemErroPersonalizada("Por favor digite a competição");
            competicao.focus();
        }
        else if (time.val() == 0) {
            MensagemErroPersonalizada("Por favor escolha o seu time");
            time.focus();
        }
        else if (adversario.val() == 0) {
            MensagemErroPersonalizada("Por favor escolha um adversário");
            adversario.focus();
        }
        else 
            return true;

        return false;
    }
});