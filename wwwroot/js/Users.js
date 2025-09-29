

$(document).ready(function () {
    LoadData();
});


function LoadData() {
    console.log("Test");

    $('#userTable').DataTable({
        processing: true,
        serverSide: true,
        ajax: {
            url: '/User/GetData',
            type: 'POST'
        },
        columns: [
            { data: 'id' },
            { data: 'username' },
            { data: 'password' },
            {
                data: null,
                orderable: false,
                searchable: false,
                render: function (data, type, row) {
                    return `<button class="btn btn-sm btn-primary" onclick="openModal('User')">Edit</button>`;
                }
            }
        ]
    });
}

function users(id) {
    alert("Id edit : "+ id);
}