<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productinfon.aspx.cs" Inherits="TREC.Web.aspx.productinfon" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <title><%=TitleSEO %></title>
    <%=keywordsSEO%>
    <%=DescriptionSEO%>
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
                $("#ifr").attr("src","/addBaoMing.aspx?Pid=" + Pid + "&Ptitle=" + Ptitle + "&prodcon=1"); 
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
            <div style="margin-bottom: 15px; margin-top: 15px;">
                <%=nav %></div>
            <div class="chief clearfix">
                <div class="chief-l fl">
                    <div style="width: 544px; height: 409px;">
                        <img src="<%=imgpath %>" alt="" style="max-width: 544px; max-height: 409px;" /></div>
                </div>
            
                <div class="chief-r fl">
                    <h3 class="yahei">
                        <%=title %>
                        <%--<span>玉庭</span>现代 床头柜（5G258）板式--%></h3>
                    <div class="price b">
                        <%=jg %>
                        <%--指导价 ￥5399.00<span class="f16">促销价 ￥5399.00</span>--%>
                    </div>
                    <div class="information">
                        <div class="b">
                            <label>
                                厂商：</label><%=company %>
                        </div>
                        <div class="b">
                            <label>
                                品牌：</label><i><%=brand %></i>
                        </div>
                        <div class="b">
                            <label>
                                风格：</label><%=fg %>
                        </div>
                        <div class="b">
                            <label>
                                材质：</label>
                            <%=cz %>
                            <%-- <select>
                               <option value="">实用颗粒+实用颗粒</option>
                            </select>--%>
                        </div>
                        <div class="b">
                            <label>
                                尺寸：</label>
                            <%=cc %>
                            <%--<select>
                                    <option value="">200*200*200</option>
                                </select>--%>
                            <label>
                                长/宽/高/（单位：毫米）</label>
                        </div>
                        <div class="b">
                            <label>
                                系列：</label><i><%=xl %></i>
                        </div>
                        <div class="b">
                            <label>
                                颜色：</label><span><%=ys %></span>
                        </div>
                    </div>
                    <div id='divhd' style="display:none">
                        <%=attrpromotion%></div>
                    <div class="shop">
                        <%=dp %>
                        <%--<h4>
                            <span>[店铺]</span><a href="#" class="b f14">玉庭黑龙江冠群店</a></h4>
                        <p class="address">
                            黑龙江省大庆市冠群一楼</p>
                        <p class="phone">
                            <span class="prom">[优惠]</span>欢迎来电咨询促销优惠信息
                        </p>--%>

                        <div style="width:135px;height:36px;background-image:url('/resource/ShoppingCss/jr.gif');"  onclick="funbuying()">
                        <div style="width:100%;height:100%;background-color:#666666;display:none;" id="imgpay">
                      <center style="padding-top:10px;color:White;">正在进入购物车...</center>
                        </div>
                        </div>
                        
                    </div>
                </div>
            </div>
       <div>
       <img src="/resource/web/images/qianglc.gif"   style="display:none;"/>
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
                <div class="item" style="border-bottom: 1px  solid #e7e7e7;">
                <table width="100%" border="0" cellpadding="3" cellspacing="3" >
                            <tr>
                                <th width="70" align="center">
                                    <b>产品名称：</b>
                                </th>
                                <td>
                                    <%=title %>
                                </td>
                                <th width="70" align="center">
                                    <b>产品编号：</b>
                                </th>
                                <td>
                                    <%=_prodSKN%>
                                </td>
                                <th width="70" align="center">
                                    <b>产品品牌：</b>
                                </th>
                                <td>
                                    <%=brand %>
                                </td>
                                <th width="70" align="center">
                                    <b>产品系列：</b>
                                </th>
                                <td>
                                    <%=xl %>
                                </td>
                            </tr>
                            <tr>
                                <th align="center">
                                    <b>产品风格：</b>
                                </th>
                                <td>
                                    <%=fg %>
                                </td>
                                <th align="center">
                                    <b>材质：</b>
                                </th>
                                <td>
                                    <%=_prodCZ%>
                                </td>
                                <th align="center">
                                    <b>颜色：</b>
                                </th>
                                <td>
                                    <%=ys%>
                                </td>
                                <th align="center">
                                    <b>是否组装：</b>
                                </th>
                                <td>
                                    <%=_assemble%>
                                </td>
                            </tr>
                        </table>
                </div>
                    <div class="item">
                        
                        <br />
                        <%=des %>
                        <%--<dl>
                            <dt class="b">风格特点</dt>
                            <dd>
                                现代简约风格。适合自然、简单、舒适的装饰空间。让生活呈现本色，让日子随意流畅，悠然自得。</dd>
                        </dl>
                        <dl>
                            <dt class="b">产品细节</dt>
                            <dd>
                                此款玉庭莱茵系列六尺床的尺寸规格（长*宽*高mm）：2160*2050*840。此款六尺床基材采用实木颗粒板，表面

为实木颗粒板饰面，使用PU环保漆(大宝漆)，符合GB18581-2001标准规定要求，具有耐磨、耐刮、耐高温等特点。此款六尺床线条简单，整体感觉大

气时尚。此款床的内径为：2000mm*1800mm，可使用标准六尺床垫，床板为排骨架结构，床板离地面高度为290mm，无储物功能。
                            </dd>
                        </dl>
                        <dl>
                            <dt class="b">材质工艺</dt>
                            <dd>
                                此款玉庭莱茵系列六尺床的基材为：实木颗粒板+实木颗粒板饰面。辅料为：PU环保漆(大宝漆)和五金部件。

</dd>
                        </dl>
                        <dl>
                            <dt class="b">保养说明</dt>
                            <dd>
                                1、经常用软布为家具去尘，去尘前，应在软布上沾点喷洁剂。2、尽量避免家具面接触到腐蚀性液体、酒精、指

甲油等。</dd>
                        </dl>--%>
                    </div>
                    <div class="item">
                        <a id="img" name="img"></a>
                        <%=imgs %>
                        <%--<img src="../../../resource/content/img/details/d3.jpg" class="block g10" alt="" />
                        <img src="../../../resource/content/img/details/d3.jpg" class="block g10" alt="" />--%>
                    </div>
                    <div class="item">
                        <div class="intro">
                            <a id="shop" name="shop"></a>
                            <%=qtdp %>
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
    <div class="topstyle" id="divop">
    </div>
    <div class="divopenv" id="divsj" style="">
        <iframe src="" id="ifr"></iframe>
    </div>
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
                $("#price1").html("市场参考价 ￥" + jQuery("#selcz :selected").attr("price1"));
                $("#price2").html("销售价 ￥" + jQuery("#selcz :selected").attr("price2"));
                $("#price3").html("<%=ECProduct.CheckbuypriceName(proid) %> ￥" + jQuery("#selcz :selected").attr("price3"));

                //                var title = "<%=title %>" + jQuery("#selcz :selected").text();
                //                var id = jQuery("#selcz :selected").attr("tpid");

                //                if (jQuery("#selcz :selected").attr("pt") == "1") {
                //                    $("#divhd").html("<img src='/resource/content/images/qg.jpg' onclick='addBAOMING(" + id + ",\"" + escape(title) + "\"," + id + ");' />");
                //                } else {
                //                    $("#divhd").html("");
                //                }
            });
            jQuery("#selcc").on("change", function () {
                $("#price1").html("市场参考价 ￥" + jQuery("#selcc :selected").attr("price1"));
                $("#price2").html("销售价 ￥" + jQuery("#selcc :selected").attr("price2"));
                $("#price3").html("<%=ECProduct.CheckbuypriceName(proid) %> ￥" + jQuery("#selcc :selected").attr("price3"));

                //                var title = "<%=title2 %>" + jQuery("#selcc :selected").text();
                //                var id = jQuery("#selcc :selected").attr("tpid");

                //                if (jQuery("#selcc :selected").attr("pt") == "1") {
                //                    $("#divhd").html("<img src='/resource/content/images/qg.jpg' onclick='addBAOMING(" + id + ",\"" + escape(title) + "\"," + id + ");' />");
                //                } else {
                //                    $("#divhd").html("");
                //                }
            });
            //$("#selcc option").eq(1).attr('selected', 'true');

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
                    for (var i = 0; i < data.dt.length; i++) {

                        var imgfilename = data.dt[i].thumb.replace(".", "_230-173.");
                        imgfilename = imgfilename.replace(',', '');

                        s += "<li>";
                        s += "<a href='<%=TREC.ECommerce.ECommon.WebUrl %>/productinfo.aspx?id=" + data.dt[i].tpid + "'><div class='tpm'>";
                        s += "<img src='<%=TREC.ECommerce.ECommon.WebUrl %>/upload/product/thumb/" + data.dt[i].tpid + "/" + imgfilename + "'  alt='' /></div></a>";
                        s += "<div class='d1'><a href='<%=TREC.ECommerce.ECommon.WebUrl %>/productinfon.aspx?id=" + data.dt[i].tpid + "'><span>" + data.dt[i].brandtitle + "</span>" + data.dt[i].categorytitle + ' ' + data.dt[i].sku + ' ' + data.dt[i].materialname + "</a></div>";
                        if (parseInt(data.dt[i].shopid) > 0)
                           
                            s += "<div class='d2 b'>";
                        if (parseFloat(data.dt[i].markprice) > 0) {
                          s+="市场参考价 ￥" + data.dt[i].markprice; 
                        }
                      if (parseFloat(data.dt[i].buyprice) > 0)
                       {
                           s += "<br /> <span style='margin-left:0px;'>" + data.dt[i].buypriceName + " ￥" + data.dt[i].buyprice + "</span>";
                       }
                       s += "<a href='#' class='b a'>[店铺]" + data.dt[i].shoptitle + "</a>";
                        s += "</div></li>";
                    }

                    if (s.length == 0)
                        s = "<li>&nbsp;</li>";
                    $("#ulinfo").html(s);

                },
                error: function () { alert('错误'); }
            });



        });

        function funlogin() {
            $("#ifr").attr("src", "/addloginuser.aspx");
            $("#ifr").attr("width", "502");
            $("#ifr").attr("height", "488");
            $("#divsj").css("width", "502px");
            $("#divsj").css("height", "488px");

            funopen("divsj");
        }
        function funbuying() {
            $("#imgpay").show();
            var tpbid = $("#selcz").val();
            $.post("/ajax/STrolleyData.aspx", { "tpbid": tpbid }, function (data, textStatus) {
                var value = data;
                if (value == "nologin") {
                    $("#imgpay").hide();
                    funlogin()
                }
                else {
                    location.href = "/shoppingTrolley.aspx";
                    //$("#imgpay").hide(3000);
                }
            }, null);

        }
    </script>
</body>
</html>
