<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.market.marketcliquepromotions" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/headerMarketClique.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/_marketkeys.ascx" TagName="_marketkeys" TagPrefix="uc6" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <%=pageTitle%></title>
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <link href="/resource/content/css/core.css" rel="stylesheet" />
    <link href="/resource/content/css/mall/mall.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />
    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/mall/mall.js"></script>
</head>
<body class="sales-field">
    <uc1:header ID="header1" runat="server" />
    <div class="site">
        <a href="/">家具快搜</a> &gt; <a href="/marketlist.aspx">卖场</a> &gt; 子卖场促销活动</div>
    <%if (_marketcliquemodel != null && _marketcliquemodel.Auditstatus == 1)
      { %>
    <div class="" style="background: #f3f3f3; padding-bottom: 68px;">
        <div class="w group-t">
        </div>
    </div>
    <div class="active-guild">
        <div class="w sales-latest-active">
            <h2 class="f14 b">
                子卖场促销活动</h2>
            <div class="bd">
                <div class="d1 clearfix">
                    <div class="fl">
                        <% foreach (Haojibiz.Model.Mpromotions items in _promotion)
                           { %>
                        <a class="fl" title="<%=items.title %>" target="_blank" href="/market/<%=GetMarketIdByPromotions(items.mid)%>/promotions/<%=items.id %>/info-.aspx">
                            <img class="block" alt="<%=items.title %>" width="394" height="300" src="<%=EnFilePath.GetPromotionSurfacePath(items.id.ToString(),items.surface) %>"></a>
                        <%} %>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%}
      else
      { %>
    <div class="topNav992">
        <div class="nullInfo">
            <div class="nullText">
                <div class="nullTextTitle">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%=marketInfo.title%></div>
                <table class="c" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="line-height: 25px; height: 25px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span class="i">该卖场的集团信息不完整</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            咨询电话：400-001-9211
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="nullError">
                <p class="p1">
                    对不起,您目前访问的卖场集团信息不全。<br>
                    我们将尽快完善本卖场信息资料。</p>
                <p class="p2">
                    如需咨询，请拨打客服热线400-001-9211</p>
                <p class="p3">
                    您也可以去其它地方逛逛: <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/market/list.aspx">
                        卖场首页</a> | <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/companybrandlist.aspx">
                            品牌首页 </a>
                </p>
            </div>
        </div>
    </div>
    <%} %>
    <ucfooter:footer ID="header2" runat="server" />
</body>
</html>
