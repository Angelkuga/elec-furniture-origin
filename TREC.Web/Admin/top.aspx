<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="TREC.Web.Admin.top" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        jQuery(function () {
            $("#topnav > li").click(function () {
                $("#topnav > li").removeClass("cur");
                $(this).addClass("cur");

            });
        })
    </script>
    <style>
		*{margin:0px; padding:0px; font-size:12px;}
		td{height:60px; padding:0px; margin:0px;}
		#users{margin-left:20px;color:#FFF;}
		#users a{ font-weight:bold; color:#333; }
		
		#topnav{float:left; display:block; height:29px; width:100%; margin-top:31px;}
		li{ list-style:none; float:left; width:112px; height:29px; background:url(images/top_nav.jpg); margin:0 5px; text-align:center; cursor:pointer;}
		li a{line-height:29px; display:block;}
		li.cur{background:url(images/top_nav_cur.jpg);}
		li.cur a{ font-weight:bold; color:#282828;}
	</style>
</head>
<body style="margin:0 0 0 0">
        <table style="background-image:url(images/bg.jpg); height:60px; width:100%" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width:180px">
                	<%--<span id="users"><a href="#">孙先生(管理员)</a>：<a href="menu/menulist.aspx" target="frmmain">菜单管理</a></span>--%>
                </td>
                <td valign="top" align="left">
                	<ul id="topnav">
                    	<li class="cur"><a href="menu.aspx" target="frmLeft" onclick="parent.frames['frmmain'].src='login.aspx'">系统首页</a></li>
                        <%foreach (EnModule m in list)
                          { %>
                        <li><a href="menu.aspx?id=<%=m.id %>" target="frmLeft"><%=m.title %></a></li>
                        
                        <%} %>
                    </ul>
                </td>
                <td style="width:250px"></td>
            </tr>
        </table>
</body>
</html>
