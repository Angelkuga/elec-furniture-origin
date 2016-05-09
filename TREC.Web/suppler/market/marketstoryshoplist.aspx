<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Member.Master"  CodeBehind="marketstoryshoplist.aspx.cs" Inherits="TREC.Web.Suppler.market.marketstoryshoplist" %>
<%@ Import Namespace="TREC.ECommerce" %><%@ Import Namespace="TREC.Entity" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--<link rel="stylesheet" type="text/css" href="../css/style.css" />--%>
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
			    if ($(".msgtable").find("input[type=checkbox]:checked").length==0) {
			        alert("请选择店铺");
			        return false;
			    }
//			    $(".msgtable").find("input[type=checkbox]:checked").each(
//                    function () {
//                        alert($(this).parent().parent().parent().find("td:eq(2)").find("select option:selected").text());
//                        //                        if ($(this).parent().parent().parent().find("td:eq(3)") > 0) {
//                        //                            alert($(this).parent().parent().parent().find("td:eq(3)"));
//                        //                        }
//                    }
//                    );
			    //                    return false;
			    var isPss = false;
			   
			        $(".msgtable").find("input[type=checkbox]:checked").each(
                    function () {
                        if ($(this).parent().parent().parent().find("td:eq(1)").find("input").val() == "") {
                            $(this).parent().parent().parent().find("td:eq(1)").find("input").focus();
                            alert("编号不能为空！");
                            isPss = false;
                            return false;
                        } else {
                            isPss = true;
                           
                        }
                        if ($(this).parent().parent().parent().find("td:eq(2)").find("select option:selected").length == 0) {
                            alert("请选择一个品牌");
                            $(this).parent().parent().parent().find("td:eq(2)").find("select").focus();
                            isPss = false;
                            return false;
                        } else {
                            isPss = true;
                           // return;
                        }
                        if ($(this).parent().parent().parent().find("td:eq(3)").find("select option:selected").val() =="") {
                            alert("请选择楼层");
                            $(this).parent().parent().parent().find("td:eq(3)").find("select").focus();
                            isPss = false;
                            return false;
                        } else {
                            isPss = true;
                           // return;
                        }
                    });
                    return isPss;
                    if (isPss) {
                        if (confirm("你确定要更新信息吗？")) {
                            return isPss;
                        } else {
                            return false;
                        }
                    } else {
                    return false;
                    }
                  

}
function showDelBox(shopid) {
    if (confirm("确定要删除吗?")) {
        $.ajax({
            url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxproduct.ashx',
            data: 'type=delmaketshop&v=' + shopid + "&ram=" + Math.random(),
            dataType: 'html',
            success: function (data) {
                if (data == "ok") {
                    alert("删除成功!");
                    // window.location.href = "groupproductlist.aspx";
                    window.location.reload();
                } else {
                    alert("删除失败！");
                }


            }
        });
    }
}
    </script>
    <style type="text/css">
        .mslist{float:left; border-bottom:1px solid #cfcfcf; width:99%; margin:10px 0px;}
        .mslist li{float:left; padding:0px 5px;height:24px;}
        .mslist li a{ background:#f4f4f4;  display:block; padding:0px 8px; height:24px; line-height:24px;color:#000;}
        .mslist li a.cur,.mslist li a:hover{background:#f60;color:#fff;}
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--<ul class="mslist">
    <li><a href="marketstoryshoplist.aspx?sid=-1"  class="<%=UiCommon.QueryStringCur("sid", "-1", "", "cur")%>">暂未设置楼层店铺</a></li>
   <%-- <%foreach (EnMarketStorey ms in mslist)
      { %>
        <li><a href="marketstoryshoplist.aspx?sid=<%=ms.id %>" class="<%=UiCommon.QueryStringCur("sid", ms.id.ToString(), "", "cur")%>"><%=ms.title %></a></li>
    <%} %>
</ul--%>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable" style="float:left">
    <tr>
    <th width="40px" align="center">选择</th>
    <th width="40px" align="center">编号</th>
    <th align="left">&nbsp;&nbsp;品牌名称    
    </th>
    <th align="left" width="160px">&nbsp;&nbsp;所在楼层</th>
     <th align="left" width="160px">&nbsp;&nbsp;所属场馆</th>
    <th align="left" width="160px">&nbsp;&nbsp;操作</th>
    </tr>
    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_OnItemDataBound">
        <ItemTemplate>
            <tr>
            <td align="center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
            <td align="center">
            
            <asp:TextBox ID="txtposition" Width="100" Text='<%#Eval("position") %>' MaxLength="13" runat="server"></asp:TextBox>
            </td>
            <td align="left" class="edit l">      
            <asp:DropDownList ID="ddlBrandList" runat="server"></asp:DropDownList>
            <asp:Label ID="lb_shopid" runat="server" Text='<%#Eval("Id")%>' style="display:none"></asp:Label>
             <asp:Label ID="lb_shoptitle" runat="server" Text='<%#Eval("title")%>' style="display:none"></asp:Label>
            </td>
          
            <td align="left" class="l"><asp:DropDownList ID="ddlms" runat="server"></asp:DropDownList></td>
     <td><%#getpavTitle(Eval("PavilionId").ToString())%></td>
            <td>
              
             <asp:DropDownList ID="ddlLinestatus" runat="server">             
            </asp:DropDownList>
           <%-- <%if (sid != -1)
              { %>
            <a class="myhander" onclick="showDelBox(<%#Eval("id")%>);"><img src="../Images/del.png" width="16" height="16" border="0" /></a>
            <%} %>--%>
            </td>
           
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
  <div class="pages">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" 
                    NextPageText="下一页" PrevPageText="上一页" >
                </webdiyer:AspNetPager>
        </div>
<div class="btmenu">
<p>
  <span class="btn_bg"><a href="javascript:;" onclick="checkAllShop(this,'msgtable');" class="bome">全选</a><asp:LinkButton ID="lbtnUpStorey" CssClass="bome" runat="server"  OnClientClick="return checkSelect();" OnClick="lbtnUpStorey_Click" >确认</asp:LinkButton> </span>
</p>
</div>
<%--<div class="btmenu">
<table>
<tr><td>商家店铺编号</td><td><input type="text" size="34" name="shopPosition"  id="shopPosition"  runat="server"/></td>
 <td>商家店铺编号</td><td><input type="text" size="34" name="shopPosition"  id="Text1"  runat="server"/></td></tr>
</table>
</div>--%>
</asp:Content>

