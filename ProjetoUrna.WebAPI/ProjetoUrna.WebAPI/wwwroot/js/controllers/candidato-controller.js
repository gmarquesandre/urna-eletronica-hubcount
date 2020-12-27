angular.module('urnaEletronica').controller('CandidatoController', function($scope, $http){

    
    $scope.candidatos = []
    $scope.filtro = '';

	$http.get('/api/values/Candidate/'+filtro)
	.success(function(candidatos){
		$scope.candidatos = candidatos;
		console.log(candidatos);
	})
	.error(function(erro){
		console.log(erro);
	});
});