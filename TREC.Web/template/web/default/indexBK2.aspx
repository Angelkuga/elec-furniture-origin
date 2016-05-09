<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.index" %>

<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="Haojibiz.Model" %>
<%@ Import Namespace="Haojibiz.Data" %>
<%@ Import Namespace="Haojibiz.DAL" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>家具快搜</title>
    <meta name="keywords" content="家具品牌,家具品牌排名,家具十大品牌,品牌家具,实木家具十大品牌,儿童家具十大品牌,板式家具十大品牌">
    <meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！">
    <link href="/resource/content/css/core.css" rel="stylesheet" />
    <link href="/resource/content/css/index.css" rel="stylesheet" />
    <script src="/resource/content/libs/jquery-1.11.0.min.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/index/index.js"></script>
</head>
<body>
    <div class="header">
        <div class="hd w">
            <ul class="clearfix fl left">
                <li class="li1">给您最全的家具购买资讯</li>
                <li class="li2"><span>1000</span>个品牌</li>
                <li class="li3"><span>57189</span>个商品</li>
                <li class="li4"><a href="javascript:window.external.AddFavorite('http://www.jiajuks.com/','家具快搜');">
                    收藏</a></li>
                <li class="li5"><a href="#">关注</a></li>
                <li class="li6"><a href="#">站点导航</a></li>
                <li class="li7"><a href="#">手机家具快搜</a></li>
            </ul>
            <ul class="fr clearfix right">
                <li>欢迎您来到家具快搜 &nbsp;|&nbsp;</li>
                <li><a href="/reg.aspx?r=l">登录</a> &nbsp;|&nbsp; </li>
                <li><a href="/reg.aspx">注册</a> </li>
            </ul>
        </div>
    </div>
    <div class="header-box">
        <div class="w clearfix">
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
                <input type="text" class="text" name="name" placeholder="明星家具盛惠，1元拍爆款家具，抢码最高省4500！" /><input
                    class="button" type="button" name="name" value="搜索" />
                <div class="hot">
                     <a class="a-on" target="_blank"  href="/Dealer/index.aspx?did=84">楷模</a>  <a target="_blank" href="/company/210/index.aspx">北欧E家</a> 
            <a href="/51/default.aspx" target="_blank"> 品牌团购</a> <a target="_blank" href="/productlisttbb.aspx">名品折扣</a> 
             <a target="_blank" href="/productlist.aspx?did=7">家具精选</a>  <a target="_blank" href="/productlisttbb.aspx?xid=50&did=11">特价书柜</a>
                        
                        </div>
            </div>
            <div class="right fr">
                <a href="#">
                    <img src="/resource/content/img/common/j1.png" alt="" /></a>
            </div>
        </div>
    </div>
    <div class="nav">
        <div class="nav-box w clearfix">
            <div class="main-nav fl">
                <a href="#" class="a0">全部分类</a>
                <ul class="pull-down">
                    <li class="li1"><a href="/company-brand/list.aspx" target="_blank">家具品牌</a></li>
                    <li class="li2"><a href="/product/list.aspx" target="_blank">卧室系列</a></li>
                    <li class="li3"><a href="/product/list.aspx" target="_blank">餐厅系列</a></li>
                    <li class="li4"><a href="/product/list.aspx" target="_blank">客厅系列</a></li>
                    <li class="li5"><a href="/product/list.aspx" target="_blank">书房系列</a></li>
                    <li class="li6"><a href="/product/list.aspx" target="_blank">户外家具</a></li>
                </ul>
            </div>
            <ul class="nav-title fl">
                <li><a href="/">首 页</a> </li>
                <li><a href="/company-brand/list.aspx">品 牌</a> </li>
                <li><a href="/market/list.aspx">卖场</a> </li>
                <li><a href="#">国际馆</a></li>
            </ul>
            <ul class="fr nav-title-right">
                <li><a href="#">淘宝贝</a></li>
                <li><a href="#">热门团购</a></li>
                <li><a href="#">活动导购</a></li>
            </ul>
        </div>
    </div>
    <div class="advert" id="j_advert">
        <div class="slides">
            <div class="slides_container">
                <div class="box" style="background-image: url(/resource/content/img/common/j3.jpg)">
                    <a href="#" class="block"></a>
                </div>
                <div class="box" style="background-image: url(/resource/content/img/common/j3.jpg)">
                    <a href="#" class="block"></a>
                </div>
                <div class="box" style="background-image: url(/resource/content/img/common/j3.jpg)">
                    <a href="#" class="block"></a>
                </div>
            </div>
        </div>
        <div class="advert-box-wrap">
            <div class="w">
                <div class="advert-box">
                    <h3>
                        快搜快报<a href="#" class="fr">更多</a></h3>
                    <ul>
                        <li><a href="#"><i>.</i>家具快搜入驻优惠</a></li>
                        <li><a href="#"><i>.</i>红枣木卧房四件套 15800！</a></li>
                        <li><a href="#"><i>.</i>红星美凯龙端午缤纷礼</a></li>
                        <li><a href="#"><i>.</i>玉庭哈尔滨市旗舰店开业！</a></li>
                        <li><a href="#"><i>.</i>纯核桃木 卧房四件套14800！</a></li>
                        <li><a href="#"><i>.</i>美特龙6月纳凉特惠季</a></li>
                    </ul>
                    <div class="login">
                        <p>
                            限时入住</p>
                        <input type="button" value="商家入住" onclick="window.location.href='/reg.aspx';" />
                        <a href="/reg.aspx?r=l">登录</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="brand-intro  w">
        <div class="hd clearfix">
            <h2 class="f18 yahei fl mr10">
                品牌推荐</h2>
            <a href="#" target="_blank" class="fr more">更多</a>
            <div class="sub-tit fr">
                <a href="#">中式家具</a> <a href="#">欧式家具</a> <a href="#">韩式田园</a> <a href="#">东南亚风格</a>
            </div>
        </div>
        <div class="bd clearfix">
            <div class="focus fl">
                  <%foreach (t_advertising item in list1)
                  { %>
                <a href="<%=item.linkurl %>" title="<%=item.title %>" target="_blank">
                    <img src='<%=item.imgurl %>' alt="<%=item.title %>" class="block" /></a> </a>
                <%} %>
            </div>
            <div class="list fr">
                <table class="g10">
                    <tr>
                        <%
                            int i = 1;
                            foreach (EnWebAggregation items in newBrand)
                            {%>
                        <%if (i == 8) this.Response.Write("</tr><tr>");%>
                        <td>
                            <a href="<%=items.url%>" target="_blank">
                                <img src="/resource/content/img/index/<%=items.thumb%>" alt="<%=items.title%>" /></a>
                        </td>
                        <%i++;
                            } %>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="week-special time-rush clearfix w" id="j_timeRush">
        <div class="list-time fl">
            <div class="hd clearfix">
                <h2 class="f18 yahei fl mr10">
                    限时抢购</h2>
                <a href="#" target="_blank" class="fr more">更多</a>
            </div>
            <div class="bd">
                <ul>
                    <li class="li0"><a href="#" target="_blank">
                        <img src="/resource/content/img/index/h19.jpg" alt="" class="block" />
                    </a></li>
                    <%
                        i = 1;
                        string imgstyle = "";
                        foreach (EnWebAggregation items in timeLimiBuy)
                        {
                            if (i == 2 || i == 6)
                                imgstyle = "width:382px;height:240px;";
                            else
                                imgstyle = "width:190px;height:240px;";
                    %>
                    <li class="li<%=i %>" data-endtime="<%=items.endtime%>"><a href="<%=items.url %>"
                        target="_blank">
                        <img src="/resource/content/img/index/<%=items.thumb %>" alt="<%=items.title%>" class="block"
                            style="<%=imgstyle%>" />
                        <div class="txt">
                            <div class="p1">
                                离本期结束：<span class="day">00</span> : <span class="shi">00</span> : <span class="fen">00</span> : <span class="miao">
                                    00</span></div>
                            <p class="p2">
                                <del>原价：<%=items.title1%></del></p>
                            <p class="p3">
                                <u>抢购:<%=items.title2%></u></p>
                        </div>
                    </a></li>
                    <%i++;
                        } %>
                </ul>
            </div>
        </div>
        <div class="list-sad fr">
                          <%foreach (t_advertising item in list2)
                          { %>
                             <a href="<%=item.linkurl %>" class="block a1" title="<%=item.title %>" target="_blank"> <img src='<%=item.imgurl %>'  alt="<%=item.title %>" class="block" /></a>
</a>
                        <%} %> 
        </div>
    </div>
    <div class="week-special clearfix w">
        <div class="list-time fl">
            <div class="hd clearfix">
                <h2 class="f18 yahei fl mr10">
                    本周特价</h2>
                <a href="#" target="_blank" class="fr more">更多</a>
            </div>
            <div class="bd">
                <ul>
                    <li class="li0"><a href="#" target="_blank">
                        <img src="/resource/content/img/index/h19.jpg" alt="" class="block" />
                    </a></li>
                    <%
                        i = 1;
                        foreach (EnWebAggregation items in timeLimiBuyB)
                        {
                            if (i == 2 || i == 6)
                                imgstyle = "width:382px;height:240px;";
                            else
                                imgstyle = "width:190px;height:240px;";
                    %>
                    <li class="li<%=i %>"><a href="<%=items.url %>" target="_blank">
                        <img src="/resource/content/img/index/<%=items.thumb%>" alt="<%=items.title%>" class="block"
                            style="<%=imgstyle%>" />
                        <div class="txt">
                            <p class="p1">
                                <%=items.title%></p>
                            <p class="p2">
                                <del>原价：<%=items.title1%></del></p>
                            <p class="p3">
                                <u>特价:<%=items.title2%></u></p>
                        </div>
                    </a></li>
                    <%i++;
                        } %>
                </ul>
            </div>
        </div>
        <div class="list-sad fr">
                <%foreach (t_advertising item in list3)
                          { %>
                             <a href="<%=item.linkurl %>" class="block a1" title="<%=item.title %>" target="_blank"> <img src='<%= item.imgurl %>'  alt="<%=item.title %>" class="block" /></a>
</a>
                        <%} %>
        </div>
    </div>
    <div class="tao-trea w">
        <div class="tab">
            <div class="hd clearfix">
                <h2 class="f18 yahei fl">
                    淘宝贝</h2>
                <ul>
                    <%
                        i = 1;
                        foreach (EnProductCategory items in prodCateList)
                        {
                    %>
                    <li <%if(i==1){ %>class="on" <%} %>>
                        <%=items.title%></li>
                    <%i++;
                        } %>
                </ul>
                <a href="#" target="_blank" class="fr songti more">更多</a> <span class="fr sub-tit  f666">
                    在这里，你可以用最实惠的价格买到厂家的库存产品</span>
            </div>
            <div class="bd">
                <div class="item">
                    <div class="sib clearfix">
                        <div class="focus fl focus-change pb10">
                            <div class="tit">
                                <a href="#">
                                    <img src="/resource/content/img/index/h11.png" alt="客厅系列" /></a>
                            </div>
                            <div class="links clearfix mb10">
                            <%foreach (EnProductCategory items in prodCateDetListA)
                              { %>
                                <span><a href="/product/list---------1--<%=items.parentid %>-<%=items.id %>.aspx"><%=items.title %>(<%=items.lft %>)</a></span>
                                <%} %> <span>
                            </div>
                            <a href="#" class="block f14 b focus-choose">没中意？ 换一批淘一淘</a>
                        </div>
                        <div class="list fr">
                            <ul class="clearfix">
                                <%
                                    for (i = 0; i < 4; i++)
                                    {%>
                                <li>
                                    <div class="d1">
                                        <a href="/product/<%=prodList[i].id%>/info.aspx" target="_blank">
                                            <img src="/upload/product/thumb/<%=prodList[i].id%>/<%=prodList[i].thumb%>" style="width: 180px;
                                                height: 36px:" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">
                                            <%=prodList[i].HtmlProductName%></a></div>
                                    <div class="d3">
                                        <%=prodList[i].categorytitle%></div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥<%=prodList[i].shopprice%></p>
                                            <p class="p2">
                                                库存:
                                            </p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/upload/brand/logo/<%=prodList[i].brandid%>/<%=prodList[i].brandlogo%>" /></a>
                                    </div>
                                </li>
                                <%} %>
                            </ul>
                        </div>
                    </div>
                    <div class="sib clearfix">
                        <div class="focus fl">
                            <a href="#" target="_blank">
                                <img src="/resource/content/img/index/h14.jpg" alt="" /></a>
                        </div>
                        <div class="list fr">
                            <ul class="clearfix">
                                <%
                                    for (i = 4; i < 8; i++)
                                    {%>
                                <li>
                                    <div class="d1">
                                        <a href="/product/<%=prodList[i].id%>/info.aspx" target="_blank">
                                            <img src="/resource/content/img/index/h4.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">
                                            <%=prodList[i].HtmlProductName%></a></div>
                                    <div class="d3">
                                        <%=prodList[i].categorytitle%></div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥<%=prodList[i].shopprice%></p>
                                            <p class="p2">
                                                库存:
                                            </p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h3.png" /></a>
                                    </div>
                                </li>
                                <%} %>
                            </ul>
                        </div>
                    </div>
                    <div class="sib clearfix">
                        <div class="focus fl">
                            <a href="#" target="_blank">
                                <img src="/resource/content/img/index/h15.jpg" alt="" /></a>
                        </div>
                        <div class="list fr">
                            <ul class="clearfix">
                                <%
                                    for (i = 8; i < 12; i++)
                                    {%>
                                <li>
                                    <div class="d1">
                                        <a href="/product/<%=prodList[i].id%>/info.aspx" target="_blank">
                                            <img src="/resource/content/img/index/h4.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">
                                            <%=prodList[i].HtmlProductName%></a></div>
                                    <div class="d3">
                                        <%=prodList[i].categorytitle%></div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥<%=prodList[i].shopprice%></p>
                                            <p class="p2">
                                                库存:
                                            </p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h3.png" /></a>
                                    </div>
                                </li>
                                <%} %>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="item hide">
                    <div class="sib clearfix">
                        <div class="focus fl focus-change pb10">
                            <div class="tit">
                                <a href="#">
                                    <img src="/resource/content/img/index/h11.png" alt="客厅系列" /></a>
                            </div>
                            <div class="links clearfix mb10">
                                <span><a href="#">沙发(295)</a></span> <span><a href="#">茶几(115)</a></span> <span><a
                                    href="#">角几(11)</a></span> <span><a href="#">电视柜(114)</a></span> <span><a href="#">休闲椅(41)</a></span>
                                <span><a href="#">脚踏(11)</a></span> <span><a href="#">展示柜(49)</a></span> <span><a
                                    href="#">玄关/镜(11)</a></span> <span><a href="#">话几(9)</a></span> <span><a href="#">客厅其他(90)</a></span>
                                <span><a href="#">贵妃椅(46)</a></span> <span><a href="#">酒柜(39)</a></span> <span><a
                                    href="#">屏风(1)</a></span> <span><a href="#">鞋柜(23)</a></span> <span><a href="#">花架(19)</a></span>
                            </div>
                            <a href="#" class="block f14 b focus-choose">没中意？ 换一批淘一淘</a>
                        </div>
                        <div class="list fr">
                            <ul class="clearfix">
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h4.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h3.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h5.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h6.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h10.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h9.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h10.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h3.png" /></a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="sib clearfix">
                        <div class="focus fl">
                            <a href="#" target="_blank">
                                <img src="/resource/content/img/index/h14.jpg" alt="" /></a>
                        </div>
                        <div class="list fr">
                            <ul class="clearfix">
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h4.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h3.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h5.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h6.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h10.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h9.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h10.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h3.png" /></a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="sib clearfix">
                        <div class="focus fl">
                            <a href="#" target="_blank">
                                <img src="/resource/content/img/index/h15.jpg" alt="" /></a>
                        </div>
                        <div class="list fr">
                            <ul class="clearfix">
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h4.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h3.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h5.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h6.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h10.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h9.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h10.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h3.png" /></a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="item hide">
                    <div class="sib clearfix">
                        <div class="focus fl focus-change pb10">
                            <div class="tit">
                                <a href="#">
                                    <img src="/resource/content/img/index/h11.png" alt="客厅系列" /></a>
                            </div>
                            <div class="links clearfix mb10">
                                <span><a href="#">沙发(295)</a></span> <span><a href="#">茶几(115)</a></span> <span><a
                                    href="#">角几(11)</a></span> <span><a href="#">电视柜(114)</a></span> <span><a href="#">休闲椅(41)</a></span>
                                <span><a href="#">脚踏(11)</a></span> <span><a href="#">展示柜(49)</a></span> <span><a
                                    href="#">玄关/镜(11)</a></span> <span><a href="#">话几(9)</a></span> <span><a href="#">客厅其他(90)</a></span>
                                <span><a href="#">贵妃椅(46)</a></span> <span><a href="#">酒柜(39)</a></span> <span><a
                                    href="#">屏风(1)</a></span> <span><a href="#">鞋柜(23)</a></span> <span><a href="#">花架(19)</a></span>
                            </div>
                            <a href="#" class="block f14 b focus-choose">没中意？ 换一批淘一淘</a>
                        </div>
                        <div class="list fr">
                            <ul class="clearfix">
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h4.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h3.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h5.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h6.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h10.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h9.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h10.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h3.png" /></a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="sib clearfix">
                        <div class="focus fl">
                            <a href="#" target="_blank">
                                <img src="/resource/content/img/index/h14.jpg" alt="" /></a>
                        </div>
                        <div class="list fr">
                            <ul class="clearfix">
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h4.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h3.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h5.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h6.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h10.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h9.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h10.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h3.png" /></a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="sib clearfix">
                        <div class="focus fl">
                            <a href="#" target="_blank">
                                <img src="/resource/content/img/index/h15.jpg" alt="" /></a>
                        </div>
                        <div class="list fr">
                            <ul class="clearfix">
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h4.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h3.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h5.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h6.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h10.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h9.png" /></a>
                                    </div>
                                </li>
                                <li>
                                    <div class="d1">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h10.png" /></a></div>
                                    <div class="d2 b">
                                        <a href="#" target="_blank">欧莱思特 欧式 斗柜</a></div>
                                    <div class="d3">
                                        100% 实木</div>
                                    <div class="d4 clearfix">
                                        <div class="price fl yahei">
                                            <p class="p1">
                                                价格：￥4740</p>
                                            <p class="p2">
                                                库存：13</p>
                                        </div>
                                        <div class="btn fr">
                                            <a href="#" class="block">立即抢购</a>
                                        </div>
                                    </div>
                                    <div class="d5">
                                        <a href="#" target="_blank">
                                            <img src="/resource/content/img/index/h3.png" /></a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="active-guild">
        <div class="w">
            <div class="hd clearfix yahei">
                <h2 class="f18 yahei fl mr10">
                    商家活动导购</h2>
                <span class="fl sub-tit f666">最新、最全的家具活动折扣信息</span> <a href="#" target="_blank" class="fr more">
                    更多</a>
                <ul class="fr sub-nav">
                    <li><a href="#" target="_blank">商场</a>| <a href="#" target="_blank">品牌</a>| <a href="#"
                        target="_blank">优惠券</a> </li>
                </ul>
            </div>
            <div class="bd">
                <div class="d1 clearfix">
                    <div class="fl">
                        <a href="#" target="_blank">
                            <img src="/resource/content/img/index/h5.jpg" alt="" class="block" /></a></div>
                    <div class="fr">
                        <a href="#" target="_blank">
                            <img src="/resource/content/img/index/h6.jpg" alt="" class="block" /></a></div>
                </div>
                <div class="d2 clearfix">
                    <div class="fl">
                        <a href="#" target="_blank" class="fl">
                            <img src="/resource/content/img/index/h7.jpg" alt="" class="block" /></a> <a href="#"
                                target="_blank" class="fr">
                                <img src="/resource/content/img/index/h8.jpg" alt="" class="block" /></a>
                    </div>
                    <div class="fr">
                        <a href="#" target="_blank">
                            <img src="/resource/content/img/index/h9.jpg" alt="" class="block" /></a></div>
                </div>
                <div class="d3 clearfix">
                    <div class="fl">
                        <a href="#" target="_blank" class="fl">
                            <img src="/resource/content/img/index/h10.jpg" alt="" class="block" /></a> <a href="#"
                                target="_blank" class="fr">
                                <img src="/resource/content/img/index/h11.jpg" alt="" class="block" /></a>
                    </div>
                    <div class="fr shortcut">
                        <div class="tit b f16 tc">
                            <i></i>商家活动查询</div>
                        <dl>
                            <dt><a href="#" target="_blank">卖场</a></dt>
                            <dd>
                                <a href="#" target="_blank">金盛</a> <a href="#" target="_blank">莘潮</a> <a href="#"
                                    target="_blank">欧亚美</a> <a href="#" target="_blank">东明</a> <a href="#" target="_blank">
                                        九星</a> <a href="#" target="_blank">红星美凯龙</a> <a href="#" target="_blank">金海马</a>
                                <a href="#" target="_blank">好美家</a> <a href="#" target="_blank">沪杭春申江</a> <a href="#"
                                    target="_blank">吉盛伟邦</a> <a href="#" target="_blank">好百年</a> <a href="#" target="_blank"
                                        class="a0">更多</a>
                            </dd>
                        </dl>
                        <dl>
                            <dt><a href="#" target="_blank">品牌</a></dt>
                            <dd>
                                <a href="#" target="_blank">金盛</a> <a href="#" target="_blank">莘潮</a> <a href="#"
                                    target="_blank">欧亚美</a> <a href="#" target="_blank">东明</a> <a href="#" target="_blank">
                                        九星</a> <a href="#" target="_blank">红星美凯龙</a> <a href="#" target="_blank">金海马</a>
                                <a href="#" target="_blank">好美家</a> <a href="#" target="_blank">沪杭春申江</a> <a href="#"
                                    target="_blank">吉盛伟邦</a> <a href="#" target="_blank">好百年</a> <a href="#" target="_blank"
                                        class="a0">更多</a>
                            </dd>
                        </dl>
                        <dl>
                            <dt><a href="#" target="_blank">厂商</a></dt>
                            <dd>
                                <a href="#" target="_blank">金盛</a> <a href="#" target="_blank">莘潮</a> <a href="#"
                                    target="_blank">欧亚美</a> <a href="#" target="_blank">东明</a> <a href="#" target="_blank">
                                        九星</a> <a href="#" target="_blank">红星美凯龙</a> <a href="#" target="_blank">金海马</a>
                                <a href="#" target="_blank">好美家</a> <a href="#" target="_blank">沪杭春申江</a> <a href="#"
                                    target="_blank">吉盛伟邦</a> <a href="#" target="_blank">好百年</a> <a href="#" target="_blank"
                                        class="a0">更多</a>
                            </dd>
                        </dl>
                        <a href="#" class="block shortcut-more b f16 tc">更多查询条件</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="step-view w" id="j_stepView">
        <div class="tab">
            <div class="hd clearfix">
                <h2 class="f18 yahei fl">
                    逛卖场</h2>
                <ul>
                    <li class="on">宝山区</li>
                    <li>长宁区</li>
                    <li>虹口区</li>
                    <li>嘉定区</li>
                    <li>金山区</li>
                    <li>闵行区</li>
                    <li>浦东新区</li>
                    <li>普陀区</li>
                    <li>青浦区</li>
                    <li>徐汇区</li>
                    <li>杨浦区</li>
                    <li>闸北区</li>
                </ul>
                <a href="#" target="_blank" class="fr songti more">更多</a>
            </div>
            <div class="bd">
                <div class="item">
                    <div class="d1 clearfix mb5">
                        <div class="focus fl">
                            <a href="#" target="_blank">
                                <img src="/resource/content/img/index/h12.jpg" alt="" class="block" />
                                <img src="/resource/content/img/index/h1.png" alt="" class="trim block" />
                            </a>
                        </div>
                        <div class="slides fr">
                            <div class="slides_container">
                                <div class="box">
                                    <a href="#" class="block">
                                        <img src="/resource/content/img/index/h4.jpg" alt="" />
                                        <p class="txt">
                                            红星美凯龙宝山店</p>
                                    </a>
                                </div>
                                <div class="box">
                                    <a href="#" class="block">
                                        <img src="/resource/content/img/index/h4.jpg" alt="" />
                                        <p class="txt">
                                            红星美凯龙宝山店</p>
                                    </a>
                                </div>
                                <div class="box">
                                    <a href="#" class="block">
                                        <img src="/resource/content/img/index/h4.jpg" alt="" />
                                        <p class="txt">
                                            红星美凯龙宝山店</p>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="d2 w">
                        <ul class="clearfix">
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h1.jpg" alt="" />
                            </a></li>
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h2.jpg" alt="" />
                            </a></li>
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h3.jpg" alt="" />
                            </a></li>
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h1.jpg" alt="" />
                            </a></li>
                        </ul>
                    </div>
                </div>
                <div class="item hide">
                    <div class="d1 clearfix mb5">
                        <div class="focus fl">
                            <a href="#" target="_blank">
                                <img src="/resource/content/img/index/h12.jpg" alt="" class="block" />
                                <img src="/resource/content/img/index/h1.png" alt="" class="trim block" />
                            </a>
                        </div>
                        <div class="slides fr">
                            <div class="slides_container">
                                <div class="box">
                                    <a href="#" class="block">
                                        <img src="/resource/content/img/index/h4.jpg" alt="" />
                                        <p class="txt">
                                            红星美凯龙宝山店</p>
                                    </a>
                                </div>
                                <div class="box">
                                    <a href="#" class="block">
                                        <img src="/resource/content/img/index/h4.jpg" alt="" />
                                        <p class="txt">
                                            红星美凯龙宝山店</p>
                                    </a>
                                </div>
                                <div class="box">
                                    <a href="#" class="block">
                                        <img src="/resource/content/img/index/h4.jpg" alt="" />
                                        <p class="txt">
                                            红星美凯龙宝山店</p>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="d2 w">
                        <ul class="clearfix">
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h1.jpg" alt="" />
                            </a></li>
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h2.jpg" alt="" />
                            </a></li>
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h3.jpg" alt="" />
                            </a></li>
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h1.jpg" alt="" />
                            </a></li>
                        </ul>
                    </div>
                </div>
                <div class="item hide">
                    <div class="d1 clearfix mb5">
                        <div class="focus fl">
                            <a href="#" target="_blank">
                                <img src="/resource/content/img/index/h12.jpg" alt="" class="block" />
                                <img src="/resource/content/img/index/h1.png" alt="" class="trim block" />
                            </a>
                        </div>
                        <div class="slides fr">
                            <div class="slides_container">
                                <div class="box">
                                    <a href="#" class="block">
                                        <img src="/resource/content/img/index/h4.jpg" alt="" />
                                        <p class="txt">
                                            红星美凯龙宝山店</p>
                                    </a>
                                </div>
                                <div class="box">
                                    <a href="#" class="block">
                                        <img src="/resource/content/img/index/h4.jpg" alt="" />
                                        <p class="txt">
                                            红星美凯龙宝山店</p>
                                    </a>
                                </div>
                                <div class="box">
                                    <a href="#" class="block">
                                        <img src="/resource/content/img/index/h4.jpg" alt="" />
                                        <p class="txt">
                                            红星美凯龙宝山店</p>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="d2 w">
                        <ul class="clearfix">
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h1.jpg" alt="" />
                            </a></li>
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h2.jpg" alt="" />
                            </a></li>
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h3.jpg" alt="" />
                            </a></li>
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h1.jpg" alt="" />
                            </a></li>
                        </ul>
                    </div>
                </div>
                <div class="item hide">
                    <div class="d1 clearfix mb5">
                        <div class="focus fl">
                            <a href="#" target="_blank">
                                <img src="/resource/content/img/index/h12.jpg" alt="" class="block" />
                                <img src="/resource/content/img/index/h1.png" alt="" class="trim block" />
                            </a>
                        </div>
                        <div class="slides fr">
                            <div class="slides_container">
                                <div class="box">
                                    <a href="#" class="block">
                                        <img src="/resource/content/img/index/h4.jpg" alt="" />
                                        <p class="txt">
                                            红星美凯龙宝山店</p>
                                    </a>
                                </div>
                                <div class="box">
                                    <a href="#" class="block">
                                        <img src="/resource/content/img/index/h4.jpg" alt="" />
                                        <p class="txt">
                                            红星美凯龙宝山店</p>
                                    </a>
                                </div>
                                <div class="box">
                                    <a href="#" class="block">
                                        <img src="/resource/content/img/index/h4.jpg" alt="" />
                                        <p class="txt">
                                            红星美凯龙宝山店</p>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="d2 w">
                        <ul class="clearfix">
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h1.jpg" alt="" />
                            </a></li>
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h2.jpg" alt="" />
                            </a></li>
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h3.jpg" alt="" />
                            </a></li>
                            <li><a href="#" target="_blank">
                                <img src="/resource/content/img/index/h1.jpg" alt="" />
                            </a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="footer">
        <p class="p1">
            <a href="#">友情链接</a> | <a href="#">标签云</a> | <a href="#">企业介绍</a> | <a href="#">联系我们</a>
            | <a href="#">招聘纳士</a> | <a href="#">网站地图</a> | <a href="/reg.aspx" target="_blank">
                供应商加盟</a> | <a href="/reg.aspx?r=l" target="_blank">供应商登录</a>
        </p>
        <p class="p2">
            <a href="#">友情链接</a>|<a href="#">标签云</a>|<a href="/gywm.html">企业介绍</a>|<a href="/lxwm.html">联系我们</a></p>
        <p class="p3">
            Copyright &copy; <a href="http://www.jiajuks.com/">家具快搜</a>（www.jiajuks.com） &nbsp;沪ICP备12034118号</p>
        <p class="p4">
            <p>
                <img src="http://www.jiajuks.com/resource/web/images/index_130.jpg">
                <a href="#">
                    <img src="http://www.jiajuks.com/resource/web/images/index-08.jpg"></a> <a href="#">
                        <img src="http://www.jiajuks.com/resource/web/images/index-09.jpg"></a>
                <a href="#">
                    <img src="http://www.jiajuks.com/resource/web/images/index-10.jpg"></a>
            </p>
        </p>
    </div>
</body>
</html>
