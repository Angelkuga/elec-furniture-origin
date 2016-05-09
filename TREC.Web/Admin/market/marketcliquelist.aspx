<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="marketcliquelist.aspx.cs" Inherits="TREC.Web.Admin.market.marketcliquelist" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script> 
    <script type="text/javascript" src="../script/admin.js"></script>
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
<body>
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="back"><a href="marketcliquelist.aspx">列表</a></span><b>您当前的位置：首页 &gt; 后台供应商 &gt;
            卖场集团管理</b>
    </div>
    <div class="spClear">
    </div>
    <table>
        <tr>
            <td>
                审核：
            </td>
            <td>
                <asp:DropDownList ID="ddlauditstatus" runat="server">
                    <asp:ListItem Value="">--请选择--</asp:ListItem>
                    <asp:ListItem Value="-1">正在审核</asp:ListItem>
                    <asp:ListItem Value="0">等待审核</asp:ListItem>
                    <asp:ListItem Value="1">审核通过</asp:ListItem>
                    <asp:ListItem Value="-99">审核未过</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="submit" Text="提交" OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th width="40px" align="center">
                选择
            </th>
            <th width="40px" align="center">
                编号
            </th>
            <th align="left">
                集团名称
            </th>
            <th align="left">
                董事长
            </th>
            <th align="center" width="160px">
                最后修改时间
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
                        <asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                    </td>
                    <td align="left">
                        <a href="marketcliqueinfo.aspx?edit=1&id=<%#Eval("Id") %>">
                            <%#Eval("Title")%></a>
                    </td>
                    <td align="left">
                        <%#Eval("Chairman")%>
                    </td>
                    <td align="center">
                        <%#Eval("LastediTime")%>
                    </td>
                    <td align="right" style="padding-left: 5px;">
                        <a href="marketcliqueinfo.aspx?edit=1&id=<%#Eval("Id") %>">修改</a><%--|<a href="marketlist.aspx?edit=2&id=<%#Eval("Id") %>">删除</a>--%>
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
                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页">
            </webdiyer:AspNetPager>
        </div>
        <div class="left">
            <span class="btn_all" onclick="checkAll(this);">全选</span> <span class="btn_bg">
                <%--<asp:LinkButton ID="lbtnDel" runat="server" OnClientClick="return confirm( '确定要删除这些记录吗？ ');"
                    OnClick="lbtnDel_Click">删 除</asp:LinkButton>--%>&nbsp;&nbsp; </span>
                    <span class="btn_bg">
                     <span class="btn_bg">
                <asp:LinkButton ID="linkGo" runat="server" OnClientClick="return confirm( '确定要审核通过这些记录吗？ ');" OnClick="linkGo_Click">审核通过</asp:LinkButton>&nbsp;&nbsp; </span>
                <span class="btn_bg">
                <asp:LinkButton ID="lonkNo" runat="server" 
                OnClientClick="return confirm( '确定要未通过审核这些记录吗？ ');" onclick="lonkNo_Click" >未通过审核</asp:LinkButton>&nbsp;&nbsp; </span>
        </div>
    </div>
    </form>
</body>
</html>
