<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="membergroupinfo.aspx.cs" Inherits="TREC.Web.Admin.member.membergroupinfo" %>
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
      <span class="back"><a href="actionlist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 会员管理 &gt; 会员组</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">会员组</th>
        </tr>
        <tr>
	        <td width="100px" align="right">会员组名称：</td>
	        <td >
		        <asp:TextBox id="txttitle" runat="server" CssClass="input w160 required"></asp:TextBox>
	        </td>
        </tr>
        <tr>
            <td align="right">
                颜色 ：
            </td>
            <td height="25" width="*">
                <asp:TextBox ID="txtcolor" runat="server" CssClass="w160 input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                组图片 ：
            </td>
            <td height="25" width="*">
                <asp:TextBox ID="txtavatar" runat="server" CssClass="w160 input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                积分 ：
            </td>
            <td height="25" width="*">
                <asp:TextBox ID="txtintegral" runat="server" CssClass="w160 input required number">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                金额 ：
            </td>
            <td height="25" width="*">
                <asp:TextBox ID="txtmoney" runat="server" CssClass="w160 input required number">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                权限 ：
            </td>
            <td height="25" width="*">
                <asp:TextBox ID="txtpermissions" runat="server" CssClass="w160 input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                级别 ：
            </td>
            <td height="25" width="*">
                <asp:TextBox ID="txtlev" runat="server" CssClass="w160 input required digits">1</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                描述 ：
            </td>
            <td height="25" width="*">
                <asp:TextBox ID="txtdescript" runat="server" CssClass=" w380 textarea" Rows="3" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                排序：
            </td>
            <td>
                <asp:TextBox ID="txtsort" runat="server" Width="40px" CssClass="input required digits">0</asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="margin-top:10px; margin-left:110px">
  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
            onclick="btnSave_Click" /><input name="重置" type="reset" class="submit" value="重置" />
</div>
</form>
</body>
</html>
