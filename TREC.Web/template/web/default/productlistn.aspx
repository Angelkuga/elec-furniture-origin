<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.productlistn" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>家具快搜-产品列表</title>
    <link href="../../../resource/content/css/guide.css" rel="stylesheet" type="text/css" />
    <script src="../../../resource/content/libs/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="../../../resource/content/js/core.js" type="text/javascript"></script>
    <script src="../../../resource/content/js/guide.js" type="text/javascript"></script>
    <script src="../../../resource/content/js/_src/index/index.js" type="text/javascript"></script>
    <link href="../../../resource/content/css/css.css" rel="stylesheet" type="text/css" />
    <script src="../../../resource/page/page.js" type="text/javascript"></script>
    <link href="../../../resource/page/page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
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
    <div class="main">
        <div class="listz">
            <h1>
                产品分类</h1>
            <ul>
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
        </div>
        <div class="listy">
            <div class="listy1">
                目前搜索到<span id='licount'></span> 件相关商品<a href="#" onclick='selall();'>清空查询条件</a></div>
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
                        <a href="#" onclick='setchk(this,"ddpp","pp", "")' class="hove" id='ddppall'>不限</a>
                        <div class="pplm">
                            <ul class="tabs" id="tabs2">
                                <li><a href="#">A</a></li>
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
                                <li><a href="#">Z</a></li>
                            </ul>
                            <ul class="tab_conbox" id="tab_conbox2">
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
                <dl>
                    <dt><strong>卖场：</strong> </dt>
                    <dd id='ddmc'>
                        <a href="#" onclick='setchk(this,"ddmc","mc", "")' class="hove" id='ddmcall'>不限</a><div class="pplm">
                            <ul class="tabs" id="tabs">
                                <li><a href="#">A</a></li>
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
                                <li><a href="#">Z</a></li>
                            </ul>
                            <ul class="tab_conbox" id="tab_conbox">
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
            <div class="listy3" id='ulinfo'>
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
    <input type="hidden" id='hidxl' value="<%=xlid %>" />
    <input type='hidden' id='hidfg' />
    <input type='hidden' id='hidcz' />
    <input type='hidden' id='hidys' />
    <input type='hidden' id='hidpp' />
    <input type='hidden' id='hidmc' />
    <input type='hidden' id='hidkey' />
    </form>
    <%--<script src="../../../resource/content/js/jq.js" type="text/javascript"></script>--%>
    <script src="../../../resource/content/js/js.js" type="text/javascript"></script>
    <script>
        var pagesize = 16;
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

            
            hd(1);
        }
        function selall() {
            $("#hidfg").val("");
            $("#hidcz").val("");
            $("#hidys").val("");
            $("#hidpp").val("");
            $("#hidmc").val("");
            $("#hidkey").val("");

            $("#ddmc a").each(function (i) {
                $(this).removeClass("hove");
            });
            $("ddmcall").addClass("hove");

            $("#ddpp a").each(function (i) {
                $(this).removeClass("hove");
            });
            $("ddppall").addClass("hove");

            $("#ddfg a").each(function (i) {
                $(this).removeClass("hove");
            });
            $("ddfgall").addClass("hove");

            $("#ddfg a").each(function (i) {
                $(this).removeClass("hove");
            });
            $("ddfgall").addClass("hove");

            $("#ddcz a").each(function (i) {
                $(this).removeClass("hove");
            });
            $("ddczall").addClass("hove");
            $("#ddys a").each(function (i) {
                $(this).removeClass("hove");
            });
            $("ddysall").addClass("hove");
            

            hd(1);
        }
        hd(1);
        function hd(index) {


            $.ajax({
                async: false, //是否异步
                url: '../../../ajax/hdsearch.ashx?t=ncp&xl=' + $("#hidxl").val() + '&fg=' + $("#hidfg").val() + '&cz=' + $("#hidcz").val() + '&ys=' + $("#hidys").val() + '&pp=' + $("#hidpp").val() + '&mc=' + $("#hidmc").val() + '&k=' + $("#hidkey").val() + '&m=' + Math.random(),
                type: 'post', //post方法
                dataType: 'json', //返回json格式数据
                success: function (data) {

                    var s = "";
                    for (var i = pagesize * (index - 1); i <= pagesize * index - 1 && i < data.dt.length; i++) {
                        s += "<div><a href='productinfon.aspx?id=" + data.dt[i].tpid + "'>";
                        s += "<img src='http://jiajuks.com/upload/product/thumb/" + data.dt[i].tpid + "/" + data.dt[i].thumb + "' width='222' height='166' alt='' />";
                        s += "</a><br>";
                        //  s += "<a href='product/" + data.dt[i].tpid + "/info.aspx'>" + data.dt[i].tptitle + "</a>";
                        s += "<a href='productinfon.aspx?id=" + data.dt[i].tpid + "'>" + data.dt[i].tptitle + "</a>";
                        s += "<br>";
                        s += "<span class='huis'>市场参考价：¥" + data.dt[i].markprice + "</span>";
                        s += "<br>";
                        if (false) {
                            s += "<a href='#'>";
                            s += "<span class='hse'>[店铺]</span> ";
                            s += "<span class='lanse'>法朗仕欧亚美浦东店</span>";
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
                    if (data.dt.length < pagesize)
                        $("#paging1").html('');
                    else
                        $("#paging1").pagination({
                            items: data.dt.length,
                            cssStyle: 'light-theme',
                            itemsOnPage: pagesize,
                            callFn: "hd",
                            currentPage: index
                        });

                },
                error: function () { alert('错误'); }
            });
        }


    </script>
</body>
</html>
