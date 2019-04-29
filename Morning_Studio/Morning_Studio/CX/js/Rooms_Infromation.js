// 会议室管理资源图
$.ajax({
    url: "../CX_Handler.ashx?act=Select_infroations",
    type: "get",
    dataType: "json",
    success: function (a) {
        for (var i = 0; i < a.length; i++) {
            //alert(a.length);
            var my_html ='<tr style="color:white; background-image: url("../images/btn_over.gif");" height="21" align="center">'+
                    '<td width="120" style="border: 1px solid rgb(97, 190, 243);">'+
                        '<b>资源名称</b>'+
                   ' </td>'+
                   ' <td>'+
                       ' <b>资源占用图例</b>'+
                   ' </td>'+
                   ' <td style="border: 1px solid rgb(97, 190, 243);">'+
                        '<b>备&nbsp;&nbsp;注</b>'+
                    '</td>'+
                '</tr>'+
                '<tr>'+
                '<td width="120" bgcolor="#ffffff" align="center" style="background-color: rgb(241, 246, 255);border: 1px solid rgb(97, 190, 243);">' + a[i].ConferenceRoomName+'</td>'+
                    '<td bgcolor="white" align="center">'+
                        '<table width="430" height="10" cellspacing="0" cellpadding="0" border="0">'+
                            '<tbody>'+
                                '<tr>'+
                                    '<td align="left">00:00</td>'+
                                    '<td align="center"><font color="gray">08:00&nbsp;上午</font>&nbsp;<font color="blue">12:00</font>&nbsp;<font color="gray">下午&nbsp;17:00</font></td>'+
                                    '<td align="right">24:00</td>'+
                                '</tr>'+
                            '</tbody>'+
                        '</table>'+
                        '<table width="400" height="15" cellspacing="0" cellpadding="0" border="0">'+
                            '<tbody>'+
                                '<tr>'+
                                    '<td bgcolor="#eee4e4"></td>'+
                                '</tr>'+
                            '</tbody>'+
                        '</table>'+

                        '<table width="400" height="2" cellspacing="0" cellpadding="0" border="0">'+
                            '<tbody>'+
                                '<tr>'+
                                    '<td width="33%" bgcolor="#ccc2c2"></td>'+
                                '</tr>'+
            '</tbody>' +
                '</table>' +
                '</td>' +
                '<td width="80" align="center" style=" border: 1px solid rgb(97, 190, 243);">机械工程部预约</td>' +
                '</tr>';

            $("#tbody_infoation").append($(my_html));
        }
    }
});