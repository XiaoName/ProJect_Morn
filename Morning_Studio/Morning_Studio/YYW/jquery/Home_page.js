
$(function () {
    /*图片放大效果*/
    $("#Home_picture img").mouseenter(function () {
        var wValue = 1.15 * $(this).width();
        var hValue = 1.15 * $(this).height();
        $(this).animate({
            width: wValue,
            height: hValue,
            left: ("-40"),
            top: ("-40")
        }, 3000);
    }).mouseleave(function () {
        $(this).animate({
            width: "1200",
            height: "250",
            left: "0px",
            top: "0px"
        }, 3000);
        });
    //考勤显示
    KaoQin();
    //系统时间获取
    Date.prototype.Format = function (fmt) { // author: meizz
        var o = {
            "M+": this.getMonth() + 1, // 月份
            "d+": this.getDate(), // 日
            "H+": this.getHours(), // 小时
            "m+": this.getMinutes(), // 分
            "s+": this.getSeconds(), // 秒
            "q+": Math.floor((this.getMonth() + 3) / 3), // 季度
            "S": this.getMilliseconds() // 毫秒
        };
        if (/(y+)/.test(fmt))
            fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        for (var k in o)
            if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        return fmt;
    }
    //调用
    var time1 = new Date().Format("yyyy-MM-dd");
    //var time2 = new Date().Format("yyyy-MM-dd HH:mm:ss"); 
    /*----------------------------------------------------------------------------------*/

    //用户打卡
    $("#user_daka").click(function () {
        User_DaKa();
    });

    /*请假按钮*/
    $("#btn_qingjia").click(function () {
        ShowMask();
        $("#kaoqin").show();
        var html = "<form id='form_qj'><table class='table'>";
        html += "<tr>";
        html += "<td rowspan='2' colspan='4' class='user_qingjia'><lable id='tal'>请假申请<lable></td>";
        html += "<td></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td rowspan='2' colspan='4'></td>";
        html += "<td ></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td colspan='2' class='he'>姓名:</td>";
        html += "<td colspan='2' class='he'><input type='text' class='text_he' readonly='readonly' id='user_name' /></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td colspan='2' class='he'>工号:</td>";
        html += "<td colspan='2' class='he'><input type='text' class='text_he' readonly='readonly' id='user_gonghao' /></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td  class='dan'>性别:</td>";
        html += "<td  class='shuang'><input type='text' class='text_fen' readonly='readonly' id='user_sex' /></td>";
        html += "<td  class='dan'>电话:</td>";
        html += "<td  class='shuang'><input type='text' class='text_fen' id='phone' /></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td  class='dan'>部门:</td>";
        html += "<td  class='shuang' id='derpt_td'><input type='text' class='text_fen' readonly='readonly' id='user_dept'/></td>";
        html += "<td  class='dan'>接收人:</td>";
        html += "<td  class='shuang'><select class='sel_' id='user_user' ><option value='0'>--请选择--</option></select></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td  class='dan'>请假开始时间:</td>";
        html += "<td  class='shuang' id='start_td'><input type='datetime' class='text_fen'  id='start_time' value='" + time1 + "'/></td>";
        html += "<td  class='dan'>请假结束时间:</td>";
        html += "<td  class='shuang' id='end_td'><input type='datetime' class='text_fen'  id='end_time' value='" + time1 + "'/></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td colspan='4' class='he'>备注（原因）</td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td colspan='4'><textarea class='textarea' id='qj_beizhu'></textarea></td>";
        html += "</tr>";

        html += "<tr style='margin-top='20px''>";
        html += "<td colspan='2' id='fasong'><input type='button' value='发送' class='btn_'  id='Em_return'/></td>";
        html += "<td colspan='2' id='guanbi'><input type='button' value='关闭' class='btn_' id='close'/></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td colspan='4' class='kong'></td>";
        html += "</tr></table></form>";
        $("#kaoqin").append($(html));


        /*查询请假页面初始数据*/
        User_Select();
        //显示部门
        User_Dept()
        //显示接收人
        Select_Jieshou();
        //下拉框绑定事件
        //通过绑定change事件，当下拉框内容发生变化时事件被启动
        $("#user_user").bind("change", function () {
            //获取被选中的option的值
            //var miaoshu = $(this).val();

            //获取自定义属性的值
            var bianhao = $(this).find("option:selected").attr("flog");
            var jieshourenid = $(this).find("option:selected").attr("value");
            sessionStorage.setItem("js_userid", bianhao);
            sessionStorage.setItem("jieshourenid", jieshourenid);
        });


        /*关闭请假窗口*/
        $("#guanbi").on("click", "#close", function () {
            $("#kaoqin").html("");
            $("#kaoqin").hide();
            $(".Mask_z").hide();
        });

        /*发送请假请求*/
        $("#fasong").on("click", "#Em_return", function () {
            Email_Return();
        });

    });

    /*项目休假申请按钮*/
    $("#btn_xmqingjia").click(function () {
        ShowMask();
        $("#kaoqin").show();
        var html = "<table class='table'>";
        html += "<tr>";
        html += "<td rowspan='2' colspan='4' class='user_qingjia'><lable id='xj_tal'>项目休假申请<lable></td>";
        html += "<td></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td rowspan='2' colspan='4'></td>";
        html += "<td ></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td  class='dan'>姓名:</td>";
        html += "<td  class='shuang'><input type='text' class='text_fen' readonly='readonly' id='xj_user_name'/></td>";
        html += "<td  class='dan'>工号:</td>";
        html += "<td  class='shuang'><input type='text' class='text_fen' readonly='readonly' id='xj_user_gonghao'/></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td  class='dan'>性别:</td>";
        html += "<td  class='shuang'><input type='text' class='text_fen' readonly='readonly' id='xj_user_sex'/></td>";
        html += "<td  class='dan'>电话:</td>";
        html += "<td  class='shuang'><input type='text' class='text_fen' id='xj_phone'/></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td  class='dan'>部门:</td>";
        html += "<td  class='shuang' id='derpt_td'><input type='text' class='text_fen' readonly='readonly' id='xj_user_dept'/></td>";
        html += "<td  class='dan'>接收人:</td>";
        html += "<td  class='shuang'><select class='sel_' id='xj_user_user'><option value='0'>--请选择--</option></select></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td  class='dan'>休假项目:</td>";
        html += "<td  class='shuang'><select class='sel_' id='user_xiangmu'></select></td>";
        html += "<td  class='dan'></td>";
        html += "<td  class='shuang'></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td  class='dan'>请假开始时间:</td>";
        html += "<td  class='shuang' id='xj_start_td'><input type='datetime' class='text_fen'  id='xj_start_time' value='" + time1 + "'/></td>";
        html += "<td  class='dan'>请假结束时间:</td>";
        html += "<td  class='shuang' id='xj_end_td'><input type='datetime' class='text_fen'  id='xj_end_time' value='" + time1 + "'/></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td colspan='4' class='he'>备注（原因）</td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td colspan='4'><textarea class='textarea' id='xj_beizhu'></textarea></td>";
        html += "</tr>";

        html += "<tr style='margin-top='20px''>";
        html += "<td colspan='2' id='xj_Em_return'><input type='button' value='发送' class='btn_' id='xj_fasong'/></td>";
        html += "<td colspan='2' id='xj_guanbi'><input type='button' value='关闭' class='btn_' id='xj_close'/></td>";
        html += "</tr>";

        html += "<tr>";
        html += "<td colspan='4' class='kong'></td>";
        html += "</tr>";
        $("#kaoqin").append($(html));
        /*查询请假页面初始数据*/
        User_Select();
        //显示部门
        User_Dept()
        //显示接收人
        Select_Jieshou();
        //下拉框绑定事件
        //通过绑定change事件，当下拉框内容发生变化时事件被启动
        $("#xj_user_user").bind("change", function () {
            //获取被选中的option的值
            //var miaoshu = $(this).val();

            //获取自定义属性的值
            var bianhao = $(this).find("option:selected").attr("flog");
            var xj_jieshourenid = $(this).find("option:selected").attr("value");
            sessionStorage.setItem("xjjs_userid", bianhao);
            sessionStorage.setItem("xj_jieshourenid", xj_jieshourenid);
        });

        /*发送请假请求*/
        $("#xj_Em_return").on("click", "#xj_fasong", function () {
            XJ_Email_Return();
        });

        /*关闭请假窗口*/
        $("#xj_guanbi").on("click", "#xj_close", function () {
            $("#kaoqin").html("");
            $("#kaoqin").hide();
            $(".Mask_z").hide();
        });

    });
    

    //请假审批按钮
    $(".btn_qjshenpi_tr").delegate("#btn_qjshenpi", "click", function () {
                ShowMask();
        $("#kaoqin_shenpi").show();
        QingJiaShenPi();
        $("#shenhe").delegate("#btn_tuichu_shenpi", "click", function () {
            $("#kaoqin_shenpi tbody").html("");
            $("#kaoqin_shenpi").hide();
            $(".Mask_z").hide();
        });
    })



});

//显示遮罩层
function ShowMask() {
    var W = $('body').width();
    var H = $('body').height();
    $('.Mask_z').css({
        "height": H + "px",
        "width": W + "px",
        "display": "block"
    });
}

/*登录后查询用户资料（内部储存用户资料）*/
function User_Select() {

    var gonghao = sessionStorage.getItem("user");
    $.ajax({
        url: "/YYW/my_Handler/home_page_handler.ashx?act=user_select",
        data: { "usergonghao": gonghao },
        type: "post",
        dataType: "json",
        success: function (rs) {
            //请假数据载入
            $("#user_name").val(rs.Name);
            $("#user_gonghao").val(rs.JobNumber);
            $("#user_sex").val(rs.Sex);
            $("#phone").val(rs.Phone);
            //休假项目载入
            $("#xj_user_name").val(rs.Name);
            $("#xj_user_gonghao").val(rs.JobNumber);
            $("#xj_user_sex").val(rs.Sex);
            $("#xj_phone").val(rs.Phone);
        }
    });
}

//查询用户部门( 内储存登录用户部门ID（也可做为部门邮件接收人部门ID）)
function User_Dept() {
    var gonghao = sessionStorage.getItem("user");
    $.ajax({
        url: "/YYW/my_Handler/home_page_handler.ashx?act=user_dept",
        data: { "usergonghao": gonghao },
        type: "post",
        dataType: "json",
        success: function (rs) {
            //储存登录用户部门ID（也可做为部门邮件接收人部门ID）
            sessionStorage.setItem("jieshou_user", rs.DepartID);
            //请假数据载入
            $("#user_dept").val(rs.DepartName);
            //休假数据载入
            $("#xj_user_dept").val(rs.DepartName);
        }
    });
}

//查询邮件接收人(下拉框数据)
function Select_Jieshou() {
    var user_id = sessionStorage.getItem("dep_id");
    var gonghao = sessionStorage.getItem("user");
    $.ajax({
        url: "/YYW/my_Handler/home_page_handler.ashx?act=jieshouren",
        data: { "js_user": user_id, "gonghao": gonghao },
        type: "post",
        dataType: "json",
        success: function (rs) {
            for (var i = 0; i < rs.length; i++) {
                var html = "<option value='" + rs[i].UserID + "'flog='" + rs[i].JobNumber + "'>" + rs[i].Name + "</option>";
                $("#user_user").append($(html));
                $("#xj_user_user").append($(html));
            }
        }
    });
}

//查询上班时间
function Select_shangban_time() {
    $.ajax({
        url: "/YYW/my_Handler/home_page_handler.ashx?act=daka_time",
        dataType: "json",
        type: "post",
        success: function (rs) {
            //春天
            sessionStorage.setItem("chuntian", rs[0].Standard_Season);
            sessionStorage.setItem("c_shangban", rs[0].Standard_BeginHours);
            sessionStorage.setItem("c_shangban_max", rs[0].Standard_BeginHours_max);
            sessionStorage.setItem("c_xiaban", rs[0].Standard_EndHours);
            sessionStorage.setItem("c_xiaban_max", rs[0].Standard_EndHours_max);
            //夏天
            sessionStorage.setItem("xiatian", rs[1].Standard_Season);
            sessionStorage.setItem("x_shangban", rs[1].Standard_BeginHours);
            sessionStorage.setItem("x_shangban_max", rs[1].Standard_BeginHours_max);
            sessionStorage.setItem("x_xiaban", rs[1].Standard_EndHours);
            sessionStorage.setItem("x_xiaban_max", rs[1].Standard_EndHours_max);
            //秋天
            sessionStorage.setItem("qiutian", rs[2].Standard_Season);
            sessionStorage.setItem("q_shangban", rs[2].Standard_BeginHours);
            sessionStorage.setItem("q_shangban_max", rs[2].Standard_BeginHours_max);
            sessionStorage.setItem("q_xiaban", rs[2].Standard_EndHours);
            sessionStorage.setItem("q_xiaban_max", rs[2].Standard_EndHours_max);
            //冬天
            sessionStorage.setItem("dongtian", rs[3].Standard_Season);
            sessionStorage.setItem("d_shangban", rs[3].Standard_BeginHours);
            sessionStorage.setItem("d_shangban_max", rs[3].Standard_BeginHours_max);
            sessionStorage.setItem("d_xiaban", rs[3].Standard_EndHours);
            sessionStorage.setItem("d_xiaban_max", rs[3].Standard_EndHours_max);
        }
    });
}
//用户打卡
function User_DaKa() {
    //春夏秋冬上下班时间获取
    var chuntian = sessionStorage.getItem("chuntian");
    var c_shangban = sessionStorage.getItem("c_shangban");
    var c_shangban_max = sessionStorage.getItem("c_shangban_max");
    var c_xiaban = sessionStorage.getItem("c_xiaban");
    var c_xiaban_max = sessionStorage.getItem("c_xiaban_max");

    var xiatian = sessionStorage.getItem("xiatian");
    var x_shangban = sessionStorage.getItem("x_shangban");
    var x_shangban_max = sessionStorage.getItem("x_shangban_max");
    var x_xiaban = sessionStorage.getItem("x_xiaban");
    var x_xiaban_max = sessionStorage.getItem("x_xiaban_max");

    var qiutian = sessionStorage.getItem("qiutian");
    var q_shangban = sessionStorage.getItem("q_shangban");
    var q_shangban_max = sessionStorage.getItem("q_shangban_max");
    var q_xiaban = sessionStorage.getItem("q_xiaban");
    var q_xiaban_max = sessionStorage.getItem("q_xiaban_max");

    var dongtian = sessionStorage.getItem("dongtian");
    var d_shangban = sessionStorage.getItem("d_shangban");
    var d_shangban_max = sessionStorage.getItem("d_shangban_max");
    var d_xiaban = sessionStorage.getItem("d_xiaban");
    var d_xiaban_max = sessionStorage.getItem("d_xiaban_max");

    //获取当前时间
    var dangqian_time = new Date().Format("yyyy-MM-dd");
    //获取当前时分秒
    var dangqiansfm = new Date().Format("HH:mm:ss");
    //上班打卡标记
    var dakabiaoshi_shangban = 0;
    //下班打卡标记
    var dakabiaoshi_xiaban = 0;
    //当前时间转化
    var intStart = parseInt(dangqiansfm.split(":")[0]) * 100 + parseInt(dangqiansfm.split(":")[1]);
    //春天打卡
    if ((dangqian_time >= dongtian && dangqian_time < chuntian)) {
        //上班时间转化
        var intEnd = parseInt(c_shangban.split(":")[0]) * 100 + parseInt(c_shangban.split(":")[1]);
        var intEnd_max = parseInt(c_shangban_max.split(":")[0]) * 100 + parseInt(c_shangban_max.split(":")[1]);
        //下班时间转化
        var xiaban_intEnd = parseInt(c_xiaban.split(":")[0]) * 100 + parseInt(c_xiaban.split(":")[1]);
        var xiaban_intEnd_max = parseInt(c_xiaban_max.split(":")[0]) * 100 + parseInt(c_xiaban_max.split(":")[1]);

        if (intStart < intEnd) {
            alert("上班打卡！");
            dakabiaoshi_shangban = 2;
        }
        if (intStart < intEnd_max && intStart > intEnd) {
            alert("延时打卡！");
            dakabiaoshi_shangban = 1;
        }
        if (intStart > intEnd_max && intStart < xiaban_intEnd) {
            alert("无法打卡！");
            dakabiaoshi_shangban = 0;
        }
        if (intStart > xiaban_intEnd) {
            alert("下班打卡！");
            dakabiaoshi_xiaban = 2;
        }
        if (intStart > xiaban_intEnd_max) {
            alert("延时打卡！");
            dakabiaoshi_xiaban = 1;
        }


    }
    //夏天打卡
    if ((dangqian_time >= chuntian && dangqian_time < xiatian)) {
        //上班时间转化
        var intEnd = parseInt(x_shangban.split(":")[0]) * 100 + parseInt(x_shangban.split(":")[1]);
        var intEnd_max = parseInt(x_shangban_max.split(":")[0]) * 100 + parseInt(x_shangban_max.split(":")[1]);
        //下班时间转化
        var xiaban_intEnd = parseInt(x_xiaban.split(":")[0]) * 100 + parseInt(x_xiaban.split(":")[1]);
        var xiaban_intEnd_max = parseInt(x_xiaban_max.split(":")[0]) * 100 + parseInt(x_xiaban_max.split(":")[1]);

        if (intStart < intEnd) {
            alert("上班打卡！");
            dakabiaoshi_shangban = 2;
        }
        if (intStart < intEnd_max && intStart > intEnd) {
            alert("延时打卡！");
            dakabiaoshi_shangban = 1;
        }
        if (intStart > intEnd_max && intStart < xiaban_intEnd) {
            alert("无法打卡！");
            dakabiaoshi_shangban = 0;
        }
        if (intStart > xiaban_intEnd) {
            alert("下班打卡！");
            dakabiaoshi_xiaban = 2;
        }
        if (intStart > xiaban_intEnd_max) {
            alert("延时打卡！");
            dakabiaoshi_xiaban = 1;
        }


    }
    //秋天打卡
    if ((dangqian_time >= xiatian && dangqian_time < qiutian)) {
        //上班时间转化
        var intEnd = parseInt(q_shangban.split(":")[0]) * 100 + parseInt(q_shangban.split(":")[1]);
        var intEnd_max = parseInt(q_shangban_max.split(":")[0]) * 100 + parseInt(q_shangban_max.split(":")[1]);
        //下班时间转化
        var xiaban_intEnd = parseInt(q_xiaban.split(":")[0]) * 100 + parseInt(q_xiaban.split(":")[1]);
        var xiaban_intEnd_max = parseInt(q_xiaban_max.split(":")[0]) * 100 + parseInt(q_xiaban_max.split(":")[1]);

        if (intStart < intEnd) {
            alert("上班打卡！");
            dakabiaoshi_shangban = 2;
        }
        if (intStart < intEnd_max && intStart > intEnd) {
            alert("延时打卡！");
            dakabiaoshi_shangban = 1;
        }
        if (intStart > intEnd_max && intStart < xiaban_intEnd) {
            alert("无法打卡！");
            dakabiaoshi_shangban = 0;
        }
        if (intStart > xiaban_intEnd) {
            alert("下班打卡！");
            dakabiaoshi_xiaban = 2;
        }
        if (intStart > xiaban_intEnd_max) {
            alert("延时打卡！");
            dakabiaoshi_xiaban = 1;
        }


    }
    //冬天打卡
    if ((dangqian_time >= qiutian && dangqian_time < dongtian)) {
        //上班时间转化
        var intEnd = parseInt(d_shangban.split(":")[0]) * 100 + parseInt(d_shangban.split(":")[1]);
        var intEnd_max = parseInt(d_shangban_max.split(":")[0]) * 100 + parseInt(d_shangban_max.split(":")[1]);
        //下班时间转化
        var xiaban_intEnd = parseInt(d_xiaban.split(":")[0]) * 100 + parseInt(d_xiaban.split(":")[1]);
        var xiaban_intEnd_max = parseInt(d_xiaban_max.split(":")[0]) * 100 + parseInt(d_xiaban_max.split(":")[1]);

        if (intStart < intEnd) {
            alert("上班打卡！");
            dakabiaoshi_shangban = 2;
        }
        if (intStart < intEnd_max && intStart > intEnd) {
            alert("延时打卡！");
            dakabiaoshi_shangban = 1;
        }
        if (intStart > intEnd_max && intStart < xiaban_intEnd) {
            alert("无法打卡！");
            dakabiaoshi_shangban = 0;
        }
        if (intStart > xiaban_intEnd) {
            alert("下班打卡！");
            dakabiaoshi_xiaban = 2;
        }
        if (intStart > xiaban_intEnd_max) {
            alert("延时打卡！");
            dakabiaoshi_xiaban = 1;
        }


    }
    //打卡备注
    var beizu = "";
    if (dakabiaoshi_shangban == 0) {
        beizu = "（上班）旷工一次";
    }
    if (dakabiaoshi_shangban == 1) {
        beizu = "（上班）延时打卡一次";
    }
    if (dakabiaoshi_shangban == 2) {
        beizu = "（上班）打卡成功";
    }
    if (dakabiaoshi_xiaban == 2) {
        beizu = "（下班）打卡成功";
    }
    if (dakabiaoshi_xiaban == 1) {
        beizu = "（下班）延时打卡一次";
    }
    if (dakabiaoshi_xiaban == 0) {
        beizu = "（下班）缺卡一次";
    }
    //打卡标记
    var dakabiaoji = dakabiaoshi_shangban + dakabiaoshi_xiaban;
    //工号和部门ID
    var gonghao = sessionStorage.getItem("userid");
    var dept_id = sessionStorage.getItem("dep_id");
    $.ajax({
        url: "/YYW/my_Handler/home_page_handler.ashx?act=user_daka",
        data: { "userid": gonghao, "dept_id": dept_id, "dangqian_time": dangqian_time, "beizhu": beizu, "dakabiaoji": dakabiaoji},
        dataType: "json",
        type: "post",
        success: function (obj)
        {
            alert(obj.msg);
        }        
    });
};
//发送邮件（申请）
function Email_Return() {
    //收信人工号
    var js_userid = sessionStorage.getItem("jieshourenid")
    if (js_userid == 0) {
        alert("请选择发送人");
        return;
    }
    var tal = $("#tal").text();
    var gonghao = sessionStorage.getItem("userid");
    var beizhu = $("#qj_beizhu").val();
    if (beizhu == "") {
        alert("请输入请假事由！")
        return;
    }

    var start_time = $("#start_time").val();
    var end_time = $("#end_time").val();
    var stdt = new Date(start_time.replace("-", "/"));
    var etdt = new Date(end_time.replace("-", "/"));
    if (stdt > etdt) {
        alert("开始时间必须小于结束时间")
        return;
    }
    var t_time = new Date().Format("yyyy-MM-dd HH:mm:ss");

    $.ajax({
        url: "/YYW/my_Handler/home_page_handler.ashx?act=em_rtn",
        data: { "tal": tal, "number": gonghao, "js_userid": js_userid, "beizhu": beizhu, "t_time": t_time, "start_time": start_time, "end_time": end_time },
        type: "post",
        dataType: "json",
        success: function (rs) {
            if (rs.code == 200) {
                alert(rs.msg);
                $("#kaoqin").html("");
                $("#kaoqin").hide();
                $(".Mask_z").hide();
            }
            else
                alert(rs.msg);
        }
    });
}

//发送休假邮件（申请）
function XJ_Email_Return() {
    //收信人工号
    var xjjs_userid = sessionStorage.getItem("xj_jieshourenid")
    if (xjjs_userid == 0) {
        alert("请选择发送人");
        return;
    }
    var xj_tal = $("#xj_tal").text();
    var xj_gonghao = sessionStorage.getItem("userid");
    var xj_beizhu = $("#xj_beizhu").val();
    var xj_time = new Date().Format("yyyy-MM-dd HH:mm:ss");

    var xj_start_time = $("#xj_start_time").val();
    var xj_end_time = $("#xj_end_time").val();
    var stdt = new Date(xj_start_time.replace("-", "/"));
    var etdt = new Date(xj_end_time.replace("-", "/"));
    if (stdt > etdt) {
        alert("开始时间必须小于结束时间")
        return;
    }

    $.ajax({
        url: "/YYW/my_Handler/home_page_handler.ashx?act=xj_em_rtn",
        data: { "xj_tal": xj_tal, "xj_number": xj_gonghao, "xjjs_userid": xjjs_userid, "xj_beizhu": xj_beizhu, "xj_time": xj_time, "xj_start_time": xj_start_time, "xj_end_time": xj_end_time },
        type: "post",
        dataType: "json",
        success: function (rs) {
            if (rs.code == 200) {
                alert(rs.msg);
                $("#kaoqin").html("");
                $("#kaoqin").hide();
                $(".Mask_z").hide();
            }
            else
                alert(rs.msg);
        }
    });
}



//页面显示-----------------------------------------------------------------------

//审批显示
function QingJiaShenPi()
{
    var gonghao = sessionStorage.getItem("user");
    var userid = sessionStorage.getItem("userid");
    $.ajax({
        url: "/YYW/my_Handler/home_page_handler.ashx?act=em_rtn_sp",
        data: { "gonghao": gonghao, "userid": userid },
        type: "post",
        dataType: "json",
        success: function (rs) {
            console.log(rs);
                for (var i = 0; i < rs.length; i++) {                 
                    var html = "<tbody><tr>"
                    html += "<td class='sp_td'>" + rs[i].name + "</td>";
                    html += "<td class='sp_td'>" + rs[i].MessageSendTime + "</td>";
                    html += "<td class='sp_td' colspan='2'>" + rs[i].MessageContent+"</td>";
                    html += "<td class='sp_td'>" + rs[i].MessageTitle+"</td>";
                    html += "<td class='sp_td'><input type='button' value='同意' class='anniu' onclick='btn_shenpi(this)'><input type='button' value='不同意' class='anniu' onclick='btn_shenpi(this)'></td>";
                    html += "</tr></tbody>";
                    $("#shenpi_table").append($(html));      
            }
        }
    })
}
//待办事宜

//会议显示

//考勤
function KaoQin() {
    var userid = sessionStorage.getItem("userid");
    $.ajax({
        url: "/YYW/my_Handler/home_page_handler.ashx?act=kaoqin",
        data: { "userid": userid},
        dataType: "json",
        type: "post",
        success: function (rs) {
            $("#chidao").val(rs[0]);
            $("#queka").val(rs[1]);
            $("#kuanggong").val(rs[2]);
            $("#quanqin").val(rs[3]);
        }
    })
}

//内部邮件