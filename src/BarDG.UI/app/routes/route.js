app.config(function($routeProvider) {
    
    $routeProvider
        .when("/", {
            templateUrl: "app/views/login.html",
            controller: "LoginCtrl"
        })

        .when("/home", {
            templateUrl: "app/views/home.html",
            controller: "HomeCtrl",
            requireAuth: true
        })

        .when("/adicionar-item", {
            templateUrl: "app/views/adicionar-item.html",
            controller: "AdicionarItemCtrl",
            requireAuth: true
        })

        .when("/visualizar-comanda", {
            templateUrl: "app/views/visualizar-comanda.html",
            controller: "VisualizarComandaCtrl",
            requireAuth: true
        })

        .otherwise({ redirectTo: "/" });
});