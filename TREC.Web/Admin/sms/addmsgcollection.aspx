<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addmsgcollection.aspx.cs"
    Inherits="TREC.Web.Admin.sms.addmsgcollection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="TREC.ECommerce" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/messages_cn.js"></script>
    <script type="text/javascript">
        function Validate() {
            var name = $("#txtname").val();
            name = name.replace(/[ ]/g, "");
            if (name == "") {
                $("#txtname").val('');
                $("#txtname").focus();
                alert("抱歉，请输入您的姓名！");
                return false;
            }
            var contact = $("#txtcontact").val();
            contact = contact.replace(/[ ]/g, "");
            var regstr = /^0{0,1}(13[0-9]|15[0-9]|153|156|18[0-9])[0-9]{8}$/; //手机13，15，18开头的验证
            if (!regstr.test(contact)) {
                $("#txtcontact").focus();
                alert("抱歉，请输入正确的手机号！");
                return false;
            }
            return true;
        };
        function Reset() {
            $("#txtname").val('');
            $("#txtcontact").val('');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="back"><a href="msgcollectionlist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt;
            报名管理 &gt; 新增/编辑报名</b>
    </div>
    <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">
                报名编辑
            </th>
        </tr>
        <tr>
            <td width="100px" align="right">
                姓名：
            </td>
            <td>
                <asp:TextBox ID="txtname" runat="server" CssClass="input w160 required"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                手机：
            </td>
            <td height="25" width="*">
                <asp:TextBox ID="txtcontact" runat="server" CssClass="input w160 required"></asp:TextBox>
                <asp:HiddenField runat="server" ID="hiddcode" Value="" />
            </td>
        </tr>
        <tr>
            <td align="right">
                地址：
            </td>
            <td height="25" width="*">
                <asp:TextBox ID="txtaddress" runat="server" CssClass="input w160 required"></asp:TextBox>
                <asp:HiddenField runat="server" ID="HiddenField1" Value="" />
            </td>
        </tr>
        <tr>
            <td align="right">
                需求产品：
            </td>
            <td height="25" width="*">
                <asp:TextBox ID="txtProd" TextMode="MultiLine" runat="server" CssClass="input w260 required"></asp:TextBox>
                <asp:HiddenField runat="server" ID="HiddenField2" Value="" />
            </td>
        </tr>
        tr>
        <td align="right">
            活动类型：
        </td>
        <td height="25" width="*">
            <asp:DropDownList ID="ddlPromtype" runat="server">
            </asp:DropDownList>
        </td>
        </tr>
    </table>
    <div style="margin-top: 10px; margin-left: 110px">
        <asp:Button ID="btnSave" runat="server" Text="确认报名" CssClass="submit" OnClick="btnSave_Click"
            OnClientClick="return Validate();" /><input name="重置" type="reset" onclick="Reset();"
                class="submit" value="重置" />
    </div>
    </form>
</body>
</html>
