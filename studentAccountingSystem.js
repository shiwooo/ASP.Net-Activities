$(document).ready(function () {
    $("#btnclck").click(function () {
        var IDNumber = $("#idnumber").val();
        var lastName = $("#lastname").val();
        var firstName = $("#firstname").val();
        var gender = $("#gender").val();
        var courseCode = $("#coursecode").val();
        var yearLevel = $("#yearlevel").val();
        var subjectCount = parseInt($("#subjectcount").val());
        var modeOfPayment = $("#modeofpayment").val();
        
      /*  !IDNumber || !lastName || !firstName || !gender || !yearLevel ||*/
        if (!courseCode || !subjectCount) {
            alert("Please enter all required fields.");
            return
        }
        if (subjectCount <= 0) {
            alert("NUMBER OF SUBJECTS DOES NOT MEET THE MINIMUM REQUIREMENT!!!");
            return
        }
        if (subjectCount > 10) {
            alert("NUMBER OF SUBJECTS EXCEEDED THE MINIMUM REQUIREMENT!!!");
            return
        }

        $.post('../Home/StudentEntry', {
            crsCode: courseCode,
            subjCount: subjectCount,
        }, function (data) {
            $(".id-number").text(IDNumber);
            $(".last-name").text(lastName);
            $(".first-name").text(firstName);
            $(".year-level").text(yearLevel);
            $(".gender-identity").text(gender);
            $(".crs-code").text(courseCode);
            $(".crs").text(data[0].course_name);
            $(".unit").text(data[0].total_unit);
            $("#registration-fee").text(data[0].registration_fee.toFixed(2));
            $("#misc-fee").text(data[0].miscellaneous_fee);
            $("#lab-fee").text(data[0].laboratory_fee);
            $("#total-tuition").text(data[0].total_tuition_fee.toFixed(2));
            $("#total-fee").text(data[0].total_fee.toFixed(2));
            $("#prelim-payment").text(data[0].prelim_payment.toFixed(2));
            $("#midterm-payment").text(data[0].midterm_payment.toFixed(2));
            $("#semifinal-payment").text(data[0].semi_final_payment.toFixed(2));
            $("#final-payment").text(data[0].final_payment.toFixed(2));
            $("#mode-of-payment").text(modeOfPayment);

        });
    });

    $("#btnclck-2").click(function () {
        var amountTendered = parseInt($("#amount-tendered").val());
        var prelimAssessment = $("#prelim-payment").text();
        var midtermAssessment = $("#midterm-payment").text();
        var semifinalAssessment = $("#semifinal-payment").text();
        var finalAssessment = $("#final-payment").text();
        var assessmentChoice = parseInt($('input[name="assessment"]:checked').val());

        if (!amountTendered) {
            alert("Please enter an amount.")
            return;
        }

        $.post('../Home/Assessment', {
            amtTendered: amountTendered,
            prelimAssess: prelimAssessment,
            midtermAssess: midtermAssessment,
            semifinalAssess: semifinalAssessment,
            finalAssess: finalAssessment,
            assessChoice: assessmentChoice
        }, function (data) {
            $("#final-amount-tendered").text(data[0].amount_tendered);
            $("#change-amount").text(data[0].change.toFixed(2));
            $("#number-to-phrase").text(data[0].phrase);
        });
    });
});
