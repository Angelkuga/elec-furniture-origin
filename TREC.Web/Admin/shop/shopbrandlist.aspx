<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shopbrandlist.aspx.cs" Inherits="TREC.Web.Admin.shop.shopbrandlist" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href=<%="\""+TREC.ECommerce.ECommon.WebAdminResourceUrl%>/altdialog/skins/default.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/altdialog/artDialog.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/altdialog/plugins/iframeTools.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.getcss.js"></script>
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
        });
		function getDialog(j) {
			    art.dialog.open('<%=ECommon.WebAdminUrl %>/common/getbrand.aspx?type=upshopbrandid&value='+j,
                {
                    id: 'memdiv' + j,
                    width: 800,
                    height: 400,
                    title: '选择-<%#Eval("title") %>-品牌',
                    ok: function () {
                        var iframe = this.iframe.contentWindow;
                        if (!iframe.document.body) {
                            alert('正在加载……')
                            return false;
                        };
                        $.ajax({
                            url: '<%=TREC.ECommerce.ECommon.WebAdminUrl %>/ajax/ajaxuser.ashx',
                            data: 'type=upshopbrand&v=' + j + '&v2=' + iframe.document.getElementById('hfvalue').value,
                            dataType: "json",
                            success: function (data) {
                                if (data != null) {
                                    $.each(data, function (i) {
                                        var f = '<%=string.Format(EnFilePath.Brand,"_",EnFilePath.Logo) %>';
                                        var mHtml = "<li id=\"" + data[i].id + "\"><a href=\"#\">";
                                        mHtml += "<img src=\"" + f.replace("_", data[i].id) + "/" + data[i].logo + "\" width='105' height='38' alt='" + data[i].name + "' />"
                                        mHtml += data[i].name;

                                        mHtml += "</a></li>"
                                        $("#d_" + j).append(data[i].name);

                                    });
                                }
                            }
                        })
                        return true;
                    },
                    init: function () {
                        $('.aui_buttons').append('<img src=<%=ECommon.WebAdminResourceUrl %>/images/ico/ico-03.gif class=tipimg>');
                    }
                });
            }
    </script>
</head>
<body style="padding:10px;">
<form id="form1" runat="server">
<div class="navigation">
    <b>您当前的位置：首页 &gt; 店铺管理 &gt; 店铺品牌</b>
</div>
<div class="spClear"></div>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
    <tr>
    <th width="40px" align="center">选择</th>
    <th width="40px" align="center">编号</th>
    <th width="200px"align="center">店铺名称</th>
    <th align="left">品牌</th>
    </tr>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr>
            <td align="center"><asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" /></td>
            <td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("Id")%>'></asp:Label></td>
            <td align="center"><a href="shopinfo.aspx?edit=1&id=<%#Eval("id") %>"><%#Eval("title") %></a></td>
            <td align="left">
                    <a href="#" onclick="javascript:getDialog(<%#Eval("id") %>);">【设置】</a>
                    <div id="d_<%#Eval("id") %>"></div>
                </td>
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
</div>
<style>
    .tipimg{width:255px;  height:32px; position:absolute; right:66px; bottom:14px;}
</style>
</form>
</body>
</html>
