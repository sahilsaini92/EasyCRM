$("#drpSource").change(function () {
    var src = $("#drpSource").val();
    if (src == 1) {
        $("#divRack").css("display", "block");
    }
    else {
        $("#divRack").css("display", "none");
    }
});