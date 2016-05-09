<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.market.about" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_marketnav.ascx" TagName="_marketnav" TagPrefix="uc3" %>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>
<%@ Register src="../ascx/_marketkeys.ascx" tagname="_marketkeys" tagprefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_marketkeys ID="_marketkeys1" Title="-家具卖场-卖场介绍" runat="server" />
    <uc2:_resource ID="_resource1" runat="server" />
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
</head>
<body>
    <uc1:_headA ID="_headA1" runat="server" />
    <uc3:_marketnav ID="_marketnav1" runat="server" />
    <div style="height:6px;"></div>
    <div class="marketdesc">
        <div class="topNav992">
            <div class="homebraLift" style="width:745px;padding-top:15px;">
            <div class="braabtitle" style="width:100%;float:left;">卖场介绍</div>
             <div style="margin-top:0;width:100%;float:left;"> 
                        <%--<div class="braabtitle">
                            <%=marketInfo.title %></div>--%>
                        <div class="homebraLi22" style="padding:0;padding-top:18px;">
                            <%--<div style="float:left; margin-right:15px;"><img  src="<%=EnFilePath.GetMarketSurfacePath(marketInfo.id.ToString(),marketInfo.surface) %>" height="346" width="219"></div>--%>
                            <div class="homebraLi221" style="width: 738px;">
                                <%=marketInfo.descript %>
                            </div>
                        </div>                   

                   <%-- <div class="braAbout">
                        <div class="homebraLi22" style="float:none;">
                            <div class="braabtitle">
                                联系方式<a href="#" style="color: #b70d01; text-decoration: underline; float:right; font-weight:normal; font-size:12px; text-decoration:none;">查看全部联系方式</a></div>
                            <div class="braAboutlx">
                                <div style="float: right;">
                                    <img width="245" height="199" src="<%=ECommon.WebResourceUrlToWeb %>/images/brands_05.jpg"><p class="p1">将地址发送短信至手机</p></div>
                                <b>所属区县</b>：<%=marketInfo.areacode %>
                                <br>
                                <b>地址</b>：<%=marketInfo.address %>
                                <br>
                                <b>乘车路线</b>：<%=marketInfo.busroute %><br>
                                <b>咨询电话</b>：<%=marketInfo.zphone %>
                                <br>
                                <b>投诉电话</b>：<%=marketInfo.phone %><br>
                                <b>营业时间</b>：<%=marketInfo.hours %><br>
                                <b>营业面积</b>：<%=marketInfo.cbm %>平方米<br>
                                <a href="#" style="color: #b70d01; text-decoration: underline;">更多联系方式</a><br>
                            </div>
                        </div>
                    </div>--%>
                    <%--<div class="braAbout" style="display: none">
                        <div class="braabtitle">
                            <span class="spana1"><a href="#">卖场照片</a></span>卖场照片</div>
                        <div id="braAboutzs" class="braAboutzs">
                            <ul>
                                <%if (marketInfo.desimage != null)
                                  { %>
                                <%foreach (string s in marketInfo.desimage.Split(','))
                                  { %>
                                <%if (s != "")
                                  { %>
                                <li><a href="javascript:;">
                                    <img width="88" height="121" src="<%=EnFilePath.GetMarketDescriptPath(marketInfo.id.ToString(),s) %>"></a></li>
                                <%} %>
                                <%} %>
                                <%}
                                  else
                                  { %>
                                <li><a href="javascript:;">
                                    <img width="88" height="121" src=" <%=ECommon.WebResourceUrlToWeb %>/images/noshop.jpg"></a></li>
                                <%} %>
                            </ul>
                        </div>
                    </div>--%>
                    <%--<div class="braAbout">
                        <div class="braabtitle">
                            <span class="spana1"><a href="<%=string.Format(EnUrls.MarketInfoBrand,marketInfo.id) %>">
                                查看全部入驻品牌</a></span>入驻品牌</div>
                        <div class="brandjs3">
                            <%foreach (EnWebMarket.MarketShop s in marketInfo.MarketShopList)
                              { %>
                            <div class="brandjs31">
                                <span>
                                    <img width="74" height="56" src="<%=EnFilePath.GetShopThumbPath(s.id.ToString(),s.thumb) %>"></span>
                                <p class="haui">
                                    <a style="color: #b1051b;" href="#">
                                        <%=s.title%>
                                        <img src="images/index_117.gif"></a></p>
                                <p class="address">
                                    <%=s.address%></p>
                                <p class="phone">
                                    <%=s.phone%></p>
                            </div>
                            <%} %>
                        </div>
                    </div>--%>
                </div>
            <div class="braabtitle" style="width:100%;float:left;margin-top:30px;">联系方式</div>
            <div class="braAboutlx" style="padding-bottom:10px;width:100%;float:left;border-bottom:1px dotted #c0c0c0;height:auto;margin-bottom:60px;">
                    咨询电话：<%=marketInfo.lphone%><br />
                    招商电话：<%=marketInfo.zphone %><br />
                    联系人：<%=marketInfo.linkman %><br />
                    传真：<%=marketInfo.fax %><br />
                    营业时间：<%=marketInfo.hours %><br />
                    营业面积：<%=marketInfo.cbm %>(平方米)<br />
                    地址：<%=ECommon.GetTrueCodeNameNew(ECommon.GetAreaName(marketInfo.areacode)+marketInfo.address) %><br />                            
                    网址：<a href="<%=string.IsNullOrEmpty(marketInfo.homepage)?"#":(marketInfo.homepage.ToLower().Contains("http://")?marketInfo.homepage:"http://"+marketInfo.homepage)%>" style="color: #c61f38; text-decoration: underline;"><%=marketInfo.homepage %></a>
                </div>
            </div>
            <div class="homebraRight">
                <%--<div class="productNew c61f38" style="margin-bottom:8px;">
                    <div class="productNew-header">
                        <span class="left">最新产品</span> <a href="#"
                            target="_blank" class="right">更多</a>
                    </div>
                    <div class="productNew-content">
                        <ul>
                            <li>
                                <p class="image">
                                    <a href="#">
                                        <img alt="" width="212" src="/upload/product/thumb/14106//20110228092857.jpeg" /></a></p>
                                <p class="title">
                                    <a href="#" target="_blank">荣尊木坊 衣柜 RZ605 全实木</a></p>
                                <p class="price">
                                    <strong>市场参考价：</strong><a>11250.00元</a></p>
                                <p class="button">
                                    <a href="#" class="btn">所有产品</a>
                                    <a href="#" class="btn">品牌介绍</a> 
                                    <a href="#" class="btn">所有店铺</a>
                                </p>
                            </li>
                            <li>
                                <div class="sp">
                                </div>
                            </li>
                            <li>
                                <p class="image">
                                    <a href="#">
                                        <img alt="" width="212" src="/upload/product/thumb/14106//20110228092857.jpeg" /></a></p>
                                <p class="title">
                                    <a href="#" target="_blank">荣尊木坊 衣柜 RZ605 全实木</a></p>
                                <p class="price">
                                    <strong>市场参考价：</strong><a>11250.00元</a></p>
                                <p class="button">
                                    <a href="#" class="btn">所有产品</a>
                                    <a href="#" class="btn">品牌介绍</a> 
                                    <a href="#" class="btn">所有店铺</a>
                                </p>
                            </li>
                            <li>
                                <div class="sp">
                                </div>
                            </li>
                            <li>
                                <p class="image">
                                    <a href="#">
                                        <img alt="" width="212" src="/upload/product/thumb/14106//20110228092857.jpeg" /></a></p>
                                <p class="title">
                                    <a href="#" target="_blank">荣尊木坊 衣柜 RZ605 全实木</a></p>
                                <p class="price">
                                    <strong>市场参考价：</strong><a>11250.00元</a></p>
                                <p class="button">
                                    <a href="#" class="btn">所有产品</a>
                                    <a href="#" class="btn">品牌介绍</a> 
                                    <a href="#" class="btn">所有店铺</a>
                                </p>
                            </li>
                        </ul>
                    </div>
                </div>--%>
                <div class="brandgz1 brandst">推荐品牌</div>
                <div class="brandsUl" style="margin-bottom:8px;">
                    <ul style=" height:auto;">
                        <li onmouseover="this.style.borderColor='#DE0F00'" onmouseout="this.style.borderColor='#DADADA'" style="width:196px; height:70px; margin-left:auto; margin-right:auto; float:none; display:block;"><a href="http://www.fujiawang.com/pinpai/miluooudian.html"><img src="/resource/web/images/productbrand001.gif" title="MIRO" /></a></li>
                        <li onmouseover="this.style.borderColor='#DE0F00'" onmouseout="this.style.borderColor='#DADADA'" style="width:196px; height:70px; margin-left:auto; margin-right:auto; float:none; display:block;"><a href="http://www.fujiawang.com/pinpai/yuting.html"><img src="/resource/web/images/productbrand002.gif" title="玉庭家具" /></a></li>
                        <li onmouseover="this.style.borderColor='#DE0F00'" onmouseout="this.style.borderColor='#DADADA'" style="width:196px; height:70px; margin-left:auto; margin-right:auto; float:none; display:block;"><a href="http://www.fujiawang.com/pinpai/qingshulin.html"><img src="/resource/web/images/productbrand003.gif" title="青树木" /></a></li>
                        <li onmouseover="this.style.borderColor='#DE0F00'" onmouseout="this.style.borderColor='#DADADA'" style="width:196px; height:70px; margin-left:auto; margin-right:auto; float:none; display:block;"><a href="http://www.fujiawang.com/pinpai/yamengsha.html"><img src="/resource/web/images/productbrand004.gif" title="AMSA" /></a></li>
                    </ul>
                </div>
                <%--<div class="homebraRight1 homebraRight3" style="margin: 0">
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
