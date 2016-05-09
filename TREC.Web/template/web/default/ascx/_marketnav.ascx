<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_nav.ascx.cs" Inherits="TREC.Web.aspx.ascx._marketnav" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>

<div class="topNav992 homebrandsNav">
  <div class="homebrandsNav1">
    <h1><%=MarketPageBase.marketInfo.title %></h1>
    <div class="homebrandsNav11"><strong>地址：</strong><font><%=MarketPageBase.marketInfo.address %></font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>联系方式：</strong><font><%=MarketPageBase.marketInfo.lphone %></font></div>
    <div class="homebrandsNav12"><a href="#"><%if (!string.IsNullOrEmpty(MarketPageBase.marketInfo.logo)) { %><img src="<%=EnFilePath.GetMarketLogoPath(MarketPageBase.marketInfo.id.ToString(),MarketPageBase.marketInfo.logo) %>" width="105" height="38" /><%} %></a></div>
  </div>
  <%if (TREC.ECommerce.UiCommon.QueryStringCur("pageName", "index.aspx", "", "homebrandsNava") == "homebrandsNava" && !string.IsNullOrEmpty(MarketPageBase.marketInfo.thumb))
    {%>
  <div class="marketBanner"><img alt="<%=MarketPageBase.marketInfo.title %>" src="<%=EnFilePath.GetMarketThumbPath(MarketPageBase.marketInfo.id.ToString(),MarketPageBase.marketInfo.thumb)%>" width="992" /></div>
  <%} %>
  <div class="homebrandsNav2">
    <dl>
      <dd><a href="<%=string.Format(EnUrls.MarketInfoIndex,ECommon.QueryMid) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "index.aspx", "", "homebrandsNava")%>">首页</a></dd>
      <dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>
      <dd><a href="<%=string.Format(EnUrls.MarketInfoAbout,ECommon.QueryMid) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "about.aspx", "", "homebrandsNava")%>">卖场介绍</a></dd>
      <dt style="display:none;"><a href="#"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></a></dt>
      <dd style="display:none;"><a href="<%=string.Format(EnUrls.MarketInfoBrand,ECommon.QueryMid) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "brand.aspx", "", "homebrandsNava")%>">入驻品牌</a></dd>
      <dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>
      <dd><a href="<%=string.Format(EnUrls.MarketInfoProduct,ECommon.QueryMid) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "product.aspx", "", "homebrandsNava")%>">全部产品</a></dd>
      <dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt><%--
      <dd><a href="<%=string.Format(EnUrls.MarketInfoNews,ECommon.QueryMid) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "news.aspx", "", "homebrandsNava")%>">品牌新闻</a></dd>
      <dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>
      <dd><a href="<%=string.Format(EnUrls.MarketInfoPromotion,ECommon.QueryMid) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "promotion.aspx", "", "homebrandsNava")%>">促销信息</a></dd>
      <dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>--%>
      <dd><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "promotions.aspx,promotionsinfo.aspx", "", "homebrandsNava") %>" href="<%=string.Format(EnUrls.MarketInfoPromotions, ECommon.QueryMid) %>">促销信息</a></dd>
      <dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>
      <dd><a href="<%=string.Format(EnUrls.MarketBusiness,ECommon.QueryMid) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "business.aspx", "", "homebrandsNava")%>">招商信息</a></dd>   
      <dt style="display:none;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>
      <dd style="display:none;"><a href="<%=string.Format(EnUrls.MarketInfoAddress,ECommon.QueryMid) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "address.aspx", "", "homebrandsNava")%>">卖场地址</a></dd>       
    </dl>     
  </div>
</div>