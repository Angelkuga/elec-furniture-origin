<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createsmarket.aspx.cs"
    Inherits="TREC.Web.Suppler.shop.createsmarket" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新建卖场</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="<%="\""+TREC.ECommerce.ECommon.WebSupplerResourceUrl%>/altdialog/skins/default.css" />
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.inputlabel.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/altdialog/artDialog.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/altdialog/plugins/iframeTools.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/fileupload.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="../script/formValidator-4.1.1.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../script/formValidatorRegex.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../script/supplercommon.js"></script>
    <script type="text/javascript" src="../script/pageValitator/shopaddmarket.js"></script>
</head>
<body style="height: auto">
    <form id="form1" runat="server">
    <table class="formTable">
        <tr>
            <th colspan="2">
                &nbsp;&nbsp;卖场信息：<asp:HiddenField ID="hfcompanyid" runat="server" />
            </th>
        </tr>
        <tr>
            <td align="right">
                地区：
            </td>
            <td>
                <div class="_droparea" id="ddlareacode">
                </div>
            </td>
        </tr>
        <tr>
            <td align="right">
                地址：
            </td>
            <td>
                <asp:TextBox ID="txtaddress" runat="server" CssClass="input required" Style="width: 310px"></asp:TextBox>
                <div id="txtaddressTip" style="width: 280px; float: left" class="forTip">
                </div>
            </td>
        </tr>
        <tr>
            <td align="right" width="70">
                卖场名称：
            </td>
            <td>
                <asp:TextBox ID="txtmarkettitle" runat="server" CssClass="input"></asp:TextBox>
                <div id="txtmarkettitleTip" style="width: 280px; float: left" class="forTip">
                </div>
            </td>
        </tr>
        <tr style="display: none;">
            <td align="right">
                联系人：
            </td>
            <td>
                <asp:TextBox ID="txtlinkman" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none;">
            <td align="right">
                联系电话：
            </td>
            <td>
                <asp:TextBox ID="txtphone" runat="server" CssClass="input"></asp:TextBox>
                <div id="txtphoneTip" style="width: 280px; float: left" class="forTip">
                </div>
            </td>
        </tr>
        <tr style="display: none;">
            <td align="right">
                卖场介绍：
            </td>
            <td>
                <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea" TextMode="MultiLine"
                    Height="80px" Width="500"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="margin-top: 10px; margin-left: 80px">
        <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" OnClick="btnSave_Click" /><input
            name="重置" type="reset" class="submit" value="重置" />
    </form>
</body>
</html>
