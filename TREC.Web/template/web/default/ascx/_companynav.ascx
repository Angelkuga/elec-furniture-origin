<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_nav.ascx.cs" Inherits="TREC.Web.aspx.ascx._companynav" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<div class="topNav992 homebrandsNav">
    <div class="homebrandsNav1">
        <h1>
            <%=companyInfo.title %></h1>
        <%--<div class="homebrandsNav11"><strong>旗下品牌：</strong><font><%=CompanyPageBase.companyInfo.BrandName.Replace(",", " ") %></font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>工厂规模：</strong><font><%=ECommon.GetConfigName(((int)EnumConfigModule.工厂配置).ToString(), "2", CompanyPageBase.companyInfo.staffsize.ToString(), ',', " ")%></font></div>--%>
        <div class="homebrandsNav12">
            <%foreach (CompanyBrand b in companyInfo.CompanyBrandList)
              { %>
            <a title="<%=companyInfo.BrandName.Replace(",", " ") %>" href="<%=string.Format(EnUrls.CompanyInfoIndex,ECommon.QueryCId)%>">
                <img alt="<%=companyInfo.BrandName.Replace(",", " ") %>" src="<%=EnFilePath.GetBrandLogoPath(b.id,b.logo) %>"
                    width="105" height="38" /></a>
            <%} %>
        </div>
    </div>
    <div class="homebrandsNav2">
        <dl>
            <dd>
                <a href="<%=string.Format(EnUrls.CompanyInfoIndex,ECommon.QueryCId) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "index.aspx", "", "homebrandsNava")%>">
                    首页</a></dd><dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>
            <dd>
                <a href="<%=string.Format(EnUrls.CompanyInfoAbout,ECommon.QueryCId) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "about.aspx", "", "homebrandsNava")%>">
                    厂商介绍</a></dd><dt><a href="#"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></a></dt>
            <%
                if (companyInfo.CompanyBrandList != null && companyInfo.CompanyBrandList.Count != 0)
                {
            %>
            <dd>
                <a href="<%=string.Format(EnUrls.CompanyInfoBrand,ECommon.QueryCId) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "brand.aspx", "", "homebrandsNava")%>">
                    品牌介绍</a></dd><dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>
            <dd>
                <a href="<%=string.Format(EnUrls.CompanyInfoProduct,ECommon.QueryCId) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "product.aspx", "", "homebrandsNava")%>">
                    全部产品</a></dd><dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>
            <%
                }
            %>
           <%-- <%if (memberInfo != null && memberInfo.RegEndTime > DateTime.Now)
              {%>--%>
                    <%--<dd><a href="<%=string.Format(EnUrls.CompanyInfoCredit,ECommon.QueryCId) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "credit.aspx", "", "homebrandsNava")%>">认证证书</a></dd><dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>--%>
                    <%--<dd><a href="<%=string.Format("aboutress.aspx",ECommon.QueryCId) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "aboutress.aspx", "", "homebrandsNava")%>">联系方式</a></dd><dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>--%>
                    <dd>
                        <a href="<%=string.Format(EnUrls.CompanyMerchantsList, ECommon.QueryCid) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "merchants.aspx,merchantsInfo.aspx", "", "homebrandsNava")%>">
                            招商信息</a></dd><dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>
                    <dd>
                        <a href="<%=string.Format(EnUrls.CompanyInfoPromotions, ECommon.QueryCid) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "promotions.aspx,promotionsinfo.aspx", "", "homebrandsNava") %>">
                            促销信息</a></dd><dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>
                    <dd>
                        <a href="<%=string.Format(EnUrls.CompanyInfoNews,ECommon.QueryCId) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "news.aspx,newsinfo.aspx", "", "homebrandsNava")%>">
                            公司新闻</a></dd><dt><img src="<%=ECommon.WebResourceUrlToWeb %>/images/homebrands_24.gif" /></dt>
                    <dd>
                        <a href="<%=string.Format(EnUrls.CompanyInfoAddress,ECommon.QueryCId) %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "address.aspx", "", "homebrandsNava")%>">
                            店铺地址</a></dd>
            <%--<%} %>--%>
        </dl>
        <div>
            <a href="<%=string.Format(EnUrls.CompanyInfoProduct,ECommon.QueryCId) %>">共有产品（<%=companyInfo.productcount %>）</a></div>
    </div>
</div>
