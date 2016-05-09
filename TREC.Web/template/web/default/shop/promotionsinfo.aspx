<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotionsinfo.aspx.cs"
    Inherits="TREC.Web.aspx.shop.promotionsinfo" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/headerShop.ascx" TagName="_headerShop" TagPrefix="ucheaderShop" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>  
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>

<%--<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_shopnav.ascx" TagName="_shopnav" TagPrefix="uc3" %>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>--%>
<%@ Register Src="../ascx/_shopproduct.ascx" TagName="_shopproduct" TagPrefix="uc5" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<%@ Register src="../ascx/_shopkeys.ascx" tagname="_shopkeys" tagprefix="uc6" %>
<%@ Register src="../ascx/_shopteladdress.ascx" tagname="_shopteladdress" tagprefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_shopkeys ID="_shopkeys1" Title="-经销店铺-促销信息" runat="server" />
    <%--<uc2:_resource runat="server" />--%>
    <title>
        <%=pageTitle%></title>
   <ucnewresource:newresource ID="newresource1" runat="server" />
        <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/factory/factory.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />

    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
</head>
<body>
    <%--<uc1:_headA runat="server" />
    <uc3:_shopnav runat="server" />--%>
  <ucheaderShop:_headerShop ID="_headerShop" runat="server" />
    <div class="homebrandsc">
        <div class="topNav992">
            <%if (ShopPageBase.IsCount)
              { %>
            <div class="productList1">
                <div class="promotionsR1" style="height: auto; border-bottom: 0;">
                    <div class="promotions">
                        <span><a href="<%=string.Format(EnUrls.ShopInfoPromotions, ECommon.QuerySId) %>">返回列表页</a></span></div>
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
                        <div class="productShop productPa1" style="width:742px;">
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
                <uc5:_shopproduct ID="_shopproduct1" runat="server" />
               <uc7:_shopteladdress ID="_shopteladdress1" runat="server" />
            </div>
            <%}
              else
              { %>
            <div class="productShop productPa1" style="text-align: center;">
                该店铺或者店铺下的品牌已经被下线<br />
                您可以查询其他店铺的产品&nbsp; <a href="<%=TREC.ECommerce.ECommon.WebUrl%>product/list.aspx">去查找</a>&nbsp;
                &nbsp; <a href="<%=TREC.ECommerce.ECommon.WebUrl%>">去首页</a>
            </div>
            <%} %>
        </div>
    </div>
    <%--    <uc4:_foot runat="server" />--%>
  <ucfooter:footer ID="header3" runat="server" />
</body>
</html>
