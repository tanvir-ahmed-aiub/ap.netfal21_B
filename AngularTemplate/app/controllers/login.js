app.controller("login",function($scope,ajax,$window){
    localStorage.setItem('demo','ok');
    $scope.data = localStorage.getItem('demo');
   // $scope.token = $localStorage.get('token');
   debugger;
   //$scope.token = $window.sessionStorage.token;
    $scope.lsubmit=function(){
        ajax.post("https://localhost:44327/api/login",$scope.user,function(resp){
            console.log(resp.data);
            $window.sessionStorage.token= resp.data.AccessToken;
        },function(err){

        });
    };
});
