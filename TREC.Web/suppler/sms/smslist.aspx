<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="smslist.aspx.cs" Inherits="TREC.Web.Suppler.sms.smslist" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../script/supplercommon.js"></script>
    <script type="text/javascript" src="../resource/script/thickbox.js"></script>
    <link rel="Stylesheet" type="text/css" href="../resource/script/thickbox.css" />
</head>
<body style="height:auto">
<form id="form1" runat="server">
<table class="searchtable">
    <tr>
        <td align="right">分类：</td><td><asp:DropDownList ID="ddlproductcategory" runat="server"></asp:DropDownList></td>
        <td align="right">品牌：</td><td><asp:DropDownList ID="ddlbrand" runat="server"></asp:DropDownList></td>
        <td align="right">系列：</td><td><asp:DropDownList ID="ddlbrands" runat="server"></asp:DropDownList></td>
        <td align="right">名称：</td><td><asp:TextBox ID="txtProductName" runat="server" CssClass="input"></asp:TextBox></td>
        <td><span class="btn_bg">
            <asp:LinkButton ID="lkBtnSearch" runat="server" onclick="lkBtnSearch_Click" >查 找</asp:LinkButton>&nbsp;&nbsp;     
        </span>
        <span class="btn_bg">
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="lkBtnAdd_Click">添加</asp:LinkButton>
        </span>
        </td>
    </tr>
</table>
<div class="clear"></div>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
    <tr>
    <th width="40px" align="center">选择</th>
    <th width="50px" align="center">编号</th>
    <th align="center" width="100">分类名称</th>
    <th align="center" width="120">图片</th>
    <th align="left" class="l">名称</th>
    <th align="center" width="100">尺寸</th>
    <%--<th align="center" width="100">品牌</th>
    <th align="center" width="100">系列</th>--%>
    <th align="center" width="50">状态</th>
    <th align="center" width="50">上/下线</th>
    <%--<th align="center" width="100">风格</th>--%>
    <%--<th align="center" width="80">风格</th>
    <th align="center" width="80">色系</th>--%>
     <th align="center" width="50">操作</th>
    </tr>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr>
            <td align="center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
            <td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
            <td align="center"><a href="#"><%#Eval("categorytitle")%></a></td>
            <td align="center" style="height:70px; line-height:70;"><a href="productinfo.aspx?edit=1&id=<%#Eval("id") %>"><img width="105" height="60" src='<%#TREC.Entity.EnFilePath.GetProductThumbPath(Eval("id") != null ? Eval("id").ToString() : "", Eval("thumb") != null ? Eval("thumb").ToString() : "") %>' /></a></td>
            <td align="left" class="l edit"><a href="productinfo.aspx?edit=1&id=<%#Eval("id") %>"><%#Eval("HtmlProductName")%></a></td>
            <td align="center">
            <%#GetWebProduct(Eval("Id"))%>
            </td>
            <%--<td align="center"><%#Eval("brandtitle")%></td>
            <td align="center"><%#Eval("brandstitle")%></td>--%>
            <td align="center"><%#GetStatusStr(Eval("auditstatus"))%></td>
            <td align="center"><%#Eval("linestatus").ToString()=="0"?"下线":"上线"%></td>
            <%--<td align="center"><%#Eval("stylename")%></td>--%>
            <%--<td align="center"><%#Eval("stylename")%></td>
            <td align="center"><%#Eval("colorname")%></td>--%>
            <td align="center"><a href="modifyproductshop.aspx?id=<%#Eval("id") %>&KeepThis=true&TB_iframe=true&height=400&width=580" class="thickbox">编辑销售价</a> </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
<div class="listButtom">
        <%--<span class="btn_all" onclick="checkAll(this);"><a href="javascript:;">全选</a></span>--%>
        <span class="btn_bg">
            <asp:LinkButton ID="lbtnDel" runat="server"  OnClientClick="return confirm( '确定要删除这些记录吗？ ');" OnClick="lbtnDel_Click" >删 除</asp:LinkButton>&nbsp;&nbsp; 
            <asp:LinkButton ID="lkBtnAdd" runat="server" onclick="lkBtnAdd_Click">添加</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="lbtnUp" runat="server"  
            OnClientClick="return confirm( '确定把这个商品设置为上线吗？ ');" onclick="lbtnUp_Click" >上线</asp:LinkButton>&nbsp;&nbsp;   
             <asp:LinkButton ID="lbtnDon" runat="server"  
            OnClientClick="return confirm( '确定把这个商品设置为下线吗？ ');" onclick="lbtnDon_Click" >下线</asp:LinkButton>&nbsp;&nbsp;     
             
        </span>
        <div class="pages">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true"  
                    FirstPageText="首页" LastPageText="尾页"  PageSize="10"
                    NextPageText="下一页" PrevPageText="上一页"
                    onpagechanged="AspNetPager1_PageChanged">
                </webdiyer:AspNetPager>
        </div>
</div>
</form>
</body>
</html>
