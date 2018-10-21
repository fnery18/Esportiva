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


    $(document).on('click', 'a[data-opcao="novo-acontecimento"]', function () {
        $('#codigo-partida').val($(this).data("id"));
        $('#codigo-time-acontecimento').val($(this).data("id-time"));

        $('#info-partida').text($(this).data("nome-partida"));
        $('#modal-acontecimento').modal();
    });

    $(document).on('click', '#btn-salvar-acontecimento', function () {
        if(validaCamposAcontecimentos()){
            $.post("/Administrativo/CadastrarAcontecimento/", {
                "Jogador_Id": $('#select-jogadores').val(),
                "Partida_Id": $('#codigo-partida').val(),
                "Tempo": $('#txtTempo').val(),
                "Time_Id": $('#codigo-time-acontecimento').val(),
                "TipoAcontecimento_Id": $('#select-tipo-acontecimento').val()
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

    const validaCamposAcontecimentos = function () {
        let jogador = $('#select-jogadores');
        let tempo = $('#txtTempo');
        let tipo = $('#select-tipo-acontecimento');

        if(jogador.val() == 0){
            MensagemErroPersonalizada("Por favor escolha um jogador");
            jogador.focus();
        } else if(tempo.val() == ""){
            MensagemErroPersonalizada("Por favor digite o minuto");
            tempo.focus();
        } else if (!(eval(tempo.val()) >= 1 && eval(tempo.val()) <= 100)) {
            MensagemErroPersonalizada("Por favor digite o minuto entre 1 e 100");
            tempo.focus();
        } else if (tipo.val() == 0) {
            MensagemErroPersonalizada("Por favor escolha o tipo do acontecimento");
            tipo.focus();
        } else
            return true;

        return false;
    }






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