<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.market.marketclique" %>

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
    <%if (_marketcliquemodel != null)
      { %>
        <title>【<%=_marketcliquemodel.Title%>官网】<%=_marketcliquemodel.Title%>卖场,<%=_marketcliquemodel.Title%>网上商城,<%=_marketcliquemodel.Title%>团购,上海<%=_marketcliquemodel.Title%> - 家具快搜网</title>
<meta name="keywords" content="<%=_marketcliquemodel.Title %>卖场,<%=_marketcliquemodel.Title %>网上商城,<%=_marketcliquemodel.Title %>团购,上海<%=_marketcliquemodel.Title %>" />
<meta name="description" content="<%=_marketcliquemodel.Title %>卖场专区，包含上海各区的家具卖场相关资讯内容，为各大<%=_marketcliquemodel.Title %>卖场提供贸易平台，为消费者推荐优秀的家具产品，提供准确的<%=_marketcliquemodel.Title %>家具品牌信息，<%=_marketcliquemodel.Title %>卖场团购信息，活动信息及<%=_marketcliquemodel.Title %>的全方位家具品牌产品信息，使你更好的了解<%=_marketcliquemodel.Title %>卖场信息。" />
    <% }%>
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
        <a href="/">家具快搜</a> &gt; <a href="/marketlist.aspx">卖场</a> &gt; 集团首页</div>
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
                            <%=  SubmitMeth.bSubstring(SubmitMeth.DisposeHtml(_marketcliquemodel.Descript),560)%>
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
                            <%= SubmitMeth.bSubstring(SubmitMeth.DisposeHtml(_marketcliquemodel.ChairmanOration),165)%>
                        </div>
                    </dd>
                </dl>
            </div>
        </div>
    </div>
    <div style="background: #fff; padding-bottom: 80px;">
        <div class="shopping w">
            <h2 class="f14 b">
                逛商场</h2>
            <ul class="clearfix">
                <% string address;
                   foreach (TREC.Entity.EnWebMarket m in _marketlist.Take(6))
                   { %>
                <li><a href="<%=string.Format(EnUrls.MarketInfoIndex,m.id) %>">
                    <img src="<%=EnFilePath.GetMarketSurfacePath(m.id.ToString(), m.surface)%>" class="block g10"
                        alt="<%=m.title %>" width="379" height="199" />
                    <div class="f14 d1 b ml10">
                        <span class="f16">
                            <%=m.title %></span> 电话:<%=m.lphone %></div>
                    <div class="d2 ml10">
                        <%address = ECommon.GetAreaName(m.areacode) + m.address;%>
                        地址:<%=TRECommon.StringOperation.CutString(address, 0, 50)%></div>
                    <div class="f14 d3 b ml10">
                        <%
System.Data.DataSet epm = Haojibiz.Data.SqlHelper.ExecuteDataSet(System.Data.CommandType.Text, "SELECT id,title FROM t_promotions where istop =1 and mid in (select mid from t_market where id=" + m.id + ")", null);
if (epm.Tables[0].Rows.Count > 0)
{ %>
                        <span>[促销]</span> <a href="/market/<%=m.id %>/promotions/<%=epm.Tables[0].Rows[0]["id"]%>/info-brand.aspx"
                            target="_blank">
                            <%=TRECommon.StringOperation.CutString(epm.Tables[0].Rows[0]["title"].ToString(),0,16)%></a>
                        <%}
else
{ %>
                        <span>[促销]</span> 欢迎来电咨询促销信息
                        <%}%></div>
                    <div class="shade">
                    </div>
                </a></li>
                <%} %>
            </ul>
        </div>
    </div>
    <div class="active-guild">
        <div class="w sales-latest-active">
            <h2 class="f14 b">
                最新活动</h2>
            <div class="hd clearfix yahei">
                <h3 class="f18 yahei fl mr10">
                    商家活动导购</h3>
                <span class="fl sub-tit f666">最新、最全的家具活动折扣信息</span> <a class="fr more" target="_blank"
                    href="#"></a>
                <%--<ul class="fr sub-nav">
                    <li><a target="_blank" href="#">商场</a>| <a target="_blank" href="#">品牌</a>| <a target="_blank"
                        href="#">优惠券</a> </li>
                </ul>--%>
            </div>
            <div class="bd">
                <div class="d1 clearfix">
                    <div class="fl">
                        <div id="j_keynote" class="keynote keynote-mid">
                            <div class="slides_container">
                                <%
                                    if (_marketbanner.Length > 0)
                                    {
                                        foreach (string items in _marketbanner)
                                        {%>
                                <div>
                                    <img src="<%=EnFilePath.GetMarketBannerPath(_marketcliquemodel.MarketId.ToString(),items) %>"
                                        alt="" width="795" height="298" />
                                </div>
                                <%}
                                    }
                                    else
                                    {
                                %>
                                <div>
                                    <img src="/resource/content/img/sales-field/s8.jpg" alt="" width="795" height="298" />
                                </div>
                                <%} %>
                            </div>
                        </div>
                    </div>
                    <div class="fr">
                        <% if (_promotion.Length >= 1)
                           { %>
                        <a target="_blank" href="/market/<%=GetMarketIdByPromotions(_promotion[0].mid)%>/promotions/<%=_promotion[0].id %>/info-.aspx">
                            <img class="block" alt="<%=_promotion[0].title %>" width="394" height="300" src="<%=EnFilePath.GetPromotionSurfacePath(_promotion[0].id.ToString(),_promotion[0].surface) %>"></a>
                        <%} %>
                    </div>
                </div>
                <div class="d2 clearfix">
                    <div class="fl">
                        <% if (_promotion.Length >= 2)
                           { %>
                        <a class="fl" target="_blank" href="/market/<%=GetMarketIdByPromotions(_promotion[1].mid)%>/promotions/<%=_promotion[1].id %>/info-.aspx">
                            <img class="block" alt="<%=_promotion[1].title %>" width="394" height="300" src="<%=EnFilePath.GetPromotionSurfacePath(_promotion[1].id.ToString(),_promotion[1].surface) %>"></a>
                        <%} %>
                        <% if (_promotion.Length >= 3)
                           { %>
                        <a class="fr" target="_blank" href="/market/<%=GetMarketIdByPromotions(_promotion[2].mid)%>/promotions/<%=_promotion[2].id %>/info-.aspx">
                            <img class="block" alt="<%=_promotion[2].title %>" width="394" height="300" src="<%=EnFilePath.GetPromotionSurfacePath(_promotion[2].id.ToString(),_promotion[2].surface) %>"></a>
                        <%} %>
                    </div>
                    <div class="fr">
                        <% if (_promotion.Length >= 4)
                           { %>
                        <a target="_blank" href="/market/<%=GetMarketIdByPromotions(_promotion[3].mid)%>/promotions/<%=_promotion[3].id %>/info-.aspx">
                            <img class="block" alt="<%=_promotion[3].title %>" width="394" height="300" src="<%=EnFilePath.GetPromotionSurfacePath(_promotion[3].id.ToString(),_promotion[3].surface) %>"></a>
                        <%} %>
                    </div>
                </div>
            </div>
        </div>
        <div class="w sales-brand-intro" id="j_salesBrandIntro" style="overflow: hidden;">
            <div class="hd">
                <ul class="clearfix">
                    <li class="on">品牌推荐</li>
                    <%--<li>季度明星品牌</li>--%>
                </ul>
            </div>
            <div class="bd">
                <div class="item">
                    <ul class="clearfix">
                        <%foreach (EnWebBrand items in brandList)
                          {%>
                        <li><a href="<%=string.Format(EnUrls.CompanyInfoIndex,items.companyid) %>">
                            <img src="<%=EnFilePath.GetBrandThumbPath(items.id.ToString(),items.thumb) %>" class="block"
                                alt="" width="260" height="194" /></a>
                            <div class="li-t clearfix">
                                <div class="li-t-l fl">
                                    <a href="" target="_blank" class="yahei f24">
                                        <%=items.title %></a>
                                    <p>
                                        <%=items.stylename%>
                                        /
                                        <%=items.materialname %></p>
                                </div>
                                <a href='#'>
                                    <img src="<%=EnFilePath.GetBrandLogoPath(items.id.ToString(),items.logo) %>" class="li-t-r fr"
                                        alt="<%=items.title %>" width="40" height="36" /></a>
                            </div>
                            <div class="text">
                                <%= TRECommon.StringOperation.CutString(TRECommon.StringOperation.ReplaceHtmlTag(items.descript, items.descript.Length), 0, 100)%>
                            </div>
                        </li>
                        <%}   %>
                    </ul>
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
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
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
