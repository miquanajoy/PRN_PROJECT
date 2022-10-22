$(document).ready(function () {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Category",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "displayOrder", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 bth-group">
                            <a href="/Admin/Category/upsert?id=${data}"
                                class="btn btn-success text-white mx-2">
                                <i class="bi bi-pencil-square"></i></a>
                            <a onClick="Delete('/api/Category/' + ${data})"
                                class="btn btn-danger text-white" mx-2>
                                <i class="bi bi-trash-fill"></i></a>
                            </div>`
                },
                "width": "10%"
            }
        ],
        "width": "100%"
    });
});