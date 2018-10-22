$(function () {
    var codigoTime = $('#codigo-time').val();


    $.get(`/Escalacao/RetornarRelatorios?codigoTime=${codigoTime}`, function (retorno) {
        var ctx = $('#acontecimentos').get(0).getContext("2d");
        var data = {
            datasets: [{
                data: retorno.Quantidade,
                backgroundColor: retornaCores(retorno.Quantidade.length)
            }],

            labels: retorno.Nome
        };

        var myDoughnutChart = new Chart(ctx, {
            type: 'doughnut',
            data: data
        });
    })

    retornaCores = function (quantidade) {
        var cores = [];

        for (var i = 1; i < quantidade; i++) {
            
            cores.push('#' + Math.floor(Math.random() * 16777215).toString(16));
        }

        return cores;
    }
});