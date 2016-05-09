<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seekusername.aspx.cs" Inherits="TREC.Web.seekusername" %>

<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>家具快搜-找回用户名</title>
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <link href="/resource/content/css/core.css" rel="stylesheet" />
    <link href="/resource/content/css/index/index.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />
    <script src="/resource/content/js/core.js" type="text/javascript"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/')%>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/')%>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/')%>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/')%>/script/jquery.form.js"></script>
<style>
 .tip{ color:Red; font-size:12px;}
span.error{	
	color:#F00;
	background:url(../images/onError.gif) left center no-repeat;
	float:right;
	
}
</style>
    <script type="text/javascript">
        $(function () {

            $("#txtPhone").blur(function () {
                var txtRegName = "";
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

                var txtPhone = $("#txtPhone");
                var txtcode = $("#txtcode");


                if (txtPhone.val() == "") {
                    alert("请输入您注册时的手机号码!");
                    txtPhone.focus();
                    return;
                }
                if (txtcode.val() == "") {
                    alert("请输入您手机接收到的验证码!");
                    txtcode.focus();
                    return;
                }


                $.ajax({
                    url: "../ajax/ajaxuser.ashx",
                    data: 'type=seekname&v=' + txtcode.val() + "&phone=" + escape(txtPhone.val()) + "&ram=" + Math.random(),
                    dataType: 'text',
                    success: function (data) {
                        if (data == "true") {
                            alert("您的用户名已发送到您的手机，请妥善保管，谢谢!");
                            window.location.href = "index.aspx";
                        } else {
                            alert(data);
                            // txtcode.select();
                            return;
                        }
                    }
                });


            })

        });
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
                //txtPhone.focus();
                return;
            }
            if (txtPhone.val() != "") {
                $.ajax({
                    url: "../ajax/ajaxuser.ashx",
                    data: 'type=checkmoblieemail&v=' + txtPhone.val()+ "&t=moblie&ram=" + Math.random(),
                    dataType: 'text',
                    success: function (data) {
                        if (data == "false") {
                            alert("您输入的手机号码无效!");
                          //  txtPhone.select();
                            //  return;                                
                        } else {
                            $.ajax({
                                url: "../ajax/ajaxuser.ashx",
                                data: 'type=sendcode&v=' + txtPhone.val()+"&title="+escape("用户名") + "&ram=" + Math.random(),
                                dataType: 'text',
                                success: function (data) {
                                    if (data == "true") {
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
        function showhide() {
            var vals = $('input:radio[name="Email"]:checked').val();
            $("#showval").val(vals);
            // alert(vals)
            if (vals == 'email') {
                $("#selquestion").get(0).selectedIndex = 2
                $("#question_q").hide();

                $("#txtanswer").val('000');
                $("#question_a").hide();

                $("#txtEmail").val('');
                $("#email").show();

                $("#pass").val("000000");
                $("#pass").hide();

                $("#pass2").val("000000");
                $("#pass2").hide();
            }
            else if (vals == 'question') {
                $("#selquestion").get(0).selectedIndex = 0
                $("#question_q").show();

                $("#txtanswer").val('');
                $("#question_a").show();

                $("#txtEmail").val('0e0m0a0i0l');
                $("#email").hide();

                $("#pass").val("");
                $("#pass").show();

                $("#pass2").val("");
                $("#pass2").show();
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <%--<uc1:_head ID="_head1" runat="server" />
    <uc4:_nav ID="_nav1" runat="server" />--%>
    <uc1:header ID="header1" runat="server" />
    <div class="topNav992">
        <div class="zhuce">
            <div class="bzctit">找回用户名</div>
            <div class="bzccon">
              <input type="hidden" id="hf" name="hf" value="seekback" />
                <table width="80%" border="0" cellspacing="0" cellpadding="0" class="registration1" style=" margin:0 auto;">
                    <tr><td colspan="2" align="right" style="line-height: 30px;">&nbsp;</td></tr>
                                
                     <tr>
                        <td class="tr" align="right">请输入您注册时的手机号码：</td>
                        <td class="tl" >
                            <input type="text" name="txtPhone" value="" maxlength="11" id="txtPhone" class="regiinput" /><span  class="tip">*</span>
                                <a  onclick="sendCode()"  style=" color:Blue; text-decoration:underline"  id="getCode">获取验证码</a>
                            
                        </td>
                    </tr>
                     <tr>
                        <td class="tr" align="right">请输入手机验证码：</td>
                        <td class="tl" >
                            <input type="text" name="txtcode" value="" maxlength="6" id="txtcode" class="regiinput" /><span  class="tip">*</span> 
                        </td>
                    </tr>
                  
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <div class="homebraLi23">
                                <a href="javascript:;" id="btnLogin">提&nbsp;交</a>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right" style="line-height: 30px;">&nbsp;
                            
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <%--<uc3:_foot ID="_foot1" runat="server" />--%>
    <ucfooter:footer ID="header3" runat="server" />
    </form>
</body>
</html>
