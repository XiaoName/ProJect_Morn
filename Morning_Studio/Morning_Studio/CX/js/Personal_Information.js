$(function () {
    //储存登录用户工号
    var job = sessionStorage.getItem("user"); $("#JobNumber1").text(job);
    //储存用户名字
    var name = sessionStorage.getItem("username"); $("#Name1").text(name);
    //储存用户性别
    var sex = sessionStorage.getItem("usersex"); $("#Sex1").text(sex);
    //储存银行卡号
    var ygcard = sessionStorage.getItem("ygcard"); $("#id_card").val(ygcard);
    //储存用户邮箱
    var email = sessionStorage.getItem("useremail"); $("#email").val(email);
    //储存用户地址
    var address = sessionStorage.getItem("useraddress"); $("#address").val(address);
    //储存用户户口
    var account = sessionStorage.getItem("useraccount"); $("#huk").val(account);
    //储存用户生日
    var brithday = sessionStorage.getItem("userBrithday"); $("#birthday").val(gettime(brithday));
    //储存用户身份证
    var card = sessionStorage.getItem("userIdCard"); $("#ic_card").val(card);
    //储存用户电话号码
    var phone = sessionStorage.getItem("userPhone"); $("#mobile").val(phone);
    //储存登陆部门名称
    $("#DepartID1").text("市场部");
    //储存登陆职务名称
    $("#PositionId1").text("人事主管");

    //保存按钮
    inform_btn();
});
function inform_btn() {
    $("#inform_btn").click(function () {
        //$.ajax({
        //    url: "../CX/CX_Handler.ashx?act=GetUpUsers",
        //    type: "post",
        //    dataType: "json",
        //    data: $("#my_form").serialize(),
        //    success: function (str) {
        //        alert("");
        //        if (str.code == 200) {
        //            alert(str.msg);
        //        } else {
        //            alert(str.msg);
        //        }
        //    }
        //})
    });
}

function gettime(t) {
    var _time = new Date(t);
    var year = _time.getFullYear();//2017
    var month = _time.getMonth() + 1;//7
    var date = _time.getDate();//10
    return year + "年" + month + "月" + date + "日   ";//这里自己按自己需要的格式拼接
}