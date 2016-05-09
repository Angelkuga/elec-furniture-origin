<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pavilionproduct.aspx.cs" Inherits="TREC.Web.template.web.market.pavilionproduct" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<%@ Register Src="../ascx/Headpavilion.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_marketkeys.ascx" TagName="_marketkeys" TagPrefix="uc6" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>
        <%=pageTitle%></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <uc6:_marketkeys ID="_marketkeys1" Title="-家具卖场-首页" runat="server" />
    <link href="/resource/content/css/core.css" rel="stylesheet" />
    <link href="/resource/content/css/mall/mall.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />
    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script type="text/javascript" src="/resource/script/myfocus-1.2.4.min.js"></script>
    <script type="text/javascript" src="/resource/script/soglobal.js?v2"></script>
    <script type="text/javascript" src="/resource/script/socommon.js"></script>
    <style>
        .promotions
        {
            height: 33px;
            line-height: 33px;
            font-size: 14px;
            font-weight: bold;
            color: #b9003c;
            text-indent: 8px;
            background: #f2f1f1;
            border-bottom: 1px solid #cecece;
        }
        .homebraLi2
        {
            border: 1px solid #d8d8d8;
            overflow: hidden;
            _height: 100%;
            background: #fff;
            padding-bottom: 35px;
        }
        .homebraRight2
        {
            margin-top: 15px;
            padding: 0;
        }
        .homebraLi2 h3
        {
            font-size: 22px;
            color: #b9003c;
            line-height: 30px;
            font-family: microsoft yahei;
            font-weight: 500;
            padding: 15px;
            border-bottom: 1px solid #cecece;
        }
        .jies
        {
            padding: 30px;
            font-size: 14px;
            line-height: 24px;
        }
        .xwlis
        {
            padding: 30px;
        }
        .xwlis dl
        {
            border-bottom: 1px dashed #cecece;
            overflow: hidden;
            padding: 10px 0;
            margin-bottom: 10px;
        }
        .xwlis dt
        {
            float: left;
        }
        .xwlis dd
        {
            float: right;
            width: 750px;
            line-height: 25px;
        }
        .xwlis dd.xw1
        {
            font-size: 18px;
            color: #b9003c;
            font-family: microsoft yahei;
        }
        .xwlis dd.xw2
        {
            color: #aaa;
        }
        .xwlis dd.xw2 a.red
        {
            color: #b9003c;
        }
        .xwlis dd.xw3
        {
        }
        .xwlis dt img
        {
            width: 135px;
            height: 100px;
        }
        .sycp
        {
            border: 1px solid #fff;
            width: 283px;
            padding: 12px;
            font-size: 12px;
            float: left;
            margin: 10px 9px 0 0;
        }
        .sycp:hover
        {
            border: 1px solid #e7e7e7;
            box-shadow: 0px 0px 10px #B7B5B5;
        }
        .sycp1
        {
            width: 283px;
            height: 158px;
            line-height: 158px;
            display: table-cell;
            vertical-align: middle;
            overflow: hidden;
            font-size: 158px;
            text-align: center;
        }
        .sycp1 img
        {
            vertical-align: middle;
        }
        .sycp2
        {
            width: 283px;
            height: 20px;
            line-height: 20px;
            overflow: hidden;
            font-size: 14px;
            font-family: "Microsoft YaHei";
        }
        .sycp3 span
        {
            color: #e00000;
            margin-right: 10px;
        }
        .sycp4
        {
            color: #808080;
            line-height: 22px;
        }
        .sycp4 div
        {
            float: right;
        }
        .sycp4 div span
        {
            color: #e00000;
            font-size: 22px;
        }
        .sycp5
        {
            width: 283px;
            height: 20px;
            line-height: 20px;
            overflow: hidden;
        }
        .sycp5 span
        {
            color: #e00000;
        }
        .sycp5 span.lans
        {
            color: #005aa0;
        }
        
        .sycpp
        {
          border: 1px solid #e7e7e7;
width: 220px;
padding: 8px;
font-size: 12px;
float: left;
margin: 10px 0px 0 0;
height: 242px;
        }
        .sycpp:hover
        {
            border: 1px solid #e7e7e7;
            box-shadow: 0px 0px 10px #B7B5B5;
        }
        .sycpp1
        {
            width: 220px;
            height: 158px;
            line-height: 158px;
            display: table-cell;
            vertical-align: middle;
            overflow: hidden;
            font-size: 158px;
            text-align: center;
        }
        /*
        .sycpp1 img
        {
            vertical-align: middle;
        }*/
        .sycpp1 img {
width: 216px;
height: 162px;
}
        .sycpp2
        {
            width: 220px;
            height: 22px;
            line-height: 22px;
            overflow: hidden;
            font-size: 14px;
            font-family: "Microsoft YaHei";
        }
        .sycpp3 span
        {
            color: #e00000;
            margin-right: 10px;
        }
        .sycpp4
        {
            color: #808080;
            line-height: 22px;
            position: relative;
        }
        .sycpp4 div
        {
            position: absolute;
            top: -3px;
            right: 0px;
        }
        .sycpp4 div span
        {
            color: #e00000;
            font-size: 16px;
        }
        .sycpp5
        {
            width: 220px;
            height: 20px;
            color: #707070;
            padding-left: 12px;
            background: url(/resource/web/css/dit.gif) no-repeat 0px 3px;
            line-height: 20px;
            overflow: hidden;
        }
        .sycppp
        {
            border: none;
            width: 220px;
            padding: 0px;
        }
        .sycppp:hover
        {
            border: none;
            box-shadow: 0px 0px 0px #B7B5B5;
        }
    </style>
    <script type="text/javascript">
        myFocus.set({
            id: 'fjwcontainer', //焦点图盒子ID
            pattern: 'mF_games_tb', //风格应用的名称
            path: '<%=ECommon.WebResourceUrl %>/script/pattern/',
            time: 6, //切换时间间隔(秒)
            trigger: 'mouseover', //触发切换模式:'click'(点击)/'mouseover'(悬停)
            width: 300, //设置图片区域宽度(像素)
            height: 225, //设置图片区域高度(像素)
            txtHeight: 0//文字层高度设置(像素),'default'为默认高度，0为隐藏
        });
        $(function () {
            SoPopVerification(); //弹出联系方式
        });
        function SoPopVerification() {
            //$('#braAboutzs a').lightBox({ fixedNavigation: true });
        }
    </script>
    <script type="text/javascript">
        function showhideall() {
            var val = $("#abcall").html();
            val = val.replace(/\#/, '');
            if (val == "隐藏") {
                $("#allabc").slideUp('slow');
                $("#abcall").html("展开");
            } else if (val == "展开") {
                $("#allabc").slideDown('slow');
                $("#abcall").html("隐藏");
            }
        }
        function showhideabc(obj) {
            $("dd[name='xyz']").removeClass("dn").addClass("dn");
            $("#" + obj + "_xyz").removeClass("dn");

            $("a[name='abc']").removeClass("cut1");
            $("#" + obj + "_abc").addClass("cut1");
        }

        function showmchideabc(obj) {
            $("dd[name='mc_xyz']").removeClass("dn").addClass("dn");
            $("#" + obj + "_mc_xyz").removeClass("dn");

            $("a[name='mc_abc']").removeClass("cut1");
            $("#" + obj + "_mc_abc").addClass("cut1");
        }
        $(document).ready(function () {
            var myid = '';
            var isdo = false;
            $('#sbrand .pro-tab').each(function () {
                if ($.trim($(this).html()) == '') {
                    myid = $(this).attr('id').toString().replace('xyz', 'abc');
                    $('#' + myid).css({ 'color': '#999', 'cursor': 'default' }); //, 'background': '#FCF4CD'
                    $('#' + myid).removeAttr('onmouseover');
                }

                if (!isdo && $.trim($(this).html()) != '') {
                    myid = $(this).attr('id').toString().replace('xyz', 'abc');
                    $('#' + myid).addClass('cut1');
                    $(this).removeClass('dn');
                    isdo = true;
                }
            });
            var mylen = $('#sbrand .cut').size();
            if (0 < mylen) {
                $('#sbrand .cut').parent().removeClass('dn');
                myid = $('#sbrand .cut').parent().attr('id').toString().replace('xyz', 'abc');
                $('#' + myid.toString()).addClass('cut1');
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <uc1:header ID="header1" runat="server" />
    <div class="site">
        <a href="/">家具快搜</a> &gt; <a href="/marketlist.aspx">卖场</a> &gt; 卖场产品</div>
    <div class="marketdesc">
        <div class="topNav992 central" style="background: #fff;">
            <div class="productList1">
                <div class="prlifl1">
                    <div class="prlifl1">
                        <div class="prsq">
                            <a href="#">收起</a></div>
                    </div>
                </div>
                <div class="prlifl2">
                    <div class="prlifl20">
                        <div class="topli-selected">
                            <span style="float: right; padding-right: 10px; font-weight: 400;"><a href="/market/<%=marketInfo.id %>/product.aspx">
                                清空查询条件</a></span> <span class="spanleft">目前搜索到&nbsp;&nbsp;&nbsp;<strong><%=AspNetPager1.RecordCount %></strong>&nbsp;件相关商品</span>
                            <%if (!string.IsNullOrEmpty(ECommon.QuerySearchCategory))
                              { %>
                            <span class="spanright">您当前搜索的是&nbsp;<b><%=(ECProductCategory.GetProductCategoryInfo(" where id=" + (!string.IsNullOrEmpty(ECommon.QuerySearchPCategory) ? ECommon.QuerySearchPCategory : "0")) ?? new EnProductCategory()).title %>&nbsp;<%=(ECProductCategory.GetProductCategoryInfo(" where id=" + (!string.IsNullOrEmpty(ECommon.QuerySearchCategory) ? ECommon.QuerySearchCategory : "0")) ?? new EnProductCategory()).title %></b>&nbsp;<a
                                href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, "", "") %>">×</a></span>
                            <%} %>
                        </div>
                        <%if (ECProduct.GetMarketSearchItem(marketInfo.id.ToString()).FindAll(x => x.isCur == true).Count > 0)
                          { %>
                        <div class="prli-selected">
                            <span>您的搜索条件：</span>
                            <div class="selectedselect">
                                <%foreach (EnSearchItem i in ECProduct.GetMarketSearchItem(marketInfo.id.ToString()).FindAll(x => x.isCur == true))
                                  { %>
                                <a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb.Replace("_" + i.value, ""), ECommon.QuerySearchStyle.Replace("_" + i.value, ""), ECommon.QuerySearchMaterial.Replace("_" + i.value, ""), ECommon.QuerySearchSpread.Replace("_" + i.value, ""), ECommon.QuerySearchColor.Replace("_" + i.value, ""), ECommon.QuerySearchSort.Replace("_" + i.value, ""), ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType.Replace("_" + i.value, ""),ECommon.QuerySearchPCategory.Replace("_" + i.value, ""),ECommon.QuerySearchCategory.Replace("_" + i.value, ""))%>">
                                    <%=i.title%></a>
                                <%} %>
                            </div>
                        </div>
                        <%}
                          else
                          { %>
                        <%} %>
                        <%if (ECommon.QuerySearchCategory != "")
                          { %>
                        <dl class="prlifldl">
                            <dd>
                                产品类型：</dd>
                            <dt>
                                <%foreach (EnSearchItem i in ECProduct.GetMarketProductSearchTypeItem(marketInfo.id.ToString()).FindAll(x => x.type == "type" && x.isCur == false))
                                  { %>
                                <a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType+ "_" + i.value,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory)%>">
                                    <%=i.title /*+ "&nbsp;<span class=\"tcount\">" + i.count + "</span>"*/ %></a>
                                <%} %>
                            </dt>
                        </dl>
                        <%} %>
                        <%-- <dl class="prlifldl">
                            <dd>
                                热门品牌：</dd>
                            <dt>
                                <%foreach (EnSearchItem i in ECProduct.GetMarketSearchItem(marketInfo.id.ToString()).FindAll(x => x.type == "brand" && x.isCur == false))
                                  { %>
                                <a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid,qsb+"_"+i.value,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchColor,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,ECommon.QuerySearchKey,ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory) %>">
                                    <%=i.title /*+ "&nbsp;<span class=\"tcount\">" + i.count + "</span>"*/%></a>
                                <%} %>
                            </dt>
                        </dl>--%>
                        <dl class="prlifldl">
                            <dd>
                                产品风格：</dd>
                            <dt><a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb,"", ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory)%>"
                                class="cut" title="不限">不限</a>
                                <%foreach (EnSearchItem i in ECProduct.GetMarketSearchItem(marketInfo.id.ToString()).FindAll(x => x.type == "style" && x.isCur == false))
                                  { %>
                                <a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle + "_" + i.value, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory)%>">
                                    <%=i.title /*+ "&nbsp;<span class=\"tcount\">" + i.count + "</span>"*/%></a>
                                <%} %>
                            </dt>
                        </dl>
                        <dl class="prlifldl">
                            <dd>
                                产品材质：</dd>
                            <dt><a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle, "", ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory)%>"
                                class="cut" title="不限">不限</a>
                                <%foreach (EnSearchItem i in ECProduct.GetMarketSearchItem(marketInfo.id.ToString()).FindAll(x => x.type == "material" && x.isCur == false))
                                  { %>
                                <a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial + "_" + i.value, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory)%>">
                                    <%=i.title /*+ "&nbsp;<span class=\"tcount\">" + i.count + "</span>"*/%></a>
                                <%} %>
                            </dt>
                        </dl>
                        <%--<dl class="prlifldl">
                            <dd>
                                产品价位：</dd>
                            <dt>
                                <dt>
                                    <%foreach (EnSearchItem i in ECProduct.GetMarketSearchItem(marketInfo.id.ToString()).FindAll(x => x.type == "spread" && x.isCur == false))
                                      { %>
                                    <a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread + "_" + i.value, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory)%>">
                                        <%=i.title + "&nbsp;<span class=\"tcount\">" + i.count + "</span>"%></a>
                                    <%} %>
                                </dt>
                            </dt>
                        </dl>--%>
                        <dl class="prlifldl">
                            <dd>
                                产品色系：</dd>
                            <dt><a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, "", ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory)%>"
                                class="cut" title="不限">不限</a>
                                <%foreach (EnSearchItem i in ECProduct.GetMarketSearchItem(marketInfo.id.ToString()).FindAll(x => x.type == "color" && x.isCur == false))
                                  { %>
                                <a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor+ "_" + i.value, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory)%>">
                                    <%=i.title /*+ "&nbsp;<span class=\"tcount\">" + i.count + "</span>"*/%></a>
                                <%} %>
                            </dt>
                        </dl>
                        <p>
                            <a style="float: right" onclick="showhideall();" id="abcall" href="javascript:void(0);">
                                隐藏</a></p>
                        <div id="allabc" class="pro-r-h-c" style="display: block;">
                            <dl id="sbrand">
                                <%string brand = string.Empty;
                                  if (!string.IsNullOrEmpty(Request["brand"]))
                                      brand = Request["brand"] + "_"; %>
                                <dt>品牌：</dt>
                                <dd id="showsearch">
                                    <a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid,"",ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchColor,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,ECommon.QuerySearchKey,ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory) %>"
                                        name="abc" id="buxianbrand" class="">不限</a> <a onmouseover="showhideabc('ABCD');"
                                            id="ABCD_abc" name="abc" href="javascript:void(0);" class="">ABCD</a> <a onmouseover="showhideabc('EFG');"
                                                id="EFG_abc" name="abc" href="javascript:void(0);" class="">EFG</a>
                                    <a onmouseover="showhideabc('HIJK');" id="HIJK_abc" name="abc" href="javascript:void(0);"
                                        class="">HIJK</a> <a onmouseover="showhideabc('LMN');" id="LMN_abc" name="abc" href="javascript:void(0);"
                                            class="">LMN</a> <a onmouseover="showhideabc('OPQ');" id="OPQ_abc" name="abc" href="javascript:void(0);"
                                                class="">OPQ</a> <a onmouseover="showhideabc('RST');" id="RST_abc" name="abc" href="javascript:void(0);"
                                                    class="">RST</a> <a onmouseover="showhideabc('UVW');" id="UVW_abc" name="abc" href="javascript:void(0);"
                                                        class="">UVW</a> <a onmouseover="showhideabc('XYZ');" id="XYZ_abc" name="abc" href="javascript:void(0);"
                                                            class="">XYZ</a>
                                </dd>
                                <dd id="ABCD_xyz" name="xyz" class="pro-tab dn">
                                    <%foreach (System.Data.DataRow dr in dtBrandLetterIndex.Select("letter='a' or letter='b' or letter='c' or letter='d'"))
                                      {
                                          if (!string.IsNullOrEmpty(brand))
                                          {
                                              if (-1 < brand.IndexOf("_" + dr["id"] + "_"))
                                                  Response.Write("<a class=\"cut\" href=\"" + string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb.Replace("_" + dr["id"], ""), ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) + "\">" + dr["title"] + "</a>");
                                              else
                                                  Response.Write("<a href=\"" + string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb + "_" + dr["id"], ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) + "\">" + dr["title"] + "</a>");
                                          }
                                          else
                                          {
                                              Response.Write("<a href=\"" + string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb + "_" + dr["id"], ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) + "\">" + dr["title"] + "</a>");
                                          }
                                      } %></dd>
                                <dd id="EFG_xyz" name="xyz" class="pro-tab dn">
                                    <%foreach (System.Data.DataRow dr in dtBrandLetterIndex.Select("letter='e' or letter='f' or letter='g'"))
                                      {
                                          Response.Write("<a href=\"" + string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb + "_" + dr["id"], ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) + "\">" + dr["title"] + "</a>");
                                      } %></dd>
                                <dd id="HIJK_xyz" name="xyz" class="pro-tab dn">
                                    <%foreach (System.Data.DataRow dr in dtBrandLetterIndex.Select("letter='h' or letter='i' or letter='j' or letter='k'"))
                                      {
                                          Response.Write("<a href=\"" + string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb + "_" + dr["id"], ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) + "\">" + dr["title"] + "</a>");
                                      } %></dd>
                                <dd id="LMN_xyz" name="xyz" class="pro-tab dn">
                                    <%foreach (System.Data.DataRow dr in dtBrandLetterIndex.Select("letter='l' or letter='m' or letter='c' or letter='n'"))
                                      {
                                          Response.Write("<a href=\"" + string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb + "_" + dr["id"], ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) + "\">" + dr["title"] + "</a>");
                                      } %></dd><dd id="OPQ_xyz" name="xyz" class="pro-tab dn"><%foreach (System.Data.DataRow dr in dtBrandLetterIndex.Select("letter='o' or letter='p' or letter='q'"))
                                                                                                {
                                                                                                    Response.Write("<a href=\"" + string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb + "_" + dr["id"], ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) + "\">" + dr["title"] + "</a>");
                                                                                                } %></dd><dd id="RST_xyz" name="xyz" class="pro-tab dn"><%foreach (System.Data.DataRow dr in dtBrandLetterIndex.Select("letter='r' or letter='s' or letter='t'"))
                                                                                                                                                          {
                                                                                                                                                              Response.Write("<a href=\"" + string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb + "_" + dr["id"], ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) + "\">" + dr["title"] + "</a>");
                                                                                                                                                          } %></dd><dd id="UVW_xyz" name="xyz" class="pro-tab dn"><%foreach (System.Data.DataRow dr in dtBrandLetterIndex.Select("letter='u' or letter='v' or letter='w'"))
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        Response.Write("<a href=\"" + string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb + "_" + dr["id"], ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) + "\">" + dr["title"] + "</a>");
                                                                                                                                                                                                                    } %></dd><dd id="XYZ_xyz" name="xyz" class="pro-tab dn"><%foreach (System.Data.DataRow dr in dtBrandLetterIndex.Select("letter='x' or letter='y' or letter='z'"))
                                                                                                                                                                                                                                                                              {
                                                                                                                                                                                                                                                                                  Response.Write("<a href=\"" + string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb + "_" + dr["id"], ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) + "\">" + dr["title"] + "</a>");
                                                                                                                                                                                                                                                                              } %></dd>
                            </dl>
                        </div>
                    </div>
                </div>
                <div class="productList12">
                    <div class="productList121">
                        <ul class="pr12-ti">
                            <li><a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, "",ECommon.QuerySearchKey, 1, ECommon.QuerySearchType, "", "") %>"
                                class="<%=TREC.ECommerce.UiCommon.QueryStringCur("composing","","","pr12-tia") %>">
                                所有产品</a></li>
                            <%--<li><a href="<%=string.Format(EnUrls.MarketInfoProductList,ECommon.QueryMid,  ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, "recomm", ECommon.QuerySearchKey, 1, ECommon.QuerySearchType, "", "") %>"
                                class="<%=TREC.ECommerce.UiCommon.QueryStringCur("composing","recomm","","pr12-tia") %>">
                                热门产品</a></li>--%>
                        </ul>
                        <div class="pr12-fy">
                            <a href="<%=NextUrl %>" class="xyy">下一页</a><span><%=ECommon.QueryPageIndex %>/<%=AspNetPager1.PageCount %></span><a
                                href="<%=PrvUrl %>" style="float: right;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/product_19.gif" /></a></div>
                    </div>
                    <div class="productList122">
                        <span class="s1">快速分类</span>
                        <%--<div class="pr_xl">
                            <%=sortTitle%>
                            <ul>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoProductList,ECommon.QueryMid,  ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">
                                    产品名称</a></li>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t1","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoProductList,ECommon.QueryMid,  ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">
                                    名称降序</a></li>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_t2","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoProductList,ECommon.QueryMid,  ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_t2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">
                                    名称升序</a></li>
                            </ul>
                        </div>
                        <div class="pr_xl">
                            <%=sortDate %>
                            <ul>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoProductList,ECommon.QueryMid,  ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">
                                    更新时间</a></li>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d1","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoProductList,ECommon.QueryMid,  ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">
                                    由近到远</a></li>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_d2","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoProductList,ECommon.QueryMid,  ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_d2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">
                                    由远到近</a></li>
                            </ul>
                        </div>
                        <div class="pr_xl" style="display: none">
                            <%=sortHot %>
                            <ul>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoProductList,ECommon.QueryMid,  ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">
                                    推荐产品</a></li>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h1","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoProductList,ECommon.QueryMid,  ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h1", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">
                                    由高到低</a></li>
                                <li><a class="<%=TREC.ECommerce.UiCommon.QueryStringCur("sort","_h2","","pr_xla") %>"
                                    href="<%=string.Format(EnUrls.MarketInfoProductList,ECommon.QueryMid,  ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchStaffsize, "_h2", ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) %>">
                                    由低到高</a></li>
                            </ul>
                        </div>
                        <label for="supportDIY"><input name="supprotDIY" id="supportDIY" type="checkbox" value="" /><s>支持定制</s></label>--%>
                        <div class="pr_xl">
                            所有风格
                            <ul>
                                <%foreach (EnSearchItem i in ECProduct.GetMarketSearchItem(marketInfo.id.ToString()).FindAll(x => x.type == "style"))
                                  { %>
                                <li><a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle + "_" + i.value, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory)%>">
                                    <%=i.title %></a></li>
                                <%} %>
                            </ul>
                        </div>
                        <div class="pr_xl">
                            所有材质
                            <ul>
                                <%foreach (EnSearchItem i in ECProduct.GetMarketSearchItem(marketInfo.id.ToString()).FindAll(x => x.type == "material" && x.isCur == false))
                                  { %>
                                <li><a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial + "_" + i.value, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory)%>">
                                    <%=i.title.Length > 5 ? i.title.Substring(0, 5) + "..." : i.title %></a></li>
                                <%} %>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="productList">
                                <%if (list.Count > 0)
                                  { %>
                                <%
                                    int listcount = 0;
                                    foreach (EnWebProduct p in list)
                                    {
                                        listcount++;  %>
                                <div class="sycpp">
                                    <div class="sycpp1" style="width: 216px; height: 162px;overflow:hidden;">
                                        <a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                            <img src="<%=EnFilePath.GetProductThumbPathNew(p.id.ToString(), p.thumb,"230","173") %>" width="196"
                                                height="70" alt="" /></a>
                                    </div>
                                    <div class="sycpp2">
                                        <%=p.HtmlProductName%></div>
                                    <div class="sycpp3">
                                        系列：<span><%=p.brandstitle%></span> 风格：<span><%=p.stylename%></span></div>
                                    <div class="sycpp4">
                                     <% if (TREC.ECommerce.SubmitMeth.getdouble(p.ProductAttributeInfo.markprice) > 0)
                                           {%>
                                        市场参考价：<%=p.ProductAttributeInfo.markprice%>
                                        <%} %>
                                        <div>
                                        <% if (TREC.ECommerce.SubmitMeth.getdouble(p.ProductAttributeInfo.buyprice) > 0)
                                           {%>
                                            促销价：<span>¥<%=p.ProductAttributeInfo.buyprice%></span>
                                            <%} %>
                                            </div>
                                    </div>
                                    <%if (p.ProductShopList != null && p.ProductShopList.Count != 0)
                                      { %>
                                    <div class="sycpp5">
                                        <a href="<%=string.Format(EnUrls.ShopInfoIndex, p.ProductShopInfo.id)%>" target="_blank">
                                            <%=getShopTitle(p.ProductShopInfoBymarket)%></a></div>
                                    <%}
                                      else
                                      {%>
                                    <div class="sycpp5">
                                        对不起，本品牌暂无店铺信息</div>
                                    <% } %>
                                </div>
                                <%} %>
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="false" CurrentPageButtonClass="cpb"
                                    CssClass="pager" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                                    PrevPageText="上一页" ShowPageIndexBox="Never" PageSize="20">
                                </webdiyer:AspNetPager>
                                <%}
                                  else
                                  { %>
                                <img alt="notfound" src="/resource/web/images/notfound.gif" />
                                <%} %>
                            </div>
                         
                
            </div>
            <div class="pro-l" style="float: right;">
                    <h3 style="">
                        产品分类</h3>
                    <div id="con_one_1" class="f1">
                        <%=ECProduct.GetMarketCategoryHtmlToNav(marketInfo.id.ToString())
                        %>
                        <script type="text/javascript">                            $(function () {
                                $(".productList22>.productList221").hover(function 
    () { $(this).addClass("productList221_hover"); }, function () {
        $(this).removeClass("productList221_hover");
    });
                            }); </script>
                    </div>
                    <%--<div style="margin-top: 8px;" class="promotionsR1">
    <div class="promotions"> <span><a href="#">更多</a></span>促销信息</div> <div class="prAd1">
    <a href="#"> <img src="images/index_52.jpg"></a><a href="#"><img src="<%=ECommon.WebResourceUrlToWeb
    %>/images/index_55.jpg"></a><a href="#"><img src="<%=ECommon.WebResourceUrlToWeb
    %>/images/index_58.jpg"></a></div> <%=ECPromotion.GetPromotionHtml(ECPromotion.GetWebTopPromotionListToMarket(4,marketInfo.id))
    %> </div>--%>
                </div>
        </div>
        <ucfooter:footer ID="header3" runat="server" />
    </form>
</body>
</html>
