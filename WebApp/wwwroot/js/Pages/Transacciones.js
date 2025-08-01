function TransaccionesViewController() {
    const ca = new ControlActions();
    this.Api = "Transaccion";
    this.getClienteId = function () {
        return parseInt($("#hdnClienteId").val() || "0", 10);
    };


    this.initView = function () {
        this.loadTable();
        this.bindEvents();
        console.log("Transacciones init → OK");
    };

    this.loadTable = function () {
        const filtro = $('#transaccionFiltro').val();
        const valor = $('#filtroValor').val();
        let endpoint = `${this.Api}/RetrieveAll`;

        if (filtro === "banco" && valor) {
            endpoint = `${this.Api}/RetrieveByBanco?iban=${valor}`;
        } else if (filtro === "comercio" && valor) {
            endpoint = `${this.Api}/RetrieveByComercio?idComercio=${valor}`;
        }

        const url = ca.GetUrlApiService(endpoint);

        if (!$.fn.dataTable.isDataTable('#tblTransacciones')) {
            $('#tblTransacciones').DataTable({
                processing: true,
                ajax: {
                    url: url,
                    dataSrc: function (json) {
                        console.log("Respuesta API →", json);
                        return json;
                    },
                    error: function (xhr, status, error) {
                        console.error("Error AJAX DataTable:", status, error);
                        console.log("Response text:", xhr.responseText);
                    }
                },
                columns: [
                    { data: 'id' },
                    { data: 'idCuentaBancaria' },
                    { data: 'iban' },                // muestra también la columna IBAN
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
        $('#btnBuscar').click(() => this.loadTable());

        $('#transaccionFiltro').change(function () {
            if (this.value === 'all') {
                $('#filtroValor').val('');
            }
        });

        $('#btnCreate').click(() => {
            const cuentaVal = $('#txtIdCuentaBancaria').val();
            const dto = {
                idCuentaCliente: this.getClienteId(),
                idCuentaBancaria: /^\d+$/.test(cuentaVal) ? parseInt(cuentaVal, 10) : 0,
                iban: $('#IBAN').val(),
                idCuentaComercio: parseInt($('#txtIdCuentaComercio').val(), 10),
                monto: parseFloat($('#txtMonto').val()),
                comision: parseFloat($('#txtComision').val()),
                descuentoAplicado: parseFloat($('#txtDescuentoAplicado').val()),
                fecha: $('#txtFecha').val(),
                metodoPago: $('#txtMetodoPago').val()
            };
            const email = $('#txtEmail').val();
            ca.PostToAPI(
                `${this.Api}/Create?email=${encodeURIComponent(email)}`,
                dto,
                () => { window.location.href = '/ClientesPages/ClienteHome'; }
            );
        });

        $('#btnUpdate').click(() => {
            const id = parseInt($('#txtId').val(), 10);
            const cuentaValUp = $('#txtIdCuentaBancaria').val();
            const dto = {
                id: id,
                idCuentaCliente: this.getClienteId(),
                idCuentaBancaria: /^\d+$/.test(cuentaValUp) ? parseInt(cuentaValUp, 10) : 0,
                iban: $('#IBAN').val(),
                idCuentaComercio: parseInt($('#txtIdCuentaComercio').val(), 10),
                monto: parseFloat($('#txtMonto').val()),
                comision: parseFloat($('#txtComision').val()),
                descuentoAplicado: parseFloat($('#txtDescuentoAplicado').val()),
                fecha: $('#txtFecha').val(),
                metodoPago: $('#txtMetodoPago').val()
            };
            ca.PutToAPI(`${this.Api}/Update/${id}`, dto, () => this.loadTable());
        });

        $('#btnDelete').click(() => {
            const id = parseInt($('#txtId').val(), 10);
            ca.DeleteToAPI(`${this.Api}/Delete/${id}`, {}, () => this.loadTable());
        });

$('#tblTransacciones tbody').on('click','tr', function(){
  const data = $('#tblTransacciones').DataTable().row(this).data();
  $('#txtIdCuentaBancaria').val(data.idCuentaBancaria);
  $('#IBAN').val(data.iban);
            $('#txtIdCuentaComercio').val(data.idCuentaComercio);
            $('#txtMonto').val(data.monto);
            $('#txtComision').val(data.comision);
            $('#txtDescuentoAplicado').val(data.descuentoAplicado);
            $('#txtFecha').val(data.fecha);
            $('#txtMetodoPago').val(data.metodoPago);
        });
    };
}

$(document).ready(() => {
    new TransaccionesViewController().initView();
});
