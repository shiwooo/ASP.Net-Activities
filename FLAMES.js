$(document).ready(function () {
    $("#btnclck").click(function () {
        var yourName = $("#yourname").val()
        var crushName = $("#crushname").val()

        $.post('../Home/IdentifyFLAMES', {
            yourName: yourName,
            crushName: crushName
        }, function (data) {
            $("#flamesresult").text(data[0].flamesresult)
        })
    })
})
