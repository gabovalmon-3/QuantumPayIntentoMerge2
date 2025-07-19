// wwwroot/js/pages/Transacciones.js
function TransaccionesViewController() {
    this.Api = "Transaccion"; // /api/transacciones

    this.initView = function () {
        console.log("Transacciones init → OK");
        this.loadTable();
    };

    this.loadTable = function () {
        var ca = new ControlActions();
        var type = $('#Context').data('type');
        var id = $('#Context').data('id');
        var url = ca.GetUrlApiService(this.Api + "/" + type + "/" + id);

        if (!$.fn.dataTable.isDataTable('#tblTransacciones')) {
            $('#tblTransacciones').DataTable({
                processing: true,
                ajax: { url: url, dataSrc: '' },
                columns: [
                    { data: 'id' },
                    { data: type === 'banco' ? 'idCuentaComercio' : 'idCuentaBancaria' },
                    { data: 'monto' },
                    { data: 'comision' },
                    { data: 'descuentoAplicado' },
                    { data: 'fecha' },
                    { data: 'metodoPago' }
                ]
            });
        } else {
            $('#tblTransacciones').DataTable().ajax.url(url).load();
        }
    };
}

$(document).ready(function () {
    new TransaccionesViewController().initView();
});
