angular.module('urnaEletronica').controller('PostVoteController', function($scope, $http){

    
    $scope.candidatos = []
    $scope.filter = ''

    $http.post('/api/values/PostVote/', { id }, { codigoVoto })
	.success(function(candidatos){
		$scope.candidatos = candidatos;
		console.log(candidatos);
	})
	.error(function(erro){
		console.log(erro);
	});
});