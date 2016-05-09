<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.market.business" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/headerMarket.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_marketkeys.ascx" TagName="_marketkeys" TagPrefix="uc6" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=pageTitle%></title>
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <uc6:_marketkeys ID="_marketkeys1" Title="-家具卖场-首页" runat="server" />
    <link href="/resource/content/css/core.css" rel="stylesheet" />
    <link href="/resource/content/css/mall/mall.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />
    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/mall/mall.js"></script>
</head>
<body>
    <uc1:header ID="header1" runat="server" />
    <div class="site">
        <a href="/">家具快搜</a> &gt; <a href="/marketlist.aspx">卖场</a> &gt; 招商信息</div>
    <div class="marketdesc">
        <div class="topNav992">
            <div class="homebraLift">
                <div style="margin-top: 0; border: 0;" class="homebraLi2">
                    <!------招商信息 begin---------->
        <div class="productList1" style="margin-top: 0; min-height: 1000px;">
            <div class="productList12" style="margin-top: 0;">
                <div class="productList121">
                    <ul class="pr12-ti" style="visibility:hidden;">
                        <li><a class="<%=UiCommon.QueryStringCur("display", "", "", "pr12-tia") %><%=UiCommon.QueryStringCur("display", "all", "", "pr12-tia") %>"
                            href="<%=string.Format(EnUrls.MarketInfoPromotionsSearch, ECommon.QueryMid, "all", "", "") %>">
                            所有资讯</a></li>
                        <li><a class="<%=UiCommon.QueryStringCur("display", "brand", "", "pr12-tia") %>"
                            href="<%=string.Format(EnUrls.MarketInfoPromotionsSearch, ECommon.QueryMid, "brand", "", "") %>">
                            品牌促销资讯</a></li>
                        <li><a class="<%=UiCommon.QueryStringCur("display", "market", "", "pr12-tia") %>"
                            href="<%=string.Format(EnUrls.MarketInfoPromotionsSearch, ECommon.QueryMid, "market", "", "") %>">
                            卖场促销资讯</a></li>
                    </ul>
                    <div class="pr12-fy">
                        <a href="<%=NextUrl %>" class="xyy">下一页</a><span><%=ECommon.QueryPageIndex %>/<%=pager.PageCount %></span><a
                            href="<%=PrvUrl %>" style="float: right;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/product_19.gif" /></a></div>
                </div>
                <div class="productList122">
                </div>
            </div>
            <%for (int i = 0; i < list.Count; i++)
              { %>
           
            <div class="promotionsitem2">
                <div class="promotionsitem2bg">
                    <div class="promotionsitem2right">
                        <%if (!string.IsNullOrEmpty(MarketPageBase.marketInfo.logo))
                          { %><img src="<%=EnFilePath.GetMarketLogoPath(MarketPageBase.marketInfo.id.ToString(),MarketPageBase.marketInfo.logo) %>"
                              width="105" height="38" /><%} %>
                    </div>
                    <div class="promotionsitem2canlender">
                        <div class="day">
                            <%=list[i].startdatetime.Day.ToString("00")%></div>
                        <div class="month">
                            <%=list[i].startdatetime.Month.ToString("00")%>月</div>
                    </div>
                    <div class="promotionsitem2left">
                        <h2>
                            <a href="<%=string.Format(EnUrls.MarketInfoPromotionsInfo, ECommon.QueryMid, list[i].id, ECommon.QuerySearchDisplay) %>">
                                <%=list[i].title%></a></h2>
                        <p>
                            <span style="color: #ffb724;">[卖场]</span><strong><a href="<%=string.Format(EnUrls.MarketInfoIndex, marketInfo.id) %>"><%=marketInfo.title %></a></strong><span
                                class="mobile"><%=marketInfo.phone %></span>
                        </p>
                    </div>
                </div>
            </div>
           
            <%} %>
            <webdiyer:AspNetPager ID="pager" runat="server" AlwaysShow="true" CssClass="pager"
                CurrentPageButtonClass="cpb" UrlPaging="true" FirstPageText="首页" PrevPageText="上一页"
                NextPageText="下一页" LastPageText="尾页">
            </webdiyer:AspNetPager>
        </div>

                    <!------招商信息 end---------->
                </div>
            </div>
            <div class="pro-l" style="float: right;">
                <h3 style="">
                    推荐品牌</h3>
                <div id="con_one_1" class="f1">
                    <%foreach (EnWebMarketStoreyShop items in elist)
                      {
                          if (string.IsNullOrEmpty(items.BrandInfo.companyid)) continue; %>
                    <div class="out">
                        <a href="/company/<% = items.BrandInfo.companyid %>/index.aspx">
                            <img style="width: 196px; height: 70px;" src="<%=EnFilePath.GetBrandLogoPath(items.BrandInfo.id,items.BrandInfo.logo) %>"
                                title="<%= items.BrandInfo.title%>" /></a>
                    </div>
                    <% }%>
                </div>
            </div>
            <%--<div class="homebraRight1 homebraRight3" style="margin-top: 12px;">
                    <div class="promotions">
                        <span><a href="<%=string.Format(EnUrls.MarketInfoBrand,marketInfo.id) %>">更多</a></span>推荐入驻品牌</div>
                    <ul>
                        <%foreach (EnWebMarket.MarketBrand b in marketInfo.MarketBrandList)
                          { %>
                        <li><a href="<%=string.Format(EnUrls.CompanyInfoBrandList,b.companyid,b.id) %>">
                            <img src="<%=EnFilePath.GetBrandLogoPath(b.id,b.logo) %>" width="105" height="38"></a></li>
                        <%} %>
                    </ul>
                </div>--%>
            <%--<div class="homebraRight1 homebraRight3">
                    <div class="promotions">
                        <span><a href="<%=EnUrls.PromotionList%>">更多</a></span>促销信息</div>
                    <%=ECPromotion.GetPromotionHtml(ECPromotion.GetWebTopPromotionListToMarket(4,marketInfo.id))%>
                </div>--%>
        </div>
    </div>
    </div>
    <ucfooter:footer ID="header3" runat="server" />
</body>
</html>
