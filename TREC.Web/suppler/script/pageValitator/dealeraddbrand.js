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
    //    $("#txtcompanytitle").formValidator({ onShow: "请输入厂商名称", onFocus: "厂商名称至少3个字符,最多50个字符", onCorrect: "该厂商名称可以注册" }).inputValidator({ min: 3, max: 50, onError: "你输入的厂商名称非法,请确认" })//.regexValidator({regExp:"username",dataType:"enum",onError:"用户名格式不正确"})
    //	    .ajaxValidator({
    //	        dataType: "html",
    //	        async: true,
    //	        url: "../ajax/ajaxSupplerValidator.ashx?type=checkcompanytitle2",
    //	        success: function (data) {
    //	            if (data.indexOf("该厂商名称可以注册") > -1) { return true; } else {
    //	                return data;
    //	            }
    //	        },
    //	        buttons: $("#btnSave"),
    //	        error: function (jqXHR, textStatus, errorThrown) { alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown); },
    //	        onError: "该用厂商名称不可用，请更换用厂商名称",
    //	        onWait: "正在对用厂商名称进行合法性校验，请稍候..."
    //	    }).defaultPassed();

    //$("#txtcphone").formValidator({ onShow: "请输入工厂联系电话", onFocus: "格式例如：021-88888888", onCorrect: "谢谢你的合作" }).regexValidator({ regExp: "^(([0\\+]\\d{2,3}-)?(0\\d{2,3})-)?(\\d{7,8})(-(\\d{3,}))?$", onError: "你输入的联系电话格式不正确" });

    $("#txtbrandtitle").formValidator({ onShow: "请输入品牌名称", onFocus: "品牌名称至少3个字符,最多25个字符", onCorrect: "该品牌名称可以注册" }).inputValidator({ min: 3, max: 25, onError: "你输入的品牌名称非法,请确认" })//.regexValidator({regExp:"username",dataType:"enum",onError:"用户名格式不正确"})
	    .ajaxValidator({
	        dataType: "html",
	        async: true,
	        url: "../ajax/ajaxSupplerValidator.ashx?type=checkbrandtitle2",
	        success: function (data) {
	            if (data.indexOf("该品牌名称可以添加") > -1) { return true; } else {
	                return data;
	            }
	        },
	        buttons: $("#btnSave"),
	        error: function (jqXHR, textStatus, errorThrown) { alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown); },
	        onError: "该用品牌名称不可用，请更换用品牌名称",
	        onWait: "正在对用品牌名称进行合法性校验，请稍候..."
	    }).defaultPassed();

//    $("#txtbrandletter").formValidator({ onShow: "请输入品牌索引", onFocus: "品牌索引至少3个字符,最多15个字符", onCorrect: "该品牌索引可以注册" }).inputValidator({ min: 1, max: 25, onError: "你输入的品牌索引非法,请确认" })//.regexValidator({regExp:"username",dataType:"enum",onError:"用户名格式不正确"})
//	    .ajaxValidator({
//	        dataType: "html",
//	        async: true,
//	        url: "../ajax/ajaxSupplerValidator.ashx?type=checkbrandtitleletter2",
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
	    $("#txtbrandletter").formValidator({ onShow: "请输入品牌索引", onFocus: "品牌索引至少2个字符,最多15个字符", onCorrect: "该品牌索引可以注册" }).regexValidator({ regExp: "^[a-zA-Z]{2,15}$", onError: "你输入的品牌索引非法,请确认" });


	    $("#txtcompanytitle").formValidator({ onShow: "请输入厂商名称", onFocus: "厂商名称至少3个字符,最多50个字符", onCorrect: "该厂商名称可以注册" }).inputValidator({ min: 3, max: 50, onError: "厂商名称至少3个字符,最多50个字符" }); //.regexValidator({regExp:"username",dataType:"enum",onError:"用户名格式不正确"})
	    $("#txtmphone").formValidator({ empty: true, onShow: "请输入你的手机号码", onFocus: "格式例如：13800138000", onCorrect: "输入正确" }).regexValidator({ regExp: "^1[3|4|5|6|7|8|9][0-9]{9}$", onError: "你输入的手机号码格式不正确" });
});