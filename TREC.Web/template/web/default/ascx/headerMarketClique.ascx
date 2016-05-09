<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="headermarketClique.ascx.cs"
    Inherits="TREC.Web.aspx.ascx.headermarketClique" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebResourceUrl.TrimEnd('/') %>/script/oms_autocomplate.js"></script>
<script type="text/javascript">
    $(function () {
        var url = document.URL.toLowerCase();
        $('#kslkcon>.inner,#ksbrandcon>inner').html('正在加载数据中...');
        GetMarket('A,B,C,D', null); //初始化卖场
        GetBrand('A,B,C', null); //初始化品牌
        GetBrand2('A', null)
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
    function GetBrand2(myletter, obj) {

        var myclass = '';
        if (obj != null) {
            myclass = $(obj).attr('class');
            if (myclass == undefined) {
                myclass = '';
            }
        }
        if (myclass == '') {
            if (obj != null) {
                $('#j_menuTab .on').removeClass('on');
                $(obj).addClass('on');
            }
            $.ajax({
                url: '/ajax/ajaxproduct.ashx',
                data: 'type=getbrandbyletter&v=' + myletter.toString(),
                dataType: 'text',
                success: function (data) {
                    if (data != null) {
                        if (data == '') {
                            $('#ppshop').html('抱歉，暂无品牌！');
                        } else {
                            $('#ppshop').html("<div class='item' style='font-size:12px;'><div class='inner' title='A'>" + data.toString() + "</div></div>");
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
        <ul class="fr clearfix right">
            <li>欢迎您来到家具快搜 &nbsp;|&nbsp;</li>
            <%if (TRECommon.CookiesHelper.GetCookieCustomer("cid") != "")
              { %>
            <li><strong style="color: #0000FF;">[<%=TRECommon.CookiesHelper.GetCookieCustomer("cname")%>]</strong></li>
            <li></li>
            <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/logoutuser.aspx">[退出]</a>
            <%}
              else if (TRECommon.CookiesHelper.GetCookie("mid") != "" && TRECommon.CookiesHelper.GetCookie("mname") != "")
              { %>
            <li><a href="<%=TREC.ECommerce.ECommon.WebSupplerUrl.TrimEnd('/') %>/suppler/index.aspx">
                <strong>[<%=TRECommon.CookiesHelper.GetCookie("mname") != "" && TRECommon.CookiesHelper.GetCookie("mname").Length > 7 ? TRECommon.CookiesHelper.GetCookie("mname").Substring(0, 7) + ".." : TRECommon.CookiesHelper.GetCookie("mname")%>]</strong>
            </a></li>
            <li></li>
            <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/loginout.aspx">[退出]</a></li>
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
        <div class="fl search group">
            <%if (!string.IsNullOrEmpty(_marketcliquemodel.LogImg))
              { %><img class="vm"
                src="<%=EnFilePath.GetMarketLogoPath(MarketPageBase.marketInfo.id.ToString(),_marketcliquemodel.LogImg) %>"
                width="105" height="38" /><%} %>
            <%=_marketcliquetitle%>
        </div>
        <div class="right fr">
            <a href="http://www.jiajuks.com/product/17781/info.aspx">
                <img src="../../../resource/content/img/common/j1.png" alt="" /></a>
        </div>
    </div>
</div>
<!--头部文件结束-->
<!--菜单开始-->
<div class="nav">
    <div class="nav-box w clearfix">
        <%if (TRECommon.WebRequest.GetQueryString("pageName").ToLower() == "index.aspx")
          {%>
        <div class="main-nav fl" id="j_navTab">
            <a href="#" class="a0">全部分类</a>
            <ul class="pull-down hide">
                <li class="li1"><a href="/market/list.aspx" class="nav-item">家具卖场</a> <a href="#"
                    class="trim"></a>
                    <dl class="hide">
                        <dt id="marketmenu"><span class="on" onmouseover="GetMarket('A,B,C,D',this);">ABCD</span>
                            <span onmouseover="GetMarket('E,F,G,H',this);">EFGH</span> <span onmouseover="GetMarket('I,J,K,L',this);">
                                IJKL</span> <span onmouseover="GetMarket('M,N,O,P',this);">MNOS</span> <span onmouseover="GetMarket('Q,R,S,T,U',this);">
                                    TUVW</span> <span onmouseover="GetMarket('V,W,X,Y,Z',this);">XYZ</span>
                        </dt>
                        <dd>
                            <div class="items" id="kslkcon">
                                <div class="inner">
                                </div>
                                <div class="inner-img">
                                    <a href="http://www.jiajuks.com/market/14/index.aspx">
                                        <img style="width: 120px; height: 45px;" src="http://www.jiajuks.com/upload/market/logo/14/20130608175750105503.jpg" /></a>
                                    <a href="http://www.jiajuks.com/market/list.aspx">
                                        <img src="http://www.jiajuks.com/upload/market/logo/8/20130608144234216136.jpg" /></a>
                                    <a href="http://www.jiajuks.com/market/list.aspx">
                                        <img src="http://www.jiajuks.com/upload/market/logo/41/20130608174628497316.jpg" /></a>
                                    <a href="http://www.jiajuks.com/market/list.aspx">
                                        <img src="http://www.jiajuks.com/upload/market/logo/43/20130608145015418676.jpg" /></a>
                                    <a href="http://www.jiajuks.com/market/list.aspx">
                                        <img src="http://www.jiajuks.com/upload/market/logo/45/20130608145353002055.jpg" /></a>
                                    <a href="http://www.jiajuks.com/market/list.aspx">
                                        <img src="http://www.jiajuks.com/upload/market/logo/46/20130608150014577812.jpg" /></a>
                                    <a href="http://www.jiajuks.com/market/list.aspx">
                                        <img src="http://www.jiajuks.com/upload/market/logo/52/20130608150641921687.jpg" /></a>
                                    <a href="http://www.jiajuks.com/market/list.aspx">
                                        <img src="http://www.jiajuks.com/upload/market/logo/56/20130608174958084551.jpg" /></a>
                                </div>
                            </div>
                        </dd>
                    </dl>
                </li>
                <li class="li2"><a href="/company-brand/list.aspx" class="nav-item">家具品牌</a> <a href="#"
                    class="trim"></a>
                    <dl class="hide">
                        <dt id="brandmenu"><span class="on" onmouseover="GetBrand('A,B,C',this);">ABC</span>
                            <span onmouseover="GetBrand('D,E,F,G',this);">DEFG</span> <span onmouseover="GetBrand('H,I,J,K',this);">
                                HIJK</span> <span onmouseover="GetBrand('L,M,N,O',this);">LMNO</span> <span onmouseover="GetBrand('P,Q,R,S,T',this);">
                                    PQRST</span> <span onmouseover="GetBrand('U,V,W,X,Y,Z',this);">UVWXYZ</span>
                        </dt>
                        <dd>
                            <div class="items" id="ksbrandcon">
                                <div class="inner">
                                </div>
                                <div class="inner-img">
                                    <a href="http://www.jiajuks.com/company/136/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/340/20130607172438841210.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/84/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/26/20130607163039796565.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/84/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/27/20130607163926744345.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/84/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/28/20130607163837507808.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/285/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/479/20130607170959064141.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/84/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/454/20130607162434373504.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/197/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/401/20130607170000134017.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/202/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/318/20130607164839988311.jpg" /></a>
                                </div>
                            </div>
                        </dd>
                    </dl>
                </li>
                <li class="li3"><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productlist.aspx?did=7"
                    class="nav-item">卧室系列</a> <a href="#" class="trim"></a>
                    <dl class="hide">
                        <dd>
                            <div class="item">
                                <div class="inner">
                                    <table border='0'>
                                        <tr>
                                            <td style="width: 50px" align='right'>
                                                <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productlist2.aspx?did=7&ty=%u5367%u5BA4%u5957%u7EC4%u5408%20"
                                                    style='color: #9f1121'>卧室套组合</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td style="width: 50px" align='right'>
                                                <a href="/productlist.aspx?xid=8&did=7" style='color: #9f1121'>床</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                <a title="四尺床(宽1.2m)" href="/productlist.aspx?xid=8&did=7&tid=57">四尺床(宽1.2m)</a>
                                                <a title="五尺床(宽1.5m)" href="/productlist.aspx?xid=8&did=7&tid=58">五尺床(宽1.5m)</a>
                                                <a title="六尺床(宽1.8m)" href="/productlist.aspx?xid=8&did=7&tid=106">六尺床(宽1.8m)</a>
                                                <a title="加大床" href="/productlist.aspx?xid=8&did=7&tid=59">加大床</a> <a title="上下床"
                                                    href="/productlist.aspx?xid=8&did=7&tid=61">上下床</a> <a title="折叠床" href="/productlist.aspx?xid=8&did=7&tid=60">
                                                        折叠床</a>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td style="width: 50px" align='right'>
                                                <a href="/productlist.aspx?xid=14&did=7" style='color: #9f1121'>衣柜</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                <a title="单门衣柜" href="/productlist.aspx?xid=14&did=7&tid=91">单门衣柜</a> <a title="二门衣柜"
                                                    href="/productlist.aspx?xid=14&did=7&tid=77">二门衣柜</a> <a title="三门衣柜" href="/productlist.aspx?xid=14&did=7&tid=76">
                                                        三门衣柜</a> <a title="四门衣柜" href="/productlist.aspx?xid=14&did=7&tid=75">四门衣柜</a>
                                                <a title="五门衣柜" href="/productlist.aspx?xid=14&did=7&tid=92">五门衣柜</a> <a title="六门衣柜"
                                                    href="/productlist.aspx?xid=14&did=7&tid=74">六门衣柜</a> <a title="组合衣柜" href="/productlist.aspx?xid=14&did=7&tid=127">
                                                        组合衣柜</a>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td style="width: 50px;" align='right'>
                                                <a href="/productlist.aspx?xid=15&did=7" style='color: #9f1121'>斗柜</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                <a title="二斗柜" href="/productlist.aspx?xid=15&did=7&tid=120">二斗柜</a> <a title="三斗柜"
                                                    href="/productlist.aspx?xid=15&did=7&tid=85">三斗柜</a> <a title="四斗柜" href="/productlist.aspx?xid=15&did=7&tid=86">
                                                        四斗柜</a> <a title="五斗柜" href="/productlist.aspx?xid=15&did=7&tid=87">五斗柜</a>
                                                <a title="六斗柜" href="/productlist.aspx?xid=15&did=7&tid=88">六斗柜</a> <a title="七斗柜"
                                                    href="/productlist.aspx?xid=15&did=7&tid=89">七斗柜</a>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td style="width: 50px" align='right'>
                                                <a href="/productlist.aspx?xid=16&did=7" style='color: #9f1121'>梳妆</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                <a title="梳妆台/镜" href="/productlist.aspx?xid=16&did=7&tid=129">梳妆台/镜</a> <a title="梳妆镜"
                                                    href="/productlist.aspx?xid=16&did=7&tid=125">梳妆镜</a> <a title="梳妆台" href="/productlist.aspx?xid=16&did=7&tid=124">
                                                        梳妆台</a>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td style="width: 50px" align='right'>
                                                <a href="/productlist.aspx?xid=21&did=7" style='color: #9f1121'>床垫</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                <a title="很软" href="/productlist.aspx?xid=21&did=7&tid=113">很软</a> <a title="中软"
                                                    href="/productlist.aspx?xid=21&did=7&tid=112">中软</a> <a title="柔软" href="/productlist.aspx?xid=21&did=7&tid=111">
                                                        柔软</a> <a title="中硬" href="/productlist.aspx?xid=21&did=7&tid=110">中硬</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="inner-img">
                                    <a href="http://www.jiajuks.com/company/210/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/414/20130608105907455896.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/136/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/340/20130607172438841210.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/121/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/61/20130608140415624904.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/198/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/322/20130607160115855265.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/162/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/365/20130608142529164872.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/275/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/470/20130608140035934460.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/84/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/26/20130607163039796565.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/196/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/400/20130607173842112509.jpg" /></a>
                                </div>
                            </div>
                        </dd>
                    </dl>
                </li>
                <li class="li4"><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productlist.aspx?did=10"
                    class="nav-item">餐厅系列</a><a href="#" class="trim"></a><dl class="hide">
                        <dd>
                            <div class="item">
                                <div class="inner">
                                    <table border='0'>
                                        <tr>
                                            <td style="width: 50px" align='right'>
                                                <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productlist2.aspx?did=10&ty=%u9910%u5385%u5957%u7EC4%u5408%20"
                                                    style='color: #9f1121'>餐厅套组合</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table border='0'>
                                        <tr>
                                            <td style="width: 50px" align='right'>
                                                <a href="/productlist.aspx?xid=40&did=10" style='color: #9f1121'>餐桌</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                <a title="椭圆餐桌" href="/productlist.aspx?xid=40&did=10&tid=102">椭圆餐桌</a> <a title="方餐桌"
                                                    href="/productlist.aspx?xid=40&did=10&tid=104">方餐桌</a> <a title="圆餐桌" href="/productlist.aspx?xid=40&did=10&tid=100">
                                                        圆餐桌</a> <a title="长餐桌" href="/productlist.aspx?xid=40&did=10&tid=99">长餐桌</a>
                                            </td>
                                        </tr>
                                    </table>
                                    <table border='0'>
                                        <tr>
                                            <td style="width: 50px" align='right'>
                                                <a href="/productlist.aspx?xid=41&did=10" style='color: #9f1121'>餐椅</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                <a title="无扶手椅" href="/productlist.aspx?xid=41&did=10&tid=68">无扶手椅</a> <a title="扶手椅"
                                                    href="/productlist.aspx?xid=41&did=10&tid=67">扶手椅</a> <a title="餐椅" href="/productlist.aspx?xid=41&did=10&tid=27">
                                                        餐椅</a>
                                            </td>
                                        </tr>
                                    </table>
                                    <table border='0'>
                                        <tr>
                                            <td style="width: 50px" align='right'>
                                                <a href="/productlist.aspx?xid=42&did=10" style='color: #9f1121'>餐边柜</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                <a title="餐边柜" href="/productlist.aspx?xid=42&did=10&tid=123">餐边柜</a> <a title="餐边柜/镜"
                                                    href="/productlist.aspx?xid=42&did=10&tid=28">餐边柜/镜</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="inner-img">
                                    <a href="http://www.jiajuks.com/company/210/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/414/20130608105907455896.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/84/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/26/20130607163039796565.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/199/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/317/20130608133400293966.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/198/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/322/20130607160115855265.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/300/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/496/20130608115735281486.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/77/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/19/20130608115103371717.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/120/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/60/20130608113729786518.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/116/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/56/20130608110953431966.jpg" /></a>
                                </div>
                            </div>
                        </dd>
                    </dl>
                </li>
                <li class="li5"><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productlist.aspx?did=9"
                    class="nav-item">客厅系列</a><a href="#" class="trim"></a><dl class="hide">
                        <dd>
                            <div class="item">
                                <div class="inner">
                                    <table border='0'>
                                        <tr>
                                            <td style="width: 50px" align='right'>
                                                <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productlist2.aspx?did=9&ty=%u5BA2%u5385%u5957%u7EC4%u5408%20"
                                                    style='color: #9f1121'>客厅套组合</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td align='right' style='width: 50px'>
                                                <a href="/productlist.aspx?xid=25&did=9" style='color: #9f1121'>沙发</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                <a title="单人沙发" href="/productlist.aspx?xid=25&did=9&tid=69">单人沙发</a> <a title="二人沙发"
                                                    href="/productlist.aspx?xid=25&did=9&tid=70">二人沙发</a> <a title="三人沙发" href="/productlist.aspx?xid=25&did=9&tid=71">
                                                        三人沙发</a> <a title="四人沙发" href="/productlist.aspx?xid=25&did=9&tid=121">四人沙发</a>
                                                <a title="转角沙发" href="/productlist.aspx?xid=25&did=9&tid=114">转角沙发</a> <a title="功能沙发"
                                                    href="/productlist.aspx?xid=25&did=9&tid=73">功能沙发</a> <a title="组合沙发" href="/productlist.aspx?xid=25&did=9&tid=72">
                                                        组合沙发</a> <a title="沙发床" href="/productlist.aspx?xid=25&did=9&tid=62">沙发床</a>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td align='right' style='width: 50px'>
                                                <a href="/productlist.aspx?xid=26&did=9" style='color: #9f1121'>茶几</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                <a title="椭圆茶几" href="/productlist.aspx?xid=26&did=9&tid=105">椭圆茶几</a> <a title="长茶几"
                                                    href="/productlist.aspx?xid=26&did=9&tid=94">长茶几</a> <a title="圆茶几" href="/productlist.aspx?xid=26&did=9&tid=84">
                                                        圆茶几</a> <a title="方茶几" href="/productlist.aspx?xid=26&did=9&tid=83">方茶几</a>
                                                <a title="茶几" href="/productlist.aspx?xid=26&did=9&tid=16">茶几</a>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td align='right' style='width: 50px'>
                                                <a href="/productlist.aspx?xid=27&did=9" style='color: #9f1121'>角几</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                <a title="长角几" href="/productlist.aspx?xid=27&did=9&tid=97">长角几</a> <a title="圆角几"
                                                    href="/productlist.aspx?xid=27&did=9&tid=96">圆角几</a> <a title="方角几" href="/productlist.aspx?xid=27&did=9&tid=95">
                                                        方角几</a> <a title="角几" href="/productlist.aspx?xid=27&did=9&tid=17">角几</a>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td align='right' style='width: 50px'>
                                                <a href="/productlist.aspx?xid=30&did=9" style='color: #9f1121'>酒柜</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                <a title="单门酒柜" href="/productlist.aspx?xid=30&did=9&tid=115">单门酒柜</a> <a title="二门酒柜"
                                                    href="/productlist.aspx?xid=30&did=9&tid=116">二门酒柜</a> <a title="三门酒柜" href="/productlist.aspx?xid=30&did=9&tid=117">
                                                        三门酒柜</a> <a title="四门酒柜" href="/productlist.aspx?xid=30&did=9&tid=118">四门酒柜</a>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td align='right' style='width: 50px'>
                                                <a href="/productlist.aspx?xid=34&did=9" style='color: #9f1121'>玄关</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体 sans-serif;">
                                                <a title="玄关" href="/productlist.aspx?xid=34&did=9&tid=126" style="font-size: 12px;
                                                    font-family: 宋体 sans-serif;">玄关</a> <a title="玄关/镜" href="/productlist.aspx?xid=34&did=9&tid=22"
                                                        style="font-size: 12px; font-family: 宋体 sans-serif;">玄关/镜</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="inner-img">
                                    <a href="http://www.jiajuks.com/company/196/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/400/20130607173842112509.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/84/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/26/20130607163039796565.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/85/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/29/20130607174721238574.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/195/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/398/20130608094403236623.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/198/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/322/20130607160115855265.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/102/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/45/20130607175726151527.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/173/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/376/20130608134905541115.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/231/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/436/20130608134241482229.jpg" /></a>
                                </div>
                            </div>
                        </dd>
                    </dl>
                </li>
                <li class="li6"><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productlist.aspx?did=11"
                    class="nav-item">书房系列</a><a href="#" class="trim"></a><dl class="hide">
                        <dd>
                            <div class="item">
                                <div class="inner">
                                    <table border='0'>
                                        <tr>
                                            <td style="width: 50px" align='right'>
                                                <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productlist2.aspx?did=11&ty=%u4E66%u623F%u5957%u7EC4%u5408%20"
                                                    style='color: #9f1121'>书房套组合</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td align='right' style='width: 50px'>
                                                <a href="/productlist.aspx?xid=50&did=11" style='color: #9f1121'>书柜</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                <a title="单门书柜" href="/productlist.aspx?xid=50&did=11&tid=98">单门书柜</a> <a title="二门书柜"
                                                    href="/productlist.aspx?xid=50&did=11&tid=81">二门书柜</a> <a title="三门书柜" href="/productlist.aspx?xid=50&did=11&tid=80">
                                                        三门书柜</a> <a title="四门书柜" href="/productlist.aspx?xid=50&did=11&tid=79">四门书柜</a>
                                                <a title="五门书柜" href="/productlist.aspx?xid=50&did=11&tid=93">五门书柜</a> <a title="六门书柜"
                                                    href="/productlist.aspx?xid=50&did=11&tid=78">六门书柜</a> <a title="组合书柜" href="/productlist.aspx?xid=50&did=11&tid=82">
                                                        组合书柜</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="inner-img">
                                    <a href="http://www.jiajuks.com/company/195/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/398/20130608094403236623.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/84/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/26/20130607163039796565.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/210/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/414/20130608105907455896.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/198/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/322/20130607160115855265.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/169/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/372/20130608103014994939.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/271/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/466/20130608102345565733.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/204/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/405/20130608101326443832.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/228/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/433/20130608095204333815.jpg" /></a>
                                </div>
                            </div>
                        </dd>
                    </dl>
                </li>
                <li class="li7"><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productlist.aspx?did=12"
                    class="nav-item">儿童系列</a><a href="#" class="trim"></a><dl class="hide">
                        <dd>
                            <div class="item">
                                <div class="inner">
                                    <table border='0'>
                                        <tr>
                                            <td style="width: 50px" align='right'>
                                                <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/productlist2.aspx?did=12&ty=%u513F%u7AE5%u5957%u7EC4%u5408%20"
                                                    style='color: #9f1121'>儿童套组合</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td align='right' style='width: 50px'>
                                                <a href="/productlist.aspx?xid=55&did=12" style='color: #9f1121'>儿童床</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                <a title="上下床" href="/productlist.aspx?xid=55&did=12&tid=61">上下床</a> <a title="四尺床(宽1.2m)"
                                                    href="/productlist.aspx?xid=55&did=12&tid=57">四尺床(宽1.2m)</a> <a title="儿童床" href="/productlist.aspx?xid=55&did=12&tid=39">
                                                        儿童床</a> <a title="婴儿床" href="/productlist.aspx?xid=55&did=12&tid=5">婴儿床</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align='right' style='width: 50px'>
                                                <a href="/productlist.aspx?xid=58&did=12" style='color: #9f1121'>儿童衣柜</a>
                                            </td>
                                            <td style="font-size: 12px; font-family: 宋体;">
                                                <a title="二门衣柜" href="/productlist.aspx?xid=58&did=12&tid=77">二门衣柜</a> <a title="三门衣柜"
                                                    href="/productlist.aspx?xid=58&did=12&tid=76">三门衣柜</a> <a title="儿童衣柜" href="/productlist.aspx?xid=58&did=12&tid=42">
                                                        儿童衣柜</a> <a title="衣柜" href="/productlist.aspx?xid=58&did=12&tid=6">衣柜</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="inner-img">
                                    <a href="http://www.jiajuks.com/company/196/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/400/20130607173842112509.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/159/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/363/20130608092356693629.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/162/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/365/20130608142529164872.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/80/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/21/20130608142313421317.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/162/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/366/20130608142637606838.jpg" /></a>
                                    <a href="http://www.jiajuks.com/company/197/index.aspx">
                                        <img src="http://www.jiajuks.com/upload/brand/logo/401/20130607170000134017.jpg" /></a>
                                </div>
                            </div>
                        </dd>
                    </dl>
                </li>
            </ul>
        </div>
        <% }%>
        <ul class="nav-title fl" id="j_menuTab">
            <li class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "marketclique.aspx", "", "on")%>">
                <a class="nav-item" href="/market/marketclique.aspx?id=<%=_marketid %>">
                    首 页</a></li>
            <li class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "marketcliqueabout.aspx", "", "on")%>">
                <a class="nav-item" href="/market/marketcliqueabout.aspx?id=<%=_marketid %>">集团介绍</a></li>
            <li class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "marketcliquesubmarket.aspx", "", "on")%>">
                <a class="nav-item" href="/market/marketcliquesubmarket.aspx?id=<%=_marketid %>">
                    商场</a></li>
            <li class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "marketcliquepromotions.aspx", "", "on") %>">
                <a class="nav-item" href="/market/marketcliquepromotions.aspx?id=<%=_marketid %>">
                    促销活动</a></li>
            <li class="<%=TREC.ECommerce.UiCommon.QueryStringCur("pageName", "marketcliquebusiness.aspx", "", "on")%>">
                <a class="nav-item" href="/market/marketcliquebusiness.aspx?id=<%=_marketid %>">
                    招商信息</a></li>
        </ul>
    </div>
</div>
<!--菜单结束-->
