<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grouporderproductinfo.aspx.cs" Inherits="TREC.Web.Admin.grouporder.grouporderproductinfo" %>
<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/My97DatePicker/WdatePicker.js"></script>
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
<body style="padding:10px;">
<form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="grouporderproductlist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 订单管理 &gt; 团购订单</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="3" align="left">订单信息</th>
        </tr>
        <tr>
            <td width="120" align="right">
                订单编号 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtgrouporderno" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>    
            <td  align="right">
                活动介绍ID ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtpromotionid" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                活动内容ID：
            </td>
            <td align="left">
                <asp:TextBox ID="txtpromotiondefid" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                优惠规则ID ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtpromoteionstageid" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                产品ID ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtproductid" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                产品属性ID：
            </td>
            <td align="left">
                <asp:TextBox ID="txtproductattributeid" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                产品code ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtproductcode" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                产品名称 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtproductname" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                产品颜色 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtcolor" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                产品选材 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtmaterial" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                产品大小 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtsize" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                产品体积 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtcbm" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                产品数量 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtnum" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                产品单价(原) ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtprice" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                总价(原) ：
            </td>
            <td align="left">
                <asp:TextBox ID="txttotalmoney" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                产品单价(活动) ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtproprice" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                总价 (活动)：
            </td>
            <td align="left">
                <asp:TextBox ID="txtprototalmoney" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
    </table>
    
    <div style="margin-top:10px; margin-left:140px">
  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
            onclick="btnSave_Click" /><input name="重置" type="reset" class="submit" value="重置" />
</div>
</form>
</body>
</html>
