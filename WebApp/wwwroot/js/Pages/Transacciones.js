// wwwroot/js/pages/Transacciones.js
function TransaccionesViewController() {
    const ca = new ControlActions();
    const self = this;

    this.Api = "Transaccion";

    this.initView = function () {
        this.loadTable(); // Carga por defecto "todas"
        this.bindEvents();
        console.log("Transacciones init → OK");
        this.loadTable();
    };

    this.loadTable = function () {
        const filtro = $('#transaccionFiltro').val();
        const valor = $('#filtroValor').val();

        let endpoint = "";
        if (filtro === "banco" && valor) {
            endpoint = `Transaccion/RetrieveByBanco?iban=${valor}`;
        } else if (filtro === "comercio" && valor) {
            endpoint = `Transaccion/RetrieveByComercio?idComercio=${valor}`;
        } else {
            endpoint = `Transaccion/RetrieveAll`;
        }
        const url = ca.GetUrlApiService(endpoint);

        if (!$.fn.dataTable.isDataTable('#tblTransacciones')) {
            $('#tblTransacciones').DataTable({
                processing: true,
                ajax: { url: url, dataSrc: '' },
                columns: [
                    { data: 'id' },
                    { data: 'idCuentaBancaria' },
                    { data: 'idCuentaComercio' },
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

    this.bindEvents = function () {
        var self = this;
        // Botón para recargar según el filtro
        $('#btnBuscar').click(function () {
            self.loadTable();
        });

        // Recargar automáticamente al cambiar el filtro (opcional)
        $('#transaccionFiltro').change(function () {
            if ($(this).val() === "all") {
                $('#filtroValor').val('');
            }
        });

        // CRUD (igual que antes)
        $('#btnCreate').click(function () {
            var dto = {
                idCuentaBancaria: $('#txtIdCuentaBancaria').val(),
                idCuentaComercio: parseInt($('#txtIdCuentaComercio').val(), 10),
                monto: parseFloat($('#txtMonto').val()),
                comision: parseFloat($('#txtComision').val()),
                descuentoAplicado: parseFloat($('#txtDescuentoAplicado').val()),
                fecha: $('#txtFecha').val(),
                metodoPago: $('#txtMetodoPago').val()
            };
            ca.PostToAPI(self.Api + "/Create", dto, () => self.loadTable());
        });

        $('#btnUpdate').click(function () {
            var id = parseInt($('#txtId').val(), 10); // Debe estar cargado al seleccionar una fila de la tabla
            var dto = {
                id: id,
                idCuentaBancaria: $('#txtIdCuentaBancaria').val(),
                idCuentaComercio: parseInt($('#txtIdCuentaComercio').val(), 10),
                monto: parseFloat($('#txtMonto').val()),
                comision: parseFloat($('#txtComision').val()),
                descuentoAplicado: parseFloat($('#txtDescuentoAplicado').val()),
                fecha: $('#txtFecha').val(),
                metodoPago: $('#txtMetodoPago').val()
            };
            ca.PutToAPI(self.Api + "/" + id, dto, () => self.loadTable());
        });



        $('#tblTransacciones tbody').on('click', 'tr', function () {
            var data = $('#tblTransacciones').DataTable().row(this).data();
            $('#txtId').val(data.id);
            $('#txtIdCuentaBancaria').val(data.idCuentaBancaria);
            $('#txtIdCuentaComercio').val(data.idCuentaComercio);
            $('#txtMonto').val(data.monto);
            $('#txtComision').val(data.comision);
            $('#txtDescuentoAplicado').val(data.descuentoAplicado);
            $('#txtFecha').val(data.fecha);
            $('#txtMetodoPago').val(data.metodoPago);
        });
    };
}

$(document).ready(function () {
    new TransaccionesViewController().initView();
});
