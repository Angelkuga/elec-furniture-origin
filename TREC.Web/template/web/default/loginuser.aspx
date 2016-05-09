<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginuser.aspx.cs" Inherits="TREC.Web.loginuser" %>

<%@ Register Src="ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="ascx/_headA.ascx" TagName="_headA" TagPrefix="uc4" %>
<%@ Register Src="ascx/_foot.ascx" TagName="_foot" TagPrefix="uc5" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

        function showTip(message, type) {
//            var size = $('.loginerror').size();
//            if (size == 0) {
//                $('<tr class="loginerror"><td height="20"></td><td align="left">' + message + '</td></tr>').insertAfter('#con_one_1 tr:eq(5)');
//            } else {
//                $('.loginerror td:eq(1)').html(message);
//            }
//            $('#con_one_1 tr:eq(' + ($('#con_one_1 tr').size() - 1) + ') td').css('padding-top', '5px');
//            if (type == 0) {
//                $('.loginerror td:eq(1)').removeClass('smessage').addClass('emessage');
//            } else if (type == 1) {
//                $('.loginerror td:eq(1)').removeClass('emessage').addClass('smessage');
//            } else {
//                $('.loginerror td:eq(1)').removeClass('smessage').addClass('omessage');
            //            }

            $("#errmsg2").html(message);
            $("#errmsg2").css("color", "#FF0000");
        }

        function showLoginTip(message, type) {
            $("#errmsg2").html(message);
            $("#errmsg2").css("color", "#FF0000");
//            var size = $('.loginingerror').size();
//            if (size == 0) {
//                $('<tr class="loginingerror"><td height="20"></td><td align="left">' + message + '</td></tr>').insertAfter('#con_one_2 tr:eq(3)');
//            } else {
//                $('.loginingerror td:eq(1)').html(message);
//            }
//            $('#con_one_2 tr:eq(' + ($('#con_one_2 tr').size() - 2) + ') td').css('padding-top', '5px');
//            if (type == 0) {
//                $('.loginingerror td:eq(1)').removeClass('smessage').addClass('emessage');
//            } else if (type == 1) {
//                $('.loginingerror td:eq(1)').removeClass('emessage').addClass('smessage');
//            } else {
//                $('.loginingerror td:eq(1)').removeClass('smessage').addClass('omessage');
//            }
        }

        function removeShowTip() {
            //$('.loginerror td:eq(1)').html('');
            $('.loginerror').remove();
            $('#con_one_1 tr:eq(' + ($('#con_one_1 tr').size() - 1) + ') td').css('padding-top', '15px');
        }

        function removeLoginShowTip() {
            $('.loginingerror').remove();
            $('#con_one_2 tr:eq(' + ($('#con_one_2 tr').size() - 2) + ') td').css('padding-top', '20px');
        }

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
                            window.location = "<%=getUrlReferrer %>";
                        }
                    }
                });
            });

        });


        function changetable(id) {
            $("#inputkey").val(id);
            $("#sub1").hide();
            $("#sub2").hide();

            $("#alogin1").attr("style", "color:#333;");
            $("#alogin2").attr("style", "color:#333;");

            $("#nav_reg1").attr("style", "border-bottom-width:0px;border-top-color:#c7c7c7;border-top-width:0px;border-right-width:0px;border-left-width:0px;");
            $("#nav_reg2").attr("style", "border-bottom-width:0px;border-top-color:#c7c7c7;border-top-width:0px;border-right-width:0px;border-left-width:0px;");

            $("#sub" + id).show();
            var cid;
            if (id == "1") {
                cid = "2";
            }
            else {
                cid = "1";
            }
            $("#alogin" + id).attr("style", "color:#b9003c;");
            $("#nav_reg" + id).attr("style", "border-bottom-width:0px;border-top-color:#c7c7c7;border-top-width:1px;border-top-style:solid;border-right-color:#c7c7c7;border-right-width:1px;border-right-style:solid;");
           
        }


        function companylogin()
        {
            var v = $.trim($('#txtLoginName').val());
            if (v == '') {
                showLoginTip('抱歉，请输入用户名！', 0);
                $('#txtLoginName').focus();
            } else {
                var v2 = $.trim($('#txtLoginPwd').val());
                if (v2 == '') {
                    showLoginTip('抱歉，请输入密码！', 0);
                    $('#txtLoginPwd').focus();
                } else if (v2.length < 6) {
                    showLoginTip('抱歉，密码不能少于6位！', 0);
                    $('#txtLoginPwd').focus();
                } else {
                    showLoginTip('正在提交数据中...！', 1);
                    jQuery.ajax({
                        url: 'ajax/ajaxuser.ashx',
                        data: 'type=login&v=' + v + '&v2=' + v2 + '&ram=' + Math.random(),
                        dataType: 'text',
                        success: function (data) {
                            //alert(data);
                            if (data == "1") {
                                showLoginTip('登录成功，跳转页面中...！', 2);
                                window.location = "<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/suppler/index.aspx";
                            } else if (data == "2") {
                                showLoginTip('登录成功，跳转页面中...！', 2);
                                window.location = "<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/suppler/supplerindex.aspx";
                            } else if (data == "10") {
                                showLoginTip('登录成功，跳转页面中...！', 2);
                                window.location = "<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/index.aspx";
                            } else if (data == "-1") {
                                showLoginTip('验证码有误！', 0);
                            }
                            else {
                                showLoginTip('用户名或密码错误！', 0);
                                //setTimeout('removeLoginShowTip();', 5000); //3秒钟后消失提示信息
                            }
                        }
                    });
                }
            }
        }

        function keybnt() {
            if ($("#inputkey").val() == "1") {
                $("#loginbtn")[0].click();
            }
            else {
                companylogin();
            }
        }
        $(document).keypress(function (e) {
            // 回车键事件 
            if (e.which == 13) {
                keybnt();
            }
        });
    </script>
</head>
<body>
    <uc1:header ID="header1" runat="server" />
    <form id="form1" runat="server">
    <div>
        <div class="zhuce">
            <ul class="nav_reg">
                <li class="nav_reg_current" id="nav_reg1" style="margin-right:0px;border-right-width:0px;" onclick="changetable('1')">
                   <a href="#"  id="alogin1" >用户登录</a>
                   </li>
                    <li class="nav_reg_current" id="nav_reg2" style="border-bottom-color:#c7c7c7;border-bottom-width:1px;border-bottom-style:solid;border-top-width:0px;border-right-width:0px;" onclick="changetable('2')">
                   <a href="#" style="color:#333333;" id="alogin2">商家登录</a>
                   </li> 
            </ul>
            <div class="nav_reg-down">
                <div class="dis" id="sub1">
                    <p>
                        <label style="width:105px;">
                            用户登录账号：</label>
                        <input type="text" id="uname" placeholder="请填写登录账号手机号或用户名" />
                    </p>
                    <p>
                        <label style="width:105px;">
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
                        <a href="findpwduser.aspx" style="color: #0000FF;">找回密码？</a>
                    </p>
                </div>

                <!--商家 begin--->
                <div class="dis" id="sub2" style="display:none;">
                    <p>
                        <label style="width:105px;">
                            商家登录账号：</label>
                        <input type="text" id="txtLoginName" placeholder="请填写商家登录账号手机号或用户名" />
                    </p>
                    <p>
                        <label style="width:105px;">
                            密 码：</label>
                        <input type="password" id="txtLoginPwd" placeholder="6-20个大小写英文字母、符号或数字" />
                    </p>
                    <p>
                        <label>
                        </label>
                        <input id="sj_loginbtn" class="fpwd_btnimg" onclick="companylogin()" type="button" value="登录" />
                    </p>
                    <p>
                        <label>
                        </label>
                        <span id="errmsg2" style=""></span>
                    </p>
                    <p>
                        <label>
                        </label>
                        <a href="FindPwdSupply.aspx" style="color: #0000FF;">找回密码？</a>
                    </p>
                </div>
                <!--商家 end--->

                <input type="hidden" value="1" id="inputkey" />
            </div>
            <div class="zhucey">
                <img src="/resource/images/gg1.gif" width="260" height="207" alt="" /><br>
                <br>
                <a href="reg.aspx?r=l">
                    <img src="/resource/images/lu.gif" width="167" height="46" alt="" /></a>
            </div>
        </div>
    </div>
    </form>
    <ucfooter:footer ID="header2" runat="server" />
</body>
</html>
