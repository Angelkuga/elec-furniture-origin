<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="TREC.Web.aspx.ascx.header" %>
<link href="../../../../resource/content/css/core.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/oms_autocomplate.js"></script>
<script type="text/javascript">
    $(function () {
        var url = document.URL.toLowerCase();
        $("#searchKey").oms_autocomplate({ url: "/ajax/search.ashx", inputWidth: 339, inputHeight: 32, paramTypeSelector: "#searchTypeList>a.Searcha" });
        $('#kslkcon>.inner,#ksbrandcon>inner').html('正在加载数据中...');
        GetMarket('A,B,C,D', null); //初始化卖场
        GetBrand('A,B,C', null); //初始化品牌 
        //搜索条 绑定类型为产品搜索
        $("#topSearchBtn").click(function () {
            //window.top.location = "<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>" + "/search.aspx?type=product&key=" + encodeURIComponent($("#searchKey").val().replace(/\-/g, "abc111"));


            window.location.href = "<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productlist.aspx?k=" + escape($("#searchKey").val());

        });
    });
    //ajax获取卖场菜单数据
    function GetMarket(myletter, obj) {
        var myclass = '';
        if (obj != null) {
            myclass = $(obj).attr('class');
            if (myclass == undefined) {
                myclass = '';
            }
        }
        if (myclass == '') {
            if (obj != null) {
                $('#marketmenu .on').removeClass('on');
                $(obj).addClass('on');
            }
            $.ajax({
                url: '/ajax/ajaxproduct.ashx',
                data: 'type=getmarketbyletter&v=' + myletter.toString(),
                dataType: 'text',
                success: function (data) {
                    if (data != null) {
                        if (data == '') {
                            $('#kslkcon>.inner').html('抱歉，暂无卖场！');
                        } else {
                            $('#kslkcon>.inner').html(data.toString());
                        }
                    }
                }
            });
        }
    }
    //ajax获取品牌菜单数据
    function GetBrand(myletter, obj) {

        var myclass = '';
        if (obj != null) {
            myclass = $(obj).attr('class');
            if (myclass == undefined) {
                myclass = '';
            }
        }
        if (myclass == '') {
            if (obj != null) {
                $('#brandmenu .on').removeClass('on');
                $(obj).addClass('on');
            }
    
            $.ajax({
                url: '/ajax/ajaxproduct.ashx',
                data: 'type=getbrandbyletter&v=' + myletter.toString(),
                dataType: 'text',
                success: function (data) {
                    if (data != null) {
                        if (data == '') {
                            $('#ksbrandcon>.inner').html('抱歉，暂无品牌！');
                        } else {
                            $('#ksbrandcon>.inner').html(data.toString());
                        }
                    }
                }
            });
            
        }
    }

    function addToFavorite() {
        var a = "http://www.jiajuks.com",
b = "家具快搜jiajuks.com-购买家具";
        document.all ? window.external.AddFavorite(a, b) : window.sidebar && window.sidebar.addPanel ? window.sidebar.addPanel(b, a, "") : alert("\u5bf9\u4e0d\u8d77\uff0c\u60a8\u7684\u6d4f\u89c8\u5668\u4e0d\u652f\u6301\u6b64\u64cd\u4f5c!\n\u8bf7\u60a8\u4f7f\u7528\u83dc\u5355\u680f\u6216Ctrl+D\u6536\u85cf\u672c\u7ad9\u3002");
    }

</script>
<!--头部文件开始-->
<style>
    .nav-box .pull-down li dd .inner-img img
    {
        float: left;
        width: 110px;
        height: 36px;
        margin: 3px;
    }
</style>
<div class="header">
    <div class="hd w">
        <ul class="clearfix fl left">
            <li class="li1">给您最全的家具购买资讯</li>
          
            <li class="li4"><a href="##" onclick='addToFavorite();'>收藏</a></li>
            
            <li class="li7">

          <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=2285277787&site=qq&menu=yes"><img border="0" src="http://wpa.qq.com/pa?p=2:2285277787:41" alt="点击这里给我发消息" title="点击这里给我发消息" style="margin-top:3px;"/></a>
            </li>
        </ul>
        <ul class="fr clearfix right" id="ullogin">
            <li>欢迎您来到家具快搜 &nbsp;|&nbsp;</li>
            <%if (TRECommon.CookiesHelper.GetCookieCustomer("cid") != "")
              { %>
            <li><strong style="color: #0000FF;"><a href="/Ucenter/Default.aspx">[<%=TRECommon.CookiesHelper.GetCookieCustomer("cname")%>]</a></strong></li>
            <li></li>
              <a href="/shoppingTrolley.aspx">我的购物车[<%=TREC.ECommerce.EcShoppingPay.shoppingCount(TRECommon.CookiesHelper.GetCookieCustomer("cid"))%>]</a>  &nbsp; &nbsp;
            <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/logoutuser.aspx">[退出]</a>
            <%}
              else if (TRECommon.CookiesHelper.GetCookie("mid") != "" && TRECommon.CookiesHelper.GetCookie("mname") != "")
              { %>
            <li><a href="<%=TREC.ECommerce.ECommon.WebSupplerUrl.TrimEnd('/') %>/suppler/index.aspx">
                <strong>[<%=TRECommon.CookiesHelper.GetCookie("mname") != "" && TRECommon.CookiesHelper.GetCookie("mname").Length > 7 ? TRECommon.CookiesHelper.GetCookie("mname").Substring(0, 7) + ".." : TRECommon.CookiesHelper.GetCookie("mname")%>]</strong>
            </a></li>
            <li>
         <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/loginout.aspx">[退出]</a></li>
          <li><img src="/resource/images/400.gif" style="margin-top:6px;padding-left:8px;" /> </li>
            <%}
              else
              { %>
            <li><a href="/loginuser.aspx">登录</a> &nbsp;|&nbsp; </li>
            <li><a href="/reguser.aspx">注册</a> </li>
             <li><img src="/resource/images/400.gif" style="margin-top:6px;padding-left:8px;" /> </li>
            <li><a href="/reg.aspx" style="margin-left:10px;">商家入驻</a> </li>
            <%} %>
           
        </ul>
    </div>
</div>
<div class="header-box">
    <div class="w clearfix">
        <div class="logo fl" style='position: relative;'>
            <a href='/' style="position: absolute; top: 5px; left: 5px; width: 140px; height: 45px;
                z-index: 2px;"></a>
            <div class="citys">
                <a class="a0" href="#">上海</a>
                <ul class="clearfix">
                    <li><a href='##'>全国</a></li>
                    <li>上海</li>
                    <li>广州</li>
                    <li>深圳</li>
                </ul>
            </div>
        </div>
        <div class="fl search">
            <div class="logo-s-t" id="searchTypeList" style="display: none;">
                <a id="T_product" title="product" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("searchtype", "product", "", "Searcha")%><%=TREC.ECommerce.UiCommon.QueryStringCur("searchtype", "", "", "Searcha")%>">
                    搜产品</a> <a id="T_brand" title="brand" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("searchtype", "brand", "", "Searcha")%>">
                        搜品牌</a> <a id="T_market" title="market" class="<%=TREC.ECommerce.UiCommon.QueryStringCur("searchtype", "market", "", "Searcha")%>">
                            搜卖场</a>
            </div>
            <input type="text" class="text" name="searchKey" id="searchKey" placeholder="明星家具盛惠，1元拍爆款家具，抢码最高省4500！" /><input
                class="button" type="button" name="topSearchBtn" id="topSearchBtn" value="搜索" />
            <div class="hot" style="border: 0px solid #cacaca;">

            <a class="a-on" target="_blank"  href="/Dealer/index.aspx?did=84">楷模</a>  <a target="_blank" href="/company/210/index.aspx">北欧E家</a> 
            <a href="/51/default.aspx" target="_blank"> 品牌团购</a> <a target="_blank" href="/productlisttbb.aspx">名品折扣</a> 
             <a target="_blank" href="/productlist.aspx?did=7">家具精选</a>  <a target="_blank" href="/productlisttbb.aspx?xid=50&did=11">特价书柜</a>
               
               </div>
        </div>
        <div class="right fr">
         <%--   <a href="http://www.jiajuks.com/product/17781/info.aspx">
                <img src="../../../resource/content/img/common/j1.png" alt="" /></a>--%>
                <img src="/resource/images/eweima.jpg" />
        </div>
    </div>
</div>
<!--头部文件结束-->
<!--菜单开始-->
<div class="nav">
    <div class="nav-box w clearfix">
        <div class="main-nav fl" id="j_navTab">
            <a href="#" class="a0">全部分类</a>
            <ul class="pull-down hide">
                <li class="li1"><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/market/list.aspx"
                    class="nav-item">家具卖场</a> <a href="#" class="trim"></a>
                    <dl class="hide">
                        <dt id="marketmenu"><span class="on" onmouseover="GetMarket('A,B,C,D',this);">ABCD</span>
                            <span onmouseover="GetMarket('E,F,G,H',this);">EFGH</span> <span onmouseover="GetMarket('I,J,K,L',this);">
                                IJKL</span> <span onmouseover="GetMarket('M,N,O,P',this);">MNOS</span> <span onmouseover="GetMarket('Q,R,S,T,U',this);">
                                    TUVW</span> <span onmouseover="GetMarket('V,W,X,Y,Z',this);">XYZ</span>
                        </dt>
                        <dd>
                            <div class="items" id="kslkcon">
                                <div class="inner" style='min-height: 110px;'>
                                </div>
                                <div class="inner-img">
                                   <a href="/market/14/index.aspx">
                                        <img style="width: 120px; height: 45px;" src="/upload/market/logo/14/20130608175750105503.jpg" /></a>
                                    <a href="/market/list.aspx">
                                        <img src="/upload/market/logo/8/20130608144234216136.jpg" /></a>
                                    <a href="/market/list.aspx">
                                        <img src="/upload/market/logo/41/20130608174628497316.jpg" /></a>
                                    <a href="/market/list.aspx">
                                        <img src="/upload/market/logo/43/20130608145015418676.jpg" /></a>
                                    <a href="/market/list.aspx">
                                        <img src="/upload/market/logo/45/20130608145353002055.jpg" /></a>
                                    <a href="/market/list.aspx">
                                        <img src="/upload/market/logo/46/20130608150014577812.jpg" /></a>
                                    <a href="/market/list.aspx">
                                        <img src="/upload/market/logo/52/20130608150641921687.jpg" /></a>
                                    <a href="/market/list.aspx">
                                        <img src="/upload/market/logo/56/20130608174958084551.jpg" /></a>
                                </div>
                            </div>
                        </dd>
                    </dl>
                </li>
                <li class="li2"><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/companybrandlist.aspx"
                    class="nav-item">家具品牌</a> <a href="#" class="trim"></a>
                    <dl class="hide">
                        <dt id="brandmenu"><span class="on" onmouseover="GetBrand('A,B,C',this);">ABC</span>
                            <span onmouseover="GetBrand('D,E,F,G',this);">DEFG</span> <span onmouseover="GetBrand('H,I,J,K',this);">
                                HIJK</span> <span onmouseover="GetBrand('L,M,N,O',this);">LMNO</span> <span onmouseover="GetBrand('P,Q,R,S,T',this);">
                                    PQRST</span> <span onmouseover="GetBrand('U,V,W,X,Y,Z',this);">UVWXYZ</span>
                        </dt>
                        <dd>
                            <div class="items" id="ksbrandcon">
                                <div class="inner" style='min-height: 110px;'>
                                </div>
                                <div class="inner-img">
                                    <a href="/company/136/index.aspx">
                                        <img src="/upload/brand/logo/340/20130607172438841210.jpg" /></a>
                                    <a href="/company/84/index.aspx">
                                        <img src="/upload/brand/logo/26/20130607163039796565.jpg" /></a>
                                    <a href="/company/84/index.aspx">
                                        <img src="/upload/brand/logo/27/20130607163926744345.jpg" /></a>
                                    <a href="/company/84/index.aspx">
                                        <img src="/upload/brand/logo/28/20130607163837507808.jpg" /></a>
                                    <a href="/company/285/index.aspx">
                                        <img src="/upload/brand/logo/479/20130607170959064141.jpg" /></a>
                                    <a href="/company/84/index.aspx">
                                        <img src="/upload/brand/logo/454/20130607162434373504.jpg" /></a>
                                    <a href="/company/197/index.aspx">
                                        <img src="/upload/brand/logo/401/20130607170000134017.jpg" /></a>
                                    <a href="/company/202/index.aspx">
                                        <img src="/upload/brand/logo/318/20130607164839988311.jpg" /></a>
                                </div>
                            </div>
                        </dd>
                    </dl>
                </li>
                 <%=xilie %>
            </ul>
        </div>
        <ul class="nav-title fl" id="j_menuTab">
            <li id='linav_1'><a href="/" class="nav-item">首 页</a> </li>
            <li id='linav_2' class="nav-brand" ><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/companybrandlist.aspx?n=2"
                class="nav-item">品 牌</a>
                <dl>
                    <%=brand %>
                </dl>
            </li>
            <li  id='linav_3'>
            <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/marketlist.aspx" class="nav-item"
                style="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "list.aspx", "", "background:#ffd457;color: #ff6600;")%>">
                卖场</a> </li>
            <li  id='linav_4'><a href="#" class="nav-item">国际馆</a></li>
        </ul>
        <ul class="fr nav-title-right">
            <li  id='linav_5'><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productlisttbb.aspx">淘宝贝</a></li>
            <li  id='linav_6'><a href="/51/default.aspx" target="_blank">热门团购</a></li>
            <li  id='linav_7'><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/guide.aspx">活动导购</a></li>
            <li  id='linav_8'><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/news/list.aspx">行业资讯</a></li>
        </ul>
    </div>
</div>
<script>
    $("#linav_<%=nid %>").css("background-color", "#8F0633");
</script>
<!--菜单结束-->
