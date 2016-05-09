<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotions.aspx.cs" Inherits="TREC.Web.aspx.company.promotions" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="Haojibiz.Model" %>
<%@ Import Namespace="Haojibiz.Data" %>
<%@ Import Namespace="Haojibiz.DAL" %> 
<%@ Register Src="../ascx/headerCompany.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register src="../ascx/_companyproduct.ascx" tagname="_companyproduct" tagprefix="uc5" %>
<%@ Register Src="../ascx/_AreaSelect.ascx" TagName="AreaSelect" TagPrefix="my" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<%@ Register src="../ascx/_companykeys.ascx" tagname="_companykeys" tagprefix="uc6" %>
<%@ Register src="../ascx/_teladdress.ascx" tagname="_teladdress" tagprefix="uc7" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_companykeys ID="_companykeys1" Title="-促销信息" runat="server" />
    <title><%=pageTitle %></title>
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <link href="/resource/content/css/core.css" rel="stylesheet" />
    <link href="/resource/content/css/factory/factory.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />
    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/factory/factory.js"></script>
</head>
<body> 
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
                            <ul class="ul1" id="brandNav">
                                <%foreach (CompanyBrand b in companyInfo.CompanyBrandList)
                                  { %>
                                <li><a href="<%=string.Format(EnUrls.CompanyInfoPromotionsSearch, ECommon.QueryCId, b.id, "0", 1) %>"
                                    class="<%=UiCommon.QueryStringCur("brand", b.id.ToString(), "", "brandjs1a") %>">
                                    <img src="<%=EnFilePath.GetBrandLogoPath(b.id.ToString(),b.logo) %>" width="105"
                                        height="38" /></a></li>
                                <%} %>
                            </ul>
                            <span class="s1" style="margin-left:0;">&nbsp;<my:AreaSelect ID="txtarea" runat="server" /><input id="btnareasearch" type="button" value="搜索" /></span>
                            <script type="text/javascript">
                                $(function () {
                                    var rurl = '<%=string.Format(EnUrls.CompanyInfoPromotionsSearch, ECommon.QueryCId, bid, "$1",1) %>';
                                    $('#btnareasearch').click(function () {
                                        var areacode = window["<%=txtarea.ClientID %>"].valueField.value;
                                        rurl = rurl.replace("$1", areacode);
                                        location.href = rurl;
                                    });
                                });
                            </script>
                        </div>
                        <div class="brandjs2" style="margin:0; padding-top:9px;">
                            
                            <%for (int i = 0; i < list.Count; i++)
                              { %>
                              <%Mshop shopFirst = shoplist.Where(c => list[i].promotionsrelated.Any(p => p.shopid == c.id)).FirstOrDefault() ?? new Mshop(); %>
                            <div class="brandsDealer promove" style="margin-top: 0; border-bottom-width: <%=(i == list.Count - 1 ? 1 : 0) %>px;">
                                <div class="brandsDealerBj">
                                    <div class="brandsProm1">
                                        <h2 class="c61f38">
                                            <a href="<%=string.Format(EnUrls.CompanyInfoPromotionsInfo, ECommon.QueryCid, list[i].id) %>" target="_blank"><%=list[i].title %></a></h2>
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
                <uc5:_companyproduct ID="_companyproduct1" runat="server" />
               <uc7:_teladdress ID="_teladdress1" runat="server" />
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
</body>
</html>
