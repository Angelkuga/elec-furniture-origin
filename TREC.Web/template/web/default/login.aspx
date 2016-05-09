<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TREC.Web.aspx.login" %>

<%@ Register Src="ascx/_head.ascx" TagName="_head" TagPrefix="uc1" %>
<%@ Register Src="ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="ascx/_foot.ascx" TagName="_foot" TagPrefix="uc3" %>
<%@ Register Src="ascx/_nav.ascx" TagName="_nav" TagPrefix="uc4" %> 
<% Response.Redirect("/reg.aspx?r=l"); %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=pageTitle %></title>

        <meta name="keywords" content="家具品牌,家具品牌排名,家具十大品牌,品牌家具,实木家具十大品牌,儿童家具十大品牌,板式家具十大品牌" />
        <meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！" />
    <uc2:_resource ID="_resource1" runat="server" />
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl%>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl%>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl%>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl%>/script/jquery.form.js"></script>
    <script type="text/javascript">
        $(function () {
            //表单验证JS
            var validator = $("#form1").validate({
                rules: {
                    txtLoginName: {// 需要进行验证的输入框name
                        required: true, // 验证条件：必填
                        minlength: 2
                    },
                    txtLoginPwd: {// 需要进行验证的输入框name
                        required: true, // 验证条件：必填
                        minlength: 6// 验证条件：最小长度为5
                    }
                },
                messages: {
                    txtLoginName: {
                        required: "登陆账号不允许为空!",
                        minlength: jQuery.format("登陆账号最少 {0} 字符!")
                    },
                    txtLoginPwd: {
                        required: "登陆密码不允许为空!",
                        minlength: jQuery.format("密码至少输入 {0} 字符!")
                    }
                },
                errorElement: "span",
                showErrors: function (errorMap, errorList) {
                    if (errorList.length > 0) {
                        if ($("#" + errorList[0].element.id).next() != null) {
                            $("#" + errorList[0].element.id).next().remove();
                        }
                    }
                    this.defaultShowErrors();
                },
                success: function (label) {
                    label.text(" ").addClass("success");

                }
            });

            $("#btnLogin").click(function () {
                if ($("#form1").valid()) {
                    jQuery.ajax({
                        url: 'ajax/ajaxuser.ashx',
                        data: 'type=login&v=' + $("#txtLoginName").val() + '&v2=' + $("#txtLoginPwd").val(),
                        type: 'post',
                        success: function (data) {
                            if (data == "1") {
                                window.location = "<%=getUrlReferrer %>";
                            } else if (data == "2") {
                                window.location = "<%=TREC.ECommerce.ECommon.WebSupplerUrl %>suppler/supplerindex.aspx";
                            }
                            else {
                                alert("用户名或密码错误!");
                            }
                        }
                    });
                }
            })
        });

    </script>
</head>
<body>
    <form id="form1">
    <uc1:_head ID="_head1" runat="server" />
    <uc4:_nav ID="_nav1" runat="server" />
    <div class="topNav992">
        <div class="zhuce">
            <div class="bzctit">
                会员注册</div>
            <div class="bzccon">
                <div class="bzccon1">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="registration1" style="padding-bottom:45px;">
                        <tr>
                            <td colspan="2" align="right" style="line-height: 30px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="114" align="right">
                                登陆名：
                            </td>
                            <td width="77%">
                                <input type="text" name="txtLoginName" id="txtLoginName" class="regiinput" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                密&nbsp;&nbsp;码：
                            </td>
                            <td>
                                <input type="password" name="txtLoginPwd" id="txtLoginPwd" class="regiinput" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <div class="homebraLi23">
                                    <a href="javascript:;" id="btnLogin">登&nbsp;陆</a>
                                </div>
                                &nbsp;<a href="seekpass.aspx" style="color: #C91003; font-weight: bold;vertical-align:middle;">忘记密码？</a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right" style="line-height: 30px;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="login c61f38" style="margin-top: 32px;">
                    <div class="login1">
                        <div class="login10">
                            <a href="reg.aspx">注册账号</a></div>
                    </div>
                    <p>
                        <a href="#" style="line-height: 24px;">为什么要加入我们</a></p>
                    <p>- 家具快搜专注于家具领域最全的行业信息发布和搜索。<br />
                         - 为家具卖家提供便捷、迅速的售货渠道；<br />
                         - 更为卖家量身打造品牌推广、口碑营销的专业化道路。<br />
                         - 低成本，高收益；<br />
                         - 卖家具，上家具快搜已成为家具商家的不二选择！</p>
                </div>
            </div>
        </div>
    </div>
    <uc3:_foot ID="_foot1" runat="server" />
    </form>
</body>
</html>
