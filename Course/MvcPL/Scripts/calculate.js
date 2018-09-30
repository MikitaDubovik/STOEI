$('#CalculateButton').bind("click", function () {
    document.getElementById("CalculateButton").style.visibility = "hidden";
    document.getElementById("PayButton").style.visibility = "visible";
    document.getElementById("beginPrice").style.visibility = "visible";
    document.getElementById("endPrice").style.visibility = "visible";
});

$(document).ready(function () {
    document.getElementById("PayButton").style.visibility = "hidden";
    document.getElementById("beginPrice").style.visibility = "hidden";
    document.getElementById("endPrice").style.visibility = "hidden";
});