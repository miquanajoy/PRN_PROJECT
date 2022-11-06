var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("cancelled")) {
        loadlist("cancelled");
    } else {
        if (url.includes("completed")) {
            loadlist("completed");
        } else {
            if (url.includes("ready")) {
                loadlist("ready");
            } else {
                loadlist("inProgress");
            }
        }
    }
});

function loadlist(param) {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/order?status=" + param,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "pickUpName", "width": "10%" },
            { "data": "applicationUser.email", "width": "10%" },
            { "data": "orderTotal", "width": "10%" },
            { "data": "pickUpTime", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 bth-group">
                            <a href="/Admin/Order/OrderDetails?id=${data}"
                                class="btn btn-success text-white mx-2">
                                <i class="bi bi-pencil-square"></i></a>
                            
                            </div>`
                },
                "width": "10%"
            }
        ],
        "width": "100%"
    });
}