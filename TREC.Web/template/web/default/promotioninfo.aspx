<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.promotioninfo" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%--<%@ Register src="ascx/_head.ascx" tagname="_head" tagprefix="uc1" %>
<%@ Register src="ascx/_resource.ascx" tagname="_resource" tagprefix="uc2" %>
<%@ Register src="ascx/_foot.ascx" tagname="_foot" tagprefix="uc3" %>
<%@ Register src="ascx/_nav.ascx" tagname="_nav" tagprefix="uc4" %>--%>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
        <%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>家具快搜-优惠资讯_家具行业信息官网_最全的家具品牌、厂商、店铺、家居卖场信息发布和搜素!</title> 
        <meta name="keywords" content="家具活动专区 特价家具 家具秒杀 团购活动 促销活动" />
        <meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！" />
        <ucnewresource:newresource ID="newresource1" runat="server" />
      <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/index/index.css" rel="stylesheet" type="text/css" />
   
    <link href="/resource/content/indexnav/yx_rotaion.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/indexnav/jquery.min.js" type="text/javascript"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/index/index.js"></script>
     <script src="/resource/content/js/core.js" type="text/javascript"></script>

    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />
    <script src="<%=TREC.ECommerce.ECommon.WebResourceUrl%>/script/jquery.jcountdown1.3.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var newDateObj = new Date(Date.parse("<%=promotionInfo.enddatetime.ToString().Replace('-','/')%>"));
            $("#time1").countdown({
                date: (new Date())
            });
        })
    </script>
</head>
<body>
  <uc1:header ID="header1" runat="server" />
 <div class="topNav992 central">
  <div class="productList1">
    <div class="prlifl1 qtPromoxx5 c61f38"><a href="<%=string.Format(EnUrls.PromotionList) %>">返回列表页</a> &nbsp;&nbsp;</div>
    <div class="qtPromoxx6">
    	<div class="qtPromoxx61">
        <div class="qtPromoxx611">
        <h1><%=promotionInfo.title%></h1>
        <p class="time1" id="time1"></p>
        </div>
        
        </div>
        
    	<div class="qtPromoxx62">
    	  <%=promotionInfo.descript%>
        </div>
    </div>

    
    
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
    <ucfooter:footer ID="header2" runat="server" />
</body>
</html>
