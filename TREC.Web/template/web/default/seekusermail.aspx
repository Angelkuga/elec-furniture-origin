<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seekusermail.aspx.cs" Inherits="TREC.Web.aspx.seekusername" %>

<%--<%@ Register Src="ascx/_head.ascx" TagName="_head" TagPrefix="uc1" %>
<%@ Register Src="ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="ascx/_foot.ascx" TagName="_foot" TagPrefix="uc3" %>
<%@ Register Src="ascx/_nav.ascx" TagName="_nav" TagPrefix="uc4" %>--%>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>家具快搜-找回用户密码</title>
    <%--<uc2:_resource ID="_resource1" runat="server" />--%>
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
        .tip
        {
            color: Red;
            font-size: 12px;
        }
        span.error
        {
            color: #F00;
            background: url(../images/onError.gif) left center no-repeat;
            float: right;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#btnLogin").click(function () {
                var txtRegName = $("#txtRegName");
                var txtEmail = $("#txtEmail");
                if (txtRegName.val() == "") {
                    alert("请输入您的账号!");
                    txtRegName.focus();
                    return;
                }
                if (txtEmail.val() == "") {
                    alert("请输入您的邮件账号!");
                    txtEmail.focus();
                    return;
                }
                if (txtRegName.val() != "" && txtEmail.val() != "") {
                    $.ajax({
                        url: "../ajax/ajaxuser.ashx",
                        data: 'type=checkmoblieemail&v=' + txtRegName.val() + "&v2=" + txtEmail.val() + "&t=email&ram=" + Math.random(),
                        dataType: 'text',
                        success: function (data) {
                            if (data == "false") {
                                alert("没有找到,您输入的账号名和邮件账号无效!");
                                txtPhone.select();
                            }
                            else {
                                doSend();
                            }
                        }
                    });
                }
            })
        });
        function doSend() { 
            var txtEmail = $("#txtEmail");
            $.ajax({
                url: "../ajax/ajaxuser.ashx",
                data: 'type=seeknameemail&v=' + txtEmail.val() + "&ram=" + Math.random(),
                dataType: 'text',
                success: function (data) {
                    if (data == "true") {
                        alert("您的新密码已发送到您的邮箱中，请妥善保管，谢谢!");
                        $("#btnLogin").hide();
                        window.location.href = "index.aspx";
                    } else {
                        alert(data);
                        return;
                    }
                }
            });
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
            <div class="bzctit">
                Email找回用户密码</div>
            <div class="bzccon">
                <input type="hidden" id="hf" name="hf" value="seekback" />
                <table width="80%" border="0" cellspacing="0" cellpadding="0" class="registration1"
                    style="margin: 0 auto;">
                    <tr>
                        <td colspan="2" align="right" style="line-height: 30px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tr" >
                            请输入您注册时的账号：
                        </td>
                        <td class="tl">
                            <input type="text" name="txtRegName" value="" id="txtRegName" class="regiinput" /><span
                                class="tip">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tr" align="right">
                            请输入您的邮箱：
                        </td>
                        <td class="tl">
                            <input type="text" name="txtEmail" value="" id="txtEmail" class="regiinput" /><span
                                class="tip">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <div class="homebraLi23">
                                <a href="javascript:;" id="btnLogin">提&nbsp;交</a>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right" style="line-height: 30px;">
                            &nbsp;
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
