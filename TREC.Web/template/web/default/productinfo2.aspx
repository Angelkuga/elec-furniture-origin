<%@ Page Language="C#" AutoEventWireup="true" 
 %>

<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>

<!DOCTYPE HTML>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <title>产品详情</title>
    <link href="/resource/content/css/detail/detail.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/js/core.js" type="text/javascript"></script>
    <script src="/resource/content/js/detail.js" type="text/javascript"></script>
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />

</head>
<body>
    <form id="Form1" runat="server">
    <uc1:header ID="header1" runat="server" />
   <div class="topNav992">
    <div class="nullInfo">
        <div class="nullText">
            
        </div>
        <div class="nullError">
            <p class="p1">对不起,您目前访问的产品暂有部分信息不全。<br>我们将尽快完善本资料。</p>
            <p class="p2">如需咨询，请拨打客服热线400-001-9211</p>
            <p class="p3">您也可以去其它地方逛逛: <a href="/market/list.aspx">卖场首页</a> | <a href="/companybrandlist.aspx">品牌首页 </a></p>
        </div>
    </div>
</div>
    <uc2:footer runat="server" ID="footer1" />
    </form>
    <script src="../../../resource/content/js/cookies.js" type="text/javascript"></script>
     <link href="/suppler/resource/css/ymPrompt/simple_gray/ymPrompt.css" rel="stylesheet"
        type="text/css" />
    <script src="/resource/script/ymPrompt.js"></script>
    
</body>
</html>
