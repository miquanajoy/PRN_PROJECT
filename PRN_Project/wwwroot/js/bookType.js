var dataTable;

$(document).ready(function () {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/BookType",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 bth-group">
                            <a href="/Admin/BookTypes/upsert?id=${data}"
                                class="btn btn-success text-white mx-2">
                                <i class="bi bi-pencil-square"></i></a>
                            <a onClick="Delete('/api/BookType/' + ${data})"
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

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        //successNoti
                        toastr.success(data.message);
                    }
                    else {
                        //failNoti
                        toastr.error(data.message);

                    }
                }
            })
        }
    })

}


