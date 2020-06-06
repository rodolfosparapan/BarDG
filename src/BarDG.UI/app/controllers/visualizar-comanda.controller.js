app.controller("VisualizarComandaCtrl", function($scope, $location, vendasApi, session, vendaEnum) {
    
    $scope.vendaEnum = vendaEnum;
    $scope.numeroComanda = session.vendaId > 0 ? session.vendaId.toString().padStart(4,'0') : '(Nova)';
    $scope.statusVenda = session.vendaStatus;
    carregarComanda();

    function carregarComanda() {
        vendasApi.obterComanda(session.vendaId).then(
            function(response) {
                if(response.data.length){
                    $scope.comandaItens = response.data;
                    calcularTotal(response.data);
                }
            },
            function(erro) {
                alertify.alert(erro.data);
            }
        );
    }

    function calcularTotal(comandaItens){
        let total = 0;
        for (var item in comandaItens) {
            total += comandaItens[item].total;
        }
        $scope.comandaTotal = total;
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
                session.vendaStatus = response.data;
                alertify.alert("Comanda finalizada com sucesso!");
                $location.path('home');
            },
            function(erro) {
                alertify.alert(erro.data);
            }
        );
    }
});