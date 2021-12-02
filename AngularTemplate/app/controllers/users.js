app.controller("users",function($scope,$http,ajax){
    //$scope.fname = "Tanvir";
    $http.get("https://localhost:44327/api/users").then(function (response){
        $scope.users = response.data;
    },function(error){

    });
    /*function success(rsp){
        $scope.users = rsp.data;
    }
    function error(err){

    }
    ajax.get("https://localhost:44327/api/users",success,error);*/

});
