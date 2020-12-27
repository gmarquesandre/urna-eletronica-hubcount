angular.module('urnaEletronica', ['minhasDiretivas', 'ngRoute'])
    .config(function ($routeProvider, $locationProvider) {

        $locationProvider.html5Mode(true);
        $locationProvider.hashPrefix('');
        $routeProvider.when('/voto-prefeito', {
            templateUrl: '/partials/voto-prefeito.html',
            controller: 'CandidatosController'
        })
            .when('/voto-vereador', {
                templateUrl: '/partials/voto-vereador.html',
                controller: 'CandidatosController'
            })
            .when('/fim-voto', {
                templateUrl: '/partials/fim-voto.html',
                controller: 'CandidatosController'
            })           .when('/tabela-candidatos', {
                templateUrl: '/partials/tabela-candidatos.html',
                controller: 'CandidatosController'
            })
            .when('/pagina-votos', {
                templateUrl: '/partials/pagina-votos.html',
                controller: 'VotosController'
            }).when('/adicionar-candidato', {
                templateUrl: '/partials/adicionar-candidato.html',
                controller: 'AddCandidatoController'
            }).when('/editar-candidato', {
                templateUrl: '/partials/editar-candidato.html',
                controller: 'EditCandidato'
            })
        //.$routeProvider.when('/tabela', {
        //    templateUrl: '/partials/voto-prefeito.html',
        //    controller: 'CandidatosController'
        //})
            .otherwise({ redirectTo: '/voto-prefeito' });

    });