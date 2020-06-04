angular.module('app').factory('vendasApi', function ($http, config){
    
    var _adicionarItem = function (Item) {
        return $http({
            method: "POST",
            url: config.baseUrl + "/adicionarItem",
            data: Item
        });
    };

    var _finalizarComanda = function () {
        return $http({
            method: "POST",
            url: config.baseUrl + "/finalizar"
        });
    };

    var _resetarComanda = function () {
        return $http({
            method: "PUT",
            url: config.baseUrl + "/resetar"
        });
    };

    var _obterComanda = function () {
        return $http({
            method: "GET",
            url: config.baseUrl + "/comanda"
        });
    };

    return{
        adicionarItem: _adicionarItem,
        finalizarComanda: _finalizarComanda,
        resetarComanda: _resetarComanda,
        obterComanda: _obterComanda
    };
});