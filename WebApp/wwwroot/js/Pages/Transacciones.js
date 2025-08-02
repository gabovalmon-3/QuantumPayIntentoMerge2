// WebApp/wwwroot/js/pages/Transacciones.js
function TransaccionesViewController() {
    const ca = new ControlActions();
    this.Api = "Transaccion";
    this.ApiCuenta = "CuentaCliente";
    this.ApiComercio = "Comercio";

    this.getClienteId = () =>
        parseInt($("#hdnClienteId").val() || "0", 10);

    this.initView = () => {
        this.loadTable();
        this.loadDropdowns();
        this.bindEvents();
    };

    this.loadTable = () => {
        let endpoint = `${this.Api}/RetrieveAll`;

        const filtro = $("#transaccionFiltro").val();
        const valor = $("#filtroValor").val();
        if (filtro === "banco" && valor)
            endpoint = `${this.Api}/RetrieveByBanco?cuentaId=${valor}`;
        if (filtro === "comercio" && valor)
            endpoint = `${this.Api}/RetrieveByComercio?idComercio=${valor}`;

        const url = ca.GetUrlApiService(endpoint);
        const cfg = {
            processing: true,
            ajax: { url, dataSrc: "" },
            columns: [
                { data: "id" },
                { data: "idCuentaCliente" },
                { data: "idCuentaBancaria" },
                { data: "idCuentaComercio" },
                { data: "monto" },
                { data: "comision" },
                { data: "descuentoAplicado" },
                { data: "fecha" },
                { data: "metodoPago" }
            ]
        };

        if (!$.fn.dataTable.isDataTable("#tblTransacciones"))
            $("#tblTransacciones").DataTable(cfg);
        else
            $("#tblTransacciones").DataTable().ajax.url(url).load();
    };

    this.loadDropdowns = () => {
        ca.GetToApi(`${this.ApiCuenta}/RetrieveAll?clienteId=${this.getClienteId()}`, data => {
            const ddl = $("#ddlCuentas").empty();
            data.forEach(c => ddl.append(new Option(c.numeroCuenta, c.id)));
        });
        ca.GetToApi(`${this.ApiComercio}/RetrieveAll`, data => {
            const ddl = $("#ddlComercios").empty();
            data.forEach(c => ddl.append(new Option(c.nombre, c.id)));
        });
    };

    this.bindEvents = () => {
        $("#btnBuscar").click(() => this.loadTable());

        $("#btnCreate").click(() => {
            const dto = {
                idCuentaCliente: this.getClienteId(),
                idCuentaBancaria: parseInt($("#ddlCuentas").val(), 10),
                idCuentaComercio: parseInt($("#ddlComercios").val(), 10),
                monto: parseFloat($("#txtMonto").val()),
                comision: parseFloat($("#txtComision").val()),
                descuentoAplicado: parseFloat($("#txtDescuentoAplicado").val()),
                fecha: $("#txtFecha").val(),
                metodoPago: $("#txtMetodoPago").val()
            };
            const email = $("#hdnEmail").val() || $("#txtEmail").val();
            ca.PostToAPI(`${this.Api}/Create?email=${encodeURIComponent(email)}`, dto, () =>
                window.location.href = "/ClientesPages/ClienteHome"
            );
        });

        $("#btnUpdate").click(() => {
            const id = parseInt($("#txtId").val(), 10);
            const dto = {
                id,
                idCuentaCliente: this.getClienteId(),
                idCuentaBancaria: parseInt($("#ddlCuentas").val(), 10),
                idCuentaComercio: parseInt($("#ddlComercios").val(), 10),
                monto: parseFloat($("#txtMonto").val()),
                comision: parseFloat($("#txtComision").val()),
                descuentoAplicado: parseFloat($("#txtDescuentoAplicado").val()),
                fecha: $("#txtFecha").val(),
                metodoPago: $("#txtMetodoPago").val()
            };
            ca.PutToAPI(`${this.Api}/Update/${id}`, dto, () => this.loadTable());
        });

        $("#btnDelete").click(() => {
            const id = parseInt($("#txtId").val(), 10);
            ca.DeleteToAPI(`${this.Api}/Delete/${id}`, {}, () => this.loadTable());
        });
    };
}

$(document).ready(() => new TransaccionesViewController().initView());
