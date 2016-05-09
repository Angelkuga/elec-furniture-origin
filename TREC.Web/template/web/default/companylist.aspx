<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.companylist" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections" %>
<%@ Register Src="ascx/_resource.ascx" TagName="_resource" TagPrefix="uc1" %>
<%@ Register Src="ascx/_head.ascx" TagName="_head" TagPrefix="uc2" %>
<%@ Register Src="ascx/_foot.ascx" TagName="_foot" TagPrefix="uc3" %>
<%@ Register Src="ascx/_nav.ascx" TagName="_nav" TagPrefix="uc4" %>
<%@ Register Src="ascx/_brandletter.ascx" TagName="_brandletter" TagPrefix="uc5" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>
        <%=pageTitle%></title>
        <meta name="keywords" content="家具品牌,家具品牌排名,家具十大品牌,品牌家具,实木家具十大品牌,儿童家具十大品牌,板式家具十大品牌" />
        <meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！" />
    <uc1:_resource ID="_resource1" runat="server" />
</head>
<body>
    <uc2:_head ID="_head1" runat="server" />
    <uc4:_nav ID="_nav1" runat="server" />
    <div style="width:1px; height:100%; position:absolute; top:0px; left:0px;" id="bodyHeightBox"></div>
    <div style="width:0; height:6px;"></div>
    <div id="floatBar" class="layout_a" style=" top:0; right:0;">
        <div class="layout_a_inner">
            <div id="floatBarList" class="list_a">
                <div class="productList2" style="margin-top:0;">
                    <div id="" class="promotionsR1" style=" background-color:White; height:auto;">
                        <div class="promotions">
                            <span><a href="<%=string.Format(EnUrls.PromotionList) %>" target="_blank">更多</a></span>品牌查询</div>
                        <div class="companySearch">
                            <form method="get" action="/search.aspx">
                            <input type="hidden" name="type" value="brand" title="onlybrnad" id="onlybrnad" />
                            <input style="width:5px; margin:0; padding:0; background:none; border:0;" />
                            <input type="text" name="key" class="input1" id="brnadSearchkey" />
                            <input type="image" src="<%=ECommon.WebResourceUrlToWeb %>/images/marketSearch.gif" onmousemove="this.src='<%=ECommon.WebResourceUrlToWeb %>/images/marketSearchhover.gif'" onmouseout="this.src='<%=ECommon.WebResourceUrlToWeb %>/images/marketSearch.gif'" />
                            <i class="clearfix"></i>
                            <script type="text/javascript">
                                $(function () {
                                    $('#brnadSearchkey').oms_autocomplate({ url: "/ajax/search.ashx", paramTypeSelector: "#onlybrnad" });
                                });
                            </script>
                            </form>
                        </div>
                        <i class="clearfix"></i>
                        <div class="treeSubNavv1">
                            <ul id="tree_letter">
                                <%for (var i = 65; i < 91; i++)
                                  {
                                      Response.Write(BrandList.Any(c => c.letter != null && c.letter.Substring(0, 1).Equals(((char)i).ToString(), StringComparison.OrdinalIgnoreCase))
                                          ?
                                          ("<li ><a href=\"#" + ((char)i) + "\">" + ((char)i) + "</a></li>")
                                          :
                                          ("<li class=\"none\">" + ((char)i) + "</li>"));
                                  }%>
                            </ul>
                        </div>
                        <div id="treev1" class="treev1" style="height: 1400px;">
                            <ul>
                                <% foreach (var g in BrandList.Where(c => c.letter != null && c.letter.Length > 0).GroupBy(c => c.letter[0].ToString().ToUpper()).OrderBy(c => c.Key))
                                   { %>

                                <li id="letter1" class="root"><b>
                                    <%=g.Key%>
                                    <s>(<%=g.Count()%>)</s><a href="#" name="<%=g.Key%>"></a></b>
                                    <ul>
                                        <% foreach (var p in g)
                                           { %>
                                        <li><a class="mainBrand" href="<%=string.Format(EnUrls.CompanyInfoIndex, p.companyid) %>"
                                            target="_blank"><big>
                                                <%=p.title %></big><%if (p.style != null && p.style.Length > 0)
                                                                     { %>
                                                                     <div class="auto_BDBDBD auto_item_right" style="width:70px; top:7px;"><%=(StyleList.FirstOrDefault(c => c.value == p.style) ?? new EnConfig()).title %></div>
                                                                     <%} %></a></li>
                                        <% }%>
                                    </ul>
                                </li>
                                <% }%>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="topNav992 central">
        <div class="productList1" style="margin-top:0; min-height:1000px;">
            <uc5:_brandletter ID="_brandletter1" runat="server" />
            <div class="prlifl2">
                <div class="prlifl20">
                    <div class="topli-selected">
                        <span class="spanleft">目前搜索到&nbsp;&nbsp;&nbsp;<strong><%=AspNetPager1.RecordCount %></strong>&nbsp;件相关品牌</span>
                    </div>
                    <%if (ECProduct.GetSearchItem().FindAll(x => x.isCur == true).Count > 0)
                      { %>
                    <div class="prli-selected">
                        <span>您的搜索条件：</span>
                        <div class="selectedselect">
                            <%foreach (EnSearchItem i in ECCompany.GetSearchItem().FindAll(x => x.isCur == true))
                              { %>
                            <a href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand.Replace("_" + i.value, ""), ECommon.QuerySearchStyle.Replace("_" + i.value, ""), ECommon.QuerySearchMaterial.Replace("_" + i.value, ""), ECommon.QuerySearchSpread.Replace("_" + i.value, ""), ECommon.QuerySearchStaffsize.Replace("_" + i.value, ""), ECommon.QuerySearchSort.Replace("_" + i.value, ""), ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex)%>">
                                <%=i.title%></a>
                            <%} %>
                        </div>
                    </div>
                    <%}
                      else
                      { %>
                    <div style="width: 738px; height: 8px; margin: 0 auto; background-color: #FFE1B3;
                        margin-top: 8px;">
                    </div>
                    <%} %>
                    <%--<dl class="prlifldl">
          <dd>热门品牌：</dd>
          <dt class="dt1">
          <%int tmp = 0; foreach (EnSearchItem i in ECCompany.GetSearchItem().FindAll(x => x.type == "brand" && x.isCur == false))
            { %>
            <a href="<%=string.Format(EnUrls.CompanyListSearch,ECommon.QuerySearchBrand+"_"+i.value,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,ECommon.QuerySearchKey,ECommon.QueryPageIndex) %>" <%=tmp > 26 ? "class=\"ahide\"" : "" %>><%=i.title%></a>
        <% tmp++;
            } %>
          </dt>
          <dt class="prWhole">
          <a href="#">全部</a>
          </dt>
        </dl>--%>
                    <dl class="prlifldl">
                        <dd>
                            产品风格：</dd>
                        <dt>
                            <%foreach (EnSearchItem i in ECCompany.GetSearchItem().FindAll(x => x.type == "style" && x.isCur == false && x.title != null && x.title != ""))
                              {%>
                            <a href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle + "_" + i.value, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex)%>">
                                <%=i.title + "&nbsp;<span class=\"tcount\">" + i.count + "</span>" %></a>
                            <%}%>
                        </dt>
                    </dl>
                    <dl class="prlifldl">
                        <dd>
                            产品材质：</dd>
                        <dt>
                            <%foreach (EnSearchItem i in ECCompany.GetSearchItem().FindAll(x => x.type == "material" && x.isCur == false && x.title != null && x.title != ""))
                              { %>
                            <a href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial + "_" + i.value, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex)%>">
                                <%=i.title + "&nbsp;<span class=\"tcount\">" + i.count + "</span>" %></a>
                            <%} %>
                        </dt>
                    </dl>
                    <%--<dl class="prlifldl">
          <dd>产品价位：</dd>
          <dt>
            <dt>
          <%foreach (EnSearchItem i in ECCompany.GetSearchItem().FindAll(x => x.type == "spread" && x.isCur == false))
            { %>
            <a href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread + "_" + i.value, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex)%>"><%=i.title%></a>
        <%} %>
          </dt>
          </dt>
        </dl>
                    <dl class="prlifldl">
                        <dd>
                            工厂规模：</dd>
                        <dt>
                            <%foreach (EnSearchItem i in ECCompany.GetSearchItem().FindAll(x => x.type == "staffsize" && x.isCur == false && x.title != null && x.title != ""))
                              { %>
                            <a href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize + "_" + i.value, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex)%>">
                                <%=i.title + "&nbsp;<span class=\"tcount\">" + i.count + "</span>" %></a>
                            <%} %>
                        </dt>
                    </dl>--%>
                </div>
            </div>
            <div class="productList12">
                <div class="productList121">
                    <ul class="pr12-ti">
                        <li><a href="<%=EnUrls.CompanyBrandList %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName","companylist.aspx","","pr12-tia") %>">
                            按品牌显示</a></li>
                        <%--          <li><a href="<%=EnUrls.CompanyList %>" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName","companylist.aspx","","pr12-tia") %>">按工厂显示</a></li>
                        --%>
                    </ul>
                    <div class="pr12-fy">
                        <a href="<%=NextUrl %>" class="xyy">下一页</a><span><%=AspNetPager1.CurrentPageIndex %>/<%=AspNetPager1.PageCount%></span><a
                            href="<%=PrvUrl %>" style="float: right;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/product_19.gif" /></a></div>
                </div>
                <div class="productList122">
                    <span class="s1">快速分类</span>
                    <%--<div class="pr_xl"><%=sortTitle%>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">厂家名称</a></li>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">名称降序</a></li>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t2","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">名称升序</a></li>
          </ul>
        </div>
        <div class="pr_xl"><%=sortDate%>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">更新时间</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由近到远</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d2","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由远到近</a></li>
          </ul>
        </div>
        <div class="pr_xl"><%=sortHot%>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">推荐厂家</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由高到低</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h2","","pr_xla") %>" href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由低到高</a></li>
          </ul>
        </div>
        <label for="supportDIY"><input name="supprotDIY" id="supportDIY" type="checkbox" value="" /><s>支持定制</s></label>--%>
                    <div class="pr_xl">
                        所有风格
                        <ul>
                            <%foreach (EnSearchItem i in ECCompany.GetSearchItem().FindAll(x => x.type == "style" && x.title != null && x.title != ""))
                              {%>
                            <li><a href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle + "_" + i.value, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex)%>">
                                <%=i.title %></a></li>
                            <%}%>
                        </ul>
                    </div>
                    <div class="pr_xl">
                        所有材质
                        <ul>
                            <%foreach (EnSearchItem i in ECCompany.GetSearchItem().FindAll(x => x.type == "material" && x.isCur == false && x.title != null && x.title != ""))
                              { %>
                            <li><a href="<%=string.Format(EnUrls.CompanyListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial + "_" + i.value, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex)%>">
                                <%=i.title.Length > 5 ? i.title.Substring(0, 5) + "..." : i.title %></a></li>
                            <%} %>
                        </ul>
                    </div>
                </div>
            </div>
            <%if (list.Count > 0)
              { %>
            <%foreach (EnWebCompany c in list)
              { %>
            <div class="brandsgc">
                <div class="brandsgc0">
                    <div class="brandsgc01">
                        <a href="<%=string.Format(EnUrls.CompanyInfoIndex,c.id) %>" target="_blank">
                            <img class="scrollLoading" src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/common/white.gif"
                                data-url="<%=EnFilePath.GetCompanyThumbPath(c.id.ToString(),c.thumb) %>" width="141"
                                height="106" /></a></div>
                    <div class="brandsgc02">
                        <h3>
                            <a href="<%=string.Format(EnUrls.CompanyInfoIndex,c.id) %>" target="_blank">
                                <%=c.BrandName.Replace(",", " ")%></a></h3>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <%--<tr>
              <td><strong>生产厂家：</strong><%=c.title%></td>
              <td><strong>工厂规模：</strong><%=ECommon.GetConfigName(((int)EnumConfigModule.工厂配置).ToString(), "2", c.staffsize.ToString(), ',', " ")%></td>
            </tr>--%>
                            <tr>
                                <td>
                                    <strong>风格：</strong><%=ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "3", c.StyleName, ',', " ")%>
                                </td>
                                <%--<td><strong>产品价位：</strong><%=ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "5", c.SpreadName, ',', " ")%></td>--%>
                                <td>
                                    <strong>材质：</strong><%=ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "4", c.CompanyBrandInfo.materialvalue, ',', " ")%>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <div>
                            <%=c.descript != null && TRECommon.HTMLUtils.GetAllTextFromHTML(c.descript).Length > 100 ? TRECommon.HTMLUtils.GetAllTextFromHTML(c.descript).Substring(0, 99) : TRECommon.HTMLUtils.GetAllTextFromHTML(c.descript)%></div>
                        <%--<p>
                            地址：<font><%=ECommon.GetAreaName(c.areacode)%><%=c.address%></font></p>--%>
                    </div>
                    <div class="brandsgc03">
                        <%foreach (CompanyBrand b in c.CompanyBrandList)
                          { %>
                        <a href="<%=string.Format(EnUrls.CompanyInfoBrand,c.id,b.id) %>" target="_blank">
                            <img style="max-height:70px;"  class="scrollLoading" src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/common/white.gif"
                                data-url="<%=EnFilePath.GetBrandLogoPath(b.id, b.logo) %>" /></a>
                        <%} %>
                        <div class="productView">
                            <%-- <div class="br-gcs hd">
                                <ul>
                                  <li ><a href="#" >公司介绍</a></li>
                                  <li ><a href="#" >店铺地址</a></li>
                                  <li ><a href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.CompanyInfoProduct,c.id) %>');" target="_parent" >产品展示</a></li>
                                </ul>
                              </div>--%>
                            <div class="br-gcs bd">
                                <%--<div class="item">
                            <p class="p1">
                                品牌厂家介绍：</p>
                            <p>
                                <%=c.descript == null || TRECommon.HTMLUtils.GetAllTextFromHTML(c.descript).Length == 0 ? "暂无介绍" : TRECommon.HTMLUtils.GetAllTextFromHTML(c.descript)%>
                            </p>
                        </div>
                        <div class="item">
                            <p class="p1">
                                <a href="#" class="br-gcsa">经销商</a></p>
                            <ul class="braAboutjli">
                                <%if (c.CompanyShopList == null || c.CompanyShopList.Count == 0)
                                  { %>
                                <li>暂无经销商</li>
                                <%} %>
                                <%foreach (CompanyShop s in c.CompanyShopList)
                                  { %>
                                <li>
                                    <p class="haui">
                                        <a href="<%=string.Format(EnUrls.ShopInfoIndex,s.id) %>" target="_blank" style="color: #b1051b;">
                                            <%=s.title%>
                                            <img class="scrollLoading" src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/common/white.gif"
                                                data-url="<%=EnFilePath.GetShopThumbPath(s.id.ToString(),s.thumb) %>" width="170px"
                                                height="130px" /></a></p>
                                    <p class="address">
                                        长逸路15号建配龙6楼</p>
                                    <p class="phone">
                                        王丽君 13269291819</p>
                                </li>
                                <%} %>
                            </ul>
                        </div>--%>
                                <ul>
                                    <li><a href="#" class="btn" onclick="window.open('<%=string.Format(EnUrls.CompanyInfoProduct, c.id) %>')">查看产品</a></li>
                                    <li><a href="#" class="btn" onclick="window.open('<%=string.Format(EnUrls.CompanyInfoBrand, c.id) %>')">品牌介绍</a></li>
                                    <li><a href="#" class="btn" onclick="window.open('<%=string.Format(EnUrls.CompanyInfoAddress, c.id) %>')">店铺地址</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%} %>
            <%}
              else
              { %>
            <div class="brandsgc" style="padding:0;">
                <img src="/resource/web/images/notcompany.gif" />
            </div>
            <%} %>
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="false" CurrentPageButtonClass="cpb"
                CssClass="pager" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                PrevPageText="上一页">
            </webdiyer:AspNetPager>
        </div>
        <div class="productList2" style="margin-top:0;">
            <%--<div class="brandgz1 brandst">推荐品牌</div>
                <div class="brandsUl">
                    <ul>
                    <%foreach (EnWebAggregation a in ECommon.GetCompanyListTopBrand())
                        { %>
                        <li><a href="<%=a.url %>"><img src="<%=EnFilePath.GetAggregationThumbPath(a.id.ToString(),a.thumb) %>" width="<%=a.thumbw %>" height="<%=a.thumbh %>" title="<%=a.title %>" /></a></li>
                    <%} %>
                    </ul>
                </div>
                <div class="promotionsR2"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/index_62.jpg" /></div>
                <div class="promotionsR1" style="margin-top:10px;">
                    <div class="promotions"><span><a href="<%=string.Format(EnUrls.PromotionList) %>" target="_blank">更多</a></span>促销信息</div>
                    <div class="prAd1"><script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=14"></script><script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=15"></script></div>
                    <%=ECPromotion.GetPromotionHtml(ECPromotion.GetWebTopPromotionListToCompanyList(4))%>
                </div>
            --%>
        </div>
    </div>
    <uc3:_foot ID="_foot1" runat="server" />
    <script type="text/javascript" language="javascript">
        var Browser = new Object();
        Browser.ua = window.navigator.userAgent.toLowerCase();
        Browser.ie = /msie/.test(Browser.ua);
        Browser.moz = /gecko/.test(Browser.ua);
        var SIPAUTO_RivalHeader = document.getElementById('floatBar');
        var SIPAUTO_RivalHeader_height = document.getElementById('floatBarList').clientHeight;
        var SIPAUTO_bodyHeightBox = document.getElementById('bodyHeightBox');
        var SIPAUTO_RivalHeaderTop = (Browser.ie) ? (SIPAUTO_RivalHeader.offsetTop) : SIPAUTO_RivalHeader.offsetTop;
        var SIPAUTO_OtherTop = SIPAUTO_RivalHeader.offsetTop;
        var SIPAUTO_AutoOtherTop = SIPAUTO_OtherTop;
        function SIP_Rival_posHeader() {
            var scrollHeight = document.documentElement.scrollTop;
            if (scrollHeight > SIPAUTO_OtherTop) {
                SIPAUTO_AutoOtherTop = 0;
                SIPAUTO_RivalHeader.style.position = 'relative';
                SIPAUTO_RivalHeader.style.top = scrollHeight - SIPAUTO_OtherTop + 'px';
            } else {
                SIPAUTO_AutoOtherTop = SIPAUTO_OtherTop - scrollHeight;
                SIPAUTO_RivalHeader.style.position = '';
            }
            SIPAUTO_ResizeHeight();
        };
        function SIP_Rival_fixedHeader() {
            var scrollHeight = document.documentElement.scrollTop;
            var scr_left = document.documentElement.scrollLeft || document.body.scrollLeft;
            if (scrollHeight == 0) {
                scrollHeight = document.body.scrollTop;
            }
            if (scrollHeight > SIPAUTO_OtherTop) {
                SIPAUTO_RivalHeader.style.position = 'fixed';
                SIPAUTO_RivalHeader.style.top = '0';
                SIPAUTO_RivalHeader.style.left = '-' + scr_left + 'px';
                SIPAUTO_AutoOtherTop = 0;
            } else {
                SIPAUTO_RivalHeader.style.position = '';
                SIPAUTO_RivalHeader.style.left = '-' + scr_left + 'px';
                SIPAUTO_AutoOtherTop = SIPAUTO_OtherTop - scrollHeight;
            }
            SIPAUTO_ResizeHeight();
        };
        function SIP_Rival_PollCancel(tar) { clearInterval(tar); };
        function SIP_Rival_CycDetector() {
            return;
            var _detector = setInterval(SIP_Rival_posHeader, 50);
            setTimeout('SIP_Rival_PollCancel(' + _detector + ')', 2000);
        };
        //ie6
        if (document.attachEvent && window.ActiveXObject && !window.XMLHttpRequest) {
            window.attachEvent("onload", SIP_Rival_posHeader);
            document.attachEvent("onmousewheel", SIP_Rival_CycDetector);
            window.attachEvent("onresize", SIP_Rival_posHeader);
            window.attachEvent("onscroll", SIP_Rival_posHeader);
        };
        //ie8 ie7
        if (document.attachEvent && window.ActiveXObject && window.XMLHttpRequest) {
            window.attachEvent("onload", SIP_Rival_fixedHeader);
            window.attachEvent("onresize", SIP_Rival_fixedHeader);
            window.attachEvent("onscroll", SIP_Rival_fixedHeader);
        };
        //!ie
        if (document.addEventListener) {
            window.addEventListener("load", SIP_Rival_fixedHeader, true);
            window.addEventListener("resize", SIP_Rival_fixedHeader, true);
            window.addEventListener("scroll", SIP_Rival_fixedHeader, true);
        };
        var SIPAUTO_ResizeHeight_box = document.getElementById('treev1');
        var SIPAUTO_ResizeHeight = function () {
            var dHeight = SIPAUTO_bodyHeightBox.offsetHeight;
            var height = dHeight - SIPAUTO_AutoOtherTop - 183;
            if (height < 100) {
                height = 100;
            }
            SIPAUTO_ResizeHeight_box.style.height = height - 1 + 'px';
        }
        $(function () {
            $('#tree_letter li a[href]').click(function (e) {
                var aname = $(this).attr('href').replace(/\#/, '');
                var liTop = $("#treev1 a[name='" + aname + "']").parent().parent().offset().top;
                var ulTop = $('#treev1').offset().top;
                var ulscroTop = $('#treev1').scrollTop();
                $('#treev1').scrollTop(liTop - ulTop + ulscroTop);
                return false;
            });
        });
    </script>
</body>
</html>
