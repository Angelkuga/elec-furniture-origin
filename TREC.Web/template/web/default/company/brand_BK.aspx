<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.company.brand" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_companynav.ascx" TagName="_companynav" TagPrefix="uc3" %>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>
<%@ Register Src="../ascx/_companyproduct.ascx" TagName="_companyproduct" TagPrefix="uc5" %>
<%@ Register src="../ascx/_companykeys.ascx" tagname="_companykeys" tagprefix="uc6" %>
<%@ Register src="../ascx/_teladdress.ascx" tagname="_teladdress" tagprefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_companykeys ID="_companykeys1" Title="-厂家品牌" runat="server" />
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
            if ("<%=ECommon.QuerySearchBrand %>" == "") {
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
                <div class="shopindex0">
                    <div class="Brand">
                        <div class="BrandLeft">
                            <p>
                                <span>品牌：</span><a target="_blank" href="<%=string.Format(EnUrls.CompanyInfoIndex, companyInfo.id) %>"><strong><%=currentBrand.title %></strong></a></p>
                            <p style="border-bottom: 1px dotted #C0C0C0;">
                                <span>厂商：</span><%=companyInfo != null ? companyInfo.title : "暂无" %>
                                &nbsp;&nbsp;&nbsp;<span>风格：</span><%=ECConfig.GetConfigInfoNew(" type=3 and value in(" + StyleString + ")")%></p>
                            <p>
                                <%=TRECommon.HTMLUtils.GetAllTextFromHTML(companyInfo.descript).Length > 76 ? TRECommon.HTMLUtils.GetAllTextFromHTML(companyInfo.descript).Substring(0, 76) + "..." : TRECommon.HTMLUtils.GetAllTextFromHTML(companyInfo.descript)%></p>
                        </div>
                        <div class="BrandRight" style="position: relative;">
                            <div style="height: 70px;">
                                <img alt="<%=currentBrand.title %>" src="<%=EnFilePath.GetBrandLogoPath(currentBrand.id, currentBrand.logo) %>"
                                    width="196" height="70" />
                            </div>
                            <div class="productView" style="display: block; margin-top: 3px; width: 197px; position: relative;
                                right: 0;">
                                <div class="br-gcs">
                                    <ul>
    <li style="margin-right: 2px;"><a href="<%=string.Format(EnUrls.CompanyInfoProductList, ECommon.QueryCId, currentBrand.id, "", "", "", "", "", "", "", "", "", "", "")%>" class="btn">所有产品</a> </li>
    <li><a href="<%=string.Format(EnUrls.CompanyInfoAddress, companyInfo.id) %>" class="btn">所有店铺</a> </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="homebraLi2" style="position:relative; overflow:visible; margin-top:8px;">
                    <%if (companyInfo.CompanyBrandList.Count > 1)
                      { %>
                    <div style="width:206px; height:35px; background:url(/resource/web/images/tiptool.gif) no-repeat; position:absolute; top:-30px; right:37px;">
                        <span onclick="this.parentNode.style.display='none'" style=" cursor:pointer; width:11px; height:11px; background:url(/resource/web/images/tiptool.gif) right top no-repeat; display:block; float: right; margin-right:8px; margin-top:10px;">&nbsp;</span>
                    </div>
                    <%} %>
                    <div class="brandjs">
                        <div class="brandjs1">
                            <ul class="ul1" id="brandNav">
                                <%foreach (CompanyBrand b in companyInfo.CompanyBrandList)
                                  { %>
                                <li><a title="<%=b.title %>" href="<%=string.Format(EnUrls.CompanyInfoIndex,ECommon.QueryCId)%>"
                                    class="<%=UiCommon.QueryStringCur("brand", b.id.ToString(), "", "brandjs1a") %>">
                                    <img src="<%=EnFilePath.GetBrandLogoPath(b.id.ToString(),b.logo) %>" alt="<%=b.title %>" width="105"
                                        height="38" /></a></li>
                                <%} %>
                            </ul>
                            <%--<span class="s1"><%=companyInfo.title %></span>--%>
                        </div>
                        <div class="brandjs2">
                            <%=BrandDescript %>
                        </div>
                    </div>
                    <%--<div class="braAbout">
          <div class="braabtitle"><span class="spana1"><a href="#">查看全部产品</a></span>相关产品</div>
          <ul class="braAbout12">
            <%foreach(EnWebProduct p in ECProduct.GetWebProductList(1,4," and brandid="+BrandId,"","",out tmpPageCount)){ %>
            <li>
              <p><a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank"><img src="<%=EnFilePath.GetProductThumbPath(p.id.ToString(), p.thumb) %>" height="131" width="175" /></a></p>
              <p><strong><a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank"><%=p.categorytitle %>(<%=p.sku %>)</a></strong></p>
            </li>
            <%} %>
            
          </ul>
        </div>--%>
                    <%--<div class="braAbout">
          <div class="braabtitle"><span class="spana1"><a href="#">查看全部经销商</a></span>相关经销商</div>
          <div class="brandjs3">
          <%foreach(CompanyShop s in companyInfo.CompanyShopList){ %>
            <div class="brandjs31"><span><img src="<%=EnFilePath.GetShopThumbPath(s.id.ToString(),s.thumb) %>" width="74" height="56" /></span>
              <p class="haui"><a href="<%=string.Format(EnUrls.ShopInfoIndex,s.id) %>" target="_blank" style="color:#b1051b;"><%=s.title %> <img src="images/index_117.gif" /></a></p>
              <p class="address"><%=s.address %></p>
              <p class="phone"><%=s.phone %></p>
            </div>
          <%} %>
          <%if (companyInfo.CompanyShopList.Count == 0)
            { %>
            暂无经销商
          <%} %>
          </div>
        </div>--%>
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
