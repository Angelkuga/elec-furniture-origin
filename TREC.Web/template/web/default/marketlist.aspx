<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.marketlist" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="Haojibiz.Data" %>
<%@ Import Namespace="Haojibiz.DAL" %>
<%@ Import Namespace="Haojibiz.Model" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!doctype html>
<html>
<head>
<title>【家具卖场】家具卖场十大品牌,家具价格,家具品牌,家具卖场团购 - 家具快搜</title>
<meta name="keywords" content="家具卖场十大品牌,家具价格,家具品牌,家具卖场团购" />
<meta name="description" content="家具快搜网的卖场频道，传递家具卖场十大品牌分布情况，家具卖场团购促销活动等信息，健康家居,定制家具,高档家具,古典家具,新古典家具,儿童家具,家具品牌,家具品牌排名等均来家具快搜网。"/>
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <link href="/resource/content/css/css.css" rel="stylesheet" type="text/css">
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css">
    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/index/index.js" type="text/javascript"></script>
    <style>
        .quyu
        {
            cursor: pointer;
        }
        .quyu ul
        {
            display: none;
        }
        .quyu:hover ul
        {
            display: block;
            position: absolute;
            background: #f5f5f5;
            border-top: none;
            overflow: hidden;
            border: 1px solid #d8d8d8;
            width: 89px;
        }
        .quyu ul li
        {
            height: 22px;
            padding-left: 16px;
            line-height: 22px;
            background: #fff;
            color: #af051c;
            text-decoration: none;
        }
        .site {
    background: url("/resource/web/css/zd.gif") no-repeat scroll 2px 12px rgba(0, 0, 0, 0);
    color: #9d9d9d;
    height: 40px;
    line-height: 40px;
    margin: 0 auto;
    padding-left: 25px;
    width: 1175px;
}
.tipmessage{position:absolute;color:#d52249;height:31px;line-height:31px;display:none;width:286px;text-align:center;background:url(/resource/web/images/viptipbg.gif) no-repeat;z-index:100;}
    </style>
    
</head>
<body>
    <uc1:header ID="header1" runat="server" />
  <div class="site"><a href="/">家具快搜</a> >卖场</div>
    <div class="main clearfix" style="margin-top:0px;">
        <div class="mainz">
            <div class="mainz1" >
                <dl>
                    <strong>目前搜索到 <span>
                        <%=AspNetPager1.RecordCount %></span> 个相关卖场 </strong>
                </dl>
                <%if (ECMarket.GetSearchItem().FindAll(x => x.isCur == true).Count > 0)
                  { %>
                <dl>
                    <dt>您的搜索：</dt>
                    <dd>
                        <%foreach (EnSearchItem i in ECMarket.GetSearchItem().FindAll(x => x.isCur == true))
                          { %>
                        <a href="<%=string.Format(EnUrls.MarketListSearch, ECommon.QuerySearchBrand.Replace("_" + i.value, ""), ECommon.QuerySearchStyle.Replace("_" + i.value, ""), ECommon.QuerySearchMaterial.Replace("_" + i.value, ""), ECommon.QuerySearchSpread.Replace("_" + i.value, ""), ECommon.QuerySearchStaffsize.Replace("_" + i.value, ""), ECommon.QuerySearchSort.Replace("_" + i.value, ""), ECommon.QuerySearchComposing, ECommon.QuerySearchKey, ECommon.QueryPageIndex,ECommon.QuerySearchArea.Replace("_" + i.value, ""))%>">
                            <%=i.title%>
                            ×</a>
                        <%} %>
                    </dd>
                </dl>
                <%} %>
                <dl >
                    <dt >区域： </dt>
                    <dd >
                        <%foreach (EnSearchItem i in ECMarket.GetSearchItem().FindAll(x => x.type == "area" && x.value.StartsWith("3101") && x.isCur == false))
                          { %>
                        <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,ECommon.QuerySearchKey,1,"_"+i.value) %>">
                            <%=i.title %></a>
                        <%} %>
                    </dd>
                </dl>
                <dl style="max-height:180px;height:auto;mix-height:50px;">
                <table border="1" style="">
                            <tbody><tr>
                                <td style="vertical-align: top; padding-top: 10px; width: 50px; text-align: right">
                                    卖场：
                                </td>
                                <td>
                                    <div style="float: right;" class="listy2">
                                        <dl style="border: 0px solid #e7e3e7;">
                                            <dd id="dd1">
                                                <div class="pplm">
                                                    <ul id="tabs" class="tabs">
                                                        <li class="thistab"><a id="ddmcall" style="padding: 0 8px;" class="hove"  href="#" onmouseover="selectletter('0')">不限</a></li>
                                                            <%=marketlet%>
                                                             </ul>
                                                    <ul style="width:788px" id="tab_conbox" class="tab_conbox">
                                                        <li class="tab_con" style="display: list-item;">
                                                        <table border="0" valign="top" style="text-align:top"><tbody><tr>
                                                        <td>
                                                        <div style="display:none;" id="divletterList">
                                                        <%=markethide%>
                                                        </div>
                                                        <div style="width:778px; height:100px; overflow-y: auto; overflow-x:hidden;  border:0px solid #000000;" id="divmarketlist">
                                                        <%=market%>
                                                        </div>
                                                         </td>
                                                        
                                                        <td valign="top" style="text-align:center;display:none;" >&nbsp;&nbsp;<label onclick="javascript:if($(this).html()==&quot;展开&quot;){$(&quot;#divmarket&quot;).show();$(this).html(&quot;收起&quot;);}else{$(this).html(&quot;展开&quot;);$(&quot;#divmarket&quot;).hide();};" style="color:#f89a05">收起</label></td>
                                                        </tr></tbody></table>
                                                        </li>
                                                      
                                                    </ul>
                                                </div>
                                            </dd>
                                        </dl>
                                    </div>
                                </td>
                            </tr>
                        </tbody></table>

                    <dt style="display:none;">卖场： </dt>
                    <dd style="display:none;">
                        <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"金盛",1,ECommon.QuerySearchArea) %>">
                            金盛</a> <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"莘潮",1,ECommon.QuerySearchArea) %>">
                                莘潮</a> <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"欧亚美",1,ECommon.QuerySearchArea) %>">
                                    欧亚美</a> <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"东明",1,ECommon.QuerySearchArea) %>">
                                        东明</a> <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"九星",1,ECommon.QuerySearchArea) %>">
                                            九星</a> <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"红星美凯龙",1,ECommon.QuerySearchArea) %>">
                                                红星美凯龙</a> <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"金海马",1,ECommon.QuerySearchArea) %>">
                                                    金海马</a> <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"好美家",1,ECommon.QuerySearchArea) %>">
                                                        好美家</a> <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"沪杭",1,ECommon.QuerySearchArea) %>">
                                                            沪杭</a> <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"春申江",1,ECommon.QuerySearchArea) %>">
                                                                春申江</a> <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"吉盛伟邦",1,ECommon.QuerySearchArea) %>">
                                                                    吉盛伟邦</a> <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"好百年",1,ECommon.QuerySearchArea) %>">
                                                                        好百年</a> <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"盛源大地",1,ECommon.QuerySearchArea) %>">
                                                                            盛源大地</a> <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"剪刀石头布",1,ECommon.QuerySearchArea) %>">
                                                                                剪刀石头布</a> <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"月星",1,ECommon.QuerySearchArea) %>">
                                                                                    月星</a> <a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,"建配龙",1,ECommon.QuerySearchArea) %>">
                                                                                        建配龙</a>
                    </dd>
                </dl>
            </div>
            <%--<div class="mainz2 clearfix">
                <h3>
                    按卖场显示</h3>
            </div>--%>
            <div class="mainz3 clearfix">
                <div class="flei">
                    快速分类</div>
                <div class="quyu">
                    所有区域
                    <ul>
                        <%foreach (EnSearchItem i in ECMarket.GetSearchItem().FindAll(x => x.type == "area" && x.value.StartsWith("3101") && x.isCur == false))
                          { %>
                        <li><a href="<%=string.Format(EnUrls.MarketListSearch,ECommon.QuerySearchBrand,ECommon.QuerySearchStyle,ECommon.QuerySearchMaterial,ECommon.QuerySearchSpread,ECommon.QuerySearchStaffsize,ECommon.QuerySearchSort,ECommon.QuerySearchComposing,ECommon.QuerySearchKey,ECommon.QueryPageIndex,"_"+i.value) %>">
                            <%=i.title %></a></li>
                        <%} %>
                    </ul>
                </div>
                <div class="quyu">
                    推荐卖场
                    <ul>
                        <%foreach (EnMarket i in ECMarket.GetMarketList("auditstatus=1"))
                          { %>
                        <li><a target="_blank" href="<%=string.Format(EnUrls.MarketInfoIndex, i.id) %>">
                            <%=i.title.Length > 5 ? i.title.Substring(0, 5) + "..." : i.title %></a></li>
                        <%} %>
                    </ul>
                </div>
            </div>
            <div class="mainz4 clearfix">

                <%
                    int yfd = 0;
                    int mcount = 0;
                    string address;
                    foreach (EnWebMarket m in list)
                    {
                        EnMarketClique mc = GetMarketClique(m.id);
                        mcount++; %>
                <% if (mcount % 2 == 0)
                   {%>
                <dl class="yfd">
                    <% }
                   else
                   { %>
                    <dl>
                        <%} %>
                        <dt <%if( yfd!=0) {%>class="yfd" <%} %>>
                            <img src="<%=EnFilePath.GetMarketSurfacePath(m.id.ToString(), m.surface)%>" width="134"
                                height="189" />
                        </dt>
                        <dd class="scmc">
                            <%if (mc != null)
                              {%>
                            <a href="<%=string.Format(EnUrls.MarketClique,m.id) %>" target="_blank">
                                <%}
                              else
                              { %>
                                <a href="<%=string.Format(EnUrls.MarketInfoIndex,m.id) %>" target="_blank">
                                    <%} %>
                                    <img alt="<%=m.title %>" src="<%=EnFilePath.GetMarketLogoPath(m.id.ToString(),m.logo)%>"
                                        width="101" height="36" /></a><br>
                                <%=TRECommon.StringOperation.CutString(m.title,0,16)%><img src="/resource/content/images/bz.jpg"
                                    width="14" height="13" /></dd>
                        <dd class="scgm">
                            所属集团：<%=m.MarketCliqueName %>
                            <br />
                            卖场规模：<%=m.cbm %>
                            平方米
                            <br />
                            <%address = ECommon.GetAreaName(m.areacode) + m.address;%>
                            卖场地址：<a href="<%=string.Format(EnUrls.MarketInfoAddress, m.id) %>" target="_blank"><%=TRECommon.StringOperation.CutString(address, 0, 18)%></a>
                            <br>
                            <%
System.Data.DataSet epm = Haojibiz.Data.SqlHelper.ExecuteDataSet(System.Data.CommandType.Text, "SELECT id,title FROM t_promotions where istop =1 and mid in (select mid from t_market where id=" + m.id + ")", null);
if (epm.Tables[0].Rows.Count > 0)
{ %>
                            <img src="/resource/content/images/gwc.jpg" width="17" height="13" />[促销] <a href="/market/<%=m.id %>/promotions/<%=epm.Tables[0].Rows[0]["id"]%>/info-brand.aspx"
                                target="_blank">
                                <%=TRECommon.StringOperation.CutString(epm.Tables[0].Rows[0]["title"].ToString(),0,16)%></a>
                            <%}
else
{ %>
                            <img src="/resource/content/images/gwc.jpg" width="17" height="13" />[促销] 欢迎来电咨询促销信息
                            <%} %>
                            <a href="/market/<%=m.id %>/promotions/list/-market--.aspx" target="_blank">更多</a>
                        </dd>
                    </dl>
                    <%}%>


                    <!--------集团 begin------------>
      <%=MarketCliqueShow %>
      
                    <!--------集团 begin--------->
            </div>
            <div class="digg">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="false" CurrentPageButtonClass="disabled"
                    CssClass="ks-pager" UrlPaging="true" NextPageText="&gt;" PrevPageText="&lt;"
                    PageSize="20">
                </webdiyer:AspNetPager>
            </div>
        </div>
        <table>
            <tr>
                <td>
                    <!-- 卖场查询工具 start -->
                    
                    <!-- 卖场查询工具 end   -->
                    <div class="mainy" >
                        <h3>
                            推荐卖场</h3>
                        <div style='padding: 15px;'>
                            <%
                                int count = 0;
                                foreach (t_advertising tad in list_right)
                                {
                                    
                            %>
                            <a target="_blank" href="<%=tad.linkurl %>">
                                <img style='width: 196px; height: 70px;' src='<%=tad.imgurl.Replace(",","") %>' /></a>&nbsp;&nbsp;
                            <%}%>
                        </div>
                    </div>
                    <div class="mainy" style='margin-top: 5px;display:none;'>
                        <h3>
                            优质商家</h3>
                        <%-- <%=shangjia %>--%>
                        <%--<ul class="clearfix" style="">
                <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/product/21155/info.aspx">
                    <img src='http://www.jiajuks.com/upload//product/thumb/21155/20130531110052483268_230-173.jpg'
                        style='width: 223px; height: 165px;' /><br />
                    <p style=" padding:0 6px">
                        北欧E家 床 HA-516双人床 实木</p>
                    <p style=" padding:0 6px">
                        参考价：¥9800.00</p>
                </a>
            </ul>
            <table style="text-align: center; ">
                <tr>
                    <td valign="top" style="vertical-align:top; padding-left:6px;">
                        <a href='<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/company/210/brand-414.aspx'
                            target="_blank">
                            <img src='http://www.jiajuks.com/upload//brand/logo/414/20150121162613926433.png'
                                style="height: 32px; width: 84px" />
                        </a>
                    </td>
                    <td valign="top" align="left" style=" padding-right6px;">
                        <a href='<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/')%>/company/210/brand-414.aspx'
                            target="_blank">
                            <label>
                                北欧E家专业生产实木家具，旗下十种名贵木材、十大经典系列，设计秉承北欧简约风格......</label>
                        </a>
                    </td>
                </tr>
            </table>--%>
                    </div>
                    <div class="mainy" style='margin-top: 5px;display:none;'>
                        <%=adv %>
                    </div>
                </td>
            </tr>
        </table >
    </div>

    
    <ucfooter:footer ID="header2" runat="server" />

    <div class="tipmessage" id="diverrorshow">抱歉，该卖场权限不够，信息暂无法开放！</div>


    <script>

        function messagedshow(e) {
     
            $("#diverrorshow").show();
            var pointX = e.pageX;
            var pointY = e.pageY;
            $("#diverrorshow")[0].style.top = pointY + 'px';
            $("#diverrorshow")[0].style.left = pointX + 'px';
            setTimeout("messagedhide()", 3000) 
        }

        function messagedhide() {
            $("#diverrorshow").hide(500);
        }
        $(function () {
            //$('#j_navTab').hide();
        });


        function selectletter(le) {
            var list = '';
            $("#divletterList li").each(
            function (i) {
                if (le == '0') {//不限
                    list = list + $(this).html();
                }
                else {
                    if ($(this).attr("letter") == le) {
                        list = list + $(this).html();
                    }
                }
            }
            );
            $("#divmarketlist").html(list);
        }

        $("#tabs a").hover(function () {
            $("#tabs a").removeClass("hove");
            $(this).addClass("hove");
        },function () {
            $(this).addClass("");
        });
    </script>

    <script language="javascript" type="text/javascript">
        //下一个
        function funnext(pageindex, funcount, divid) {
            var id = $("#" + pageindex).val();
            var n = 0;
            if (parseInt(id) < parseInt($("#" + funcount).val())) {
                var n = parseInt(id) + 1;
            }
            else {
                n = 1;
            }
            $("#" + pageindex).val(n);
            funloop(divid, id, n, funcount);
            $("#" + divid + id).animate({ left: '+435px' }, "slow");

        }
        //上一个
        function funnpra(pageindex, funcount, divid) {
            var id = $("#" + pageindex).val();
            var n = 0;
            if (parseInt(id) > 1) {
                n = parseInt(id) - 1;
            }
            else {
                n = parseInt($("#" + funcount).val());
            }
            $("#" + pageindex).val(n);
            funloop(divid, id, n, funcount);
            $("#" + divid + id).animate({ right: '+435px' }, "slow");

        }


        function funloop(divid, id, nextid, funcount) {
            $("#" + divid + id).attr("style", "position:absolute;z-index:300;");
            $("#" + divid + nextid).attr("style", "position:absolute;z-index:200;");

            for (var i = 1; i <= parseInt($("#" + funcount).val()); i++) {
                if (i != parseInt(id) && i != parseInt(nextid)) {
                    $("#" + divid + i).attr("style", "position:absolute;z-index:0;");
                }
            }
        }
        
    </script>
</body>
</html>
