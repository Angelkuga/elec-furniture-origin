﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reguser.aspx.cs" Inherits="TREC.Web.reguser" %>

<%@ Register Src="ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="ascx/_headA.ascx" TagName="_headA" TagPrefix="uc4" %>
<%@ Register Src="ascx/_foot.ascx" TagName="_foot" TagPrefix="uc5" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
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
            height: 36px; line-height:36px;
            padding-left: 6px;
        }
        .undis input.iptd, .dis input.iptd
        {
            width: 128px;
            height: 36px;line-height:36px;
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
            min-height:350px;
            height:auto;
            padding: 30px 40px;
            text-align: left;
        }
        .zhucexy2 {
    background: #fff none repeat scroll 0 0;
    border: 1px solid #c7c7c7;
    height: 380px;
    overflow-x: hidden;
    overflow-y: scroll;
    padding: 10px;
     width: 600px;
}
.zhucexy3
{
    
   left: 375px;
    position: absolute;
    top: 30px;
    width: 600px;
    z-index: 999;    
}
.sh_fg
{
    border-bottom-width : 1px;
	border-bottom-color : #c7c7c7;
	border-bottom-style :dashed;
	width:530px;
 }
 .sh_radio
 {
 }
  .sh_radio input
  {
      width:15px;
      height:14px;
   }
.sh_radio label
 {
     width:70px;
     text-align:left;
     padding-top:0px;
   
 }
 .bitian
 {
     color:Red;
     font-size:15px;
 }
 #divcompany label
 {
     width:100px;
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
        //验证手机注册
        function chkmobilereg() {
            var flag = true;
            $("errmsg").html("");
            var mobile = $("#<%=txtmobile.ClientID %>")
            if (mobile.val().length != 11) {
                $("#errmsg").html('必须填写11位的手机号！'); mobile.focus(); return false;
            }
            var pwd = $("#<%=txtpassword.ClientID %>")
            if (pwd.val().length < 6 || pwd.val().length > 20) {
                $("#errmsg").html('必须填写密码6-20位！'); pwd.focus(); return false;
            }

            var pwdb = $("#txtpasswordB")
            if (pwd.val() != pwdb.val()) {
                $("#errmsg").html('两次密码不一致！'); pwdb.focus(); return false;
            }
            var codeA = $("#<%=txtcodeA.ClientID %>")
            if (codeA.val().length != 6) {
                $("#errmsg").html('必须填写6位的短信动态码！'); codeA.focus(); return false;
            }
            var zcxy = $("#zcxy").is(":checked");
            if (!zcxy) {
                $("#errmsg").html('必须确认注册协议！'); return false;
            }
            $.ajax({
                url: 'ajax/ajaxuser.ashx',
                async: false,
                data: 'type=chkcustomer&v=1&m=' + mobile.val(),
                dataType: 'text',
                success: function (data) {
                    var rs = data;
                    if (rs > 0) {
                        $("#errmsg").html("手机号已注册");
                        flag = false;
                    }
                }
            });
            return flag;
        }
        //验证mail注册
        function chkmailreg() {
            var flag = true;
            $("errmsgB").html("");
            var mail = $("#<%=txtmail.ClientID %>")
            var reg = /^\S+@\S+\.\S+$/;
            if (mail.val().length == 0) {
                $("#errmsgB").html('必须填写邮箱账号！'); mail.focus(); return false;
            }
            if (!reg.test(mail.val())) {
                $("#errmsgB").html('必须填写有效的邮箱账号！'); mail.focus(); return false;
            }
            var pwd = $("#<%=txtpasswordmail.ClientID %>")
            if (pwd.val().length < 6 || pwd.val().length > 20) {
                $("#errmsgB").html('必须填写密码6-20位！'); pwd.focus(); return false;
            }

            var pwdb = $("#PasswordBmail")
            if (pwd.val() != pwdb.val()) {
                $("#errmsgB").html('两次密码不一致！'); pwdb.focus(); return false;
            }
            var codeB = $("#<%=txtcodemail.ClientID %>")
            if (codeB.val().length != 4) {
                $("#errmsgB").html('必须填写4位的验证码！'); codeB.focus(); return false;
            }
            var zcxy = $("#zcxymail").is(":checked");
            if (!zcxy) {
                $("#errmsgB").html('必须确认注册协议！'); return false;
            }
            $.ajax({
                url: 'ajax/ajaxuser.ashx',
                async: false,
                data: 'type=chkcustomer&v=2&m=' + mail.val(),
                dataType: 'text',
                success: function (data) {
                    var rs = data;
                    if (rs > 0) {
                        $("#errmsgB").html("邮箱账号已注册");
                        flag = false;
                    }
                }
            });
            return flag;
        }

        function sendSMSCode() {
            $("errmsg").html("");
            var mobile = $("#<%=txtmobile.ClientID %>")
            if (mobile.val().length != 11) {
                $("#errmsg").html('必须填写11位的手机号！'); mobile.focus(); return false;
            }
            $.ajax({
                url: 'ajax/ajaxuser.ashx',
                type: "get",
                async: false,
                data: 'type=sendsmscustomeractive&m=' + mobile.val(),
                dataType: 'text',
                complete: function (data) {
                    var rs = data.responseText;
                    if (rs == -1) {
                        alert("手机号已注册过！");
                    }else if (rs > 0) {
                        Timer('#btnsms');
                        alert("动态码已发送！");
                    }
                    else {
                        alert("动态码发送失败！");
                    }
                }
            });
        }
        function sendSMSMemberCode() {
            $("errmsg").html("");
            var mobile = $("#txt_membermobile")
            if (mobile.val().length != 11) {
                $("#errmsg").html('必须填写11位的手机号！'); mobile.focus(); return false;
            }
            $.ajax({
                url: '/ajax/ajaxuser.ashx',
                type: "get",
                async: false,
                data: 'type=sendSmsMemberActive&m=' + mobile.val() + "&ran=" + Math.random(),
                dataType: 'text',
                complete: function (data) {
                    var rs = data.responseText;
                    if (rs == -1) {
                        alert("手机号已注册过！");
                    } else if (rs > 0) {
                        Timer('#btnsms');
                        alert("动态码已发送！");
                    }
                    else {
                        alert("动态码发送失败！");
                    }
                }
            });
        }    
        function showrole() {
            var zhucexy = $("#zhucexy")
            if (zhucexy.css("display") == "none") {
                zhucexy.show();
            }
            else {
                zhucexy.hide();
            }
        }
        function rplyimg() {
            $('#imgValiateCode').attr('src', "/ajaxtools/imageVerify.aspx?rand=" + Math.random() + "&model=reg");
        }
    </script>
</head>
<body>
    <uc1:header ID="header1" runat="server" />
   
    <form id="form1" runat="server">
    <div class="zhuce" style="height:auto;">
        <ul class="nav_reg">
            <li class="nav_reg_current" id="nav_reg1" onclick="javascript:doClick(this)"><a href="#">
                手机注册</a></li>
            <li class="nav_reg_link" id="nav_reg2" onclick="javascript:doClick(this)"><a href="#">
                邮箱注册</a></li>

                <li class="nav_reg_link" id="Li1" onclick="javascript:doClick(this)"><a href="reg.aspx" style="background-color:#BB2E3C;color:#FFEB9B;">
                商家注册</a></li>
        </ul>
        <div class="nav_reg-down">
            <div class="dis" id="sub1" style="display:none;">
                <p>
                    <label>
                        手机号：</label>
                    <asp:TextBox ID="txtmobile" runat="server" placeholder="请填写手机号" />
                </p>
                <p>
                    <label>
                        短信动态码：</label>
                    <asp:TextBox ID="txtcodeA" runat="server" placeholder="请填写短信动态码" />
                    <input type="button" id="btnsms" class="hszit" style="width: 120px;" onclick="sendSMSCode();"
                        value="免费获取短信动态码" />
                </p>
                <p>
                    <label>
                        创建密码：</label>
                    <asp:TextBox ID="txtpassword" TextMode="Password" runat="server" placeholder="6-20个大小写英文字母、符号或数字" />
                </p>
                <p>
                    <label>
                        确认密码：</label>
                    <input type="password" id="txtpasswordB" placeholder="确认密码" />
                </p>
                <p>
                    <label>
                    </label>
                    <input type="checkbox" id="zcxy" class="fxk" checked="checked" />
                    <span class="hszitt">我已阅读并同意</span><span class="hszit" onclick="showrole();">《家具快搜用户协议》</span></p>
                <p>
                    <label>
                    </label>
                    <asp:ImageButton runat="server" ID="btnmobile" ImageUrl="/resource/images/zc.gif"
                        Width="188" Height="35" OnClick="btnmobile_Click" OnClientClick="return chkmobilereg();" /></p>
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
                        创建密码：</label>
                    <asp:TextBox ID="txtpasswordmail" TextMode="Password" runat="server" placeholder="6-20个大小写英文字母、符号或数字" />
                </p>
                <p>
                    <label>
                        确认密码：</label>
                    <input type="password" id="PasswordBmail" placeholder="确认密码" />
                </p>
                <p>
                    <label>
                        验证码：</label>
                    <asp:TextBox ID="txtcodemail" runat="server" placeholder="请填写验证码" CssClass="iptd" />
                    <img id="imgValiateCode" src="/ajaxtools/imageVerify.aspx?model=reg" alt="" style="vertical-align: middle;
                        margin-right: 10px;" onclick="rplyimg()"/>
                    <span class="hszit" id="chkImgVerify" onclick="rplyimg()">看不清楚？换一张</span></p>
                <p>
                    <label>
                    </label>
                    <input type="checkbox" id="zcxymail" class="fxk" checked="checked" />
                    <span class="hszitt">我已阅读并同意</span><span class="hszit" onclick="showrole();">《家具快搜用户协议》</span></p>
                <p>
                    <label>
                    </label>
                    <asp:ImageButton runat="server" ID="ImageButtonMail" ImageUrl="/resource/images/zc.gif"
                        Width="188" Height="35" OnClick="btnmail_Click" OnClientClick="return chkmailreg();" /></p> 
                <p>
                    <label>
                    </label>
                    <span id="errmsgB" style="color: #FF0000;"></span>
                </p>
            </div>

            <!--商家注册 begin---->
            <div class="dis" id="divcompany" >
            <p>  
            <label><span class="bitian">*</span>用户名：</label>
              <asp:TextBox ID="txt_memberusername" runat="server" placeholder="请填写登陆的用户名" />
            </p>
                <p>
                    <label>
                        <span class="bitian">*</span>手机号：</label>
                    <asp:TextBox ID="txt_membermobile" runat="server" placeholder="请填写手机号" />
                </p>
                <p>
                    <label >
                        <span  class="bitian">*</span>短信动态码：</label>
                    <asp:TextBox ID="txt_sjdtcode" runat="server" placeholder="请填写短信动态码" />
                    <input type="button" id="Button1" class="hszit" style="width: 120px;" onclick="sendSMSMemberCode();"
                        value="免费获取短信动态码" />
                </p>
                <p>
                    <label>
                        <span class="bitian">*</span>创建密码：</label>
                    <asp:TextBox ID="txt_sjpwd1" TextMode="Password" runat="server" placeholder="6-20个大小写英文字母、符号或数字" />
                </p>
                <p>
                    <label>
                       <span class="bitian">*</span>确认密码：</label>
                    <input type="password" id="txt_sjpwd2" placeholder="确认密码" />
                </p>

                <div class="sh_fg"></div>
                 <p>
                    <label style="width:120px;">
                       <span class="bitian">*</span>请选择商家身份：
                        </label>
                 </p>
                 <div class="sh_radio">
                     <asp:RadioButtonList ID="Radio_usertype" runat="server" 
                         RepeatDirection="Horizontal">
                         <asp:ListItem Value="101" Selected="True">厂商</asp:ListItem>
                          <asp:ListItem Value="102">经销商</asp:ListItem>
                           <asp:ListItem Value="103">子卖场</asp:ListItem>
                            <asp:ListItem Value="105">卖场集团</asp:ListItem>
                     </asp:RadioButtonList>
                 </div>
                 <div style="padding-top:40px;">

                 <table border="0"  id="table101">
                 <tr><td align="right"><span class="bitian">*</span>工厂名称：</td><td><asp:TextBox ID="txt_companyName" Height="20" runat="server"></asp:TextBox>  </td> </tr>
                 <tr><td align="right"><span class="bitian">*</span>工厂地址：</td><td>
                 <div style="float:left;">
                 <iframe frameborder="0" scrolling="no" src="/AreaDrop.aspx?txtname=txt_companyareacode" id="if_company" style="width:240px;height:22px;margin-top:10px;"></iframe> 
                 </div>
                 <div style="float:left;padding-top:9px;">
                 <asp:TextBox ID="txt_companyAddress" Height="20" runat="server" Width="200" placeholder="请输入具体路名和门牌号"></asp:TextBox> 
                 <div style="display:none;">
                 <asp:TextBox ID="txt_companyareacode" Height="20" Width="30" runat="server"></asp:TextBox> 
                 </div>
                 </div>
                   </td> </tr>
                     <tr><td style="height:35px;" align="right"><span class="bitian">*</span>品牌名称：</td><td><asp:TextBox ID="txt_companybrand" Height="20" runat="server"></asp:TextBox>  </td> </tr>
                       <tr><td style="height:35px;" align="right"><span class="bitian">*</span>联系人：</td><td><asp:TextBox ID="txt_companylinkman" Height="20" runat="server"></asp:TextBox>  </td> </tr>
                        <tr><td style="height:35px;" align="right"><span class="bitian">*</span>联系方式：</td><td><asp:TextBox ID="txt_companyMenth" Height="20" runat="server"></asp:TextBox>  </td> </tr>
                 </table>


                 <table border="0" style="display:none;" id="table102">
                 <tr><td align="right"><span class="bitian">*</span>代理品牌名称：</td><td><asp:TextBox ID="txt_Dealerbrand" Height="20" runat="server"></asp:TextBox>  </td> </tr>
                 <tr><td align="right"><span class="bitian">*</span>经销商：</td><td>
                 <div class="sh_radio" style="padding-top:4px;">
                     <asp:RadioButtonList ID="radio_Dealer" runat="server"  RepeatDirection="Horizontal" Width="200">
                      <asp:ListItem Value="1" Selected="True">个人</asp:ListItem>
                          <asp:ListItem Value="1">企业</asp:ListItem>
                     </asp:RadioButtonList>  
                     </div>
                     </td>  </tr>
                 <tr><td align="right"><span class="bitian">*</span>工厂地址：</td><td>
                 <div style="float:left;">
                 <iframe frameborder="0" scrolling="no" src="/AreaDrop.aspx" style="width:240px;height:22px;margin-top:10px;"></iframe> 
                 </div>
                 <div style="float:left;padding-top:9px;">
                 <asp:TextBox ID="TextBox5" Height="20" runat="server" Width="200" placeholder="请输入具体路名和门牌号"></asp:TextBox> 
                 </div>
                   </td> </tr>
                       <tr><td style="height:35px;" align="right"><span class="bitian">*</span>联系人：</td><td><asp:TextBox ID="TextBox7" Height="20" runat="server"></asp:TextBox>  </td> </tr>
                        <tr><td style="height:35px;" align="right"><span class="bitian">*</span>联系方式：</td><td><asp:TextBox ID="TextBox8" Height="20" runat="server"></asp:TextBox>  </td> </tr>
                 </table>


                 <table border="0"  style="display:none;" id="table103">
                 <tr><td align="right"><span class="bitian">*</span>子卖场名称：</td>
                 <td><asp:TextBox ID="txt_marketname" Height="20" Width="208" runat="server" placeholder="如：红星美凯龙"></asp:TextBox>+ 
                 <asp:TextBox ID="txt_marketshop" Height="20" Width="208" runat="server"  placeholder="吴中路"></asp:TextBox><span style="margin-left:4px;font-size:14px;font-weight:bold;">店</span>
                  </td> </tr>
                 <tr><td align="right"><span class="bitian">*</span>子卖场地址：</td><td>
                 <div style="float:left;">
                 <iframe frameborder="0" scrolling="no" src="/AreaDrop.aspx" style="width:240px;height:22px;margin-top:10px;"></iframe> 
                 </div>
                 <div style="float:left;padding-top:9px;">
                 <asp:TextBox ID="TextBox6" Height="20" runat="server" Width="200" placeholder="请输入具体路名和门牌号"></asp:TextBox> 
                 </div>
                   </td> </tr>
                       <tr><td style="height:35px;" align="right"><span class="bitian">*</span>联系人：</td><td><asp:TextBox ID="TextBox10" Height="20" runat="server"></asp:TextBox>  </td> </tr>
                        <tr><td style="height:35px;" align="right"><span class="bitian">*</span>联系方式：</td><td><asp:TextBox ID="TextBox11" Height="20" runat="server"></asp:TextBox>  </td> </tr>
                 </table>


                 <table border="0"  style="display:none;" id="table105">
                 <tr><td align="right"><span class="bitian">*</span>集团名称：</td><td><asp:TextBox ID="TextBox4" Height="20" runat="server" placeholder="如：红星美凯龙"></asp:TextBox>  </td> </tr>
                 <tr><td align="right"><span class="bitian">*</span>集团地址：</td><td>
                 <div style="float:left;">
                 <iframe frameborder="0" scrolling="no" src="/AreaDrop.aspx" style="width:240px;height:22px;margin-top:10px;"></iframe> 
                 </div>
                 <div style="float:left;padding-top:9px;">
                 <asp:TextBox ID="TextBox9" Height="20" runat="server" Width="200" placeholder="请输入具体路名和门牌号"></asp:TextBox> 
                 </div>
                   </td> 
                   </tr>
                       <tr><td style="height:35px;" align="right"><span class="bitian">*</span>联系人：</td><td><asp:TextBox ID="TextBox13" Height="20" runat="server"></asp:TextBox>  </td> </tr>
                        <tr><td style="height:35px;" align="right"><span class="bitian">*</span>联系方式：</td><td><asp:TextBox ID="TextBox14" Height="20" runat="server"></asp:TextBox>  </td> </tr>
                 </table>

                 </div>

                   <p>
                    <label style="width:73px;">
                        <span class="bitian">*</span>验证码：</label>
                    <asp:TextBox ID="txt_sjcode" runat="server" placeholder="请填写验证码" CssClass="iptd" Height="22" />
                    <img id="imgcode_sj" src="/common/VerifyCode.aspx" alt="" onclick="this.src=this.src+'?'" title="看不清，换一张！" style="vertical-align: middle;
                        margin-right: 10px;" />
                    <span class="hszit" id="Span2" onclick="sjcodechange()">看不清楚？换一张</span></p>

                <p>
                    <label>
                    </label>
                    <input type="checkbox" id="Checkbox1" class="fxk" checked="checked" />
                    <span class="hszitt">我已阅读并同意</span><span class="hszit" onclick="showrole();">《家具快搜用户协议》</span></p>
                <p style="display:none;">
                    <label>
                    </label>
                    <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="/resource/images/zc.gif"
                        Width="188" Height="35" OnClick="btnmobile_Click" OnClientClick="chkmobilereg(event);" /></p>
                <p>
               <p>
                   <asp:ImageButton ID="imgbnt_sjsave" runat="server" 
                       ImageUrl="/resource/images/zc.gif" Width="188" Height="35" 
                       onclick="imgbnt_sjsave_Click" OnClientClick="checksj(event);" />
               </p>
                    <label>
                    </label>
                    <span id="Span1" style="color: #FF0000;"></span>
                </p>
            </div>
               <!--商家注册 end---->
        </div>
        <!--注册协议-->
      <div style="display: none;" id="zhucexy" class="zhucexy3">
      <div style="width:600px;"><span style="float:right;color:Red;cursor:pointer;" onclick="showrole()">关闭</span></div>
        <div class="zhucexy2" >
            <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span style="font-size: 9pt; color: rgb(119, 119, 119);">尊敬的客户，欢迎您注册成为家具快搜的网站用户。在注册前请您仔细阅读如下服务条款：</span></b><b></b></p> <p class="MsoNormal" align="left" style="text-indent: 24pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">家具快搜的所有权和运作权归上海渡福实业有限公司所有。本服务协议双方为本网站与本网站客户，本服务协议具有合同效力。您确认本服务协议后，本服务协议即在您和本网站之间产生法律效力。请您务必在注册之前认真阅读全部服务协议内容，如有任何疑问，可向本网站咨询。</span><span style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"> </span><span style="font-size: 9pt; color: rgb(51, 51, 51);">无论您事实上是否在注册之前认真阅读了本服务协议，只要您点击协议正本下方的</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">"</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">注册</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">"</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">按钮并按照本网站注册程序成功注册为用户，这表示用户与上海渡福实业有限公司达成协议并接受所有的服务条款。</span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">协议细则</span></b><b></b></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">1</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、本网站服务条款的确认和接纳</span></b><b></b></p> <p class="MsoNormal" align="left" style="text-indent: 24pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">本网站各项服务的所有权和运作权归本网站拥有。</span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">2</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、用户必须：</span></b><b></b></p> <p class="MsoNormal" align="left" style="line-height: 18pt; vertical-align: baseline;"><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">(1)</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">自行配备上网的所需设备，</span><span style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"> </span><span style="font-size: 9pt; color: rgb(51, 51, 51);">包括个人电脑、调制解调器或其他必备上网装置。</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"><br> (2)</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">自行负担个人上网所支付的与此服务有关的电话费用、</span><span style="font-size: 9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333;mso-font-kerning:0pt"> </span><span style="font-size: 9pt; color: rgb(51, 51, 51);">网络费用。</span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">3</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、用户在本网站交易平台上不得发布下列违法信息：</span></b><b></b></p> <p class="MsoNormal" align="left" style="line-height: 18pt; vertical-align: baseline;"><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">(1)</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">反对宪法所确定的基本原则的；</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"><br> (2)</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">危害国家安全，泄露国家秘密，颠覆国家政权，破坏国家统一的；</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"><br> (3)</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">损害国家荣誉和利益的；</span><span lang="EN-US" style="font-size:9.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333;mso-font-kerning:0pt"><br> (4)</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">煽动民族仇恨、民族歧视，破坏民族团结的；</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"><br> (5)</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">破坏国家宗教政策，宣扬邪教和封建迷信的；</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"><br> (6)</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">散布谣言，扰乱社会秩序，破坏社会稳定的；</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"><br> (7)</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">散布淫秽、色情、赌博、暴力、凶杀、恐怖或者教唆犯罪的；</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"><br> (8)</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">侮辱或者诽谤他人，侵害他人合法权益的；</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"><br> (9)</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">含有法律、行政法规禁止的其他内容的。</span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">4</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、有关个人资料</span></b><b></b></p> <p class="MsoNormal" align="left" style="text-indent: 24pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">用户同意：</span></p> <p class="MsoNormal" align="left" style="line-height: 18pt; vertical-align: baseline;"><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">(1) </span><span style="font-size: 9pt; color: rgb(51, 51, 51);">提供及时、详尽及准确的个人资料。</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"><br> (2)</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">上海渡福实业有限公司保留随时变更、中断或终止部分或全部网络服务的权利。</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"><br> (3) </span><span style="font-size: 9pt; color: rgb(51, 51, 51);">不断更新注册资料，符合及时、详尽准确的要求。所有原始键入的资料将引用为注册资料。</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"></span></p> <p class="MsoNormal" align="left" style="line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(119, 119, 119);">另外，用户可授权上海渡福实业有限公司向第三方透漏其注册资料，否则上海渡福实业有限公司不能公开用户的姓名、住址、出件地址、电子邮箱、账号。除非：</span></p> <p class="MsoListParagraph" align="left" style="margin-left: 36pt; text-indent: -36pt; line-height: 18pt; vertical-align: baseline;"><!--[if !supportLists]--><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-bidi-font-family: 宋体;color:#777777;mso-font-kerning:0pt">（1）<span style="font-stretch: normal; font-size: 7pt; line-height: normal; font-family: 'Times New Roman';">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><!--[endif]--><span style="font-size: 9pt; color: rgb(119, 119, 119);">用户要求上海渡福实业有限公司或授权某人通过电子邮件服务或其他方式透漏这些信息。</span></p> <p class="MsoListParagraph" align="left" style="margin-left: 36pt; text-indent: -36pt; line-height: 18pt; vertical-align: baseline;"><!--[if !supportLists]--><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-bidi-font-family: 宋体;color:#777777;mso-font-kerning:0pt">（2）<span style="font-stretch: normal; font-size: 7pt; line-height: normal; font-family: 'Times New Roman';">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></span><!--[endif]--><span style="font-size: 9pt; color: rgb(119, 119, 119);">相应的法律、法规要求及程序服务需要上海渡福实业有限公司提供用户的个人资料。</span></p> <p class="MsoNormal" align="left" style="line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(119, 119, 119);">用户应该为自己提供资料的合法性负责，如果用户提供的资料不准确，不真实，不合法有效，上海渡福实业有限公司保留结束用户使用上海渡福实业有限公司各项服务的权利。</span></p> <p class="MsoNormal" align="left" style="line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(119, 119, 119);">用户在享用上海渡福实业有限公司各项服务的同时，同意接受上海渡福实业有限公司提供的各类信息服务。</span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">5</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、电子邮件</span></b><b></b></p> <p class="MsoNormal" align="left" style="text-indent: 24pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">用户在注册时应当选择稳定性及安全性相对较好的电子邮箱，并且同意接受并阅读本网站发往用户的各类电子邮件。如用户未及时从自己的电子邮箱接受电子邮件或因用户电子邮箱或用户电子邮件接收及阅读程序本身的问题使电子邮件无法正常接收或阅读的，只要本网站成功发送了电子邮件，应当视为用户已经接收到相关的电子邮件。电子邮件在发信服务器上所记录的发出时间视为送达时间。</span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">6</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、服务条款的修改</span></b><b></b></p> <p class="MsoNormal" align="left" style="text-indent: 24pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">本网站有权在必要时修改服务条款，本网站服务条款一旦发生变动，将会在重要页面上提示修改内容。如果不同意所改动的内容，用户可以主动取消获得的本网站信息服务。如果用户继续享用本网站信息服务，则视为接受服务条款的变动。本网站保留随时修改或中断服务而不需通知用户的权利。本网站行使修改或中断服务的权利，不需对用户或第三方负责。</span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">7</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、用户的帐号、密码和安全性</span></b><b></b></p> <p class="MsoNormal" align="left" style="text-indent: 24pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">你一旦注册成功成为用户，你将得到一个密码和帐号。如果你不保管好自己的帐号和密码安全，将负全部责任。另外，每个用户都要对其帐户中的所有活动和事件负全责。你可随时根据指示改变你的密码，也可以结束旧的帐户重开一个新帐户。用户同意若发现任何非法使用用户帐号或安全漏洞的情况，请立即通知本网站。</span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">8</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、拒绝提供担保</span></b><b></b></p> <p class="MsoNormal" align="left" style="text-indent: 24pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">用户明确同意信息服务的使用由用户个人承担风险。本网站不担保服务不会受中断，对服务的及时性，安全性，出错发生都不作担保，但会在能力范围内，避免出错。</span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">9</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、有限责任</span></b><b></b></p> <p class="MsoNormal" align="left" style="text-indent: 24pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">本网站对任何直接、间接、偶然、特殊及继起的损害不负责任，这些损害来自：不正当使用本网站服务，或用户传送的信息不符合规定等。这些行为都有可能导致本网站形象受损，所以本网站事先提出这种损害的可能性，同时会尽量避免这种损害的发生。</span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">10</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、信息的储存及限制</span></b><b></b></p> <p class="MsoNormal" align="left" style="text-indent: 24pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">本网站有判定用户的行为是否符合本网站服务条款的要求和精神的权利，如果用户违背本网站服务条款的规定，本网站有权中断其服务的帐号。</span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">11</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、用户管理</span></b><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"></span></b></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(119, 119, 119);">（</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:#777777;mso-font-kerning:0pt;mso-bidi-font-weight:bold">1</span><span style="font-size: 9pt; color: rgb(119, 119, 119);">）用户在申请使用上海渡福实业有限公司提供的网络服务时，必须向上海渡福实业有限公司提供准确的个人资料，如个人资料有任何变动，必须及时更新。</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#777777; mso-font-kerning:0pt;mso-bidi-font-weight:bold"></span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(119, 119, 119);">（</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:#777777;mso-font-kerning:0pt;mso-bidi-font-weight:bold">2</span><span style="font-size: 9pt; color: rgb(119, 119, 119);">）用户注册成功后，上海渡福实业有限公司将给予每个用户一个用户账号及相应的密码，该用户账号和密码由用户负责保管；用户应当对以其用户账号进行的所有活动和事件法律责任。</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#777777; mso-font-kerning:0pt;mso-bidi-font-weight:bold"></span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(119, 119, 119);">（</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;; color:#777777;mso-font-kerning:0pt;mso-bidi-font-weight:bold">3</span><span style="font-size: 9pt; color: rgb(119, 119, 119);">）用户在使用家具快搜时，上海渡福实业有限公司需要对用户身份进行特别验证，具体的验证方式以页面显示为准。</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#777777; mso-font-kerning:0pt;mso-bidi-font-weight:bold"></span></p> <p class="MsoNormal" align="left" style="text-indent: 4.5pt; line-height: 22.5pt; vertical-align: baseline;"><span lang="EN-US" style="font-size: 9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#777777;mso-font-kerning:0pt; mso-bidi-font-weight:bold">(4) </span><span style="font-size: 9pt; color: rgb(119, 119, 119);">用户在使用家具快搜服务过程中，必须遵循以下原则：</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#777777; mso-font-kerning:0pt;mso-bidi-font-weight:bold"></span></p> <p class="MsoNormal" align="left" style="margin-left: 18pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">（</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">a</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">）遵守中国有关的法律法规；</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"></span></p> <p class="MsoNormal" align="left" style="text-indent: 18pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">（</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">b</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">）</span><span style="font-size:9.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333;mso-font-kerning:0pt"> </span><span style="font-size: 9pt; color: rgb(51, 51, 51);">不得为任何非法目的而使用网络服务系统；</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"></span></p> <p class="MsoNormal" align="left" style="text-indent: 18pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">（</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">c</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">）遵守所有与网络服务有关的网络协议、规定和程序；</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"></span></p> <p class="MsoNormal" align="left" style="text-indent: 18pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">（</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">d</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">）不得利用家具快搜服务系统进行任何可能对互联网的正常运转造成不利影响的行为；</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"></span></p> <p class="MsoNormal" align="left" style="margin-left: 40.55pt; text-indent: -22.5pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">（</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">e</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">）不得利用家具快搜服务系统传输任何骚扰性的、中伤他人的、辱骂性的、恐吓性的、庸俗淫秽的或其他非法的信息资料；</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"></span></p> <p class="MsoNormal" align="left" style="text-indent: 18pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">（</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">f</span><span style="font-size: 9pt; color: rgb(51, 51, 51);">）不得利用家具快搜服务系统进行任何不利于上海渡福实业有限公司的行为；</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"></span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">12</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、保障</span></b><b></b></p> <p class="MsoNormal" align="left" style="text-indent: 24pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">用户同意保障和维护本网站全体成员的利益，负责支付由用户使用超出服务范围引起的律师费用，违反服务条款的损害补偿费用，其它人使用用户的电脑、帐号和其它知识产权的追索费。</span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">13</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、结束服务</span></b><b></b></p> <p class="MsoNormal" align="left" style="text-indent: 24pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">用户或本网站可随时根据实际情况中断一项或多项服务。本网站不需对任何个人或第三方负责而随时中断服务。用户若反对任何服务条款的建议或对后来的条款修改有异议，或对本网站服务不满，用户可以行使如下权利：</span></p> <p class="MsoNormal" align="left" style="line-height: 18pt; vertical-align: baseline;"><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">(1) </span><span style="font-size: 9pt; color: rgb(51, 51, 51);">不再使用本网站信息服务。</span><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt"><br> (2) </span><span style="font-size: 9pt; color: rgb(51, 51, 51);">通知本网站停止对该用户的服务。</span><span lang="EN-US" style="font-size: 9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#777777;mso-font-kerning:0pt"></span></p> <p class="MsoNormal" align="left" style="text-indent: 24pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">结束用户服务后，用户使用本网站服务的权利马上中止。从那时起，用户没有权利，本网站也没有义务传送任何未处理的信息或未完成的服务给用户或第三方。</span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">14</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、通告</span></b><b></b></p> <p class="MsoNormal" align="left" style="text-indent: 24pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">所有发给用户的通告都可通过重要页面的公告或电子邮件或常规的信件传送。服务条款的修改、服务变更、或其它重要事件的通告都会以此形式进行。</span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">15</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、信息内容的所有权</span></b><b></b></p> <p class="MsoNormal" align="left" style="text-indent: 24pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">本网站定义的信息内容包括：文字、软件、声音、相片、录象、图表；在广告中全部内容；本网站为用户提供的其它信息。所有这些内容受版权、商标、标签和其它财产所有权法律的保护。所以，用户只能在本网站和广告商授权下才能使用这些内容，而不能擅自复制、再造这些内容、或创造与内容有关的派生产品。</span></p> <p class="MsoNormal" align="left" style="line-height: 22.5pt; vertical-align: baseline;"><b><span lang="EN-US" style="font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#333333; mso-font-kerning:0pt">16</span></b><b><span style="font-size: 9pt; color: rgb(51, 51, 51);">、法律</span></b><b></b></p> <p class="MsoNormal" align="left" style="text-indent: 24pt; line-height: 18pt; vertical-align: baseline;"><span style="font-size: 9pt; color: rgb(51, 51, 51);">本网站信息服务条款要与中华人民共和国的法律解释一致。用户和本网站一致同意服从本网站所在地有管辖权的法院管辖。</span></p> 
        </div>
        </div>
        <!--注册协议-->
        <div class="zhucey">
            <img src="/resource/images/gg1.gif" width="260" height="207" alt="" /><br>
            <br>
            <a href="reg.aspx">
                <img src="/resource/images/ann.gif" width="167" height="46" alt="" /></a>
        </div>
    </div>  
    
        <asp:HiddenField ID="hideurl" runat="server" />

    <asp:HiddenField runat="server" ID="hdpopflag" Value="0" /> 
    </form>
    <ucfooter:footer ID="header2" runat="server" />

    <script language="javascript" type="text/javascript">
        function xieyiclose() {
            $("#zhucexy").hide();
        }
        $(document).ready(function () {
            $(':radio[name="Radio_usertype"]').change(
        function () {
            checkusertype();
        }
        );
        });
    function checkusertype() {
        var id = $(':radio[name="Radio_usertype"]:checked').val();
        $("#table101").hide();
        $("#table102").hide();
        $("#table103").hide();
        $("#table105").hide();
        $("#table" + id).show();
    }

    function sjcodechange() {
        $("#imgcode_sj")[0].click();
    }

    //商家用户验证
    function checksjuser(e) {

        if ($.trim($("#txt_memberusername").val()) == '') {
            alert('用户名不能为空');
            if (document.all) e.returnValue = false;
            else e.preventDefault();
            return false;
        }

        if ($.trim($("#txt_membermobile").val()) == '') {
            alert('手机号码不能为空');
            if (document.all) e.returnValue = false;
            else e.preventDefault();
            return false;
        }

        var reg = new RegExp(/((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/);
        var input = $.trim($.trim($("#txt_membermobile").val()));
        if (!reg.test(input)) {
            alert('手机号码有误');
            return;
            window.event.returnValue = false;
        }


        if ($.trim($("#txt_sjdtcode").val()) == '') {
            alert('短信动态码不能为空');
            if (document.all) e.returnValue = false;
            else e.preventDefault();
            return false;
        }
        if ($.trim($("#txt_sjpwd1").val()) == '') {
            alert('创建密码不能为空');
            if (document.all) e.returnValue = false;
            else e.preventDefault();
            return false;
        }
        if ($.trim($("#txt_sjpwd2").val()) == '') {
            alert('确认密码不能为空');
            if (document.all) e.returnValue = false;
            else e.preventDefault();
            return false;
        }
        
    }
    function checksj101(e) {

        if ($.trim($("#txt_companyName").val()) == '') {
            alert('工厂名称不能为空');
            if (document.all) e.returnValue = false; 
            else e.preventDefault();
            return false;
        }


        if ($.trim($("#txt_companyareacode").val()) == '') {
            alert('请选择地区');
            if (document.all) e.returnValue = false;
            else e.preventDefault();
            return false;
        }
        if ($.trim($("#txt_companyAddress").val()) == '') {
            alert('具体地址不能为空');
            if (document.all) e.returnValue = false;
            else e.preventDefault();
            return false;
        }
        

        if ($.trim($("#txt_companybrand").val()) == '') {
            alert('请填写品牌名称');
            if (document.all) e.returnValue = false;
            else e.preventDefault();
            return false;
        }


        if ($.trim($("#txt_companylinkman").val()) == '') {
            alert('请填写联系人');
            if (document.all) e.returnValue = false;
            else e.preventDefault();
            return false;
        }

        if ($.trim($("#txt_companyMenth").val()) == '') {
            alert('请填写联系方式');
            if (document.all) e.returnValue = false;
            else e.preventDefault();
            return false;
        }
        if ($.trim($("#txt_sjcode").val()) == '') {
            alert('验证码不能为空');
            if (document.all) e.returnValue = false;
            else e.preventDefault();
            return false;
        }
        
    }
    function checksj(e) {
        var id = $(':radio[name="Radio_usertype"]:checked').val();
        checksjuser(e);
        if (id == '101') {
            getfla = checksj101(e);
        }

    }
    </script>
</body>
</html>
