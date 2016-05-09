$(function () {
    $(".msgtable tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
    $(".msgtable tr").hover(
			    function () {
			        $(this).addClass("tr_hover_col");
			    },
			    function () {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
    $("input[type='text'].input").focus(function () {
        if (!$(this).hasClass("tcal")) {
            $(this).addClass("focus");
        }
    }).blur(function () {
        $(this).removeClass("focus");
    });
});
//设置为自动高
function SetWinHeight(obj) {
	var win = obj;
	if (document.getElementById) {
		if (win && !window.opera) {
			if (win.contentDocument && win.contentDocument.body.offsetHeight)
			    win.height = win.contentDocument.body.offsetHeight + 100;
			else if (win.Document && win.Document.body.scrollHeight)
			    win.height = win.Document.body.scrollHeight + 100;
		}
	}
}

//全选取消按钮函数，调用样式如：
function checkAll(chkobj) {
    if ($(chkobj).text() == "全选") {
        $(chkobj).text("取消");
        $(".checkall").each(function () {
            if ($(this).attr("disabled") != 'disabled') {
                $(this).find("input").attr("checked", true);
            }
        });
        
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
        mainFrame.history.back(-1);
    } else if (url != "") {
        mainFrame.location.href = url;
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
        mainFrame.history.back(-1);
    } else if (url != "") {
        mainFrame.location.href = url;
    }
    //3秒后清除提示
    setTimeout(function () {
        $("#msgprint").fadeOut(500);
        //如果动画结束则删除节点
        if (!$("#msgprint").is(":animated")) {
            $("#msgprint").remove();
        }
    }, 3000);
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

function SetPermission() {
    $("#SetPermission").remove();
    var str = "<div id='SetPermission' style='width:100%; position:fixed; z-index:99999999; background:#000; left:0px; top:0px; bottom:0px; right:0px; display:none;'></div>";
    $("body").append(str);
    $("#SetPermission").css("display", "block").animate({ opacity: 0.1 });
}