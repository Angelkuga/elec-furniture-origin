<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.market.business" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_marketnav.ascx" TagName="_marketnav" TagPrefix="uc3" %>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>
<%@ Register src="../ascx/_marketkeys.ascx" tagname="_marketkeys" tagprefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc6:_marketkeys ID="_marketkeys1" Title="-家具卖场-招商信息" runat="server" />
    <uc2:_resource ID="_resource1" runat="server" />
</head>
<body>
   <uc1:_headA ID="_headA1" runat="server" />
    <uc3:_marketnav ID="_marketnav1" runat="server" />
    <div class="marketdesc">
        <div class="topNav992">
            <div class="homebraLift">
                <div style="margin-top: 0; border: 0;" class="homebraLi2">
                    <div class="braAbout">
                    </div>
                    <div class="braAbout">
                        <%--<div class="brandsDealer-map" id="maps">
                        </div>
                        <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2"></script>
                        <script type="text/javascript">
                            var map = new BMap.Map("maps");
                            map.centerAndZoom(new BMap.Point(116.404, 39.915), 11);
                            var local = new BMap.LocalSearch(map, {
                                renderOptions: { map: map }
                            });
                            local.search("<%=ECommon.GetTrueCodeNameNew(ECommon.GetAreaName(marketInfo.areacode)+marketInfo.address) %>");
                        </script>
                        <br />
                        <br />--%>
                        <div class="braabtitle">招商信息</div>
                        <div class="braAboutlx" style="height: auto; padding-bottom: 10px; border-bottom: 1px dotted #c0c0c0;">
                            招商电话：<%=marketInfo.zphone %><br />
                            地址：<%=ECommon.GetTrueCodeNameNew(ECommon.GetAreaName(marketInfo.areacode)+marketInfo.address) %><br />                            
                            网址：<a href="<%=string.IsNullOrEmpty(marketInfo.homepage)?"#":(marketInfo.homepage.ToLower().Contains("http://")?marketInfo.homepage:"http://"+marketInfo.homepage)%>" style="color: #c61f38; text-decoration: underline;"><%=marketInfo.homepage %></a><br />
                        </div>
                    </div>
                </div>
            </div>
            <div class="homebraRight">
                <div class="brandgz1 brandst" style="margin-top: 12px;">推荐品牌</div>
                <div class="brandsUl" style="margin-bottom:8px;">
                    <ul style=" height:auto;">
                        <li onmouseover="this.style.borderColor='#DE0F00'" onmouseout="this.style.borderColor='#DADADA'" style="width:196px; height:70px; margin-left:auto; margin-right:auto; float:none; display:block;"><a href="http://www.fujiawang.com/pinpai/miluooudian.html"><img src="/resource/web/images/productbrand001.gif" title="MIRO" /></a></li>
                        <li onmouseover="this.style.borderColor='#DE0F00'" onmouseout="this.style.borderColor='#DADADA'" style="width:196px; height:70px; margin-left:auto; margin-right:auto; float:none; display:block;"><a href="http://www.fujiawang.com/pinpai/yuting.html"><img src="/resource/web/images/productbrand002.gif" title="玉庭家具" /></a></li>
                        <li onmouseover="this.style.borderColor='#DE0F00'" onmouseout="this.style.borderColor='#DADADA'" style="width:196px; height:70px; margin-left:auto; margin-right:auto; float:none; display:block;"><a href="http://www.fujiawang.com/pinpai/qingshulin.html"><img src="/resource/web/images/productbrand003.gif" title="青树木" /></a></li>
                        <li onmouseover="this.style.borderColor='#DE0F00'" onmouseout="this.style.borderColor='#DADADA'" style="width:196px; height:70px; margin-left:auto; margin-right:auto; float:none; display:block;"><a href="http://www.fujiawang.com/pinpai/yamengsha.html"><img src="/resource/web/images/productbrand004.gif" title="AMSA" /></a></li>
                    </ul>
                </div>
                <%--<div class="homebraRight1 homebraRight3" style="margin-top: 12px;">
                    <div class="promotions">
                        <span><a href="<%=string.Format(EnUrls.MarketInfoBrand,marketInfo.id) %>">更多</a></span>推荐入驻品牌</div>
                    <ul>
                        <%foreach (EnWebMarket.MarketBrand b in marketInfo.MarketBrandList)
                          { %>
                        <li><a href="<%=string.Format(EnUrls.CompanyInfoBrandList,b.companyid,b.id) %>">
                            <img src="<%=EnFilePath.GetBrandLogoPath(b.id,b.logo) %>" width="105" height="38"></a></li>
                        <%} %>
                    </ul>
                </div>--%>
                <%--<div class="homebraRight1 homebraRight3">
                    <div class="promotions">
                        <span><a href="<%=EnUrls.PromotionList%>">更多</a></span>促销信息</div>
                    <%=ECPromotion.GetPromotionHtml(ECPromotion.GetWebTopPromotionListToMarket(4,marketInfo.id))%>
                </div>--%>
            </div>
        </div>
    </div>
    <uc4:_foot ID="_foot1" runat="server" />
</body>
</html>