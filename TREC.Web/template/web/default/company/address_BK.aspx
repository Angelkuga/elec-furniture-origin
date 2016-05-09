<%@ Page Language="C#" AutoEventWireup="true"  Inherits="TREC.Web.aspx.company.address" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register src="../ascx/_headA.ascx" tagname="_headA" tagprefix="uc1" %>
<%@ Register src="../ascx/_resource.ascx" tagname="_resource" tagprefix="uc2" %>
<%@ Register src="../ascx/_companynav.ascx" tagname="_companynav" tagprefix="uc3" %>
<%@ Register src="../ascx/_foot.ascx" tagname="_foot" tagprefix="uc4" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<%@ Register src="../ascx/_companyproduct.ascx" tagname="_companyproduct" tagprefix="uc5" %>
<%@ Register Src="../ascx/_AreaSelect.ascx" TagName="_AreaSelect" TagPrefix="My" %>
<%@ Register src="../ascx/_companykeys.ascx" tagname="_companykeys" tagprefix="uc6" %>
<%@ Register src="../ascx/_teladdress.ascx" tagname="_teladdress" tagprefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_companykeys ID="_companykeys1" Title="-店铺地址" runat="server" />
    <uc2:_resource ID="_resource1" runat="server" />
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

<uc1:_headA ID="_headA1" runat="server" />
<uc3:_companynav ID="_companynav1" runat="server" />
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
                    <li><a href="#" class="pr12-tia">所有店铺</a></li>
                </ul>
                <div class="pr12-fy">
                    <strong style="color:#777;">
                    <%foreach (CompanyBrand b in companyInfo.CompanyBrandList)
                        { %>
                        &nbsp;&nbsp;&nbsp;<%=b.title + "："%><b class="auto_BD182D"><%=ECShop.GetShopList("linestatus=1 and id in (select shopid from t_shopbrand where brandid=" + (b.id != null && b.id != "" ? b.id : "0") + ")").Count%>家</b>
                    <%} %>
                    </strong>
                </div>
            </div>
            <div class="productList122">
                <span class="s1">快速分类</span>
                <div class="pr_xl">
                    所有品牌
                    <ul>
                        <%foreach (CompanyBrand b in companyInfo.CompanyBrandList)
                            { %>
                            <li><a href="<%=string.Format(EnUrls.CompanyInfoAddressList,ECommon.QueryCId,b.id,"1")%>"><%=b.title %></a></li>
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
                    <My:_AreaSelect ID="myareaselect" runat="server" />
                    <input type="button" id="btnareasearch" value="搜索" />
                    <script type="text/javascript">
                        $(function () {
                            var rurl = '<%=string.Format(EnUrls.CompanyInfoAddressList2, ECommon.QueryCId, "", ECommon.QueryPageIndex, "$1") %>';
                            $('#btnareasearch').click(function () {
                                var areacode = window["<%=myareaselect.ClientID %>"].valueField.value;
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
                <div class="brandsgc01">
                    <a href="<%=string.Format(EnUrls.ShopInfoIndex, s.id) %>" title="<%=s.title %>" target="_blank"><img alt="<%=s.title %>" src="<%=EnFilePath.GetShopThumbPath(s.id.ToString(),s.thumb) %>" height="109" width="145" /></a>
                </div>
                <div class="brandsgc02">
                    <h3><a href="<%=string.Format(EnUrls.ShopInfoIndex, s.id) %>"><%=s.title%></a>&nbsp;
                     <%if (!string.IsNullOrEmpty(s.qq))
                       { %>
                    <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=<%=s.qq%>&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:<%=s.qq%>:41" alt="点击这里给我发消息" title="点击这里给我发消息"></a>
                    <%} %>
                    </h3>
                    <p><strong>经销品牌</strong>：<font><%=s.BrandName.Replace(",", " ")%></font>&nbsp;&nbsp;<strong>品牌风格：</strong><font><%=ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "3", (ECBrand.GetBrandsInfo("where brandid=" + (s.ShopBrandInfo == null ? "0" : s.ShopBrandInfo.id)) ?? new EnBrands()).style, ',', " ")%></font></p>
                    <p><img src="<%=ECommon.WebResourceUrlToWeb %>/images/house.gif" style=" float:left; margin:6px 5px 0 0;" /><%=s.address%></p>
                    <a class="addressphone"><%=s.phone %></a>
                </div>
                <div class="brandsgc03">
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
                </div>
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
      <uc5:_companyproduct ID="_companyproduct1" runat="server" />
        <uc7:_teladdress ID="_teladdress1" runat="server" />
    </div>
  </div>
</div>
<uc4:_foot ID="_foot1" runat="server" />
</body>
</html>
