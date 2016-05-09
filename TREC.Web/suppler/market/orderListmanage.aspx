<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="orderListmanage.aspx.cs" Inherits="TREC.Web.Suppler.market.orderListmanage" %>
<%@ Import Namespace="TREC.ECommerce" %><%@ Import Namespace="TREC.Entity" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--<link rel="stylesheet" type="text/css" href="../css/style.css" />--%>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
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
            if (confirm("你确定要更新信息吗？")) {
                return true;
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
        .style1
        {
            height: 33px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maintitle"><h1><u>定单查看</u></h1></div>
<div class="sobox"><table width="100%" border="0" cellpadding="0" cellspacing="0"  style="margin-top:10px;">
  <tr>
    <td align="right" style="width:200px;">查询条件&nbsp;<asp:DropDownList ID="drop_search" runat="server">
        <asp:ListItem Selected="True" Value="0">全部</asp:ListItem>
        <asp:ListItem Value="Result,0">未支付</asp:ListItem>
        <asp:ListItem Value="Result,1">定金支付完成</asp:ListItem>
        <asp:ListItem Value="Result,2">全款支付完成</asp:ListItem>
        <asp:ListItem Value="Result,3">余款支付完成</asp:ListItem>
        <asp:ListItem Value="Deliverystatus,1">备货中</asp:ListItem>
        <asp:ListItem Value="Deliverystatus,2">送货中</asp:ListItem>
        <asp:ListItem Value="Deliverystatus,3">已完成</asp:ListItem>
        <asp:ListItem Value="OrderDel,1">取消定单</asp:ListItem>
        </asp:DropDownList></td>
   <td align="left"> <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="搜索" CssClass="btnso" /></td>
    </tr>

</table>
</div>
<ul class="mslist">
   <%-- <li><a href="marketstoryshoplist.aspx?sid=-1"  class="<%=UiCommon.QueryStringCur("sid", "-1", "", "cur")%>">暂未设置楼层店铺</a></li>--%>
   <%-- <%foreach (EnMarketStorey ms in mslist)
      { %>
        <li><a href="marketstoryshoplist.aspx?sid=<%=ms.id %>" class="<%=UiCommon.QueryStringCur("sid", ms.id.ToString(), "", "cur")%>"><%=ms.title %></a></li>
    <%} %>--%>
</ul>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable" style="float:left">
    <tr>
    <th width="40px" align="center">编号</th>
    <th width="240px" align="center">定单号</th>
    
    <th align="left" width="80px">提交金额</th>  
     <th align="left"" width="120px">支付状态</th>  
      <th align="left"" width="120px">是否查看</th>  
    <th align="left">提交时间</th>
   
   <th align="left"">查看</th>
    </tr>
    <asp:Repeater ID="rptList" runat="server" >
        <ItemTemplate>
            <tr>
            <td align="center"><%#Eval("Id")%></td>
           
               
             <td align="left"><%#Eval("OrderNumber") %></td>

              <td><%#Eval("payprice")%></td> 
                <td><%#getpaystatic(Eval("result").ToString())%></td>  
                     
             
                <td align="left"><%#isRead(Eval("OrderNumber").ToString())%></td>
              <td><%#Eval("CreateTime", "{0:yyyy-MM-dd HH:mm}")%></td>      
            <td><a href="OrderInforpabe.aspx?OrderNumber=<%#Eval("OrderNumber")%>">查看</a></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
  <div class="pages">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" 
                    UrlPaging="true" FirstPageText="首页" LastPageText="尾页" 
                    NextPageText="下一页" PrevPageText="上一页" 
                    onpagechanging="AspNetPager1_PageChanging">
                </webdiyer:AspNetPager>
        </div>
<div class="btmenu">
<p>
  
</p>
</div>
<%--<div class="btmenu">
<table>
<tr><td>商家店铺编号</td><td><input type="text" size="34" name="shopPosition"  id="shopPosition"  runat="server"/></td>
 <td>商家店铺编号</td><td><input type="text" size="34" name="shopPosition"  id="Text1"  runat="server"/></td></tr>
</table>
</div>--%>
</asp:Content>

