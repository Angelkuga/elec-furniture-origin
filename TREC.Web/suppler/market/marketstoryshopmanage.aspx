<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="marketstoryshopmanage.aspx.cs" Inherits="TREC.Web.Suppler.market.marketstoryshopmanage" %>
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
<div class="maintitle"><h1><u>商家管理</u></h1></div>
<div class="sobox"><table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td align="right" style="width:250px;">楼层&nbsp;<asp:DropDownList ID="ddlmarketstory" runat="server"></asp:DropDownList></td>
    <td style="width:250px;"><div style="padding-left:70px;"> 店铺编号&nbsp;<input type="text" size="34"  style=" width:100px;height:18px;" name="marketshopposition" value=""  id="marketshopposition" class="input"  runat="server"/></div></td>
    <td style="width:250px;"><div style="padding-left:80px;">品牌&nbsp;<asp:DropDownList ID="ddlbrand" runat="server"></asp:DropDownList></div> </td>
    </tr>
    <tr>
    <td align="right">状态
   <select id="Status" name="Status">
      <option value="">请选择</option>
      <option value="0" <%if(linestatus==0){ %> selected<%} %>>已下线</option>
      <option value="1"  <%if(linestatus==1){ %> selected<%} %>>申请中</option>
      <option value="2"  <%if(linestatus==2){ %> selected<%} %>>已上线</option>
    </select></td>
     <td>
     <div style="padding-left:100px;">
     来源
   <select id="source" name="source">
      <option value="">请选择</option>
      <option value="1" <%if(source==1){ %> selected<%} %>>店铺</option>
      <option value="2" <%if(source==2){ %> selected<%} %>>卖场</option>      
    </select>
    </div>
    </td>
    <td >
     <div style="padding-left:80px;">
      场馆 <asp:DropDownList ID="drop_Pavilion" runat="server">
        </asp:DropDownList>  
        </div>
    
    </td>
    </tr>
    <tr><td colspan="3" align="center" style="padding-top:20px;"><asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="搜索" CssClass="btnso" /></td> </tr>
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
    <th width="40px" align="center">选择</th>
    <th width="40px" align="center">编号</th>
    <th align="left">&nbsp;&nbsp;品牌名称</th>
    <th align="left" width="160px">&nbsp;&nbsp;所在楼层</th>    

    <th align="left"">&nbsp;&nbsp;上传日期</th>
    <th align="left"">&nbsp;&nbsp;最后修改日期</th>
    <th align="left"">&nbsp;&nbsp;状态</th>
    <th align="left"">&nbsp;&nbsp;场馆</th>
    <th align="left"">&nbsp;&nbsp;来源</th>
    <th align="left">&nbsp;&nbsp;操作</th>
    </tr>
    <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_OnItemDataBound">
        <ItemTemplate>
            <tr>
            <td align="center"><asp:CheckBox ID="cb_id"  CssClass="checkall" runat="server" /></td>
            <asp:Label ID="lb_id" runat="server" style=" display:none;" Text='<%#Eval("shopid")%>'></asp:Label>
                <asp:Label ID="lb_mkssId" runat="server" style=" display:none;" Text='<%#Eval("id")%>'></asp:Label>
             <td align="left"><asp:TextBox ID="txtposition" Width="100" Text='<%#Eval("position") %>' MaxLength="13" runat="server"></asp:TextBox></td>
            <td align="left" class="edit l"><%--<a href="shopinfo.aspx?edit=1&id=<%#Eval("id") %>">--%>            
              <%# Eval("brandtitlelist") == null ? Eval("shoptitle") : Eval("brandtitlelist")%>
              <%--<%if(<%# Eval("brandtitlelist")%>==null{}) %>--%>
            </td>
            <td align="left" class="l">
            <%--<%# Eval("storeytitle")%>--%>
            <asp:DropDownList ID="ddlms" runat="server"></asp:DropDownList>
            </td>   
             <%--<td><%#Eval("createtime")%></td>       --%>
            <td><%#Eval("createtime").ToString() == "0001-1-1" ? "" : Eval("createtime", "{0:d}")%></td>   
            <td><%#Eval("lastedittime","{0:d}")%></td>   
            <td align="left" class="l">           
            <asp:DropDownList ID="ddlLinestatus" runat="server">             
            </asp:DropDownList>
            </td>  
             <td><%#getpavTitle(Eval("PavilionId").ToString())%></td>            
            <td><%# Eval("source") == null ? "未知" : Eval("source").ToString()=="1" ? "店铺":"卖场"%></td>
            <td>          
            <a class="myhander" onclick="showDelBox(<%#Eval("shopid")%>);"><img src="../Images/del.png" width="16" height="16" border="0" /></a>
                     </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
  <div class="pages">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" 
                    NextPageText="下一页" PrevPageText="上一页" PageSize="40">
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

