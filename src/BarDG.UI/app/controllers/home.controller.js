app.controller("HomeCtrl", function($scope, $location, session, vendasApi, vendaEnum) {
    
    $scope.iniciar = function(){

        let vendaId = parseInt($scope.numeroComanda);
        vendasApi.obter(vendaId).then(function(retorno){
            if(retorno.data){
                session.vendaId = retorno.data.id;
                session.vendaStatus = retorno.data.status;
                $location.path("adicionar-item");
            }
            else{
                alertify.alert("Comanda não encontrada");
            }
        });
    };

    $scope.novaComanda = function(){
        session.vendaId = 0;
        session.vendaStatus = vendaEnum.emAberto;
        $location.path("adicionar-item");
    };
});