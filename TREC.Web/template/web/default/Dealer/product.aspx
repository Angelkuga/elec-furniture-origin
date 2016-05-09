<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="TREC.Web.template.web.Dealer.product" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>

<%@ Register Src="../ascx/HeadDealer.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register src="../ascx/DealerProduct.ascx" tagname="DealerProduct" tagprefix="uc2" %>

<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<%@ Register src="../ascx/DealerteladdressCon.ascx" tagname="Dealerteladdress" tagprefix="uc3" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title><%=title + "-全部产品" + seoword%></title>
     <link href="/resource/content/css/core.css" rel="stylesheet" />
    <link href="/resource/content/css/factory/factory.css" rel="stylesheet" />

    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />
    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/factory/factory.js"></script>
    <script type="text/javascript">
        myFocus.set({
            id: 'fjwcontainer', //焦点图盒子ID
            pattern: 'mF_taobao2010', //风格应用的名称
            path: '<%=ECommon.WebResourceUrl %>/script/pattern/',
            time: 6, //切换时间间隔(秒)
            trigger: 'mouseover', //触发切换模式:'click'(点击)/'mouseover'(悬停)
            width: 767, //设置图片区域宽度(像素)
            height: 331, //设置图片区域高度(像素)
            txtHeight: 0//文字层高度设置(像素),'default'为默认高度，0为隐藏
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
  
     <uc1:header ID="header1" runat="server" />
     <div class="site"><a href="/">家具快搜</a> > <a href="/companybrandlist.aspx">品牌</a> > 所有产品</div>
    <div class="homebrandsc">
        <div class="topNav992">
            <div class="homebraLift">
                <div class="homebraLi2" style="margin-top: 0; border:0;">
                    <div class="productList120">
                            <ul>
                                <%foreach (EnSearchProductItem item in _list)
                                  {%>
                                      <%if (ECommon.QuerySearchBrand == item.value)
                                        {%>
                                            <li ><a  class="productList120cut" href="<%=string.Format(EnUrls.DealerInfoProductListBrands, getdid, item.value, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType,ECommon.QuerySearchPCategory, "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>" style="<%=getBgcolor(item.value)%>"><%=item.title%></a></li>
                                      <%}
                                        else
                                        { %>
                                           <li ><a href="<%=string.Format(EnUrls.DealerInfoProductListBrands, getdid, item.value, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType,ECommon.QuerySearchPCategory, "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>" style=""><%=item.title%></a></li> 
                                      <%} %>
                                 <% } %>                                
                            </ul>
                        </div>
                    <div class="productList12" style="height: 65px;">
                        
                        <div class="productList121">
                            <ul class="pr12-ti">
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pcategory","","","pr12-tia") %>"
                                    href="<%=string.Format(EnUrls.DealerInfoProductListBrands, getdid, "", ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType, "", "","","") %>">
                                    所有产品</a></li>
                                <li><a class="<%=hass["7"] == "True" ? TREC.ECommerce.UiCommon.QueryStringCur("pcategory", "7", "", "pr12-tia") : "pr13-tia" %>"
                                    href="<%=string.Format(EnUrls.DealerInfoProductListBrands, getdid, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType, "7", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>"
                                    onclick="<%=hass["7"] == "True" ? "" : "return false;" %>">卧室系列</a></li>
                                <li><a class="<%=hass["9"] == "True" ? TREC.ECommerce.UiCommon.QueryStringCur("pcategory", "9", "", "pr12-tia") : "pr13-tia" %>"
                                    href="<%=string.Format(EnUrls.DealerInfoProductListBrands, getdid, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType, "9", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>"
                                    onclick="<%=hass["9"] == "True" ? "" : "return false;" %>">客厅系列</a></li>
                                <li><a class="<%=hass["10"] == "True" ? TREC.ECommerce.UiCommon.QueryStringCur("pcategory", "10", "", "pr12-tia") : "pr13-tia" %>"
                                    href="<%=string.Format(EnUrls.DealerInfoProductListBrands, getdid, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType, "10", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>"
                                    onclick="<%=hass["10"] == "True" ? "" : "return false;" %>">餐厅系列</a></li>
                                <li><a class="<%=hass["11"] == "True" ? TREC.ECommerce.UiCommon.QueryStringCur("pcategory", "11", "", "pr12-tia") : "pr13-tia" %>"
                                    href="<%=string.Format(EnUrls.DealerInfoProductListBrands, getdid, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType, "11", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>"
                                    onclick="<%=hass["11"] == "True" ? "" : "return false;" %>">书房系列</a></li>
                                <li><a class="<%=hass["12"] == "True" ? TREC.ECommerce.UiCommon.QueryStringCur("pcategory", "12", "", "pr12-tia") : "pr13-tia" %>"
                                    href="<%=string.Format(EnUrls.DealerInfoProductListBrands, getdid, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType, "12", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>"
                                    onclick="<%=hass["12"] == "True" ? "" : "return false;" %>">儿童系列</a></li>
                                     <li><a class=""  
                                 href="<%=string.Format(EnUrls.DealerInfoProductListBrandstzh, getdid, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey,1, ECommon.QuerySearchType,  "999", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>" >套组合产品</a></li>
                            </ul>
                            <div class="pr12-fy">
                                <a href="<%=NextUrl %>" class="xyy">下一页</a><span><%=AspNetPager1.CurrentPageIndex %>/<%=AspNetPager1.PageCount %></span><a
                                    href="<%=PrvUrl %>" style="float: right;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/product_19.gif" /></a></div>
                        </div>
                      <%--  <div class="productList122">
                            <span class="s1">快速分类</span>--%>
                            <%--<div class="pr_xl"><%=sortTitle%>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">产品名称</a></li>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">名称降序</a></li>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t2","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId,ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">名称升序</a></li>
          </ul>
        </div>
        <div class="pr_xl"><%=sortDate %>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId,ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">更新时间</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">由近到远</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d2","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">由远到近</a></li>
          </ul>
        </div>
        <div class="pr_xl"><%=sortHot %>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId,ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">推荐产品</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId,ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">由高到低</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h2","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">由低到高</a></li>
          </ul>
        </div>
        <label for="supportDIY"><input name="supprotDIY" id="supportDIY" type="checkbox" value="" /><s>支持定制</s></label>--%>
                            <%--<div class="pr_xl">
                                按品牌
                                <ul>
                                    <%foreach (var c in companyInfo.CompanyBrandList)
                                      { %>
                                    <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("brand", c.id, "", "pr_xla") %>" href="<%=string.Format(EnUrls.CompanyInfoProductListPost, ECommon.QueryCId, c.id, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory,ECommon.QuerySearchPostName) %>">
                                        <%=c.title %></a></li>
                                    <%} %>
                                </ul>
                            </div>
                        </div>--%>
                    </div>
                   
                    
             

            <!------>
            
                   
                   <%foreach (EnWebProduct p in list)
                          { %> 
                  <div class="sycp" style="overflow:hidden;height:270px;" >
                        <div class="sycp1"><a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>"><img src="<%=EnFilePath.GetProductThumbPathNew(p.id.ToString(),p.thumb,"230","173") %>"  alt=""/></a>
                    </div>
                        <div class="sycp2">
                                        <%if (p.lastedittime > new DateTime(2014, 12, 1))
                                          {%>
                                           <%=p.brandtitle%>  <%=p.categorytitle%>  <%=p.sku%>  <%=p.materialname%> <%=p.title%>
                                            <%} else { %>
                                              <%=p.HtmlProductName%>&nbsp;
                                            <%} %>
                                            </div>
                        <div class="sycp3">系列：<span><%=p.brandstitle %></span>  风格：<span><%=p.stylename %></span></div>
                       <%=GetPrice(p.ProductAttributeInfo.markprice, p.ProductAttributeInfo.saleprice, p.ProductAttributeInfo.buyprice, p.id.ToString())%>
                        <%--<div class="sycp4" >市场价：¥999 <div>市场价：¥555</div> <br />   <div style="float:left;">销售价：<span>¥88888</span></div></div>--%>
                         <div class="sycp5"><a href="#"><span>[店铺]</span> <span class="lans"><a href="<%=string.Format(EnUrls.ShopInfoIndex, p.ProductShopInfoNew.id)%>" target="_blank"><%=p.ProductShopInfoNew.title%></a></span></a></div>
                        
                  </div>
                   <%} %>
               
                   <div class="digg" style="margin-top:50px;"> <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="false" CurrentPageButtonClass="cpb"
                        CssClass="pager" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                        PrevPageText="上一页" ShowPageIndexBox="Never" PageSize="36">
                    </webdiyer:AspNetPager></div>
                    
                </div>
            </div>
            <!------>
            <div class="homebraRight">
                <uc2:DealerProduct ID="DealerProduct1" runat="server" />
                <uc3:Dealerteladdress ID="Dealerteladdress1" runat="server" />
                
            </div>
        </div>
    </div>
    <ucfooter:footer ID="header2" runat="server" />
    </form>
</body>
</html>
