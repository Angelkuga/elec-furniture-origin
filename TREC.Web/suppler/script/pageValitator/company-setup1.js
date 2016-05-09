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
    $("#txttitle").formValidator({ onShow: "请输入厂商名称", onFocus: "厂商名称至少3个字符,最多45个字符", onCorrect: "该厂商名称可以注册" }).inputValidator({ min: 3, max: 45, onError: "你输入的厂商名称非法,请确认" })//.regexValidator({regExp:"username",dataType:"enum",onError:"用户名格式不正确"})
	    .ajaxValidator({
	        dataType: "html",
	        async: true,
	        url: "../ajax/ajaxSupplerValidator.ashx?type=checkcompanytitle",
	        success: function (data) {
	            if (data.indexOf("该厂商名称可以注册") > -1) { return true; } else {
	                return data;
	            }
	        },
	        buttons: $("#btnSave"),
	        error: function (jqXHR, textStatus, errorThrown) { alert("服务器没有返回数据，可能服务器忙，请重试" + errorThrown); },
	        onError: "该用厂商名称不可用，请更换用厂商名称",
	        onWait: "正在对用厂商名称进行合法性校验，请稍候..."
	    }).defaultPassed();
	    $("#txtphone").formValidator({ onShow: "请输入你的联系电话", onFocus: "格式例如：021-88888888", onCorrect: "输入正确" }).regexValidator({ regExp: "(^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$)|(^(4[0]{2})+(\-[0-9]{3})+(\-[0-9]{4})?$)|(^(4[0]{2})+([0-9]{7})?$)|(^1[3|4|5|6|7|8|9][0-9]{9}$)", onError: "你输入的联系电话格式不正确" });
    $("#txtfax").formValidator({ empty: true, onShow: "请输入你的联系传真", onFocus: "格式例如：021-88888888", onCorrect: "输入正确" }).regexValidator({ regExp: "^(([0\\+]\\d{2,3}-)?(0\\d{2,3})-)?(\\d{7,8})(-(\\d{3,}))?$", onError: "你输入的联系传真格式不正确" });
    $("#txtemail").formValidator({ empty: true, onShow: "请输入邮箱", onFocus: "请正确输入您的电子邮箱", onCorrect: "恭喜你,你输对了" }).inputValidator({ min: 6, max: 100, onError: "你输入的邮箱长度非法,请确认" }).regexValidator({ regExp: "^([\\w-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([\\w-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$", onError: "你输入的邮箱格式不正确" });
    var strRegexss = "^((https|http)?://)"
            + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //ftp的user@ 
            + "(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP形式的URL- 199.194.52.184 
            + "|" // 允许IP和DOMAIN（域名）
            + "([0-9a-z_!~*'()-]+\.)*" // 域名- www. 
            + "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // 二级域名 
            + "[a-z]{2,6})" // first level domain- .com or .museum 
            + "(:[0-9]{1,4})?" // 端口- :80 
            + "((/?)|" // a slash isn't required if there is no file name 
            + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
    //$("#txthomepage").formValidator({ empty: true, onShow: "请输入你的网址", onFocus: "格式例如：http://www.jiajuks.com", onCorrect: "输入正确" }).regexValidator({ regExp: strRegexss, onError: "你输入的网址格式不正确" });
    $("#txtmphone").formValidator({ empty: true, onShow: "请输入你的手机号码", onFocus: "格式例如：13800138000", onCorrect: "输入正确" }).regexValidator({ regExp: "^1[3|4|5|6|7|8|9][0-9]{9}$", onError: "你输入的手机号码格式不正确" });
    $("#txtaddress").formValidator({ onShow: "请输入你的地址", onFocus: "格式例如：长临路969弄308室", onCorrect: "输入正确" }).inputValidator({ min: 3, max: 100, onError: "你输入的地址格式不正确" });
    $("#ddlareacode_city").formValidator({ onShow: "请选择地区", onFocus: "地区选择", onCorrect: "请择正确", defaultValue: "" }).inputValidator({ min: 1, onError: "请选择地区!" }).defaultPassed();
});