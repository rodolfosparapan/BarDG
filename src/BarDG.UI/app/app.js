var app = angular.module("app", ["ngRoute"])
.controller('RootController', function ($scope, $location, session) {

    $scope.$on('$routeChangeStart', function (angularEvent, newUrl) {

        if (newUrl.requireAuth && !session.usuario) {
            $location.path("login");
        }
    });

    $scope.logout = function()
    {
        session.usuario = null;
        session.token = null;
        $location.path("login");
    };
});

alertify.defaults.glossary = {
    title:'Mensagem',
    ok: 'OK',
    cancel: 'Cancel'   
};