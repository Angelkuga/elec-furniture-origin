<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page404.aspx.cs" Inherits="TREC.Web.Page404" %>

<%@ OutputCache Duration="10" VaryByParam="none" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="Haojibiz.Model" %>
<%@ Import Namespace="Haojibiz.Data" %>
<%@ Import Namespace="Haojibiz.DAL" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>家具快搜 - 未找到页面</title>
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <meta http-equiv="X-UA-Compatible" content="IE=7;IE=9;IE=8">
    <meta name="keywords" content="家具品牌,家具品牌排名,家具十大品牌,品牌家具,实木家具十大品牌,儿童家具十大品牌,板式家具十大品牌">
    <meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！">
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/index/index.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/js/core.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:header ID="header1" runat="server" />
    <div style="text-align:center;">
        <a href="http://www.jiajuks.com/" style=" padding:50px 50px 0 0">
            <img src="/resource/images/404img.jpg"/>
        </a>
    </div>
    <ucfooter:footer ID="header2" runat="server" />
    </form>
</body>
</html>
