<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_nav.ascx.cs" Inherits="TREC.Web.aspx.ascx._shopnav" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<div class="topNav992 homebrandsNav">
    <div class="homebrandsNav1">
        <h1>
            <%=ShopPageBase.shopInfo.title %></h1>
        <div class="homebrandsNav11">
            <strong>旗下品牌：</strong><font><%=ShopPageBase.shopInfo.BrandName.Replace(",", " ")%></font><%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>工厂规模：</strong><font><%=ECommon.GetConfigName(((int)EnumConfigModule.工厂配置).ToString(), "2", CompanyPageBase.companyInfo.staffsize.ToString(), ',', " ")%></font>--%></div>
        <div class="homebrandsNav12">
            <%foreach (ShopBrand b in ShopPageBase.shopInfo.ShopBrandList)
              { %>
            <a title="<%=ShopPageBase.shopInfo.BrandName.Replace(",", " ")%>" href="<%=string.Format(EnUrls.CompanyInfoBrandList,b.companyid,b.id)%>"
                target="_blank">
                <img alt="<%=ShopPageBase.shopInfo.BrandName.Replace(",", " ")%>" src="<%=EnFilePath.GetBrandLogoPath(b.id,b.thumb) %>"
                    width="105" height="38" /></a>
            <%} %>
        </div>
    </div>
    <div class="homebrandsNav2">
        <dl>
            <dd>
                <a href="<%=string.Format(EnUrls.ShopInfoIndex,ECommon.QuerySId) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "index.aspx", "", "homebrandsNava")%>">
                    首页</a></dd><dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>
            <dd>
                <a href="<%=string.Format(EnUrls.ShopInfoProduct,ECommon.QuerySId) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "product.aspx", "", "homebrandsNava")%>">
                    全部产品</a></dd><dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>
           <%-- <%if (memberInfo != null && memberInfo.RegEndTime > DateTime.Now)
              {%>--%>
                <%--<dd><a href="<%=string.Format(EnUrls.ShopInfoPromotion,ECommon.QuerySId) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "promotion.aspx", "", "homebrandsNava")%>">促销信息</a></dd><dt><a href="#"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></a></dt>--%>
                <dd>
                    <a href="<%=string.Format(EnUrls.ShopInfoPromotions, ECommon.QuerySId) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "promotions.aspx,promotionsinfo.aspx", "", "homebrandsNava") %>">
                        促销信息</a></dd><dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>
                <dd>
                    <a href="<%=string.Format(EnUrls.ShopInfoAddress,ECommon.QuerySId) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "address.aspx", "", "homebrandsNava")%>">
                        联系方式</a></dd>
           <%-- <%} %>--%>
        </dl>
        <div>
            共有产品（<%=ShopPageBase.shopInfo.productcount %>）</div>
    </div>
</div>
