$.ajax({
    url: "Handler.ashx?act=getSePermissios",
    type: "post",
    dataType: "json",
    success: function (str) {
        for (var i = 0; i < str.length; i++) {
            var html = "<option value='" + str[i].PermissiosID + "' name='DepartID'>" + str[i].PermissiosName + "</option>";
            $(".selects_caidan1").append($(html));
        }
    }
});
