$.ajax({
    url: "Handler.ashx?act=Depart",
    type: "post",
    dataType: "json",
    success: function (str) {
        for (var i = 0; i < str.length; i++) {
            var html = "<option value='" + str[i].DepartID + "' name='DepartID'>" + str[i].DepartName + "</option>";
            $(".selects").append($(html));
        }
    }
});

$.ajax({
    url: "Handler.ashx?act=PositionTable",
    type: "post",
    dataType: "json",
    data: { "id": $(".selects").val()},
    success: function (str) {
        for (var i = 0; i < str.length; i++) {
            var html = "<option value='" + str[i].PositionId + "' name='PositionId'>" + str[i].PositionName + "</option>";
            $(".pos").append($(html));
        }
    }
});

$.ajax({
    url: "Handler.ashx?act=GZstateld",
    type: "post",
    dataType: "json",
    success: function (str) {
        for (var i = 0; i < str.length; i++) {
            var html = "<option value='" + str[i].stateldId + "' name='PositionId'>" + str[i].stateldName + "</option>";
            $(".selects_type").append($(html));
        }
    }
});





