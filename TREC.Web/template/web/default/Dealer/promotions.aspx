<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotions.aspx.cs" Inherits="TREC.Web.template.web.Dealer.promotions" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="Haojibiz.Model" %>
<%@ Import Namespace="Haojibiz.Data" %>
<%@ Import Namespace="Haojibiz.DAL" %> 

<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/_AreaSelect.ascx" TagName="AreaSelect" TagPrefix="my" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<%@ Register Src="../ascx/HeadDealer.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register src="../ascx/DealerProduct.ascx" tagname="DealerProduct" tagprefix="uc2" %>

<%@ Register src="../ascx/DealerteladdressCon.ascx" tagname="DealerteladdressCon" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title><%=title + "-促销信息" + seoword%></title>
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
<div class="site"><a href="/">家具快搜</a> > <a href="/companybrandlist.aspx">品牌</a> > 促销信息</div>
    <div style="width:0; height:6px;"></div>
    <div class="homebrandsc">
        <div class="topNav992">
            <%if (CompanyPageBase.IsCount)
              { %>
            <div class="homebraLift">
                <div class="homebraLi2" style="position:relative; overflow:visible; margin-top:0;">
                    <div class="brandjs">
                        <div class="brandjs1">
                           
                            <span class="s1" style="margin-left:10;">促销信息</span>
                            
                        </div>
                        <div class="brandjs2" style="margin:0; padding-top:9px;">
                            
                            <%for (int i = 0; i < list.Count; i++)
                              { %>
                              <%Mshop shopFirst = shoplist.Where(c => list[i].promotionsrelated.Any(p => p.shopid == c.id)).FirstOrDefault() ?? new Mshop(); %>
                            <div class="brandsDealer promove" style="margin-top: 0; border-bottom-width: <%=(i == list.Count - 1 ? 1 : 0) %>px;">
                                <div class="brandsDealerBj">
                                    <div class="brandsProm1">
                                        <h2 class="c61f38">
                                            <a href="/Dealer/promotionsinfo.aspx?id=<%=list[i].id%>&did=<%=did %>" target="_blank"><%=list[i].title %></a></h2>
                                        <p class="lastdate">
                                            <%if (DateTime.Now.Date > list[i].enddatetime.Date )
                                              { %>
                                              活动已经结束
                                            <%}
                                              else
                                              { %>
                                              <%=list[i].startdatetime.ToString("yy年MM月dd号")%>-<%=list[i].enddatetime.ToString("yy年MM月dd号")%>
                                            <%} %>
                                            <%--<strong><%=(list[i].enddatetime - DateTime.Now).Days.ToString("00") %></strong>天<strong><%=(list[i].enddatetime - DateTime.Now).Hours.ToString("00") %></strong>时<strong><%=(list[i].enddatetime - DateTime.Now).Minutes.ToString("00") %></strong>分<strong><%=(list[i].enddatetime - DateTime.Now).Seconds.ToString("00") %></strong>秒--%>
                                        </p>
                                        <p>
                                            <%=list[i].descript != null && TRECommon.HTMLUtils.GetAllTextFromHTML(list[i].descript).Length > 100 ? TRECommon.HTMLUtils.GetAllTextFromHTML(list[i].descript).Substring(0, 99) : TRECommon.HTMLUtils.GetAllTextFromHTML(list[i].descript) %></p>
                                    </div>
                                    <div class="brandsProm2">
                                        <p class="pm1 c61f38">
                                            <a href="<%=string.Format(EnUrls.ShopInfoIndex, shopFirst.id) %>"><%=shopFirst.title %></a></p>
                                        <p class="pm2">
                                            <img src="<%=ECommon.WebResourceUrlToWeb + "/images/index_74.gif"%>"><%=shopFirst.address %></p>
                                        <p class="pm2">
                                            <img src="<%=ECommon.WebResourceUrlToWeb + "/images/index_76.gif"%>"><%=shopFirst.phone %></p>
                                            <%if (list[i].promotionsrelated.Count > 1)
                                              { %>
                                        <p class="pm2">
                                            <a href="<%=string.Format(EnUrls.CompanyInfoPromotionsInfo, ECommon.QueryCid, list[i].id) %>">点击查看更多参与活动店铺</a></p>
                                            <%} %>
                                    </div>
                                </div>
                            </div>
                            <%} %>

                            <webdiyer:AspNetPager id="pager" runat="server" AlwaysShow="true" UrlPaging="true" CssClass="pager" CurrentPageButtonClass="cpb" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
              PrevPageText="上一页"></webdiyer:AspNetPager>
                        </div>
                    </div>
                </div>
            </div>
            <div class="homebraRight">
               <uc2:DealerProduct ID="DealerProduct1" runat="server" />
               <uc3:DealerteladdressCon ID="DealerteladdressCon1" runat="server" />
                
            </div>
            <%}
              else
              { %>
              <div class="productShop productPa1" style="text-align:center;">
            该厂商已经被下线<br />您可以查询其他厂商的产品&nbsp; <a href="<%=TREC.ECommerce.ECommon.WebUrl%>product/list.aspx">去查找</a>&nbsp; &nbsp; <a href="<%=TREC.ECommerce.ECommon.WebUrl%>">去首页</a>
            </div>
            <%} %>
        </div>
    </div> 
    <ucfooter:footer ID="Footer1" runat="server" />

    </form>
</body>
</html>
