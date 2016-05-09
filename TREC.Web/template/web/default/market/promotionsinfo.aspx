<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotionsinfo.aspx.cs"
    Inherits="TREC.Web.aspx.market.promotionsinfo" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/headerMarket.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_marketkeys.ascx" TagName="_marketkeys" TagPrefix="uc6" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <uc6:_marketkeys ID="_marketkeys1" Title="-家具卖场-首页" runat="server" />
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <link href="/resource/content/css/core.css" rel="stylesheet" />
    <link href="/resource/content/css/mall/mall.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />
    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/mall/mall.js"></script>
</head>
<body>
    <uc1:header ID="header1" runat="server" />
    <div class="site">
        <a href="/">首页</a> &gt; <a href="/marketlist.aspx">卖场</a> &gt; 促销活动</div>
    <div id="floatBar" class="layout_a" style="top: 0; right: 0;">
        <div class="layout_a_inner">
        </div>
    </div>
    <div class="topNav992 central">
        <div id="floatBarList" class="list_a">
            <div class="productList2" style="margin-top: 0;">
                <div class="promotionsR1" style="height: auto;">
                    <div class="promotions">
                        <span></span>品牌查询</div>
                    <div class="companySearch">
                        <form method="get" action="promotions.aspx">
                        <input type="hidden" name="mid" value="<%=ECommon.QueryMid %>" />
                        <input type="hidden" name="display" value='brand' />
                        <input type="hidden" name="type" value="brand" id="onlybrnad" title="onlybrnad" />
                        <input type="text" name="brand" class="input1" id="brnadSearchkey" value='<%=ECommon.QuerySearchBrand %>' />
                        <input type="image" src="<%=ECommon.WebResourceUrlToWeb %>/images/marketSearch.gif" />
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
                                  Response.Write(BrandList.Any(c => c.letter.Length > 0 && c.letter.Substring(0, 1).Equals(((char)i).ToString(), StringComparison.OrdinalIgnoreCase))
                                      ?
                                      ("<li ><a href=\"#" + ((char)i) + "\">" + ((char)i) + "</a></li>")
                                      :
                                      ("<li class=\"none\">" + ((char)i) + "</li>"));
                              }%>
                        </ul>
                    </div>
                    <div id="treev1" class="treev1" style="height: 300px;">
                        <ul>
                            <% foreach (var g in BrandList.Where(c => c.letter.Length > 0 && c.letter.Length > 0).GroupBy(c => c.letter[0].ToString().ToUpper()).OrderBy(c => c.Key))
                               { %>
                            <li id="letter1" class="root"><b>
                                <%=g.Key%>
                                <s>(<%=g.Count()%>)</s><a href="#" name="<%=g.Key%>"></a></b>
                                <ul>
                                    <% foreach (var p in g)
                                       { %>
                                    <li><a class="mainBrand" href="<%=string.Format("/market/promotions.aspx?mid={0}&display={1}&brand={2}", ECommon.QueryMid, "brand", Server.UrlEncode(p.title)) %>">
                                        <big>
                                            <%=p.title%></big></a></li>
                                    <% }%>
                                </ul>
                            </li>
                            <% }%>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="productList1" style="margin-top: 0; min-height: 1000px;">
            <div class="promotionsR1" style="height: auto;">
                <div class="promotions">
                    <span><a href="<%=string.Format(EnUrls.MarketInfoPromotionsSearch, ECommon.QueryMid, ECommon.QuerySearchDisplay, "", "") %>">
                        返回列表页</a></span></div>
            </div>
            <div class="promotionsinfo">
                <div class="promotionsinfoinner">
                    <%--<img src="<%=EnFilePath.GetMarketSurfacePath(mpromotions.id.ToString(), mpromotions.surface)%>" class="block g10"
                        alt="<%=mpromotions.title %>" width="379" height="199" />--%>
                    <div class="promotionsinfoinner1" style="width: auto;">
                        <h2>
                            <%=mpromotions.title %></h2>
                        <%if (DateTime.Now.Date > mpromotions.enddatetime.Date)
                          { %>
                        <p class="lastdate">
                            活动已经结束</p>
                        <%}
                          else
                          { %>
                        <p class="lastdate">
                            <%=mpromotions.startdatetime.ToString("yy年MM月dd号") %>-<%=mpromotions.enddatetime.ToString("yy年MM月dd号") %></p>
                        <%} %>
                        <%--<p class="lastdate">
                            <strong>
                                <%=(mpromotions.enddatetime - DateTime.Now).Days.ToString("00") %></strong>天<strong><%=(mpromotions.enddatetime - DateTime.Now).Hours.ToString("00") %></strong>时<strong><%=(mpromotions.enddatetime - DateTime.Now).Minutes.ToString("00") %></strong>分</p>--%>
                    </div>
                    <%--<div class="promotionsinfoinner2">
                        <h2 style="font-weight:bold; color:#D0233F; line-height:20px;">吉盛伟邦店</h2>
                        <p style="background:url(<%=ECommon.WebResourceUrlToWeb + "/images/index_74.gif" %>) no-repeat left 3px; padding-left:14px; line-height:22px;">长逸路15号建配龙6楼 1148</p>
                        <p style="background:url(<%=ECommon.WebResourceUrlToWeb + "/images/index_76.gif" %>) no-repeat left 3px; padding-left:14px; line-height:22px;">15221582831</p>
                    </div>--%>
                </div>
                <div class="produtShop" style="overflow: auto;">
                    <div class="productShop productPa1" style="width: 941px;">
                        <%if (mpromotions.membertype == (int)EnumMemberType.工厂企业 || mpromotions.membertype == (int)EnumMemberType.经销商)
                          { %>
                        <div class="productShop-header">
                            <p class="p1">
                                参与活动店铺</p>
                            <p class="p2">
                                电话</p>
                            <p class="p3">
                                地址</p>
                        </div>
                        <div class="productShop-content">
                            <%for (int i = 0; i < shoplist.Count; i++)
                              { %>
                            <div class="productDetails1 verticalmid" style="border-bottom-width: 1px; *padding-bottom: 0px;">
                                <a class="p1" href="<%=string.Format(EnUrls.ShopInfoIndex, shoplist[i].id) %>" target="_blank"
                                    style="text-decoration: none;">
                                    <%=shoplist[i].title %>
                                    <%if (shoplist[i].attribute != null && shoplist[i].attribute.Contains(((int)EnumAttribute.推荐).ToString()))
                                      { %>
                                    <span style="color: Red; font-weight: normal; text-decoration: none;">[推荐]</span>
                                    <%} %>
                                </a>
                                <p class="p2">
                                    <%=shoplist[i].phone %>&nbsp;</p>
                                <p class="p4">
                                    <%=ECommon.GetAreaName(shoplist[i].areacode) %><%=shoplist[i].address %></p>
                                <div style="clear: both; height: 0px; width: 0px; overflow: hidden;">
                                </div>
                            </div>
                            <%} %>
                        </div>
                        <%}
                          else if (mpromotions.membertype == (int)EnumMemberType.卖场)
                          { %>
                        <div class="productShop-header">
                            <p class="p1">
                                参与活动卖场</p>
                            <p class="p2">
                                电话</p>
                            <p class="p3">
                                地址</p>
                        </div>
                        <div class="productShop-content">
                            <%for (int i = 0; i < marketlist.Count; i++)
                              { %>
                            <div class="productDetails1 verticalmid" style="border-bottom-width: 1px; *padding-bottom: 0px;">
                                <a class="p1" href="<%=string.Format(EnUrls.MarketInfoIndex, marketlist[i].id) %>"
                                    target="_blank" style="text-decoration: none;">
                                    <%=marketlist[i].title %>
                                    <%if (marketlist[i].attribute != null && marketlist[i].attribute.Contains(((int)EnumAttribute.推荐).ToString()))
                                      { %>
                                    <span style="color: Red; font-weight: normal; text-decoration: none;">[推荐]</span>
                                    <%} %>
                                </a>
                                <p class="p2">
                                    <%=marketlist[i].phone %></p>
                                <p class="p4">
                                    <%=ECommon.GetAreaName(marketlist[i].areacode) %><%=marketlist[i].address %></p>
                                <div style="clear: both; height: 0px; width: 0px; overflow: hidden;">
                                </div>
                            </div>
                            <%} %>
                        </div>
                        <%} %>
                    </div>
                </div>
                <div class="promotionsinfodes">
                    <%if (!string.IsNullOrEmpty(mpromotions.surface))
                      {  %>
                    <img src="<%=EnFilePath.GetPromotionSurfacePath(mpromotions.id.ToString(),mpromotions.surface) %>" /><br />
                    <%} %>
                    <%=mpromotions.descript %>
                </div>
            </div>
            <div class="clearfix">
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
            // SIPAUTO_ResizeHeight_box.style.height = height - 1 + 'px';
        }
        $(function () {
            $('#tree_letter li a[href]').click(function (e) {
                var aname = $(this).attr('href').replace(/\#/, '');
                var liTop = $("#treev1 a[name='" + aname + "']").parent().parent().offset().top;
                var ulTop = $('#treev1').offset().top;
                var ulscroTop = $('#treev1').scrollTop();
                //    $('#treev1').scrollTop(liTop - ulTop + ulscroTop);
                return false;
            });
        });
    </script>
</body>
</html>
