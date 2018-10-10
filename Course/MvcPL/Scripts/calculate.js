$('#CalculateButton').bind("click", function () {
    document.getElementById("CalculateButton").style.visibility = "hidden";

    var countries = $("#DdlCountries").val();

    var sex = $("#DdlSex").val();

    var ageBegin = parseInt($("#DdlAgeBegin").val());
    var ageEnd = parseInt($("#DdlAgeEnd").val());
    var languages = $("#DdlLanguage").val();

    var totalPrice = 0;

    if (countries.length !== 0)
        totalPrice += countries.length * 30;
    else
        totalPrice += 1000;

    if (sex.length !== 0)
        totalPrice += sex.length * 30;
    else
        totalPrice += 60;

    if (languages.length !== 0)
        totalPrice += languages.length * 30;
    else
        totalPrice += 150;

    totalPrice += (ageEnd - ageBegin) * 30;

    $("#endPrice").text(totalPrice);

    document.getElementById("PayButton").style.visibility = "visible";
    document.getElementById("beginPrice").style.visibility = "visible";
    document.getElementById("endPrice").style.visibility = "visible";
});

$(document).ready(function () {
    document.getElementById("PayButton").style.visibility = "hidden";
    document.getElementById("beginPrice").style.visibility = "hidden";
    document.getElementById("endPrice").style.visibility = "hidden";
});

$('#PayButton').bind("click", function () {
    $.post({
        type: "POST",
        url: "PayPage",
        data: { price: $("#endPrice").text() }
    });
});