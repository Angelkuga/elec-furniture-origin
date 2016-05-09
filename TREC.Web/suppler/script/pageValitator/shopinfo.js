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
    $("#txttitle").formValidator({ onShow: "请输入店铺名称,例：红星美凯隆全友店", onFocus: "店铺名称至少3个字符,最多25个字符", onCorrect: "该店铺名称可以注册" }).inputValidator({ min: 3, max: 25, onError: "你输入的店铺名称非法,请确认" })//.regexValidator({regExp:"username",dataType:"enum",onError:"用户名格式不正确"})
	    .ajaxValidator({
	        dataType: "html",
	        async: true,
	        url: "../ajax/ajaxSupplerValidator.ashx?type=checkshoptitle",
	        success: function (data) {
	            if (data.indexOf("店铺名称可以添加") > -1) { return true; } else {
	                return data;
	            }
	        },
	        buttons: $("#btnSave"),
	        error: function (jqXHR, textStatus, errorThrown) { alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown); },
	        onError: "该用店铺名称不可用，请更换用店铺名称",
	        onWait: "正在对用店铺名称进行合法性校验，请稍候..."
	    }).defaultPassed();
	    //$("z").formValidator({ tipID: "test3Tip", onShow: "请选择你的兴趣爱好（至少选一个）", onFocus: "你至少选择1个", onCorrect: "恭喜你,你选对了" }).inputValidator({ min: 1, onError: "你选的个数不对" });
	//$(":checkbox").formValidator({ tipID: "chkbrandlistTip", onShow: "选择店铺销售产品品牌（至少选一个）", onFocus: "你至少选择1个", onCorrect: "正确" }).inputValidator();
	    $("#txtphone").formValidator({ onShow: "请输入您的联系方式", onFocus: "格式：021-88888888或者13800138000", onCorrect: "谢谢您的合作", onEmpty: "你真的不想留联系方式了吗？" }).regexValidator({ regExp: "(^(([0\\+]\\d{2,3}-)?(0\\d{2,3})-)?(\\d{7,8})(-(\\d{3,}))?$)|(^1[3|4|5|6|7|8|9][0-9]{9}$)", onError: "你输入的联系方式格式不正确" });
	    $("#txtqq").formValidator({ empty: true, onShow: "请输入你店铺的客服QQ", onFocus: "格式例如：123456789", onCorrect: "输入正确" }).regexValidator({ regExp: "^[0-9]{3,13}$", onError: "你输入的客服QQ格式不正确" });
	    $("#txtletter").formValidator({ onShow: "请输入店铺索引", onFocus: "店铺索引至少2个字符,最多15个字符", onCorrect: "该店铺索引可以注册" }).regexValidator({ regExp: "^[a-zA-Z]{2,35}$", onError: "你输入的店铺索引非法,请确认" });
    
});