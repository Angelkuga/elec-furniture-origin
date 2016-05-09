<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Member.Master" CodeBehind="editpwd.aspx.cs" Inherits="TREC.Web.Suppler.member.editpwd" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="../script/supplercommon.js"></script>
    <script type="text/javascript">
        $(function () {
            //表单验证JS
            $("#form1").validate({
                //出错时添加的标签
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
                    //正确时的样式
                    label.text(" ").addClass("success");
                }
            });
        })
        function checkinput() {
            var oldpwd = $("#<%=txtOldPwd.ClientID %>");
            if (oldpwd.val() == "") {
                alert("请输入旧密码");
                oldpwd.focus();
                return false;
            }
            var newpwd = $("#<%=txtNewPwd.ClientID %>");
            if (newpwd.val() == "") {
                newpwd.focus();
                alert("请输入新密码！");
                return false;
            }
            var checkpwd = $("#<%=txtCheckPwd.ClientID %>");
            if (checkpwd.val() == "") {
                checkpwd.focus();
                alert("请再次输入新密码！");
                return false;
            }
            if (newpwd.val() != checkpwd.val()) {
                alert("两次输入的新密码不一致！");
                return false;
            }
            if (oldpwd.val() == newpwd.val()) {
                alert("旧密码和新密码一样！");
                return false;
            }
            return true;

        }
    </script>
    <style type="text/css">
    .pop{position:absolute;}
    .guishudp input{margin-right:10px;}
    #typeId,#MaterialId,#SeriesId{width:72px;}
    .addcm{ position:relative;}
    .wait{ position:absolute; z-index:100; background:#ccc;width:94%;top:0;height:246px; line-height:246px;filter:alpha(opacity=80);-moz-opacity:0.8;opacity:0.8;color:#000;font-size:14px;}
    #copyproductdiv{width:450px;}
    #copyproductdiv .popcon{width:410px;}
    #copyproductdiv td{font-size:13px;padding-left:0;}
</style>
</head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="6" cellspacing="1" class="formTable">
        <tbody id="Tabs1">
            <tr>
                <td class="tl" align="right" style="color:Red;">
                    注：
                </td>
                <td class="tr f_red" style="color:Red;">
                        修改密码成功后必须重新登录系统
                </td>
            </tr>
            <tr>
                <td class="tl" align="right">
                    旧密码：
                </td>
                <td class="tr f_red">
                    <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password" Width="180" CssClass="required input"></asp:TextBox>&nbsp;
                    <span class="lbInfo">*输入您原来的密码!</span>
                </td>
            </tr>
            <tr>
                <td class="tl" align="right">
                    新密码：
                </td>
                <td class="tr  f_red">
                    <asp:TextBox ID="txtNewPwd" runat="server"  TextMode="Password" Width="180" CssClass="required input"></asp:TextBox>
                    <span id="dpassword" class="f_red"></span>
                </td>
            </tr>
            <tr>
                <td class="tl" align="right">
                    重复新密码：
                </td>
                <td class="tr  f_red">
                    <asp:TextBox ID="txtCheckPwd" runat="server"  TextMode="Password" Width="180" CssClass="required input"></asp:TextBox>&nbsp;
                    <span id="dcpassword" class="f_red"></span>
                </td>
            </tr>
        </tbody>
        <tr>
            <td class="tl">
                &nbsp;
            </td>
            <td class="tr  f_red">
                <asp:Button ID="btnEdit" runat="server" Text="保 存" CssClass="submit" OnClientClick="return checkinput();" OnClick="btnEdit_Click" />
                <input type="button" value=" 返 回 " class="submit" onclick="history.back(-1);" />
            </td>
        </tr>
    </table>
</asp:Content>