$(function () {
    jogo.acoes.click();
});

var jogo = {
    acoes: {
        click: function () {
            this.detalharJogoAmigo();            
        },
        detalharJogoAmigo: function () {
            var parametro = { id: window.modelJogo.IdJogo };
            var urlComParametro = window.urlHelper.adicionarParametrosNaUrl(app.Urls.urlDetalharJogoAmigo, parametro);

            $("#detalharJogoAmigo").on("click", function () {               
                $.ajax({
                    url: urlComParametro,
                    type: "GET",
                    dataType: "html",
                    success: function (data) {
                        $("#containerModal").html(data);
                        $("#modalDetalharJogoComAmigo").modal("show");
                    }
                });
            });
        }        
    }
};