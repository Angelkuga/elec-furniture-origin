<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="apppromotioncusinfo.aspx.cs" Inherits="TREC.Web.Admin.promotion.apppromotioncusinfo" %>
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
<body style="padding:10px;">
<form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="apppromotioncuslist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 促销活动 &gt; 促销活动信息</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">申请记录</th>
        </tr>
        <tr>
            <td  width="160"  align="right">
                品牌：
            </td>
            <td align="left" >
                <asp:DropDownList ID="ddlappbrand" runat="server" CssClass="select" Width="160px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                姓名 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtname" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                电话 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtphone" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                手机 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtmphone" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                邮件 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtemail" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                地址 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtaddress" runat="server" CssClass="input w380"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                描述 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea w250" Height="60"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                联系记录 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtcus" runat="server" CssClass=" textarea w380" TextMode="MultiLine" Height="80"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="margin-top:10px; margin-left:180px">
  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
            onclick="btnSave_Click" /><input name="重置" type="reset" class="submit" value="重置" />
</div>
</form>
</body>
</html>
