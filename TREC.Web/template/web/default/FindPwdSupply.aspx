<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindPwdSupply.aspx.cs"
    Inherits="TREC.Web.FindPwdSupply" %>

<%@ Register Src="ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="ascx/_headA.ascx" TagName="_headA" TagPrefix="uc4" %>
<%@ Register Src="ascx/_foot.ascx" TagName="_foot" TagPrefix="uc5" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>家具快搜 - 商家找回密码</title>
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <meta name="keywords" content="家具品牌,家具品牌排名,家具十大品牌,品牌家具,实木家具十大品牌,儿童家具十大品牌,板式家具十大品牌">
    <meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！">
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/index/index.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/js/core.js" type="text/javascript"></script>
    <style>
        .zhuce
        {
            width: 1000px;
            height: 530px;
            margin: 20px auto;
            font-size: 14px;
            font-family: 微软雅黑;
            position: relative;
        }
        .zhucey
        {
            width: 260px;
            height: 250px;
            position: absolute;
            right: 50px;
            top: 100px;
            background: url(/resource/images/sx.gif) left no-repeat;
            text-align: center;
            padding-left: 75px;
        }
        .zhucexy
        {
            width: 600px;
            height: 380px;
            position: absolute;
            padding: 10px;
            overflow-x: hidden;
            overflow-y: scroll;
            left: 375px;
            background: #fff;
            top: 50px;
            border: 1px solid #c7c7c7;
            z-index: 999;
        }
        .dis
        {
            display: block;
        }
        .undis
        {
            display: none;
        }
        .undis p, .dis p
        {
            margin: 10px 0;
        }
        .undis input, .dis input
        {
            width: 258px;
            height: 36px;
            line-height: 36px;
            padding-left: 6px;
        }
        .undis input.iptd, .dis input.iptd
        {
            width: 128px;
            height: 36px;
            line-height: 36px;
            padding-left: 6px;
        }
        .undis input.fxk, .dis input.fxk
        {
            width: 20px;
            height: 20px;
            padding: 0px;
            vertical-align: middle;
            margin-right: 10px;
        }
        .undis label, .dis label
        {
            width: 85px;
            display: inline-block;
            text-align: right;
        }
        .hszit
        {
            color: #b9003c;
            font-size: 12px;
            cursor: pointer;
        }
        .hszitt
        {
            font-size: 12px;
        }
        .nav_reg
        {
            width: 100%;
            margin: 0 auto;
            height: 40px;
            padding-top: 4px;
        }
        .nav_reg li
        {
            float: left;
            height: 40px;
            border: 1px solid #c7c7c7;
            border-bottom: none;
            margin-right: 5px;
        }
        .nav_reg li a
        {
            float: left;
            font-family: 微软雅黑;
            font-size: 14px;
            height: 40px;
            padding: 0 20px;
            text-align: center;
            line-height: 40px;
        }
        .nav_reg li.nav_reg_current a
        {
            color: #b9003c;
            background: #fff;
        }
        .nav_reg li.nav_link a
        {
            color: #333;
        }
        .nav_reg-down
        {
            border: 1px solid #c7c7c7;
            height: 350px;
            padding: 30px 40px;
            text-align: left;
        }
        input.fpwd_btnimg
        {
            width: 188px;
            height: 35px;
            border: none;
            background: url(/resource/images/zubtn.jpg) no-repeat;
            text-align: center;
            line-height: 30px;
            font-family: 微软雅黑;
            font-size: 16px;
            color: #fff;
            cursor:pointer;
        }
    </style>
    <script type="text/javascript">
        function doClick(o) {
            o.className = "nav_reg_current";
            var j;
            var id;
            var e;
            for (var i = 1; i <= 2; i++) { //这里3 需要你修改 你多少条分类 就是多少
                id = "nav_reg" + i;
                j = document.getElementById(id);
                e = document.getElementById("sub" + i);
                if (id != o.id) {
                    j.className = "nav_reg_link";
                    e.style.display = "none";
                } else {
                    e.style.display = "block";
                }
            }
        }
        $(function () {
            // 手机 找回密码 
            $("#txtRegName").blur(function () {
                var txtRegName = $("#txtRegName");
                if (txtRegName.val() != "") {
                    $.ajax({
                        url: "../ajax/ajaxuser.ashx",
                        data: 'type=checkname&v=' + txtRegName.val() + "&t=seek&ram=" + Math.random(),
                        dataType: 'text',
                        success: function (data) {
                            if (data == "false") {
                                alert("没有找到,您输入的登录用户名!");
                                txtRegName.select();
                                //  return;                                
                            }
                        }
                    });
                }
            });
            $("#txtPhone").blur(function () {
                var txtRegName = $("#txtRegName");
                var txtPhone = $("#txtPhone");
                if (txtPhone.val() != "") {
                    $.ajax({
                        url: "../ajax/ajaxuser.ashx",
                        data: 'type=checkmoblieemail&v=' + txtPhone.val() + "&v2=" + txtRegName.val() + "&t=mobliname&ram=" + Math.random(),
                        dataType: 'text',
                        success: function (data) {
                            if (data == "false") {
                                alert("没有找到,您输入的手机号码无效!");
                                txtPhone.select();
                                //  return;                                
                            }
                        }
                    });
                }
            });
            $("#btnLogin").click(function () {
                $("#errmsg").html("");
                var txtRegName = $("#txtRegName");
                var txtPhone = $("#txtPhone");
                var txtcode = $("#txtcodeA");
                var txtRegPwd = $("#txtRegPwd");
                var txtChekPwd = $("#txtChekPwd");
                if (txtRegName.val() == "") {
                    $("#errmsg").html("请输入您的登录用户名!");
                    txtRegName.focus();
                    return;
                }

                if (txtPhone.val() == "") {
                    $("#errmsg").html("请输入您注册时的手机号码!");
                    txtPhone.focus();
                    return;
                }
                if (txtcode.val() == "") {
                    $("#errmsg").html("请输入您手机接收到的验证码!");
                    txtcode.focus();
                    return;
                }
                if (txtRegPwd.val().length < 6) {
                    $("#errmsg").html("新密码必须六位以上!");
                    txtRegPwd.focus();
                    return;
                }
                if (txtRegPwd.val() == "") {
                    $("#errmsg").html("新输入您的新密码!");
                    txtRegPwd.focus();
                    return;
                }
                if (txtChekPwd.val() == "") {
                    $("#errmsg").html("请再次输入新密码!");
                    txtChekPwd.focus();
                    return;
                }
                if (txtRegPwd.val() != txtChekPwd.val()) {
                    $("#errmsg").html("两次输入的新密码不一致!");
                    txtChekPwd.focus();
                    return;
                }
                var isPss = true;
                $.ajax({
                    url: "../ajax/ajaxuser.ashx",
                    data: 'type=checkcode&v=' + txtcode.val() + "&name=" + escape(txtRegName.val()) + "&pwd=" + escape(txtRegPwd.val()) + "&ram=" + Math.random(),
                    dataType: 'text',
                    success: function (data) {
                        if (data == "true") {
                            alert("您的密码已设置成功，请重新登录!");
                            window.location.href = "index.aspx";
                        } else {
                            alert(data);
                            txtcode.select();
                            return;
                        }
                    }
                });
            });
            // 手机 找回密码 
            // 邮件 找回密码 
            $("#btnLoginB").click(function () {
                $("#errmsg").html("");
                var txtRegNameB = $("#txtRegNameB");
                var txtEmailB = $("#txtEmailB");
                if (txtRegNameB.val() == "") {
                    $("#errmsgB").html("请输入您的账号!");
                    txtRegNameB.focus();
                    return;
                }
                if (txtEmailB.val() == "") {
                    $("#errmsgB").html("请输入您的邮件账号!");
                    txtEmailB.focus();
                    return;
                }
                if (txtRegNameB.val() != "" && txtEmailB.val() != "") {
                    $.ajax({
                        url: "../ajax/ajaxuser.ashx",
                        data: 'type=checkmoblieemail&v=' + txtRegNameB.val() + "&v2=" + txtEmailB.val() + "&t=email&ram=" + Math.random(),
                        dataType: 'text',
                        success: function (data) {
                            if (data == "false") {
                                alert("没有找到,您输入的账号名和邮件账号无效!");
                            }
                            else {
                                doSend();
                            }
                        }
                    });
                }
            });
            // 邮件 找回密码 
        });

        //限时锁定按钮
        var secs = 60 * 1;
        var wait = secs * 1000;
        function Timer(ctrlID) {
            $(ctrlID).attr("disabled", "disabled");
            var ctrlTxt = $(ctrlID).val();
            for (i = 1; i <= (wait / 100); i++) {
                window.setTimeout("doUpdate(" + i + ",'" + ctrlID + "','" + ctrlTxt + "')", i * 100);
            }
        }
        function doUpdate(num, ctrlID, ctrlTxt) {
            if (num == (wait / 100)) {
                $(ctrlID).val(ctrlTxt);
                $(ctrlID).removeAttr("disabled");
            } else {
                var wut = (wait / 100) - num;
                $(ctrlID).val(parseInt(wut / 10) + "秒后重新操作");
            }
        }
        // 手机 找回密码 
        function sendCode() {
            var txtPhone = $("#txtPhone");
            var txtRegName = $("#txtRegName");
            if (txtPhone.val() == "") {
                alert("请输入您注册时的手机号码!");
                txtPhone.focus();
                return;
            }
            var reg = /^0{0,1}(13[0-9]|15[0-9]|153|156|18[0-9])[0-9]{8}$/;
            var isMobile = reg.test(txtPhone.val());
            if (!isMobile) {
                alert('输入的手机格式不对！');
                txtPhone.focus();
                return;
            }
            if (txtPhone.val() != "") {
                $.ajax({
                    url: "../ajax/ajaxuser.ashx",
                    data: 'type=checkmoblieemail&v=' + txtPhone.val() + "&v2=" + txtRegName.val() + "&t=mobliname&ram=" + Math.random(),
                    dataType: 'text',
                    success: function (data) {
                        if (data == "false") {
                            
                            alert("您输入的手机号码无效!");
                            txtPhone.select();
                            //  return;                                
                        } else {
                            $.ajax({
                                url: "../ajax/ajaxuser.ashx",
                                data: 'type=sendcode&v=' + txtPhone.val() + "&title=" + escape("密码") + "&ram=" + Math.random(),
                                dataType: 'text',
                                success: function (data) {
                                    if (data == "true") {
                                        Timer('#btnsms');
                                        alert("验证码已发送到您的手机，请查收!");
                                        //getCode
                                        // txtPhone.select();
                                        return;
                                    } else {
                                        alert("发送失败，请检查手机号是否正确!");
                                        // txtPhone.select();
                                        return;
                                    }
                                }
                            });
                        }
                    }
                });
            }
        }
        // 手机 找回密码 
        // 邮件 找回密码 
        function doSend() {
            var txtEmailB = $("#txtEmailB");
            $.ajax({
                url: "../ajax/ajaxuser.ashx",
                data: 'type=seeknameemail&v=' + txtEmailB.val() + "&ram=" + Math.random(),
                dataType: 'text',
                success: function (data) {
                    if (data == "true") {
                        alert("您的新密码已发送到您的邮箱中，请妥善保管，谢谢!");
                        $("#btnLoginB").hide();
                        window.location.href = "index.aspx";
                    } else {
                        alert(data);
                        return;
                    }
                }
            });
        }
        // 邮件 找回密码 
    </script>
</head>
<body>
    <uc1:header ID="header1" runat="server" />
    <form id="form1" runat="server">
    <div class="zhuce">
        <ul class="nav_reg">
            <li class="nav_reg_current" id="nav_reg1" onclick="javascript:doClick(this)"><a href="###">
                商家手机找回密码</a></li>
            <li class="nav_reg_link" id="nav_reg2" onclick="javascript:doClick(this)"><a href="###">
                商家邮箱找回密码</a></li>
        </ul>
        <div class="nav_reg-down">
            <div class="dis" id="sub1">
                <p>
                    <label>
                        登录用户名：</label>
                    <input type="text" name="txtRegName" id="txtRegName" placeholder="请填写登录用户名" />
                </p>
                <p>
                    <label>
                        手机号：</label>
                    <input type="text" name="txtPhone" value="" maxlength="11" id="txtPhone" placeholder="请填写手机号" />
                    <input type="button" id="btnsms" class="hszit" style="width: 120px;" onclick="sendCode();"
                        value="免费获取短信动态码" />
                </p>
                <p>
                    <label>
                        短信动态码：</label>
                    <asp:TextBox ID="txtcodeA" runat="server" placeholder="请填写短信动态码" />
                </p>
                <p>
                    <label>
                        新密码：</label>
                    <input type="password" name="txtRegPwd" id="txtRegPwd" placeholder="6-20个大小写英文字母、符号或数字" />
                </p>
                <p>
                    <label>
                        确认新密码：</label>
                    <input type="password" name="txtChekPwd" id="txtChekPwd" placeholder="确认密码" />
                </p>
                <p>
                    <label>
                    </label>
                    <input id="btnLogin" class="fpwd_btnimg" type="button" value="提交" />
                </p>
                <p>
                    <label>
                    </label>
                    <span id="errmsg" style="color: #FF0000;"></span>
                </p>
            </div>
            <div class="undis" id="sub2">
                <p>
                    <label>
                        登录用户名：</label>
                    <input type="text" name="txtRegNameB" id="txtRegNameB" placeholder="填写登录用户名" /></p>
                <p>
                    <label>
                        邮箱：</label>
                    <input type="text" name="txtEmailB" id="txtEmailB" placeholder="填写邮箱地址" /></p>
                <p>
                    <label>
                    </label>
                    <input id="btnLoginB" class="fpwd_btnimg" type="button" value="提交" />
                </p>
                <p>
                    <label>
                    </label>
                    <span id="errmsgB" style="color: #FF0000;"></span>
                </p>
            </div>
        </div>
        <div class="zhucey">
            <img src="/resource/images/gg1.gif" width="260" height="207" alt="" /><br>
            <br>
            <a href="reg.aspx?r=l">
                <img src="/resource/images/lu.gif" width="167" height="46" alt="" /></a>
        </div>
    </div>
    </form>
    <ucfooter:footer ID="header2" runat="server" />
</body>
</html>
