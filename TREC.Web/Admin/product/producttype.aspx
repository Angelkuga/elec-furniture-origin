<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="producttype.aspx.cs" Inherits="TREC.Web.Admin.product.producttype" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
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
    <span class="add"><a href="../config/configinfo.aspx">添加系列</a></span><b>您当前的位置：首页 &gt; 产品管理 &gt; 产品类型</b>
</div>
<div class="spClear">
</div>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
    <tr>
    <th width="40px" align="center">选择</th>
    <th width="40px" align="center">编号</th>
    <th align="center" width="60px">所属模块</th>
    <th align="center" width="60px">配置类型</th>
    <th align="center" width="120px">配置值</th>
    <th align="left">配置名称</th>
    <th align="center" width="60px">排序</th>
    <th width="80px" align="right" style="padding-left:5px;">操作</th>
    </tr>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr>
            <td align="center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
            <td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
            <td align="center"><%# Enum.GetName(typeof(TREC.Entity.EnumConfigModule),Eval("module"))%></td>
            <td align="center"><%# ECConfig.GetTypeName(Eval("module").ToString(), Eval("type").ToString())%></td>
            <td align="center"><%#Eval("value")%></td>
            <td align="left"><a href="configinfo.aspx?edit=1&id=<%#Eval("id") %>"><%#Eval("title") %></a></td>
            <td align="center"><asp:TextBox ID="txtSort" runat="server" Text='<%#Eval("sort") %>' Width="40" style="margin-left:10px;"></asp:TextBox></td>
            <td align="right" style="padding-left:5px;"><a href="configinfo.aspx?edit=1&id=<%#Eval("id") %>">修改</a><%--|<a href="configlist.aspx?edit=2&id=<%#Eval("id") %>">删除</a>--%></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
<div class="spClear"></div>
<div style="line-height:30px;height:30px;">
    <div id="Pagination" class="right flickr">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" 
            UrlPaging="true" FirstPageText="首页" LastPageText="尾页" 
            NextPageText="下一页" PrevPageText="上一页">
        </webdiyer:AspNetPager>
    </div>
    <div class="left">
        <span class="btn_all" onclick="checkAll(this);">全选</span>
        <span class="btn_bg">
            <asp:LinkButton ID="lbtnDel" runat="server"  OnClientClick="return confirm( '确定要删除这些记录吗？ ');" OnClick="lbtnDel_Click" >删 除</asp:LinkButton>
            <asp:LinkButton ID="lbUpSort" runat="server" OnClick="lbUpSort_Click" >排 序</asp:LinkButton>&nbsp;&nbsp;          
        </span>
   </div>
</div>
</form>
</body>
</html>
