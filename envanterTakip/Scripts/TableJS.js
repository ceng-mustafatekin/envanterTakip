$(document).ready(function () {

    $(".click").click(function () {

        var proName = $("#ProductName").val();
        var proBarcode = $("#ProductBarcode").val();
        var proExpiry = $("#exdatePicker").val();
        var proCartons = $("#CartonTxt").val();
        var proPerCar = $("#PieceTxt").val();
        var proBuying = $("#BuyingTxt").val();



        var code = "<tr><td><input type='checkbox' name='record' /> </td><td>" + proName + "</td><td>" + proBarcode + "</td><td>" + proExpiry + "</td><td>" + proCartons + "</td><td>" + proPerCar + "</td><td>" + proBuying + "</td></tr>"

        $("table .tbody").append(code);

    })
    $(".del").click(function () {
        $("table .tbody").find('input[name="record"]').each(function () {

            if ($(this).is(":checked")) {
                $(this).parents("tr").remove();
            }
        })




    });

    //<td><input type='button' value='sil' name='remBtn' class='del'/></td>

});