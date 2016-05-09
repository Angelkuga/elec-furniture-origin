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
    $("#txtmarkettitle").formValidator({ onShow: "请输入卖场名称,例：金盛国际家居广场(上海)", onFocus: "卖场名称至少3个字符,最多25个字符", onCorrect: "该卖场名称可以注册" }).inputValidator({ min: 3, max: 25, onError: "你输入的卖场名称非法,请确认" })//.regexValidator({regExp:"username",dataType:"enum",onError:"用户名格式不正确"})
	    .ajaxValidator({
	        dataType: "html",
	        async: true,
	        url: "../ajax/ajaxSupplerValidator.ashx?type=checkmarkettitle",
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
	    $("#txtphone").formValidator({ empty: true, onShow: "请输入你的联系电话，可以为空哦", onFocus: "格式例如：021-88888888", onCorrect: "谢谢你的合作", onEmpty: "你真的不想留联系电话了吗？" }).regexValidator({ regExp: "(^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$)|(^(4[0]{2})+(\-[0-9]{3})+(\-[0-9]{4})?$)|(^(4[0]{2})+([0-9]{7})?$)|(^1[3|4|5|6|7|8|9][0-9]{9}$)", onError: "你输入的联系电话格式不正确" });
    
});