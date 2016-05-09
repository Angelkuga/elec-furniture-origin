<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.market.marketcliqueabout" %>

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
        <a href="/">家具快搜</a> &gt; <a href="/marketlist.aspx">卖场</a> &gt; 集团介绍</div>
    <%if (_marketcliquemodel != null && _marketcliquemodel.Auditstatus == 1)
      { %>
    <div class="" style="background: #f3f3f3; padding-bottom: 68px;">
        <div class="w group-t">
            <%if (!String.IsNullOrEmpty(_marketcliquemodel.InfoImg))
              { %>
            <img src="<%=EnFilePath.GetMarketCliquePath(_marketcliquemodel.MarketId.ToString(),_marketcliquemodel.InfoImg) %>"
                class="block g10" alt="" width="1200" height="487" />
            <%}
              else
              { %>
            <img src="/resource/images/ppfbbg.jpg" style="border: 1px solid #CCCCCC;" class="block g10"
                alt="" width="1200" height="487" />
            <%} %>
            <div class="group-t-c clearfix">
                <dl class="fl left">
                    <dt>
                        <h2 class="f14 b">
                            集团介绍</h2>
                    </dt>
                    <dd class="clearfix">
                        <img src="<%=EnFilePath.GetMarketCliqueThumbPath(_marketcliquemodel.MarketId.ToString(),_marketcliquemodel.ThumbImg) %>"
                            class="fl img-l" alt="" width="259" height="158" />
                        <div class="text fl" style="width: 470px;">
                            <%= _marketcliquemodel.Title %><br />
                            <%= TRECommon.StringOperation.CutString(_marketcliquemodel.Descript,0,220)%>
                        </div>
                    </dd>
                </dl>
                <dl class="fl right">
                    <dt>
                        <h2 class="f14 b">
                            董事长致辞</h2>
                    </dt>
                    <dd class="clearfix">
                        <img src="<%=EnFilePath.GetMarketChairmanPath(_marketcliquemodel.MarketId.ToString(),_marketcliquemodel.ChairmanImg) %>"
                            class="fl img-r" alt="" width="234" height="163" />
                        <div class="name fl" style="width: 155px;">
                            <span class="f18 b">
                                <%= _marketcliquemodel.Chairman%></span><br />
                            <%= TRECommon.StringOperation.CutString(_marketcliquemodel.ChairmanOration,0,80)%>
                        </div>
                    </dd>
                </dl>
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
