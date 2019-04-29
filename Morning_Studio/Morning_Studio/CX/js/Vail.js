$(function () {
    $("#form").validate({
        rules: {
            textfield_name: "required",
            textfield_creditcard: "required",
            textfield_username: {
                required: true,
                minlength: 2
            },
            textfield_password: {
                required: true,
                minlength: 5
            },
            confirm_password: {
                required: true,
                minlength: 5,
                equalTo: ".textfield_password"
            },
            textfield_moblie: {
                required: true,
                minlength: 11,
            },
            radio: {
                required: "#checkbox:checked",
                minlength: 1
            },
        },
        messages: {
            textfield_name: "请输入您的名字",
            textfield_creditcard: "请输入您的身份证",
            textfield_username: {
                required: "请输入用户名",
                minlength: "用户名必需由两个字母组成"
            },
            textfield_password: {
                required: "请输入密码",
                minlength: "密码长度不能小于 5 个字母"
            },
            confirm_password: {
                required: "请输入密码",
                minlength: "密码长度不能小于 5 个字母",
                equalTo: "两次密码输入一致"
            },
            textfield_moblie: {
                required: "请输入一个11位数",
                minlength: "长度不能小于 11个字母"
            },
            radio: "请选择一个"
        }
    })
    $("#button").click(function () {
        var name = $("#txtLoginNo").val();
        var pwd = $("#txtPwd").val();
        $.ajax({
            url: "DataRequest.ashx?act=login",
            data: { "name": name, "pwd": pwd },
            type: "post",
            dataType: "json",
            success: function (rs) {
                if (rs.status == "success") {
                    localStorage.setItem("user", rs.user.user_id);
                    localStorage.getItem("user");
                    location.href = "index.html";
                }
            }
        });
    });
});