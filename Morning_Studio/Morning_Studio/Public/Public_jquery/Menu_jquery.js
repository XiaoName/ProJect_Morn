
/*菜单栏代码*/
$(function () {
    //退出按钮
    $("#btn_tuichu").click(function () {
        custom_close();
    });
    $("#img_tuichu").click(function () {
        custom_close();
    });
    $("#btn_zhuye").click(function () {
        window.location.href = "Home.html"
    });
    $("#img_zhuye").click(function () {
        window.location.href = "Home.html"
    });
    //自动生成第二级菜单
    var biaoji=0;
    $(".s1").click(function () {
        if (biaoji == 0) {
            /*鼠标滑过第一层菜单展开第二层菜单*/
            $(".p2").css("transform", "rotate(0deg)");
            Memu_Two_Select();
            biaoji++;
            return;
        }
        else {
            /*鼠标离开第一层菜单关闭第二层菜单*/
            $(".p2").find(".s2").remove();
            biaoji = 0;
            return;
        }
    });


    $(".p2").delegate("click", "a[name='Url']", function () {

        alert();
    })
});


//退出按钮
function custom_close() {
    if
    (confirm("您确定要退出本页吗？")) {
        window.opener = null;
        window.open('', '_self');
        window.close();
        window.opener.location.href = "OA_Login.html";
    }
    else { }
}
//查询并生成第二级，三级菜单
function Memu_Two_Select() {
    $.ajax({
        url: "../Public_Hander/Handler.ashx?act=menu_select",
        dataType: "json",
        type: "post",
        success: function (rs) {
            //二级菜单个数获取
            var Menu_Two_Num = rs.length;
            var aa = Math.ceil(90 / Menu_Two_Num);
            var Menu_dange = aa.toFixed(1);
            for (var i = 0; i < Menu_Two_Num; i++) {
                if (i % 2 == 0) {
                    var html = "<li class='s2'>";
                    html += "<a href='#url' name='Url' class='li_a' id='One_" + (i + 1) + "'style='background-color:#999;display:block;transform:rotate(" + i * Menu_dange + "deg)'><span>" + rs[i].PermissiosName + "</span></a>";
                    html += "<ul class='p3' id='Ul_One_" + rs[i].PermissiosID + "'></ul>";
                    html += "</li>";
                    $(".p2").append($(html));
                }
                else {
                    var html = "<li class='s2'>";
                    html += "<a href='#url'  class='li_a' id='One_" + (i + 1) + "'style='background-color:#888;display:block;transform:rotate(" + i * Menu_dange + "deg)'><span>" + rs[i].PermissiosName + "</span></a>";
                    html += "<ul class='p3' id='Ul_One_" + rs[i].PermissiosID + "'></ul>";
                    html += "</li>";
                    $(".p2").append($(html));
                }
                for (var j = 0; j < rs[i].PermissiosName2.length; j++) {
                    var bb = Math.ceil(90 / rs[i].PermissiosName2.length);
                    var Menu_Two_dange = bb.toFixed(1);
                    if (j % 2 == 0) {
                        var htl = "<li><a onclick='UrlLoction(this)' flog='Url_id_" + rs[i].PermissiosName2[j].PermissiosID+"' style='background-color:#888;transform:rotate(" + j * Menu_Two_dange + "deg)'> " + rs[i].PermissiosName2[j].PermissiosName + "</a></li> ";
                        $("#Ul_One_" + rs[i].PermissiosID).append($(htl));
                    }
                    if (j % 2 != 0) {
                        var htl = "<li><a  onclick='UrlLoction(this)' flog='Url_id_" + rs[i].PermissiosName2[j].PermissiosID +"' style='background-color:#999;transform:rotate(" + j * Menu_Two_dange + "deg)'>" + rs[i].PermissiosName2[j].PermissiosName + "</a></li>";
                        $("#Ul_One_" + rs[i].PermissiosID).append($(htl));
                    }

                }
            }

        }
    });
}

//网页生成
function UrlLoction(obj) {
   
   var id= obj.getAttribute("flog");
    $.ajax({
        url: "../My_Url/My_Url.js",
        type: "get",
        dataType: "json",
        success: function (a) {
            $("#iframe_url").attr("src",a[0][id]);
        }

    });

}





