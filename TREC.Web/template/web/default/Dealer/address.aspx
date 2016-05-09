<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="address.aspx.cs" Inherits="TREC.Web.template.web.Dealer.address" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %> 

<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<%@ Register Src="../ascx/_AreaSelect.ascx" TagName="_AreaSelect" TagPrefix="My" %>
<%@ Register Src="../ascx/HeadDealer.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register src="../ascx/DealerProduct.ascx" tagname="DealerProduct" tagprefix="uc2" %>

<%@ Register src="../ascx/DealerteladdressCon.ascx" tagname="DealerteladdressCon" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=title +"-店铺地址"+ seoword %></title>
    
    <link href="/resource/content/css/core.css" rel="stylesheet" />
    <link href="/resource/content/css/factory/factory.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />
    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/factory/factory.js"></script>
    <script type="text/javascript">
        myFocus.set({
            id: 'fjwcontainer', //焦点图盒子ID
            pattern: 'mF_taobao2010', //风格应用的名称
            path: '<%=ECommon.WebResourceUrl %>/script/pattern/',
            time: 6, //切换时间间隔(秒)
            trigger: 'mouseover', //触发切换模式:'click'(点击)/'mouseover'(悬停)
            width: 767, //设置图片区域宽度(像素)
            height: 331, //设置图片区域高度(像素)
            txtHeight: 0//文字层高度设置(像素),'default'为默认高度，0为隐藏
        });
    </script>
    <script type="text/javascript">
        $(function () {
            var sb = '<%=ECommon.QuerySearchBrand.ToLower()%>';
            if (sb.indexOf("_a") >= 0) {
                sb = sb.replace("_a", "");
            }
            else if (sb.indexOf("_b") >= 0) {
                sb = sb.replace("_b", "");
            }
            else {
                sb = '<%=ECommon.QuerySearchBrand %>';
            }
            if (sb == "") {
                $($("#brandNav li:first-child a")).addClass("brandjs1a")
            }
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
  <uc1:header ID="header1" runat="server" />
<div class="site"><a href="/">家具快搜</a> > <a href="/companybrandlist.aspx">品牌</a> >招商信息</div>
    <div class="homebrandsc">
  <div class="topNav992">
    <div class="homebraLift">
      <div class="productList1" style="margin-top:0;">
        <%--<div class="brandjs1">
           <ul class="ul1"  id="brandNav">
              <%foreach (CompanyBrand b in companyInfo.CompanyBrandList)
                { %>
                  <li><a href="<%=string.Format(EnUrls.CompanyInfoAddressList,ECommon.QueryCId,b.id,"1")%>" class="<%=UiCommon.QueryStringCur("brand", b.id.ToString(), "", "brandjs1a") %>"><img src="<%=EnFilePath.GetBrandLogoPath(b.id.ToString(),b.thumb) %>" width="105" height="38" /></a></li>
              <%} %>
            </ul>
          <span class="s1"><%=BrandTitle %>-相关经销商地址&nbsp;</span>
          <div class="brandsPromotion"></div></div>--%>
        <%--<div class="brandsDealer-map"><img src="<%=ECommon.WebResourceUrl %>/images/brands_11.jpg" /></div>--%>
        <div class="productList12">
            <div class="productList121">
                <ul class="pr12-ti">
                    <li><a href="/Dealer/address.aspx?did=<%=did %>" class="pr12-tia" >所有店铺</a></li>
                </ul>
                <div class="pr12-fy">
                    <strong style="color:#777;">
                    <%foreach (Haojibiz.t_brand b in _brandlist)
                        { %>
                        &nbsp;&nbsp;&nbsp;<%=b.title + "："%><b class="auto_BD182D"><%=ECShop.GetShopList("linestatus=1 and id in (select shopid from t_shopbrand where brandid=" + b.id+")").Count%>家</b>
                    <%} %>
                    </strong>
                </div>
            </div>
            <div class="productList122">
                <span class="s1">快速分类</span>
                <div class="pr_xl">
                    所有品牌
                    <ul>
                        <%foreach (Haojibiz.t_brand b in _brandlist)
                            { %>
                            <li><a href="/Dealer/address.aspx?did=<%=did %>&bid=<%=b.id %>&page=<%=getpage %>"><%=b.title %></a></li>
                        <%} %>
                    </ul>
                </div>
                <%--<div class="pr_xl">
                    所有地区
                    <ul>
                        <%foreach (EnArea a in AreaList)
                          { %>
                          <li><a href="<%=a.areacode %>"><%=a.areaname %></a></li>
                        <%} %>
                    </ul>
                </div>--%>
                <div class="pr_xl" style="width:auto; text-indent:0; background:none;">
                   <%-- <My:_AreaSelect ID="myareaselect" runat="server" />--%>
                    <input type="button" id="btnareasearch" value="搜索"  style="display:none;"/>
                    <script type="text/javascript">
                        $(function () {
                            var rurl = '<%=string.Format(EnUrls.CompanyInfoAddressList2, ECommon.QueryCId, "", ECommon.QueryPageIndex, "$1") %>';
                            $('#btnareasearch').click(function () {
                                var areacode = window[""].valueField.value;
                                rurl = rurl.replace("$1", areacode);
                                location.href = rurl;
                            });
                        });
                    </script>
                </div>
            </div>
        </div>
        
        <%if (list.Count > 0)
          { %>
        <%foreach (EnWebShop s in list)
          {  %>
          <%--<div class="brandsDealer">
              <div class="dealerEn">
                  A</div>
              <div class="brandsDealerBj">
                  <div class="brandsDealer1">
                      <a href="#">
                          <img src="<%=EnFilePath.GetShopThumbPath(s.id.ToString(),s.thumb) %>" width="141"
                              height="106" /></a></div>
                  <div class="brandsDealer2">
                      <p class="Dealer1">
                          <strong><a href="#">
                              <%=s.title%></a></strong></p>
                      <p>
                          <strong>经销品牌</strong>：<font><%=s.BrandName.Replace(",", " ")%></font>&nbsp;&nbsp;<strong>品牌风格：</strong><font><%=ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "3", s.StyleName, ',', " ")%></font></p>
                      <p>
                          <img src="<%=ECommon.WebResourceUrlToWeb %>/images/index_121.gif" style="float: left;
                              margin: 4px 5px 0 0" /><%=s.address%></p>
                      <div>
                          <%=s.phone%></div>
                      <div class="lianxifl">
                          联系时，请说是在福家网上看到的，谢谢！</div>
                  </div>
                  <div class="brandsgc03">
                      <a href="#">
                          <img src="<%=EnFilePath.GetBrandLogoPath(s.ShopBrandInfo.id,s.ShopBrandInfo.thumb) %>"
                              width="105" height="38" /></a></div>
              </div>
              <div class="productView">
                  <div class="br-gcs hd">
                      <ul>
                          <li><a href="#">公司介绍</a></li>
                          <li><a href="#">店铺地址</a></li>
                          <li><a href="#">产品展示</a></li>
                      </ul>
                  </div>
                  <div class="br-jj bd">
                      <div class="item">
                          <%=s.descript%>
                      </div>
                      <div class="item">
                      </div>
                      <div class="item">
                      </div>
                      <div class="item">
                      </div>
                  </div>
              </div>
          </div>--%>
          <div class="brandsgc">
            <div class="brandsgc0">
                <div class="brandsgc01" style="float:left;">
                    <a href="/shop/index.aspx?sid=<%=s.id %>&did=<%=did %>" title="<%=s.title %>" target="_blank"><img alt="<%=s.title %>" src="<%=EnFilePath.GetShopThumbPath(s.id.ToString(),s.thumb) %>" style="width:450px;height:208px;" /></a>
                </div>
                <div class="brandsgc02">
                    <h3><a href="/shop/index.aspx?sid=<%=s.id %>&did=<%=did %>" style="font-size:18px;"><%=s.title%></a>&nbsp;
                     <%if (!string.IsNullOrEmpty(s.qq) && isPay)
                       { %>
                    <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=<%=s.qq%>&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:<%=s.qq%>:41" alt="点击这里给我发消息" title="点击这里给我发消息"></a>
                    <%} %>
                    </h3>
                    <p style="font-size:14px;"><strong>经销品牌</strong>：<font><%=s.BrandName.Replace(",", " ")%></font>&nbsp;&nbsp;<strong>品牌风格：</strong><font><%=ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "3", (ECBrand.GetBrandsInfo("where brandid=" + (s.ShopBrandInfo == null ? "0" : s.ShopBrandInfo.id)) ?? new EnBrands()).style, ',', " ")%></font></p>
                    <%if (isPay)
                      { %>
                    <p style="font-size:14px;"><strong>地址：</strong> 
                    <%=s.address%>
                    </p>
                    <% }%>
                    <p style="font-size:14px;">[促销]<%=GetPromotionsInfor(s.id,s.phone)%></p>
                </div>
                <%--<div class="brandsgc03">
                    <div class="productPic131" style="margin-top:10px;">
                        <%foreach (var item in promotionslist.Where(c => c.promotionsrelated.Any(f => f.shopid == s.id)).Take(3))
                      { %>
                            <p class="Dealer1" style="text-align:left; margin-left:12px;">
                                <span style="display:list-item; list-style-type:square; color:#676767;"></span><span>[优惠]</span><a href="<%=string.Format(EnUrls.CompanyInfoPromotionsInfo, ECommon.QueryCid, item.id) %>"><%=item.title %></a>
                            </p>
                        <%} %>
                    </div>
                    <div class="productView">
                        <div class="br-gcs hd">
                            <ul>
                                <li>&nbsp;</li>
                                <li><a class="btn" href="#" onclick="window.open('<%=string.Format(EnUrls.ShopInfoIndex, s.id) %>');" target="_blank">店铺首页</a></li>
                                <li><a class="btn" href="#" onclick="window.open('<%=string.Format(EnUrls.ShopInfoAddress, s.id) %>');" target="_blank">店铺地址</a></li>
                            </ul>
                        </div>
                    </div>
                </div>--%>
            </div>
          </div>
        <%} %>
        <%}
          else
          { %>
            <div class="brandsgc">
                <img src="<%=ECommon.WebResourceUrlToWeb %>/images/noinfo.jpg" />
            </div>
        <%} %>
        <webdiyer:aspnetpager ID="AspNetPager1" runat="server" AlwaysShow="false" 
          CurrentPageButtonClass="cpb" CssClass="pager"
              UrlPaging="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
              PrevPageText="上一页">
        </webdiyer:aspnetpager>
      </div>
    </div>
    <div class="homebraRight">
       <uc2:DealerProduct ID="DealerProduct1" runat="server" />
       <uc3:DealerteladdressCon ID="DealerteladdressCon1" runat="server" />
    </div>
  </div>
</div> 
    <ucfooter:footer ID="header2" runat="server" />
    </form>
</body>
</html>
