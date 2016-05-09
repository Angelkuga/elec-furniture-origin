<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.company.product" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_companynav.ascx" TagName="_companynav" TagPrefix="uc3" %>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>
<%@ Register Src="../ascx/_companyproduct.ascx" TagName="_companyproduct" TagPrefix="uc5" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../ascx/_companykeys.ascx" tagname="_companykeys" tagprefix="uc6" %>
<%@ Register src="../ascx/_teladdress.ascx" tagname="_teladdress" tagprefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_companykeys ID="_companykeys1" Title="-家具产品" runat="server" />
    <uc2:_resource ID="_resource1" runat="server" />
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
    <uc1:_headA ID="_headA1" runat="server" />
    <uc3:_companynav ID="_companynav1" runat="server" />
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
                        <%foreach (EnWebProduct p in list)
                          { %>
                        <div class="productPic productPic1 productPic0">
                            <div class="productPic1">
                                <div class="productPic11">
                                    <a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                        <img src="<%=EnFilePath.GetProductThumbPathNew(p.id.ToString(),p.thumb,"230","173") %>" /></a></div>
                                <div class="productPic12 c61f38" style="padding-top: 10px;">
                                    <h4>
                                        <a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                        <%if (p.lastedittime > new DateTime(2014, 12, 1))
                                          {%>
                                           <%=p.brandtitle%>  <%=p.categorytitle%>  <%=p.sku%>  <%=p.materialname%> <%=p.title%>
                                            <%} else { %>
                                              <%=p.HtmlProductName%>&nbsp;
                                            <%} %>
                                            </a></h4>
                                    <p>
                                        <strong>系列：</strong><%=p.brandstitle %>&nbsp; <strong>风格：</strong><%=p.stylename %>
                                    </p>
                                    <p>
                                        <strong>材质：</strong><select name="" style="width: 208px; height: 25px;">
                                           <%-- <%foreach (ProductAttribute a in p.ProductAttributeList)
                                              { %>
                                            <option>
                                                <%=a.productmaterial %></option>
                                            <%} %>--%>
                                            <%foreach (object s in p.HtMaterial.Keys)
                                             { %>
                                            <option>
                                                <%=s.ToString()%></option>
                                            <%} %>
                                        </select></p>
                                    <p>
                                        <strong>尺寸：</strong><select name="select" style="width: 208px; height: 25px;">
                                           <%-- <%foreach (ProductAttribute a in p.ProductAttributeList)
                                              { %>
                                            <option>
                                                <%=double.Parse(a.productlength) + "*" + double.Parse(a.productwidth) + "*" + double.Parse(a.productheight) %></option>
                                            <%} %>--%>
                                            <%foreach (object s in p.HtSize.Keys)
                                             { %>
                                            <option>
                                                <%=s.ToString() %></option>
                                            <%} %>
                                        </select>
                                    </p>
                                    <%--<p>
                                        <strong>颜色：</strong><%=p.ProductAttributeInfo.productcolortitle %></p>--%>
                                    <p>
                                         <span style=" color:#555555;">参考价:￥<%=p.ProductAttributeInfo.markprice %></span>
                                       <%-- 销售价：<%=p.ProductAttributeInfo.saleprice%>元 促销价：<%=p.ProductAttributeInfo.buyprice%>元 --%>
                                       <!--销售价-->
                                      <% if (p.ProductAttributeInfo.buyprice != null)
                                         {
                                             if (p.ProductAttributeInfo.buyprice!=null && decimal.Parse(p.ProductAttributeInfo.buyprice) > 0)
                                             {%> 
                          <%if (p.ProductAttributeInfo.buyprice != null && decimal.Parse(p.ProductAttributeInfo.buyprice) > 0)
                                                                       {%>
                               <%-- <span style=" color:#555555;">销售价:</span><span style=" color:#555555;text-decoration:line-through">￥<%=p.ProductAttributeInfo.saleprice%></span> --%>
                           <%}
                                                                       else
                                                                       { %>
                           <span>￥<%=p.ProductAttributeInfo.saleprice%></span> 
                           <%} %>
                           <%}
                                         } %>
                           <!--促销价-->
                           <%  if (p.ProductAttributeInfo.buyprice!=null && decimal.Parse(p.ProductAttributeInfo.buyprice) > 0)
                             {%>
                             促销价:<span>￥<%=p.ProductAttributeInfo.buyprice%></span>  
                             <%} %>
                                        </p>
                                   <%if (p.FID != 0)
                                    { %>
                                        <p style="padding-top:10px; display:none">
                                           <a target="_blank" width="231px" class="gotoimg" height="24px" href="http://www.fujiawang.com/dianshigui/<%=p.FID %>/">
                                           &nbsp
                                           </a>
                                       </p>
                                    <%} %>
                                </div>
                                <%if (p.ProductShopListNew != null && p.ProductShopListNew.Count != 0)
                                  { %>
                                <div class="productPic13">
                                    <div class="productPic131">
                                        <%--<p class="Dealer1">
                                            <strong><a href="#">
                                                <%=p.ProductShopInfo.title%></a></strong><a href="#"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/index_117.gif" style="margin-top:2px;"/>&nbsp;</a></p>
                                        <p class="address">
                                            <%=p.ProductShopInfo.address%></p>
                                        <p class="phone">
                                            <%=p.ProductShopInfo.phone%></p>
                                        <p class="productPicdh">
                                            电话咨询价格，请说来自福家网</p>--%>
                                        <p class="Dealer1">
                                            <span>[推荐]</span> <strong><a href="<%=string.Format(EnUrls.ShopInfoIndex, p.ProductShopInfoNew.id)%>" target="_blank"><%=p.ProductShopInfoNew.title%></a>
                                             <%if (!string.IsNullOrEmpty(p.ProductShopInfoNew.qq))
                                               { %>
                                             <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=<%=p.ProductShopInfo.qq%>&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:<%=p.ProductShopInfo.qq%>:41" alt="点击这里给我发消息" title="点击这里给我发消息"></a>
                                             <%} %>
                                            </strong>
                                        </p>
    	                                <p class="phone">
                                            <%if ((p.ProductShopInfoNew.price != "0.00" && p.ProductShopInfoNew.price != "0") || (p.ProductShopInfoNew.dollprice != "0" && p.ProductShopInfoNew.dollprice != "0.00"))
                                          { %>
                                            <%if (p.ProductShopInfoNew.dollprice != "0" && p.ProductShopInfoNew.dollprice != "0.00")
                                              { %>
                                                    <div style="border:1px #ccc solid;border-radius:3px; width:185px;height:25px;line-height:25px;color:#FF0000; font-size:14px; margin:5px 0;">
							                            <span style="font-size:13px; color:#666; font-weight:700;padding-left:8px;float:left;">促销报价：</span>
							                            <span style="font-size:1.9em;line-height:22px; padding-right:3px; font-weight:700;"><%=p.ProductShopInfoNew.dollprice.Split('.')[0]%></span>元
						                            </div>
                                            <%}
                                              else
                                              { %>
                                                   <div style="border:1px #ccc solid;border-radius:3px; width:185px;height:25px;line-height:25px;color:#FF0000; font-size:14px; margin:5px 0;">
							                            <span style="font-size:13px; color:#666; font-weight:700;padding-left:8px;float:left;">本店报价：</span>
							                            <span style="font-size:1.9em;line-height:22px; padding-right:3px; font-weight:700;"><%=p.ProductShopInfoNew.price.Split('.')[0]%></span>元
						                            </div>
                                            <%} %>
                                        <%} %>
                                        </p>
                                        <p class="address"><%=p.ProductShopInfoNew.address%></p>
                                    </div>
                                        <%if (promotionslist.Where(c => c.promotionsrelated.Any(f => f.shopid > 0 && f.shopid.ToString() == p.ProductShopInfoNew.id)).Any())
                                          { %>
                                                  <%foreach (var pc in promotionslist.Where(c => c.promotionsrelated.Any(f => f.shopid > 0 && f.shopid.ToString() == p.ProductShopInfoNew.id)).Take(1))
                                                    {  %>
                                                <div class="productPic132 Dealer1">
                                                    <span>[优惠]</span>
                                                    <p><a href="<%=string.Format(EnUrls.CompanyInfoPromotionsInfo, ECommon.QueryCid, pc.id) %>"><%=pc.title %></a></p>
                                                </div>
                                        <%break;
                                            } %>
                                        <%}
                                          else
                                          { %>
                                          <div class="productPic132 Dealer1">
                                            <span>[优惠]</span>
                                            <p><a href="#">欢迎来电咨询最新优惠信息</a></p>
                                        </div>
                                        <%} %>
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
                                        <li><a class="btn" href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.CompanyInfoBrandList,p.companyid,p.brandid) %>');"
                                            target="_parent">品牌介绍</a></li>
                                        <li><a class="btn" href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.CompanyInfoAddress,p.companyid) %>');"
                                            target="_parent">推荐店铺</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <%} %>
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
    <uc4:_foot ID="_foot1" runat="server" />
</body>
</html>
