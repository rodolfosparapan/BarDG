app.controller("VisualizarComandaCtrl", function($scope, $location, vendasApi, session) {
    
    $scope.numeroComanda = session.vendaId > 0 ? session.vendaId.toString().padStart(4,'0') : '(Nova)';
    carregarComanda();

    function carregarComanda() {
        vendasApi.obterComanda(session.vendaId).then(
            function(response) {
                $scope.comandaItens = response.data;
            },
            function(erro) {
                alertify.alert(erro.data);
            }
        );
    }

    $scope.limparComanda = function(){
        vendasApi.resetarComanda(session.vendaId).then(
            function(response) {
                alertify.alert("Comanda Reiniciada!");
                $location.path('adicionar-item');
            },
            function(erro) {
                alertify.alert(erro.data);
            }
        );
    }

    $scope.finalizarComanda = function(){
        vendasApi.finalizarComanda(session.vendaId).then(
            function(response) {
                alertify.alert("Comanda finalizada com sucesso!");
                $location.path('home');
            },
            function(erro) {
                alertify.alert(erro.data);
            }
        );
    }
});