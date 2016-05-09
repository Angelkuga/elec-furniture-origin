﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="companylist.aspx.cs" Inherits="TREC.Web.Admin.company.companylist" %>

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
<body style="padding: 10px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="add"><a href="companyinfo.aspx">添加系列</a></span><b>您当前的位置：首页 &gt; 成员管理 &gt;
            管理工厂</b>
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
                上/下线：
            </td>
            <td>
                <asp:DropDownList ID="ddllinestatus" runat="server">
                    <asp:ListItem Value="">--请选择--</asp:ListItem>
                    <asp:ListItem Value="0">下线</asp:ListItem>
                    <asp:ListItem Value="1">上线</asp:ListItem>
                </asp:DropDownList>
            </td>
             <td>
                工厂名称：
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCompanyTitle" CssClass="input"></asp:TextBox>
            </td>
             <td>
                品牌名称：
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtBrandTitle" CssClass="input"></asp:TextBox>
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
                工厂名称
            </th>
            <th align="left">
                旗下品牌
            </th>
            <th align="center">
                是否工厂管理
            </th>
            <th align="center">
                状态
            </th>
            <th align="center">
                上/下线
            </th>
            <th align="center" width="160px">
                Email
            </th>
            <th align="center" width="160px">
                最后活动时间
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
                        <a href="companyinfo.aspx?edit=1&id=<%#Eval("id") %>&page=<%=ECommon.QueryPageIndex %>">
                            <%#Eval("title") %></a>
                    </td>
                    <td align="left">
                        <%#Eval("BrandTitle")%>
                    </td>
                    <td align="center">
                        <%#Eval("mid").ToString()=="0"?"否":"是"%>
                    </td>
                    <td align="center">
                        <%#GetStatusStrA(Eval("auditstatus"))%>
                    </td>
                    <td align="center">
                        <%#GetStatusStr(Eval("linestatus"))%>
                    </td>
                    <td align="center">
                        <%#Eval("email") %>
                    </td>
                    <td align="center">
                        <%#Eval("lastedittime")%>
                    </td>
                    <td align="right" style="padding-left: 5px;">
                        <a href="companyinfo.aspx?edit=1&id=<%#Eval("id") %>&page=<%=ECommon.QueryPageIndex %>" target="_blank">
                            修改</a><%--|<a href="companylist.aspx?edit=2&id=<%#Eval("id") %>">删除</a>--%>
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
                <asp:LinkButton ID="lbtnDel" runat="server" OnClientClick="return confirm( '确定要删除这些记录吗？ ');"
                    OnClick="lbtnDel_Click">删 除</asp:LinkButton>&nbsp;&nbsp; </span>

                     <span class="btn_bg">
                <asp:LinkButton ID="linkGo" runat="server" OnClientClick="return confirm( '确定要审核通过并且上线这些记录吗？ ');" OnClick="linkGo_Click">审核通过并且上线</asp:LinkButton>&nbsp;&nbsp; </span>
                <span class="btn_bg">
                <asp:LinkButton ID="lonkNo" runat="server" 
                OnClientClick="return confirm( '确定要下线这些记录吗？ ');" onclick="lonkNo_Click" >下线并且未通过审核</asp:LinkButton>&nbsp;&nbsp; </span>
        </div>
    </div>
    </form>
</body>
</html>
