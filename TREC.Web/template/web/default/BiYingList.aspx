<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BiYingList.aspx.cs" Inherits="TREC.Web.template.web.BiYingList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/resource/content/css/core.css" rel="stylesheet"/>
<link href="/resource/content/css/factory/factory.css" rel="stylesheet"/>
<link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css"/>
<link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css"/>
 <script src="/resource/content/js/jquery-1.4.1.min.js"></script>

 <style type="text/css">
 .biyingList
 {
     border-style : dotted;
	border-width : 1px;
	border-color : #AAAAAA;
	display:none;
	padding:5px 5px 5px 5px;
  }

.bynrn{ width:80px; color:#fff;border:none; cursor:pointer; line-height:22px; margin-bottom:5px;font-size:14px;padding:3px;font-family:"microsoft yahei"; background:#b9003c; border-radius:6px; margin-right:65px;}
.byqh a{ width:212px; float:left; color:#6a6a6a;}
.byqh a.gd{background: url(/resource/content/img/common/j5.png) no-repeat right center;padding-right: 16px; text-align:right;}

.conby{ width:619px; margin:30px auto; padding:90px 260px 30px 20px; border:1px solid #f10148; border-bottom:20px solid #f10148;background:url(/resource/images/us.gif) no-repeat; font-family:"microsoft yahei"; font-size:14px;}
.conby span{font-size:12px; color:#7b7a7a;} .conby p{ margin:25px 0} 
.conbyi{ width:612px; height:145px;}.conbyii{ width:200px; height:30px;} 
.bynri{ width:160px; color:#fff;border:none; cursor:pointer; line-height:35px; margin-bottom:5px;font-size:18px;padding:3px;font-family:"microsoft yahei"; background:#c81033; border-radius:6px;}
.conbyy{ width:569px; margin-top:10px;line-height:35px;padding:20px;}
.conbyy a{ color:#095fa1; margin:0 5px;}
.fileInput{width:102px;height:28px; background: url(/resource/images/12.png);overflow:hidden;position:relative;}
.upfile{position:absolute;top:-100px;}
.upFileBtn{width:102px;height:28px;opacity:0;filter:alpha(opacity=0);cursor:pointer;}

 </style>
</head>
<body>
    <form id="form1" runat="server">
   <div class="site" ><a href="/">首页</a> > 有求必应</div>
<DIV class=conby> <strong>温馨提示：</strong><br />
  您可以提交任何有关家具购买需要咨询的信息或问题；可以提交家具行业任何您想了解的品牌、厂家、店铺、卖场等信息，我们会第一时间给您提供最全的家具资讯服务.  <br />
  <hr />
  <p><strong>需求描述<span style="color:red;">*</span></strong><br />
  <textarea class="conbyi" id="txtDescription" placeholder="请输入需求信息"></textarea></p>
  
  <p><strong>联系手机<span style="color:red;">*</span></strong><br />
  <input  class="conbyii" type="text"  id="txtphone" maxlength="15" placeholder="请输入手机号码" onblur="funcheckphone()"/>
  <input type="radio" name="RadioGroup1" value="工作时间9:00-18:00" id="RadioGroup1_0"  checked="checked"/>
  工作时间9:00-18:00
  <input type="radio" name="RadioGroup1" value="任何时间系" id="RadioGroup1_1" />
  任何时间
  <input type="radio" name="RadioGroup1" value="仅短信联系" id="RadioGroup1_1" />
  仅短信联系 </p>
  <p><strong>联系邮箱或QQ或微信</strong><br />
<input type="text"  class="conbyii"  id="txtMsg" maxlength="30"/>
<br />
<span>当回复的信息内容比较多或是带推荐产品图片信息时需要通过邮件或QQ或微信提供给您!</span></p>
<div id="divimgup" style="display:none;">

</div>

<input type="hidden" id="imguptxt"  value=""/>

  <strong>上传图片</strong><div class="fileInput left">
          <iframe src="/common/SJupfile.aspx?showtxt=imguptxt" style="width:100px;height:30px;" id="frameupimg" frameborder="0" scrolling="no"></iframe>
        </div>
  <span>你可以上传图片更清晰表达您的需求、如产品风格。颜色、问题等 </span>
    <p><strong>验证码</strong><br /><input  style=" float:left; margin-right:10px;" class="conbyii" type="text"  id="txtcode" maxlength="30"/>
<img src="/common/VerifyCode.aspx" width="110" id="imgcheck" height="30" title="看不清，换一张！" onclick="this.src=this.src+'?'" alt=""/></p>
 <p id="pwait" style="display:none;">数据提交中.....</p>
  <p id="pbnt"><input class="bynri" type="button" value="提交"  onclick="BingYingAdd()"/></p>

  <hr  style="border:1px  solid #c81033; margin:70px 0 0 0"/>
  <DIV class="conbyy" id="divbylist">
      <asp:Repeater ID="Repeater_list" runat="server">
      <ItemTemplate>
      <%#Eval("CreateTime", "{0:yyyy-MM-dd hh:mm}")%> <a  href="javascript:byshow('<%#Eval("Id")%>')"><%#curstring(Eval("Description").ToString(),35)%></a><br />
      <div class="biyingList" id="by<%#Eval("Id")%>">
      <%#Eval("Description")%>
      </div>
      </ItemTemplate>
      </asp:Repeater>

</DIV>
<center id="dataloading" style="display:none;">数据加载中......</center>
<center id="biyingmore"><a href="javascript:fundataload()">查看更多</a></center>
</DIV>

<input type="hidden"  value="1" id="inputpageindex"/>
<input type="hidden"  value="<%=pagerow %>" id="inputRowc"/>
<script language="javascript" type="text/javascript">

    function isshowmore() {
        if ($("#inputpageindex").val() != $("#inputRowc").val()) {
            $("#biyingmore").show();
        }
        else {
            $("#biyingmore").hide();
        }
    }
    isshowmore();
    function BingYingAdd() {
        var Description = $("#txtDescription").val();
        var phone = $("#txtphone").val();
        var code = $("#txtcode").val();
        var Msg = $("#txtMsg").val();
        var ImgPath = $("#imguptxt").val();
        var Contact = $(':radio[name="RadioGroup1"]:checked').val();

        if (phone == '') {
            alert('手机号码不能为空');
            return;
            window.event.returnValue = false;
        }
            var reg = new RegExp(/((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/);
            var input = $.trim(phone);
            if (!reg.test(input)) {
                alert('手机号码有误');
                return;
                window.event.returnValue = false;
            }
   

        if ($.trim(Description) == '') {
            alert('提交内容不能为空');
            return;
        }

        if (Description.length > 500) {
            alert('字符串长度不能超过500个字符');
            return;
        }

        if (code == '') {
            alert('验证码不能为空');
            return;
        }
        $("#pbnt").hide();
        $("#pwait").show();
        $.post("/ajax/ajaxBingYing.aspx", { "Description": Description, "phone": phone, "Msg": Msg, "ImgPath": ImgPath, "code": code, "Contact": Contact }, function (data, textStatus) {
            $("#pbnt").show();
            $("#pwait").hide();
            if (data == 'true') {
                $("#txtDescription").val('');
                $("#txtphone").val('');
                $("#txtcode").val('');
                $("#txtMsg").val('');
                alert('您的需求已经提交成功！我们会尽快受理，请耐心等待');
            }
            else {
                alert(data);
                funimgcheck();
            }
        }, null);
    }
    function funimgcheck() {
        $("#imgcheck").attr("src", $("#imgcheck").attr("src") + "?");
    }
    function byshow(id) {
        if ($("#by" + id)[0].style.display == 'block') {
            $("#by" + id).hide();
        }
        else {
            $("#by" + id).show();
        }
    }


    function funcheckphone() {
        var phone = $("#txtphone").val();
        if (phone == '') {
            alert('手机号码不能为空');
            return;
            window.event.returnValue = false;
        }
            var reg = new RegExp(/((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)/);
            var input = $.trim(phone);
            if (!reg.test(input)) {
                $("#txtphone").focus();
                alert('手机号码有误');
                return;
                window.event.returnValue = false;
            }
    }

    $(document).keypress(function (e) {
        // 回车键事件 
        if (e.which == 13) {
            BingYingAdd();
        }
    });

    function fundataload() {
        var p = parseFloat($("#inputpageindex").val()) + 1;
        if (p <= parseFloat($("#inputRowc").val())) {
            $("#inputpageindex").val(p);
            $("#dataloading").show();
            $("#biyingmore").hide();
            $.post("/ajax/BiYingShow.aspx", { "p": p }, function (data, textStatus) {
                $("#dataloading").hide();
                if (p < parseFloat($("#inputRowc").val())) {
                    $("#biyingmore").show();
                }
                //alert(data);
                $("#divbylist").html($("#divbylist").html() + data);
            }, null);
        }
        else {
            $("#biyingmore").hide();
        }
    } 
</script>
    </form>
</body>
</html>
