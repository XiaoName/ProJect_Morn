//部门下拉框
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
//会议室下拉框
$.ajax({
    url: "../CX_Handler.ashx?act=Rooms",
    type: "post",
    dataType: "json",
    success: function (str) {    
        for (var i = 0; i < str.length; i++) {
            var html = "<option value='" + str[i].ConferenceRoomID + "'>" + str[i].ConferenceRoomName + "</option>";
            $(".Room_yuding").append($(html));
        }
    }
});

