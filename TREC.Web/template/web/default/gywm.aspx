<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gywm.aspx.cs" Inherits="TREC.Web.template.web.gywm" %>

<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/libs/jquery-1.11.0.min.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/index/index.js"></script>
    <style>
        .serviceColumn
        {
            width: 220px;
            border: 0;
        }
        .serviceColumn h2
        {
            background: #828282;
            color: #fff;
            height: 20px;
            line-height: 20px;
            border-bottom: 0;
            position: relative;
        }
        .serviceColumn .block1 .d1
        {
            padding-bottom: 30px;
        }
        .serviceColumn .block1
        {
            padding-bottom: 0;
        }
        .serviceColumn h2 span
        {
            position: absolute;
            bottom: -4px;
            left: 35px;
        }
        .serviceCenter .hd
        {
            border: 1px solid #d0d0d0;
            height: 40px;
            padding-left: 25px;
            line-height: 40px;
            font-weight: bold;
        }
        .serviceCenter .bd
        {
            border: 1px solid #cacaca;
            border-top: 1px solid #5c070f;
            padding: 19px;
            min-height: 646px;
            _height: 646px;
        }
        .serviceCenter .bd .strong
        {
            font-weight: bold;
        }
        .serviceCenter .bd .red
        {
            color: #981120;
        }
        .serviceCenter .bd .underline
        {
            text-decoration: underline;
        }
        .serviceCenter .bd a:hover
        {
            text-decoration: underline;
        }
        .serviceCenter .bd p
        {
            margin-bottom: 25px;
            line-height: 24px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:header ID="header1" runat="server" />
    <div style="width:1000px;margin:0 auto">
        <table id='tab1' border="1" align="center" style="text-align: center;">
            <tr>
                <td colspan='2' style="width:220px">
                    <img alt="关于我们" src="/resource/content/images/about/about1.jpg" original="/images/about/about1.jpg">
                </td>
            </tr>
            <tr>
                <td style="vertical-align:top" >
                    <div class="spL" style="border: 1px solid #cacaca; margin-right: 10px;margin-top:10px;">
                        <div class="spColumn serviceColumn" id="Div1">
                            <div class="block1">
                                <h2 style="background: #b82935; font-size: 12px;">
                                    关于我们<span><img src="/resource/content/images/about/about1.gif" alt="" original="/images/about/about1.gif"></span></h2>
                                <div class="d1" style="min-height: 707px; _height: 707px;">
                                    <p><a class="a1 cur" href="gywm.aspx">公司简介</a></p>
                                    <p><a class="a1 cur" href="lxwm.aspx">联系我们</a></p>
                                    <p><a class="a1 cur" href="yqlj.aspx">友情链接</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
                <td style="vertical-align:top" >
                    <div class="spR" style="margin-top:10px; ">
                        <div class="serviceCenter">
                        
                            <div class="hd">
                                公司简介</div>
                              <div class="bd" style="line-height: 21px; padding-top: 60px; color: #6c6c6c;">
                                <table style="text-align: left;width:715px;">
                                     
                                    <tr>
                                        <td>
                                          <p>
                                    上海福美娜家具有限公司始创于2004年,创立之初福美娜就致力于中国互联网的应用和中国家具电子商务平台的未来发展,历经多年多的潜心经营,福美娜积累了雄厚的资源、资本和丰富的运营经验。2012年2月福美娜隆重推出了国内第一家专业家具行业资讯平台——家具快搜。</p>
                                <p>
                                    家具快搜——作为国内家具行业第一个信息资讯平台，为所有家具厂家、经销商、卖场提供信息发布的服务，通过产品的展示、客服导购、咨询，或是发布活动促销、推广宣传信息以达到和消费者互动的目的；也为消费者提供资源最丰富，操作最简便，最新最全的家具行业信息资讯服务；使消费者轻松选购万种产品，不受时间、空间限制，足不出户逛卖场。买家具、卖家具，上快搜！
                                </p>
                                 <p>
                                    家具快搜优势</p>
                                <ul>
                                    <li>中国互联网第一家具信息发布平台<br />
                                    </li>
                                    <li>信息发布平台与网络商城相互结合形成信息平台与电子商务的互补,有效的弥补了家具行业信息不流通,没有有效的传播途径的空白,是对家具行业电子商务的有机整合。</li>
                                    <li>商家可以在快搜上免费发布信息,也可以加入快搜的增值服务,多重选择,灵活多变。</li>
                                    <li>加入快搜相当于商家多了一个网上店铺,可以实时发布品牌,厂家,产品,店铺,促销信息以及招商信息,为商家节省了大量网络推广和广告费用。</li>
                                    <li>快搜提供专业的客服业务,24小时为消费者提供咨询服务,相当于商家又多了一个网络客服,又为商家节省了一笔雇佣开销。</li>
                                    <li>快搜在为商家发布信息同时,也积极在互联网上进行推广,增加了商家产品的曝光率和线上线下商家店铺的访问量。</li>
                                    <li>为商家带来更精准的广告投放和有需求的潜在客户。</li>
                                    <li>在快搜有<span id="bcount">0</span>个品牌、<span id="mcount">0</span>座卖场、<span id="pcount">0</span>件商品节省了消费者的大量查询时间,让消费者可以足不出户在家逛卖场。真正实现消费者、商家和快搜三方共赢的局面。</li>
                                </ul>
                                        </td>
                                    </tr>
                                </table>
                            </div>    
 
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <ucfooter:footer ID="header2" runat="server" />
    </form> 
</body>
</html>
