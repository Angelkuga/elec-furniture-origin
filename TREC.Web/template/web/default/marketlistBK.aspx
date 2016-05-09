<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.marketlist" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="Haojibiz.Data" %>
<%@ Import Namespace="Haojibiz.DAL" %>
<%@ Import Namespace="Haojibiz.Model" %>
<%@ Register src="ascx/_resource.ascx" tagname="_resource" tagprefix="uc1" %>
<%@ Register src="ascx/_head.ascx" tagname="_head" tagprefix="uc2" %>
<%@ Register src="ascx/_foot.ascx" tagname="_foot" tagprefix="uc3" %>
<%@ Register src="ascx/_nav.ascx" tagname="_nav" tagprefix="uc4" %>
<%@ Register src="ascx/_brandletter.ascx" tagname="_brandletter" tagprefix="uc5" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>家具快搜-卖场_家具行业信息官网_最全的家具品牌、厂商、店铺、家居卖场信息发布和搜素!</title>
    <meta name="keywords" content="家具品牌,家具品牌排名,家具十大品牌,品牌家具,实木家具十大品牌,儿童家具十大品牌,板式家具十大品牌" />
    <meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！" />
    <uc1:_resource ID="_resource1" runat="server" />
</head>
<body>
<uc2:_head ID="_head1" runat="server" />
<uc4:_nav ID="_nav1" runat="server" />
<div style="width:1px; height:100%; position:absolute; top:0px; left:0px;" id="bodyHeightBox"></div>
<div style="width:0; height:6px;"></div>
<div id="floatBar" class="layout_a" style="top: 0px; right: 0;">
    <div class="layout_a_inner">
        <div id="floatBarList" class="list_a">
            <div class="productList2" style="margin-top:0px;">
                <div id="" class="promotionsR1" style=" background-color:White; height:auto;">
                    <div class="promotions"><span></span>卖场查询</div>
                    <div class="companySearch">
                        <form method="get" action="/search.aspx">
                        <input type="hidden" name="type" value="market" title="onlymarket" id="onlymarket" />
                        <input style="width:5px; margin:0; padding:0; background:none; border:0;" />
                        <input type="text" name="key" class="input1" id="marketSearchkey" />
                        <input type="image" src="<%=ECommon.WebResourceUrlToWeb %>/images/marketSearch.gif" onmousemove="this.src='<%=ECommon.WebResourceUrlToWeb %>/images/marketSearchhover.gif'" onmouseout="this.src='<%=ECommon.WebResourceUrlToWeb %>/images/marketSearch.gif'" />
                        <i class="clearfix"></i>
                        <script type="text/javascript">
                            $(function () {
                                $('#marketSearchkey').oms_autocomplate({ url: "/ajax/search.ashx", paramTypeSelector: "#onlymarket" });
                            });
                        </script>
                        </form>
                    </div>
                    <i class="clearfix"></i>
                    <div class="treeSubNavv1">
                        <ul id="tree_letter">
                            <%for (var i = 65; i < 91; i++)
                                {
                                    Response.Write(MarketList.Any(c => c.letter != null && c.auditstatus==1 && c.linestatus==1 && c.letter.Substring(0, 1).Equals(((char)i).ToString(), StringComparison.OrdinalIgnoreCase))
                                        ?
                                        ("<li ><a href=\"#" + ((char)i) + "\">" + ((char)i) + "</a></li>")
                                        :
                                        ("<li class=\"none\">" + ((char)i) + "</li>"));
                                }%>
                        </ul>
                    </div>
                    <div id="treev1" class="treev1" style="height: 1400px;">
                        <ul>
                        <% foreach (var g in MarketList.Where(c => c.letter != null && c.letter.Length > 0 && c.auditstatus == 1 && c.linestatus==1).GroupBy(c => c.letter[0].ToString().ToUpper()).OrderBy(c => c.Key))
                                   { %>

                                <li id="letter1" class="root"><b>
                                    <%=g.Key%>
                                    <s>(<%=g.Count()%>)</s><a href="#" name="<%=g.Key%>"></a></b>
                                    <ul>
                                        <% foreach (var p in g)
                                           { %>
                                        <li><a class="mainBrand" href="<%=string.Format(EnUrls.MarketInfoIndex, p.id) %>"
                                            target="_blank"><big>
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
<div class="topNav992 central">
  <div class="productList1" style="margin-top:0; min-height:1000px;">
    
    <div class="prlifl2" style=" border-top:1px solid #f1d38b;">
      <div class="prlifl20">
        <div class="topli-selected">
            <span class="spanleft">目前搜索到&nbsp;&nbsp;&nbsp;<strong><%=AspNetPager1.RecordCount %></strong>&nbsp;个相关卖场</span>
        </div>
        <%if (ECMarket.GetSearchItem().FindAll(x => x.isCur == true).Count > 0)
          { %>
        <div class="prli-selected"><span>您的搜索条件：</span>
            <div class="selectedselect">
            <%foreach (EnSearchItem i in ECMarket.GetSearchItem().FindAll(x => x.isCur == true))
              { %>
                <a href="<%=string.Format(EnUrls.MarketListSearch, ECommon.QuerySearchBrand.Replace("_" + i.value, ""), ECommon.QuerySearchStyle.Replace("_" + i.value, ""), ECommon.QuerySearchMaterial.Replace("_" + i.value, ""), ECommon.QuerySearchSpread.Replace("_" + i.value, ""), ECommon.QuerySearchStaffsize.Replace("_" + i.value, ""), ECommon.QuerySearchSort.Replace("_" + i.value, ""), ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchArea.Replace("_" + i.value, ""))%>"><%=i.title%></a>
            <%} %>
            </div>
        </div>
        <%}
          else
          { %>
          <div style="width:738px; height:8px; margin:0 auto; background-color:#FFE1B3; margin-top:8px;"></div>
        <%} %>
        <dl class="prlifldl">
          <dd>区域：</dd>
          <dt>
          <%foreach (EnSearchItem i in ECMarket.GetSearchItem().FindAll(x=>x.type=="area"&&x.isCur==false))
          { %>
            <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,ECommon.QuerySearchKey,1,ECommon.QuerySearchArea+"_"+i.value) %>"><%=i.title %></a>
        <%} %>
          </dt>
        </dl>

        <dl class="prlifldl">
          <dd>卖场：</dd>
          <dt>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"金盛",1,ECommon.QuerySearchArea) %>">金盛</a>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"莘潮",1,ECommon.QuerySearchArea) %>">莘潮</a>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"欧亚美",1,ECommon.QuerySearchArea) %>">欧亚美</a>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"东明",1,ECommon.QuerySearchArea) %>">东明</a>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"九星",1,ECommon.QuerySearchArea) %>">九星</a>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"红星美凯龙",1,ECommon.QuerySearchArea) %>">红星美凯龙</a>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"金海马",1,ECommon.QuerySearchArea) %>">金海马</a>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"好美家",1,ECommon.QuerySearchArea) %>">好美家</a>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"沪杭",1,ECommon.QuerySearchArea) %>">沪杭</a>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"春申江",1,ECommon.QuerySearchArea) %>">春申江</a>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"吉盛伟邦",1,ECommon.QuerySearchArea) %>">吉盛伟邦</a>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"好百年",1,ECommon.QuerySearchArea) %>">好百年</a>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"盛源大地",1,ECommon.QuerySearchArea) %>">盛源大地</a>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"剪刀石头布",1,ECommon.QuerySearchArea) %>">剪刀石头布</a>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"月星",1,ECommon.QuerySearchArea) %>">月星</a>
          <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"建配龙",1,ECommon.QuerySearchArea) %>">建配龙</a>
          <%--<%foreach (EnMarket i in ECMarket.GetMarketList("auditstatus=1"))
          { %>
            <a target="_blank" href="<%=string.Format(EnUrls.MarketInfoIndex, i.id) %>"><%=i.title %></a>
        <%} %>--%>
          </dt>
        </dl>
      </div>
    </div>
    <div class="productList12">
      <div class="productList121">
        <ul class="pr12-ti"><%--
          <li><a href="#">所有经销商</a></li>
          <li><a href="#">按品牌显示</a></li>--%>
          <li><a href="#" class="pr12-tia">按卖场显示</a></li>
        </ul>
        <div class="pr12-fy"><a href="<%=NextUrl %>" class="xyy">下一页</a><span><%=AspNetPager1.CurrentPageIndex %>/<%=AspNetPager1.PageCount %></span><a href="<%=PrvUrl %>" style="float:right;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/product_19.gif" /></a></div>
      </div>
        <div class="productList122"><span class="s1">快速分类</span>
        <%--<div class="pr_xl"><%=sortTitle%>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>" href="<%=string.Format(EnUrls.MarketListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchArea) %>">产品名称</a></li>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>" href="<%=string.Format(EnUrls.MarketListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchArea) %>">名称降序</a></li>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t2","","pr_xla") %>" href="<%=string.Format(EnUrls.MarketListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchArea) %>">名称升序</a></li>
          </ul>
        </div>
        <div class="pr_xl"><%=sortDate %>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>" href="<%=string.Format(EnUrls.MarketListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchArea) %>">更新时间</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>" href="<%=string.Format(EnUrls.MarketListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchArea) %>">由近到远</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d2","","pr_xla") %>" href="<%=string.Format(EnUrls.MarketListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchArea) %>">由远到近</a></li>
          </ul>
        </div>
        <div class="pr_xl"><%=sortHot %>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>" href="<%=string.Format(EnUrls.MarketListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchArea) %>">推荐产品</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>" href="<%=string.Format(EnUrls.MarketListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchArea) %>">由高到低</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h2","","pr_xla") %>" href="<%=string.Format(EnUrls.MarketListSearch, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchArea) %>">由低到高</a></li>
          </ul>
        </div>--%>
        <%--<label for="supportDIY"><input name="supprotDIY" id="supportDIY" type="checkbox" value="" /><s>支持定制</s></label>--%>
            <div class="pr_xl">所有区域
                <ul>
                    <%foreach (EnSearchItem i in ECMarket.GetSearchItem().FindAll(x=>x.type=="area"&&x.isCur==false))
                      { %>
                        <li><a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,ECommon.QuerySearchKey,ECommon.QueryPageIndex,ECommon.QuerySearchArea+"_"+i.value) %>"><%=i.title %></a></li>
                    <%} %>
                </ul>
            </div>
            <div class="pr_xl">推荐卖场
                <ul>
                    <%foreach (EnMarket i in ECMarket.GetMarketList("auditstatus=1"))
                      { %>
                        <li><a target="_blank" href="<%=string.Format(EnUrls.MarketInfoIndex, i.id) %>"><%=i.title.Length > 5 ? i.title.Substring(0, 5) + "..." : i.title %></a></li>
                    <%} %>
                </ul>
            </div>
        </div>
    </div>
    <div class="dealerLiM2" style="display:none"><strong>推荐卖场</strong> &nbsp;<a href="#">弗劳思丹</a>&nbsp; <a href="#">木之本</a>&nbsp; <a href="#">全友家私</a>&nbsp; <a href="#">玉庭家具</a>&nbsp; <a href="#">甘迪</a>&nbsp; <a href="#">斯曼克</a>&nbsp; <a href="#">卡瑞迪</a>&nbsp; <a href="#">锐驰</a>&nbsp; <a href="#">力排库斯</a>&nbsp; <a href="#">艾菲尔</a></div>
    <div style="height:6px; width:0;"></div>
    <div class="bkStyle2Wrap">
    <%foreach (EnWebMarket m in list)
      { %>
      <div class="bkStyle2"  >
      <div class="deabkStyle2Content">

      <%-- 目前不限制 卖场访问<div class="dText"<%if (m.vip == 0 || m.vip == null) {%> style="position:relative;"<%} %>>
      <div class="bkStyle2Title"<%if (m.vip != 0 && m.vip != null){}else{ %> onmouseover="showTip(this);" onmouseout="hideTip(this);"<%} %>><%if (m.vip != 0 && m.vip != null)
                                   { %><a title="<%=m.title %>" href="<%=string.Format(EnUrls.MarketInfoIndex,m.id) %>"  target="_blank"><img alt="<%=m.title %>" src="<%=EnFilePath.GetMarketLogoPath(m.id.ToString(),m.logo)%>" width="105" height="38"  /></a> <a href="<%=string.Format(EnUrls.MarketInfoIndex,m.id) %>" target="_blank" ><b class="vip"><%=m.title%></b></a><%}
                                   else
                                   { %><a title="<%=m.title %>"><img alt="<%=m.title %>" src="<%=EnFilePath.GetMarketLogoPath(m.id.ToString(),m.logo)%>" width="105" height="38"  /></a> <a><b style="color:#858585;"><%=m.title%></b></a><%} %></div>--%>
    <div class="dText">
        <div class="bkStyle2Title">
        <a title="<%=m.title %>" href="<%=string.Format(EnUrls.MarketInfoIndex,m.id) %>"  target="_blank">
            <img alt="<%=m.title %>" src="<%=EnFilePath.GetMarketLogoPath(m.id.ToString(),m.logo)%>" width="105" height="38"/></a>
            <a href="<%=string.Format(EnUrls.MarketInfoIndex,m.id) %>" target="_blank" ><b class=""><%=m.title%></b></a>
            </div>

      <div class="dText2">
          <p><strong>卖场规模：</strong><%=m.cbm %> 平方米 <%if (true){ %><a class="mHide" href="<%=string.Format(EnUrls.MarketInfoAbout, m.id) %>" target="_blank" >查看卖场介绍</a><%} %></p>
          <%--<p><strong>入驻品牌：</strong><%=m.shopcount %> <a class="mHide" href="<%=string.Format(EnUrls.MarketInfoBrand, m.id) %>" target="_blank" >查看入驻品牌</a></p>--%>
          <p><strong>卖场地址：</strong><%=ECommon.GetAreaName(m.areacode) %><%=m.address %> <%if (true){ %><a class="mHide" href="<%=string.Format(EnUrls.MarketInfoAddress, m.id) %>" target="_blank" >查看地图</a><%} %></p>
          <p><strong>营业时间：</strong><%=m.hours %></p>

          <p class="yh"><label><span class="red">[促销]</span></label>
          <%if (promotions.Where(c => c.promotionsrelated.Where(f => f.marketid == m.id).Any()).Count() > 0)
            {%>
            <%foreach (var pitem in promotions.Where(c => c.promotionsrelated.Where(f => f.marketid == m.id).Any()))
              { %>
           <span class="s1"><a style="color:#164a84;" href="<%=string.Format("/market/promotionsinfo.aspx?mid={0}&id={1}", m.id, pitem.id) %>" target="_blank"><%=pitem.title%></a></span>
           <%break;
              } %>
              <%}
            else if (dpromotions.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1).GroupJoin(dpromotions.LinqData<Mpromotionsrelated>(), c => c.id, c => c.promotionsid, (f, k) => new { f, k }).Where(c => c.k.Where(f => dpromotions.LinqData<Mmarketstoreyshop>().Where(s => s.shopid == f.shopid && s.marketid == m.id).Any()).Any()).Any())
            { %>
            <%foreach (var pitem in dpromotions.Linq.Where(c => c.auditstatus == 1 && c.linestatus == 1).GroupJoin(dpromotions.LinqData<Mpromotionsrelated>(), c => c.id, c => c.promotionsid, (f, k) => new { f, k }).Where(c => c.k.Where(f => dpromotions.LinqData<Mmarketstoreyshop>().Where(s => s.shopid == f.shopid && s.marketid == m.id).Any()).Any()).OrderByDescending(c => c.f.IsRecommend).ThenByDescending(c => c.f.createtime).Take(1))
              { %>
              <span class="s1"><a style="color:#164a84;" href="<%=string.Format("/market/promotionsinfo.aspx?mid={0}&id={1}", m.id, pitem.f.id) %>" target="_blank"><%=pitem.f.title %></a></span>
            <%break;
              } %>
           <%}
            else
            { %>
            <span class="s1" style="color:#164a84;">欢迎来电咨询促销信息</span>
           <%} %>
            </p>
      </div>
      <%if (m.vip == 0 || m.vip == null)
        {%><div class="tipmessage">抱歉，该卖场权限不够，信息暂无法开放！</div><%} %>
      </div>
       <div class="dPic"><img alt="<%=string.IsNullOrEmpty(m.keywords) ? m.title : m.keywords.Split('|')[0] %>" src="<%=EnFilePath.GetMarketSurfacePath(m.id.ToString(), m.surface)%>" width="174" height="188" /></div>
       <i class="clearfix"></i>
      </div>
    </div>
    <%} %>
    </div>

    <webdiyer:aspnetpager ID="AspNetPager1" runat="server" AlwaysShow="false" 
          CurrentPageButtonClass="cpb" CssClass="pager"
              UrlPaging="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
              PrevPageText="上一页" PageSize="20">
        </webdiyer:aspnetpager>
    
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
        if (scrollHeight > SIPAUTO_OtherTop - parseInt($('#floatBar').css('top').replace('px',''))) {
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
    <script type="text/javascript">
        $(function () {
            $('#searchTypeList>a').removeClass("Searcha");
            $('#searchTypeList>a:eq(2)').addClass("Searcha");
            $("#searchTypeDisplay").html("搜卖场");        
        })
        
        function showTip(obj) {
            $(obj).parent().find('.tipmessage').show();
            $(obj).find('a>b').css('color','#fff');
        }
        function hideTip(obj) {
            $(obj).parent().find('.tipmessage').hide();
            $(obj).find('a>b').css('color', '#858585');
        }
    </script>
</body>
</html>