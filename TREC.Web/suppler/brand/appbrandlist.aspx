<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="appbrandlist.aspx.cs" Inherits="TREC.Web.Suppler.brand.appbrandlist" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" language="javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.poshytip.min.js"></script>
    <script type="text/javascript" src="../script/supplercommon.js"></script>
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
            $("tr[isEdit='False']").poshytip();
        })
    </script>
</head>
<body style="height:auto">
<form id="form1" runat="server">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
    <tr>
    <th width="40px" align="center">选择</th>
    <th width="40px" align="center">编号</th>
    <th align="left" class="l" width="160">品牌名</th>
    <th align="left" class="l"><%=memberInfo.type == (int)TREC.Entity.EnumMemberType.工厂企业 ? "经销商" : "品牌工厂"%></th>
<%--    <th width="120px" align="center">类型</th>--%>
    <th align="center" width="80px">审核状态</th>
    <th width="100" align="center">
                上/下线
            </th>
    <th align="center" width="160px">申请时间</th>
     
    </tr>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr isEdit="<%#GetEdit(Eval("brandid").ToString()) %>" title='<%#!GetEdit(Eval("brandid").ToString())?Eval("brandtitle").ToString()+"&nbsp;&nbsp;不是您创建的，可查看，不可编辑删除":""%>'>
            <td align="center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" Enabled='<%#GetEdit(Eval("brandid").ToString()) %>' /></td>
            <td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("brandid")%>'></asp:Label></td>
            <td align="left" class="l edit"><a href="<%#GetEdit(Eval("brandid").ToString())?"brandinfo.aspx?edit=1&id="+Eval("brandid"):"javascript:;"%>"><%#Eval("brandtitle") %></a></td>
            <td align="left" class="l edit"><%#memberInfo.type == (int)TREC.Entity.EnumMemberType.工厂企业 ? Eval("dealetitle") : Eval("companytitle") %></td>
            <%--<td align="center"><a href="javascript:;"><%#Enum.GetName(typeof(TREC.Entity.EnumAppBrandType), Eval("apptype"))%></a></td>--%>
            <td align="center"><%#GetStatusStrA(Eval("Brandid"))%></td>
            <td align="center">
                        <%#GetStatusStr(Eval("Brandid"))%>
                    </td>
            <td align="center"><%#Eval("apptime")%></td>

            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
<div class="listButtom">
        <span class="btn_bg" onclick="checkAll(this);"><a href="javascript:;">全选</a></span>
        <span class="btn_bg">
            <asp:LinkButton ID="lbtnDel" runat="server"  OnClientClick="return confirm( '确定要删除这些记录吗？ ');" OnClick="lbtnDel_Click" >删 除</asp:LinkButton>&nbsp;&nbsp;     
        </span>
        <span class="btn_bg">
                    <asp:LinkButton ID="lbtnUp" runat="server" OnClientClick="return confirm( '确定把这个品牌设置为上线吗？ ');"
                        OnClick="lbtnUp_Click">上线</asp:LinkButton>&nbsp;&nbsp; </span><span class="btn_bg">
                            <asp:LinkButton ID="lbtnDon" runat="server" OnClientClick="return confirm( '确定把这个品牌设置为下线吗？ ');"
                                OnClick="lbtnDon_Click">下线</asp:LinkButton>&nbsp;&nbsp;
        </span>
        <div class="pages">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" 
                    NextPageText="下一页" PrevPageText="上一页">
                </webdiyer:AspNetPager>
        </div>
</div>
</form>
</body>
</html>
