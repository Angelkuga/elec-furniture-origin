<%@ Page Language="C#" AutoEventWireup="true"  Inherits="TREC.Web.aspx.shop.producttzh" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/headerShop.ascx" TagName="_headerShop" TagPrefix="ucheaderShop" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>  
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>

<%--<%@ Register src="../ascx/_headA.ascx" tagname="_headA" tagprefix="uc1" %>
<%@ Register src="../ascx/_resource.ascx" tagname="_resource" tagprefix="uc2" %>
<%@ Register src="../ascx/_shopnav.ascx" tagname="_shopnav" tagprefix="uc3" %>
<%@ Register src="../ascx/_foot.ascx" tagname="_foot" tagprefix="uc4" %>--%>
<%@ Register src="../ascx/_shopproduct.ascx" tagname="_shopproduct" tagprefix="uc5" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<%@ Register src="../ascx/_shopkeys.ascx" tagname="_shopkeys" tagprefix="uc6" %>
<%@ Register src="../ascx/_shopteladdress.ascx" tagname="_shopteladdress" tagprefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_shopkeys ID="_shopkeys1" Title="-经销店铺-销售产品" runat="server" />
    <%--<uc2:_resource ID="_resource1" runat="server" />--%>
    <title>
        <%=pageTitle%></title>
    <ucnewresource:newresource ID="newresource1" runat="server" />
      <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/factory/factory.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />

    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/factory/factory.js" type="text/javascript"></script>
 
</head>
<body>
    <ucheaderShop:_headerShop ID="_headerShop" runat="server" />
<%--<uc1:_headA ID="_headA1" runat="server" />
<uc3:_shopnav ID="_shopnav1" runat="server" />--%>
<div class="homebrandsc">
  <div class="topNav992">
    <div class="homebraLift">
      <div class="homebraLi2" style="margin-top:0;">
        <div class="productList12">
          <div class="productList121">
            <ul class="pr12-ti">
              <li><a class="" href="<%=string.Format(EnUrls.ShopInfoProductListBrands, ECommon.QuerySId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, "", "","","") %>">所有产品</a></li>
              <li><a class="<%=hass["7"] == "True" ? TREC.ECommerce.UiCommon.QueryStringCur("pcategory", "7", "", "pr12-tia") : "pr13-tia" %>" href="<%=string.Format(EnUrls.ShopInfoProductListBrands, ECommon.QuerySId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, "7", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>" onclick="<%=hass["7"] == "True" ? "" : "return false;" %>">卧室系列</a></li>
              <li><a class="<%=hass["9"] == "True" ? TREC.ECommerce.UiCommon.QueryStringCur("pcategory", "9", "", "pr12-tia") : "pr13-tia" %>" href="<%=string.Format(EnUrls.ShopInfoProductListBrands, ECommon.QuerySId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, "9", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>" onclick="<%=hass["9"] == "True" ? "" : "return false;" %>">客厅系列</a></li>
              <li><a class="<%=hass["10"] == "True" ? TREC.ECommerce.UiCommon.QueryStringCur("pcategory", "10", "", "pr12-tia") : "pr13-tia" %>" href="<%=string.Format(EnUrls.ShopInfoProductListBrands, ECommon.QuerySId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, "10", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>" onclick="<%=hass["10"] == "True" ? "" : "return false;" %>">餐厅系列</a></li>
              <li><a class="<%=hass["11"] == "True" ? TREC.ECommerce.UiCommon.QueryStringCur("pcategory", "11", "", "pr12-tia") : "pr13-tia" %>" href="<%=string.Format(EnUrls.ShopInfoProductListBrands, ECommon.QuerySId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, "11", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>" onclick="<%=hass["11"] == "True" ? "" : "return false;" %>">书房系列</a></li>
              <li><a class="<%=hass["12"] == "True" ? TREC.ECommerce.UiCommon.QueryStringCur("pcategory", "12", "", "pr12-tia") : "pr13-tia" %>" href="<%=string.Format(EnUrls.ShopInfoProductListBrands, ECommon.QuerySId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, "12", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>" onclick="<%=hass["12"] == "True" ? "" : "return false;" %>">儿童系列</a></li>

              <li><a class="pr12-tia" href='?id=0' >套组合产品</a></li>
            </ul>
            <div class="pr12-fy"><a href="<%=NextUrl %>" class="xyy">下一页</a><span><%=AspNetPager1.CurrentPageIndex %>/<%=AspNetPager1.PageCount %></span><a href="<%=PrvUrl %>" style="float:right;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/product_19.gif" /></a></div>
          </div>
          <div class="productList122">
          <%--<span class="s1">快速分类</span>
        <div class="pr_xl"><%=sortTitle%>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopInfoProductList, ECommon.QuerySId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">产品名称</a></li>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopInfoProductList, ECommon.QuerySId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">名称降序</a></li>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t2","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopInfoProductList, ECommon.QuerySId,ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">名称升序</a></li>
          </ul>
        </div>
        <div class="pr_xl"><%=sortDate %>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopInfoProductList, ECommon.QuerySId,ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">更新时间</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopInfoProductList, ECommon.QuerySId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">由近到远</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d2","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopInfoProductList, ECommon.QuerySId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">由远到近</a></li>
          </ul>
        </div>
        <div class="pr_xl"><%=sortHot %>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopInfoProductList, ECommon.QuerySId,ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">推荐产品</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopInfoProductList, ECommon.QuerySId,ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">由高到低</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h2","","pr_xla") %>" href="<%=string.Format(EnUrls.ShopInfoProductList, ECommon.QuerySId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">由低到高</a></li>
          </ul>
        </div>
        <label for="supportDIY"><input name="supprotDIY" id="supportDIY" type="checkbox" value="" /><s>支持定制</s></label>--%>
        </div>
        </div>        
        <div class="productLi_w">
          <%foreach (System.Data.DataRow p in dt.Rows)
          { %>
        <div class="productPa2 productLit c61f38">
          <p><a  href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/productinfotzh.aspx?tid=<%=p["gpid"] %>" target="_blank">
          <img  src="<%=p["thumb"] %>"  style='width:230px;height:173px;' onload="javascript:DrawImage(this,230,173);"  /></a></p>
          <p class="titlepro"><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/productinfotzh.aspx?tid=<%=p["gpid"] %>" target="_blank"><%=p["gpname"] %></a></p>
          <p>风格：<span><span style="color:#C61F38;"><%=p["fgtitle"]%></span></span></p>
          <h4 style="font-size:12px;">
          <strong style="color:#666">价格：</strong><a style="text-decoration:none; cursor:default; font-weight:bold"><%=p["price"]%> 元</a></h4>
          
         
        </div>
        <%} %>

        <% if (dt.Rows.Count == 0) { 
           %>
          <br /><br /><br />
          <div style="text-align:center">暂无套组合产品</div>
           <br /><br /><br />
          <% }%>


        </div>
        <div style=" clear:both; height:10px; width:100%; float:left"></div>
        <webdiyer:aspnetpager ID="AspNetPager1" runat="server" AlwaysShow="false" 
          CurrentPageButtonClass="cpb" CssClass="pager"
              UrlPaging="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
              PrevPageText="上一页" PageSize="30">
        </webdiyer:aspnetpager>
      </div>
    </div>
    <div class="homebraRight">
      <uc5:_shopproduct ID="_shopproduct1" runat="server" />
        <uc7:_shopteladdress ID="_shopteladdress1" runat="server" />
    </div>
  </div>
</div>
<%--<uc4:_foot ID="_foot1" runat="server" />--%>
   <ucfooter:footer ID="header3" runat="server" />
     
<script language="javascript" type="text/javascript">

    function DrawImage(ImgD, FitWidth, FitHeight) {
        var image = new Image();
        image.src = ImgD.src;
        if (image.width > 0 && image.height > 0) {
            if (image.width / image.height >= FitWidth / FitHeight) {
                if (image.width > FitWidth) {
                    ImgD.width = FitWidth;
                    ImgD.height = (image.height * FitWidth) / image.width;
                }
                else {
                    ImgD.width = image.width;
                    ImgD.height = image.height;
                }
            }
            else {
                if (image.height > FitHeight) {
                    ImgD.height = FitHeight;
                    ImgD.width = (image.width * FitHeight) / image.height;
                }
                else {
                    ImgD.width = image.width;
                    ImgD.height = image.height;
                }
            }
        }
    } 
 </script>
</body>
</html>
