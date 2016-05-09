<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addloginuser.aspx.cs" Inherits="TREC.Web.loginuser" %>

<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=pageTitle %></title>
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <meta name="keywords" content="家具品牌,家具品牌排名,家具十大品牌,品牌家具,实木家具十大品牌,儿童家具十大品牌,板式家具十大品牌">
    <meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！">
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/index/index.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/js/core.js" type="text/javascript"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/messages_cn.js"></script>
    <style>
        body
        {
            overflow: hidden;
        }
        .zhuce
        {
            width: 600px;
            height: 250px;
            margin: 6px auto;
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
            height: 250px;
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
            cursor: pointer;
        }
    </style>
    <script type="text/javascript">
        //登录验证
        $(function () {

            $("#loginbtn").click(function () {
                $("#errmsg").html("");
                var flag = true;
                var uname = $("#uname");
                if (uname.val().length == 0) {
                    $("#errmsg").html('登录账号必须填写'); $("#errmsg").css("color", "#FF0000"); uname.focus(); return;
                }
                var upwd = $("#upwd");
                if (upwd.val().length < 6) {
                    $("#errmsg").html('登录密码必须填写6-20位'); $("#errmsg").css("color", "#FF0000"); upwd.focus(); return;
                }
                $("#errmsg").html("正在提交数据中...！");
                $.ajax({
                    url: 'ajax/ajaxuser.ashx',
                    async: false,
                    data: 'type=customerlogin&n=' + uname.val() + '&p=' + upwd.val(),
                    dataType: 'text',
                    success: function (data) {
                        if (data == 0) {
                            $("#errmsg").html("登录失败,账号或密码错误!");
                            $("#errmsg").css("color", "#FF0000");
                        } else if (data == -1) {
                            $("#errmsg").html("登录失败,账号未激活!");
                            $("#errmsg").css("color", "#FF0000");
                        } else if (data == 1) {
                            $("#errmsg").html("登录成功,正在跳转首页...");
                            $("#errmsg").css("color", "#00FF00");
                            window.parent.location = "/";
                            window.parent.ymPrompt.doHandler('', true);
                        }
                    }
                });
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server" style="margin: 0">
    <div class="zhuce">
        <ul class="nav_reg">
            <li class="nav_reg_current" id="nav_reg1" onclick="javascript:doClick(this)"><a href="###">
                用户登录</a></li>
        </ul>
        <div class="nav_reg-down">
            <div class="dis" id="sub1">
                <p>
                    <label>
                        登录账号：</label>
                    <input type="text" id="uname" placeholder="请填写登录账号手机号或用户名" />
                </p>
                <p>
                    <label>
                        密 码：</label>
                    <input type="password" id="upwd" placeholder="6-20个大小写英文字母、符号或数字" />
                </p>
                <p>
                    <label>
                    </label>
                    <input id="loginbtn" class="fpwd_btnimg" type="button" value="登录" />
                </p>
                <p>
                    <label>
                    </label>
                    <span id="errmsg" style=""></span>
                </p>
                <p>
                    <label>
                    </label>
                    <a href="addreguser.aspx" style="color: #0000FF;">还没注册马上注册</a>
                </p>
            </div>
        </div>
    </div>
     
    </form>
</body>
</html>
