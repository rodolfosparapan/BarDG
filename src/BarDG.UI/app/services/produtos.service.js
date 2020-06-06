angular.module('app').factory('produtosApi', function ($http, config){
    
    var _listar = function () {

        return $http({
            method: "GET",
            url: config.baseUrl + "/produtos"
        });
    };

    return{
        listar: _listar
    };
});