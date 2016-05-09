<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotions.aspx.cs" Inherits="TREC.Web.aspx.market.promotions" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="Haojibiz.Model" %>
<%@ Import Namespace="Haojibiz.Data" %>
<%@ Import Namespace="Haojibiz.DAL" %>
<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_marketnav.ascx" TagName="_marketnav" TagPrefix="uc3" %>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../ascx/_marketkeys.ascx" tagname="_marketkeys" tagprefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_marketkeys ID="_marketkeys1" Title="-家具卖场-促销信息" runat="server" />
    <uc2:_resource runat="server" />
</head>
<body>
    <uc1:_headA runat="server" />
    <uc3:_marketnav runat="server" />
    <div style="width:1px; height:100%; position:absolute; top:0px; left:0px;" id="bodyHeightBox"></div>
    <div style="width:0; height:6px;"></div>




    <div id="floatBar" class="layout_a" style=" top:0; right:0;">
        <div class="layout_a_inner">
            <div id="floatBarList" class="list_a">
                <div class="productList2" style="margin-top:0;">
                    <div class="promotionsR1" style="height: auto;">
                        <div class="promotions">
                            <span></span>品牌查询</div>
                        <div class="companySearch">
                            <form method="get" action="/market/promotions.aspx">
                            <input type="hidden" name="mid" value="<%=ECommon.QueryMid %>" />
                            <input type="hidden" name="display" value='brand' />
                            <input type="hidden" name="type" value="brand" id="onlybrnad" title="onlybrnad" />
                            <input type="text" name="brand" class="input1" id="brnadSearchkey" value='<%=ECommon.QuerySearchBrand %>' />
                            <input id="btnmbsearch" type="image" src="<%=ECommon.WebResourceUrlToWeb %>/images/marketSearch.gif" />
                            <i class="clearfix"></i>
                            <script type="text/javascript">
                                $(function () {
                                    var mburl = '<%=string.Format(EnUrls.MarketInfoPromotionsSearch, ECommon.QueryMid, "brand", "$1", "") %>';
                                    $('#brnadSearchkey').oms_autocomplate({ url: "/ajax/search.ashx", paramTypeSelector: "#onlybrnad" });
                                    $('#btnmbsearch').click(function (e) {
                                        var key = encodeURIComponent($('#brnadSearchkey').val());
                                        mburl = mburl.replace("$1", key);
                                        location.href = mburl;
                                        e.preventDefault();
                                    });
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
                                        <li><a class="mainBrand" href="<%=string.Format(EnUrls.MarketInfoPromotionsSearch, ECommon.QueryMid, "brand", Server.UrlEncode(p.title), "") %>"><big>
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
        </div>
    </div>





    <div class="topNav992 central">
        <div class="productList1" style="margin-top:0; min-height:1000px;">


            <div class="productList12" style="margin-top:0;">
                <div class="productList121">
                    <ul class="pr12-ti">
                        <li><a class="<%=UiCommon.QueryStringCur("display", "", "", "pr12-tia") %><%=UiCommon.QueryStringCur("display", "all", "", "pr12-tia") %>"
                            href="<%=string.Format(EnUrls.MarketInfoPromotionsSearch, ECommon.QueryMid, "all", "", "") %>">所有资讯</a></li>
                        <li><a class="<%=UiCommon.QueryStringCur("display", "brand", "", "pr12-tia") %>"
                            href="<%=string.Format(EnUrls.MarketInfoPromotionsSearch, ECommon.QueryMid, "brand", "", "") %>">品牌促销资讯</a></li>
                        <li><a class="<%=UiCommon.QueryStringCur("display", "market", "", "pr12-tia") %>"
                            href="<%=string.Format(EnUrls.MarketInfoPromotionsSearch, ECommon.QueryMid, "market", "", "") %>">卖场促销资讯</a></li>
                    </ul>
                    <div class="pr12-fy"><a href="<%=NextUrl %>" class="xyy">下一页</a><span><%=ECommon.QueryPageIndex %>/<%=pager.PageCount %></span><a href="<%=PrvUrl %>" style="float:right;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/product_19.gif" /></a></div>
                </div>

                <div class="productList122">

                </div>
            </div>



            <%for (int i = 0; i < list.Count; i++)
              { %>
               <%if (list[i].membertype == (int)EnumMemberType.工厂企业 || list[i].membertype == (int)EnumMemberType.经销商)
                 { %>
                 <%Mshop shopFirst = shoplist.Where(c => list[i].promotionsrelated.Where(s => s.shopid == c.id).Any()).FirstOrDefault() ?? new Mshop(); %>
                <div class="promotionsitem">
                    <div class="promotionsitembg">
                        <div class="promotionsitemright">
                            <% var firsBrand = dpromotions.LinqData<Mbrand>().Where(c => dpromotions.LinqData<Mshopbrand>().Where(f => f.shopid == shopFirst.id && f.brandid == c.id).Any()).FirstOrDefault(); %>
                           <img style="max-width:145px;" src="<%=EnFilePath.GetBrandLogoPath(firsBrand.id.ToString(), firsBrand.logo) %>" />
                        </div>
                        <div class="promotionsitemcanlender">
                            <div class="day"><%=list[i].startdatetime.Day.ToString("00")%></div>
                            <div class="month"><%=list[i].startdatetime.Month.ToString("00")%>月</div>
                        </div>
                        <div class="promotionsitemleft">
                            <h2><a href="<%=string.Format(EnUrls.MarketInfoPromotionsInfo, ECommon.QueryMid, list[i].id, ECommon.QuerySearchDisplay) %>"><%=list[i].title%></a></h2>
                            <p>
                                <span class="C50913">[店铺]</span><strong><a href="<%=string.Format(EnUrls.ShopInfoIndex, shopFirst.id) %>"><%=shopFirst.title %></a></strong><span class="mobile"><%=shopFirst.phone %></span>
                            </p>
                            <%if (list[i].promotionsrelated.Count > 1)
                              { %>
                            <p><a href="<%=string.Format(EnUrls.MarketInfoPromotionsInfo, ECommon.QueryMid, list[i].id, ECommon.QuerySearchDisplay) %>">点击查看更多参与活动店铺</a></p>
                            <%} %>
                        </div>
                    </div>
                </div>
            <%}
                 else
                 { %>
                 <div class="promotionsitem2">
                    <div class="promotionsitem2bg">
                        <div class="promotionsitem2right">
                           <%if (!string.IsNullOrEmpty(MarketPageBase.marketInfo.logo)) { %><img src="<%=EnFilePath.GetMarketLogoPath(MarketPageBase.marketInfo.id.ToString(),MarketPageBase.marketInfo.logo) %>" width="105" height="38" /><%} %>
                        </div>
                        <div class="promotionsitem2canlender">
                            <div class="day"><%=list[i].startdatetime.Day.ToString("00")%></div>
                            <div class="month"><%=list[i].startdatetime.Month.ToString("00")%>月</div>
                        </div>
                        <div class="promotionsitem2left">
                            <h2><a href="<%=string.Format(EnUrls.MarketInfoPromotionsInfo, ECommon.QueryMid, list[i].id, ECommon.QuerySearchDisplay) %>"><%=list[i].title%></a></h2>
                            <p>
                                <span style="color:#ffb724;">[卖场]</span><strong><a href="<%=string.Format(EnUrls.MarketInfoIndex, marketInfo.id) %>"><%=marketInfo.title %></a></strong><span class="mobile"><%=marketInfo.phone %></span>
                            </p>
                        </div>
                    </div>
                </div>
            <%} %>
            <%} %>

            <webdiyer:AspNetPager ID="pager" runat="server" AlwaysShow="true" CssClass="pager" CurrentPageButtonClass="cpb" UrlPaging="true" FirstPageText="首页" PrevPageText="上一页" NextPageText="下一页" LastPageText="尾页"></webdiyer:AspNetPager>

        </div>
    </div>
    <uc4:_foot runat="server" />

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
