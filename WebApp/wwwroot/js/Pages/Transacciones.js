// wwwroot/js/pages/Transacciones.js

function TransaccionesViewController() {
    this.ApiController = "transacciones";

    this.initView = function () {
        console.log("Transacciones view initialized");
        // Lee el ID de un input hidden que debes añadir en tus .cshtml:
        // <input type="hidden" id="ContextId" value="@Model.IdBanco" />
        var ctx = $('#Context').data('type');      // "banco" o "comercio"
        var id = $('#Context').data('id');        // número

        if (ctx && id) {
            this.loadTable(ctx, id);
        }
    }

    this.loadTable = function (context, id) {
        var ca = new ControlActions();
        var service = this.ApiController + "/" + context + "/" + id;
        ca.FillTable(service, "tblTransacciones", false);
    }
}

$(document).ready(function () {
    var vc = new TransaccionesViewController();
    vc.initView();
});
