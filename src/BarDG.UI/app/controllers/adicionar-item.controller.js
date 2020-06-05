app.controller("AdicionarItemCtrl", function($scope, vendasApi, produtosApi) {
    
    $scope.produtos = [];
    $scope.successMessage = '';
    $scope.errorMessage = '';

    $scope.adicionarItem = function(produto) {
        vendasApi.adicionarItem(produto).then(function(response){
                if (response.data.isSuccess) {
                    $scope.successMessage = "Novo lançamento de pontos realizado com sucesso!";
                }
                else{
                    $scope.errorMessage = response.data.message;
                }
            },
            function(error){
                $scope.errorMessage = "Ocorreu um erro ao lançar os pontos da partida."
            }
        );
    };

    carregarProdutos();

    function carregarProdutos() {
        produtosApi.listar().then(
            function(response) {
                $scope.produtos = response.data;
            }
        );
    }
});