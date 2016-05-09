<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.market.product" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_marketnav.ascx" TagName="_marketnav" TagPrefix="uc3" %>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../ascx/_marketkeys.ascx" tagname="_marketkeys" tagprefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_marketkeys ID="_marketkeys1" Title="-产品" runat="server" />
    <uc2:_resource ID="_resource1" runat="server" />
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
                    $('#' + myid).css({ 'color': '#999', 'cursor': 'default', 'background': '#FCF4CD' });
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
    <uc1:_headA ID="_headA1" runat="server" />
    <uc3:_marketnav ID="_marketnav1" runat="server" />
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
                            <span style="float:right; padding-right:10px;font-weight:400;"><a href="/market/<%=marketInfo.id %>/product.aspx">清空查询条件</a></span>
                            <span class="spanleft">目前搜索到&nbsp;&nbsp;&nbsp;<strong><%=AspNetPager1.RecordCount %></strong>&nbsp;件相关商品</span>
                            <%if (!string.IsNullOrEmpty(ECommon.QuerySearchCategory))
                              { %>
                            <span class="spanright">您当前搜索的是&nbsp;<b><%=(ECProductCategory.GetProductCategoryInfo(" where id=" + (!string.IsNullOrEmpty(ECommon.QuerySearchPCategory) ? ECommon.QuerySearchPCategory : "0")) ?? new EnProductCategory()).title %>&nbsp;<%=(ECProductCategory.GetProductCategoryInfo(" where id=" + (!string.IsNullOrEmpty(ECommon.QuerySearchCategory) ? ECommon.QuerySearchCategory : "0")) ?? new EnProductCategory()).title %></b>&nbsp;<a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, "", "") %>">×</a></span>
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
                          <div style="width:738px; height:8px; margin:0 auto; background-color:#FFE1B3; margin-top:8px;"></div>
                        <%} %>
                        <%if (ECommon.QuerySearchCategory != "")
                          { %>
                        <dl class="prlifldl">
                            <dd>产品类型：</dd>
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
                            <dd>产品风格：</dd>
                            <dt>
                                    <a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb,"", ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory)%>" class="cut" title="不限">不限</a>
                                    <%foreach (EnSearchItem i in ECProduct.GetMarketSearchItem(marketInfo.id.ToString()).FindAll(x => x.type == "style" && x.isCur == false))
                                      { %>
                                    <a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle + "_" + i.value, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory)%>">
                                        <%=i.title /*+ "&nbsp;<span class=\"tcount\">" + i.count + "</span>"*/%></a>
                                    <%} %>
                                </dt>
                        </dl>
                        <dl class="prlifldl">
                            <dd>产品材质：</dd>
                            <dt>                               
                                    <a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle, "", ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory)%>" class="cut" title="不限">不限</a>
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
                            <dd>产品色系：</dd>
                            <dt>                               
                                   <a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, "", ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory)%>" class="cut" title="不限">不限</a>
                                    <%foreach (EnSearchItem i in ECProduct.GetMarketSearchItem(marketInfo.id.ToString()).FindAll(x => x.type == "color" && x.isCur == false))
                                      { %>
                                    <a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb, ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor+ "_" + i.value, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory)%>">
                                        <%=i.title /*+ "&nbsp;<span class=\"tcount\">" + i.count + "</span>"*/%></a>
                                    <%} %>
                               
                            </dt>
                        </dl>
                        <p><a style="float: right" onclick="showhideall();" id="abcall" href="javascript:void(0);">隐藏</a></p>
                        <div id="allabc" class="pro-r-h-c" style="display: block;">
                            <dl id="sbrand"><%string brand = string.Empty;
                                              if (!string.IsNullOrEmpty(Request["brand"]))
                                                  brand = Request["brand"] + "_"; %>
                                <dt>品牌：</dt>
                                <dd id="showsearch">
                                    <a href="<%=string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid,"",ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchColor,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,ECommon.QuerySearchKey,ECommon.QueryPageIndex,ECommon.QuerySearchType,ECommon.QuerySearchPCategory,ECommon.QuerySearchCategory) %>" name="abc" id="buxianbrand" class="">不限</a>  
                                    <a onmouseover="showhideabc('ABCD');" id="ABCD_abc" name="abc" href="javascript:void(0);" class="">ABCD</a>                                            
                                    <a onmouseover="showhideabc('EFG');" id="EFG_abc" name="abc" href="javascript:void(0);" class="">EFG</a>                                    
                                    <a onmouseover="showhideabc('HIJK');" id="HIJK_abc" name="abc" href="javascript:void(0);" class="">HIJK</a>                                    
                                    <a onmouseover="showhideabc('LMN');" id="LMN_abc" name="abc" href="javascript:void(0);" class="">LMN</a>                                    
                                    <a onmouseover="showhideabc('OPQ');" id="OPQ_abc" name="abc" href="javascript:void(0);" class="">OPQ</a>                                    
                                    <a onmouseover="showhideabc('RST');" id="RST_abc" name="abc" href="javascript:void(0);" class="">RST</a>                                    
                                    <a onmouseover="showhideabc('UVW');" id="UVW_abc" name="abc" href="javascript:void(0);" class="">UVW</a>                                    
                                    <a onmouseover="showhideabc('XYZ');" id="XYZ_abc" name="abc" href="javascript:void(0);" class="">XYZ</a>                                    
                                </dd>                                
                                <dd id="ABCD_xyz" name="xyz" class="pro-tab dn"><%foreach (System.Data.DataRow dr in dtBrandLetterIndex.Select("letter='a' or letter='b' or letter='c' or letter='d'"))
                                                                                   {
                                                                                       if (!string.IsNullOrEmpty(brand))
                                                                                       {
                                                                                           if(-1 < brand.IndexOf("_"+dr["id"]+"_"))
                                                                                               Response.Write("<a class=\"cut\" href=\"" + string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb.Replace("_"+dr["id"],""), ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) + "\">" + dr["title"] + "</a>");
                                                                                           else
                                                                                               Response.Write("<a href=\"" + string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb + "_" + dr["id"], ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) + "\">" + dr["title"] + "</a>");
                                                                                       }
                                                                                       else
                                                                                       {
                                                                                           Response.Write("<a href=\"" + string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb + "_" + dr["id"], ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) + "\">" + dr["title"] + "</a>");
                                                                                       }
                                                                                   } %></dd>
                                <dd id="EFG_xyz" name="xyz" class="pro-tab dn"><%foreach (System.Data.DataRow dr in dtBrandLetterIndex.Select("letter='e' or letter='f' or letter='g'"))
                                                                                   {
                                                                                       Response.Write("<a href=\"" + string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb + "_" + dr["id"], ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) + "\">" + dr["title"] + "</a>");
                                                                                   } %></dd>
                                
                                <dd id="HIJK_xyz" name="xyz" class="pro-tab dn"><%foreach (System.Data.DataRow dr in dtBrandLetterIndex.Select("letter='h' or letter='i' or letter='j' or letter='k'"))
                                                                                   {
                                                                                       Response.Write("<a href=\"" + string.Format(EnUrls.MarketInfoProductList, ECommon.QueryMid, qsb + "_" + dr["id"], ECommon.QuerySearchStyle, ECommon.QuerySearchMaterial, ECommon.QuerySearchSpread, ECommon.QuerySearchColor, ECommon.QuerySearchSort, ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex, ECommon.QuerySearchType, ECommon.QuerySearchPCategory, ECommon.QuerySearchCategory) + "\">" + dr["title"] + "</a>");
                                                                                   } %></dd>
                                                                                   <dd id="LMN_xyz" name="xyz" class="pro-tab dn"><%foreach (System.Data.DataRow dr in dtBrandLetterIndex.Select("letter='l' or letter='m' or letter='c' or letter='n'"))
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
                <%foreach (EnWebProduct p in list)
                  { %>
                <div class="productPic productPic1">
                    <div class="productPic1">
                        <div class="productPic11">
                            <a title="<%=p.brandtitle + " " +p.materialname + " " + p.stylename+" "+p.categorytitle+" "+ p.sku %>" href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                <img alt="<%=p.brandtitle + " " +p.materialname + " " + p.stylename+" "+p.categorytitle+" "+ p.sku %>" src="<%=EnFilePath.GetProductThumbPathNew(p.id.ToString(),p.thumb,"230","173") %>"/></a></div>
                        <div class="productPic12 c61f38" style="padding-top: 10px;">
                            <h4>
                                <a href="<%=string.Format(EnUrls.ProductInfo,p.id) %>" target="_blank">
                                    <%=p.HtmlProductName%></a></h4>
                            <p>
                                <strong>系列：</strong><%=p.brandstitle%>&nbsp; <strong>风格：</strong><%=p.stylename%>
                            </p>
                            <p>
                                <strong>材质：</strong><select name="" style="width: 208px; height: 25px;">
                                    <%--<%foreach (ProductAttribute a in p.ProductAttributeList)
                                      { %>
                                    <option>
                                        <%=a.productmaterial%></option>
                                    <%} %>--%>
                                    <%foreach (object s in p.HtMaterial.Keys)
                                     { %>
                                    <option>
                                        <%=s.ToString()%></option>
                                    <%} %>
                                </select></p>
                            <p>
                                <strong>尺寸：</strong><select name="select" style="width: 208px; height: 25px;">
                                    <%--<%foreach (ProductAttribute a in p.ProductAttributeList)
                                      { %>
                                    <option>
                                        <%=double.Parse(a.productlength) + "*" + double.Parse(a.productwidth) + "*" + double.Parse(a.productheight)%></option>
                                    <%} %>--%>
                                    <%foreach (object s in p.HtSize.Keys)
                                     { %>
                                    <option>
                                        <%=s.ToString() %></option>
                                    <%} %>
                                </select>
                            </p>
                            <%--<p>
                                <strong>颜色：</strong><%=p.ProductAttributeInfo.productcolortitle%></p>--%>
                            <h4>
                                <a style="text-decoration: none" href="javascript:;">指导价：<%=p.ProductAttributeInfo.markprice%></a></h4>
                                
                                <%if (p.FID != 0)
                                  { %>
                                 
                                      <p style="padding-top:10px;display:none">
                                           <a target="_blank" width="231px" class="gotoimg" height="24px" href="http://www.fujiawang.com/dianshigui/<%=p.FID %>/">
                                           &nbsp
                                           </a>
                                       </p>
                                  <%} %>
                        </div>
                        <%if (p.ProductShopList != null && p.ProductShopList.Count != 0)
                          { %>
                        <%--<div class="productPic13">
                            <div class="productPic131">
                                <p class="Dealer1">
                                    <strong><a href="<%=string.Format(EnUrls.ShopInfoIndex,p.ProductShopInfo.id) %>"
                                        target="_blank">
                                        <%=p.ProductShopInfo.title%></a></strong><a href="<%=string.Format(EnUrls.ShopInfoIndex,p.ProductShopInfo.id) %>"
                                            target="_blank">&nbsp;</a></p>
                                <p class="address">
                                    <%=p.ProductShopInfo.address%></p>
                                <p class="phone">
                                    <%=p.ProductShopInfo.phone%></p>
                                <p class="productPicdh">
                                    电话咨询价格，请说来自福家网</p>
                            </div>
                            <div class="productPic132">
                            <p>优惠信息：</p>
                            <p><a href="#" style="color:#2953a6; text-decoration:underline;">德尔地板跌爆眼球的抄底团购全场 6.4折起 12.03</a></p>
                          </div>
                        </div>--%>
                        <div class="productPic13">
                          <div class="productPic131">
                          <p class="Dealer1">
                             <span>[店铺]</span> <strong><a href="<%=string.Format(EnUrls.ShopInfoIndex, p.ProductShopInfo.id)%>" target="_blank"><%=p.ProductShopInfo.title%></a></strong>
                          </p>
    	                  <p class="phone">
                            <%if ((p.ProductShopInfoNew.price != "0.00" && p.ProductShopInfoNew.price != "0") || (p.ProductShopInfoNew.dollprice != "0" && p.ProductShopInfoNew.dollprice != "0.00"))
                            { %>
                              <%if (p.ProductShopInfoNew.dollprice != "0" && p.ProductShopInfoNew.dollprice != "0.00")
                                {
                                    if (!string.IsNullOrEmpty(p.ProductShopInfoNew.dollprice))
                                    {
                                    %>
                                      <div style="border:1px #ccc solid;border-radius:3px; width:185px;height:25px;line-height:25px;color:#FF0000; font-size:14px; margin:5px 0;">
			                             <span style="font-size:13px; color:#666; font-weight:700;padding-left:8px;float:left;">促销报价：</span>
			                             <span style="font-size:1.9em;line-height:22px; padding-right:3px; font-weight:700;"><%=p.ProductShopInfoNew.dollprice.Split('.')[0]%></span>元
			                         </div>
                              <%}
                                }
                                else
                                { %>
                                     <div style="border:1px #ccc solid;border-radius:3px; width:185px;height:25px;line-height:25px;color:#FF0000; font-size:14px; margin:5px 0;">
			                             <span style="font-size:13px; color:#666; font-weight:700;padding-left:8px;float:left;">本店报价：</span>
			                             <span style="font-size:1.9em;line-height:22px; padding-right:3px; font-weight:700;"><%=p.ProductShopInfoNew.price.Split('.')[0]%></span>元
			                         </div>
                              <%} %>
                          <%} %>
                          </p>
                          <p class="address"><%=p.ProductShopInfo.address%></p>
                          </div>
                          <div class="productPic132 Dealer1">
                          
                            <%if (promotionslist.Where(c => c.promotionsrelated.Where(f => f.shopid.ToString() == p.ProductShopInfo.id).Any()).Count() > 0)
                              { %>
                              <%foreach (var pitem in promotionslist.Where(c => c.promotionsrelated.Where(f => f.shopid.ToString() == p.ProductShopInfo.id).Any()))
                                { %>
                            <span>[优惠]</span>
                            <p><a href="<%=string.Format(EnUrls.MarketInfoPromotionsInfo, ECommon.QueryMid, pitem.id, "") %>"><%=pitem.title %></a></p>
                            <%break;
                                } %>
                            <%}
                              else
                              { %>
                              <span>[优惠]</span><p>欢迎来电咨询促销优惠信息
                            <%} %>
                          </div>
                          <div class="productView">
                             <div class="br-gcs hd">
                                <ul>
                                     <li><a class="btn" href="#" onclick="window.open('<%=string.Format(EnUrls.ShopInfoProduct, p.ProductShopInfo.id) %>');" target="_blank">所有产品</a></li>
                                     <li><a class="btn" href="#" onclick="window.open('<%=string.Format(EnUrls.CompanyInfoBrandList,p.companyid,p.brandid)%>');" target="_blank">品牌介绍</a></li>
                                     <li><a class="btn" href="#" onclick="window.open('<%=string.Format(EnUrls.CompanyInfoAddress,p.companyid) %>');" target="_blank">所有店铺</a></li>
                                 </ul>
                               </div>
                          </div>
                        </div>
                        <%}
                          else
                          { 
                        %>
                        <div class="productPic13 productPic133">
                            <p class="tip">对不起，本品牌暂无店铺信息</p>
                         </div> 
                        <% } %>
                    </div>
                    <div class="productView">
                        <div class="br-gcs hd">
                            <ul>
                                <li><a class="btn" href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.CompanyInfoIndex,p.companyid) %>');"
                                    target="_parent">厂家介绍</a></li>
                                <li><a class="btn" href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.CompanyInfoBrandList,p.companyid,p.brandid) %>');"
                                    target="_parent">品牌介绍</a></li>
                                <li><a class="btn" href="javascript:;" onclick="javascript:window.open('<%=string.Format(EnUrls.CompanyInfoAddress,p.companyid) %>');"
                                    target="_parent">推荐店铺</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <%} %>
                <%}
                  else
                  { %>
                  <div class="productPic productPic1"><div class="productPic1"><img alt="notfound" src="/resource/web/images/notfound.gif" /></div></div>
                <%} %>
                </div>
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="false" CurrentPageButtonClass="cpb"
                    CssClass="pager" UrlPaging="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                    PrevPageText="上一页" ShowPageIndexBox="Never" PageSize="20">
                </webdiyer:AspNetPager>
            </div>
            <div class="pro-l" style="float:right;">
                <h3 style="margin-top:6px;">产品分类</h3>
                <div id="con_one_1" class="f1">
                    <%=ECProduct.GetMarketCategoryHtmlToNav(marketInfo.id.ToString()) %>
                    <script type="text/javascript">
                        $(function () {
                            $(".productList22>.productList221").hover(function () {
                                $(this).addClass("productList221_hover");
                            }, function () {
                                $(this).removeClass("productList221_hover");
                            });
                        });
                    </script>
                </div>
                <%--<div style="margin-top: 8px;" class="promotionsR1">
                    <div class="promotions">
                        <span><a href="#">更多</a></span>促销信息</div>
                    <div class="prAd1">
                        <a href="#">
                            <img src="images/index_52.jpg"></a><a href="#"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/index_55.jpg"></a><a
                                href="#"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/index_58.jpg"></a></div>
                    <%=ECPromotion.GetPromotionHtml(ECPromotion.GetWebTopPromotionListToMarket(4,marketInfo.id)) %>
                </div>--%>
            </div>
        </div>
    </div>
    <uc4:_foot ID="_foot1" runat="server" />
</body>
</html>
