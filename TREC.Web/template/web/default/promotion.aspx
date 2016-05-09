<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotion.aspx.cs" Inherits="TREC.Web.aspx.promotion" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register src="ascx/_head.ascx" tagname="_head" tagprefix="uc1" %>
<%@ Register src="ascx/_resource.ascx" tagname="_resource" tagprefix="uc2" %>
<%@ Register src="ascx/_foot.ascx" tagname="_foot" tagprefix="uc3" %>
<%@ Register src="ascx/_nav.ascx" tagname="_nav" tagprefix="uc4" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>家具快搜-资讯_家具行业信息官网_最全的家具品牌、厂商、店铺、家居卖场信息发布和搜素!</title>
    <meta name="keywords" content="家具品牌,家具品牌排名,家具十大品牌,品牌家具,实木家具十大品牌,儿童家具十大品牌,板式家具十大品牌" />
        <meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！" />
    <uc2:_resource ID="_resource1" runat="server" />
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl%>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl%>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl%>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl%>/script/jquery.form.js"></script>
    
</head>
<body>
<uc1:_head ID="_head1" runat="server" />
<uc4:_nav ID="_nav1" runat="server" />
<div class="topNav992 central">
  <div class="productList1">    
    <div class="productList12">
      <div class="productList121">
        <ul class="pr12-ti">
          <li><a class="pr12-tia" href="#">所有资讯</a></li>
        </ul>
        <div class="pr12-fy"><a href="<%=NextUrl %>" class="xyy">下一页</a><span><%=ECommon.QueryPageIndex %>/<%=AspNetPager1.PageCount %></span><a href="<%=PrvUrl %>" style="float:right;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/product_19.gif" /></a></div>
      </div>
      <div class="productList122"><span class="s1">快速分类</span>
        <div class="pr_xl"><%=sortTitle%>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>" href="<%=string.Format(EnUrls.PromotionListsearch, ECommon.QueryCId, ECommon.QuerySId, ECommon.QueryPId, ECommon.QueryBId, ECommon.QueryMid, ECommon.QuerySearchArea, ECommon.QueryStime, ECommon.QueryEtime,  "_t1", ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">活动名称</a></li>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>" href="<%=string.Format(EnUrls.PromotionListsearch, ECommon.QueryCId, ECommon.QuerySId, ECommon.QueryPId, ECommon.QueryBId, ECommon.QueryMid, ECommon.QuerySearchArea, ECommon.QueryStime, ECommon.QueryEtime,  "_t1", ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">名称降序</a></li>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t2","","pr_xla") %>" href="<%=string.Format(EnUrls.PromotionListsearch, ECommon.QueryCId, ECommon.QuerySId, ECommon.QueryPId, ECommon.QueryBId, ECommon.QueryMid, ECommon.QuerySearchArea, ECommon.QueryStime, ECommon.QueryEtime,  "_t2", ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">名称升序</a></li>
          </ul>
        </div>
        <div class="pr_xl"><%=sortDate %>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>" href="<%=string.Format(EnUrls.PromotionListsearch, ECommon.QueryCId, ECommon.QuerySId, ECommon.QueryPId, ECommon.QueryBId, ECommon.QueryMid, ECommon.QuerySearchArea, ECommon.QueryStime, ECommon.QueryEtime,  "_d1", ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">更新时间</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>" href="<%=string.Format(EnUrls.PromotionListsearch, ECommon.QueryCId, ECommon.QuerySId, ECommon.QueryPId, ECommon.QueryBId, ECommon.QueryMid, ECommon.QuerySearchArea, ECommon.QueryStime, ECommon.QueryEtime,  "_d1", ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由近到远</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d2","","pr_xla") %>" href="<%=string.Format(EnUrls.PromotionListsearch, ECommon.QueryCId, ECommon.QuerySId, ECommon.QueryPId, ECommon.QueryBId, ECommon.QueryMid, ECommon.QuerySearchArea, ECommon.QueryStime, ECommon.QueryEtime,  "_d2", ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由远到近</a></li>
          </ul>
        </div>
        <div class="pr_xl"><%=sortHot %>
          <ul>
            <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>" href="<%=string.Format(EnUrls.PromotionListsearch, ECommon.QueryCId, ECommon.QuerySId, ECommon.QueryPId, ECommon.QueryBId, ECommon.QueryMid, ECommon.QuerySearchArea, ECommon.QueryStime, ECommon.QueryEtime,  "_h1", ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">推荐厂家</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>" href="<%=string.Format(EnUrls.PromotionListsearch, ECommon.QueryCId, ECommon.QuerySId, ECommon.QueryPId, ECommon.QueryBId, ECommon.QueryMid, ECommon.QuerySearchArea, ECommon.QueryStime, ECommon.QueryEtime,  "_h1", ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由高到低</a></li>
             <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h2","","pr_xla") %>" href="<%=string.Format(EnUrls.PromotionListsearch, ECommon.QueryCId, ECommon.QuerySId, ECommon.QueryPId, ECommon.QueryBId, ECommon.QueryMid, ECommon.QuerySearchArea, ECommon.QueryStime, ECommon.QueryEtime,  "_h2", ECommon.QuerySearchKey, ECommon.QueryPageIndex) %>">由低到高</a></li>
          </ul>
        </div>
        <%--<label for="supportDIY"><input name="supprotDIY" id="supportDIY" type="checkbox" value="" /><s>支持定制</s></label>--%></div>
    </div>  
        
         <%foreach(EnWebPromotion p in list){ %>
          <div class="brandsDealer promove">
          <div class="brandsDealerBj">
            <div class="brandsProm1">
            <h2 class="c61f38"><a href="<%=string.Format(EnUrls.PromotionInfo,p.id) %>" target="_blank"><%=p.title %></a></h2>
            <p class="promcjie">截至日期：<%=DateTime.Parse(p.enddatetime.ToString()).ToShortDateString() %></p>
            <p><%=p.descript != null && TRECommon.HTMLUtils.GetAllTextFromHTML(p.descript).Length > 100 ? TRECommon.HTMLUtils.GetAllTextFromHTML(p.descript).Substring(0, 99) : TRECommon.HTMLUtils.GetAllTextFromHTML(p.descript)%></p>
            </div>
            <div class="brandsProm2" style="display:none">          
            
            <p class="pm1 c61f38"><a href="#"></a></p>
            <p class="pm2"><img src="../skin/default/images/index_74.gif"> </p>
            <p class="pm2"><img alt="" src="../skin/default/images/index_76.gif"></p>
            </div>
          </div>
        </div>
        <%} %>

    <webdiyer:aspnetpager ID="AspNetPager1" runat="server" AlwaysShow="true" 
          CurrentPageButtonClass="cpb" CssClass="pager"
              UrlPaging="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
              PrevPageText="上一页">
        </webdiyer:aspnetpager>


  </div>
  <div class="productList2">
<div class="brandgz1 brandst">推荐品牌</div>
    <div class="brandsUl">
      <ul>
        <%foreach (EnWebAggregation a in ECommon.GetCompanyListTopBrand())
          { %>
            <li><a href="<%=a.url %>"><img src="<%=EnFilePath.GetAggregationThumbPath(a.id.ToString(),a.thumb) %>" width="<%=a.thumbw %>" height="<%=a.thumbh %>" title="<%=a.title %>" /></a></li>
        <%} %>
      </ul>
    </div>
    <div class="promotionsR2"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/index_62.jpg" /></div>
    <div class="promotionsR1" style="margin-top:8px;">
      <div class="promotions"><span><a href="<%=string.Format(EnUrls.PromotionList) %>" target="_blank">更多</a></span>促销信息</div>
      <div class="prAd1"><script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=14"></script><script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=15"></script></div>
        <%=ECPromotion.GetPromotionHtml(ECPromotion.GetWebTopPromotionList(5))%>
    </div>
    
</div>
</div>
<uc3:_foot ID="_foot1" runat="server" />
</body>
</html>
