<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Member.Master"  CodeBehind="setmarketstoryshop.aspx.cs" Inherits="TREC.Web.Suppler.market.setmarketstoryshop" %>
<%@ Import Namespace="TREC.ECommerce" %><%@ Import Namespace="TREC.Entity" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
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
			})
			//select all
			function checkAllShop(th, t_class) {
			    if ($("." + t_class).find("input[type=checkbox]:checked").length > 0) {
			        $("." + t_class).find("input[type=checkbox]").attr('checked', false);
			        $(th).text("全选")
			    } else {
			        $("." + t_class).find("input[type=checkbox]").attr('checked', "checked");
			        $(th).text("取消")
			    }
			}

			function checkSelect() {
			    if ($(".msgtable").find("input[type=checkbox]:checked").length == 0) {
			        alert("请选择店铺");
			        return false;
			    }
			    if (confirm("你确定要更新级别吗？")) {
			        return true;
			    } else {
			        return false;
			    }
			}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
    <tr>
    <th width="40px" align="center">选择</th>
    <th width="40px" align="center">编号</th>
    <th align="left">&nbsp;&nbsp;品牌名称</th>
    <th align="left">&nbsp;&nbsp;所在楼层</th>
    <th width="80px" align="center">置顶</th>
    <th width="80px" align="center">推荐</th>
    <th align="left" width="80px">&nbsp;&nbsp;级别</th>
    </tr>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr>
            <td align="center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
            <td align="center">
            <asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>' style=" display:none"></asp:Label>
            <%#Eval("position") %>
            </td>
            <td align="left" class="edit l">
              <%# Eval("brandtitlelist") == null ? Eval("shoptitle") : Eval("brandtitlelist")%>
            </td>
            <td align="center"><%#Eval("storeytitle")%></td>
            <td align="center"><a href="setmarketstoryshop.aspx?edit=3&id=<%#Eval("Id")%>&value=<%#Eval("istop").ToString()=="0"?"1":"0" %>&page=<%=ECommon.QueryPageIndex %>"><img src="../images/<%#Eval("istop") %>_421.png" /></a></td>
           
            <td align="center"><a href="setmarketstoryshop.aspx?edit=4&id=<%#Eval("Id")%>&value=<%#Eval("isrecommend").ToString()=="0"?"1":"0" %>&page=<%=ECommon.QueryPageIndex %>"><img src="../images/<%#Eval("isrecommend") %>_835.png" /></a></td>
            <td align="center" class="l"><asp:TextBox ID="txtlev" runat="server" Text='<%#Eval("lev") %>' CssClass="input" Width="40"></asp:TextBox></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
  <div class="pages">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" 
                    NextPageText="下一页" PrevPageText="上一页">
                </webdiyer:AspNetPager>
        </div>
<div class="btmenu" >  
<p>
        <span class="btn_bg"><a class="bome" href="javascript:;"  onclick="checkAllShop(this,'msgtable');">全选</a>
            <asp:LinkButton ID="lbtnUpLev" runat="server" CssClass="bome"  OnClientClick="return checkSelect();" OnClick="lbtnUpLev_Click" >更新级别</asp:LinkButton>&nbsp;&nbsp; 
        </span>   
        </p>         
</div>
</asp:Content>