function TransaccionesViewController() {
const ca = new ControlActions();
this.Api = "Transaccion";
this.ApiCuenta = "CuentaCliente";
this.ApiComercio = "Comercio";
this.getClienteId = function () {
        return parseInt($("#hdnClienteId").val() || "0", 10);
    };


    this.initView = function () {
        if ($('#tblTransacciones').length) {
            this.loadTable();
        }
        this.loadDropdowns();
        this.bindEvents();
        console.log("Transacciones init → OK");
    };

    this.loadTable = function () {
        const filtro = $('#transaccionFiltro').val();
        const valor = $('#filtroValor').val();
        let endpoint = `${this.Api}/RetrieveAll`;

        if (filtro === "banco" && valor) {
            endpoint = `${this.Api}/RetrieveByBanco?cuentaId=${valor}`;
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

    this.loadDropdowns = function () {
        const ddlCuentas = $('#ddlCuentas');
        const ddlComercios = $('#ddlComercios');
        if (ddlCuentas.length) {
            ca.GetToApi(`${this.ApiCuenta}/RetrieveAll?clienteId=${this.getClienteId()}`,(data) => {
                ddlCuentas.empty();
                data.forEach(d => ddlCuentas.append(new Option(d.numeroCuenta, d.id)));
            });
        }
        if (ddlComercios.length) {
            ca.GetToApi(`${this.ApiComercio}/RetrieveAll`, (data) => {
                ddlComercios.empty();
                data.forEach(c => ddlComercios.append(new Option(c.nombre, c.id)));
            });
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
            const cuenta = $('#ddlCuentas').length ? $('#ddlCuentas').val() : $('#txtIdCuentaBancaria').val();
            const comercio = $('#ddlComercios').length ? $('#ddlComercios').val() : $('#txtIdCuentaComercio').val();
            const dto = {
                idCuentaBancaria: parseInt(cuenta, 10),
                idCuentaComercio: parseInt(comercio, 10),
                monto: parseFloat($('#txtMonto').val()),
                metodoPago: $('#txtMetodoPago').val()
            };
            const email = $('#hdnEmail').val() || $('#txtEmail').val();
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
                idCuentaBancaria: /^\d+$/.test(cuentaValUp) ? parseInt(cuentaValUp, 10) : 0,
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
