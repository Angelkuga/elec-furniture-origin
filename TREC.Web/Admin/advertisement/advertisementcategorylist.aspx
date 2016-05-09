<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="advertisementcategorylist.aspx.cs" Inherits="TREC.Web.Admin.advertisement.advertisementcategorylist" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>广告位管理</title>
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
    <span class="add"><a href="advertisementcategoryinfo.aspx">添加广告位</a></span><b>您当前的位置：首页 &gt; 营销互动 &gt; 广告位管理</b>
</div>
<div class="spClear"></div>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
    <tr>
    <th width="40px" align="center">选择</th>
    <th width="40px" align="center">编号</th>
    <th align="center" width="120px">上级分类</th>
    <th align="left">广告位名称</th>
    <th align="center" width="80px">管理广告</th>
    <th align="center" width="80px">调用代码</th>
    <th align="center" width="80px">广告类型</th>
    <th align="center" width="80px">所属模块</th>
    <th align="center" width="120px">开始时间</th>
    <th align="center" width="120px">结束时间</th>
    <th align="center" width="120px">标识位置(预览)</th>
    <th width="80px" align="right" style="padding-left:5px;">操作</th>
    </tr>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr>
            <td align="center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
            <td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
            <td align="center"><%#Eval("parentid")%></td>
            <td align="left"><%#Eval("parentid").ToString() == "0" ? "<strong>" : ""%><a href="advertisementcategoryinfo.aspx?edit=1&id=<%#Eval("id") %>"><%#Eval("parentid").ToString() == "0" ? "" : "|----"%><%#Eval("title") %></a><%#Eval("parentid").ToString() == "0" ? "</strong>" : ""%></td>
            <td align="center"><a href="advertisementinfo.aspx?cid=<%#Eval("id") %>">0 条广告</a></td>
            <td align="center"><a href="javascript:GetCodeDialg(<%#Eval("id") %>);">点击查看</a></td>
            <td align="center"><%#Eval("adtype")%></td>
            <td align="center"><%#Eval("moduleid")%></td>
            <td align="center"><%#Eval("starttime")%></td>
            <td align="center"><%#Eval("endtime")%></td>
            <td align="center"><%#Eval("img")%></td>
            <td align="right" style="padding-left:5px;"><a href="advertisementcategoryinfo.aspx?edit=1&id=<%#Eval("id") %>">修改</a>|<a href="advertisementcategoryinfo.aspx?edit=2&id=<%#Eval("id") %>">删除</a></td>
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
<div class="codeDialg" style="width:300px; height:30px; position:absolute; top:50%; left:50%; margin:-15px 0px 0px -150px; display:none;">
    <textarea class="textarea" id="getcode" rows="2" style="width:450px"></textarea>
</div>
<script type="text/javascript">
    function GetCodeDialg(i) {
        $(".codeDialg").show();
        $("#getcode").text("<script type=\"text/javascript\" src=\"http://192.168.1.115:16/ajaxtools/ajaxashow.ashx?id=" + i + "\"><\/script>");
    }
</script>
</form>
</body>
</html>
