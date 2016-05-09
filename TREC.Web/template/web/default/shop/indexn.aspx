<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.shop.index" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
 

<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_shopnav.ascx" TagName="_shopnav" TagPrefix="uc3" %>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>
<%@ Register Src="../ascx/_shopproduct2.ascx" TagName="_shopproduct" TagPrefix="uc5" %>
<%@ Register Src="../ascx/_shopkeys.ascx" TagName="_shopkeys" TagPrefix="uc6" %>
<%@ Register Src="../ascx/_shopteladdress2.ascx" TagName="_shopteladdress" TagPrefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<%--   <uc6:_shopkeys ID="_shopkeys1" Title="-经销店铺-首页" runat="server" />
    <uc2:_resource ID="_resource1" runat="server" />--%>
    <link href="../../../../resource/content/css/_src/core.css" rel="stylesheet" type="text/css" />
    
    <link href="../../../../resource/content/css/factory.css" rel="stylesheet" type="text/css" />
    <script src="../../../../resource/content/js/core.js"></script>
    <script src="../../../../resource/content/libs/slides.min.jquery.js"></script>
    <script src="../../../../resource/content/js/_src/factory/factory.js" type="text/javascript"></script>
     

    <%-- <link href="content/css/_src/core.css" rel="stylesheet" />
    <link href="content/css/_src/factory/factory.css" rel="stylesheet" />
    <script src="content/js/core.js"></script>
    <script src="content/libs/slides.min.jquery.js"></script>
    <script src="content/js/_src/factory/factory.js"></script>--%>
   <%-- <script type="text/javascript" src="../../../../resource/content/libs/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="../../../../resource/script/soglobal.js?v2"></script>
    <script type="text/javascript" src="../../../../resource/script/socommon.js"></script>
    <script type="text/javascript" src="../../../../resource/script/myfocus-1.2.4.min.js"></script>
    <script type="text/javascript" src="../../../../resource/script/jquery.inputlabel.js"></script>
    <script type="text/javascript" src="../../../../resource/script/jquery.scrollLoading.js"></script>
    <script type="text/javascript" src="../../../../resource/script/oms_autocomplate.js"></script>
--%>
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
<%--  <uc1:_headA ID="_headA1" runat="server" />
    <uc3:_shopnav ID="_shopnav1" runat="server" /> --%>
    <div class="header">
        <div class="hd w">
            <ul class="clearfix fl left">
                <li class="li1">给您最全的家具购买资讯</li>
                <li class="li2"><span>
                    <%=_htb["bcount"]%></span>个品牌</li>
                <li class="li3"><span>
                    <%=_htb["pcount"]%></span>个商品</li>
                <li class="li4"><a href="##" onclick='addToFavorite();'>收藏</a></li>
                <li class="li5"><a href="#">关注</a></li>
                <li class="li6"><a href="#">站点导航</a></li>
                <li class="li7"><a href="#">手机家具快搜</a></li>
            </ul>
            <ul class="fr clearfix right">
                <li>欢迎您来到家具快搜 &nbsp;|&nbsp;</li>
                <%if (TRECommon.CookiesHelper.GetCookie("mid") != "" && TRECommon.CookiesHelper.GetCookie("mname") != "" && TRECommon.CookiesHelper.GetCookie("mpwd") != "")
                  { %>
                <li>您好：<a href="<%=TREC.ECommerce.ECommon.WebSupplerUrl.TrimEnd('/') %>/suppler/index.aspx"><strong>[<%=TRECommon.CookiesHelper.GetCookie("mname") != "" && TRECommon.CookiesHelper.GetCookie("mname").Length > 7 ? TRECommon.CookiesHelper.GetCookie("mname").Substring(0, 7) + ".." : TRECommon.CookiesHelper.GetCookie("mname")%>]</strong></a></li>
                <li></li>
                <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/loginout.aspx">[退出]</a></li>
                <%}
                  else
                  { %>
                <li><a href="/reg.aspx?r=l">登录</a> &nbsp;|&nbsp; </li>
                <li><a href="/reg.aspx">注册</a> </li>
                <%} %>
            </ul>
        </div>
    </div>
    <div class="header-box">
        <div class="w clearfix header-border">
            <div class="logo fl">
                <div class="citys">
                    <a class="a0" href="#">上海</a>
                    <ul class="clearfix">
                        <li>全国</li>
                        <li>上海</li>
                        <li>广州</li>
                        <li>深圳</li>
                    </ul>
                </div>
            </div>
            <div class="fl search">
                <input type="text" class="text" name="searchKey" id="searchKey" placeholder="明星家具盛惠，1元拍爆款家具，抢码最高省4500！" /><input
                    class="button" type="button" name="topSearchBtn" id="topSearchBtn" value="搜索" />
                <div class="hot">
                    <a class="a-on" href="#">48小时疯抢</a><a href="#">床</a><a href="#">灯饰</a><a href="#"></a><a
                        class="a-on" href="#">Simmons</a><a href="#">转角沙发</a><a href="#">特价记忆枕</a><a href="#">1.8米进口床垫</a></div>
            </div>
            <div class="fr f14 box-r b">
                <span><a href='../../reg.aspx'>供应商登录</a></span> <a href="../../reg.aspx">申请入驻 </a>
            </div>
        </div>
        <div class="w clearfix">
            <h4 class="yahei fl">
                 <%=ShopPageBase.shopInfo.title %></h4>
            

                  <%foreach (ShopBrand b in ShopPageBase.shopInfo.ShopBrandList)
              { %>
            <a class="fr" title="<%=ShopPageBase.shopInfo.BrandName.Replace(",", " ")%>" href="<%=string.Format(EnUrls.CompanyInfoBrandList,b.companyid,b.id)%>"
                target="_blank">
                <img alt="<%=ShopPageBase.shopInfo.BrandName.Replace(",", " ")%>" src="http://www.jiajuks.com/<%=EnFilePath.GetBrandLogoPath(b.id,b.thumb) %>"
                    width="105" height="38" /></a>
                     

            <%} %>

        </div>
    </div>
    <div class="nav seller-nav">
        <div class="nav-box w clearfix">
            <div class="main-nav fl" id="j_navTab">
            </div>
            <ul class="nav-title fl" id="j_menuTab">
                <li class="on"><a  href="<%=string.Format(EnUrls.ShopInfoIndex,ECommon.QuerySId) %>"  class="nav-item">首 页</a> </li>
                <li class="nav-brand"><a href="#" class="nav-item">厂商介绍</a> </li>
                <li><a href="#" class="nav-item">品牌介绍</a> </li>
                <li><a  href="<%=string.Format(EnUrls.ShopInfoProduct,ECommon.QuerySId) %>"  class="nav-item">全部产品</a></li> 
                <li><a href="#" class="nav-item">招商信息</a></li>
                <li><a href="<%=string.Format(EnUrls.ShopInfoPromotions, ECommon.QuerySId) %>" class="nav-item">促销信息</a></li>
                <li><a href="#" class="nav-item">公司新闻</a></li>
                 <li><a href="<%=string.Format(EnUrls.ShopInfoAddress,ECommon.QuerySId) %>" class="nav-item">店铺地址</a></li>

            </ul>
        </div>
    </div> 
    <!---->
    <div class="seller-cont clearfix">
        <div class="w">
            <div class="cont-l fl">
                <%if (ShopPageBase.IsCount)
                  { %>
                    <div class="brand">
                        <div class="common-hd clearfix">
                            <span class="hd-l fl b f14">旗下品脾</span> <a href="#" class="hd-r fr songti">查看详细介绍 >></a>
                        </div>
                        <table class="bd g10">
                            <tr>
                                <td width="170" class="tc bd-l">
                                    <a href="#" class="block"> <img style='width:64px;height:72px' alt="<%=brandcompanyInfo.BrandInfo.title %>" src="http://www.jiajuks.com<%=EnFilePath.GetBrandLogoPath(shopInfo.ShopBrandInfo.id, brandcompanyInfo.BrandInfo.logo) %>"
                                            width="196" height="70" /></a>
                                </td>
                                <td class="bd-c">
                                    <h6 class="f14 b">
                                        <a href="#"><a target="_blank" href="<%=string.Format(EnUrls.CompanyInfoIndex, shopInfo.ShopBrandInfo.companyid) %>">
                                            <strong>
                                                <%=ShopPageBase.shopInfo.BrandName.Replace(",", " ")%></strong></a></a></h6>
                                    <p>
                                        <b>风格：</b><%=ECConfig.GetConfigInfoNew(" type=3 and value in(" + StyleString+")")%>
                                        <%-- <b class="ml10">材质：</b>全实木--%>
                                    </p>
                                    <div class="text">
                                        <%=brandcompanyInfo != null && brandcompanyInfo.CompanyInfo != null && brandcompanyInfo.CompanyInfo.descript != null ? (TRECommon.HTMLUtils.GetAllTextFromHTML(brandcompanyInfo.CompanyInfo.descript).Length > 78 ? TRECommon.HTMLUtils.GetAllTextFromHTML(brandcompanyInfo.CompanyInfo.descript).Substring(0, 78) + "..." : TRECommon.HTMLUtils.GetAllTextFromHTML(brandcompanyInfo.CompanyInfo.descript)) : "" %></div>
                                </td>
                                <td width="240" class="tc">
                                    <a href="#" class="block">
                                        <img alt="<%=brandcompanyInfo.BrandInfo.title %>" src="http://www.jiajuks.com<%=EnFilePath.GetBrandLogoPath(shopInfo.ShopBrandInfo.id, brandcompanyInfo.BrandInfo.logo) %>"
                                            width="196" height="70" /></a>
                                </td>
                            </tr>
                        </table>
                    </div>
                <div id="j_facShop" class="fac-shop">
                    <div class="slides_container">
                        <%if (!string.IsNullOrEmpty(shopInfo.bannel))
                          { %>
                                <%foreach (string s in shopInfo.bannel.Split(','))
                                  { %>
                                    <%if (s != "")
                                        { %>
                                    <div class="item">
                                        <a href="#" class="block img fl">
                                            <img style="width:606px;height:304px" class="block" src="<%=EnFilePath.GetShopBannerPath(shopInfo.id.ToString(), s)%>"
                                                alt="" /></a>
                                        <div class="txt fl">
                                            <p class="p1">
                                                <a href="#" class="block f18 yahei lh3">全网人气之最 栅栏式简约</a></p>
                                            <p>
                                                促销价：<i class="a1">￥1799.00</i></p>
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
                                    </div>
                                    <%}%>
                                <%} %>
                        <%} %>
                        
                    </div>
                </div>
                <div class="recommend">
                    <div class="common-hd clearfix">
                        <span class="hd-l fl b f14">推荐产品</span> <a href="<%=string.Format(EnUrls.ShopInfoProduct,ECommon.QuerySId) %>"
                            class="hd-r fr">更多</a>
                    </div>
                    <div class="common-bd">
                        <div class="item">
                            <ul class=" clearfix">
                                <%foreach (EnWebProduct p in ECProduct.GetWebProductList(1, 12, " and brandid in(" + shopInfo.BrandIdList + ") and brandid!=0", "hits", "desc", out tmpPageCount))
                                  { %>
                                <li><a title="<%=p.brandtitle + " " +p.materialname + " " + p.stylename+" "+p.categorytitle+" "+ p.sku %>"
                                    href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                    <img class="block" style='width:216px;height:162px' alt="<%=p.brandtitle + " " +p.materialname + " " + p.stylename+" "+p.categorytitle+" "+ p.sku %>"
                                        src="http://www.jiajuks.com<%=EnFilePath.GetProductThumbPathNew(p.id.ToString(),p.thumb,"230","173") %>" />
                                    <p class="p1">
                                        <a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                            <%=p.HtmlProductName %></a></p>
                                    <p class="p2">
                                        实木框架 家具 FC02
                                    </p>
                                    <p class="p3">
                                        参考价:￥<%=p.ProductAttributeInfo.markprice%>
                                        <%if ((p.ProductShopInfoNew.price != "0.00" && p.ProductShopInfoNew.price != "0") || (p.ProductShopInfoNew.dollprice != "0" && p.ProductShopInfoNew.dollprice != "0.00"))
                                          { %>
                                            <%if (p.ProductShopInfoNew.dollprice != "0" && p.ProductShopInfoNew.dollprice != "0.00")
                                              { %>
                                            <span>促销价:￥<%=p.ProductShopInfoNew.dollprice.Split('.')[0]%>
                                            </span>
                                            <%}
                                              else
                                              { %>
                                            <span>促销价:￥<%=p.ProductShopInfoNew.price.Split('.')[0]%>
                                            </span>
                                            <%} %>
                                        <%} %>
                                    </p>
                                </a></li>
                                <%} %>
                            </ul>
                        </div>
                    
                        <div class="ks-pager">
                         <table align="center"  style="margin:auto" ><tr><td><a disabled="disabled" href="<%=string.Format(EnUrls.ShopInfoProduct,shopInfo.id) %>">查看所有产品</a></td></tr></table>
                             
<%--   

                            <a disabled="disabled">首页</a> <a disabled="disabled">上页</a> <span>1</span> <a href="#">
                                2</a> <a href="#">3</a> <a href="#">4</a> <a href="#">5</a> <a href="#">6</a>
                            <a href="#">7</a> <a href="#">下页</a> <a href="#">最后一页</a>--%>
                        </div>
                        <br />
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


                <uc7:_shopteladdress ID="_shopteladdress1" runat="server" />
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
    <div class="footer">
        <p class="p1">
            <a href="/Link.aspx">友情链接</a> | <a href="/tag.aspx">标签云</a> | <a href="/about/gsjs.html">
                企业介绍</a> | <a href="/about/lxwm.html">联系我们</a> | <a href="/about/zxns.html">招聘纳士</a>
            | <a href="/sitemap.html">网站地图</a> | <a target="_blank" href="/applysupplier.aspx">供应商加盟</a>
            | <a target="_blank" href="/passport/SupplierLogin.aspx">供应商登录</a>
        </p>
        <p class="p2">
            <a href="#">友情链接</a>|<a href="#">标签云</a>|<a href="/gywm.html">企业介绍</a>|<a href="/lxwm.html">联系我们</a></p>
        <p class="p3">
            Copyright &copy; <a href="http://www.jiajuks.com/">家具快搜</a>（www.jiajuks.com） &nbsp;沪ICP备12034118号</p>
        <p class="p4">
        </p>
        <p>
            <img src="http://www.jiajuks.com/resource/web/images/index_130.jpg">
            <a href="#">
                <img src="http://www.jiajuks.com/resource/web/images/index-08.jpg"></a> <a href="#">
                    <img src="http://www.jiajuks.com/resource/web/images/index-09.jpg"></a>
            <a href="#">
                <img src="http://www.jiajuks.com/resource/web/images/index-10.jpg"></a>
        </p>
        <p>
        </p>
    </div>   
    </form>
</body>
</html>
