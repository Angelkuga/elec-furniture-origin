<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="TREC.Web.Admin.menu" %>
<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js" language="javascript"></script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            $(".leftMenu").find("ul").hide();
            $(".leftMenu").find("h3:eq(0)").next("ul").show() ;
            $('.leftMenu > h3').live('click', function () {
                if ($(this).next().css('display') == 'none') {
                    $(this).next().css('display', "block");
                    $(this).find("img").attr("src", "images/nav_menu_dow.gif");
                } else {
                    $(this).next().css('display', "none");
                    $(this).find("img").attr("src", "images/nav_menu_up.gif");
                }

            });
        });
    </script>
    <style type="text/css">
        *{margin:0px; padding:0px;}
        .menu_title2{background:url("images/title_bg_quit.gif"); height:25px; line-height:25px;}
        .menu_title2 span{ display:block;}
        .menu_title2 span a{margin-left:4px;}
        .leftMenu h3{ background-image:url("images/menu_bg.gif"); height:29px; line-height:29px; cursor:pointer;} 
        .leftMenu h3 img{margin:0px 5px 0px 10px;}
        .leftMenu ul{margin-bottom:15px;}
        .leftMenu ul li{ background-image:url("images/left_menu_bg.gif"); height:24px; line-height:24px; padding-left:10px;}
        .leftMenu ul li img{margin-right:10px;}
    </style>
</head>
<body>
<form id="form1" runat="server">
<table cellspacing="0" cellpadding="0" width="158">
        <tr>
            <td class="menu_title2">
                <span><a href="index.aspx"><b>系统首页</b></a>|<a href="loginout.aspx">注销登陆</a></span>
            </td>
        </tr>
</table>
<div class="leftMenu">
    <%if (ECommon.QueryId == "")
      { %>
    <h3><img src="images/nav_menu_dow.gif" />会员管理</h3>
    <ul>
        <li><img src="images/ico_01.gif" /><a href="member/memberinfo.aspx" target="frmmain">添加会员</a></li>
        <li><img src="images/ico_01.gif" /><a href="member/memberlist.aspx" target="frmmain">管理会员</a></li>
        <li><img src="images/ico_01.gif" /><a href="member/membergroupinfo.aspx" target="frmmain">添加会员组</a></li>
        <li><img src="images/ico_01.gif" /><a href="member/membergrouplist.aspx" target="frmmain">管理会员组</a></li>
    </ul>
    <h3><img src="images/nav_menu_dow.gif" />工厂管理</h3>
    <ul>
        <li><img src="images/ico_01.gif" /><a href="company/companyinfo.aspx" target="frmmain">添加工厂</a></li>
        <li><img src="images/ico_01.gif" /><a href="company/companylist.aspx" target="frmmain">管理工厂</a></li>
        <li><img src="images/ico_01.gif" /><a href="company/companygroupinfo.aspx" target="frmmain">添加工厂级别</a></li>
        <li><img src="images/ico_01.gif" /><a href="company/companygrouplist.aspx" target="frmmain">管理工厂级别</a></li>
    </ul>
    <h3><img src="images/nav_menu_dow.gif" />经 销 商</h3>
    <ul>
        <li><img src="images/ico_01.gif" /><a href="dealer/dealerinfo.aspx" target="frmmain">添加经销商</a></li>
        <li><img src="images/ico_01.gif" /><a href="dealer/dealerlist.aspx" target="frmmain">管理经销商</a></li>
        <li><img src="images/ico_01.gif" /><a href="dealer/dealergroupinfo.aspx" target="frmmain">添加经销商级别</a></li>
        <li><img src="images/ico_01.gif" /><a href="dealer/dealergrouplist.aspx" target="frmmain">管理经销商级别</a></li>
    </ul>
    <h3><img src="images/nav_menu_dow.gif" />销售店铺</h3>
    <ul>
        <li><img src="images/ico_01.gif" /><a href="shop/shopinfo.aspx" target="frmmain">添加店铺</a></li>
        <li><img src="images/ico_01.gif" /><a href="shop/shoplist.aspx" target="frmmain">管理店铺</a></li>
        <li><img src="images/ico_01.gif" /><a href="shop/shopgroupinfo.aspx" target="frmmain">添加店铺级别</a></li>
        <li><img src="images/ico_01.gif" /><a href="shop/shopgrouplist.aspx" target="frmmain">管理管理级别</a></li>
    </ul>
    <h3><img src="images/nav_menu_dow.gif" />卖场管理</h3>
    <ul>
        <li><img src="images/ico_01.gif" /><a href="market/marketinfo.aspx" target="frmmain">添加卖场</a></li>
        <li><img src="images/ico_01.gif" /><a href="market/marketlist.aspx" target="frmmain">管理卖场</a></li>
        <li><img src="images/ico_01.gif" /><a href="market/marketgroupinfo.aspx" target="frmmain">添加卖场级别</a></li>
        <li><img src="images/ico_01.gif" /><a href="market/marketgrouplist.aspx" target="frmmain">管理卖场级别</a></li>
        <li><img src="images/ico_01.gif" /><a href="market/marketcliquelist.aspx" target="frmmain">集团卖场</a></li>
    </ul>
    <h3><img src="images/nav_menu_dow.gif" />系统管理</h3>
    <ul>
        <li><img src="images/ico_01.gif" /><a href="config/configlist.aspx" target="frmmain">配置管理</a></li>
        <li><img src="images/ico_01.gif" /><a href="advertisement/advertisementcategorylist.aspx" target="frmmain">广告管理</a></li>
        <li><img src="images/ico_01.gif" /><a href="administrator/administratorlist.aspx" target="frmmain">管理员管理</a></li>
    </ul>
    <%} %>

    <%if (ECommon.QueryId != "")
      {
         int j = 0;%>
      <%foreach (TREC.Entity.EnMenu m in ECMenu.GetMenuList("", " where module=" + ECommon.QueryId, ""))
        { %>
            <%if (j != 0 && m.parent == 0)
              { %>
              </ul>
            <%} %>
            <%if (m.lev == 1)
              { %>
              <h3><img src="images/nav_menu_dow.gif" /><%=m.title%></h3>
              <ul>
            <%}
              else if (m.lev == 2)
              { %>
                <li><img src="images/ico_01.gif" /><a href="<%=ECommon.getNewMenuUrl(m.url) %>" target="frmmain"><%=m.title%></a></li>
             <%} %>
      <%j++;
        } %>
    <%} %>
     </ul>
</div>
   <%--
<table cellspacing="0" cellpadding="0" width="158">
 <tr>
        <td class="menu_title">
            <span>权限管理</span>
        </td>
    </tr>
    <tr>
        <td class="submenu" style="display: block">	
            <div class="sec_menu" style="width: 156px">
                    <table cellpadding="0" cellspacing="0" width="135">
                        <tr>
                            <td style="width: 8px">
                            </td>
                            <td>
                                <a href="permission/rolelist.aspx" target="frmmain">角色管理</a>&nbsp;|&nbsp;<a href="permission/roleinfo.aspx" target="frmmain">增加</a>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 8px">
                            </td>
                            <td>
                                <a href="permission/actionlist.aspx" target="frmmain">操作动作</a>&nbsp;|&nbsp;<a href="permission/actioninfo.aspx" target="frmmain">增加</a>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 8px">
                            </td>
                            <td>
                                <a href="permission/modulelist.aspx" target="frmmain">模块管理</a>&nbsp;|&nbsp;<a href="permission/moduleinfo.aspx" target="frmmain">增加</a>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 8px">
                            </td>
                            <td>
                                <a href="permission/setroleaction.aspx" target="frmmain">设置角色权限</a>
                            </td>
                        </tr>
                    </table>
            </div>
        </td>
    </tr>
    <tr>
        <td class="menu_title">
            <span>管理员管理</span>
        </td>
    </tr>
    <tr>
        <td class="submenu" style="display: block">	
            <div class="sec_menu" style="width: 156px">
                    <table cellpadding="0" cellspacing="0" width="135">
                        <tr>
                            <td style="width: 8px">
                            </td>
                            <td>
                                <a href="administrator/administratorlist.aspx" target="frmmain">管理员管理</a>&nbsp;|&nbsp;<a href="administrator/administratorinfo.aspx" target="frmmain">增加</a>
                            </td>
                        </tr>
                    </table>
            </div>
        </td>
    </tr>
    <tr>
        <td class="menu_title">
            <span>广告管理</span>
        </td>
    </tr>
    <tr>
        <td class="submenu" style="display: block">	
            <div class="sec_menu" style="width: 156px">
                    <table cellpadding="0" cellspacing="0" width="135">
                        <tr>
                            <td style="width: 8px">
                            </td>
                            <td>
                                <a href="advertisement/advertisementcategorylist.aspx" target="frmmain">广告位管理</a>&nbsp;|&nbsp;<a href="advertisement/advertisementcategoryinfo.aspx" target="frmmain">增加</a>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 8px">
                            </td>
                            <td>
                                <a href="advertisement/advertisementlist.aspx" target="frmmain">广告管理</a>&nbsp;|&nbsp;<a href="advertisement/advertisementinfo.aspx" target="frmmain">增加</a>
                            </td>
                        </tr>
                    </table>
            </div>
        </td>
    </tr>
    
</table>
--%>
</form>
</body>
</html>
