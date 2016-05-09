<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_resource.ascx.cs" Inherits="TREC.Web.aspx.ascx._resource" %>
<link rel="Stylesheet" type="text/css" href="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/css/index.css" />
<link rel="Stylesheet" type="text/css" href="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/css/common.css" />
<link rel="icon" href="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/jiajukuaiso.ico"
    type="image/x-icon" />
<link rel="shortcut icon" href="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/jiajukuaiso.ico"
    type="image/x-icon" />
<!--[if lte IE 6]>
<style type="text/css">
body { behavior:url("<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/css/csshover.htc"); }
</style>
<![endif]-->
<%--<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>--%>
 <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/content/libs/jquery-1.11.0.min.js"></script>
 
 <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/soglobal.js?v2"></script>
 
<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/socommon.js"></script>
<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/myfocus-1.2.4.min.js"></script>
<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/jquery.inputlabel.js"></script>
<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/jquery.scrollLoading.js"></script>
<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/oms_autocomplate.js"></script>
<script>

<!--
    function setTab(name, cursel, n) {
        for (i = 1; i <= n; i++) {
            var menu = document.getElementById(name + i);
            var con = document.getElementById("con_" + name + "_" + i);
            menu.className = i == cursel ? "hover" : "";
            con.style.display = i == cursel ? "block" : "none";
        }
    }
//-->
</script>
<script type="text/javascript">
     $(document).ready(function(){

         $("img.scrollLoading").scrollLoading();
});
    
</script>
<style>
    .backToTop
    {
        display: none;
        padding: 26px;
        background-image: url(<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/images/backtop.gif);
        background-repeat: no-repeat;
        vertical-align: middle;
        position: fixed;
        _position: absolute;
        right: 5px;
        bottom: 5px;
        _bottom: "auto";
        cursor: pointer;
        opacity: .8;
        filter: Alpha(opacity=60);
    }
</style>

