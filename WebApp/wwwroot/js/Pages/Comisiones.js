// wwwroot/js/pages/Comisiones.js
function ComisionesViewController() {
    const ca = new ControlActions();
    const self = this;

    // Nombre EXACTO de tu controller en la WebAPI
    this.Api = "Comision";

    this.initView = function () {
        console.log("Comisiones init → OK");
        this.loadTable();
        this.bindEvents();
    };

    this.loadTable = function () {
        var ca = new ControlActions();
        var url = ca.GetUrlApiService(this.Api);
        if (!$.fn.dataTable.isDataTable('#tblComisiones')) {
            $('#tblComisiones').DataTable({
                processing: true,
                ajax: { url: url, dataSrc: '' },
                columns: [
                    { data: 'id' },
                    { data: 'idInstitucionBancaria' },
                    { data: 'idCuentaComercio' },
                    { data: 'porcentaje' },
                    { data: 'montoMaximo' }
                ]
            });
        } else {
            $('#tblComisiones').DataTable().ajax.url(url).load();
        }
    };

    this.bindEvents = function () {
        var ca = new ControlActions(), self = this;

        $('#btnCreate').click(function () {
            var dto = {
                idInstitucionBancaria: parseInt($('#txtIdInstitucionBancaria').val(), 10),
                idCuentaComercio: parseInt($('#txtIdCuentaComercio').val(), 10) || null,
                porcentaje: parseFloat($('#txtPorcentaje').val()),
                montoMaximo: parseFloat($('#txtMontoMaximo').val())
            };
            ca.PostToAPI(self.Api, dto, () => self.loadTable());
        });

        $('#btnUpdate').click(function () {
            var id = parseInt($('#txtId').val(), 10);
            var dto = {
                id: id,
                idInstitucionBancaria: parseInt($('#txtIdInstitucionBancaria').val(), 10),
                idCuentaComercio: parseInt($('#txtIdCuentaComercio').val(), 10) || null,
                porcentaje: parseFloat($('#txtPorcentaje').val()),
                montoMaximo: parseFloat($('#txtMontoMaximo').val())
            };
            ca.PutToAPI(self.Api + "/" + id, dto, () => self.loadTable());
        });

        // DELETE
        $('#btnDelete').click(function () {
            const dto = { id: parseInt($('#txtId').val(), 10) };
            // ahora hace DELETE /api/Comision/{id}
            ca.DeleteToAPI(self.Api + '/' + dto.id, dto, () => self.loadTable());
        });

        $('#tblComisiones tbody').on('click', 'tr', function () {
            var data = $('#tblComisiones').DataTable().row(this).data();
            $('#txtId').val(data.id);
            $('#txtIdInstitucionBancaria').val(data.idInstitucionBancaria);
            $('#txtIdCuentaComercio').val(data.idCuentaComercio);
            $('#txtPorcentaje').val(data.porcentaje);
            $('#txtMontoMaximo').val(data.montoMaximo);
        });
    };
}

$(document).ready(function () {
    new ComisionesViewController().initView();
});
