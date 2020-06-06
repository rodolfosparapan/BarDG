angular.module('app').factory('usuariosApi', function ($http, config){
    
    var _login = function (login) {

        console.log(login);

        return $http({
            method: "POST",
            url: config.baseUrl + "/usuarios/login",
            data: login
        });
    };

    return{
        login: _login
    };
});