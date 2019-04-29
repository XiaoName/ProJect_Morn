$(function () {
  //加载表格数据
    Select_biaoge();

    //部门下拉框
    Select_Depart();

    //WorkCreate_Upate.html查询事件
    $("#WorkCreateBTN").click(function () {
        $("#tbody_content").html("");
        Select_table();
    });

    //查看详情
    $("#tbody_content").on("click",".a_details", function () {    
        var id = $(this).attr("update");
        window.localStorage.setItem("WorkOrderNumber", id);//键是自定义的
    
      window.open("WorkCreate_Upate.html");
    });
});


//工作单创建明细加载数据库
function Select_table(){
    var work_idcard = $("#work_idcard").val();
    var work_names = $("#work_names").val();
   // alert(work_idcard);
    $.ajax({
        url: "../CX_Handler.ashx?act=WorkGetList",
        type: "get",
        dataType: "json",
        data: { "WorkOrderNumber": work_idcard, "WorkTaskName": work_names },
        success: function (a) {
            for (var i = 0; i < a.length; i++) {
                var my_html ='<tr>' +
                    '<td>' + a[i].WorkOrderNumber + '</td>' +
                    '<td>' + a[i].ResponsiblePerson + '</td>' +
                    '<td>' + a[i].WorkCreatNumber + '</td>' +
                    '<td>' + gettime(a[i].WorksheetCreatDate) + '</td>' +
                    '<td>' + a[i].WorkDealPeople + '</td>' +
                    '<td>' + a[i].WorkUploadType + '</td>' +
                    '<td>' + a[i].MyProWorkDescribleperty + '</td>' +
                    '<td>' + a[i].WorkState + '</td>' +
                    '<td>' + gettime(a[i].WorkDueTime) + '</td>' +
                    '<td>' + a[i].WorkDueDeal + '</td>' +
                    '<td>' + a[i].WorkTaskName + '</td>' +
                    '<td>' + a[i].WorkReminderlevel + '</td>' +
                    '<td>' + a[i].WorkReminderTime + '</td>' +
                    '<td><a href="javascript:;"  class="a_details">查看详情</a></td>' +
                    '</tr >';
                $("#tbody_content").append($(my_html));
                sessionStorage.setItem("WorkOrderNumber", a[i].WorkCreatNumber);
            }
        }
    });
}
//表格显示数据年月日
function gettime(t) {
    var _time = new Date(t);
    var year = _time.getFullYear();//2017
    var month = _time.getMonth() + 1;//7
    var date = _time.getDate();//10
    return year + "年" + month + "月" + date + "日   ";//这里自己按自己需要的格式拼接
}
//加载表格数据
function  Select_biaoge(){
$.ajax({
    url: "../CX_Handler.ashx?act=GetCha",
    type: "get",
    dataType: "json",
    success: function (a) {
        for (var i = 0; i < a.length; i++) {
            var my_html =
                '<tr>' +
                '<td>' + a[i].WorkOrderNumber + '</td>' +
                '<td>' + a[i].ResponsiblePerson + '</td>' +
                '<td>' + a[i].WorkCreatNumber + '</td>' +
                '<td>' + gettime(a[i].WorksheetCreatDate)  + '</td>' +
                '<td>' + a[i].WorkDealPeople + '</td>' +
                '<td>' + a[i].WorkUploadType + '</td>' +
                '<td>' + a[i].MyProWorkDescribleperty + '</td>' +
                '<td>' + a[i].WorkState + '</td>' +
                '<td>' + gettime(a[i].WorkDueTime) + '</td>' +
                '<td>' + a[i].WorkDueDeal + '</td>' +
                '<td>' + a[i].WorkTaskName + '</td>' +
                '<td>' + a[i].WorkReminderlevel + '</td>' +
                '<td>' + a[i].WorkReminderTime + '</td>' +
                '<td><a href="javascript:;" class="a_details"  update="' + a[i].WorksheetID + '">查看详情</a></td>' +
                '</tr >';
                
            $("#tbody_content").append($(my_html));
        }
    }
});

}


//部门下拉框
function Select_Depart(){
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
}