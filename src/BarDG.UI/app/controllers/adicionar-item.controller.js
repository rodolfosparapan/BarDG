app.controller("AdicionarItemCtrl", function($scope, $location, vendasApi, produtosApi, session) {
    
    $scope.numeroComanda = session.vendaId > 0 ? session.vendaId.toString().padStart(4,'0') : '(Nova)';
    $scope.produtos = [];

    $scope.adicionarItem = function(produto) {
        
        let novoItem = {
            vendaId: session.vendaId,
            produtoId: produto.id,
            quantidade: produto.quantidade,
        };
        
        vendasApi.adicionarItem(novoItem).then(function(response){
                session.vendaId = response.data.vendaId;

                if(response.data.brindes.length){
                    let produtoBrinde = response.data.brindes[0];

                    alertify.confirm("Brinde: " + produtoBrinde.produtoDescricao + "! Adicionar?",
                    function(){
                        novoItem.produtoId = produtoBrinde.produtoId;
                        novoItem.quantidade = produtoBrinde.quantidade;
                        vendasApi.adicionarItem(novoItem).then(function(response){
                            $location.path("visualizar-comanda");
                        }, function(erro){
                            alertify.alert(erro.data);
                        });
                    });
                }else{
                    $location.path("visualizar-comanda");
                }
            },
            function(erro){
                alertify.alert(erro.data.erros ? erro.data.erros[0] : erro.data);
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