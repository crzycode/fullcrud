$(document).ready(function () {

    $("#save").click(function () {
        save();
        
    })
    get();

    $("#update").hide();
})

function save() {
    var obj = {};
    obj.firstname = $("#fname").val();
    obj.lastname = $("#lname").val();
    if (obj) {
        $.ajax({
            url: "https://localhost:44373/Otherway/post",
            contentType: "application/json charset=utf-8",
            dataType: "json",
            data: JSON.stringify(obj),
            type: "post",
            success: function (result) {
                clear();
                console.log(result);

            },
            error: function (msg) {
                console.log(msg);
            }
        })
    }
}
function clear() {
     $("#fname").val('');
    $("#lname").val('');
}
function get() {
    $.ajax({
        url: "https://localhost:44373/Otherway/get",
        contentType: "application/json charset=utf-8",
        dataType: "json",
        
        type: "get",
        success: function (result) {

            console.log(result);
            if (result) {
                $("#userdata").html('');
                var row = '';

                $.each(result, function (key, value) {
                    row = row
                        + "<tr>"
                        + "<td>" + value.firstname + "</td>"
                        + "<td>" + value.lastname + "</td>"

                        + "<td> <button class='btn btn-primary' onclick='delet(" + value.id + ")'> Delete</button><button class='btn btn-success' onclick='edit(" + value.id +")'> Edit</button></td>"
                        
                        + "</tr>"

                });
            }
                    
                
            
            if (row != '') {
                $("#userdata").append(row)
            };


        },
        error: function (msg) {
            console.log(msg);
        }
    })
}
function delet(id) {
    
    
        $.ajax({
            url: "https://localhost:44373/Otherway/delete/" + id,
            contentType: "application/json charset=utf-8",
            dataType: "json",
            
            type: "Delete",
            success: function (result) {
                clear();
                console.log(result);

            },
            error: function (msg) {
                console.log(msg);
            }
        })
    
}
function edit(id) {
    $.ajax({
        url: "https://localhost:44373/Otherway/get",
        contentType: "application/json charset=utf-8",
        dataType: "json",

        type: "get",
        success: function (result) {
            $("#fname").val(result[0].firstname);
            $("#lname").val(result[0].lastname);
            $("#save").hide();
            $("#update").show();

            


        },
        error: function (msg) {
            console.log(msg);
        }
    })
    $("#update").click(function () {
        var obj = {};
        obj.firstname = $("#fname").val();
        obj.lastname = $("#lname").val();

        $.ajax({
            url: "https://localhost:44373/Otherway/Put/" + id,
            contentType: "application/json charset=utf-8",
            dataType: "json",
            data: JSON.stringify(obj),
            type: "Delete",
            success: function (result) {
                clear();
                console.log(result);

            },
            error: function (msg) {
                console.log(msg);
            }
        })
        
    })
}
