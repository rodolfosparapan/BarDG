angular.module('app').factory('vendasApi', function ($http, config, session){
    
    $http.defaults.headers.common['Authorization'] = 'Bearer ' + session.token;

    var _adicionarItem = function (Item) {
        return $http({
            method: "POST",
            url: config.baseUrl + "/vendas/adicionarItem",
            data: Item
        });
    };

    var _finalizarComanda = function () {
        return $http({
            method: "POST",
            url: config.baseUrl + "/vendas/finalizar"
        });
    };

    var _resetarComanda = function () {
        return $http({
            method: "PUT",
            url: config.baseUrl + "/vendas/resetar"
        });
    };

    var _obterComanda = function () {
        return $http({
            method: "GET",
            url: config.baseUrl + "/vendas/comanda"
        });
    };

    return{
        adicionarItem: _adicionarItem,
        finalizarComanda: _finalizarComanda,
        resetarComanda: _resetarComanda,
        obterComanda: _obterComanda
    };
});