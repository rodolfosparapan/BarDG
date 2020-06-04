app.config(function($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "app/views/home.html",
            controller: "HomeCtrl"
        })

        .when("/adicionar-item", {
            templateUrl: "app/views/adicionar-item.html",
            controller: "AdicionarItemCtrl"
        })

        .when("/resultados", {
            templateUrl: "app/views/visualizar-comanda.html",
            controller: "VisualizarComandaCtrl"
        })

        .otherwise({ redirectTo: "/" });
});