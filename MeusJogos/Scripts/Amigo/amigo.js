$(function () {
    amigo.acoes.click();    
});

var amigo = {
    acoes: {
        click: function () {
            this.detalharListaJogosAmigo();            
        },
        detalharListaJogosAmigo: function () {
            var parametro = { id: window.modelAmigo.IdAmigo };
            var urlComParametro = window.urlHelper.adicionarParametrosNaUrl(app.Urls.urlListarJogosAmigo, parametro);

            $("#detalharJogoAmigo").on("click", function () {               
                $.ajax({
                    url: urlComParametro,
                    type: "GET",
                    dataType: "html",
                    success: function (data) {
                        $("#containerModal").html(data);
                        $("#modalJogosComAmigo").modal("show");
                    }
                });
            });
        }        
    }
};