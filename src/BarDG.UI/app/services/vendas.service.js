angular.module('app').factory('vendasApi', function ($http, config, session){
    
    $http.defaults.headers.common['Authorization'] = 'Bearer ' + session.token;

    var _adicionarItem = function (Item) {
        return $http({
            method: "POST",
            url: config.baseUrl + "/vendas/adicionarItem",
            data: Item
        });
    };

    var _finalizarComanda = function (vendaId) {
        return $http({
            method: "POST",
            url: config.baseUrl + "/vendas/finalizar",
            params: { vendaId }
        });
    };

    var _resetarComanda = function (vendaId) {
        return $http({
            method: "PUT",
            url: config.baseUrl + "/vendas/resetar",
            params: { vendaId }
        });
    };

    var _obterComanda = function (vendaId) {
        return $http({
            method: "GET",
            url: config.baseUrl + "/vendas/comanda",
            params: { vendaId }
        });
    };

    var _obter  = function (vendaId) {
        return $http({
            method: "GET",
            url: config.baseUrl + "/vendas",
            params: { vendaId }
        });
    };

    var _removerItem  = function (vendaItemId) {
        return $http({
            method: "DELETE",
            url: config.baseUrl + "/vendas/removerItem",
            params: { vendaItemId }
        });
    };

    return{
        adicionarItem: _adicionarItem,
        finalizarComanda: _finalizarComanda,
        resetarComanda: _resetarComanda,
        obterComanda: _obterComanda,
        obter: _obter,
        removerItem: _removerItem
    };
});