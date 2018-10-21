$(function () {
    habilitaTooltip();
});

const habilitaTooltip = function () {
    $('.habilita-tooltip').tooltip();
}

function esconderAlerts() {
    setTimeout(function () {
        $(".alert").fadeOut("slow")
    }, 5000)
}

function mostrarMensagem(n, t, i, r) {
    $("#alert-helper").html("<div style='display:none;' class='alert alert-" + r + " alert-dismissable erro-dashboard' style='z-index:9999999999;'><i class='fa fa-" + i + "'><\/i><button aria-hidden='true' data-dismiss='alert' class='close' type='button'>×<\/button>" + n + "<\/div>");
    $("#alert-helper .alert").fadeIn("slow");
    esconderAlerts()
}

function MensagemErroPersonalizada(n, t) {
    mostrarMensagem(n, t, "ban", "danger")
}

function MensagemErro(n) {
    mostrarMensagem("Ops! Ocorreu um erro.", n, "ban", "danger")
}

function MensagemSucesso(n, t) {
    mostrarMensagem(n, t, "check", "success")
}