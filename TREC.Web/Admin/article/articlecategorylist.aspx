<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="articlecategorylist.aspx.cs" Inherits="TREC.Web.Admin.article.articlecategorylist" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理分类</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../script/function.js"></script>
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
    <span class="add"><a href="articlecategoryinfo.aspx">添加分类</a></span><b>您当前的位置：首页 &gt; 文档信息 &gt; 文档分类</b>
</div>
<div class="spClear"></div>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="display:none">
      <tr>
        <td width="50" align="center">请选择：</td>
        <td>
            <asp:DropDownList ID="ddlcategory" runat="server" CssClass="select"></asp:DropDownList>&nbsp;
            <asp:DropDownList ID="ddlattribute" runat="server" CssClass="select"></asp:DropDownList>
        </td>
        <td width="50" align="right">关健字：</td>
        <td width="150"><asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword"></asp:TextBox></td>
        <td width="60" align="center"><asp:Button ID="btnSelect" runat="server" Text="查询" 
                CssClass="submit" onclick="btnSelect_Click" /></td>
        </tr>
    </table>
<div class="spClear"></div>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
    <tr>
    <th width="40px" align="center">选择</th>
    <th width="40px" align="center">编号</th>
    <th align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;分类名称</th>
    <th align="center" width="240px">操作</th>
    <th align="center" width="160px">最后修改</th>
    <th width="80px" align="right" style="padding-left:5px;">修改/删除</th>
    </tr>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr>
            <td align="center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
            <td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
            <td align="left">
                <%#TRECommon.HTMLUtils.GetSpacesString(TRECommon.TypeConverter.StrToInt(Eval("lev").ToString())*2) %>
                <img align="absmiddle" src="../images/folder_open.gif"><img align="absmiddle" src="../images/t.gif">
                <a href="articlecategoryinfo.aspx?edit=1&id=<%#Eval("id") %>"><%#Eval("title")%></a>
            </td>
            <td align="center">
                <a href="articlecategorylist.aspx?edit=3&id=<%#Eval("id") %>">上移</a>&nbsp;&nbsp;|&nbsp;&nbsp;
                <a href="articlelist.aspx?cid=<%#Eval("id")%>">管理文档</a>&nbsp;&nbsp;|&nbsp;&nbsp;
                <a href="articlecategoryinfo.aspx?pid=<%#Eval("id")%>">添加子分类</a>
            </td>
            <td align="center"><%#Eval("edittime")%></td>
            <td align="right" style="padding-left:5px;"><a href="articlecategoryinfo.aspx?edit=1&id=<%#Eval("id") %>">修改</a>|<a href="articlecategorylist.aspx?edit=2&id=<%#Eval("id") %>" onclick="return confirm( '确定要删除这条记录吗？ ');">删除</a></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
<div class="spClear"></div>
<div style="line-height:30px;height:30px;">
    <div id="Pagination" class="right flickr">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" PageSize="50"
            NextPageText="下一页" PrevPageText="上一页">
        </webdiyer:AspNetPager>
    </div>
    <div class="left">
        <span class="btn_all" onclick="checkAll(this);">全选</span>
        <span class="btn_bg">
            <asp:LinkButton ID="lbtnDel" runat="server"  OnClientClick="return confirm( '确定要删除这些记录吗？ ');" OnClick="lbtnDel_Click" >删 除</asp:LinkButton>
        </span>
   </div>
</div>
</form>
</body>
</html>
