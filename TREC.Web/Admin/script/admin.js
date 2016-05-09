//==========================页面加载时JS函数开始===============================
$(document).ready(function () {

    setWorkspace();

    //分栏点击
    $("#tableLeftMenuBar").click(function () {
        if ($("#tableLeftMenu").css("display") == "block") {
            $("#tableLeftMenu").hide();
            $(this).find("span").html("4");
        }
        else {
            $("#tableLeftMenu").show();
            $(this).find("span").html("3");
        }
    })

    //文本框焦点
    $(".input,.login_input,.textarea,.input2").focus(function () {
        if (!$(this).hasClass("tcal")) {
            $(this).addClass("focus");
        }
    }).blur(function () {
        $(this).removeClass("focus");
    });

    //输入框提示,获取拥有HintTitle,HintInfo属性的对象
    $("[HintTitle],[HintInfo]").focus(function (event) {
        $("*").stop(); //停止所有正在运行的动画
        $("#HintMsg").remove(); //先清除，防止重复出错
        var HintHtml = "<ul id=\"HintMsg\"><li class=\"HintTop\"></li><li class=\"HintInfo\"><b>" + $(this).attr("HintTitle") + "</b>" + $(this).attr("HintInfo") + "</li><li class=\"HintFooter\"></li></ul>"; //设置显示的内容
        var offset = $(this).offset(); //取得事件对象的位置
        $("body").append(HintHtml); //添加节点
        $("#HintMsg").fadeTo(0, 0.85); //对象的透明度
        var HintHeight = $("#HintMsg").height(); //取得容器高度
        $("#HintMsg").css({ "top": offset.top - HintHeight + "px", "left": offset.left + "px" }).fadeIn(500);
    }).blur(function (event) {
        $("#HintMsg").remove(); //删除UL
    });

    //列表分组
    $("div.navCur > span.t").click(function () {
        $("div.navCur > span.t").removeClass("cur");
        $(this).addClass("cur");

    })

    //    //tabs
    //    $(".msgtable").find("a.cur").siblings().each(function (index) {
    //        var thisId = $(this).attr("href");
    //        $(thisId).css("display", "none");
    //    });
    //    $(".msgtable").find("a.t").click(function () {
    //        $($(this).attr("href")).css("display", "block");
    //        $(this).addClass("cur");
    //        $(this).siblings(".t").each(function (index) {
    //            var thisId = $(this).attr("href");
    //            $(thisId).css("display", "none");
    //            $(this).removeClass("cur");
    //        });
    //        //alert("123");
    //    })
    //    

    $("#msgprint").live("click", function () {
        $(this).hide();
    })

    //setWorkspace();



});
//==========================页面加载时JS函数结束===============================

/* 设置工作区 */
function setWorkspace(e) {

    var wWidth = $(window).width();
    var wHeight = $(window).height();
    /*兼容性*/
    if (navigator.appVersion.split("MSIE") && navigator.userAgent.indexOf('Opera') === -1 && parseFloat(navigator.appVersion.split("MSIE")[1]) < 7) wWidth = wWidth - 1; if (window.innerHeight) wHeight = window.innerHeight - 1;
    //$('#workspace').width(wWidth - $('#left').width() - parseInt($('#left').css('margin-right')));
    $('#sysMain').height(wHeight - 60); //alert(wWidth);
    $("#tableConvertMain").width(wWidth - 170)
    $("#frmmain").width($("#tableConvertMain").width());
    $("#frmmain").height($("#tableConvertMain").height());

}



//===========================系统管理JS函数开始================================

//全选取消按钮函数，调用样式如：
function checkAll(chkobj) {
    if ($(chkobj).text() == "全选") {
        $(chkobj).text("取消");
        $(".checkall input").attr("checked", true);
    } else {
        $(chkobj).text("全选");
        $(".checkall input").attr("checked", false);
    }
}

//遮罩提示窗口
function jsmsg(w, h, msgtitle, msgbox, url, msgcss) {
    $("#msgdialog").remove();
    var cssname = "";
    switch (msgcss) {
        case "Success":
            cssname = "icon-01";
            break;
        case "Error":
            cssname = "icon-02";
            break;
        default:
            cssname = "icon-03";
            break;
    }
    var str = "<div id='msgdialog' title='" + msgtitle + "'><p class='" + cssname + "'>" + msgbox + "</p></div>";
    $("body").append(str);
    $("#msgdialog").dialog({
        //title: null,
        //show: null,
        bgiframe: true,
        autoOpen: false,
        width: w,
        //height: h,
        resizable: false,
        closeOnEscape: true,
        buttons: { "确定": function () { $(this).dialog("close"); } },
        modal: true
    });
    $("#msgdialog").dialog("open");
    if (url == "back") {
        frmmain.history.back(-1);
    } else if (url != "") {
        frmmain.location.href = url;
    }
}

function jsmsgCurPage(w, h, msgtitle, msgbox, url, msgcss) {
    $("#msgdialog").remove();
    var cssname = "";
    switch (msgcss) {
        case "Success":
            cssname = "icon-01";
            break;
        case "Error":
            cssname = "icon-02";
            break;
        default:
            cssname = "icon-03";
            break;
    }
    var str = "<div id='msgdialog' title='" + msgtitle + "'><p class='" + cssname + "'>" + msgbox + "</p></div>";
    $("body").append(str);
    $("#msgdialog").dialog({
        //title: null,
        //show: null,
        bgiframe: true,
        autoOpen: false,
        width: w,
        height: h,
        resizable: false,
        closeOnEscape: true,
        buttons: { "确定": function () { $(this).dialog("close"); } },
        modal: true
    });
    $("#msgdialog").dialog("open");
}


//可以自动关闭的提示
function jsprint(msgtitle, url, msgcss) {
    $("#msgprint").remove();
    var cssname = "";
    switch (msgcss) {
        case "Success":
            cssname = "pcent correct";
            break;
        case "Error":
            cssname = "pcent disable";
            break;
        default:
            cssname = "pcent warning";
            break;
    }
    var str = "<div id=\"msgprint\" class=\"" + cssname + "\">" + msgtitle + "</div>";
    $("body").append(str);
    $("#msgprint").show();
    if (url == "back") {
        frmmain.history.back(-1);
    } else if (url != "") {
        frmmain.location.href = url;
    }
    //3秒后清除提示
    setTimeout(function () {
        $("#msgprint").fadeOut(500);
        //如果动画结束则删除节点
        if (!$("#msgprint").is(":animated")) {
            $("#msgprint").remove();
        }
    }, 6000);
}

//可以自动关闭的提示
function jsprintCurPage(msgtitle, url, msgcss) {
    $("#msgprint").remove();
    var cssname = "";
    switch (msgcss) {
        case "Success":
            cssname = "pcent correct";
            break;
        case "Error":
            cssname = "pcent disable";
            break;
        default:
            cssname = "pcent warning";
            break;
    }
    var str = "<div id=\"msgprint\" class=\"" + cssname + "\">" + msgtitle + "</div>";
    $("body").append(str);
    $("#msgprint").show();
    var outT = 900;
    var outT2 = 3000;
    if (url == "thickbox") {
        outT = 500;
        outT2 = 1500;
    }

    //3秒后清除提示
    setTimeout(function () {
        $("#msgprint").fadeOut(outT);
        //如果动画结束则删除节点
        if (!$("#msgprint").is(":animated")) {
            $("#msgprint").remove();
        }
        if (url == "back") {
            this.history.back(-1);
        } else if (url == "#") {
            return;
        } else if (url == "thickbox") {
            TB_iframeContent.location.href = $("#TB_iframeContent").attr("src");
        } else if (url != "") {
            this.location.href = url;
        }
    }, outT2);

}

