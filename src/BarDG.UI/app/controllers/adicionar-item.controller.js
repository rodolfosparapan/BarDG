app.controller("AdicionarItemCtrl", function($scope, $location, vendasApi, produtosApi, session, vendaEnum) {
    
    $scope.vendaEnum = vendaEnum;
    $scope.numeroComanda = session.vendaId > 0 ? session.vendaId.toString().padStart(4,'0') : '(Nova)';
    $scope.statusVenda = session.vendaStatus;
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
                    validarBrinde(response.data.brindes[0]);
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

    function validarBrinde(produtoBrinde){
        alertify.confirm("Brinde: " + produtoBrinde.produtoDescricao + "! Adicionar?",
            function(){
                $location.path("visualizar-comanda");
            },
            function(){
                removerItem(produtoBrinde.vendaItemId, false);
            }
        );
    }

    function removerItem(vendaItemId, mostrarMsgSucesso) {
        vendasApi.removerItem(vendaItemId).then(function(retorno){
            if(retorno.data){
                if(mostrarMsgSucesso)
                    alertify.alert("item removido com sucesso");
                
                $location.path("visualizar-comanda");
            }
        }, function(erro){
            alertify.alert(erro.data.erros ? erro.data.erros[0]: erro.data);
        });
    };
});