<%@ Page Language="C#" AutoEventWireup="true"  Inherits="TREC.Web.aspx.shop.index2" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register Src="../ascx/header.ascx" TagName="_headerShop" TagPrefix="ucheaderShop" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>  
<%--
<%@ Register src="../ascx/_resource.ascx" tagname="_resource" tagprefix="uc1" %>
<%@ Register src="../ascx/_head.ascx" tagname="_head" tagprefix="uc2" %>
<%@ Register src="../ascx/_foot.ascx" tagname="_foot" tagprefix="uc3" %>
<%@ Register src="../ascx/_nav.ascx" tagname="_nav" tagprefix="uc4" %>--%>
<%@ Register src="../ascx/_shopkeys.ascx" tagname="_shopkeys" tagprefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <uc6:_shopkeys ID="_shopkeys1" Title="<%=pageTitle %>" runat="server" />
    <%-- <uc1:_resource ID="_resource1" runat="server" />--%>
     <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" /> 
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />

    <script src="/resource/content/js/core.js"></script> 

</head>
<body>
<%--<uc2:_head ID="_head1" runat="server" />
<uc4:_nav ID="_nav1" runat="server" />--%>
    <ucheaderShop:_headerShop ID="_headerShop" runat="server" />
<div class="topNav992">
    <div class="nullInfo">
        <div class="nullText">
            <div class="nullTextTitle">&nbsp;&nbsp;&nbsp;<%=shopInfo.title%></div>
            <table class="c" cellpadding="0" cellspacing="0">
                <tr>
                    <td style=" line-height:25px; height:25px;">&nbsp;</td>
                </tr>
                <tr>
                    <td><span class="i">该店铺的信息不完整</span></td>
                </tr>
                <tr>
                    <td>获得更多商业机会，建议升级会员级别</td>
                </tr>
                <tr>
                    <td>咨询电话：400-001-9211</td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
        </div>
        <div class="nullError">
            <p class="p1">对不起,您目前访问的厂家暂有部分信息不全。<br>我们将尽快完善本卖场信息资料。</p>
            <p class="p2">如需咨询，请拨打客服热线400-001-9211</p>
            <p class="p3">您也可以去其它地方逛逛: <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/market/list.aspx">卖场首页</a> | <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/companybrandlist.aspx">品牌首页 </a></p>
        </div>
    </div>
</div>
<%--<uc3:_foot ID="_foot1" runat="server" />--%>
     <ucfooter:footer ID="header3" runat="server" />
</body>
</html>
