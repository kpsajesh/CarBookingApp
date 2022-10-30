$(function () {
    $('.deleteBtn').click(function (e) { // enters to this function when a button is click having the class "deleteBtn"
        var btn = $(this);
        var name = "";
        //name = btn.data("name")

        swal({
            title: "Delete?", // sweet alert parameters
            text: "Are you sure to delete this record?",
            icon: "warning",
            buttons: true,
            dangerMode: true
        }).then((confirm) => { // enters if clicked OK in the sweet alert
            if (confirm) {
                var id = btn.data("id") // We have assigned the primary key as item.Id in the button, so it will be bound to each button as id and this primary key and it is fetching.*
                $('#RecordId').val(id); //The primary key is assigning to the hidden control
                $('#deleteForm').submit(); // submitting the form
                //var id = btn.data("name")

            }
        });
    });
});