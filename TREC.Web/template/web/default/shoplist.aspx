<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.shoplist" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections" %>
<%@ Register src="ascx/_resource.ascx" tagname="_resource" tagprefix="uc1" %>
<%@ Register src="ascx/_head.ascx" tagname="_head" tagprefix="uc2" %>
<%@ Register src="ascx/_foot.ascx" tagname="_foot" tagprefix="uc3" %>
<%@ Register src="ascx/_nav.ascx" tagname="_nav" tagprefix="uc4" %>
<%@ Register src="ascx/_brandletter.ascx" tagname="_brandletter" tagprefix="uc5" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%=pageTitle %></title>
    <meta name="keywords" content="家具品牌,家具品牌排名,家具十大品牌,品牌家具,实木家具十大品牌,儿童家具十大品牌,板式家具十大品牌" />
        <meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！" />
    <uc1:_resource ID="_resource1" runat="server" />
</head>
<body>
<uc2:_head ID="_head1" runat="server" />
<uc4:_nav ID="_nav1" runat="server" />
<div class="topNav992 central">
  <div class="productList1">
    <uc5:_brandletter ID="_brandletter1" runat="server" />
    <div class="prlifl2">
      <div class="prlifl20">
         <div class="prli-selected"><span>您的搜索条件：</span>
        <%foreach (EnSearchItem i in ECShop.GetSearchItem().FindAll(x=>x.isCur==true))
          { %>
            <a href="<%=string.Format(EnUrls.ShopListSearch, ECommon.QuerySearchBrand.Replace("_" + i.value, ""), ECommon.QuerySearchStyle.Replace("_" + i.value, ""), ECommon.QuerySearchMaterial.Replace("_" + i.value, ""), ECommon.QuerySearchSpread.Replace("_" + i.value, ""), ECommon.QuerySearchStaffsize.Replace("_" + i.value, ""), ECommon.QuerySearchSort.Replace("_" + i.value, ""), ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex)%>"><%=i.title %></a>
        <%} %>
        </div>
        <dl class="prlifldl">
          <dd>热门品牌：</dd>
          <dt  class="dt1">
          <% int tmp = 0; foreach (EnSearchItem i in ECShop.GetSearchItem().FindAll(x => x.type == "brand" && x.isCur == false))
             { %>
            <a href="<%=string.Format(EnUrls.ShopListSearch,ECommon.QuerySearchBrand+"_"+i.value,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,ECommon.QuerySearchKey,ECommon.QueryPageIndex) %>" <%=tmp > 26 ? "class=\"ahide\"" : "" %>><%=i.title%></a>
        <%tmp++;
             } %>
          </dt>
          <dt class="prWhole">
          <a href="#">全部</a>
          </dt>
        </dl>
        <dl class="prlifldl">
          <dd>产品风格：</dd>
          <dt>
            <dt>
          <%foreach (EnSearchItem i in ECShop.GetSearchItem().FindAll(x => x.type == "style" && x.isCur == false))
          { %>
            <a href="<%=string.Format(EnUrls.ShopListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle + "_" + i.value, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex)%>"><%=i.title %></a>
        <%} %>
          </dt>
          </dt>
        </dl>
        <dl class="prlifldl">
          <dd>产品材质：</dd>
          <dt>
          <dt>
          <%foreach (EnSearchItem i in ECShop.GetSearchItem().FindAll(x => x.type == "material" && x.isCur == false))
          { %>
            <a href="<%=string.Format(EnUrls.ShopListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial + "_" + i.value, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex)%>"><%=i.title %></a>
        <%} %>
          </dt>
          </dt>
        </dl>
        <dl class="prlifldl">
          <dd>产品价位：</dd>
          <dt>
            <dt>
          <%foreach (EnSearchItem i in ECShop.GetSearchItem().FindAll(x => x.type == "spread" && x.isCur == false))
          { %>
            <a href="<%=string.Format(EnUrls.ShopListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread + "_" + i.value, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex)%>"><%=i.title %></a>
        <%} %>
          </dt>
          </dt>
        </dl>
        
      </div>
    </div>
    <div class="productList12">
      <div class="productList121">
        <ul class="pr12-ti"> 
          <li><a href="<%=EnUrls.ShopList %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName","shoplist.aspx","","pr12-tia") %>">按经销商显示</a></li>
          <li><a href="<%=EnUrls.ShopBrandList %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName","shopbrandlist.aspx","","pr12-tia") %>">按品牌显示</a></li>
        </ul>
        <div class="pr12-fy"><a href="<%=NextUrl %>" class="xyy">下一页</a><span><%=ECommon.QueryPageIndex %>/<%=AspNetPager1.PageCount %></span><a href="<%=PrvUrl %>" style="float:right;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/product_19.gif" /></a></div>
      </div>
      <div class="productList122"><span class="s1">快速分类</span>
        <div class="pr_xl"><%=sortTitle%>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">店铺名称</a></li>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">名称降序</a></li>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t2","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">名称升序</a></li>
          </ul>
        </div>
        <div class="pr_xl"><%=sortDate %>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">更新时间</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由近到远</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d2","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由远到近</a></li>
          </ul>
        </div>
        <div class="pr_xl"><%=sortHot %>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">推荐厂家</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由高到低</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h2","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由低到高</a></li>
          </ul>
        </div>
        <%--<label for="supportDIY"><input name="supprotDIY" id="supportDIY" type="checkbox" value="" /><s>支持定制</s></label>--%></div>
    </div>
    <%foreach (EnWebShop s in list)
      { %>

      <div class="brandsDealer dealerList1">
      <%--<div class="dealerEn">A</div>--%>
      <div class="brandsDealerBj">
        <div class="brandsDealer1"><a href="<%=string.Format(EnUrls.ShopInfoIndex,s.id) %>" target="_blank"><img src="<%=EnFilePath.GetShopThumbPath(s.id.ToString(),s.thumb) %>" width="141" height="106" /></a></div>
        <div class="brandsDealer2">
          <p class="Dealer1"><strong><a href="<%=string.Format(EnUrls.ShopInfoIndex,s.id) %>" target="_blank" ><%=s.title %></a></strong><%--<a href="#"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/index_117.gif" style="margin-top:2px;"/></a>--%></p>
          <p><strong>经销品牌</strong>：<font><%=s.BrandName.Replace(",", " ") %></font>&nbsp;&nbsp;<strong>品牌风格：</strong><font><%=ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "3", s.StyleName, ',', " ")%></font></p>
          <p><img src="<%=ECommon.WebResourceUrlToWeb %>/images/index_121.gif" style=" float:left; margin:4px 5px 0 0"/><%=ECommon.GetAreaName(s.areacode) %><%=s.address %></p>
          <div><%=s.phone %></div><div class="lianxifl">欢迎来电咨询本店最新产品价格及优惠活动！</div>
        </div>
        
        <div class="brandsgc03"><a href="<%=string.Format(EnUrls.CompanyInfoBrandList, s.ShopBrandInfo.companyid,s.ShopBrandInfo.id)%>" target="_blank"><img src="<%=EnFilePath.GetBrandLogoPath(s.ShopBrandInfo.id,s.ShopBrandInfo.thumb) %>" /></a></div>
      </div>
      <div class="productView">
          <div class="br-gcs hd"><ul>
          <li><a href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.ShopInfoIndex,s.id) %>');">店铺介绍</a></li>
          <li><a href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.ShopInfoProduct,s.id) %>');">店铺产品</a></li>
          <li><a href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.ShopInfoAddress,s.id) %>');">联系方式</a></li>
         </ul>
       </div>
       </div>
    </div>

    <%} %>
    <webdiyer:aspnetpager ID="AspNetPager1" runat="server" AlwaysShow="true" 
          CurrentPageButtonClass="cpb" CssClass="pager"
              UrlPaging="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
              PrevPageText="上一页">
        </webdiyer:aspnetpager>
  </div>
  <div class="productList2">
    <div class="brandgz1 brandst">推荐品牌</div>
    <div class="brandsUl">
      <ul>
        <%foreach (EnWebAggregation a in ECommon.GetShopListTopBrand())
          { %>
            <li><a href="<%=a.url %>"><img src="<%=EnFilePath.GetAggregationThumbPath(a.id.ToString(),a.thumb) %>" width="<%=a.thumbw %>" height="<%=a.thumbh %>" title="<%=a.title %>" /></a></li>
        <%} %>
      </ul>
    </div>
    
    <div class="promotionsR1" style="margin-top:8px;">
      <div class="promotions"><span><a href="<%=string.Format(EnUrls.PromotionList) %>" target="_blank">更多</a></span>促销信息</div>
      <div class="prAd1"><script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=14"></script><script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=15"></script></div>
        <%=ECPromotion.GetPromotionHtml(ECPromotion.GetWebTopPromotionListToCompanyList(4))%>
    </div>
  </div>
</div>
<uc3:_foot ID="_foot1" runat="server" />
</body>
</html>
