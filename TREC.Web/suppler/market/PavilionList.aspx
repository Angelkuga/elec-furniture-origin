<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="PavilionList.aspx.cs" Inherits="TREC.Web.Suppler.market.PavilionList" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
    <tr>
     <th width="40px" align="center">选择</th>
    <th width="40px" align="center">编号</th>
    <th align="left">&nbsp;&nbsp;卖场名称</th>
    <th align="center" width="80">&nbsp;&nbsp;操作</th>
    </tr>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr>
            <td align="center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
            <td align="center" style="height:34px;"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
            <td align="left" class="edit l"><a href="marketstoryinfo.aspx?edit=1&id=<%#Eval("id") %>"><%#Eval("title") %></a></td>
            <td align="left" class="edit l">
            <a href="PavilionAdd.aspx?id=<%#Eval("id") %>">编辑</a>     
            </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
<div class="listButtom">
  <span class="btn_all" onclick="checkAll(this);"><a href="javascript:;">全选</a></span>
        <span class="btn_bg">
            <asp:LinkButton ID="lbtnDel" runat="server"  OnClientClick="return confirm( '确定要删除这些记录吗？ ');" OnClick="lbtnDel_Click" >删 除</asp:LinkButton>&nbsp;&nbsp;     
        </span>
        <div class="pages">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" 
                    NextPageText="下一页" PrevPageText="上一页">
                </webdiyer:AspNetPager>
        </div>
</div>
</asp:Content>
