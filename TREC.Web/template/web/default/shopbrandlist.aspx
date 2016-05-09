<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.shopbrandlist" %>
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
    <div class="prlifl1">
      <uc5:_brandletter ID="_brandletter1" runat="server" />

    <div class="prlifl2">
      <div class="prlifl20">
         <div class="prli-selected"><span>您的搜索条件：</span>
        <%foreach (EnSearchItem i in ECShop.GetSearchItem().FindAll(x=>x.isCur==true))
          { %>
            <a href="<%=string.Format(EnUrls.ShopBrandListSearch, ECommon.QuerySearchBrand.Replace("_" + i.value, ""), ECommon.QuerySearchStyle.Replace("_" + i.value, ""), ECommon.QuerySearchMaterial.Replace("_" + i.value, ""), ECommon.QuerySearchSpread.Replace("_" + i.value, ""), ECommon.QuerySearchStaffsize.Replace("_" + i.value, ""), ECommon.QuerySearchSort.Replace("_" + i.value, ""), ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex)%>"><%=i.title %></a>
        <%} %>
        </div>
        <dl class="prlifldl">
          <dd>热门品牌：</dd>
          <dt  class="dt1">
          <%int tmp = 0; foreach (EnSearchItem i in ECShop.GetSearchItem().FindAll(x => x.type == "brand" && x.isCur == false))
            { %>
            <a href="<%=string.Format(EnUrls.ShopBrandListSearch,ECommon.QuerySearchBrand+"_"+i.value,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,ECommon.QuerySearchKey,ECommon.QueryPageIndex) %>" <%=tmp > 26 ? "class=\"ahide\"" : "" %>><%=i.title%></a>
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
            <a href="<%=string.Format(EnUrls.ShopBrandListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle + "_" + i.value, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex)%>"><%=i.title %></a>
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
            <a href="<%=string.Format(EnUrls.ShopBrandListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial + "_" + i.value, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex)%>"><%=i.title %></a>
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
            <a href="<%=string.Format(EnUrls.ShopBrandListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread + "_" + i.value, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex)%>"><%=i.title %></a>
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
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopBrandListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">品牌名称</a></li>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopBrandListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">名称降序</a></li>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t2","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopBrandListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">名称升序</a></li>
          </ul>
        </div>
        <div class="pr_xl"><%=sortDate %>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopBrandListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">更新时间</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopBrandListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由近到远</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d2","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopBrandListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由远到近</a></li>
          </ul>
        </div>
        <div class="pr_xl"><%=sortHot %>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopBrandListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">推荐厂家</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopBrandListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由高到低</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h2","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopBrandListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由低到高</a></li>
          </ul>
        </div>
        <%--<label for="supportDIY"><input name="supprotDIY" id="supportDIY" type="checkbox" value="" /><s>支持定制</s></label>--%></div>
    </div>
    <div class="dealerLiM2"><strong>推荐卖场</strong> &nbsp;<a href="#">弗劳思丹</a>&nbsp; <a href="#">木之本</a>&nbsp; <a href="#">全友家私</a>&nbsp; <a href="#">玉庭家具</a>&nbsp; <a href="#">甘迪</a>&nbsp; <a href="#">斯曼克</a>&nbsp; <a href="#">卡瑞迪</a>&nbsp; <a href="#">锐驰</a>&nbsp; <a href="#">力排库斯</a>&nbsp; <a href="#">艾菲尔</a></div>
    <%foreach (EnWebShopBrand b in list)
      { %>
      <div class="dealerLiMc dealerLiMc1">
      <div class="dealLiMc11 dealLiMc110">
        <div class="demc-Mlo"><img src="<%=EnFilePath.GetBrandLogoPath(b.id.ToString(),b.logo) %>" width="105" height="38" /></div>
        <ul class="demc-Mli">
          <li><strong>品牌：</strong><%=b.title %></li>
          <li><strong>风格：</strong><%=ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "3", b.style, ',', " ")%></li>
          <li><strong>档位：</strong><%=ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "5", b.spread, ',', " ")%></li>
        </ul>
      </div>
      <div class="dealLiMc12">
        <div class="dealerLiMc12">
          <ul>
          <%foreach (EnWebShopBrand.BrandShop s in b.BrandShopList)
            { %>
            <li>
              <p class="dealLiMc1-litit c61f38"><a href="<%=string.Format(EnUrls.ShopInfoIndex,s.id) %>" target="_blank" ><%=s.title %></a><%--<img src="images/index_117.gif" width="88" height="18" />--%></p>
              <p class="address"><%=ECommon.GetAreaName(s.areacode)+s.address %></p>
              <p class="phone"><%=s.phone %></p>
            </li>
            <%} %>
          </ul>
        </div>
        <div class="dealerLiMc13 c61f38">
            <%foreach (EnWebShopBrand.BrnadPomotion p in b.BrandPomotionList)
              { %>
              <%=p.title %><br />
            <%} %>
            <%if(b.BrandPomotionList.Count>0){ %>
          <a href="#">更多促销信息查询》</a><%}else{ %>
          暂无促销信息
          <%} %>
        </div>
      </div>
      <div class="productView">
          <div class="br-gcs hd"><ul>
         <li ><a href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.CompanyInfoIndex,b.companyid) %>');" target="_blank">公司介绍</a></li>
          <li ><a href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.CompanyInfoBrand,b.companyid,b.id) %>');" target="_blank">品牌介绍</a></li>
          <li ><a href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.CompanyInfoProduct,b.companyid) %>');" target="_blank">品牌产品</a></li>
          <li ><a href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.CompanyInfoAddress,b.companyid) %>');" target="_blank">店铺地址</a></li>
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
    <div class="clear" style="display:block; float:left; width:100%; height:6px; clear:both"></div>
  </div>
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

    <div class="promotionsR2"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/index_62.jpg" /></div>
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
