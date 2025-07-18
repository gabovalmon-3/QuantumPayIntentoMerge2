// wwwroot/js/ControlActions.js
// Copiado de CenfoCinemas, ajusta URL_API a tu API QuantumPay :contentReference[oaicite:0]{index=0}

function ControlActions() {
    // Ruta base de tu API QuantumPay
    this.URL_API = "https://localhost:5000/api/";

    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    }

    this.FillTable = function (service, tableId, refresh) {
        if (!refresh) {
            var columns = $('#' + tableId).attr("ColumnsDataName").split(',');
            var arrayColumnsData = columns.map(function (col) {
                return { data: col };
            });

            $('#' + tableId).DataTable({
                processing: true,
                ajax: {
                    url: this.GetUrlApiService(service),
                    dataSrc: ''
                },
                columns: arrayColumnsData
            });
        } else {
            $('#' + tableId).DataTable().ajax.reload();
        }
    }

    this.PostToAPI = function (service, data, callBackFunction) {
        $.ajax({
            type: "POST",
            url: this.GetUrlApiService(service),
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (callBackFunction) callBackFunction(response);
            },
            error: function (xhr) {
                var msg = xhr.responseJSON?.errors
                    ? Object.values(xhr.responseJSON.errors).flat().join("<br/>")
                    : xhr.responseText;
                Swal.fire({ icon: 'error', title: 'Oops...', html: msg });
            }
        });
    }

    this.PutToAPI = function (service, data, callBackFunction) {
        $.ajax({
            type: "PUT",
            url: this.GetUrlApiService(service),
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (callBackFunction) callBackFunction(response);
            },
            error: function (xhr) {
                var msg = xhr.responseJSON?.errors
                    ? Object.values(xhr.responseJSON.errors).flat().join("<br/>")
                    : xhr.responseText;
                Swal.fire({ icon: 'error', title: 'Oops...', html: msg });
            }
        });
    }

    this.DeleteToAPI = function (service, data, callBackFunction) {
        $.ajax({
            type: "DELETE",
            url: this.GetUrlApiService(service),
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (callBackFunction) callBackFunction(response);
            },
            error: function (xhr) {
                var msg = xhr.responseJSON?.errors
                    ? Object.values(xhr.responseJSON.errors).flat().join("<br/>")
                    : xhr.responseText;
                Swal.fire({ icon: 'error', title: 'Oops...', html: msg });
            }
        });
    }

    this.GetToApi = function (service, callBackFunction) {
        $.get(this.GetUrlApiService(service), function (response) {
            if (callBackFunction) callBackFunction(response);
        });
    }
}
