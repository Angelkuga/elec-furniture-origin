<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantsList.aspx.cs"
    Inherits="TREC.Web.Admin.information.MerchantsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>招商列表</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
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
        <span class="add"><a href="SelectMerchantsMember.aspx">添加招商</a></span><b>您当前的位置：首页 &gt;
            促销信息管理 &gt; 招商列表</b>
    </div>
    <div class="spClear">
    </div>
    <table>
        <tr>
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
                名称：
            </td>
            <td>
                <asp:TextBox ID="txttitle" runat="server" CssClass="input"></asp:TextBox>
            </td>
            <td>
                <span class="btn_bg">
                    <asp:LinkButton ID="lkBtnSearch" runat="server" OnClick="lkBtnSearch_Click">查 找</asp:LinkButton>&nbsp;&nbsp;
                </span>
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
            <th align="center" width="200">
                标题
            </th>
            <th align="left">
                状态 	
            </th>
            <th align="center" width="80">
                上/下线 
            </th>
            <th align="center" width="80">
                留言数量
            </th>
            <th align="center" width="300px">
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
                    <td align="center">
                        <a href="AddMerchantsInfo.aspx?edit=1&id=<%#Eval("id") %>&cid=<%#Eval("cid") %>">
                            <%#Eval("title")%></a>
                    </td>
                    <td align="left">
                         <%#GetStatusStrA(Eval("auditstatus"))%>
                    </td>
                    <td align="center">
                       <%#GetStatusStr(Eval("linestatus"))%>
                    </td>
                    <td align="center">
                        <%#Eval("Membercount")%>
                    </td>
                    <td align="center">
                        <%#Eval("Lastedittime")%>
                    </td>
                    <td align="right" style="padding-left: 5px;">
                        <a href="AddMerchantsInfo.aspx?edit=1&id=<%#Eval("id") %>&cid=<%#Eval("cid") %>">修改</a><%--|<a href="productlist.aspx?edit=2&id=<%#Eval("id") %>" onclick="confirm(是否确认删除该产品)">删除</a>--%>
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
            <span class="btn_all" onclick="checkAll(this);">全选</span> <span class="btn_bg"><span
                class="btn_bg">
                <asp:LinkButton ID="lbtnDel" runat="server" OnClientClick="return confirm( '确定要删除这些记录吗？ ');"
                    OnClick="lbtnDel_Click">删 除</asp:LinkButton>&nbsp;&nbsp; </span>
        </div>
    </div>
    </form>
</body>
</html>
