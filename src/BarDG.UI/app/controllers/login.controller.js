app.controller("LoginCtrl", function($scope, $location, session, usuariosApi) {
    
    $scope.login = function() {
        
        usuariosApi.login($scope.dadosLogin).then(function(response){                   
                session.usuario = response.data.email,
                session.token = response.data.token;
                $location.path('/home');
            },
            function(error){
                $scope.errorMessage = "Ocorreu um erro ao realizar o login:" + error
            }
        );
    };
});