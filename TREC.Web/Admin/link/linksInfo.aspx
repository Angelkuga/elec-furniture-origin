<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="linksInfo.aspx.cs"
    Inherits="TREC.Web.Admin.link.linksInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="TREC.ECommerce" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新增工厂招商信息</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="../script/admin.js"></script>
    <style type="text/css">
        .formTable
        {
            border: 1px solid #ccc;
        }
        .formTable tr th
        {
            background: #ededed;
            text-align: left;
        }
        .formTable tr td
        {
            border: none;
            padding-top: 8px;
            padding-bottom: 8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="back"><a href="newslist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 友情连接 &gt;
            友情连接</b>
    </div>
    <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">
                友情连接
            </th>
        </tr>
        <tr>
            <td>
                <table class="formTable" width="770">
                    <tr>
                        <th colspan="2">
                            友情连接：
                        </th>
                    </tr>
                    <tr>
                        <td align="right" width="70">
                            名称：
                        </td>
                        <td>
                            <asp:TextBox ID="tbTitle" runat="server" Width="300"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="70">
                            连接：
                        </td>
                        <td>
                            <asp:TextBox ID="tblink" runat="server" CssClass="textarea required"  Width="650"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            上/下线：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddllinestatus" runat="server" CssClass="select selectNone"
                                Width="160">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div style="margin-top: 10px; margin-left: 180px">
        <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
            onclick="btnSave_Click" /><input name="重置"
            type="reset" class="submit" value="重置" />
    </div>
    </form>
</body>
</html>
