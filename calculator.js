$(document).ready(function () {
    $("#computebutton").click(function () {
        var firstNum = $("#firstnum").val();
        var secondNum = $("#secondnum").val();
        var operation = $("#operations").val();

        if (!firstNum || !secondNum || !operation) {
            alert("Input all fields");
            return
        }

        $.post('../Home/CalculatorOperation', {
            frstNum: firstNum,
            scndNum: secondNum,
            op: operation

        }, function (data) {
            $("#answer").text(data[0].final_answer.toFixed(2));

        });
    });
});