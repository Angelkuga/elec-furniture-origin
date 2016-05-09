<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.productlist2"
    CodeBehind="productlist2.aspx.cs" %>

<!--套组合产品-->
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta name="renderer" content="webkit|ie-comp|ie-stand" />
    <meta http-equiv="X-UA-Compatible" content="IE=7;IE=9;IE=8">
    <title>家具快搜-套组合产品列表</title>
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <link href="/resource/content/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <script src="/resource/content/js/core.js" type="text/javascript"></script>
    <%--    <script src="../../../resource/content/js/_src/index/index.js" type="text/javascript"></script>--%>
    <script src="/resource/page/page.js" type="text/javascript"></script>
    <link href="/resource/page/page.css" rel="stylesheet" type="text/css" /> 
    <%--    <link href="/resource/content/css/guide/guide.css" rel="stylesheet" type="text/css" />    
    <script src="/resource/content/js/core.js" type="text/javascript"></script>
    <script src="/resource/content/js/guide.js" type="text/javascript"></script>
    <script src="/resource/content/js/_src/index/index.js" type="text/javascript"></script>
    <link href="/resource/content/css/css.css" rel="stylesheet" type="text/css" />
    <script src="/resource/page/page.js" type="text/javascript"></script>
    <link href="/resource/page/page.css" rel="stylesheet" type="text/css" />--%>
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
        .tab_con
        {
            padding: 10px;
            display: none;
            overflow: hidden;
            height: 80px;
        }
        .tpm
        {
            width: 222px;
            height: 168px;
            border: 0px;
            line-height: 168px;
            overflow: hidden;
            font-size: 168px;
            text-align: center;
            position:relative;
        }
        .tpmg{position: absolute;right:0px; bottom:0px;}
        .tpm img
        {
            vertical-align: middle;
        }
  
        .listp:hover
        {
            border: 1px solid #d9d9d9;
            box-shadow: 0px 0px 10px #B7B5B5;
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
    <div class="rmtj">
        <div class="rmtj1">
            <%=remai %>
            <%--<dl>
                <dt>
                    <img src="../../../resource/content/images/cp2.jpg" width="159" height="106" alt="" /></dt>
                <dd>
                    <a href="#">纯天然亚麻布艺沙发</a><br>
                    本站价：<span>￥899</span><br>
                    <img src="../../../resource/content/images/qg.jpg" width="80" height="25" alt="" /></dd>
            </dl>
            <dl>
                <dt>
                    <img src="../../../resource/content/images/cp2.jpg" width="159" height="106" alt="" /></dt>
                <dd>
                    <a href="#">纯天然亚麻布艺沙发</a><br>
                    本站价：<span>￥899</span><br>
                    <img src="../../../resource/content/images/qg.jpg" width="80" height="25" alt="" /></dd>
            </dl>
            <dl>
                <dt>
                    <img src="../../../resource/content/images/cp2.jpg" width="159" height="106" alt="" /></dt>
                <dd>
                    <a href="#">纯天然亚麻布艺沙发</a><br>
                    本站价：<span>￥899</span><br>
                    <img src="../../../resource/content/images/qg.jpg" width="80" height="25" alt="" /></dd>
            </dl>--%>
        </div>
    </div>
    <div class="main clearfix">
        <div class="listz">
            <h2>
                产品分类</h2>
            <ul id='con_one_1'>
                <%=leftmenu %>
                <%--<li class="hove">
                    <a href="#">卧室系列</a>
                    <div class="linu" style="display: block">
                        <a href="#">床</a>
                    </div>
                </li>
                <li>
                    <a href="#">客厅系列</a>
                    <div class="linu">
                        <a href="#">床</a>
                    </div>
                </li>--%>
            </ul>
            <h1>
                推荐产品</h1>
            <div id='divtj'>
            </div>
            <%=tj %>
        </div>
        <div class="listy">
            <div class="listy1">
                目前搜索到<span id='licount'></span> 件相关商品&nbsp;&nbsp;&nbsp;&nbsp;<span id='spans'><span
                    id='spantid'></span><span id='spanfg'></span><span id='spancz'></span><span id='spanys'></span><span
                        id='spanpp'></span><span id='spanmc'></span></span><a href="#" onclick='selall();'>清空查询条件</a></div>
            <div class="listy2">
                <%=lx %>
                <%--<dl>
                    <dt><strong>产品风格：</strong> </dt>
                    <dd>
                        <a href="#">不限</a> <a href="#" class="hove">北欧</a> <a href="#">现代</a> <a href="#">休闲</a>
                        <a href="#">欧式</a> <a href="#">户外</a> <a href="#">中式</a> <a href="#">东南亚</a> <a href="#">
                            法式</a> <a href="#">简欧</a> <a href="#">美式</a> <a href="#">田园 </a><a href="#">韩式</a></dd>
                </dl>
                <dl>
                    <dt><strong>产品材质：</strong> </dt>
                    <dd>
                        <a href="#">不限</a> <a href="#" class="hove">北欧</a> <a href="#">现代</a> <a href="#">休闲</a>
                        <a href="#">欧式</a> <a href="#">户外</a> <a href="#">中式</a> <a href="#">东南亚</a> <a href="#">
                            法式</a> <a href="#">简欧</a> <a href="#">美式</a> <a href="#">田园 </a><a href="#">韩式</a></dd>
                </dl>
                <dl>
                    <dt><strong>产品色系：</strong> </dt>
                    <dd>
                        <a href="#">不限</a> <a href="#" class="hove">北欧</a> <a href="#">现代</a> <a href="#">休闲</a>
                        <a href="#">欧式</a> <a href="#">户外</a> <a href="#">中式</a> <a href="#">东南亚</a> <a href="#">
                            法式</a> <a href="#">简欧</a> <a href="#">美式</a> <a href="#">田园 </a><a href="#">韩式</a></dd>
                </dl>--%>
                <dl>
                    <dt><strong>品牌：</strong> </dt>
                    <dd id="ddpp">
                        <div class="pplm">
                            <ul class="tabs" id="tabs2" style='width: 830px'>
                                <li><a href="#" onclick='setchk(this,"ddpp","pp", "")' class="hove" id='ddppall'>不限</a></li>
                                <%=brandlet %>
                                <%--<li><a href="#">A</a></li>
                                <li><a href="#">B</a> </li>
                                <li><a href="#">C</a> </li>
                                <li><a href="#">D</a></li>
                                <li><a href="#">E</a></li>
                                <li><a href="#">F</a></li>
                                <li><a href="#">G</a></li>
                                <li><a href="#">H</a></li>
                                <li><a href="#">I</a></li>
                                <li><a href="#">J</a></li>
                                <li><a href="#">K</a></li>
                                <li><a href="#">L</a></li>
                                <li><a href="#">M</a></li>
                                <li><a href="#">N</a></li>
                                <li><a href="#">O</a></li>
                                <li><a href="#">P</a></li>
                                <li><a href="#">Q</a></li>
                                <li><a href="#">R</a></li>
                                <li><a href="#">S</a></li>
                                <li><a href="#">T</a></li>
                                <li><a href="#">U</a></li>
                                <li><a href="#">V</a></li>
                                <li><a href="#">W</a></li>
                                <li><a href="#">X</a></li>
                                <li><a href="#">Y</a></li>
                                <li><a href="#">Z</a></li>--%>
                            </ul>
                            <ul class="tab_conbox" id="tab_conbox2" style='width: 830px'>
                                <%=recbrand %>
                                <%=brand %>
                                <%--<li class="tab_con">
                                    <a href="#" class="hove">北欧1</a> 
                                    <a href="#">现代</a> 
                                    <a href="#">休闲</a>
                                </li>
                                <li class="tab_con">
                                    <a href="#" class="hove">北欧2</a> 
                                    <a href="#">现代</a> 
                                    <a href="#"> 休闲</a>
                                </li>
                                <li class="tab_con"><a href="#" class="hove">北欧3</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧4</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>--%>
                            </ul>
                        </div>
                    </dd>
                </dl>
                <dl>
                    <dt><strong>卖场：</strong> </dt>
                    <dd id='ddmc'>
                        <div class="pplm">
                            <ul class="tabs" id="tabs" style='width: 830px'>
                                <li><a href="#" onclick='setchk(this,"ddmc","mc", "")' class="hove" id='ddmcall'>不限</a></li>
                                <%=marketlet %>
                                <%-- <li><a href="#">A</a></li>
                                <li><a href="#">B</a> </li>
                                <li><a href="#">C</a> </li>
                                <li><a href="#">D</a></li>
                                <li><a href="#">E</a></li>
                                <li><a href="#">F</a></li>
                                <li><a href="#">G</a></li>
                                <li><a href="#">H</a></li>
                                <li><a href="#">I</a></li>
                                <li><a href="#">J</a></li>
                                <li><a href="#">K</a></li>
                                <li><a href="#">L</a></li>
                                <li><a href="#">M</a></li>
                                <li><a href="#">N</a></li>
                                <li><a href="#">O</a></li>
                                <li><a href="#">P</a></li>
                                <li><a href="#">Q</a></li>
                                <li><a href="#">R</a></li>
                                <li><a href="#">S</a></li>
                                <li><a href="#">T</a></li>
                                <li><a href="#">U</a></li>
                                <li><a href="#">V</a></li>
                                <li><a href="#">W</a></li>
                                <li><a href="#">X</a></li>
                                <li><a href="#">Y</a></li>
                                <li><a href="#">Z</a></li>--%>
                            </ul>
                            <ul class="tab_conbox" id="tab_conbox" style='width: 830px'>
                                <%=recmarket %>
                                <%=market %>
                                <%-- <li class="tab_con"><a href="#" class="hove">北欧1</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧2</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧3</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧4</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧5</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧6</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧7</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧8</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧9</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧10</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧11</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧12</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧13</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧14</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧15</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧16</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧17</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧18</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧19</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧20</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧17</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧18</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧19</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧20</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧y</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>
                                <li class="tab_con"><a href="#" class="hove">北欧z</a> <a href="#">现代</a> <a href="#">
                                    休闲</a></li>--%>
                            </ul>
                        </div>
                    </dd>
                </dl>
            </div>
            <div class="listy3 clearfix" id='ulinfo'>
                <%-- <div>
                    <img src="../../../resource/content/images/cp3.jpg" width="222" height="166" alt="" />
                    <br>
                    <a href="#">法朗仕 茶几 FR026 全实木</a>
                    <br>
                    <span class="huis">市场参考价：¥7400.00</span>
                    <br>
                    <a href="#"><span class="hse">[店铺]</span> <span class="lanse">法朗仕欧亚美浦东店</span> </a>
                </div>--%>
            </div>
            <div class="digg">
                <br />
                <span id="paging1" class="page"></span>
                <br />
                <%--<span class="disabled">&lt;</span><span class="current">1</span><a href="#?page=2">2</a><a
                    href="#?page=3">3</a><a href="#?page=4">4</a><a href="#">5</a><a href="#?page=6">6</a><a
                        href="#?page=7">7</a>...<a href="#?page=199">199</a><a href="#?page=200">200</a><a
                            href="#?page=2"> &gt; </a>--%>
            </div>
        </div>
    </div>
    <!--弹出窗口-->
    <div class="topstyle" id="divop"></div> 
    <div class="divopenv" id="divsj" style=""><iframe src="" id="ifr"></iframe></div>
    <!--弹出窗口-->
    <ucfooter:footer ID="header2" runat="server" />
    <input type="hidden" id='hidxl' value="<%=xlid %>" />
    <input type='hidden' id='hidfg' />
    <input type='hidden' id='hidcz' />
    <input type='hidden' id='hidys' />
    <input type='hidden' id='hidpp' />
    <input type='hidden' id='hidmc' />
    <input type='hidden' id='hidkey' />
    <input type='hidden' id='hidtype' value='<%=dlid %>' />
    <input type='hidden' id='hidtid' value='<%=leixing %>' /><!--类型-->
    </form>
    <%--<script src="../../../resource/content/js/jq.js" type="text/javascript"></script>--%>
    <script src="../../../resource/content/js/js.js" type="text/javascript"></script>
    <script>

        function getQueryString(name) {
            var reg = new RegExp("(^|&|\\?)" + name + "=([^&]*)(&|$)"), r;
            if (r = window.location.href.match(reg)) return unescape(r[2]); return null;
        };


        //        if (getQueryString("ty") != null)
        //            $("#hidtype").val(getQueryString("ty"));

        var pagesize = 48;


        $.each($("#con_one_1 a"), function (i, link) {
            if ($(this).html().replace(/ /g, "").indexOf("卧室套组合") != -1) {
                link.href = "?did=7&ty=" + escape("卧室套组合"); //link.href = "list2---------1--7-64.aspx?ty=" + escape("卧室套组合");
            }
            if ($(this).html().replace(/ /g, "").indexOf("客厅套组合") != -1) {
                link.href = "?did=9&ty=" + escape("客厅套组合"); //link.href = "list2---------1--9-65.aspx?ty=" + escape("客厅套组合");
            }
            if ($(this).html().replace(/ /g, "").indexOf("餐厅套组合") != -1) {
                link.href = "?did=10&ty=" + escape("餐厅套组合"); //link.href = "list2---------1--10-66.aspx?ty=" + escape("餐厅套组合");
            }
            if ($(this).html().replace(/ /g, "").indexOf("书房套组合") != -1) {
                link.href = "?did=11&ty=" + escape("书房套组合"); //link.href = "list2---------1--11-67.aspx?ty=" + escape("书房套组合");
            }
            if ($(this).html().replace(/ /g, "").indexOf("儿童套组合") != -1) {
                link.href = "?did=12&ty=" + escape("儿童套组合"); //link.href = "list2---------1--12-68.aspx?ty=" + escape("儿童套组合");
            }
            //            if ($(this).html().replace(/ /g, "").indexOf("套组合") == -1) {
            //            }
            //            else {
            //                link.href = link.href.replace('list', 'list2');
            //                link.href = link.href + "?ty=" + escape($(this).html());
            //            }
        });
        function setchk2(id0, id1) {
            setchk($("#dd" + id1 + "all"), id0, id1, "");
        }
        function setchk(obj, id0, id1, v1) {
            $("#" + id0 + " a").each(function (i) {
                $(this).removeClass("hove");
            });
            $(obj).addClass("hove");
            $("#hid" + id1).val(v1);

            if (id0 == "tab_conbox2") {
                $("#ddppall").removeClass("hove");
            }
            if (id0 == "tab_conbox") {
                $("#ddmcall").removeClass("hove");
            }

            var type = "";
            if (id1 == "fg")
                type = "风格：";
            else if (id1 == "cz")
                type = "材质：";
            else if (id1 == "ys")
                type = "色系：";
            else if (id1 == "tid")
                type = "类型：";
            else if (id1 == "mc")
                type = "卖场：";
            else if (id1 == "pp")
                type = "品牌：";


            if ($(obj).html() == "不限")
                $("#span" + id1).html("");
            else
                $("#span" + id1).html("<label style='color:black'>" + type + "</label><label onclick='setchk2(\"" + id0 + "\",\"" + id1 + "\")' style='color:red;cursor:pointer'>" + $(obj).html() + "</label>&nbsp;&nbsp;&nbsp;&nbsp;");


            hd(1);
        }
        function selall() {
            $("#spanfg").html("");
            $("#spancz").html("");
            $("#spanys").html("");
            $("#spanpp").html("");
            $("#spanmc").html("");
            $("#spantid").html("");

            $("#hidfg").val("");
            $("#hidcz").val("");
            $("#hidys").val("");
            $("#hidpp").val("");
            $("#hidmc").val("");
            $("#hidkey").val("");
            $("#hidtid").val("");
            $("#ddtid a").each(function (i) {
                $(this).removeClass("hove");
            });
            $("#ddtidall").addClass("hove");
            $("#ddmc a").each(function (i) {
                $(this).removeClass("hove");
            });
            $("#ddmcall").addClass("hove");

            $("#ddpp a").each(function (i) {
                $(this).removeClass("hove");
            });
            $("#ddppall").addClass("hove");

            $("#ddfg a").each(function (i) {
                $(this).removeClass("hove");
            });
            $("#ddfgall").addClass("hove");

            $("#ddfg a").each(function (i) {
                $(this).removeClass("hove");
            });
            $("#ddfgall").addClass("hove");

            $("#ddcz a").each(function (i) {
                $(this).removeClass("hove");
            });
            $("#ddczall").addClass("hove");
            $("#ddys a").each(function (i) {
                $(this).removeClass("hove");
            });
            $("#ddysall").addClass("hove");


            hd(1);
        }
        hd(1);
        function hd(index) {


            $.ajax({
                async: false, //是否异步
                // url: '../../../ajax/hdsearch.ashx?t=tzh&did=' + $("#hidtid").val() + '&xl=' + $("#hidxl").val() + '&fg=' + $("#hidfg").val() + '&cz=' + $("#hidcz").val() + '&ys=' + $("#hidys").val() + '&pp=' + $("#hidpp").val() + '&mc=' + $("#hidmc").val() + '&k=' + $("#hidkey").val() + '&m=' + Math.random(),
                url: '../../../ajax/hdsearch.ashx?t=tzh&pg=' + pagesize + '&pi=' + index + '&cx=&fg=' + $("#hidfg").val() + '&cz=' + $("#hidcz").val() + '&ys=' + $("#hidys").val() + '&pp=' + $("#hidpp").val() + '&type=' + $("#hidtype").val() + '&mc=' + $("#hidmc").val() + '&m=' + Math.random(),
                type: 'post', //post方法
                dataType: 'json', //返回json格式数据
                success: function (data) {

                    var s = "";
                    for (var i = 0; i < data.dt.length; i++) {

                        var titlenames =  data.dt[i].brandtitle + ' ' + data.dt[i].No + ' ' + data.dt[i].cztitle;
                        var titlenamesub = titlenames;
                        if (titlenames.length > 16)
                            titlenamesub = titlenames.substr(0, 16) + '...';
                        var imgfilename = data.dt[i].thumb.replace(".", "_230-173.");
                        imgfilename = imgfilename.replace(',', '');

                        s += "<div class='listp'>";
                        s += "<div style='margin:0px auto;;width:222px; height:166px;'><a target='_blank' href='<%=TREC.ECommerce.ECommon.WebUrl %>/productinfotzh.aspx?tid=" + data.dt[i].gpId + "'>";
                        s += "<div class='tpm'><img src='<%=TREC.ECommerce.ECommon.WebUrl %>/upload/productgroup/thumb/" + data.dt[i].gpId + "/" + imgfilename + "'  alt='' style='float:left;display:block;'  />";
                        s += "<img class='tpmg' src='../../../resource/content/img/index/common6.gif'/></div> ";
                        s += "</div> </a><br>";
                        //  s += "<a href='product/" + data.dt[i].tpid + "/info.aspx'>" + data.dt[i].tptitle + "</a>";
                        s += "<a  target='_blank'  href='<%=TREC.ECommerce.ECommon.WebUrl %>/productinfotzh.aspx?tid=" + data.dt[i].gpId + "' title='" + titlenames + "'>" + titlenamesub + "</a>";
                        s += "<br>";
                        s += "<span class='huis'>市场参考价：¥" + data.dt[i].price + "</span>";
                        s += "<br>";
                        if (data.dt[i].shoptitle.length > 0) {
                            s += "<a href='<%=TREC.ECommerce.ECommon.WebUrl %>/shop/" + data.dt[i].shopid + "/index.aspx'>";
                            s += "<span class='hse'>&nbsp;&nbsp;&nbsp;[店铺]</span> ";
                            s += "<span class='lanse'>" + getSubString(data.dt[i].shoptitle, 10) + "</span>";
                            s += "</a>";
                        }
                        else {
                            s += "&nbsp;";
                        }
                        s += "</div>";

                    }

                    if (s.length == 0)
                        s = "<div class='productPic productPic1'><div class='productPic1' style='background: url(<%=ECommon.WebResourceUrlToWeb %>/images/not.gif) no-repeat;height: 201px; line-height: 210px; text-align: center; font-size: 16px; font-weight: bold;color: #595959;'>抱歉， 暂无相关产品</div></div>";
                    $("#ulinfo").html(s);

                    $("#licount").html(data.dt.length);

                    //分页
                    if (data.totalrow < pagesize)
                        $("#paging1").html('');
                    else
                        $("#paging1").pagination({
                            items: data.totalrow,
                            cssStyle: 'light-theme',
                            itemsOnPage: pagesize,
                            callFn: "hd",
                            currentPage: index
                        });

                },
                error: function () { alert('错误'); }
            });
        }

        $.ajax({
            async: false, //是否异步
            url: '../../../ajax/hdsearch.ashx?t=tjtzh&did=' + $("#hidtype").val() + '&xid=' + $("#hidxl").val() + '&ty=0&p=0&c=3&m=' + Math.random(),
            type: 'post', //post方法
            dataType: 'json', //返回json格式数据
            success: function (data) {

                var s = "";
                for (var i = 0; i < data.dt.length; i++) {

                    s += "<div>";
                    s += "<a target='_blank' href='<%=TREC.ECommerce.ECommon.WebUrl %>/productinfo.aspx?id=" + data.dt[i].id + "'>";
                    s += "        <img src='<%=TREC.ECommerce.ECommon.WebUrl %>/upload/product/thumb/" + data.dt[i].id + "/" + data.dt[i].thumb.replace(',', '') + "' width='192' height='146' alt='' />";
                    s += "    </a>";
                    s += "    <br>";
                    s += "    <a target='_blank' href='<%=TREC.ECommerce.ECommon.WebUrl %>/productinfo.aspx?id=" + data.dt[i].id + "'>" + data.dt[i].title + "</a>";
                    s += "    <br>";
                    s += "    <span class='huis'>市场参考价：¥" + data.dt[i].buyprice + "</span>";
                    s += "    <br>";
                    s += "</div>";

                }

                $("#divtj").html(s);




            },
            error: function () { alert('错误'); }
        });
        function getSubString(str, len) {
            if (str.length <= len)
                return str;
            return str.substring(0, len) + '…';
        }
       
    </script>
</body>
</html>
