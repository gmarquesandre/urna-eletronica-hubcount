angular.module('minhasDiretivas', [])
    .directive('minhaTabelaCandidatos', function () {
        var ddo = {};
            
        ddo.restric = "AE"; //atributo e elemento

        ddo.templateUrl = 'partials/tabela-candidatos.html';
        return ddo;
    })
    .directive('minhaTabelaVotos', function () {
        var ddo = {};

        ddo.restric = "AE"; //atributo e elemento

        ddo.templateUrl = 'partials/pagina-votos.html';
        
  
        return ddo;
    })
    .directive('votoPrefeito', function () {
  
        var ddo = {};

        ddo.restric = "AE"; //atributo e elemento

        
        ddo.templateUrl = 'partials/voto-prefeito.html'
        return ddo;

    }).directive('votoVereador', function () {

        var ddo = {};

        ddo.restric = "AE"; //atributo e elemento

        ddo.templateUrl = 'partials/voto-vereador.html'
        return ddo;

    }).directive('fimVoto', function () {

        var ddo = {};

        ddo.restric = "AE"; //atributo e elemento

        ddo.templateUrl = 'partials/fim-voto.html'
        return ddo;

    }).directive('menuFimVoto', function () {

        var ddo = {};

        ddo.restric = "AE"; //atributo e elemento

        ddo.templateUrl = 'partials/menu-fim-voto.html'
        return ddo;

    }).directive('adicionarCandidato', function () {

        var ddo = {};

        ddo.restric = "AE"; //atributo e elemento

        ddo.templateUrl = 'partials/adicionar-candidato.html'
        return ddo;
    })
        .directive('editarCandidato', function () {

        var ddo = {};

        ddo.restric = "AE"; //atributo e elemento

        ddo.templateUrl = 'partials/editar-candidato.html'
        return ddo;

    });