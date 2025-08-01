function CuentaClienteController() {
    const ca = new ControlActions();
    this.Api = "CuentaCliente";

    this.init = function () {
        this.loadTable();
        $('#btnCreateCuenta').click(() => this.create());
        $('#btnUpdateCuenta').click(() => this.update());
        $('#btnDeleteCuenta').click(() => this.delete());
    };

    this.getClienteId = function () {
        return $('#hdnClienteId').val() || 1;
    };

    this.loadTable = function () {
        const url = ca.GetUrlApiService(`${this.Api}/RetrieveAll?clienteId=${this.getClienteId()}`);
        $('#tblCuentaCliente').DataTable({
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

    this.create = function () {
        const dto = {
            clienteId: this.getClienteId(),
            numeroCuenta: $('#txtNumeroCuenta').val(),
            banco: $('#selectBanco').val(),
            tipoCuenta: $('#selectTipoCuenta').val(),
            saldo: parseFloat($('#txtSaldo').val() || 0)
        };
        ca.PostToAPI(`${this.Api}/Create`, dto, () => this.loadTable());
    };

    this.update = function () {
        const dto = {
            id: parseInt($('#txtId').val(), 10),
            numeroCuenta: $('#txtNumeroCuenta').val(),
            banco: $('#selectBanco').val(),
            tipoCuenta: $('#selectTipoCuenta').val(),
            saldo: parseFloat($('#txtSaldo').val() || 0)
        };
        ca.PutToAPI(`${this.Api}/Update`, dto, () => this.loadTable());
    };

    this.delete = function () {
        const id = parseInt($('#txtId').val(), 10);
        ca.DeleteToAPI(`${this.Api}/Delete/${id}`, {}, () => this.loadTable());
    };
}

$(document).ready(function () {
    new CuentaClienteController().init();
});
