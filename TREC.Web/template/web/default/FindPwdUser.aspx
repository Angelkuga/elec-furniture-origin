<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindPwdUser.aspx.cs" Inherits="TREC.Web.FindPwdUser" %>

<%@ Register Src="ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="ascx/_headA.ascx" TagName="_headA" TagPrefix="uc4" %>
<%@ Register Src="ascx/_foot.ascx" TagName="_foot" TagPrefix="uc5" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>家具快搜 - 用户找回密码</title>
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
            width: 98px;
            height: 40px;
            border: 1px solid #c7c7c7;
            border-bottom: none;
            margin-right: 5px;
        }
        .nav_reg li a
        {
            float: left;
            width: 98px;
            font-family: 微软雅黑;
            font-size: 14px;
            height: 40px;
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
        //验证手机
        function chkmobilereg() {
            var flag = true;
            $("errmsg").html("");
            var mobile = $("#<%=txtmobile.ClientID %>")
            if (mobile.val().length != 11) {
                $("#errmsg").html('必须填写11位的手机号！'); mobile.focus(); return false;
            }
            var pwd = $("#<%=txtpassword.ClientID %>")
            if (pwd.val().length < 6 || pwd.val().length > 20) {
                $("#errmsg").html('必须填写新密码6-20位！'); pwd.focus(); return false;
            }

            var pwdb = $("#txtpasswordB")
            if (pwd.val() != pwdb.val()) {
                $("#errmsg").html('两次密码不一致！'); pwdb.focus(); return false;
            }
            var codeA = $("#<%=txtcodeA.ClientID %>")
            if (codeA.val().length != 6) {
                $("#errmsg").html('必须填写6位的短信动态码！'); codeA.focus(); return false;
            }
            return flag;
        }
        //验证mail
        function chkmailreg() {
            var flag = true;
            $("errmsgB").html("");
            var mail = $("#<%=txtmail.ClientID %>")
            var reg = /^\w+@\w+\.\w+$/;
            if (mail.val().length == 0) {
                $("#errmsgB").html('必须填写邮箱账号！'); mail.focus(); return false;
            }
            if (!reg.test(mail.val())) {
                $("#errmsgB").html('必须填写有效的邮箱账号！'); mail.focus(); return false;
            }
            var pwd = $("#<%=txtpasswordmail.ClientID %>")
            if (pwd.val().length < 6 || pwd.val().length > 20) {
                $("#errmsgB").html('必须填写新密码6-20位！'); pwd.focus(); return false;
            }
            var pwdb = $("#PasswordBmail")
            if (pwd.val() != pwdb.val()) {
                $("#errmsgB").html('两次密码不一致！'); pwdb.focus(); return false;
            }
            var codeB = $("#<%=txtcodeB.ClientID %>")
            if (codeB.val().length != 8) {
                $("#errmsgB").html('必须填写8位的验证码！'); codeB.focus(); return false;
            }
            return flag;
        }
        function sendCode(para) {
            $("errmsg").html("");
            $("errmsgB").html("");
            if (para == 3) {
                var mobile = $("#<%=txtmobile.ClientID %>")
                if (mobile.val().length != 11) {
                    $("#errmsg").html('必须填写11位的手机号！'); mobile.focus(); return false;
                }
                $.ajax({
                    url: 'ajax/ajaxuser.ashx',
                    type: "get",
                    async: false,
                    data: 'type=sendfindpwd&t=3&m=' + mobile.val(),
                    dataType: 'text',
                    complete: function (data) {
                        var rs = data.responseText;
                        if (rs == "1") {
                            Timer('#btnsms');
                            alert("动态码短信已发送");
                        }
                        else if (rs == "-31") {
                            alert("动态码发送失败，该手机的用户不存在");
                        }
                        else {
                            alert("动态码发送失败");
                        }
                    }
                });
            } else if (para == 4) {
                var reg = /^\w+@\w+\.\w+$/;
                var mail = $("#<%=txtmail.ClientID %>")
                if (!reg.test(mail.val())) {
                    $("#errmsgB").html('必须填写有效的邮箱账号！'); mail.focus(); return false;
                }
                $.ajax({
                    url: 'ajax/ajaxuser.ashx',
                    type: "get",
                    async: false,
                    data: 'type=sendfindpwd&t=4&m=' + mail.val(),
                    dataType: 'text',
                    complete: function (data) {
                        var rs = data.responseText;
                        if (rs == "1") {
                            Timer('#btnsmsB');
                            alert("动态码邮件已发送");
                        }
                        else if (rs == "-41") {
                            alert("动态码发送失败，该邮件号的用户不存在");
                        }
                        else {
                            alert("动态码发送失败");
                        }
                    }
                });
            }
        }
    </script>
</head>
<body>
    <uc1:header ID="header1" runat="server" />
    <form id="form1" runat="server">
    <div class="zhuce">
        <ul class="nav_reg">
            <li class="nav_reg_current" id="nav_reg1" onclick="javascript:doClick(this)"><a href="###">
                手机找回密码</a></li>
            <li class="nav_reg_link" id="nav_reg2" onclick="javascript:doClick(this)"><a href="###">
                邮箱找回密码</a></li>
        </ul>
        <div class="nav_reg-down">
            <div class="dis" id="sub1">
                <p>
                    <label>
                        手机号：</label>
                    <asp:TextBox ID="txtmobile" runat="server" placeholder="请填写手机号" />
                </p>
                <p>
                    <label>
                        短信动态码：</label>
                    <asp:TextBox ID="txtcodeA" runat="server" placeholder="请填写短信动态码" />
                    <input type="button" id="btnsms" class="hszit" style="width: 120px;" onclick="sendCode(3);"
                        value="免费获取短信动态码" />
                </p>
                <p>
                    <label>
                        新密码：</label>
                    <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" placeholder="6-20个大小写英文字母、符号或数字" />
                </p>
                <p>
                    <label>
                        确认新密码：</label>
                    <input type="password" id="txtpasswordB" placeholder="确认密码" />
                </p>
                <p>
                    <label>
                    </label>
                    <asp:Button runat="server" ID="btnmob2" CssClass="fpwd_btnimg" Text="提交" OnClick="btnmobile_Click"
                        OnClientClick="return chkmobilereg();" />
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
                        邮箱：</label>
                    <asp:TextBox ID="txtmail" runat="server" placeholder="填写邮箱地址" /></p>
                <p>
                    <label>
                        邮箱动态码：</label>
                    <asp:TextBox ID="txtcodeB" runat="server" placeholder="请填写邮箱动态码" />
                    <input type="button" id="btnsmsB" class="hszit" style="width: 120px;" onclick="sendCode(4);"
                        value="免费获取邮箱动态码" />
                </p>
                <p>
                    <label>
                        新密码：</label>
                    <asp:TextBox ID="txtpasswordmail" TextMode="Password" runat="server" placeholder="6-20个大小写英文字母、符号或数字" />
                </p>
                <p>
                    <label>
                        确认新密码：</label>
                    <input type="password" id="PasswordBmail" placeholder="确认密码" />
                </p>
                <p>
                    <label>
                    </label>
                    <asp:Button ID="btnmail" runat="server" CssClass="fpwd_btnimg" Text="提交" OnClick="btnmail_Click"
                        OnClientClick="return chkmailreg();" />
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
            <input type="button" class="fpwd_btnimg" value="用户登录" class="fpwd_btnimg" onclick="window.location.href='loginuser.aspx';" />
        </div>
    </div>
    </form>
    <ucfooter:footer ID="header2" runat="server" />
</body>
</html>
