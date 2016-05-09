<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotions.aspx.cs" Inherits="TREC.Web.aspx.promotions" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="Haojibiz.Model" %>
<%@ Import Namespace="Haojibiz.Data" %>
<%@ Import Namespace="Haojibiz.DAL" %>

<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<%--
<%@ Register Src="ascx/_resource.ascx" TagName="Resource" TagPrefix="my" %>
<%@ Register Src="ascx/_head.ascx" TagName="Head" TagPrefix="my" %>
<%@ Register Src="ascx/_foot.ascx" TagName="Foot" TagPrefix="my" %>
<%@ Register Src="ascx/_nav.ascx" TagName="Nav" TagPrefix="my" %>--%>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="my" %>
<%@ Register Src="ascx/_AreaSelect.ascx" TagName="AreaSelect" TagPrefix="my" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <ucnewresource:newresource ID="newresource1" runat="server" />

    <meta name="keywords" content="家具活动专区 特价家具 家具秒杀 团购活动 促销活动" />
    <meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！" />
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/index/index.css" rel="stylesheet" type="text/css" />
       <script src="/resource/content/js/core.js" type="text/javascript"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/index/index.js"></script>
  

    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />
</head>
<body>

    <uc1:header ID="header1" runat="server" />
 <div class="site"><a href="/">家具快搜</a> > <a href="/promotions/list.aspx">品牌资讯</a> > <%=getListTitle%></div>
    <div style="width:1px; height:100%; position:absolute; top:0px; left:0px;" id="bodyHeightBox"></div>
    <div style="width:0; height:6px;"></div>

   

    <div class="topNav992 central">
        <div class="productList1" style="margin-top:0; min-height:1000px;">
            <div class="productList12" style="margin-top:0;">
                <div class="productList121">
                    <ul class="pr12-ti">
                        <li><a class="<%=UiCommon.QueryStringCur("display", "", "", "pr12-tia") %><%=UiCommon.QueryStringCur("display", "all", "", "pr12-tia") %>"
                            href="<%=string.Format(EnUrls.PromotionsListSearch, "all", "", "", "", "") %>">所有资讯</a></li>
                        <li><a class="<%=UiCommon.QueryStringCur("display", "brand", "", "pr12-tia") %>"
                            href="<%=string.Format(EnUrls.PromotionsListSearch, "brand", "", "", "", "") %>">品牌促销资讯</a></li>
                        <li><a class="<%=UiCommon.QueryStringCur("display", "market", "", "pr12-tia") %>"
                            href="<%=string.Format(EnUrls.PromotionsListSearch, "market", "", "", "", "") %>">卖场促销资讯</a></li>
                    </ul>
                    <div class="pr12-fy"><a href="<%=NextUrl %>" class="xyy">下一页</a><span><%=ECommon.QueryPageIndex %>/<%=pager.PageCount %></span><a href="<%=PrvUrl %>" style="float:right;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/product_19.gif" /></a></div>
                </div>
                <div class="productList122">
                    <span class="s1">区域搜索</span>
                    <div class="pr_xl" style="width: auto; text-indent: 0; background: none;">
                        <my:AreaSelect ID="txtarea" runat="server" />
                    </div>
                    <div class="pr_xl" style="width: auto; text-indent: 0; background: none;">
                        <input id="btnareasearch" type="button" value="搜索" />
                        
                        <script type="text/javascript">
                            $(function () {
                                var rurl = '<%=string.Format(EnUrls.PromotionsListSearch, ECommon.QuerySearchDisplay, ECommon.QuerySearchBrand, ECommon.QuerySearchMarket, "$1", "") %>';
                                $('#btnareasearch').click(function () {
                                    var areacode = window["<%=txtarea.ClientID %>"].valueField.value;
                                    rurl = rurl.replace("$1", areacode);
                                    location.href = rurl;
                                });
                            });
                        </script>
                    </div>
                    <%if (ECommon.QuerySearchDisplay == "brand" && !string.IsNullOrEmpty(ECommon.QuerySearchBrand))
                      { %>
                    <div class="topli-selected">
                        <div class="spanright">你当前搜索的是&nbsp;<b><%=ECommon.QuerySearchBrand.Trim()%></b>&nbsp;相关促销&nbsp;<a style="color:Red;" href="<%=string.Format("/promotions.aspx?display={0}&brand={1}&area={2}", ECommon.QuerySearchDisplay, "", ECommon.QuerySearchArea) %>">×</a></div>
                    </div>
                    <%}
                      else if (ECommon.QuerySearchDisplay == "market" && !string.IsNullOrEmpty(ECommon.QuerySearchMarket))
                      { %>
                      <div class="topli-selected">
                        <div class="spanright">你当前搜索的是&nbsp;<b><%=ECommon.QuerySearchMarket.Trim()%></b>&nbsp;相关促销&nbsp;<a style="color:Red;" href="<%=string.Format("/promotions.aspx?display={0}&market={1}&area={2}", ECommon.QuerySearchDisplay, "", ECommon.QuerySearchArea) %>">×</a></div>
                    </div>
                    <%} %>
                </div>
            </div>
            <%if (list.Count > 0)
              { %>
            <%for (int i = 0; i < list.Count; i++)
              { %>
              <% Mshop shopFirst = new Mshop();
                 Mmarket marketFirst = new Mmarket(); %>
              <%if (list[i].membertype == (int)EnumMemberType.工厂企业 || list[i].membertype == (int)EnumMemberType.经销商)
                { %>
                <%if (!string.IsNullOrEmpty(ECommon.QuerySearchArea) && ECommon.QuerySearchArea != "0")
                  {  %>
                  <%shopFirst = shoplist.Where(c => arealist.Contains(c.areacode) && list[i].promotionsrelated.Select(s => s.shopid).Contains(c.id)).FirstOrDefault(); %>
                <%}
                  else
                  { %>
                  <%shopFirst = shoplist.Where(c => list[i].promotionsrelated.Select(s => s.shopid).Contains(c.id)).FirstOrDefault(); %>
                <%} %>
                          <%}
                else if (list[i].membertype == (int)EnumMemberType.卖场)
                { %>
                <%marketFirst = marketlist.Where(c => list[i].promotionsrelated.Select(m => m.marketid).Contains(c.id)).FirstOrDefault(); %>
                <%} %>
                <%if (list[i].membertype == (int)EnumMemberType.工厂企业 || list[i].membertype == (int)EnumMemberType.经销商)
                  { %>
            <div class="promotionsitem">
                <div class="promotionsitembg">
                    <div class="promotionsitemright" style="display:none;">
                        <% var firsBrand = dpromotions.LinqData<Mbrand>().Where(c => dpromotions.LinqData<Mshopbrand>().Where(f => f.shopid == shopFirst.id && f.brandid == c.id).Any()).FirstOrDefault(); %>
                       <img style="max-width:145px;" src="<%=EnFilePath.GetBrandLogoPath(firsBrand.id.ToString(), firsBrand.logo) %>" />
                    </div>
                    <div class="promotionsitemcanlender">
                        <div class="day"><%=list[i].createtime.Day.ToString("00")%></div>
                        <div class="month"><%=list[i].createtime.Month.ToString("00")%>月</div>
                    </div>
                    <div class="promotionsitemleft">
                        <h2><a href="<%=string.Format(EnUrls.PromotionsInfo, list[i].id) %>"><%=list[i].title%></a></h2>
                        <p>
                            <span class="C50913">[店铺]</span><strong><a href="<%=string.Format(EnUrls.ShopInfoIndex, shopFirst.id) %>"><%=shopFirst.title%></a></strong><span class="mobile"><%=shopFirst.phone%></span>
                        </p>
                            <%if (list[i].promotionsrelated.Count > 1)
                              { %>
                              <p><a href="<%=string.Format(EnUrls.PromotionsInfo, list[i].id) %>">点击查看更多参与活动店铺</a></p>
                            <%} %>
                    </div>
                </div>
            </div>
            <%}
                  else
                  { %>
                  <div class="promotionsitem2">
                    <div class="promotionsitem2bg">
                        <div class="promotionsitem2right" style="display:none;">
                           <img style="max-width:145px;" src="<%=!string.IsNullOrEmpty(marketFirst.logo) ? EnFilePath.GetMarketLogoPath(marketFirst.id.ToString(), marketFirst.logo) : EnFilePath.GetBrandLogoPath("0", "") %>" />
                        </div>
                        <div class="promotionsitem2canlender">
                            <div class="day"><%=list[i].startdatetime.Day.ToString("00")%></div>
                            <div class="month"><%=list[i].startdatetime.Month.ToString("00")%>月</div>
                        </div>
                        <div class="promotionsitem2left">
                            <h2><a href="<%=string.Format(EnUrls.PromotionsInfo, list[i].id) %>"><%=list[i].title%></a></h2>
                            <div>
                                <span style="color:#ffb724;">[卖场]</span><strong><a href="<%=string.Format(EnUrls.MarketInfoIndex, marketFirst.id) %>"><%=marketFirst.title%></a></strong><span class="mobile"><%=marketFirst.mphone%></span>
                              </div>
                        </div>
                    </div>
                </div>
            <%} %>
            <%} %>
            <%}
              else
              { %>
            <div class="productPic productPic1">
                <div class="productPic1" style="background: url(<%=ECommon.WebResourceUrlToWeb %>/images/not.gif) no-repeat;
                    height: 201px; line-height: 210px; text-align: center; font-size: 16px; font-weight: bold;
                    color: #595959;">
                    抱歉，暂无<%if (ECommon.QuerySearchDisplay == "brand" && !string.IsNullOrEmpty(ECommon.QuerySearchBrand))
                           { %>相关与&nbsp;<a class="auto_BD182D"><%=ECommon.QuerySearchBrand.Trim() %></a>&nbsp;<%}
                           else if (ECommon.QuerySearchDisplay == "market" && !string.IsNullOrEmpty(ECommon.QuerySearchMarket))
                           { %>相关与&nbsp;<a class="auto_BD182D"><%=ECommon.QuerySearchMarket.Trim() %></a>&nbsp;<%} %>相关的促销信息
                </div>
            </div>
            <%} %>
            <my:AspNetPager ID="pager" runat="server" AlwaysShow="true" PageSize="20" CssClass="pager" CurrentPageButtonClass="cpb"
                UrlPaging="true" FirstPageText="首页" PrevPageText="上一页" NextPageText="下一页" LastPageText="尾页">
            </my:AspNetPager>
        </div>




        <%if (ECommon.QuerySearchDisplay.ToLower() != "brand" && ECommon.QuerySearchDisplay.ToLower() != "market")
          { %>
        <div class="productList2" style="margin-top:0;">
        <div class="promotionsR1" style="height:auto; padding-bottom:30px;">
              <div class="promotions">促销信息</div>
              <div class="prAd1"><script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=14"></script><script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=15"></script></div>
                <%if (NewList.Count == 0)
                  { %>
                  暂无促销信息
                  <%}
                  else
                  { %>
                <%for (int i = 0; i < NewList.Count; i++)
                  { %>
                  <div class="promotions2">
                    <a href="<%=string.Format("/promotionsinfo.aspx?id={0}", NewList[i].id) %>"><h3><%=NewList[i].title%></h3></a>
                    <p class="time">截至日期：<%=NewList[i].enddatetime.ToShortDateString() %></p>
                    <%if (NewList[i].promotionsrelated.Count > 0)
                      { %>
                      <%if (NewList[i].membertype == (int)EnumMemberType.工厂企业 || NewList[i].membertype == (int)EnumMemberType.经销商)
                        { %>
                        <p class="address"><%=NewList[i].promotionsrelated[0].shopaddress%></p>
                    <%}
                        else if (NewList[i].membertype == (int)EnumMemberType.卖场)
                        { %>
                        <p class="address"><%=NewList[i].promotionsrelated[0].marketaddress%></p>
                    <%} %>
                    <%} %>
                  </div>
                <%} %>
                <%} %>
            </div>
        </div>
        <%} %>


                     <%if (ECommon.QuerySearchDisplay == "brand")
      { %>
    <div id="floatBar" class="layout_a" style=" top:0; right:0;">
        <div class="layout_a_inner">
            <div id="floatBarList" class="list_a">
                <div class="productList2" style="margin-top:0;">
                    <div class="promotionsR1" style="height: auto;">
                        <div class="promotions">
                            <span></span>品牌查询</div>
                        <div class="companySearch">
                            <form method="get" action="/promotions.aspx">
                            <input type="hidden" name="display" value='<%=ECommon.QuerySearchDisplay %>' />
                            <input type="hidden" name="type" value="brand" id="onlybrnad" title="onlybrnad" />
                            <input type="text" name="brand" class="input1" id="brnadSearchkey" value='<%=ECommon.QuerySearchBrand %>' />
                            <input id="btnpbrandsearch" type="image" src="<%=ECommon.WebResourceUrlToWeb %>/images/marketSearch.gif" />
                            <i class="clearfix"></i>
                            
                            <script type="text/javascript">
                                $(function () {
                                    var bsurl = '<%=string.Format(EnUrls.PromotionsListSearch, ECommon.QuerySearchDisplay, "$1", ECommon.QuerySearchMarket, ECommon.QuerySearchArea, "") %>';
                                    $('#brnadSearchkey').oms_autocomplate({ url: "/ajax/search.ashx", paramTypeSelector: "#onlybrnad" });
                                    $('#btnpbrandsearch').click(function (e) {
                                        var key = encodeURIComponent($("#brnadSearchkey").val());
                                        bsurl = bs.replace("$1", key);
                                        location.href = bsurl;
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
                                        <li><a class="mainBrand" href="<%=string.Format(EnUrls.PromotionsListSearch, ECommon.QuerySearchDisplay, Server.UrlEncode(p.title), ECommon.QuerySearchMarket, ECommon.QuerySearchArea, "") %>"><big>
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
    <%} %>
    <%if (ECommon.QuerySearchDisplay == "market")
      { %>
    <div id="floatBar" class="layout_a" style="top: 0; right: 0;">
        <div class="layout_a_inner">
            <div id="floatBarList" class="list_a">
                <div class="productList2" style="margin-top: 0;">
                    <div id="" class="promotionsR1" style="background-color: White; height: auto;">
                        <div class="promotions">
                            <span></span>卖场查询</div>
                        <div class="companySearch">
                            <form method="get" action="promotions.aspx">
                            <input type="hidden" name="display" value='<%=ECommon.QuerySearchDisplay %>' />
                            <input type="hidden" name="type" value="market" title="onlymarket" id="onlymarket" />
                            <input style="width: 5px; margin: 0; padding: 0; background: none; border: 0;" />
                            <input type="text" name="market" class="input1" id="marketSearchkey" value='<%=ECommon.QuerySearchMarket %>' />
                            <input type="image" id="btnpmarketsearch" src="<%=ECommon.WebResourceUrlToWeb %>/images/marketSearch.gif"
                                onmousemove="this.src='<%=ECommon.WebResourceUrlToWeb %>/images/marketSearchhover.gif'"
                                onmouseout="this.src='<%=ECommon.WebResourceUrlToWeb %>/images/marketSearch.gif'" />
                            <i class="clearfix"></i>
                            <script type="text/javascript">
                                $(function () {
                                    var msurl = '<%=string.Format(EnUrls.PromotionsListSearch, ECommon.QuerySearchDisplay, ECommon.QuerySearchBrand, "$1", ECommon.QuerySearchArea, "") %>';
                                    $('#marketSearchkey').oms_autocomplate({ url: "/ajax/search.ashx", paramTypeSelector: "#onlymarket" });
                                    $("#btnpmarketsearch").click(function (e) {
                                        var key = encodeURIComponent($('#marketSearchkey').val());
                                        msurl = msurl.replace("$1", key);
                                        location.href = msurl;
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
                                      Response.Write(MarketList.Any(c => c.letter != null && c.auditstatus == 1 && c.linestatus == 1 && c.letter.Substring(0, 1).Equals(((char)i).ToString(), StringComparison.OrdinalIgnoreCase))
                                          ?
                                          ("<li ><a href=\"#" + ((char)i) + "\">" + ((char)i) + "</a></li>")
                                          :
                                          ("<li class=\"none\">" + ((char)i) + "</li>"));
                                  }%>
                            </ul>
                        </div>
                        <div id="treev1" class="treev1" style="height: 1400px;">
                            <ul>
                                <% foreach (var g in MarketList.Where(c => c.letter != null && c.letter.Length > 0 && c.auditstatus == 1 && c.linestatus == 1).GroupBy(c => c.letter[0].ToString().ToUpper()).OrderBy(c => c.Key))
                                   { %>
                                <li id="letter1" class="root"><b>
                                    <%=g.Key%>
                                    <s>(<%=g.Count()%>)</s><a href="#" name="<%=g.Key%>"></a></b>
                                    <ul>
                                        <% foreach (var p in g)
                                           { %>
                                        <li><a class="mainBrand" href="<%=string.Format(EnUrls.PromotionsListSearch, ECommon.QuerySearchDisplay, ECommon.QuerySearchBrand, Server.UrlEncode(p.title), ECommon.QuerySearchArea, "") %>"><big>
                                                <%=p.title %></big><%--<%if (p.areacode != null && p.areacode.Length > 0)
                                                                     { %>
                                                                     <div class="auto_BDBDBD auto_item_right" style="width:45px; top:7px;"><%=(AreaList.FirstOrDefault(c => c.areacode == p.areacode) ?? new EnArea()).areaname %></div>
                                                                     <%} %>--%></a></li>
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
    <%}%>

    </div>
   <ucfooter:footer ID="header2" runat="server" />

    <%if (ECommon.QuerySearchDisplay.ToLower() == "brand" || ECommon.QuerySearchDisplay.ToLower() == "market")
      { %>
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
    <%} %>
</body>
</html>
