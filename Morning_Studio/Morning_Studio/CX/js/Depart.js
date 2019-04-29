$.ajax({
    url: "../CX_Handler.ashx?act=Depart",
    type: "post",
    dataType: "json",
    success: function (str) {
        for (var i = 0; i < str.length; i++) {
            var html = "<option value='" + str[i].DepartID + "'>" + str[i].DepartName + "</option>";
            $(".depart").append($(html));
        }
    }
});

$.ajax({
    url: "../CX_Handler.ashx?act=RoomsPeople",
    type: "post",
    dataType: "json",
    data: { "id": $(".depart").val() },
    success: function (str) {
        for (var i = 0; i < str.length; i++) {
            var html = "<option value='" + str[i].UserID + "' name='PositionId'>" + str[i].JobNumber + "</option>";
            $(".yaoqr").append($(html));
        }
    }
});



