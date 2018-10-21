$(function () {

    $(document).on('click', 'i[data-opcao="editar-time"]', function () {
        $('#txtNomeAntigo').val($(this).data("nome"));
        $('#txtNome').val($(this).data("nome"));
        $('#txtNacionalidade').val($(this).data("nacionalidade"));
        $('#txtFundacao').valueAsDate = new Date($(this).data("fundacao"));
        $('#txtSigla').val($(this).data("sigla"));
        $('#txtCor1').val($(this).data("cor1"));
        $('#txtCor2').val($(this).data("cor2"));
        $('#txtCor3').val($(this).data("cor3"));

        $('#modal-time').modal();
    });

    $(document).on('click', '#btn-jogadores', function () {
        let codigo = $('#codigo-time').val();
        window.location.href = `/Escalacao/Jogadores?codigoTime=${codigo}`
    });

    $(document).on('click', '#btn-partidas', function () {
        let codigo = $('#codigo-time').val();
        window.location.href = `/Administrativo/Partidas?codigoTime=${codigo}`
    });

    $(document).on('click', '#btn-relatorios', function () {
        let codigo = $('#codigo-time').val();
        window.location.href = `/Escalacao/Jogadores?codigoTime=${codigo}`
    });

    $(document).on('click', '#btn-adversarios', function () {
        let codigo = $('#codigo-time').val();
        window.location.href = `/Escalacao/Adversarios/`
    });
})