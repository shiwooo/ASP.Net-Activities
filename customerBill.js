$(document).ready(function () {
    $("#buttonclick").click(function () {
        var TV = parseInt($("#tv").val())
        var VCR = parseInt($("#vcr").val())
        var RC = parseInt($("#rc").val())
        var CD = parseInt($("#cd").val())
        var TR = parseInt($("#tr").val())

        var TVPrice = 400
        var VCRPrice = 220
        var RCPrice = 35.2
        var CDPrice = 300
        var TRPrice = 150

        var TVTotal = TV * TVPrice
        var VCRTotal = VCR * VCRPrice
        var RCTotal = RC * RCPrice
        var CDTotal = CD * CDPrice
        var TRTotal = TR * TRPrice

        var subTotal = TVTotal + VCRTotal + RCTotal + CDTotal + TRTotal
        var tax = subTotal * .0825
        var total = subTotal + tax

        $("#tvqty").text(TV)
        $("#vcrqty").text(VCR)
        $("#rcqty").text(RC)
        $("#cdqty").text(CD)
        $("#trqty").text(TR)
        $("#tvtotalprice").text((TVTotal).toFixed(2))
        $("#vcrtotalprice").text((VCRTotal).toFixed(2))
        $("#rctotalprice").text((RCTotal).toFixed(2))
        $("#cdtotalprice").text((CDTotal).toFixed(2))
        $("#trtotalprice").text((TRTotal).toFixed(2))
        $("#subtotalamt").text((subTotal).toFixed(2))
        $("#taxamt").text((tax).toFixed(2))
        $("#totalamt").text((total).toFixed(2))
    })
})