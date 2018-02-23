$(function () {
    geral.acoes.maskPhone();
});

var geral = {
    acoes: {
        maskPhone: function (){
            var behavior = function (val) {
                return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
            },
            options = {
                onKeyPress: function (val, e, field, options) {
                    field.mask(behavior.apply({}, arguments), options);
                }
            };

            $('.telefone').mask(behavior, options);
        }
    }
}

var urlHelper = {
    adicionarParametrosNaUrl: function (urlBase, parametros) {
        var parametrosFormatados = [];
        if (parametros) {
            for (var parametro in parametros) {
                parametrosFormatados.push(parametro + '=' + encodeURIComponent(parametros[parametro]));
            }
            urlBase += '?' + parametrosFormatados.join('&');
        }
        return urlBase;
    }
}   