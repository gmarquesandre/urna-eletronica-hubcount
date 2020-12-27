angular.module('urnaEletronica')
    .controller('CandidatosController', function ($scope, $http,$location) {

        $scope.filtro = '';
        $scope.codigoCandidato = '';


        $scope.changePath = function (idCandidato, codigoCandidato, nomeCandidato, nomeVice, legenda, tipoCandidato) {
            console.log($location.path('/editar-candidato').search({
                id: idCandidato, codigoCandidato: codigoCandidato, nomeCandidato: nomeCandidato,
                nomeVice: nomeVice,
                legenda: legenda,
                tipoCandidato: tipoCandidato
            }));
            //optional use if not work $scope.$apply();
        };
        
        $scope.redirect = function (redirecionar) {
            console.log(redirecionar);
            window.location = redirecionar;
        };

        $scope.requestCandidato = function (codigoCandidato, min_length) {
            if (codigoCandidato.toString().length == min_length) {
                this.listaCandidatos(codigoCandidato);
            }
            else {
                $scope.candidatos = {};
            }

        };

        $scope.listaCandidatos = function (codigoCandidato) {
                if (codigoCandidato == '' | codigoCandidato == null) {
                    $scope.candidatos = []
                }
                else {
                    $scope.candidatos = {}
                };

                url = '/api/values/GetCandidates/' + codigoCandidato;
                console.log(url)
                $http.get(url)
                    .success(function (candidatos) {

                        $scope.candidatos = candidatos;
                        console.log(candidatos);
                    })
                    .error(function (erro) {
                        console.log(erro);
                    });
            
        };

       

        $scope.voto = function (id) {
            var randNumber = Math.random() * 1000;
            $scope.date = new Date();
            $scope.date = $scope.date.getFullYear() + ('0' + ($scope.date.getMonth() + 1)).slice(-2) + ('0' + $scope.date.getDate()).slice(-2)
           
            $scope.date = $scope.date.toString() + randNumber.toString();
            if (id == 0 | id == null) {
                url = '/api/values/PostVote/' + md5($scope.date)
            }
            else {
                console.log("teste2");
                url = '/api/values/PostVote/' + id + ',' + md5($scope.date);
            };
            console.log("URL = " + url);
            $http.post(url)
                .success(function (response) {
                $scope.results = response;
                })
                .error(function (erro) {
                    console.log(erro);
                })
        };

    })
    .controller('VotosController', function ($scope, $http) {

        $scope.votos = []
        $scope.filter = ''

        $http.get('/api/values/GetVote')
            .success(function (votos) {
                $scope.votos = votos;
                console.log($scope.votos);
            })
            .error(function (erro) {
                console.log(erro);
            });

        $scope.redirect = function (redirecionar) {
            console.log(redirecionar);
            window.location = redirecionar;
        };
        

    })
    .controller('AddCandidatoController', function ($scope, $http) {
        $scope.maxlength = 5;
        $scope.listOfOptions = ['Prefeito', 'Vereador']

        $scope.limpaTextos = function () {
            $scope.codigoCandidato = "";
            $scope.nomeVice = "";
        };

        $scope.add_candidato = function (codigoCandidato, nomeCandidato, legenda, nomeVice, tipoCandidato) {
            if (tipoCandidato == 'Prefeito') {
                codigo_tipo_candidato = 1
            }
            else if (tipoCandidato == 'Vereador') {
                codigo_tipo_candidato = 2
            };
            if ( nomeVice == "" | nomeVice == null) {
                nomeVice = null;
            };
            url = "/api/values/PostCandidate/" + codigoCandidato + "," + nomeCandidato + "," + legenda + "," + nomeVice + "," + codigo_tipo_candidato;
            console.log(url);
            $http.post(url)
                .success(function (response) {
                    $scope.results = response;
                })
                .error(function (erro) {
                    console.log(erro);
                })
        };

        $scope.redirect = function (redirecionar) {
            console.log(redirecionar);
            window.location = redirecionar;
        };


    })
    .controller('EditCandidato', function ($scope, $http, $location) {
        $scope.maxlength = 5;
        $scope.listOfOptions = ['Prefeito', 'Vereador']

        $scope.idCandidato = $location.search().id;
        $scope.codigoCandidato = $location.search().id;
        $scope.codigoCandidato = $location.search().codigoCandidato;
        $scope.nomeCandidato= $location.search().nomeCandidato;
        $scope.nomeVice = $location.search().nomeVice;
        $scope.legenda = $location.search().legenda;
        if ($location.search().tipoCandidato == 1) {
            $scope.tipoCandidato = 'Prefeito'
        }
        else if ($location.search().tipoCandidato == 2) {
            $scope.tipoCandidato = 'Vereador'
        }



        $scope.limpaTextos = function () {
            $scope.codigoCandidato = "";
            $scope.nomeVice = "";
        };

        $scope.editarCandidato = function (idCandidato, codigoCandidato, nomeCandidato, legenda, nomeVice, tipoCandidato) {
            if (tipoCandidato == 'Prefeito') {
                codigo_tipo_candidato = 1
            }
            else if (tipoCandidato == 'Vereador') {
                codigo_tipo_candidato = 2
            };
            if ( nomeVice == "" | nomeVice == null) {
                nomeVice = null;
            };
            url = "/api/values/EditCandidate/" + idCandidato + "," + codigoCandidato + "," + nomeCandidato + "," + legenda + "," + nomeVice + "," + codigo_tipo_candidato;
            console.log(url);
            $http.post(url)
                .success(function (response) {
                    $scope.results = response;
                })
                .error(function (erro) {
                    console.log(erro);
                })
        };

        $scope.redirect = function (redirecionar) {
            console.log(redirecionar);
            window.location = redirecionar;
        };


    })
    ;