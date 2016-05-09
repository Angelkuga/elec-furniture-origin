<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.shop.index" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/headerShop.ascx" TagName="_headerShop" TagPrefix="ucheaderShop" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>

<%--<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_shopnav.ascx" TagName="_shopnav" TagPrefix="uc3" %>--%>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>
<%@ Register Src="../ascx/_shopproduct2.ascx" TagName="_shopproduct" TagPrefix="uc5" %>
<%@ Register Src="../ascx/_shopkeys.ascx" TagName="_shopkeys" TagPrefix="uc6" %>
<%@ Register Src="../ascx/_shopteladdress2.ascx" TagName="_shopteladdress" TagPrefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <uc6:_shopkeys ID="_shopkeys1"  runat="server" />
     <%-- <uc2:_resource ID="_resource1" runat="server" />--%>
    <title>
        <%=pageTitle%></title>
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/factory/factory.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/factory/factory.js" type="text/javascript"></script>
    <link href="/resource/content/css/index/index.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/index/index.js"></script>
    <style>
        .btnf
        {
            margin: 0 auto;
            width: 150px;
        }
        .btnn
        {
            width: 74px;
            height: 22px;
            background: url(/resource/web/images/img2.gif);
            display: block;
            float: left;
            line-height: 22px;
            margin-right: 1px;
        }
        .btnn:hover
        {
            width: 74px;
            height: 22px;
            background: url(/resource/web/images/img1.gif);
            color: #fff;
        }
    </style>
    <%--<link href="content/css/_src/core.css" rel="stylesheet" />
    <link href="content/css/_src/factory/factory.css" rel="stylesheet" />
    <script src="content/js/core.js"></script>
    <script src="content/libs/slides.min.jquery.js"></script>
    <script src="content/js/_src/factory/factory.js"></script>--%>
    <script>
        function addToFavorite() {
            var a = "http://www.jiajuks.com",
b = "家具快搜jiajuks.com-购买家具";
            document.all ? window.external.AddFavorite(a, b) : window.sidebar && window.sidebar.addPanel ? window.sidebar.addPanel(b, a, "") : alert("\u5bf9\u4e0d\u8d77\uff0c\u60a8\u7684\u6d4f\u89c8\u5668\u4e0d\u652f\u6301\u6b64\u64cd\u4f5c!\n\u8bf7\u60a8\u4f7f\u7528\u83dc\u5355\u680f\u6216Ctrl+D\u6536\u85cf\u672c\u7ad9\u3002");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ucheaderShop:_headerShop ID="_headerShop" runat="server" />
    <%--  <uc1:_headA ID="_headA1" runat="server" />
    <uc3:_shopnav ID="_shopnav1" runat="server" /> --%>
    <!---->
    <div class="seller-cont clearfix">
        <div class="w">
            <div class="cont-l fl">

            
                <div id="j_keynote" class="keynote">
                    <div class="slides_container">
                       <%=getbannelImg%>
                    </div>
                </div>

                <%if (ShopPageBase.IsCount)
                  { %>
                <div class="brand">
                    <div class="common-hd clearfix">
                        <span class="hd-l fl b f14">品脾</span> <a href="#" class="hd-r fr songti">查看详细介绍 >></a>
                    </div>
                    <table class="bd g10">
                        <tr>
                            <td width="170" class="tc bd-l">
                                <a href="#" class="block">
                                    <img style='width: 64px; height: 72px' alt="<%=brandcompanyInfo.BrandInfo.title %>"
                                        src="<%=EnFilePath.GetBrandLogoPath(shopInfo.ShopBrandInfo.id, brandcompanyInfo.BrandInfo.logo) %>"
                                        width="196" height="70" /></a>
                            </td>
                            <td class="bd-c">
                                <h6 class="f14 b">
                                <%if (getdid == "0")
                                  { %>
                                    <a target="_blank" href="<%=string.Format(EnUrls.CompanyInfoIndex, shopInfo.ShopBrandInfo.companyid) %>">
                                    <% }
                                  else
                                  {%>
                                     <a href="/Dealer/<%=getdid %>/product-<%=shopInfo.ShopBrandInfo.id %>--------1-----.aspx" target="_blank">
                                     <%} %>
                                        <strong>
                                            <%=ShopPageBase.shopInfo.BrandName.Replace(",", " ")%></strong>
                                            </a>
                                            
                                            </h6>
                                <p>
                                    <b>风格：</b><%=ECConfig.GetConfigInfoNew(" type=3 and value in(" + StyleString+")")%>
                                    <%-- <b class="ml10">材质：</b>全实木--%>
                                </p>
                                <div class="text">
                                    <%=brandcompanyInfo != null && brandcompanyInfo.CompanyInfo != null && brandcompanyInfo.CompanyInfo.descript != null ? (TRECommon.HTMLUtils.GetAllTextFromHTML(brandcompanyInfo.CompanyInfo.descript).Length > 78 ? TRECommon.HTMLUtils.GetAllTextFromHTML(brandcompanyInfo.CompanyInfo.descript).Substring(0, 78) + "..." : TRECommon.HTMLUtils.GetAllTextFromHTML(brandcompanyInfo.CompanyInfo.descript)) : "" %></div>
                            </td>
                            <td width="240" class="tc">
                                <a href="#" class="block">
                                    <img alt="<%=brandcompanyInfo.BrandInfo.title %>" src="<%=EnFilePath.GetBrandLogoPath(shopInfo.ShopBrandInfo.id, brandcompanyInfo.BrandInfo.logo) %>"
                                        width="196" height="70" /></a>
                                <br />
                                <div class="btnf">
                                 <%if (getdid == "0")
                                  { %>
                                    <a href="<%=string.Format(EnUrls.CompanyInfoIndex, shopInfo.ShopBrandInfo.companyid) %>"
                                     <% }
                                  else
                                  {%>
                                   <a href=" /Dealer/brand.aspx?did=<%=getdid %>&bid=<%=shopInfo.ShopBrandInfo.id%>"
                                   
                                     <%} %>
                                        class="btnn">品牌介绍</a> 
                                        <%if (getdid == "0")
                                  { %>
                                        <a href="<%=string.Format(EnUrls.CompanyInfoAddress, shopInfo.ShopBrandInfo.companyid) %>"
                                         <% }
                                  else
                                  {%>
                                  <a href="/Dealer/address.aspx?did=<%=getdid %>&bid=<%=shopInfo.ShopBrandInfo.id%>&page=1"
                                   <%} %>
                                            class="btnn">所有店铺</a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="j_facShop" class="fac-shop" style="display: <%=advstyle%>">
                    <div class="slides_container">
                        <%=adv %>
                        <%--<div class="item">
                            <a href="#" class="block img fl">
                                <img class="block" style='width:606px;height:304px;' src="../../../resource/content/img/factory/f1.jpg" alt="" /></a>
                            <div class="txt fl">
                                <p class="p1">
                                    <a href="#" class="block f18 yahei lh3">全网人气之最 栅栏式简约</a></p>
                                <p>
                                    促销价：<i class="a1">¥1799.00</i></p>
                                <p>
                                    销量：<i class="a2">19502件</i></p>
                                <p>
                                    人气：<i class="a2">676710</i></p>
                                <p>
                                    商品展馆：上海奉贤区体验馆</p>
                                <p>
                                    营业时间：9:00-19:00</p>
                                <p>
                                    客服电话：021-2344555</p>
                            </div>
                        </div>--%>
                    </div>
                </div>
                <div class="recommend">
                    <div class="step-view w" id="j_stepView" style="margin-top: 2px; padding-top: 2px;
                        width: 947px">
                        <div class="tab">
                            <div class="hd clearfix">
                                <ul  style="left:0px;">
                                    <li class="on">推荐产品</li>
                                    <li  >促销产品</li>
                                </ul>
                                 <%if (getdid == "0")
                                   { %>
                                <a href="<%=string.Format(EnUrls.ShopInfoProduct,shopInfo.id) %>" target="_blank" class="fr songti more">更多</a>
                                <%}
                                   else
                                   { %>
                                <a href="/shop/product.aspx?sid=<%=ECommon.QuerySId %>&did=<%=getdid %>" target="_blank" class="fr songti more">更多</a>
                                <%} %>
                            </div>
                            <div class="bd" style='width: 947px'>
                                <div class="item">
                                    
                                        <div >
                                            <ul class=" clearfix">
                                                <%
                                                    System.Collections.Generic.List<EnWebProduct> _list = new System.Collections.Generic.List<EnWebProduct>();
                                             _list=ECProduct.GetWebProductList(1, 40, " and brandid in(" + shopInfo.BrandIdList + ") and brandid!=0 AND shopid=" + shopInfo.id + " ", "hits", "desc", out tmpPageCount);
                                             if (_list.Count == 0)
                                             {
                                                 _list = ECProduct.GetWebProductList(1, 40, " and brandid in(" + shopInfo.BrandIdList + ") and brandid!=0 and  (shopid=0 OR shopid IS NULL)  ", "hits", "desc", out tmpPageCount);  
                                             }
                                      foreach (EnWebProduct p in _list)
                                                  { %>
                                                <li style="padding:2px 2px 2px 2px;overflow:hidden;"><a title="<%=p.brandtitle + " " +p.materialname + " " + p.stylename+" "+p.categorytitle+" "+ p.sku %>"
                                                    href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                                    <center>
                                                    <img class="block" style='height:162px' alt="<%=p.brandtitle + " " +p.materialname + " " + p.stylename+" "+p.categorytitle+" "+ p.sku %>"
                                                        src="<%=EnFilePath.GetProductThumbPathNew(p.id.ToString(), p.thumb,"230","173") %>" />
                                                        </center>
                                                    <p class="p1">
                                                        <a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                                            <%=p.HtmlProductName %></a></p>
                                                    <p class="p2" style='display:none'>
                                                        实木框架 家具 FC02
                                                    </p>
                                                  <p class="p3">
                                                        <%if (p.ProductAttributeInfo.markprice != null && decimal.Parse(p.ProductAttributeInfo.markprice) > 0)
                                                              {%>
                                                    市场参考价:￥<%=p.ProductAttributeInfo.markprice %>
                                                     <%} %>
                                                        
                                                      
                                                      
                                                        
                                                    </p>
                                                     <%if (p.ProductAttributeInfo.saleprice != null && decimal.Parse(p.ProductAttributeInfo.saleprice) > 0)
                                                              {%>
                                                       <p style="color:#b80b0f;">销售价:￥<%=p.ProductAttributeInfo.saleprice%></p>
                                                        <%} %>
                                                           <span style="color:#b80b0f;">
                                                     
                                                        <%if (p.ProductAttributeInfo.buyprice != null && decimal.Parse(p.ProductAttributeInfo.buyprice) > 0)
                                                              {%>
                                                        <%=ECProduct.CheckbuypriceName(p.id.ToString()) %>:￥<%=p.ProductAttributeInfo.buyprice%>
                                                        <%} %></span>

                                                </a></li>
                                                <%} %>
                                            </ul>
                                        </div>
                                        <div class="ks-pager">
                                            <table align="center" style="margin: auto">
                                                <tr>
                                                    <td>
                                                     <%if (getdid == "0")
                                                             { %>
                                                        <a disabled="disabled" href="<%=string.Format(EnUrls.ShopInfoProduct,shopInfo.id) %>">
                                                          <img src="/resource/content/img/factory/comallprod.gif" /></a>
                                                            <%}
                                                              else
                                                             { %>
                                                             <a disabled="disabled" href="/shop/product.aspx?sid=<%=ECommon.QuerySId %>&did=<%=getdid %>">
                                                            <img src="/resource/content/img/factory/comallprod.gif" /></a>
                                                             <%} %>
                                                    </td>
                                                </tr>
                                            </table>
                                            <%--   

                            <a disabled="disabled">首页</a> <a disabled="disabled">上页</a> <span>1</span> <a href="#">
                                2</a> <a href="#">3</a> <a href="#">4</a> <a href="#">5</a> <a href="#">6</a>
                            <a href="#">7</a> <a href="#">下页</a> <a href="#">最后一页</a>--%>
                                        </div>
                                        <br />
                                    
                                </div>
                                <div class="item hide"  >
                                     <div >
                                            <ul class=" clearfix">
                                                <%
                                                    int pcount = 0;
                                            foreach (EnWebProduct p in ECProduct.GetWebProductList(1, 40, " and brandid in(" + shopInfo.BrandIdList + ") and brandid!=0", "hits", "desc", out tmpPageCount))
                                                  {

                                                      if (string.IsNullOrEmpty(p.attributexml))
                                                          p.attributexml = "-";
                                                      var type = new System.Text.RegularExpressions.Regex("<ProductAttributePromotion>([^<]+)</ProductAttributePromotion>").Match(p.attributexml, 1).Groups[1].Value;

                                                      if (!string.IsNullOrEmpty(type) && int.Parse(type) > 1)
                                                      {
                                                          pcount++; %>
                                                <li><a title="<%=p.brandtitle + " " +p.materialname + " " + p.stylename+" "+p.categorytitle+" "+ p.sku %>"
                                                    href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                                    <img class="block" style='width: 216px; height: 162px' alt="<%=p.brandtitle + " " +p.materialname + " " + p.stylename+" "+p.categorytitle+" "+ p.sku %>"
                                                        src="<%=EnFilePath.GetProductThumbPath(p.id.ToString(),p.thumb) %>" />
                                                    <p class="p1">
                                                        <a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                                            <%=p.HtmlProductName %></a></p>
                                                    <p class="p3">
                                                        <%if (p.ProductAttributeInfo.markprice != null && decimal.Parse(p.ProductAttributeInfo.markprice) > 0)
                                                              {%>
                                                    市场参考价:￥<%=p.ProductAttributeInfo.markprice %>
                                                     <%} %>
                                                         <%if (p.ProductAttributeInfo.saleprice != null && decimal.Parse(p.ProductAttributeInfo.saleprice) > 0)
                                                              {%>
                                                       <span style="color:#b80b0f;">销售价:￥<%=p.ProductAttributeInfo.saleprice%></span>
                                                        <%} %>
                                                      
                                                         <span style="color:#b80b0f;">
                                                     
                                                        <%if (p.ProductAttributeInfo.buyprice != null && decimal.Parse(p.ProductAttributeInfo.buyprice) > 0)
                                                              {%>
                                                        <%=ECProduct.CheckbuypriceName(p.id.ToString()) %>:￥<%=p.ProductAttributeInfo.buyprice%>
                                                        <%} %></span>
                                                        
                                                    </p>
                                                </a></li>
                                                <%}} 
                                                 %>
                                            </ul>
                                        </div>
                                       
                                        <div class="ks-pager">
                                            <table align="center" style="margin: auto">
                                                <tr>
                                                    <td>
                                                     <% if (pcount == 0)
                                                        { %>

                                                        <label>暂无参加活动的产品<br /><br /></label>

                                                        <%} %>
                                                        <a disabled="disabled" href="<%=string.Format(EnUrls.ShopInfoProduct,shopInfo.id) %>">
                                                            查看所有产品</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%}
                  else
                  { %>
                <div class="productShop productPa1" style="text-align: center;">
                    该店铺或者店铺下的品牌已经被下线<br />
                    您可以查询其他店铺的产品&nbsp; <a href="<%=TREC.ECommerce.ECommon.WebUrl%>product/list.aspx">去查找</a>&nbsp;
                    &nbsp; <a href="<%=TREC.ECommerce.ECommon.WebUrl%>">去首页</a>
                </div>
                <%} %>
            </div>
            <div class="cont-r fr">
                <uc5:_shopproduct ID="_shopproduct1" runat="server" />
                <div style="float:left;height:auto;">
                <uc7:_shopteladdress ID="_shopteladdress1" runat="server" />
                </div>
                <!--
                <div class="cont-r-t tc f14 b">共有产品（74）</div>
                <div class="bd">
                    <div class="selects f14">
                        <select>
                            <option value="">——所有品牌——</option>
                        </select>
                        <select>
                            <option value="">——所有系列——</option>
                        </select>
                        <select>
                            <option value="">——所有分类——</option>
                        </select>
                    </div>
                    <div class="classify">
                        <span>所有类型</span>
                        <a href="#">床头柜(2)</a>
                        <a href="#">衣柜(4)</a>
                        <a href="#">斗柜(2)</a>
                        <a href="#">梳妆台/镜(4)</a>
                        <a href="#">梳妆凳(3)</a> <a href="#">床尾凳(2)</a>
                        <a href="#">穿衣镜(1)</a> <a href="#">沙发(12)</a>
                        <a href="#">茶几(6)</a> <a href="#">角几(1)</a>
                        <a href="#">电视柜(3)</a>
                        <a href="#">展示柜(2)</a>
                        <a href="#">酒柜(3)</a>
                        <a href="#">休闲椅(4)</a>
                        <a href="#">贵妃椅(1)</a>
                        <a href="#">玄关/镜(1)</a>
                        <a href="#">鞋柜(1)</a>
                        <a href="#">花架(1)</a>
                        <a href="#">客厅其他(2)</a>
                        <a href="#">餐桌(2)</a>
                        <a href="#">餐椅(4)</a>
                        <a href="#">吧台(1)</a>
                        <a href="#">吧椅(1)</a> <a href="#">书桌(2)</a>
                        <a href="#">书柜(3)</a> <a href="#">办公椅(1)</a>
                        <a href="#">床(5)</a>
                    </div>
                    <div class="search">
                        <input class="i1 vm" type="text" value="" /><input type="button" class="i2 vm" name="name" value="搜索" />
                    </div>
                </div>
                <div class="fd-t f14">联系方式</div>
                <div class="fd">
                    <p>电话： 15221152335</p>
                    <p>在线客服：  <a title="点击这里给我发消息" href="http://wpa.qq.com/msgrd?v=3&amp;uin=123456789&amp;site=www.cactussoft.cn&amp;menu=yes" target="_blank">
                    <img src="http://wpa.qq.com/pa?p=2:123456789:41"></a></p>
                    <p>所在卖场：欧亚美浦东家具广场</p>
                    <p>店铺名称：法朗仕欧亚美浦东店</p>
                    <p>经销品牌：法朗仕</p>
                    店铺地址：上海市浦东新区浦三路1515号（三林世博家园） </p>                </div>

               -->
            </div>
        </div>
    </div>
    <ucfooter:footer ID="header3" runat="server" />
    </form>
    <script language="javascript" type="text/javascript">

        function DrawImage(ImgD, FitWidth, FitHeight) {
            var image = new Image();
            image.src = ImgD.src;
            if (image.width > 0 && image.height > 0) {
                if (image.width / image.height >= FitWidth / FitHeight) {
                    if (image.width > FitWidth) {
                        ImgD.width = FitWidth;
                        ImgD.height = (image.height * FitWidth) / image.width;
                    }
                    else {
                        ImgD.width = image.width;
                        ImgD.height = image.height;
                    }
                }
                else {
                    if (image.height > FitHeight) {
                        ImgD.height = FitHeight;
                        ImgD.width = (image.width * FitHeight) / image.height;
                    }
                    else {
                        ImgD.width = image.width;
                        ImgD.height = image.height;
                    }
                }
            }
        } 
 </script>
</body>
</html>
