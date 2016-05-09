<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="memberlist.aspx.cs" Inherits="TREC.Web.Admin.member.memberlist" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
<body style="padding: 10px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="add"><a href="memberinfo.aspx">添加系列</a></span><b>您当前的位置：首页 &gt; 成员管理 &gt;
            登陆账号管理</b>
    </div>
    <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="80" align="center">
                会员类型：
            </td>
            <td width="100">
                <asp:DropDownList ID="ddlmembertype" runat="server">
                </asp:DropDownList>
            </td>
            <td width="80" align="left">
                会员别级：
            </td>
            <td>
                <asp:DropDownList ID="ddlmembergroup" runat="server">
                </asp:DropDownList>
            </td>
            <td width="50" align="right">
                关健字：
            </td>
            <td width="150">
                <asp:TextBox ID="txtUserName" runat="server" class="keyword"></asp:TextBox>
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
                会员类型
            </th>
            <th align="center" width="160px">
                会员级别
            </th>
            <th align="center" width="160px">
                注册时间
            </th>
            <th align="center" width="160px">
                到期时间
            </th>
            <th align="center">
                登陆名
            </th>
            <th align="center" width="160px">
                关联企业
            </th>
            <th align="center" width="160px">
                Email
            </th>
            <%--<th align="center" width="160px">最后活动时间</th>--%>
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
                        <%#Enum.GetName(typeof(TREC.Entity.EnumMemberType),Eval("type")) %>
                    </td>
                    <td align="center">
                        <%#Eval("groupid") %>
                    </td>
                     <td align="center">
                        <%#Convert.ToDateTime( Eval("regtime")).ToString("yyyy-MM-dd HH:mm:ss")%>
                    </td>
                    <td align="center">
                        <%#DateTime.Parse(Eval("RegEndTime").ToString()).Year>2000?Eval("RegEndTime").ToString():"暂未充值"%>
                    </td>
                    <td align="center">
                        <a href="memberinfo.aspx?edit=1&id=<%#Eval("id") %>">
                            <%#Eval("username") %></a>
                    </td>
                    <td align="center">
                        <%#CompanyOrDealerTitle(Eval("type"), Eval("id"))%>
                    </td>
                    <td align="center">
                        <%#Eval("email") %>
                    </td>
                    <%--<td align="center"><%#Eval("lastedittime")%></td>--%>
                    <td align="right" style="padding-left: 5px;">
                        <a href="memberinfo.aspx?edit=1&id=<%#Eval("id") %>">修改</a><%--|<a href="memberlist.aspx?edit=2&id=<%#Eval("id") %>">删除</a>--%>
                        <script>
                            if("<%#Eval("type") %>"=="101" || "<%#Eval("type") %>"=="102")
                            {
                                document.write("<a href=\"../product/ImportProduct.aspx?id=<%#Eval("id") %>\">导入产品</a>");
                            }
                        </script>
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
        </div>
    </div>
    </form>
</body>
</html>
