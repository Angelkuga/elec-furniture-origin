<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menulist.aspx.cs" Inherits="TREC.Web.Admin.dealer.menulist" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

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
<body style="padding:10px;">
<form id="form1" runat="server">
<div class="navigation">
    <span class="add"><a href="menuinfo.aspx">添加菜单</a></span><b>您当前的位置：首页 &gt; 系统管理 &gt; 菜单管理</b>
</div>
<div class="spClear">
    <ul class="nav">
        <%foreach (TREC.Entity.EnModule m in TREC.ECommerce.ECModule.GetModuleList(""))
          { %>
            <li><a href="menulist.aspx?mid=<%=m.id %>" class="<%=UiCommon.QueryStringCur("mid", m.id.ToString(), "", "cur")%>" id="<%=m.id %>"><%=m.title %></a></li>
        <%} %>
    </ul>
</div>
<div class="spClear"></div>
    <% if (Request.QueryString["mid"] == null)
       {%>
    <div class="msgbox">
        请点击模块加载数据修改菜单!
    </div>
    <%}
       else
       { %>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
    <tr>
    <th width="40px" align="center">选择</th>
    <th width="40px" align="center">编号</th>
    <th align="left" width="200">名称</th>
    <th width="60px" align="center">模块</th>
    <th align="center">连接地址</th>
    <th width="80px" align="right" style="padding-left:5px;">操作</th>
    </tr>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr>
            <td align="center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
            <td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
            <td align="left"><%#TRECommon.HTMLUtils.GetSpacesString(int.Parse(Eval("lev").ToString())) %><a href="menuinfo.aspx?edit=1&id=<%#Eval("id") %>"><%#Eval("lev").ToString() == "1" || Eval("lev").ToString() == "" ? "<strong>" + Eval("title") + "</strong>" : Eval("title")%></a></td>
            <td align="center"><%#Eval("module")%></td>
            <td align="center"><%#Eval("url")%></td>
            <td align="right" style="padding-left:5px;"><a href="menuinfo.aspx?edit=1&id=<%#Eval("id") %>">修改</a>|<a href="menuinfo.aspx?edit=2&id=<%#Eval("id") %>">删除</a></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>

<div class="spClear"></div>
<div style="line-height:30px;height:30px;">
    <div id="Pagination" class="right flickr">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" 
            NextPageText="下一页" PrevPageText="上一页">
        </webdiyer:AspNetPager>
    </div>
    <div class="left">
        <span class="btn_all" onclick="checkAll(this);">全选</span>
        <span class="btn_bg">
            <asp:LinkButton ID="lbtnDel" runat="server"  OnClientClick="return confirm( '确定要删除这些记录吗？ ');" OnClick="lbtnDel_Click" >删 除</asp:LinkButton>&nbsp;&nbsp;     
        </span>
   </div>
</div>

<%} %>
</form>
</body>
</html>
