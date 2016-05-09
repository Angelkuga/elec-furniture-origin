<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.companybrandlistn" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections" %>

<%@ Register Src="ascx/headerbrand.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="uc2" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>家具快搜-品牌</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7;IE=9;IE=8">
 <ucnewresource:newresource ID="newresource1" runat="server" />
    <link href="../../../resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <link href="../../../resource/content/css/css.css" rel="stylesheet" type="text/css" />
    <link href="../../../resource/content/css/brand/brand.css" rel="stylesheet" type="text/css" />
<script src="../../../resource/content/js/core.js" type="text/javascript"></script>
    <script src="../../../resource/content/libs/slides.min.jquery.js" type="text/javascript"></script>
    
 <script src="../../../resource/content/js/brand.js" type="text/javascript"></script>
 <script src="../../../resource/page/page.js" type="text/javascript"></script>
    <link href="../../../resource/page/page.css" rel="stylesheet" type="text/css" />
    <style>
        .tab_con
        {
            padding: 10px;
            display: none;
            overflow: hidden;
            height: 80px;
        }
   
    </style>
</head>
<body>
    <form id="Form1" runat="server">
 <uc1:header ID="header1" runat="server" />
    <div class="brand-mod w clearfix">
        <div class="cont-l fl">
            <div class="tab" id="j_brandTab" style="width: 950px;">
                <div class="hd clearfix">
                    <ul class="fl">
                        <%=hletter%>
                    </ul>
                    <div class="arrow">
                        <a href="#" class="">收起</a></div>
                </div>
                <div class="filter">
                    <div class="line b f666">
                        目前搜索到<span id='licount'></span>个相关品牌</div>
                    <dl class="clearfix">
                        <dt class="b f666">产品风格：</dt>
                        <%=sfg %>
                    </dl>
                    <dl class="clearfix">
                        <dt class="b f666">产品材质：</dt>
                        <%=scz %>
                    </dl>
                    <dl class="clearfix" style='height: 150px;'>
                        <dt class="b f666">卖场：</dt>
                        <dd>
                            <div class="mall-alpha" id='tab_conbox2'>
                                <ul class="clearfix" id='tab_conbox'>
                                    <%=market %>
                                </ul>
                                <%=allmc %>
                            </div>
                        </dd>
                    </dl>
                </div>
            </div>
            <div class="bd">
                <div class="line clearfix">
                    <div class="fl f14 tit b" id="divbrandshow">
                        按品牌显示</div>
                    <div class="fr" style="display: none">
                        <a class="s1 fr" href="#">下一页</a> <span class="s2 fr songti">1/6</span> <a class="fr s3"
                            href="#">
                            <img src="../../../resource/content/img/brand/product_19.gif" /></a>
                    </div>
                </div>
                <div class="condi clearfix" style="width: 950px">
                    <span class="fl">快速分类</span>
                    <table>
                        <tr>
                            <td>
                                <%=selectfg %>
                                <%--<select class="inp" style="width: 105px;">
                                    <option>所有材质</option>
                                    <option>dddd</option>
                                </select>--%>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                <%=selectcz %>
                                <%-- <select class="inp" style="width: 105px;">
                                    <option>所有风格</option>
                                    <option>dddd</option>
                                </select>--%>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="mainz5" id='ulinfo'>
                   
                </div>
                <%--<div class="brand-result">
                    <ul class="clearfix" id='ulinfo'>
                    </ul>
                </div>--%>
            </div>
            <div class="digg" style="clear: both; margin: 30px;">
                <span id="paging1" class="page"></span>
            </div>
        </div>
        <table>
            <tr>
                <td>
                    <div class="cont-r fr" style="width: 230px;display:none;">
                        <div class="layout_a brand-bar" id="j_brandBar">
                            <div class="tit">
                                品牌查询</div>
                            <div class="brand-search">
                                <input type="text" class="txt" name="key" id='txtkey' style="width: 120px;" />
                                <input type="image" onclick='return selkey();' src="../../../resource/content/img/mall/marketSearch.gif" />
                            </div>
                            <div class="clearfix alpha-list">
                                <ul id="j_letterAlpha" class="clearfix">
                                    <%=rightletter %>
                                    <%--<li><a href="#A">A</a></li>
                        <li><a href="#B">B</a></li>
                        <li><a href="#C">C</a></li>
                        <li><a href="#D">D</a></li>
                        <li class="none">E</li>
                        <li><a href="#F">F</a></li>
                        <li class="none">G</li>
                        <li><a href="#H">H</a></li>
                        <li class="none">I</li>
                        <li><a href="#J">J</a></li>
                        <li><a href="#K">K</a></li>
                        <li><a href="#L">L</a></li>
                        <li><a href="#M">M</a></li>
                        <li><a href="#N">N</a></li>
                        <li><a href="#O">O</a></li>
                        <li><a href="#P">P</a></li>
                        <li><a href="#Q">Q</a></li>
                        <li><a href="#R">R</a></li>
                        <li><a href="#S">S</a></li>
                        <li><a href="#T">T</a></li>
                        <li class="none">U</li>
                        <li class="none">V</li>
                        <li><a href="#W">W</a></li>
                        <li><a href="#X">X</a></li>
                        <li><a href="#Y">Y</a></li>
                        <li><a href="#Z">Z</a></li>--%>
                                </ul>
                            </div>
                            <div style="height: 300px;" class="brand-alpha-list" id="j_letterTree">
                                <ul>
                                    <%=rightletter2 %>
                                    <%--<li class="root"><b>C <s>(3)</s><a name="C" href="#"></a></b>
                            <ul>
                                <li><a target="_blank" href="/company/304/index.aspx"><big>川洋家私</big></a></li>
                                <li><a target="_blank" href="/company/211/index.aspx"><big>诚丰</big></a></li>
                                <li><a target="_blank" href="/company/94/index.aspx"><big>COMO</big></a></li>
                            </ul>
                        </li> --%>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="cont-r fr" style="margin-top: 10px; float: right; width: 230px;">
                        <div class="layout_a brand-bar">
                            <div class="tit">
                                最新入驻品牌</div>
                            <div style='padding: 15px; min-height: 200px;' class="brand-barimglist">
                                <%=tuijian %>
                            </div>
                        </div>
                    </div>
                    <div class="cont-r fr" style="margin-top: 10px; width: 230px;visibility:hidden;">
                        <div class="layout_a brand-bar" style="" >
                            <div class="tit">
                                优质商家</div>
                            <div class="clearfix alpha-list">
                                <%=shangjia %>
                                <%--<ul class="clearfix">
                                    <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/product/21155/info.aspx">
                                        <img src='http://www.jiajuks.com/upload//product/thumb/21155/20130531110052483268_230-173.jpg'
                                            style='width: 223px; height: 165px;' /><br />
                                        <p>
                                            北欧E家 床 HA-516双人床 实木</p>
                                        <p>
                                            参考价：¥9800.00</p>
                                    </a>
                                </ul>
                                <table style="text-align: center">
                                    <tr>
                                        <td valign="top">
                                            <a href='<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/company/210/brand-414.aspx'
                                                target="_blank">
                                                <img src='http://www.jiajuks.com/upload//brand/logo/414/20150121162613926433.png'
                                                    style="height: 32px; width: 84px" />
                                            </a>
                                        </td>
                                        <td valign="top">
                                            <a href='<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/company/210/brand-414.aspx'
                                                target="_blank">
                                                <label>
                                                    北欧E家专业生产实木家具，旗下十种名贵木材、十大经典系列，设计秉承北欧简约风格......</label>
                                            </a>
                                        </td>
                                    </tr>
                                </table>--%>
                            </div>
                        </div>
                    </div>
                    <div class="cont-r fr" style="margin-top: 10px; width: 230px;display:none;">
                        <div class="" >
                            <div class="">
                                <ul >
                                    <%=adv %>
                                </ul>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
<uc2:footer runat="server" ID="footer1" />
    <input type="hidden" id='hidmc' value='' />
    <input type="hidden" id='hidcz' value='' />
    <input type="hidden" id='hidfg' value='' />
    <input type="hidden" id='hidkey' value='' />
    <input type="hidden" id="hidetitle"  value='<%=bname %>'/>
    </form>
    <script type="text/javascript">
        var pagesize = 40;
        function selval(id, id1) {

            $("#hid" + id).val($("#" + id1).val());
            hd(1);
        }
        function setchk(obj, id0, id1, id2) {

            $("#" + id0 + " a").each(function (i) {
                $(this).css("background-color", "");
            });

            $(obj).css("background-color", "#B9003C");

            $("#hid" + id1).val(id2);
            $("#hidkey").val("");
            hd(1);
        }
        function selkey() {
            $("#hidmc").val("");
            $("#hidcz").val("");
            $("#hidfg").val("");
            $("#hidetitle").val("");
            $("#hidkey").val($("#txtkey").val());

            hd(1);
            return false;
        }
        //通过标题查询品牌
        function selectbrand(title) {
            $("#hidetitle").val(title);
            hd(1);
        }
        if (getQueryString("s") != null)
            $("#hidkey").val(getQueryString("s"));

        hd(1);
        function hd(index) {

            $.ajax({
                async: true, //是否异步
                url: '../../../ajax/hdsearch.ashx?t=pp&pi=' + index + '&pg=' + pagesize + '&mc=' + $("#hidmc").val() + '&cz=' + $("#hidcz").val() + '&fg=' + $("#hidfg").val() + '&k=' + escape($("#hidkey").val()) + '&brandName='+escape($("#hidetitle").val())+'&m=' + Math.random(),
                type: 'post', //post方法
                dataType: 'json', //返回json格式数据
                success: function (data) {
                    var s = "";
                    var f = "";
                    var stylecount = 0;
                    for (var i = 0; i < data.dt.length; i++) {
                        stylecount++;
                        if (stylecount % 2 == 0)
                            s += "<div class='pplm2 pplm2y'>";
                        else
                            s += "<div class='pplm2'>";

                        if (data.dt[i].utype == '102' && data.dt[i].did != '0') {
                            s += " <div class='pplm21'>";
                            s += " <a target='_blank' href='/Dealer/index.aspx?did=" + data.dt[i].did + "' >";
                            s += " <img style='margin-bottom:5px;' src=\"<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/upload/brand/logo/" + data.dt[i].id + "/" + data.dt[i].logo.replace(",", "") + "\"  class=\"pplm22tp\" width=\"215\" height=\"50\"  alt=\"\"/></a>";
                            s += " <a target='_blank' href='/Dealer/index.aspx?did=" + data.dt[i].did + "' >";
                            s += " <img src=\"<%=TREC.ECommerce.ECommon.WebUrl %>/upload/brand/thumb/" + data.dt[i].id + "/" + data.dt[i].thumb.replace(",", "") + "\" width=\"215\" height=\"135\"  alt=''/></a></div>";

                            s += "<div class=\"pplm22\"><dd style='cursor:pointer;' class=\"dd1\" onclick='window.open(\"/Dealer/index.aspx?did=" + data.dt[i].did + "\")'>" + data.dt[i].title + "</dd><dd class=\"dd2\">";
                            s += "<strong>风格：</strong>" + data.dt[i].fgtitle + "<br><strong>材质：</strong>" + data.dt[i].cztitle + "</dd>";
                            s += "<dd class=\"dd3\">" + data.dt[i].descript + "</dd>";

                            f = ' <%=string.Format(EnUrls.CompanyInfoProductList, "' + data.dt[i].companyid + '", "' + data.dt[i].id + '","","","","","","", "", "", "","", "") %>';
                            s += "<a href=\"/Dealer/" + data.dt[i].did + "/product-" + data.dt[i].id + "--------1-----.aspx\" target='_blank'>查看产品</a> ";
                            f = ' <%=string.Format(EnUrls.CompanyInfoBrandList, "' + data.dt[i].companyid + '", "' + data.dt[i].id + '") %>';
                            s += "<a href=\"/Dealer/brand.aspx?did=" + data.dt[i].did + "\" target='_blank'>品牌介绍</a> ";
                            f = ' <%=string.Format(EnUrls.CompanyInfoAddressList, "' + data.dt[i].companyid + '", "' + data.dt[i].id + '","1") %>';
                            s += " <a href=\"/Dealer/address.aspx?did=" + data.dt[i].did + "&bid=" + data.dt[i].id + "&page=1\" target='_blank'>店铺地址</a></div></div>";
                        }
                        else {
                            s += " <div class='pplm21'>";
                            s += " <a target='_blank' href='<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/company/" + data.dt[i].companyid + "/index.aspx' >";
                            s += " <img style='margin-bottom:5px;' src=\"<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/upload/brand/logo/" + data.dt[i].id + "/" + data.dt[i].logo.replace(",", "") + "\"  class=\"pplm22tp\" width=\"215\" height=\"50\"  alt=\"\"/></a>";
                            s += " <a target='_blank' href='<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/company/" + data.dt[i].companyid + "/index.aspx' >";
                            s += " <img src=\"<%=TREC.ECommerce.ECommon.WebUrl %>/upload/brand/thumb/" + data.dt[i].id + "/" + data.dt[i].thumb.replace(",", "") + "\" width=\"215\" height=\"135\"  alt=''/></a></div>";

                            s += "<div class=\"pplm22\"><dd style='cursor:pointer;' class=\"dd1\" onclick='window.open(\"<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/company/" + data.dt[i].companyid + "/index.aspx\")'>" + data.dt[i].title + "</dd><dd class=\"dd2\">";
                            s += "<strong>风格：</strong>" + data.dt[i].fgtitle + "<br><strong>材质：</strong>" + data.dt[i].cztitle + "</dd>";
                            s += "<dd class=\"dd3\">" + data.dt[i].descript + "</dd>";

                            f = ' <%=string.Format(EnUrls.CompanyInfoProductList, "' + data.dt[i].companyid + '", "' + data.dt[i].id + '","","","","","","", "", "", "","", "") %>';
                            s += "<a href=\"#\" onclick='window.open(\"" + f + "\")'>查看产品</a> ";
                            f = ' <%=string.Format(EnUrls.CompanyInfoBrandList, "' + data.dt[i].companyid + '", "' + data.dt[i].id + '") %>';
                            s += "<a href=\"#\" onclick='window.open(\"" + f + "\")'>品牌介绍</a> ";
                            f = ' <%=string.Format(EnUrls.CompanyInfoAddressList, "' + data.dt[i].companyid + '", "' + data.dt[i].id + '","1") %>';
                            s += " <a href=\"#\" onclick='window.open(\"" + f + "\")'>店铺地址</a></div></div>";
                        }

                    }

                    if (s.length == 0)
                        s = '<br />暂无信息<br />';
                    $("#ulinfo").html(s);
                    $("#licount").html("<label style='color:red'>&nbsp;" + data.dt.length + "&nbsp;</label>");

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


        function getQueryString(name) {
            var reg = new RegExp("(^|&|\\?)" + name + "=([^&]*)(&|$)"), r;
            if (r = window.location.href.match(reg)) return unescape(r[2]); return null;
        };
        function htmlencode(str) {
            str = str.replace(/&/g, '&amp;');
            str = str.replace(/</g, '&lt;');
            str = str.replace(/>/g, '&gt;');
            str = str.replace(/(?:t| |v|r)*n/g, '<br />');
            str = str.replace(/  /g, '&nbsp; ');
            str = str.replace(/t/g, '&nbsp; &nbsp; ');
            str = str.replace(/x22/g, '&quot;');
            str = str.replace(/x27/g, '&#39;');
            return str;
        }

        function DrawImage(ImgD, FitWidth, FitHeight) {
            var image = new Image();
            image.src = ImgD.src;
            if (image.width > 0 && image.height > 0) {
                if (image.width / image.height >= FitWidth / FitHeight) {
                    if (image.width > FitWidth) {
                        ImgD.width = FitWidth;
                        ImgD.height = (image.height * FitWidth) / image.width;
                    }
                    else {
                        ImgD.width = image.width;
                        ImgD.height = image.height;
                    }
                }
                else {
                    if (image.height > FitHeight) {
                        ImgD.height = FitHeight;
                        ImgD.width = (image.width * FitHeight) / image.height;
                    }
                    else {
                        ImgD.width = image.width;
                        ImgD.height = image.height;
                    }
                }
            }
        }  
    </script>
</body>
</html>
