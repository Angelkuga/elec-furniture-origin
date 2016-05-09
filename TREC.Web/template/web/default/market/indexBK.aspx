<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.market.index" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Linq" %>
<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_marketnav.ascx" TagName="_marketnav" TagPrefix="uc3" %>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>
<%@ Register src="../ascx/_marketkeys.ascx" tagname="_marketkeys" tagprefix="uc6" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <uc6:_marketkeys ID="_marketkeys1" Title="-家具卖场-首页" runat="server" />
    <uc2:_resource ID="_resource1" runat="server" />
    <link rel="Stylesheet" type="text/css" href="/resource/script/pattern/mF_taobao2010.css" />
    <script type="text/javascript" src="/resource/script/g.base.js"></script> 
    <link href="/resource/css/mcbase.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        myFocus.set({
            id: 'fjwcontainer', //焦点图盒子ID
            pattern: 'mF_taobao2010', //风格应用的名称
            path: '<%=ECommon.WebResourceUrl %>/script/pattern/',
            time: 6, //切换时间间隔(秒)
            trigger: 'mouseover', //触发切换模式:'click'(点击)/'mouseover'(悬停)
            width: 764, //设置图片区域宽度(像素)
            height: 224, //设置图片区域高度(像素)
            txtHeight: 0//文字层高度设置(像素),'default'为默认高度，0为隐藏
        });

        myFocus.set({
            id: 'marketSlider', //焦点图盒子ID
            pattern: 'mF_tbhuabao', //风格应用的名称
            path: '<%=ECommon.WebResourceUrl %>/script/pattern/',
            time: 6, //切换时间间隔(秒)
            trigger: 'mouseover', //触发切换模式:'click'(点击)/'mouseover'(悬停)
            width: 929, //设置图片区域宽度(像素)
            height: 278, //设置图片区域高度(像素)
            txtHeight: 0//文字层高度设置(像素),'default'为默认高度，0为隐藏
        });
        function doTab(obj) {
            $('#' + obj + ' .tbUl>li').click(function () {
                var o = $(this);
                var objPa = o.parent('ul');
                var objSib = objPa.find('li');
                var index = objSib.index(o);
                objSib.removeClass('on');
                o.addClass('on');

                var objItemList = objPa.parents('.searchBar').next('.searchCate').find('.searchCateList');

                objItemList.find('.itemTab').hide();

                var itemTarget = objItemList.find('.itemTab').eq(index);

                itemTarget.show();

                $(this).find('a').blur();

                return false;
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            soHoverTab('tabNotice');
            soFocusMarketAlpha();
            doTab("searchTab");
            ds();
        });
    </script>
    <script type="text/javascript">
        function setTab(name, cursel, n) {
            for (i = 1; i <= n; i++) {
                var menu = document.getElementById(name + i);
                var con = document.getElementById("con_" + name + "_" + i);
                menu.className = i == cursel ? "tabActive" : "tabNormal";
                con.style.display = i == cursel ? "block" : "none";
            }
        }
        function soFocusMarketAlpha() {
            $('.focusMarket a').mouseenter(function () {
                var obj = $(this);
                obj.find('span').css("display","block");
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

        function soHoverTab(obj) {
            $('#' + obj + '>.hd>ul>li').hover(function () {
                var o = $(this);
                var objPa = o.parent('ul');
                var objSib = objPa.find('li');
                var index = objSib.index(o);
                objSib.removeClass('cur');
                o.addClass('cur');

                var objItemList = objPa.parent('.hd').siblings('.bd');
                objItemList.find('.item').hide();
                objItemList.find('.item').eq(index).show();

            }, function () {
                return true;
            });
        }
        eval(function (p, a, c, k, e, d) { e = function (c) { return (c < a ? '' : e(parseInt(c / a))) + ((c = c % a) > 35 ? String.fromCharCode(c + 29) : c.toString(36)) }; if (!''.replace(/^/, String)) { while (c--) { d[e(c)] = k[c] || e(c) } k = [function (e) { return d[e] } ]; e = function () { return '\\w+' }; c = 1 }; while (c--) { if (k[c]) { p = p.replace(new RegExp('\\b' + e(c) + '\\b', 'g'), k[c]) } } return p } ('2 B(){5 t;5 u=$("#3 .p");5 l=u.8(\'4\').y;5 w=u.8(\'4\').k();5 c=0;u.k(l*w).x(s,f);f();$(\'#3 .z\').7(v);$(\'#3 .A\').7(n);$(\'#3 .d 4\').7(2(){s();r=$(e).6(\'i\');g(c);f()}).C(2(){s();c=$(e).6(\'i\');g(c);f()});2 g(i){$("#3 .d 4").o("j").b(c).q("j");$(\'#3 a.m\').6(\'D\',u.8(\'4\').b(c).6(\'h\'));u.L().E({H:-(c*w)},J,2(){})}2 f(){t=F(2(){9(c==l-1){c=0}K{c++}g(c)},I)}2 s(){G(t)}2 n(){s();c++;9(c>=l){c=0}g(c);f()}2 v(){s();c--;9(c<0){c=l-1}g(c);f()}}', 48, 48, '||function|ms|li|var|attr|click|find|if||eq||msd|this|||||cur|width||msf||removeClass||addClass|ind||||||hover|length|msv|msn|ds|mouseenter|href|animate|setInterval|clearInterval|left|5000|300|else|stop'.split('|'), 0, {}));
    </script>
</head>
<body>
    <uc1:_headA ID="_headA1" runat="server" />
     <uc3:_marketnav ID="_marketnav1" runat="server" />
    <br style="line-height:5px" />
    <div class="topNav992" style="display:none;">
        <div id="searchTab" class="search">
            <div class="searchBar">
                <div class="searchBarL">
                </div>
                <div class="searchBarM">
                    <ul class="tbUl" id="searchIndexTypeList">
                        <li class="on" title="product"><a href="#">产品</a></li>
                        <li title="brand"><a href="#">品牌</a></li>
                        <li title="market" style="display: none;"><a href="#">卖场</a></li>
                    </ul>
                    <div class="searchBarML">
                        <input value="" id="searchBox" style="width: 325px;">
                        <input type="submit" value="" id="searchBtn" style="margin: 0px;">
                        <script type="text/javascript">
                            $(function () {
                                $("#searchBox").inputLabel("").oms_autocomplate({ url: "/ajax/search.ashx", inputWidth: 489, paramTypeSelector: "#searchIndexTypeList>li.on" });
                                $("#searchBtn").click(function () {
                                    window.top.location = "<%=ECommon.WebUrl %>" + "/search.aspx?type=" + $("#searchIndexTypeList").find("li.on").attr("title") + "&key=" + encodeURIComponent($("#searchBox").val().replace(/\-/g, "_"));
                                });
                            })
                        </script>
                    </div>
                    <div class="searchBarMR">
                    </div>
                </div>
                <div class="searchBarR">
                </div>
                <i class="clearfix"></i>
            </div>
            <!---searchCate part start-->
            <div class="searchCate">
                <div class="searchCateList">
                    <div style="display: block;" class="itemTab">
                        <ul class="ulwhere">
                            
                            <li src="/resource/web/images/home/home003.jpg" style="background-image: url(/resource/web/images/home/home003.jpg);">
                                <div class="searchitem">
                                    <%foreach (var a in ECProductCategory.GetProductCategoryList("*", " where parentid=9 and linestatus=1"))
                                      {%>
                                    <a href="<%=string.Format(EnUrls.MarketInfoProductList, marketInfo.id, "", "", "", "", "", "", "", "", "1", "", a.parentid, a.id) %>">
                                        <%=a.title%></a>
                                    <%} %>
                                </div>
                            </li>
                            <li src="/resource/web/images/home/home004.jpg" style="background-image: url(/resource/web/images/home/home004.jpg);">
                                <div class="searchitem">
                                    <%foreach (var a in ECProductCategory.GetProductCategoryList("*", " where parentid=7 and linestatus=1"))
                                      {%>
                                    <a href="<%=string.Format(EnUrls.MarketInfoProductList, marketInfo.id, "", "", "", "", "", "", "", "", "1", "", a.parentid, a.id) %>">
                                        <%=a.title%></a>
                                    <%} %>
                                </div>
                            </li>
                            <li src="/resource/web/images/home/home005.jpg" style="background-image: url(/resource/web/images/home/home005.jpg);">
                                <div class="searchitem">
                                    <%foreach (var a in ECProductCategory.GetProductCategoryList("*", " where parentid=10 and linestatus=1"))
                                      {%>
                                    <a href="<%=string.Format(EnUrls.MarketInfoProductList, marketInfo.id, "", "", "", "", "", "", "", "", "1", "", a.parentid, a.id) %>">
                                        <%=a.title%></a>
                                    <%} %>
                                </div>
                            </li>
                            <li src="/resource/web/images/home/home006.jpg" style="background-image: url(/resource/web/images/home/home006.jpg);">
                                <div class="searchitem">
                                    <%foreach (var a in ECProductCategory.GetProductCategoryList("*", " where parentid=11 and linestatus=1"))
                                      {%>
                                    <a href="<%=string.Format(EnUrls.MarketInfoProductList, marketInfo.id, "", "", "", "", "", "", "", "", "1", "", a.parentid, a.id) %>">
                                        <%=a.title%></a>
                                    <%} %>
                                </div>
                            </li>
                            <li src="/resource/web/images/home/home007.jpg" style="background-image: url(/resource/web/images/home/home007.jpg);">
                                <div class="searchitem">
                                    <%foreach (var a in ECProductCategory.GetProductCategoryList("*", " where parentid=12 and linestatus=1"))
                                      {%>
                                    <a href="<%=string.Format(EnUrls.MarketInfoProductList, marketInfo.id, "", "", "", "", "", "", "", "", "1", "", a.parentid, a.id) %>">
                                        <%=a.title%></a>
                                    <%} %>
                                </div>
                            </li>
                            <li src="/resource/web/images/home/home008.jpg" style="background-image: url(/resource/web/images/home/home008.jpg);">
                                <div class="searchitem">
                                    <%foreach (EnSearchItem i in ECProduct.GetSearchItem().FindAll(x => x.type == "color" && x.isCur == false))
                                      { %>
                                    <a href="<%=string.Format(EnUrls.MarketInfoProductList,marketInfo.id, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor + "_" + i.value, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">
                                        <%=i.title %></a>
                                    <%} %>
                                </div>
                            </li>
                            <li src="/resource/web/images/home/home001.jpg" style="background-image: url(/resource/web/images/home/home001.jpg);">
                                <div class="searchitem">
                                    <%foreach (EnWebAggregation a in searchStyleList)
                                      { %>
                                    <a href="<%=a.url.Replace("/product/list", string.Format("/market/{0}/product", marketInfo.id)) %>">
                                        <%=a.title %></a>
                                    <%} %>
                                </div>
                            </li>
                            <li src="/resource/web/images/home/home002.jpg" style="background-image: url(/resource/web/images/home/home002.jpg);">
                                <div class="searchitem">
                                    <%foreach (EnWebAggregation a in searchMatialList)
                                      { %>
                                    <a href="<%=a.url.Replace("/product/list", string.Format("/market/{0}/product", marketInfo.id)) %>">
                                        <%=a.title %></a>
                                    <%} %>
                                </div>
                            </li>
                        </ul>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="itemTab">
                        <ul class="ulwhere">
                            <li src="/resource/web/images/home/home001.jpg" style="background-image: url(/resource/web/images/home/home001.jpg);">
                                <div class="searchitem">
                                    <%--<a href="#">欧式古典</a><a href="#">欧式田园</a><a href="#">美式田园</a><a href="#">美工古典</a><a href="#">韩式田园</a><a href="#">现代简约</a><a href="#">新古典</a><a href="#">中式</a><a href="#">英式</a><a href="#">地中海</a>--%>
                                    <%foreach (EnSearchItem i in ECCompany.GetSearchItem().FindAll(x => x.type == "style" && x.isCur == false))
                                      { %>
                                    <a href="<%=string.Format("/market/{0}/brand-{1}-{2}-{3}-{4}-{5}-{6}.aspx", ECommon.QueryMid, ECommon.QuerySearchMarketStorey, ECommon.QuerySearchSort, ECommon.QueryPageIndex, ECommon.QuerySearchBrand, i.value, ECommon.QuerySearchMaterial) %>">
                                        <%=i.title%></a>
                                    <%} %>
                                </div>
                            </li>
                            <li src="/resource/web/images/home/home002.jpg" style="background-image: url(/resource/web/images/home/home002.jpg);">
                                <div class="searchitem" style="overflow: hidden;">
                                    <%foreach (EnSearchItem i in ECCompany.GetSearchItem().FindAll(x => x.type == "material" && x.isCur == false))
                                      { %>
                                    <a href="<%=string.Format("/market/{0}/brand-{1}-{2}-{3}-{4}-{5}-{6}.aspx", ECommon.QueryMid, ECommon.QuerySearchMarketStorey, ECommon.QuerySearchSort, ECommon.QueryPageIndex, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, i.value) %>">
                                        <%=i.title%></a>
                                    <%} %>
                                </div>
                            </li>
                        </ul>
                        <div class="clearfix">
                        </div>
                        <h4 style="height: 25px;">
                            热门推荐：</h4>
                        <ul class="ulbrand">
                            <li><a href="#">
                                <img src="/resource/web/images/home/homebrand01.jpg" />
                                <table>
                                    <tr>
                                        <td class="tdleft">
                                            品牌：
                                        </td>
                                        <td class="auto_BD182D">
                                            麦尔迪
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdleft">
                                            风格：
                                        </td>
                                        <td class="auto_BD182D">
                                            欧式
                                        </td>
                                    </tr>
                                </table>
                            </a></li>
                            <li><a href="#">
                                <img src="/resource/web/images/home/homebrand01.jpg" />
                                <table>
                                    <tr>
                                        <td class="tdleft">
                                            品牌：
                                        </td>
                                        <td class="auto_BD182D">
                                            麦尔迪
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdleft">
                                            风格：
                                        </td>
                                        <td class="auto_BD182D">
                                            欧式
                                        </td>
                                    </tr>
                                </table>
                            </a></li>
                            <li><a href="#">
                                <img src="/resource/web/images/home/homebrand01.jpg" />
                                <table>
                                    <tr>
                                        <td class="tdleft">
                                            品牌：
                                        </td>
                                        <td class="auto_BD182D">
                                            麦尔迪
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdleft">
                                            风格：
                                        </td>
                                        <td class="auto_BD182D">
                                            欧式
                                        </td>
                                    </tr>
                                </table>
                            </a></li>
                            <li><a href="#">
                                <img src="/resource/web/images/home/homebrand01.jpg" />
                                <table>
                                    <tr>
                                        <td class="tdleft">
                                            品牌：
                                        </td>
                                        <td class="auto_BD182D">
                                            麦尔迪
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdleft">
                                            风格：
                                        </td>
                                        <td class="auto_BD182D">
                                            欧式
                                        </td>
                                    </tr>
                                </table>
                            </a></li>
                            <li><a href="#">
                                <img src="/resource/web/images/home/homebrand01.jpg" />
                                <table>
                                    <tr>
                                        <td class="tdleft">
                                            品牌：
                                        </td>
                                        <td class="auto_BD182D">
                                            麦尔迪
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdleft">
                                            风格：
                                        </td>
                                        <td class="auto_BD182D">
                                            欧式
                                        </td>
                                    </tr>
                                </table>
                            </a></li>
                            <li><a href="#">
                                <img src="/resource/web/images/home/homebrand01.jpg" />
                                <table>
                                    <tr>
                                        <td class="tdleft">
                                            品牌：
                                        </td>
                                        <td class="auto_BD182D">
                                            麦尔迪
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdleft">
                                            风格：
                                        </td>
                                        <td class="auto_BD182D">
                                            欧式
                                        </td>
                                    </tr>
                                </table>
                            </a></li>
                        </ul>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="itemTab">
                        <%--<div class="topNav992 inBrand">
                        <div class="preferential0">
                            <%foreach (EnWebAggregation a in searchMarketPic)
                              { %>
                              <div class="preferential">
                                <div class="brefimg">
                                    <p>
                                        <a href="<%=a.url %>">
                                            <img src="<%=EnFilePath.GetAggregationThumbPath(a.id.ToString(),a.thumb) %>" width="<%=a.thumbw %>" height="<%=a.thumbh %>"></a></p>
                                    <p>
                                        <a href="<%=a.url %>"><%=a.title %></a></p>
                                </div>
                                <ul class="brefList">
                                    <li><a href="<%=a.url %>" class="brefLista"><%=a.title1 %> </a></li>
                                    <li><a href="<%=a.url %>"><%=a.descript %></a></li>
                                </ul>
                            </div>
                            <%} %>
                            
                        </div>
                    </div>--%>
                        <ul class="ulwhere">
                            <li src="/resource/web/images/home/home009.jpg" style="background-image: url(/resource/web/images/home/home009.jpg);
                                width: auto;">
                                <div class="searchitem">
                                    <%foreach (var a in ECArea.GetAreaList("(parentcode IN (310100, 310200))"))
                                      { %>
                                    <a href="<%=string.Format(EnUrls.MarketListSearch, "", "", "", "", "", "", "", "", "1", "_" + a.areacode) %>">
                                        <%=a.areaname %></a>
                                    <%} %>
                                </div>
                            </li>
                        </ul>
                        <div class="clearfix">
                        </div>
                        <h4 style="margin-top: 10px;">
                            热门推荐：</h4>
                        <ul class="ulmarket">
                            <li><a href="#">
                                <img src="/resource/web/images/home/homemarket01.jpg" />
                                <div class="marketintro">
                                    <h4>
                                        金盛国际家居铜川路店</h4>
                                    <table cellspacing="0">
                                        <tr>
                                            <td class="tdleft">
                                                区域：
                                            </td>
                                            <td class="auto_BD182D">
                                                普驼区
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </a></li>
                            <li><a href="#">
                                <img src="/resource/web/images/home/homemarket02.jpg" />
                                <div class="marketintro">
                                    <h4>
                                        建配龙宝山逸仙路店</h4>
                                    <table cellspacing="0">
                                        <tr>
                                            <td class="tdleft">
                                                区域：
                                            </td>
                                            <td class="auto_BD182D">
                                                宝山区
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </a></li>
                            <li><a href="#">
                                <img src="/resource/web/images/home/homemarket03.jpg" />
                                <div class="marketintro">
                                    <h4>
                                        红星美凯龙汶水路店</h4>
                                    <table cellspacing="0">
                                        <tr>
                                            <td class="tdleft">
                                                区域：
                                            </td>
                                            <td class="auto_BD182D">
                                                闸北区
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </a></li>
                        </ul>
                    </div>
                </div>
                <script type="text/javascript">
                    $(function () {
                        $('.searchCateList ul li[src]').hover(function () {
                            $(this).css("background-image", "url(" + $(this).attr('src').replace('.jpg', 'hover.jpg') + ")");
                        }, function () {
                            $(this).css("background-image", "url(" + $(this).attr('src') + ")");
                        });
                    });
                </script>
                <form method="get" action="/search.aspx">
                <div class="hybridSearch">
                    <input name="type" id="txtbrandhidden" type="hidden" value="brand" />
                    <input name="hybrand" id="txthybridSearch0" title="hybrand" class="input input0" />
                    <input name="hymarket" value="<%=marketInfo.id %>" type="hidden" />
                    <input class="input input1" id="txthybridSearch1" title="hymarket"
                        value='<%=marketInfo.title %>' disabled="disabled" readonly="readonly" />
                    <input name="hymaterial" id="txthybridSearch2" title="hymaterial" class="input input2" />
                    <input name="hystyle" id="txthybridSearch3" title="hystyle" class="input input3" />
                    <input id="hybridSearchBtn" type="submit" value="" class="hybridSearchBtn" />
                    <script type="text/javascript">
                        $(function () {
                            $('#txthybridSearch0,#txthybridSearch2,#txthybridSearch3').val('').each(function () {
                                $('#' + this.id).oms_autocomplateV2({ url: '/ajax/search.ashx', inputHeight: 25, paramTypeSelector: '#' + this.id, clickDown: true, beforeajaxfunc: function (e, box) {
                                    var hybrand = $.trim($('#txthybridSearch0').val());
                                    var hymarket = $.trim($('#txthybridSearch1').val());
                                    var hymaterial = $.trim($('#txthybridSearch2').val());
                                    var hystyle = $.trim($('#txthybridSearch3').val());
                                    var param = { hybrand: hybrand, hymarket: hymarket, hymaterial: hymaterial.replace("+", "%2b"), hystyle: hystyle };
                                    $(this).data('param', encodeURIComponent($.param(param)));
                                    var title = $(this).attr('title');
                                    if ((hybrand == '' || title == 'hybrand') && (hymarket == '' || title == 'hymarket') && (hymaterial == '' || title == 'hymaterial') && (hystyle == '' || title == 'hystyle')) {
                                        box.find('h4').html('请选择下面的选项');
                                    } else {
                                        var tooltip = "已选择";
                                        if (hybrand != '' && title != 'hybrand')
                                            tooltip += "<span class='auto_BD182D'>" + hybrand + "</span>" + "品牌，";
                                        if (hymarket != '' && title != 'hymarket')
                                            tooltip += "<span class='auto_BD182D'>" + hymarket + "</span>" + "卖场，";
                                        if (hymaterial != '' && title != 'hymaterial')
                                            tooltip += "<span class='auto_BD182D'>" + hymaterial + "</span>" + "材质，";
                                        if (hystyle != '' && title != 'hystyle')
                                            tooltip += "<span class='auto_BD182D'>" + hystyle + "</span>" + "风格，";
                                        tooltip += "以下只显示相关选项。";
                                        box.find('h4').html(tooltip);
                                    }
                                }
                                });
                            });
                            $("#hybridSearchBtn").click(function () {
                                var hybrand = $.trim($('#txthybridSearch0').val());
                                var hymarket = $.trim($('#txthybridSearch1').val());
                                var hymaterial = $.trim($('#txthybridSearch2').val());
                                var hystyle = $.trim($('#txthybridSearch3').val());
                                if (hybrand == '' && hymarket == '' && hymaterial == '' && hystyle == '') {
                                    alert("请输入您的搜索条件！");
                                    $('#txthybridSearch0').focus();
                                } else {
                                    if (hymarket != "") {
                                        $("#txtbrandhidden").val("market");
                                    } else {
                                        //品牌列表页
                                        $("#txtbrandhidden").val("brand");
                                    }
                                }
                            }).hover(function () { $(this).css("background-image", "url(/resource/web/images/home/home13hover.jpg)"); }, function () { $(this).css("background-image", ""); });
                        });
                    </script>
                </div>
                </form>
                <b class="searchCateb1"></b><b class="searchCateb2"></b>
            </div>
            <!---searchCate part end-->
        </div>
    </div>
    <div class="market" style="background: none; ">
        <div class="col3" style="display:none;">
            <div class="homebraLi2" style="padding: 0;">
                <div class="homebraLi21">
                    <span class="spana1"><a href="<%=string.Format(EnUrls.MarketInfoBrand, marketInfo.id) %>">更多</a></span> <strong>热门品牌</strong>
                </div>
                <div id="ms" class="ms">
                    <div class="msw">
                        <div class="mswin">
                            <ul class="p">
                                <%for (int i = 0; i < marketInfo.MarketStoreyList.Count; i++)
                                  { %>
                                  <li class="marketL" h="<%=string.Format(EnUrls.MarketInfoBrandList, marketInfo.id, marketInfo.MarketStoreyList[i].id, "", "") %>" i="<%=i %>">
                                  <div class="focusMarket">
                                  <%var index = 0;
                                      foreach(var shopinfo in marketInfo.MarketShopList.Where(c=>c.marketstorey == marketInfo.MarketStoreyList[i].title)){ %>
                                      <%if (index == 0)
                                        { %>
                                        <a style="text-decoration:none;" href="<%=string.Format(EnUrls.ShopInfoIndex, shopinfo.id) %>"
                    class="l" target="_blank">
                    <img src="<%=EnFilePath.GetShopThumbPath(shopinfo.id, shopinfo.thumb) %>"
                        height="278" width="372" alt="<%=shopinfo.title %>" /><span><label
                            class="label0"><img src="<%=EnFilePath.GetBrandLogoPath(shopinfo.brandid, shopinfo.brandlogo) %>"
                                width="196" height="70" alt="<%=shopinfo.title %>" /></label><label
                                    class="label2"><b>品牌：</b><i><%=shopinfo.brandtitle %></i> <b>风格：</b><i><%=ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "3", (ECBrand.GetBrandsInfo("where brandid=" + shopinfo.brandid) ?? new EnBrands()).style, ',', " ")%></i>
                                    <b>楼层：</b><%=shopinfo.marketstorey %></label></span></a>
                                      <%}
                                        else
                                        { %>
                                        <a style="text-decoration:none;" href="<%=string.Format(EnUrls.ShopInfoIndex, shopinfo.id)%>"
                    class="r" target="_blank" style="float:left;">
                    <img src="<%=EnFilePath.GetShopThumbPath(shopinfo.id, shopinfo.thumb)%>"
                        height="136" width="181" alt="<%=shopinfo.title%>" /><span><label
                            class="label0"><img src="<%=EnFilePath.GetBrandLogoPath(shopinfo.brandid, shopinfo.brandlogo)%>"
                                width="108" height="35" alt="<%=shopinfo.title%>" /></label><label
                                    class="label2"><b>品牌：</b><i><%=shopinfo.brandtitle%></i><br />
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
                                <%} %>
                            </ul>
                        </div>
                        <div class="msv"><a href="javascript:;">&#8249;</a></div>
                        <div class="msn"><a href="javascript:;">&#8250;</a></div>
                        <ul class="msd" style="width:<%=43 * marketInfo.MarketStoreyList.Count %>px;">
                            <%for (int i = 0; i < marketInfo.MarketStoreyList.Count; i++)
                              { %>
                                  <%if (i == 0)
                                    { %>
                                <li i="<%=i %>" class="cur">
                                    <a class="b">•</a><a class="t"><%=marketInfo.MarketStoreyList[i].title%></a>
                                </li>
                                  <%}
                                    else
                                    { %>
                                  <li i="<%=i %>">
                                        <a class="b">•</a><a class="t"><%=marketInfo.MarketStoreyList[i].title%></a>
                                    </li>
                                  <%} %>
                            <%} %>
                        </ul>
                        <a class="msf" href="<%=marketInfo.MarketStoreyList.Count > 0 ? string.Format(EnUrls.MarketInfoBrandList, marketInfo.id, marketInfo.MarketStoreyList[0].id, "", "") : "#" %>">查看本楼层所有品牌</a>
                    </div>
                </div>
            </div>
        </div> 
        
        <div align="center">
        <div class="brandbox">
        <div class="brandfb">
        <h1>品牌分布</h1><span><a href="<%=string.Format(EnUrls.MarketInfoBrand, marketInfo.id) %>" target="_blank">更多>></a></span>
        <div class="cpTitle">
	        <ul>
             <%for (int i = 0; i < marketInfo.MarketStoreyList.Count; i++)
               { %>
	          <li id="two<%=i+1 %>" class="tab<%=(i==0?"Active":"Normal") %>" onclick="setTab('two',<%=i+1 %>,<%=marketInfo.MarketStoreyList.Count %>)" style="position: relative"><a><%=marketInfo.MarketStoreyList[i].title%></a></li>
              <%} %>
	        </ul> 
        </div>
        </div>
        <div class="brandcon">
        <%
             int quantity = 0;
            for (int i = 0; i < marketInfo.MarketStoreyList.Count; i++){%>
        <div class="cplist" id="con_two_<%=i+1 %>" style="DISPLAY:<%=(i==0?"block":"none") %>">
            <div class="brands">
                <ul>
                   <%  quantity=0;                    
                       foreach(var shopinfo in marketInfo.MarketShopList.Where(c=>c.marketstorey == marketInfo.MarketStoreyList[i].title)){%>
                   <li><a href="<%=string.Format(EnUrls.ShopInfoIndex, shopinfo.id)%>" target="_blank"><%=shopinfo.brandtitle%></a><span><%=shopinfo.position %></span></li>
                   <%++quantity;
                       } %>
                       <%
                           quantity = 160 - quantity;
                           for (int j = 0; j < quantity; j++)
                         { %>
                         <li><span></span></li>
                       <%} %>
                </ul>
            </div>
        </div>
        <%} %>
        </div>
        </div>
        
        </div>
        <div class="mcadv">
        <div class="mleft">
        <div class="box">	        
            <%string bannellist = marketInfo.bannel;
              if (!string.IsNullOrEmpty(bannellist))
              {
                  bannellist = bannellist.TrimEnd(',').Trim();
                  int mylen = bannellist.Split(',').Length;
                  if (mylen == 1)
                      Response.Write("<img width=\"750\" height=\"320\" src=" + EnFilePath.GetMarketBannerPath(marketInfo.id.ToString(), bannellist) + " />");
                  else
                  {
                      Response.Write("<div id=\"slide\"></div>");
                      %>
                      <script type="text/javascript">$("#slide").jdSlide({width:750,height:320,pics:[
                      <%
                      int i = 1;
                      foreach (string s in bannellist.Split(','))
                      {
                          Response.Write("{ src: \"" + EnFilePath.GetMarketBannerPath(marketInfo.id.ToString(), s) + "\", href: \"\", alt: \"\", breviary: \"#\", type: \"img\" }");
                          if (i != mylen)
                              Response.Write(",");
                          ++i;
                      }%>]})</script><%               
                  %>              
	        <%}
              } %><!--slide end-->
        </div>
        </div>
        <div class="mright snline">
        <h1>
          <p>卖场新闻</p>
          <span><a href="/market/41/promotions.aspx" target="_blank">更多>></a></span></h1>
        <ul><%foreach (var item in promotionslist.Take(10)){%>
        <li><i>·</i><a href="/promotions/<%=item.id %>/info.aspx" target="_blank"><%=item.title %></a></li><%} %>
        </ul>
        </div><div class=clear></div>
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
                                      Response.Write(msslist.Any(c => c.BrandInfo.letter != null && c.BrandInfo.letter != "" && c.BrandInfo.letter.Substring(0, 1).Equals(((char)i).ToString(), StringComparison.OrdinalIgnoreCase))
                                          ?
                                          ("<li ><a href=\"#" + ((char)i) + "\">" + ((char)i) + "</a></li>")
                                          :
                                          ("<li class=\"none\">" + ((char)i) + "</li>"));
                                  }%>
                            </ul>
                        </div>
                        <div id="treev1" class="treev1" style="height:500px;">
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
        <div style="width:760px;">           
            <div class="productList12" style="margin-top:0;width:752px;">
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
            <div class="bkStyleWrap">
                    <div class="bkStyleWrapInner">
                    <%if (elist.Count > 0)
                      { %>
                        <%foreach (EnWebMarketStoreyShop s in elist)
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
                                        <b>品牌风格：</b><font>
                                        <%=                                     
                              s.BrandInfo.brands==null?"":s.BrandInfo.brands.Length > 0 ? ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "3", (ECBrand.GetBrandsInfo("where brandid=" + s.BrandInfo.id) ?? new EnBrands()).style, ',', " ") : ""
                                        %></font></p>
                                    <p>
                                        <b>所在楼层：</b><span class="gray"><%=s.storeytitle%></span></p>
                                    <div class="ph">
                                        <%=s.shopphone%></div>
                                    <p class="yh">
                                    <%if (epromotionslist.Where(c => c.promotionsrelated.Any(p => p.shopid == s.shopid)).Count() > 0)
                                      { %>
                                      <%foreach (var pitem in epromotionslist.Where(c => c.promotionsrelated.Any(p => p.shopid == s.shopid)))
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
        <%--<div class="marketR">
   <div class="homebraRight">
  
    <div class="homebraRight1 homebraRight3" style="margin:0">
    <div class="promotions"><span><a href="<%=string.Format(EnUrls.MarketInfoBrand,marketInfo.id) %>">更多</a></span>推荐入驻品牌</div>
      <ul>
        <%foreach (EnWebMarket.MarketBrand b in marketInfo.MarketBrandList)
          { %>
            <li><a href="<%=string.Format(EnUrls.CompanyInfoBrandList,b.companyid,b.id) %>"><img src="<%=EnFilePath.GetBrandLogoPath(b.id,b.logo) %>" width="105" height="38"></a></li>
        <%} %>
      </ul>
    </div>
       
      <div class="homebraRight1 homebraRight3">
        <div class="promotions"><span><a href="<%=EnUrls.PromotionList%>">更多</a></span>促销信息</div>
        <%=ECPromotion.GetPromotionHtml(ECPromotion.GetWebTopPromotionListToMarket(4,marketInfo.id))%>
      </div>
    </div>
  
  </div>--%>
        <%--<div class="clearfix">
        </div>
        <div class="col3">
            <div class="homebraLi2" style="padding: 0;">
                <div class="homebraLi21">
                    <span class="spana1"><a href="#">更多</a></span> <strong>热门品牌</strong>
                </div>
                <div class="marketSlider" id="marketSlider">
                    <ul class="pic">
                        <li><a href="javascript:;" target="_blank">
                            <img width="929" height="278" src="http://ks.likx.com/upload/market/banner/6//2012020821094659.jpg" /></a></li>
                        <li><a href="javascript:;" target="_blank">
                            <img width="929" height="278" src="http://ks.likx.com/upload/market/banner/6//2012020821095023.jpg" /></a></li>
                    </ul>
                </div>
            </div>
        </div>--%>
        <div class="clearfix">
        </div>
    </div>
    <div class="clearfix">
    </div>
    <div class="topNav992 ad1">
        <%--<img src="<%=ECommon.WebResourceUrlToWeb %>/images/index_127.jpg">--%></div>
    <uc4:_foot ID="_foot1" runat="server" />
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
        $(function () {
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
        
//            $('#tree_letter li a[href]').click(function (e) {
//                var aname = $(this).attr('href').replace(/\#/, '');
//                var liTop = $("#treev1 a[name='" + aname + "']").parent().parent().offset().top;
//                var ulTop = $('#treev1').offset().top;
//                var ulscroTop = $('#treev1').scrollTop();
//                $('#treev1').scrollTop(liTop - ulTop + ulscroTop);
//                e.preventDefault();
//            });
        });
    </script>
</body>
</html>