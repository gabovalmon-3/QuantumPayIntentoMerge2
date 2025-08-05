//js que maneja todas las vistas del administrador

function AdminHomeViewController(){
    this.ViewName = "AdminHome";
    this.ApiEndpointname = "";

    this.InitView = function () {
        console.log("AdminHome Init View --> ok");
    }
}

$(document).ready(function () {
    var vc = new AdminHomeViewController();
    vc.InitView();
})