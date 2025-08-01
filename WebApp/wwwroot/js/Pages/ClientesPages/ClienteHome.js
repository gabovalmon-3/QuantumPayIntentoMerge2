function ClienteHomePage() {
    const ca = new ControlActions();
    this.apiCuenta = "CuentaCliente";
    this.apiTrans = "Transaccion";

    this.init = function () {
        this.loadCuentas();
        this.loadTransacciones();

        // Aquí va el listener del botón Nueva Transacción
        $('#btnNuevaTransaccion').click(() => {
            const id = this.getClienteId();
            const email = $('#hdnClienteEmail').val();
            window.location.href = `/Transacciones/Transacciones?clienteId=${id}&email=${encodeURIComponent(email)}`;
        });
    };

    this.getClienteId = function () {
        return $('#hdnClienteId').val();
    };

    this.loadCuentas = function () {
        const url = ca.GetUrlApiService(`${this.apiCuenta}/RetrieveAll?clienteId=${this.getClienteId()}`);
        // inicializa tu DataTable de cuentas…
    };

    this.loadTransacciones = function () {
        const url = ca.GetUrlApiService(`${this.apiTrans}/RetrieveByCliente?clienteId=${this.getClienteId()}`);
        // inicializa tu DataTable de transacciones…
    };
}

$(document).ready(() => new ClienteHomePage().init());
