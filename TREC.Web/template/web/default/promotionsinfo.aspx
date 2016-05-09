<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotionsinfo.aspx.cs"
    Inherits="TREC.Web.aspx.promotionsinfo" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>

<%--<%@ Register Src="ascx/_resource.ascx" TagName="Resource" TagPrefix="my" %>
<%@ Register Src="ascx/_head.ascx" TagName="Head" TagPrefix="my" %>
<%@ Register Src="ascx/_foot.ascx" TagName="Foot" TagPrefix="my" %>
<%@ Register Src="ascx/_nav.ascx" TagName="Nav" TagPrefix="my" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>家具快搜-优惠资讯_家具行业信息官网_最全的家具品牌、厂商、店铺、家居卖场信息发布和搜素!</title>
    <ucnewresource:newresource ID="newresource1" runat="server" />

    <meta name="keywords" content="家具活动专区 特价家具 家具秒杀 团购活动 促销活动" />
    <meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！" />
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/index/index.css" rel="stylesheet" type="text/css" />
   
    <link href="/resource/content/indexnav/yx_rotaion.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/indexnav/jquery.min.js" type="text/javascript"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/index/index.js"></script>
     <script src="/resource/content/js/core.js" type="text/javascript"></script>

    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />

  <%--    <my:Resource ID="_resource1" runat="server" />--%>
</head>

<body>
    <uc1:header ID="header1" runat="server" />
    <div class="topNav992 central">
        <div class="productList1">
            <div class="site"><a href="/">家具快搜</a> > <a href="/promotions/list.aspx">品牌资讯</a> > <%=mpromotions.title%></div>
            <div class="promotionsinfo">
                <div class="promotionsinfoinner">
                    <div class="promotionsinfoinner1" style="width: auto;">
                        <h2>
                            <%=mpromotions.title %></h2>
                        <%if (DateTime.Now.Date > mpromotions.enddatetime.Date)
                          { %>
                        <p class="lastdate">
                            活动已经结束</p>
                        <%}
                          else
                          { %>
                        <p class="lastdate">
                            <%=mpromotions.startdatetime.ToString("yy年MM月dd号") %>-<%=mpromotions.enddatetime.ToString("yy年MM月dd号") %></p>
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
                <div class="produtShop" style="overflow: auto;">
                    <div class="productShop productPa1" style="width: 940px;">
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
                                    <%=shoplist[i].phone %></p>
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
                                    <%=marketlist[i].phone %>&nbsp;</p>
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
                    <%=mpromotions.descript %></div>
            </div>
            <div class="clearfix">
            </div>
        </div>
        <div class="productList2">
            <div class="promotionsR1" style="height: auto; padding-bottom: 30px;">
                <div class="promotions">
                    促销信息</div>
                <div class="prAd1">
                    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=14"></script>
                    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=15"></script>
                </div>
                <%if (NewList.Count == 0)
                  { %>
                暂无促销信息
                <%}
                  else
                  { %>
                <%for (int i = 0; i < NewList.Count; i++)
                  { %>
                <div class="promotions2">
                    <a href="<%=string.Format("/promotionsinfo.aspx?id={0}", NewList[i].id) %>">
                        <h3>
                            <%=NewList[i].title%></h3>
                    </a>
                    <p class="time">
                        截至日期：<%=NewList[i].enddatetime.ToShortDateString() %></p>
                    <%if (NewList[i].promotionsrelated.Count > 0)
                      { %>
                    <%if (NewList[i].membertype == (int)EnumMemberType.工厂企业 || NewList[i].membertype == (int)EnumMemberType.经销商)
                      { %>
                    <p class="address">
                        <%=NewList[i].promotionsrelated[0].shopaddress%></p>
                    <%}
                      else if (NewList[i].membertype == (int)EnumMemberType.卖场)
                      { %>
                    <p class="address">
                        <%=NewList[i].promotionsrelated[0].marketaddress%></p>
                    <%} %>
                    <%} %>
                </div>
                <%} %>
                <%} %>
            </div>
        </div>
    </div>
    <ucfooter:footer ID="header2" runat="server" />
</body>
</html>
