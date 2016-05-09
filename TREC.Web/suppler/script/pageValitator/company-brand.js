$(document).ready(function () {
    $.formValidator.initConfig({ formID: "form1", theme: "ArrowSolidBox", submitOnce: false,
        onError: function (msg, obj, errorlist) {
            $("#errorlist").empty();
            $.map(errorlist, function (msg) {
                $("#errorlist").append("<li>" + msg + "</li>")
            });
            alert(msg);
        },
        ajaxPrompt: '有数据正在异步验证，请稍等...'
    });
    //验证工厂名
//    $("#txttitle").formValidator({ onShow: "请输入品牌名称", onFocus: "品牌名称至少2个字符,最多25个字符", onCorrect: "该品牌名称可以注册" }).inputValidator({ min: 2, max: 25, onError: "你输入的品牌名称非法,请确认" })//.regexValidator({regExp:"username",dataType:"enum",onError:"用户名格式不正确"})
//	    .ajaxValidator({
//	        dataType: "html",
//	        async: true,
//	        url: "../ajax/ajaxSupplerValidator.ashx?type=checkbrandtitle",
//	        success: function (data) {
//	            if (data.indexOf("该品牌名称可以添加") > -1) { return true; } else {
//	                return data;
//	            }
//	        },
//	        buttons: $("#btnSave"),
//	        error: function (jqXHR, textStatus, errorThrown) { alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown); },
//	        onError: "该用品牌名称不可用，请更换用品牌名称",
//	        onWait: "正在对用品牌名称进行合法性校验，请稍候..."
//	    }).defaultPassed();

    $("#txtletter").formValidator({ onShow: "请输入品牌索引", onFocus: "品牌索引至少2个字符,最多15个字符", onCorrect: "该品牌索引可以注册" }).regexValidator({ regExp: "^[a-zA-Z]{2,15}$", onError: "你输入的品牌索引非法,请确认" }); //.regexValidator({regExp:"username",dataType:"enum",onError:"用户名格式不正确"})
    //	    .ajaxValidator({
    //	        dataType: "html",
    //	        async: true,
    //	        url: "../ajax/ajaxSupplerValidator.ashx?type=checkbrandtitleletter",
    //	        success: function (data) {
    //	            if (data.indexOf("该品牌索引可以添加") > -1) { return true; } else {
    //	                return data;
    //	            }
    //	        },
    //	        buttons: $("#btnSave"),
    //	        error: function (jqXHR, textStatus, errorThrown) { alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown); },
    //	        onError: "该用品牌索引不可用，请更换用品牌索引",
    //	        onWait: "正在对用品牌索引进行合法性校验，请稍候..."
    //	    }).defaultPassed();
    $("#ddlspread").formValidator({ onShow: "请选择品牌档位", onFocus: "品牌档位选择", onCorrect: "请择正确", defaultValue: "" }).inputValidator({ min: 1, onError: "请选择品牌档位!" }).defaultPassed();

});