function ClienteHomeController() {
    const ca = new ControlActions();
    this.apiCuenta = "CuentaCliente";
    this.apiTrans = "Transaccion";

    this.init = function () {
        this.loadCuentas();
        this.loadTransacciones();
        $('#btnNuevaTransaccion').click(() => {
            window.location.href = '/Transacciones/Transacciones';
        });
    };

    this.getClienteId = function () {
        return $('#hdnClienteId').val() || 1;
    };

    this.loadCuentas = function () {
        const url = ca.GetUrlApiService(`${this.apiCuenta}/RetrieveAll?clienteId=${this.getClienteId()}`);
        $('#tblCuentasHome').DataTable({
            destroy: true,
            ajax: { url: url, dataSrc: '' },
            columns: [
                { data: 'banco' },
                { data: 'tipoCuenta' },
                { data: 'numeroCuenta' },
                { data: 'saldo' }
            ]
        });
    };

    this.loadTransacciones = function () {
        const url = ca.GetUrlApiService(`${this.apiTrans}/RetrieveByCliente?clienteId=${this.getClienteId()}`);
        $('#tblUltimasTransacciones').DataTable({
            destroy: true,
            ajax: { url: url, dataSrc: '' },
            columns: [
                { data: 'fecha' },
                { data: 'metodoPago' },
                { data: 'monto' },
                { data: 'idCuentaBancaria' }
            ]
        });
    };
}

$(document).ready(function () {
    new ClienteHomeController().init();
});
