<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="apppromotionbrandlist.aspx.cs" Inherits="TREC.Web.Admin.promotion.apppromotionbrandlist" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href=<%="\""+TREC.ECommerce.ECommon.WebAdminResourceUrl%>/altdialog/skins/default.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/altdialog/artDialog.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/altdialog/plugins/iframeTools.js"></script>
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
    <span class="add"><a href="apppromotionbrandinfo.aspx">添加信息</a></span><b>您当前的位置：首页 &gt; 促销活动 &gt; 促销活动信息</b>
</div>
<div class="spClear"></div>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
    <tr>
    <th width="40px" align="center">选择</th>
    <th width="40px" align="center">编号</th>
    <th width="60px" align="center">品牌ID</th>
    <th width="60px" align="center">品牌索引</th>
    <th align="left">品牌名称</th>
    <th width="60px" align="center">福家网</th>
    <th width="60px" align="center">申请人数</th>
    <th width="80px" align="right" style="padding-left:5px;">操作</th>
    </tr>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr>
            <td align="center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
            <td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
            <td align="center"><%#Eval("bid")%></td>
            <td align="center"><%#Eval("letter") %></td>
            <td align="left"><a href="apppromotionbrandinfo.aspx?edit=1&id=<%#Eval("id") %>"><%#Eval("title").ToString()%></a></td>
            <td align="center"><%#Eval("fordio").ToString()== "1" ? "<font style='color:#f60'>是</font>" : "否"%></td>
            <td align="center"><%#Eval("appcount")%></td>
            <td align="right" style="padding-left:5px;"><a href="apppromotionbrandinfo.aspx?edit=1&id=<%#Eval("id") %>">修改</a>|<a href="apppromotionbrandlist.aspx?edit=2&id=<%#Eval("id") %>">删除</a></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
<div class="spClear"></div>
<div style="line-height:30px;height:30px;">
    <div id="Pagination" class="right flickr">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="20" AlwaysShow="true" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" 
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
</form>
</body>
</html>
