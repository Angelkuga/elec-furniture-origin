<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productinfotzh.aspx.cs"
    Inherits="TREC.Web.aspx.productinfotzh" %>

<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>产品详情</title>
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <link rel="icon" href="<%=TREC.ECommerce.ECommon.WebUrl %>/favicon.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="<%=TREC.ECommerce.ECommon.WebUrl %>/favicon.ico"
        type="image/x-icon" />
    <link href="/resource/content/css/detail/detail.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/js/core.js" type="text/javascript"></script>
    <script src="/resource/content/js/detail.js" type="text/javascript"></script>
    <style type="text/css">
        /*弹出框*/
        .topstyle
        {
            position: absolute;
            background-color: #000000;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            z-index: 9999999998;
            display: none;
            opacity: 0.0;
        }
        .divopenv
        {
            width: 300px;
            height: 300px;
            position: fixed;
            z-index: 9999999998;
            display: none;
            opacity: 0.0;
        }
        /*弹出框*/
    </style>
    <style>
        .tpm
        {
            width: 222px;
            height: 168px;
            border: 0px;
            line-height: 168px;
            overflow: hidden;
            font-size: 168px;
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        //活动报名 -start
        function addBAOMING(Pid, Ptitle, Purl) {
            <%if (TRECommon.CookiesHelper.GetCookieCustomer("cid") != ""){ %> 
                $("#ifr").attr("src","/addBaoMing.aspx?Pid=" + Pid + "&Ptitle=" + Ptitle + "&prodcon=2"); 
                $("#ifr").attr("width","374");
                $("#ifr").attr("height","523"); 
                $("#divsj").css("width","374px");
                $("#divsj").css("height","523px");
            <%}else{ %>
                $("#ifr").attr("src","/addloginuser.aspx");
                $("#ifr").attr("width","502");
                $("#ifr").attr("height","488"); 
                $("#divsj").css("width","502px");
                $("#divsj").css("height","488px");
            <%} %>
            funopen("divsj");
        }
        //-------------弹出div begin------------------------ 
        function funbgopen() {
            $("#divop").height($(document).height());
            $("#divop").show();
            $("#divop").animate({ opacity: 0.6 }, "slow");

        }
        function funopen(id) {

            funbgopen();

            var w = $("#" + id).width();
            var h = $("#" + id).height();

            var winwid = $(window).width();
            var winheight = $(window).height();
            var sw = (winwid - w) / 2;
            var sh = (winheight - h) / 2;

            $("#" + id).css("left", sw);
            $("#" + id).css("top", sh);
            $("#" + id).show();
            $("#" + id).animate({ opacity: 1.0 }, "slow");


        }
        function funclose(id) {
            $("#divop").hide();
            $("#" + id).hide();
            $("#ifr").attr("src","");
        }
        //-------------弹出div end---divsj---------------------------
        //活动报名 -start
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <uc1:header ID="header1" runat="server" />
    <div class="introduce clearfix w">
        <div class="fl introduce-l">
            <div class="chief clearfix">
                <div style="margin-bottom: 15px; margin-top: 15px;">
                    <%=nav %></div>
                <div class="chief-l fl">
                    <div style="width: 544px;height:409px;" >
                    <img src="<%=thumb %>" alt="" style="max-width: 544px; max-height: 409px;" />
                    </div>
                </div>
                <div class="chief-r fl">
                    <h3 class="yahei">
                        <a target="_blank" href="company/<%=tcompanyid %>/index.aspx">
                            <img src="upload/brand/logo/<%=tbrandid %>/<%=logo %>" width="105" height="38" /></a><font><%=tbrand %>
                                <%=tstyle %>&nbsp;<%=sku %></font>
                        <%=tcz %>
                    </h3>
                    <div class="price b">
                        <span class="f16">组合价 ￥<%=tprice%></span>
                    </div>
                    <div class="information">
                        <div class="b">
                            <label>
                                厂商：</label><%=tcompany%>
                        </div>
                        <div class="b">
                            <label>
                                品牌：</label><i><a target="_blank" href="company/<%=tcompanyid %>/index.aspx"> <span
                                    class="prbj1"><strong>
                                        <%=tbrand %></strong></span></a></i>
                        </div>
                        <div class="b">
                            <label>
                                风格：</label><%=tstyle%>
                        </div>
                        <div class="b">
                            <label>
                                材质：</label>
                            <%=tcz %>
                        </div>
                        <div class="b">
                            <label>
                                系列：</label><i><%=txl%></i>
                        </div>
                        <div class="b">
                            <label>
                                颜色：</label><span><%=tys%></span>
                        </div>
                    </div>
                    <div class="shop">
                        <%if (tshop.Length == 0)
                          { %>
                        <p>
                            对不起，本品牌暂无店铺信息</p>
                        <%}
                          else
                          { %>
                        <div class="pr-quote1 c61f38">
                            <h4>
                                <span class="shop">[店铺]</span><a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/shop/<%=shopid %>/index.aspx"
                                    target="_blank"><%=tshop%></a></h4>
                            <p class="address">
                                <%=address%></p>
                        </div>
                        <%}  %>
                    </div>
                </div>
            </div>
            <div class="product" id="j_productTab">
                <div class="hd">
                    <a id="detail" name="detail"></a>
                    <ul class="clearfix">
                        <li class="on" onclick="window.location='#detail'">商品详细</li>
                        <li onclick="window.location='#img'">细节图片</li>
                        <li onclick="window.location='#shop'">店铺推荐<span></span></li>
                    </ul>
                </div>
                <div class="bd">
                    <div class="item">
                        <%=descript%>
                    </div>
                    <div class="item">
                        <a id="img" name="img"></a>
                        <%=bannel%>
                        <%--<img src="../../../resource/content/img/details/d3.jpg" class="block g10" alt="" />
                        <img src="../../../resource/content/img/details/d3.jpg" class="block g10" alt="" />--%>
                    </div>
                    <div class="item">
                        <div class="intro">
                            <a id="shop" name="shop"></a>
                            <%=othershop%>
                            <%--<table class="g10">
                                <tr>
                                    <td>
                                        <div class="bd-t f14 b">
                                            玉庭家具曲阳路店 <span>021-66248908</span></div>
                                        <div class="clearfix">
                                            <div class="fl image">
                                                <img src="../../../resource/content/img/details/d4.jpg" />
                                            </div>
                                            <div class="fl bd-c-r">
                                                <div>
                                                    所在卖场：<span>吉盛伟邦曲阳店</span></div>
                                                <div>
                                                    上海上海上海上海上海上海上海上海上海上海上海上海上海上海</div>
                                                <div class="div-on">
                                                    [促销]<span>玉庭哈儿滨点开业</span></div>
                                            </div>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="bd-t f14 b">
                                            玉庭家具曲阳路店 <span>021-66248908</span></div>
                                        <div class="clearfix">
                                            <div class="fl image">
                                                <img src="../../../resource/content/img/details/d4.jpg" />
                                            </div>
                                            <div class="fl bd-c-r">
                                                <div>
                                                    所在卖场：<span>吉盛伟邦曲阳店</span></div>
                                                <div>
                                                    上海上海上海上海上海上海上海上海上海上海上海上海上海上海</div>
                                                <div class="div-on">
                                                    [促销]<span>玉庭哈儿滨点开业</span></div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="bd-t f14 b">
                                            玉庭家具曲阳路店 <span>021-66248908</span></div>
                                        <div class="clearfix">
                                            <div class="fl image">
                                                <img src="../../../resource/content/img/details/d4.jpg" />
                                            </div>
                                            <div class="fl bd-c-r">
                                                <div>
                                                    所在卖场：<span>吉盛伟邦曲阳店</span></div>
                                                <div>
                                                    上海上海上海上海上海上海上海上海上海上海上海上海上海上海</div>
                                                <div class="div-on">
                                                    [促销]<span>玉庭哈儿滨点开业</span></div>
                                            </div>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="bd-t f14 b">
                                            玉庭家具曲阳路店 <span>021-66248908</span></div>
                                        <div class="clearfix">
                                            <div class="fl image">
                                                <img src="../../../resource/content/img/details/d4.jpg" />
                                            </div>
                                            <div class="fl bd-c-r">
                                                <div>
                                                    所在卖场：<span>吉盛伟邦曲阳店</span></div>
                                                <div>
                                                    上海上海上海上海上海上海上海上海上海上海上海上海上海上海</div>
                                                <div class="div-on">
                                                    [促销]<span>玉庭哈儿滨点开业</span></div>
                                            </div>
                                        </div>
                                    </td>
                                </tr></table>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="introduce-r fr">
            <div class="introduce-r-t b f14">
                猜你喜欢</div>
            <ul id='ulinfo'>
                <%--li><a href="#">
                    <img src="../../../resource/content/img/details/d5.jpg" class="block g10" alt="" /></a>
                    <div class="d1">
                        <a href="#"><span>凯撒豪庭</span>美式帝王床 美式帝王床</a></div>
                    <a href="#" class="b a">法郎仕欧亚美</a>
                    <div class="d2 b">
                        指导价 ￥5399.00 <span>促销价 5.99.00</span></div>
                </li>--%>
            </ul>
        </div>
    </div>
    <!--弹出窗口-->
    <div class="topstyle" id="divop"></div> 
    <div class="divopenv" id="divsj" style=""><iframe src="" id="ifr"></iframe></div>
    <!--弹出窗口-->
    <uc2:footer runat="server" ID="footer1" />
    </form>
    <script src="../../../resource/content/js/cookies.js" type="text/javascript"></script>
    <link href="/suppler/resource/css/ymPrompt/simple_gray/ymPrompt.css" rel="stylesheet"
        type="text/css" />
    <script src="/resource/script/ymPrompt.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //jQuery("#selcz,#selcc")
            jQuery("#selcz").on("change", function () {
                jQuery("#selcc").val(jQuery("#selcz").val());
                $("#price1").html("指导价 ￥" + jQuery("#selcz :selected").attr("price1"));
                $("#price2").html("促销价 ￥" + jQuery("#selcz :selected").attr("price2"));
            });
            jQuery("#selcc").on("change", function () {
                jQuery("#selcz").val(jQuery("#selcc").val());
                $("#price1").html("指导价 ￥" + jQuery("#selcc :selected").attr("price1"));
                $("#price2").html("促销价 ￥" + jQuery("#selcc :selected").attr("price2"));
            });

            var cv = getCookie("kshis");
            var hisurl = '../../../ajax/hdsearch.ashx?t=ncp&pg=4&did=';
            if (cv != null) {
                var array = cv.split(",");
                //小类/风格/材质/颜色/类型
                hisurl += "&xl=" + array[0];
                hisurl += "&fg=" + array[1];
                hisurl += "&cz=" + array[2];
                hisurl += "&ys=" + array[3];
            } else {
                hisurl += "&xl=&fg=&cz=&ys=";
            }
            hisurl += '&m=' + Math.random();

            $.ajax({
                async: true, //是否异步
                url: hisurl,
                type: 'post', //post方法
                dataType: 'json', //返回json格式数据
                success: function (data) {
                    var s = "";
                    for (var i = 0; i < 5 && data.dt.length; i++) {

                        var imgfilename = data.dt[i].thumb.replace(".", "_230-173.");
                        imgfilename = imgfilename.replace(',', '');

                        s += "<li>";
                        s += "<a href='<%=TREC.ECommerce.ECommon.WebUrl %>/productinfo.aspx?id=" + data.dt[i].tpid + "'><div class='tpm'>";
                        s += "<img src='<%=TREC.ECommerce.ECommon.WebUrl %>/upload/product/thumb/" + data.dt[i].tpid + "/" + imgfilename + "'  alt='' /></div></a>";
                        s += "<div class='d1'><a href='<%=TREC.ECommerce.ECommon.WebUrl %>/productinfon.aspx?id=" + data.dt[i].tpid + "'><span>" + data.dt[i].brandtitle + "</span>" +data.dt[i].categorytitle + ' ' + data.dt[i].sku + ' ' + data.dt[i].materialname + "</a></div>";
                        if (parseInt(data.dt[i].shopid) > 0)
                            s += "<a href='#' class='b a'>[店铺]" + data.dt[i].shoptitle + "</a>";
                        s += "<div class='d2 b'>";
                        if (parseFloat(data.dt[i].markprice) > 0) {
                            s += "市场参考价 ￥" + data.dt[i].markprice;
                        }
                        if (parseFloat(data.dt[i].buyprice) > 0) {
                            s += "<span>促销价 ￥" + data.dt[i].buyprice + "</span>";
                        }
                        s += "</div></li>";
                    }

                    if (s.length == 0)
                        s = "<li>&nbsp;</li>";
                    $("#ulinfo").html(s);

                },
                error: function () { alert('错误'); }
            });



        }); 
    </script>
</body>
</html>
