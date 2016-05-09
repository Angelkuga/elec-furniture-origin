<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customerinfo.aspx.cs" Inherits="TREC.Web.Admin.member.customerinfo" %>

<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>消费用户信息</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/fileupload.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
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
    <style type="text/css">
        .adType
        {
            display: none;
        }
    </style>
</head>
<body style="padding: 10px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="back"><a href="customerlist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt;
            会员管理 &gt; 消费用户信息</b>
    </div>
    <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">
                消费用户信息
            </th>
        </tr>
        <tr>
            <td width="160px" align="right">
                账号类型 ：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddltype" runat="server" CssClass="select">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                账号名称 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtname" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="160px" align="right" style="color: #f30">
                账号密码 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtpwd" runat="server" CssClass="input  w250"></asp:TextBox>
                <span style="color: #FF0000;">密码重设置填写不改留空</span>
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                注册IP ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtIP" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                注册时间 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtregtime" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                状态：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlustatus" runat="server" CssClass="select">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <div style="margin-top: 10px; margin-left: 180px">
        <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" OnClick="btnSave_Click" /><input
            name="重置" type="reset" class="submit" value="重置" />
    </div>
    </form>
</body>
</html>
