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
    $("#txttitle").formValidator({ onShow: "请输入卖场名称,例：金盛国际家居广场(上海)", onFocus: "卖场名称至少3个字符,最多25个字符", onCorrect: "该卖场名称可以注册" }).inputValidator({ min: 3, max: 25, onError: "你输入的卖场名称非法,请确认" })//.regexValidator({regExp:"username",dataType:"enum",onError:"用户名格式不正确"})
	    .ajaxValidator({
	        dataType: "html",
	        async: true,
	        url: "../ajax/ajaxSupplerValidator.ashx?type=checkmarkettitle2",
	        success: function (data) {
	            if (data.indexOf("卖场名称可以添加") > -1) { return true; } else {
	                return data;
	            }
	        },
	        buttons: $("#btnSave"),
	        error: function (jqXHR, textStatus, errorThrown) { alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown); },
	        onError: "该用卖场名称不可用，请更换用卖场名称",
	        onWait: "正在对用卖场名称进行合法性校验，请稍候..."
	    }).defaultPassed();

//	    $("#txtletter").formValidator({ onShow: "请输入卖场索引,索引为英文名或拼音", onFocus: "请输入卖场名称的首字母缩写", onCorrect: "该卖场索引可以使用" }).inputValidator({ min: 3, max: 25, onError: "你输入的卖场索引非法,请确认" })//.regexValidator({regExp:"username",dataType:"enum",onError:"用户名格式不正确"})
//	    .ajaxValidator({
//	        dataType: "html",
//	        async: true,
//	        url: "../ajax/ajaxSupplerValidator.ashx?type=checkmarketletter",
//	        success: function (data) {
//	            if (data.indexOf("卖场索引可以添加") > -1) { return true; } else {
//	                return data;
//	            }
//	        },
//	        buttons: $("#btnSave"),
//	        error: function (jqXHR, textStatus, errorThrown) { alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown); },
//	        onError: "该用卖场索引不可用，请更换用卖场索引",
//	        onWait: "正在对用卖场索引进行合法性校验，请稍候..."
	    //	    }).defaultPassed();
	    $("#txtletter").formValidator({ onShow: "请输入卖场索引,索引为英文名或拼音", onFocus: "请输入卖场名称的首字母缩写", onCorrect: "该卖场索引可以使用" }).regexValidator({ regExp: "^[a-zA-Z]{2,15}$", onError: "你输入的卖场索引非法,请确认" });

	    //,,,
	    $("#txtlphone").formValidator({ empty: true, onShow: "请输入卖场投诉服务电话", onFocus: "格式例如：021-88888888", onCorrect: "谢谢你的合作", onEmpty: "" }).regexValidator({ regExp: "^(([0\\+]\\d{2,3}-)?(0\\d{2,3})-)?(\\d{7,8})(-(\\d{3,}))?$", onError: "你输入的卖场投诉服务电话格式不正确" });
	    //$("#txtphone").formValidator({ onShow: "请输入你的联系电话，可以为空哦", onFocus: "格式例如：021-88888888", onCorrect: "谢谢你的合作"}).regexValidator({ regExp: "^(([0\\+]\\d{2,3}-)?(0\\d{2,3})-)?(\\d{7,8})(-(\\d{3,}))?$", onError: "你输入的联系电话格式不正确" });
	    $("#txtzphone").formValidator({ onShow: "请输入卖场招商电话", onFocus: "格式例如：021-88888888", onCorrect: "谢谢你的合作" }).regexValidator({ regExp: "^(([0\\+]\\d{2,3}-)?(0\\d{2,3})-)?(\\d{7,8})(-(\\d{3,}))?$", onError: "你输入的卖场招商格式不正确" });
	    $("#txtaddress").formValidator({ onShow: "请输入详细街道地址", onFocus: "请输入详细街道地址", onCorrect: "正确" }).inputValidator({ min: 3, onError: "街道地址输入不正确" });
	    $("#txtfax").formValidator({ onShow: "请输入你的联系传真", onFocus: "格式例如：021-88888888", onCorrect: "输入正确" }).regexValidator({ regExp: "^(([0\\+]\\d{2,3}-)?(0\\d{2,3})-)?(\\d{7,8})(-(\\d{3,}))?$", onError: "你输入的联系传真格式不正确" });
	    $("#txtemail").formValidator({ empty: true, onShow: "请输入邮箱", onFocus: "请正确输入您的电子邮箱", onCorrect: "恭喜你,你输对了" }).inputValidator({ min: 6, max: 100, onError: "你输入的邮箱长度非法,请确认" }).regexValidator({ regExp: "^([\\w-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([\\w-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$", onError: "你输入的邮箱格式不正确" });


});