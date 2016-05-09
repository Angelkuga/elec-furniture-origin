<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.market.brand" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Linq" %>
<%@ Register Src="../ascx/headerMarket.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>  
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<%--<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>--%>
<%@ Register Src="../ascx/_marketnav.ascx" TagName="_marketnav" TagPrefix="uc3" %>
<%--<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>--%>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../ascx/_marketkeys.ascx" tagname="_marketkeys" tagprefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_marketkeys ID="_marketkeys1" Title="-家具卖场-卖场品牌" runat="server" />
   <%-- <uc2:_resource ID="_resource1" runat="server" />--%>
   <ucnewresource:newresource ID="newresource1" runat="server" />
       <link href="/resource/content/css/core.css" rel="stylesheet" />
    <link href="/resource/content/css/mall/mall.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />
    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/mall/mall.js"></script>

    <script type="text/javascript">
        myFocus.set({
            id: 'fjwcontainer', //焦点图盒子ID
            pattern: 'mF_games_tb', //风格应用的名称
            path: '<%=ECommon.WebResourceUrl %>/script/pattern/',
            time: 6, //切换时间间隔(秒)
            trigger: 'mouseover', //触发切换模式:'click'(点击)/'mouseover'(悬停)
            width: 300, //设置图片区域宽度(像素)
            height: 225, //设置图片区域高度(像素)
            txtHeight: 0//文字层高度设置(像素),'default'为默认高度，0为隐藏
        });
    </script>
    <script type="text/javascript">
        myFocus.set({
            id: 'fjwcontainer', //焦点图盒子ID
            pattern: 'mF_taobao2010', //风格应用的名称
            path: 'http://www.fujiawang.com/js/pattern/',
            time: 6, //切换时间间隔(秒)
            trigger: 'mouseover', //触发切换模式:'click'(点击)/'mouseover'(悬停)
            width: 466, //设置图片区域宽度(像素)
            height: 195, //设置图片区域高度(像素)
            txtHeight: 0//文字层高度设置(像素),'default'为默认高度，0为隐藏
        });
 
    </script>
    <script type="text/javascript">
        $(function () {
            marketFloorEvent();
            soFocusMarketAlpha()
        });

        function marketFloorEvent() {
            marketTab('marketFloorTrim1');
        }

        function marketTab(obj) {
            $('.' + obj + '>.hd>ul>li').click(function () {
                var o = $(this);
                var objPa = o.parent('ul');
                var objSib = objPa.find('li');
                var index = objSib.index(o);
                objSib.removeClass('on');
                o.addClass('on');

                var objItemList = objPa.parent('.hd').siblings('.bd');
                objItemList.find('.item').hide();

                var itemTarget = objItemList.find('.item').eq(index);
                itemTarget.show();
                return false;
            });
        }
        function soFocusMarketAlpha() {
            $('.focusMarket a').mouseenter(function () {
                var obj = $(this);
                obj.find('span').css("display", "block");
                obj.find('img:eq(0)').stop().animate({ "opacity": "0.3" }, 0);

                var objs = obj.siblings('a').find('span').hide();

            });

            $('.focusMarket a').mouseleave(function () {
                var obj = $(this);
                obj.find('span').hide();
                obj.find('img:eq(0)').stop().animate({ "opacity": "1" }, 0);
                var objs = obj.siblings('a').find('span').hide();
            });
        }
    </script>
</head>
<body>
  <uc1:header ID="header1" runat="server" />
   <%-- <uc3:_marketnav ID="_marketnav1" runat="server" />--%>
    <div class="topNav992">
        <div class="col3">
            <div class="homebraLi2" style="padding: 0;">
                <div id="ms" class="ms" style="height: 317px;">
                    <div class="msw">
                        <div class="mswin">
                            <ul class="p">
                                <li class="marketL" h="#" i="0">
                                    <div class="focusMarket">
                                        <%var index = 0;
                                          foreach (var shopinfo in marketInfo.MarketShopList.Where(c => marketInfo.MarketStoreyList.Where(f => (ECommon.QuerySearchMarketStorey != "" && f.id == ECommon.QuerySearchMarketStorey) || (ECommon.QuerySearchMarketStorey == "")).Select(e => e.title).Contains(c.marketstorey)))
                                          { %>
                                        <%if (index == 0)
                                          { %>
                                        <a href="<%=string.Format(EnUrls.ShopInfoIndex, shopinfo.id) %>" class="l" target="_blank">
                                            <img src="<%=EnFilePath.GetShopThumbPath(shopinfo.id, shopinfo.thumb) %>" height="278"
                                                width="372" alt="<%=shopinfo.title %>" /><span><label class="label0"><img src="<%=EnFilePath.GetBrandLogoPath(shopinfo.brandid, shopinfo.brandlogo) %>"
                                                    width="196" height="70" alt="<%=shopinfo.title %>" /></label><label class="label2"><b>品牌：</b><i><%=shopinfo.brandtitle %></i>
                                                        <b>风格：</b><i><%=ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "3", (ECBrand.GetBrandsInfo("where brandid=" + shopinfo.brandid) ?? new EnBrands()).style, ',', " ")%></i> <b>楼层：</b><%=shopinfo.marketstorey %></label></span></a>
                                        <%}
                                          else
                                          { %>
                                        <a href="<%=string.Format(EnUrls.ShopInfoIndex, shopinfo.id)%>" class="r" target="_blank"
                                            style="float: left;">
                                            <img src="<%=EnFilePath.GetShopThumbPath(shopinfo.id, shopinfo.thumb)%>" height="136"
                                                width="181" alt="<%=shopinfo.title%>" /><span><label class="label0"><img src="<%=EnFilePath.GetBrandLogoPath(shopinfo.brandid, shopinfo.brandlogo)%>"
                                                    width="108" height="35" alt="<%=shopinfo.title%>" /></label><label class="label2"><b>品牌：</b><i><%=shopinfo.brandtitle%></i><br />
                                                        <b>风格：</b><i><%=ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "3", (ECBrand.GetBrandsInfo("where brandid=" + shopinfo.brandid) ?? new EnBrands()).style, ',', " ")%></i><br />
                                                        <b>楼层：</b><%=shopinfo.marketstorey%></label></span></a>
                                        <%} %>
                                        <%index++; if (index > 6) break;
                                      }
                                      if (index == 0)
                                      {
                                          Response.Write("<a href=\"javascript:;\" target=\"_blank\" style=\"display:block;\"><img src=\"" + ECommon.WebResourceUrlToWeb + "/images/fnotbrand.jpg\" alt=\"暂无店铺\" height=\"278\" width=\"929\" /></a>");
                                      } %>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="width: 1px; height: 100%; position: absolute; top: 0px; left: 0px;" id="bodyHeightBox">
    </div>
    <div style="width: 0; height: 12px;">
    </div>
    <div id="floatBar" class="layout_a" style="top: 0; right: 0;">
        <div class="layout_a_inner">
            <div id="floatBarList" class="list_a">
                <div class="productList2" style="margin-top: 0;">
                    <div id="" class="promotionsR1" style="background-color: White; height: auto;">
                        <div class="promotions">
                            <span></span>品牌查询</div>
                        <div class="companySearch">
                            <form method="get" action="/search.aspx">
                            <input type="hidden" name="type" value="marketshop" title="onlymarketshop" id="onlymarketshop" />
                            <input type="hidden" name="mid" value="<%=ECommon.QueryMid %>" />
                            <input style="width: 5px; margin: 0; padding: 0; background: none; border: 0;" />
                            <input type="text" name="key" class="input1" id="marketSearchkey" />
                            <input type="image" src="<%=ECommon.WebResourceUrlToWeb %>/images/marketSearch.gif"
                                onmousemove="this.src='<%=ECommon.WebResourceUrlToWeb %>/images/marketSearchhover.gif'"
                                onmouseout="this.src='<%=ECommon.WebResourceUrlToWeb %>/images/marketSearch.gif'" />
                            <i class="clearfix"></i>
                            <script type="text/javascript">
                                $(function () {
                                    $('#marketSearchkey').oms_autocomplate({ url: "/ajax/search.ashx<%=Request.Url.Query %>", paramTypeSelector: "#onlymarketshop" });
                                });
                            </script>
                            </form>
                        </div>
                        <i class="clearfix"></i>
                        <div class="treeSubNavv1">
                            <ul id="tree_letter">
                                <%for (var i = 65; i < 91; i++)
                                  {
                                      Response.Write(msslist.Any(c => c.BrandInfo.letter != null && c.BrandInfo.letter.Substring(0, 1).Equals(((char)i).ToString(), StringComparison.OrdinalIgnoreCase))
                                          ?
                                          ("<li ><a href=\"#" + ((char)i) + "\">" + ((char)i) + "</a></li>")
                                          :
                                          ("<li class=\"none\">" + ((char)i) + "</li>"));
                                  }%>
                            </ul>
                        </div>
                        <div id="treev1" class="treev1" style="height: 1400px;">
                            <ul>
                                <% foreach (var g in msslist.Where(c => c.BrandInfo.letter != null && c.BrandInfo.letter.Length > 0).GroupBy(c => c.BrandInfo.letter[0].ToString().ToUpper()).OrderBy(c => c.Key))
                                   { %>
                                <li id="letter1" class="root"><b>
                                    <%=g.Key%>
                                    <s>(<%=g.Count()%>)</s><a href="#" name="<%=g.Key%>"></a></b>
                                    <ul>
                                        <% foreach (var p in g)
                                           { %>
                                        <li><a class="mainBrand" href="<%=string.Format(EnUrls.ShopInfoIndex, p.shopid) %>"
                                            target="_blank"><big>
                                                <%=p.BrandInfo.title %></big><%if (p.shopareacode != null && p.shopareacode.Length > 0)
                                                                     { %>
                                            <div class="auto_BDBDBD auto_item_right" style="width: 45px; top: 7px;">
                                                <%=p.storeytitle %></div>
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
    <div class="homebrandsc" style="margin-top: 0; ">
        <div class="topNav992 central" style="background: #fff;min-height:800px;">
            <div class="productList1" style="margin-top: 0;">
                <%--<div class="marketFloor">
                    <div class="marketFloorTrim1" id="marketFloorTrim1" style="width: 755px">
                        <div class="hd r">
                            <ul>
                                <%foreach (EnWebMarket.MarketStorey s in marketInfo.MarketStoreyList)
                                  { %>
                                <li><a href="#">
                                    <%=s.title %></a></li>
                                <%} %>
                            </ul>
                        </div>
                        <div class="bd l" style="width: 721px" id="topstorey">
                            <%foreach (EnWebMarket.MarketStorey s in marketInfo.MarketStoreyList)
                              { %>
                            <div class="item">
                                <img src="<%=EnFilePath.GetMarketStoreyThumbPath(s.id,s.thumb)%>" /><p>
                                    点击放大<%=s.title %>楼层图</p>
                            </div>
                            <%} %>
                            <script type="text/javascript">
                                $("#topstorey").find(".item:first").css("display", "block");
                            </script>
                        </div>
                    </div>
                    <div class="clearfix">
                    </div>
                </div>--%>
                <div class="productList12" style="margin-top: 0;">
                    <div class="productList121">
                        <ul class="pr12-ti pr12-tiTrim1">
                            <li class="li0"><a href="<%=string.Format(EnUrls.MarketInfoBrandList,  ECommon.QueryMid, "", ECommon.QuerySearchSort, ECommon.QueryPageIndex) %>"
                                class="<%=UiCommon.QueryStringCur("msid", "", "", "pr12-tia pr12-tiaTrim1") %>">
                                所有楼层</a></li>
                            <%--<li><a href="#" class="pr12-tia pr12-tiaTrim1">1楼</a></li>--%>
                            <%foreach (EnWebMarket.MarketStorey s in marketInfo.MarketStoreyList)
                              { %>
                            <li><a href="<%=string.Format(EnUrls.MarketInfoBrandList, ECommon.QueryMid, s.id, ECommon.QuerySearchSort, ECommon.QueryPageIndex) %>"
                                class="<%=UiCommon.QueryStringCur("msid", s.id.ToString(), "", "pr12-tia pr12-tiaTrim1") %>">
                                <%=s.title %></a></li>
                            <%} %>
                        </ul>
                        <div class="pr12-fy">
                            <a href="<%=NextUrl %>" class="xyy">下一页</a><span><%=AspNetPager1.CurrentPageIndex %>/<%=AspNetPager1.PageCount %></span><a
                                href="<%=PrvUrl %>" style="float: right;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/product_19.gif" /></a></div>
                    </div>
                    <div class="productList122">
                        <span class="s1">快速分类</span>
                        <%--<div class="pr_xl">
                            <%=sortTitle%>
                            <ul>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoBrandList,ECommon.QueryMid, ECommon.QuerySearchMarketStorey,  "_t1", ECommon.QueryPageIndex) %>">
                                    产品名称</a></li>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoBrandList,ECommon.QueryMid, ECommon.QuerySearchMarketStorey,"_t1",ECommon.QueryPageIndex) %>">
                                    名称降序</a></li>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t2","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoBrandList,ECommon.QueryMid, ECommon.QuerySearchMarketStorey,"_t2",ECommon.QueryPageIndex) %>">
                                    名称升序</a></li>
                            </ul>
                        </div>
                        <div class="pr_xl">
                            <%=sortDate %>
                            <ul>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoBrandList,ECommon.QueryMid, ECommon.QuerySearchMarketStorey,"_d1",ECommon.QueryPageIndex) %>">
                                    更新时间</a></li>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoBrandList,ECommon.QueryMid, ECommon.QuerySearchMarketStorey,"_d1",ECommon.QueryPageIndex) %>">
                                    由近到远</a></li>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d2","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoBrandList,ECommon.QueryMid,  ECommon.QuerySearchMarketStorey,  "_d2",ECommon.QueryPageIndex) %>">
                                    由远到近</a></li>
                            </ul>
                        </div>
                        <div class="pr_xl">
                            <%=sortHot %>
                            <ul>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoBrandList,ECommon.QueryMid, ECommon.QuerySearchMarketStorey,"_h1",ECommon.QueryPageIndex) %>">
                                    推荐产品</a></li>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoBrandList,ECommon.QueryMid, ECommon.QuerySearchMarketStorey,"_h1",ECommon.QueryPageIndex) %>">
                                    由高到低</a></li>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h2","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoBrandList,ECommon.QueryMid, ECommon.QuerySearchMarketStorey,"_h2",ECommon.QueryPageIndex) %>">
                                    由低到高</a></li>
                            </ul>
                        </div>
                        <label for="supportDIY"><input name="supprotDIY" id="supportDIY" type="checkbox" value="" /><s>支持定制</s></label>--%>
                        <div class="pr_xl">
                            <%=ECommon.QuerySearchStyle != "" ? (ECConfig.GetConfigInfo("where module=103 and type=3 and " + (TRECommon.TypeConverter.StrToInt(ECommon.QuerySearchStyle) > 0 ? "value=" + ECommon.QuerySearchStyle : "title='" + ECommon.QuerySearchStyle + "'"))??new EnConfig()).title : "所有风格" %>
                            <ul>
                                <li><a href="<%=string.Format("/market/{0}/brand-{1}-{2}-{3}-{4}-{5}-{6}.aspx", ECommon.QueryMid, ECommon.QuerySearchMarketStorey, ECommon.QuerySearchSort, ECommon.QueryPageIndex, ECommon.QuerySearchBrand,"", ECommon.QuerySearchMaterial) %>">所有风格</a></li>
                            <%foreach (var s in ECConfig.GetConfigList(" module=103 and type=3"))
                              { %>
                            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("style", s.value, "", "pr_xla") %>" title="<%=s.title %>" href="<%=string.Format("/market/{0}/brand-{1}-{2}-{3}-{4}-{5}-{6}.aspx", ECommon.QueryMid, ECommon.QuerySearchMarketStorey, ECommon.QuerySearchSort, ECommon.QueryPageIndex, ECommon.QuerySearchBrand,s.value, ECommon.QuerySearchMaterial) %>"><%=s.title %></a></li>
                            <%} %>
                            </ul>
                        </div>
                        <div class="pr_xl">
                            <%=ECommon.QuerySearchMaterial != "" ? leftString((ECConfig.GetConfigInfo("where module=103 and type=4 and " + (TRECommon.TypeConverter.StrToInt(ECommon.QuerySearchMaterial) > 0 ? "value=" + ECommon.QuerySearchMaterial : "title='" + ECommon.QuerySearchMaterial + "'"))??new EnConfig()).title, 5) : "所有材质" %>
                            <ul>
                            <li><a href="<%=string.Format("/market/{0}/brand-{1}-{2}-{3}-{4}-{5}-{6}.aspx", ECommon.QueryMid, ECommon.QuerySearchMarketStorey, ECommon.QuerySearchSort, ECommon.QueryPageIndex, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, "") %>">所有材质</a></li>
                            <%foreach (var s in ECConfig.GetConfigList(" module=103 and type=4"))
                              { %>
                            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("material", s.value, "", "pr_xla") %>" title="<%=s.title %>" href="<%=string.Format("/market/{0}/brand-{1}-{2}-{3}-{4}-{5}-{6}.aspx", ECommon.QueryMid, ECommon.QuerySearchMarketStorey, ECommon.QuerySearchSort, ECommon.QueryPageIndex, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, s.value) %>"><%=s.title.Length > 5 ? s.title.Substring(0,5) + "..." : s.title %></a></li>
                            <%} %>
                            </ul>
                        </div>
                    </div>
                </div>
                <%--<div class="d0" style="padding: 10px 20px 0;">
                    <strong>卖场推荐品牌</strong>&nbsp;&nbsp;&nbsp;<a href="#" target="_blank">弗劳思丹</a> <a
                        href="#" target="_blank">木之本</a> <a href="#" target="_blank">全友家私</a> <a href="#"
                            target="_blank">玉庭家具</a> <a href="#" target="_blank">甘迪</a> <a href="#" target="_blank">
                                斯曼克</a> <a href="#" target="_blank">卡瑞迪</a> <a href="#" target="_blank">锐驰</a>
                    <a href="#" target="_blank">力排库斯</a> <a href="#" target="_blank">艾菲尔</a></div>--%>
                <div class="bkStyleWrap">
                    <div class="bkStyleWrapInner">
                    <%if (list.Count > 0)
                      { %>
                        <%foreach (EnWebMarketStoreyShop s in list)
                          { %>
                        <div class="bkStyle">
                            <div class="brandsDealerBj">
                                <div class="brandsDealer1" style="width:100%; height:70px; margin-right:0; text-align:center;">
                                    <a target="_blank" title="<%=s.shoptitle %>" href="<%=string.Format(EnUrls.ShopInfoIndex, s.shopid) %>">
                                        <img alt="<%=s.shoptitle %>" src="<%=EnFilePath.GetBrandLogoPath(s.BrandInfo.id, s.BrandInfo.logo) %>" width="196"
                                            height="70" /></a></div>
                                <div class="brandsDealer2">
                                    <p>
                                        <b>经销品牌：</b><font><%=s.BrandName.Replace(",", " ")%></font>
                                             <%if (!string.IsNullOrEmpty(s.qq))
                                               { %>
                                         <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=<%=s.qq%>&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:<%=s.qq%>:41" alt="点击这里给我发消息" title="点击这里给我发消息"></a>
                                            <%} %>
                                        </p>
                                    <p>
                                        <b>品牌风格：</b><font><%=s.BrandInfo.brands.Length > 0 ? ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "3", (ECBrand.GetBrandsInfo("where brandid=" + s.BrandInfo.id) ?? new EnBrands()).style, ',', " ") : "" %></font></p>
                                    <p>
                                        <b>所在楼层：</b><span class="gray"><%=s.storeytitle%></span></p>
                                    <div class="ph">
                                        <%=s.shopphone%></div>
                                    <p class="yh">
                                    <%if (promotionslist.Where(c => c.promotionsrelated.Any(p => p.shopid == s.shopid)).Count() > 0)
                                      { %>
                                      <%foreach (var pitem in promotionslist.Where(c => c.promotionsrelated.Any(p => p.shopid == s.shopid)))
                                        { %>
                                        <span class="s1"><a href="<%=string.Format(EnUrls.PromotionsInfo, pitem.id) %>" target="_blank"><%=pitem.title %></a></span>
                                        <label><span class="red">[优惠]</span></label></p>
                                        <%break;
                                        } %>
                                            <%}
                                      else
                                      { %>
                                        <span class="s1"><a href="#" target="_blank">欢迎来电电咨询优惠资讯！</a></span>
                                        <label><span class="red">[优惠]</span></label></p>
                                        <%}%>
                                    <p class="pv">
                                        <a target="_blank" href="<%=string.Format(EnUrls.ShopInfoProduct, s.shopid) %>">所有产品</a><a target="_blank" href="<%=string.Format(EnUrls.ShopInfoAddress, s.shopid) %>">联系方式</a><a target="_blank" href="<%=string.Format(EnUrls.CompanyInfoBrandList, s.BrandInfo.companyid, s.BrandInfo.id) %>">品牌介绍</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <%} %>
                        <%}
                      else
                      { %>
                      <div class="brandsgc" style="margin-top:0;"><img width="752" src="<%=ECommon.WebResourceUrlToWeb %>/images/noinfo.jpg" alt="notfound"></div>
                        <%} %>
                    </div>
                </div>
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="false" CurrentPageButtonClass="cpb"
                    CssClass="pager" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                    PrevPageText="上一页" PageSize="30">
                </webdiyer:AspNetPager>
            </div>
            <div class="productList2" style="margin-top: 0;">
                <%--<div class="homebraRight">
                    <div class="homebraRight1 homebraRight3" style="margin: 0">
                        <div class="promotions">
                            <span><a href="<%=string.Format(EnUrls.MarketInfoBrand,marketInfo.id) %>">更多</a></span>推荐入驻品牌</div>
                        <ul>
                            <%foreach (EnWebMarket.MarketBrand b in marketInfo.MarketBrandList)
                              { %>
                            <li><a href="<%=string.Format(EnUrls.CompanyInfoBrandList,b.companyid,b.id) %>">
                                <img src="<%=EnFilePath.GetBrandLogoPath(b.id,b.logo) %>" width="105" height="38"></a></li>
                            <%} %>
                        </ul>
                    </div>
                    <div class="homebraRight1 homebraRight3">
                        <div class="promotions">
                            <span><a href="<%=EnUrls.PromotionList%>">更多</a></span>促销信息</div>
                        <%=ECPromotion.GetPromotionHtml(ECPromotion.GetWebTopPromotionListToMarket(4,marketInfo.id))%>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>
   <ucfooter:footer ID="header3" runat="server" />
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
                //SIPAUTO_RivalHeader.style.top = scrollHeight - SIPAUTO_OtherTop + 'px';
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
            if (scrollHeight > SIPAUTO_OtherTop - parseInt($('#floatBar').css('top').replace('px', ''))) {
                SIPAUTO_RivalHeader.style.position = 'fixed';
                //SIPAUTO_RivalHeader.style.top = '0';
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
                e.preventDefault();
            });
        });
    </script>
</body>
</html>
