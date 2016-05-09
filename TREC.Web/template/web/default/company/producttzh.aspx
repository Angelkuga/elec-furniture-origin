<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.company.producttzh" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/headerCompany.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/_companyproduct.ascx" TagName="_companyproduct" TagPrefix="uc5" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../ascx/_companykeys.ascx" tagname="_companykeys" tagprefix="uc6" %>
<%@ Register src="../ascx/_teladdress.ascx" tagname="_teladdress" tagprefix="uc7" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_companykeys ID="_companykeys1" Title="-家具产品" runat="server" />
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
                                            <li><a  class="productList120cut" href="<%=string.Format(EnUrls.CompanyInfoProductListBrands, ECommon.QueryCId, item.value, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType,ECommon.QuerySearchPCategory, "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>" ><%=item.title%></a></li>
                                      <%}
                                        else
                                        { %>
                                           <li><a href="<%=string.Format(EnUrls.CompanyInfoProductListBrands, ECommon.QueryCId, item.value, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType,ECommon.QuerySearchPCategory, "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>" ><%=item.title%></a></li> 
                                      <%} %>
                                 <% } %>                                
                            </ul>
                        </div>
                    <div class="productList12" style="height: 65px;">
                        
                        <div class="productList121">
                            <ul class="pr12-ti">
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pcategory","","","pr12-tia") %>"
                                    href="<%=string.Format(EnUrls.CompanyInfoProductListBrands, ECommon.QueryCId, "", ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType, "", "","","") %>">
                                    所有产品</a></li>
                                <li><a class="<%=hass["7"] == "True" ? TREC.ECommerce.UiCommon.QueryStringCur("pcategory", "7", "", "pr12-tia") : "pr13-tia" %>"
                                    href="<%=string.Format(EnUrls.CompanyInfoProductListBrands, ECommon.QueryCId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType, "7", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>"
                                    onclick="<%=hass["7"] == "True" ? "" : "return false;" %>">卧室系列</a></li>
                                <li><a class="<%=hass["9"] == "True" ? TREC.ECommerce.UiCommon.QueryStringCur("pcategory", "9", "", "pr12-tia") : "pr13-tia" %>"
                                    href="<%=string.Format(EnUrls.CompanyInfoProductListBrands, ECommon.QueryCId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType, "9", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>"
                                    onclick="<%=hass["9"] == "True" ? "" : "return false;" %>">客厅系列</a></li>
                                <li><a class="<%=hass["10"] == "True" ? TREC.ECommerce.UiCommon.QueryStringCur("pcategory", "10", "", "pr12-tia") : "pr13-tia" %>"
                                    href="<%=string.Format(EnUrls.CompanyInfoProductListBrands, ECommon.QueryCId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType, "10", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>"
                                    onclick="<%=hass["10"] == "True" ? "" : "return false;" %>">餐厅系列</a></li>
                                <li><a class="<%=hass["11"] == "True" ? TREC.ECommerce.UiCommon.QueryStringCur("pcategory", "11", "", "pr12-tia") : "pr13-tia" %>"
                                    href="<%=string.Format(EnUrls.CompanyInfoProductListBrands, ECommon.QueryCId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType, "11", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>"
                                    onclick="<%=hass["11"] == "True" ? "" : "return false;" %>">书房系列</a></li>
                                <li><a class="<%=hass["12"] == "True" ? TREC.ECommerce.UiCommon.QueryStringCur("pcategory", "12", "", "pr12-tia") : "pr13-tia" %>"
                                    href="<%=string.Format(EnUrls.CompanyInfoProductListBrands, ECommon.QueryCId, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, 1, ECommon.QuerySearchType, "12", "",ECommon.QuerySearchPostName,ECommon.QuerySearchBrands) %>"
                                    onclick="<%=hass["12"] == "True" ? "" : "return false;" %>">儿童系列</a></li>
                                      <li><a class="pr12-tia" href='?id=0' >套组合产品</a></li>
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
                    <div class="productList" style="background: none;">
                        <%foreach (System.Data.DataRow p in dt.Rows)
                          { %>
                        <div class="productPic productPic1 productPic0">
                            <div class="productPic1">
                                <div class="productPic11">
                                    <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productinfotzh.aspx?tid=<%=p["gpid"] %>" target="_blank">
                                        <img src="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/upload/productgroup/thumb/<%=p["gpid"] %>/<%=p["thumb"] %>" style="width:230px; height:173px;"  onload="javascript:DrawImage(this,230,173);" /></a></div>
                                <div class="productPic12 c61f38" style="padding-top: 10px;">
                                    <h4>
                                        <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productinfotzh.aspx?tid=<%=p["gpid"] %>" target="_blank">
                                        
                                           <%=p["btitle"]%>&nbsp;<%=p["gpname"]%>&nbsp;<%=p["no"]%>&nbsp;<%=p["caizhititle"]%> 
                                           
                                            </a></h4>
                                    <p>
                                       <strong>系列：</strong><%=p["bstitle"] %> <strong>风格：</strong><%=p["fgtitle"] %>
                                    </p>
                                    <p>
                                        <strong>材质：</strong>
                                       <%=p["caizhititle"]%>
                                       </p>
                                   
                                    <p>
                                         <span style=" color:#555555;">套餐价:￥<%=p["price"] %></span>
                                       
                                        </p>
                                   
                                </div>
                                <%if (Convert.ToInt32(p["shopid"]) > 0)
                                  { %>
                                <div class="productPic13">
                                    <div class="productPic131">
                                       <p class="Dealer1">
                                            <span>[推荐]</span> <strong><a href="#" target="_blank"><%=p["shoptitle"]%></a>
                                             
                                            </strong>
                                            <br /><%=p["address"] %>
                                        </p>
                                    </div>
                                       
                                </div>
                                <%}
                                  else
                                  { 
                                %>
                                <div class="productPic13 productPic133">
                                    <p class="tip">对不起，本品牌暂无店铺信息</p>
                                 </div> 
                                <% } %>
                            </div>
                            <div class="productView">
                                <div class="br-gcs hd">
                                    <ul>
                                        <li><a class="btn" href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.CompanyInfoAbout, ECommon.QueryCId) %>');"
                                            target="_parent">厂家介绍</a></li>
                                        <li><a class="btn" href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.CompanyInfoBrandList,p["companyid"],p["brandid"]) %>');"
                                            target="_parent">品牌介绍</a></li>
                                        <li><a class="btn" href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.CompanyInfoAddress,p["companyid"]) %>');"
                                            target="_parent">推荐店铺</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <%} %>

                           <% if (dt.Rows.Count == 0) { 
                           %>
                          <br /><br /><br />
                          <div style="text-align:center">暂无套组合产品</div>
                           <br /><br /><br />
                          <% }%>
                    </div>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="false" CurrentPageButtonClass="cpb"
                        CssClass="pager" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                        PrevPageText="上一页" ShowPageIndexBox="Never" PageSize="20">
                    </webdiyer:AspNetPager>
                </div>
            </div>
            <div class="homebraRight">
                <uc5:_companyproduct ID="_companyproduct1" runat="server" />
                <uc7:_teladdress ID="_teladdress1" runat="server" />
            </div>
        </div>
    </div>
    <ucfooter:footer ID="header2" runat="server" />
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
