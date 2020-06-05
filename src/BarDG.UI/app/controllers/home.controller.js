app.controller("HomeCtrl", function($scope, $location, session, vendasApi) {
    
    $scope.iniciar = function(){

        let vendaId = parseInt($scope.numeroComanda);
        vendasApi.obter(vendaId).then(function(retorno){
            if(retorno.data){
                session.vendaId = vendaId;
                $location.path("adicionar-item");
            }
            else{
                alert("Comanda não encontrada");
            }
        });
    };

    $scope.novaComanda = function(){
        session.vendaId = 0;
        $location.path("adicionar-item");
    };
});