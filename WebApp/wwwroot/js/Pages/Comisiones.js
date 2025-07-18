// wwwroot/js/pages/Comisiones.js

function ComisionesViewController() {
    this.ApiController = "comisiones";

    this.initView = function () {
        console.log("Comisiones view initialized");
        this.loadTable();
        this.bindRowClick();
    }

    this.loadTable = function () {
        var ca = new ControlActions();
        ca.FillTable(this.ApiController, "tblComisiones", false);
    }

    this.bindRowClick = function () {
        var table = $('#tblComisiones').DataTable();
        $('#tblComisiones tbody').on('click', 'tr', function () {
            var data = table.row(this).data();
            // Asume campos en tu formulario Create/Edit:
            $('#txtId').val(data.id);
            $('#txtIdInstitucionBancaria').val(data.idInstitucionBancaria);
            $('#txtIdCuentaComercio').val(data.idCuentaComercio);
            $('#txtPorcentaje').val(data.porcentaje);
            $('#txtMontoMaximo').val(data.montoMaximo);
        });
    }
}

$(document).ready(function () {
    var vc = new ComisionesViewController();
    vc.initView();
});
