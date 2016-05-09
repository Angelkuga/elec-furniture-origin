<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotionsinfo.aspx.cs" Inherits="TREC.Web.template.web.Dealer.promotionsinfo" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>

<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/HeadDealer.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register src="../ascx/DealerProduct.ascx" tagname="DealerProduct" tagprefix="uc2" %>

<%@ Register src="../ascx/DealerteladdressCon.ascx" tagname="DealerteladdressCon" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title><%=title + "-活动信息" + seoword%></title>

     <link href="/resource/content/css/core.css" rel="stylesheet" />
    <link href="/resource/content/css/factory/factory.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />
    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/factory/factory.js"></script>
</head>
<body>
    <form id="form1" runat="server">
     <uc1:header ID="header1" runat="server" />

      <div class="topNav992 central">
        <div class="productList1">
            <div class="promotionsR1" style="height: auto; border-bottom: 0;display:none;">
                <div class="promotions">
                    <span><a href="<%=string.Format(EnUrls.CompanyInfoPromotions, ECommon.QueryCid) %>">返回列表页</a></span></div>
            </div>
            <div class="promotionsinfo">
                <div class="promotionsinfoinner">
                    <div class="promotionsinfoinner1" style="width: auto;">
                        <h2>
                            <%=mpromotions.title %></h2>
                            <%if (DateTime.Now.Date > mpromotions.enddatetime.Date)
                              { %>
                              <p class="lastdate">活动已经结束</p>
                            <%}
                              else
                              { %>
                              <p class="lastdate"><%=mpromotions.startdatetime.ToString("yy年MM月dd号") %>-<%=mpromotions.enddatetime.ToString("yy年MM月dd号") %></p>
                            <%} %>
                        <%--<p class="lastdate">
                            <strong>
                                <%=(mpromotions.enddatetime - DateTime.Now).Days.ToString("00") %></strong>天<strong><%=(mpromotions.enddatetime - DateTime.Now).Hours.ToString("00") %></strong>时<strong><%=(mpromotions.enddatetime - DateTime.Now).Minutes.ToString("00") %></strong>分</p>--%>
                    </div>
                    <%--<div class="promotionsinfoinner2">
                        <h2 style="font-weight:bold; color:#D0233F; line-height:20px;">吉盛伟邦店</h2>
                        <p style="background:url(<%=ECommon.WebResourceUrlToWeb + "/images/index_74.gif" %>) no-repeat left 3px; padding-left:14px; line-height:22px;">长逸路15号建配龙6楼 1148</p>
                        <p style="background:url(<%=ECommon.WebResourceUrlToWeb + "/images/index_76.gif" %>) no-repeat left 3px; padding-left:14px; line-height:22px;">15221582831</p>
                    </div>--%>
                </div>
                <div class="produtShop" style="overflow:auto;">
                    <div class="productShop productPa1" style="width:942px;">
                        <%if (mpromotions.membertype == (int)EnumMemberType.工厂企业 || mpromotions.membertype == (int)EnumMemberType.经销商)
                          { %>
                        <div class="productShop-header">
                            <p class="p1">
                                参与活动店铺</p>
                            <p class="p2">
                                电话</p>
                            <p class="p3">
                                地址</p>
                        </div>
                        <div class="productShop-content">
                            <%for (int i = 0; i < shoplist.Count; i++)
                              { %>
                            <div class="productDetails1 verticalmid" style="border-bottom-width: 1px; *padding-bottom: 0px;">
                                <a class="p1" href="<%=string.Format(EnUrls.ShopInfoIndex, shoplist[i].id) %>" target="_blank"
                                    style="text-decoration: none;">
                                    <%=shoplist[i].title %>
                                    <%if (shoplist[i].attribute != null && shoplist[i].attribute.Contains(((int)EnumAttribute.推荐).ToString()))
                                      { %>
                                    <span style="color: Red; font-weight: normal; text-decoration: none;">[推荐]</span>
                                    <%} %>
                                </a>
                                <p class="p2">
                                    <%=shoplist[i].phone %>&nbsp;</p>
                                <p class="p4">
                                    <%=ECommon.GetAreaName(shoplist[i].areacode) %><%=shoplist[i].address %></p>
                                <div style="clear: both; height: 0px; width: 0px; overflow: hidden;">
                                </div>
                            </div>
                            <%} %>
                        </div>
                        <%}
                          else if (mpromotions.membertype == (int)EnumMemberType.卖场)
                          { %>
                        <div class="productShop-header">
                            <p class="p1">
                                参与活动卖场</p>
                            <p class="p2">
                                电话</p>
                            <p class="p3">
                                地址</p>
                        </div>
                        <div class="productShop-content">
                            <%for (int i = 0; i < marketlist.Count; i++)
                              { %>
                            <div class="productDetails1 verticalmid" style="border-bottom-width: 1px; *padding-bottom: 0px;">
                                <a class="p1" href="<%=string.Format(EnUrls.MarketInfoIndex, marketlist[i].id) %>"
                                    target="_blank" style="text-decoration: none;">
                                    <%=marketlist[i].title %>
                                    <%if (marketlist[i].attribute != null && marketlist[i].attribute.Contains(((int)EnumAttribute.推荐).ToString()))
                                      { %>
                                    <span style="color: Red; font-weight: normal; text-decoration: none;">[推荐]</span>
                                    <%} %>
                                </a>
                                <p class="p2">
                                    <%=marketlist[i].phone %></p>
                                <p class="p4">
                                    <%=ECommon.GetAreaName(marketlist[i].areacode) %><%=marketlist[i].address %></p>
                                <div style="clear: both; height: 0px; width: 0px; overflow: hidden;">
                                </div>
                            </div>
                            <%} %>
                        </div>
                        <%} %>
                    </div>
                </div>
                <div class="promotionsinfodes">
                <%if (!string.IsNullOrEmpty(mpromotions.surface))
                      {  %>
                    <img src="<%=EnFilePath.GetPromotionSurfacePath(mpromotions.id.ToString(),mpromotions.surface) %>" /><br />
                    <%} %>
                    <%=mpromotions.descript %></div>
            </div>
            <div class="clearfix">
            </div>
            
        </div>
        <div class="productList2">
           <uc2:DealerProduct ID="DealerProduct1" runat="server" />
           <uc3:DealerteladdressCon ID="DealerteladdressCon1" runat="server" />
            
        </div>
    </div>
      <ucfooter:footer ID="header2" runat="server" />
    </form>
</body>
</html>
