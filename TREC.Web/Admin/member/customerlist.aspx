<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customerlist.aspx.cs" Inherits="TREC.Web.Admin.member.customerlist" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <style>
        input
        {
            width: 120px;
        }
    </style>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../script/admin.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".msgtable tr:nth-child(odd)").addClass("tr_bg"); //隔行变色
            $(".msgtable tr").hover(
			    function () {
			        $(this).addClass("tr_hover_col");
			    },
			    function () {
			        $(this).removeClass("tr_hover_col");
			    }
		    );
        })
    </script>
</head>
<body style="padding: 10px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <b>您当前的位置：首页 &gt; 会员管理 &gt;
            消费用户管理</b>
    </div>
    <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="80" align="center">
                账号类型：
            </td>
            <td width="100">
                <asp:DropDownList ID="ddltype" runat="server">
                </asp:DropDownList>
            </td>
            <td width="80" align="center">
                状态：
            </td>
            <td width="100">
                <asp:DropDownList ID="ddlstatus" runat="server">
                </asp:DropDownList>
            </td>
            <td width="50" align="right">
                账号：
            </td>
            <td width="150">
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            </td>
            <td width="50" align="right">
                注册IP：
            </td>
            <td width="150">
                <asp:TextBox ID="txtIP" runat="server"></asp:TextBox>
            </td>
            <td>
                注册时间
            </td>
            <td>
                <asp:TextBox ID="txtstarttime" runat="server"></asp:TextBox>
                <img onclick="WdatePicker({el:'txtstarttime'})" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/My97DatePicker/skin/datePicker.gif"
                    width="16" height="22" style="cursor: pointer" align="absmiddle">
            </td>
            <td>
                <asp:TextBox ID="txtendtime" runat="server"></asp:TextBox>
                <img onclick="WdatePicker({el:'txtendtime'})" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/My97DatePicker/skin/datePicker.gif"
                    width="16" height="22" style="cursor: pointer" align="absmiddle">
            </td>
            <td width="60" align="center">
                <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="submit" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>
    <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th width="40px" align="center">
                选择
            </th>
            <th width="40px" align="center">
                编号
            </th>
            <th align="center" width="160px">
                账号
            </th>
            <th align="center" width="160px">
                账号类型
            </th>
            <th align="center" width="160px">
                注册IP
            </th>
            <th align="center" width="160px">
                注册时间
            </th>
            <th width="80px" align="right" style="padding-left: 5px;">
                操作
            </th>
        </tr>
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                    </td>
                    <td align="center">
                        <%#Eval("Id") %>
                    </td>
                    <td align="center">
                        <%#Eval("uname") %>
                    </td>
                    <td align="center">
                        <%#Eval("unametype")%>
                    </td>
                    <td align="center">
                        <%#Eval("regip")%>
                    </td>
                    <td align="center">
                        <%#Eval("regtime")%>
                    </td>
                    <td align="right" style="padding-left: 5px;">
                        <a href="customerinfo.aspx?edit=1&id=<%#Eval("id") %>">修改</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="spClear">
    </div>
    <div style="line-height: 30px; height: 30px;">
        <div id="Pagination" class="right flickr">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" UrlPaging="true"
                PageSize="20" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页">
            </webdiyer:AspNetPager>
        </div>
        <div class="left">
            <span class="btn_all" onclick="checkAll(this);">全选</span>
            <%--<span class="btn_bg">
                <asp:LinkButton ID="lbtnDel" runat="server" OnClientClick="return confirm( '确定要删除这些记录吗？ ');"
                    OnClick="lbtnDel_Click">删 除</asp:LinkButton>&nbsp;&nbsp; </span>--%>
        </div>
    </div>
    </form>
</body>
</html>
