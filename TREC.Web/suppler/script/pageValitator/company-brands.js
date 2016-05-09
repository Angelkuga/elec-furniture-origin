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
    $("#txttitle").formValidator({ onShow: "请输入系列名称", onFocus: "系列名称至少1个字符,最多25个字符", onCorrect: "该系列名称可以注册" }).inputValidator({ min: 1, max: 25, onError: "你输入的系列名称非法,请确认" }); //.regexValidator({regExp:"username",dataType:"enum",onError:"用户名格式不正确"})
    //	    .ajaxValidator({
    //	        dataType: "html",
    //	        async: true,
    //	        url: "../ajax/ajaxSupplerValidator.ashx?type=checkbrandstitle",
    //	        success: function (data) {
    //	            if (data.indexOf("该系列名称可以添加") > -1) { return true; } else {
    //	                return data;
    //	            }
    //	        },
    //	        buttons: $("#btnSave"),
    //	        error: function (jqXHR, textStatus, errorThrown) { alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown); },
    //	        onError: "该用系列名称不可用，请更换用系列名称",
    //	        onWait: "正在对用系列名称进行合法性校验，请稍候..."
    //	    }).defaultPassed();

    $("#ddlbrand").formValidator({ onShow: "请选择品牌名称", onFocus: "品牌名称选择", onCorrect: "请择正确", defaultValue: "" }).inputValidator({ min: 1, onError: "请选择品牌名称!" }).defaultPassed();
    $("#ddlmaterial").formValidator({ onShow: "请选择品牌材质", onFocus: "品牌牌材选择", onCorrect: "请择正确", defaultValue: "" }).inputValidator({ min: 1, onError: "请选择品牌材质!" }).defaultPassed();
    $("#ddlstyle").formValidator({ onShow: "请选择品牌风格", onFocus: "品牌风格选择", onCorrect: "请择正确", defaultValue: "" }).inputValidator({ min: 1, onError: "请选择品牌风格!" }).defaultPassed();
    $("#ddlcolor").formValidator({ onShow: "请选择品牌色系", onFocus: "品牌色系选择", onCorrect: "请择正确", defaultValue: "" }).inputValidator({ min: 1, onError: "请选择品牌色系!" }).defaultPassed();

});