<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.productlisttbb" %>

<!--淘宝贝产品-->
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="IE=9.0000" http-equiv="X-UA-Compatible">
    <meta charset="utf-8">
    <meta name="renderer" content="webkit|ie-comp|ie-stand">
    <meta http-equiv="X-UA-Compatible" content="IE=7;IE=9;IE=8">
    <title>家具快搜-淘宝贝产品列表</title>
    <link href="../../../resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <link href="../../../resource/content/css/css.css" rel="stylesheet" type="text/css" />
    <script src="../../../resource/content/js/core.js" type="text/javascript"></script>
    <script src="/resource/page/page.js" type="text/javascript"></script>
    <link href="/resource/page/page.css" rel="stylesheet" type="text/css" />
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
    <!--头部文件开始-->
    <style>
        .nav-box .pull-down li dd .inner-img img
        {
            float: left;
            width: 110px;
            height: 36px;
            margin: 3px;
        }
        .tab_con
        {
            padding: 10px;
            display: none;
            overflow: hidden;
            height: 80px;
        }
        .tpm{width:222px;height:168px;line-height:168px;overflow:hidden;font-size:168px;text-align:center;}
        .tpm img {vertical-align:middle} 
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
    <uc1:header ID="header1" runat="server" />
    <!--头部文件结束-->
    <!--菜单开始-->
    <!--菜单结束-->
    <div class="flexslider">
        <ul class="slides">
            <% foreach (t_advertising item in listtop3)
               {%>
            <li style="background: url(<%=item.imgurl %>) 50% 0 no-repeat;"><a target="_blank"
                href="<%=item.linkurl %>"></a></li>
            <%   } %>
        </ul>
        <div class="tbbcp">
            <div class="tbbcp1">
                <% foreach (t_advertising item in listtop4)
                   {%>
                <a target="_blank" href="<%=item.linkurl %>">
                    <img src="<%=item.imgurl %>" width="288" height="180" alt="" /></a>
                <%   } %>
            </div>
        </div>
    </div>
    <div class="main clearfix">
        <div class="listz">
            <h2>
                产品分类</h2>
            <ul id="con_one_1">
                <%=leftmenu %>
            </ul>
            <div class="tbbgg" style="display:none;">
                <%=tj %>
                <%-- <a href="#"><img src="2_files/ggg1.gif" width="200" height="260" alt="" /></a> 
                <a href="#"><img src="2_files/ggg1.gif" width="200" height="260" alt="" /></a>--%>
            </div>
            <div class="tbbrm" id='divrm1' style="display:none;">
                <%--<h3>热卖宝贝</h3>
                <dl>
                    <dt>
                        <img src="2_files/ggg3.gif" width="96" height="64" alt="" /></dt>
                    <dd>
                        <div>
                            <a href="#">法朗仕全实木全实木全实木全实木全实木</a></div>
                        <span class="tbbx21">销量：</span><span class="tbbx22">2344<br>
                            <span class="tbbx21">本站价：</span><span class="tbbx22">¥2344
                    </dd>
                </dl>--%>
            </div>
            <div class="tbbgg" style="display:none;">
                <%=tj2 %>
                <%-- <a href="#"><img src="2_files/ggg1.gif" width="200" height="260" alt="" /></a> 
                <a href="#"><img src="2_files/ggg1.gif" width="200" height="260" alt="" /></a>--%>
            </div>
            <div class="tbbrm" id='divrm2' style="display:none;">
                <%-- <h3>热卖宝贝</h3>
                <dl>
                    <dt>
                        <img src="2_files/ggg3.gif" width="96" height="64" alt="" /></dt>
                    <dd>
                        <div>
                            <a href="#">法朗仕全实木全实木全实木全实木全实木</a></div>
                        <span class="tbbx21">销量：</span><span class="tbbx22">2344<br>
                            <span class="tbbx21">本站价：</span><span class="tbbx22">¥2344
                    </dd>
                </dl>--%>
            </div>
        </div>
        <div class="listy">
            <div class="listy1">
                目前搜索到<span id='licount'></span> 件相关商品&nbsp;&nbsp;&nbsp;&nbsp;<span id='spans'><span
                    id='spantid'></span><span id='spanfg'></span><span id='spancz'></span><span id='spanys'></span><span
                        id='spanpp'></span><span id='spanmc'></span></span><a href="javascript:selall();">清空查询条件</a></div>
            <div class="listy2">
                <%=lx %>
                <dl>
                    <dt><strong>品牌：</strong> </dt>
                    <dd id="ddpp">
                        <div class="pplm">
                            <ul class="tabs" id="tabs2" style="width: 860px;">
                                <li><a href="#" onclick='setchk(this,"ddpp","pp", "")' class="hove" id='ddppall'>不限</a></li>
                                <%=brandlet %>
                            </ul>
                            <ul class="tab_conbox" id="tab_conbox2" style="width: 860px;">
                                <%=recbrand %>
                                <%=brand %>
                            </ul>
                        </div>
                    </dd>
                </dl>
            </div>
            <ul class="listy33 clearfix " style="height:auto;" id='ulinfo'>
                <%--<li>
                    <div class="tbbxl">
                        <a href="#">
                            <img src="2_files/ggg2.gif" width="222" height="166" alt="" /></a><br>
                        <a href="#">法朗仕 茶几 FR026 全实木全实木全实木全实木全实木</a><br>
                        <span>¥7400.00 </span><span class="tbbx2">| 销量：2344</span></div>
                </li>--%>
            </ul>
            <div class="digg">
                <br>
                <span id="paging1" class="page"></span>
                <br>
            </div>
        </div>
    </div>
    <!--弹出窗口-->
    <div class="topstyle" id="divop"></div> 
    <div class="divopenv" id="divsj" style=""><iframe src="" id="ifr"></iframe></div>
    <!--弹出窗口-->
    <ucfooter:footer ID="header2" runat="server" />
    <input type="hidden" id='hiddid' value="<%=dlid %>" />
    <input type="hidden" id='hidxl' value="<%=xlid %>" />
    <input type='hidden' id='hidfg' />
    <input type='hidden' id='hidcz' />
    <input type='hidden' id='hidys' />
    <input type='hidden' id='hidpp' />
    <input type='hidden' id='hidmc' />
    <input type='hidden' id='hidkey' />
    <input type='hidden' id='hidtid' value='<%=leixing %>' /><!--类型-->
    <script src="../../../resource/content/js/jquery.flexslider-min.js" type="text/javascript"></script>
    <script>
        $(function () {
            $('.flexslider').flexslider({
                directionNav: true,
                pauseOnAction: false
            });
        });
    </script>
    <script src="../../../resource/content/js/js.js" type="text/javascript"></script>
    <script type="text/javascript">
        $.each($("#con_one_1 a"), function (i, link) {

            //list2---------1--7-64.aspx?ty=%u5367%u5BA4%u5957%u7EC4%u5408%20

            if ($(this).html().replace(/ /g, "").indexOf("卧室套组合") != -1) {
                link.href = "productlisttbb2.aspx?did=7&ty=" + escape("卧室套组合");
            }
            if ($(this).html().replace(/ /g, "").indexOf("客厅套组合") != -1) {
                link.href = "productlisttbb2.aspx?did=9&ty=" + escape("客厅套组合");
            }
            if ($(this).html().replace(/ /g, "").indexOf("餐厅套组合") != -1) {
                link.href = "productlisttbb2.aspx?did=10&ty=" + escape("餐厅套组合");
            }
            if ($(this).html().replace(/ /g, "").indexOf("书房套组合") != -1) {
                link.href = "productlisttbb2.aspx?did=11&ty=" + escape("书房套组合");
            }
            if ($(this).html().replace(/ /g, "").indexOf("儿童套组合") != -1) {
                link.href = "productlisttbb2.aspx?did=12&ty=" + escape("儿童套组合");
            }
            //            if ($(this).html().replace(/ /g, "").indexOf("套组合") == -1) {
            //            }
            //            else {
            //                link.href = link.href.replace('list', 'list2');
            //                link.href = link.href + "?ty=" + escape($(this).html());
            //            }
        });



        var pagesize = 40;
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
        if (getQueryString("k") != null)
            $("#hidkey").val(getQueryString("k"));


        //        if (getQueryString("dld") != null) {
        //            $("#hrefdl" + getQueryString("dld")).click();
        //        }

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
            $("#ddlx a").each(function (i) {
                $(this).removeClass("hove");
            });
            $("#ddlxall").addClass("hove");

            hd(1);
        }
        hd(1);
        function hd(index) {


            $.ajax({
                async: false, //是否异步
                url: '../../../ajax/hdsearch.ashx?t=tbbl&pm=3&pg=' + pagesize + '&pi=' + index + '&bid=' + $("#hiddid").val() + '&did=' + $("#hidtid").val() + '&xl=' + $("#hidxl").val() + '&fg=' + $("#hidfg").val() + '&cz=' + $("#hidcz").val() + '&ys=' + $("#hidys").val() + '&pp=' + $("#hidpp").val() + '&mc=' + $("#hidmc").val() + '&k=' + escape($("#hidkey").val()) + '&m=' + Math.random(),
                type: 'post', //post方法
                dataType: 'json', //返回json格式数据
                success: function (data) { 
                    var s = "";
                    for (var i = 0; i < data.dt.length; i++) {

                        var titlenames = data.dt[i].brandtitle + ' ' + data.dt[i].categorytitle + ' ' + data.dt[i].sku + ' ' + data.dt[i].materialname;
                        var titlenamesub = titlenames;
                        if (titlenames.length > 16)
                            titlenamesub = titlenames.substr(0, 16) + '...';
                        var imgfilename = data.dt[i].thumb.replace(".", "_230-173.");
                        imgfilename = imgfilename.replace(',', '');
                        s += "<li>";
                        s += "<div class='tbbxl' style='height:300px;text-align:left;'>";
                        s += "<a href='<%=TREC.ECommerce.ECommon.WebUrl %>/productinfo.aspx?id=" + data.dt[i].tpid + "'>";
                        s += "<div class='tpm'><img src='<%=TREC.ECommerce.ECommon.WebUrl %>/upload/product/thumb/" + data.dt[i].tpid + "/" + imgfilename + "' alt='' /></div>";
                        s += "</a><br>";
                        s += "<a href='<%=TREC.ECommerce.ECommon.WebUrl %>/productinfo.aspx?id=" + data.dt[i].tpid + "' title='" + titlenames + "'>" + titlenamesub + "</a><br>";
                       // s += "<span>¥" + data.dt[i].markprice + " </span><span class='tbbx2' style='display:none'>| 销量：</span><br />";
                        if (parseFloat(data.dt[i].markprice) > 0) {
                            s += "<span class='huis' style='color:#808080;font-size:12px;font-weight:normal;'>市场参考价：¥" + data.dt[i].markprice + "</span>";
                        }
                        if (parseFloat(data.dt[i].saleprice) > 0) {
                            if (parseFloat(data.dt[i].buyprice) > 0) {
                                s += "<br /><span class='huis' style='color:#808080;font-size:12px;font-weight:normal;'>销售价：¥" + data.dt[i].saleprice + "</span>";
                            }
                            else {
                                s += "<br /><span class='pricered' >销售价：¥" + data.dt[i].saleprice + "</span>";
                            }
                        }
                        if (parseFloat(data.dt[i].buyprice) > 0) {
                            s += "<br /><span class='pricered'>清仓价：¥" + data.dt[i].buyprice + "</span>";
                        }
                        if (data.dt[i].shoptitle.length > 0) {
                            s += "<a href='<%=TREC.ECommerce.ECommon.WebUrl %>/shop/" + data.dt[i].shopid + "/index.aspx'>";
                            s += "<span style='font-size:12px;color:#333;font-bo'>[店铺] " + getSubString(data.dt[i].shoptitle, 10) + "</span>";
                            s += "</a>";
                        } else {
                            s += "<span style='font-size:12px;color:#333;font-weight:normal'>&nbsp;</span>";
                        }
                        s += "</div>";
                        s += "</li>";

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
               // error: function () { alert('错误'); }
            });
        }

        $.ajax({
            async: false, //是否异步
            url: '../../../ajax/hdsearch.ashx?t=tjcp&did=' + $("#hiddid").val() + '&xid=' + $("#hidxl").val() + '&ty=3&p=3&c=8&m=' + Math.random(),
            type: 'post', //post方法
            dataType: 'json', //返回json格式数据
            success: function (data) {

                var s = "";
                //title过长 截取
                for (var i = 0; i < data.dt.length && i < 4; i++) {
                    s += "<dl>";
                    s += "    <dt>";
                    s += "	<a href='<%=TREC.ECommerce.ECommon.WebUrl %>/productinfo.aspx?id=" + data.dt[i].id + "'><img src='<%=TREC.ECommerce.ECommon.WebUrl %>/upload/product/thumb/" + data.dt[i].id + "/" + data.dt[i].thumb.replace(',', '') + "' width='96' height='64' alt='' /></a></dt>";
                    s += "    <dd>";
                    s += "	<div>";
                    s += "	    <a href='<%=TREC.ECommerce.ECommon.WebUrl %>/productinfo.aspx?id=" + data.dt[i].id + "'>" + data.dt[i].title + "</a></div>";
                    s += "	<span class='tbbx21' style='display:none' >销量：</span><span class='tbbx22'  style='display:none' >2344<br>";
                    s += "	    <span class='tbbx21'>本站价：</span><span class='tbbx22'>¥" + data.dt[i].buyprice + "";
                    s += "    </dd>";
                    s += "</dl>";
                }
                if (s.length > 0)
                    $("#divrm1").html("<h3>热卖宝贝</h3>" + s);

                if (data.dt.length > 4) {
                    s = "";
                    for (var i = 4; i < data.dt.length && i < 8; i++) {
                        s += "<dl>";
                        s += "    <dt>";
                        s += "	<a href='<%=TREC.ECommerce.ECommon.WebUrl %>/productinfo.aspx?id=" + data.dt[i].id + "'><img src='<%=TREC.ECommerce.ECommon.WebUrl %>/upload/product/thumb/" + data.dt[i].id + "/" + data.dt[i].thumb.replace(',', '') + "' width='96' height='64' alt='' /></a></dt>";
                        s += "    <dd>";
                        s += "	<div>";
                        s += "	    <a href='<%=TREC.ECommerce.ECommon.WebUrl %>/productinfo.aspx?id=" + data.dt[i].id + "'>" + data.dt[i].title + "</a></div>";
                        s += "	<span class='tbbx21' style='display:none' >销量：</span><span class='tbbx22'  style='display:none' >2344<br>";
                        s += "	    <span class='tbbx21'>本站价：</span><span class='tbbx22'>¥" + data.dt[i].buyprice + "";
                        s += "    </dd>";
                        s += "</dl>";
                    }
                    if (s.length > 0)
                        $("#divrm2").html("<h3>热卖宝贝</h3>" + s);
                }

            },
          //  error: function () { alert('错误'); }
        });


        function getQueryString(name) {
            var reg = new RegExp("(^|&|\\?)" + name + "=([^&]*)(&|$)"), r;
            if (r = window.location.href.match(reg)) return unescape(r[2]); return null;
        };
        function getSubString(str, len) {
            if (str.length <= len)
                return str;
            return str.substring(0, len) + '…';
        }
       
    </script>
</body>
</html>
