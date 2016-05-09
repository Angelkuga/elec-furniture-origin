<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotionstage.aspx.cs" Inherits="TREC.Web.Admin.promotion.promotionstage" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/script/fileupload.js"></script>
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
        });
    </script>
</head>
<body>
<form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">
                设置促销规则
            </th>
        </tr>
        <tr>
            <td align="right">规则标题：</td>
            <td>
                <asp:TextBox ID="txttitle" runat="server" CssClass="input w380" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="70" align="right">
                促销类型：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlstype" runat="server" CssClass="select selectNone"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">规则条件：</td>
            <td><asp:DropDownList ID="ddlsmodule" runat="server" CssClass="select"></asp:DropDownList></td>
        </tr>
       <tr>
            <td align="right">条件值：</td>
            <td>
                <asp:TextBox ID="txtsvaluemin" runat="server" CssClass="input" Width="60"></asp:TextBox><label>-</label>
                <asp:TextBox ID="txtsvaluemax" runat="server" CssClass="input" Width="60"></asp:TextBox><label>模则对象的值范围</label>
            </td>
        </tr>
        <tr>
            <td align="right">促销对象：</td>
            <td><asp:DropDownList ID="ddlpmodule" runat="server" CssClass="select"></asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right">促销值：</td>
            <td>
                <asp:TextBox ID="txtpvalue" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">规则公式：</td>
            <td>
                <asp:TextBox ID="txtrule" runat="server" CssClass="textarea" Width="380" Height="60" TextMode="MultiLine"></asp:TextBox>(示意)
            </td>
        </tr>
        <tr>
            <td align="right">排序：</td>
            <td>
                <asp:TextBox ID="txtsort" runat="server" CssClass="input" Width="40">0</asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="margin-top:10px; margin-left:180px">
      <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
                onclick="btnSave_Click" /><input name="重置" type="reset" class="submit" value="重置" />
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th align="left">规则列表：</th>
        </tr>
    <asp:Repeater ID="rptlist" runat="server">
        <ItemTemplate>
            <tr>
                <td><a href="promotionstage.aspx?edit=1&id=<%#Eval("id") %>&pid=<%=ECommon.QueryPId %>&did=<%=ECommon.QueryDId %>"><%#Eval("title") %></a></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </table>
</form>
</body>
</html>
