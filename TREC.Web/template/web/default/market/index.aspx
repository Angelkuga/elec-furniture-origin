<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.market.index" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Linq" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<%@ Register Src="../ascx/headerMarket.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_marketkeys.ascx" TagName="_marketkeys" TagPrefix="uc6" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
 
     <uc6:_marketkeys ID="_marketkeys1" Title="" runat="server" />
   
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  
    <ucnewresource:newresource ID="newresource1" runat="server" />
    <link href="/resource/content/css/core.css" rel="stylesheet" />
    <link href="/resource/content/css/mall/mall.css" rel="stylesheet" />
    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/mall/mall.js"></script>
    <style>
        .clearfix li:hover .d2
        {
            display: block;
        }
        .d2
        {
            display: none;
        } 
       .cgul
       {
           font-size:14px;
           color:#333333;
           text-align:center;
           background-color:White;
           height:auto;
           width:1200px;
       } 
        .cgul li
       {
           width:220px;
           height:170px;
           float:left;
           margin-right:15px;

       } 
       .cgul li img
       {
           width:100%;
           height:135px;
          }
    </style>
</head>
<body>
    <uc1:header ID="header1" runat="server" />
    <div class="site">
        <a href="/">家具快搜</a> &gt; <a href="/marketlist.aspx">卖场</a> &gt; 卖场首页</div>
    <div class="main-hd" style="height:auto;">
        <div class="focus w">
            <%if (!String.IsNullOrEmpty(MarketPageBase.marketInfo.thumb))
              { %>
            <img src="<%=EnFilePath.GetMarketThumbPath(MarketPageBase.marketInfo.id.ToString(),MarketPageBase.marketInfo.thumb)%>"
                width="1200" height="486" />
            <%}
              else
              { %>
            <img src="/resource/images/ppfbbg.jpg" style="border: 1px solid #CCCCCC;" width="1200"
                height="486" />
            <%} %>
        </div>
        <!---楼层 begin----->
        <div class="floor-tab w" id="j_floorTab" style="<%=lcdisplay%>">
            <div class="hd b">
                <ul class="clearfix">
                    <%
                        int j = -1;
                        string display = "";
                        for (int i = 0; i < marketInfo.MarketStoreyList.Count; i++)
                      {
                          if (marketInfo.MarketShopList.Where(c => c.marketstorey == marketInfo.MarketStoreyList[i].title).ToList().Count > 0)
                          {
                              if (j == -1) { j = i; }
                              display = "";
                          }
                          else
                          {
                              display = "display:none;"; 
                          }
                                
                          %>
                    <li id="two<%=i+1 %>" class="<%=(i==j?"on":"") %>" style="position: relative;<%=display%>"><a>
                        <%=marketInfo.MarketStoreyList[i].title%></a></li>
                    <%
                      } %>
                </ul>
            </div>
            <div class="bd">
                <% 
                    for (int i = 0; i < marketInfo.MarketStoreyList.Count; i++)
                    {%>
                <div class="item <%=(i== j?"":"hide") %>" id="con_two_<%=i+1 %>">
                    <ul class="clearfix">
                        <% 
                            foreach (EnWebMarket.MarketShop shopinfo in marketInfo.MarketShopList.Where(c => c.marketstorey == marketInfo.MarketStoreyList[i].title))
                            {
                                if (string.IsNullOrEmpty(shopinfo.brandid)) continue;%>
                        <li><a href="<%=string.Format(EnUrls.ShopInfoIndex, shopinfo.id)%>" target="_blank">
                            <p class="p1 b f14">
                                <%=shopinfo.brandtitle%></p>
                            <p class="p2">
                                <%=shopinfo.position %></p>
                        </a>
                            <div class="drop">
                                <i></i>
                                <div class="d1 tc">
                                    <a href="<%=string.Format(EnUrls.ShopInfoIndex, shopinfo.id)%>">
                                        <img src="<%=EnFilePath.GetBrandLogoPath(shopinfo.brandid,shopinfo.brandlogo) %>"
                                            alt="" />
                                    </a>
                                </div>
                                <div class="d2 b">
                                    <a href="<%=string.Format(EnUrls.ShopInfoIndex, shopinfo.id)%>">
                                        <%=shopinfo.brandstylename %>
                                        \
                                        <%= shopinfo.brandmaterial%>
                                        \
                                        <%=shopinfo.position %></a></div>
                                <div class="d3 f666">
                                    <%=TRECommon.StringOperation.CutString(TREC.ECommerce.SubmitMeth.DisposeHtml(shopinfo.branddescript),0,100) %></div>
                                <div class="d4 tc">
                                    <img src="<%=EnFilePath.GetBrandThumbPath(shopinfo.brandid,shopinfo.brandthumb) %>"
                                        width="200" height="155" alt="" class="vm" />
                                </div>
                            </div>
                        </li>
                        <%} %>
                    </ul>
                </div>
                <%} %>
            </div>
        </div>
        <!---楼层 end-->

        <!--场馆 begin-->
          <div class="floor-tab w" style="height:auto;<%=cgdisplay%>">
          <table border="0" cellpadding="0" cellspacing="0"><tr><td style="width:1200px;height:auto;">
          <ul class="cgul">
              <asp:Repeater ID="Repeater_cg" runat="server">
              <ItemTemplate>
               <li>
         <a href="/market/PavilionIndex.aspx?mid=<%=marketInfo.id %>&paid=<%#Eval("Id") %>" target="_blank"><img src="<%#Eval("thumb") %>"  /></a><br />
          <a hef="/market/PavilionIndex.aspx?mid=<%=marketInfo.id %>&paid=<%#Eval("Id") %>" target="_blank"><%#Eval("Title") %></a>
          </li>
              </ItemTemplate>
              </asp:Repeater>
          </ul>
      </td> </tr> </table>


  

          </div>
        <!--场馆 end-->
    </div>
    <div class="main-bd w">
        <div class="hd clearfix">
            <h2 class="b f14">
                所有品牌</h2>
            <div class="fake-drop">
                <div class="inp">
                    所有材质</div>
                <ul>
                    <li><a href="<%=string.Format("/market/{0}/brand-{1}-{2}-{3}-{4}-{5}-{6}.aspx", ECommon.QueryMid, ECommon.QuerySearchMarketStorey, ECommon.QuerySearchSort, ECommon.QueryPageIndex, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, "") %>">
                        所有材质</a></li>
                    <%foreach (var s in ECConfig.GetConfigList(" module=103 and type=4"))
                      { %>
                    <li><a title="<%=s.title %>" href="<%=string.Format("/market/{0}/brand-{1}-{2}-{3}-{4}-{5}-{6}.aspx", ECommon.QueryMid, ECommon.QuerySearchMarketStorey, ECommon.QuerySearchSort, ECommon.QueryPageIndex, ECommon.QuerySearchBrand, ECommon.QuerySearchStyle, s.value) %>">
                        <%=s.title.Length > 5 ? s.title.Substring(0,5) + "..." : s.title %></a></li>
                    <%} %>
                </ul>
            </div>
            <div class="fake-drop">
                <div class="inp">
                    所有风格</div>
                <ul>
                    <li><a href="<%=string.Format("/market/{0}/brand-{1}-{2}-{3}-{4}-{5}-{6}.aspx", ECommon.QueryMid, ECommon.QuerySearchMarketStorey, ECommon.QuerySearchSort, ECommon.QueryPageIndex, ECommon.QuerySearchBrand,"", ECommon.QuerySearchMaterial) %>">
                        所有风格</a></li>
                    <%foreach (var s in ECConfig.GetConfigList(" module=103 and type=3"))
                      { %>
                    <li><a title="<%=s.title %>" href="<%=string.Format("/market/{0}/brand-{1}-{2}-{3}-{4}-{5}-{6}.aspx", ECommon.QueryMid, ECommon.QuerySearchMarketStorey, ECommon.QuerySearchSort, ECommon.QueryPageIndex, ECommon.QuerySearchBrand,s.value, ECommon.QuerySearchMaterial) %>">
                        <%=s.title%></a></li>
                    <%} %>
                </ul>
            </div>
        </div>
        <div class="bd clearfix">
            <div class="cont-l fl">
                <div class="item">
                    <ul class="clearfix">
                    <%if(elist.Count==0){ %>
                    &nbsp;
                    <% }%>
                        <%foreach (EnWebMarketStoreyShop s in elist)
                          {
                              if (string.IsNullOrEmpty(s.shoptitle)) continue;
                        %>
                        <li><a target="_blank" title="<%=s.shoptitle %>" href="/company/<%=s.BrandInfo.companyid %>/index.aspx"
                            class="block tc mb10">
                            <img alt="<%=s.shoptitle %>" src="<%=EnFilePath.GetBrandLogoPath(s.BrandInfo.id, s.BrandInfo.logo) %>"
                                style='width: 209px; height: 46px;' /></a> <a href="/company/<%=s.BrandInfo.companyid %>/index.aspx"
                                    target="_blank">
                                    <img alt="" width="209" height="155" class="block img" src="<%=EnFilePath.GetBrandThumbPath(s.BrandInfo.id,s.BrandInfo.thumb) %>" />
                                </a>
                            <div class="li-t clearfix">
                                <div class="li-t-l">
                                    <a class="yahei f18" href="#">
                                        <%if (s.BrandName.Replace(",", " ").Length > 0) { Response.Write(s.BrandName.Replace(",", " ")); } else { Response.Write("&nbsp;"); } %></a>
                                    <p class="clearfix f12">
                                        <span class="fl">风格：<%= s.BrandInfo.brands==null?"":s.BrandInfo.brands.Length > 0 ? ECommon.GetConfigName(((int)EnumConfigModule.产品配置).ToString(), "3", (ECBrand.GetBrandsInfo("where brandid=" + s.BrandInfo.id) ?? new EnBrands()).style, ',', " ") : ""%></span>
                                        <span class="fr">楼层：<%=s.storeytitle%></span>
                                    </p>
                                </div>
                            </div>
                            <div class="li-ext">
                                <div class="d1">
                                    <%if (epromotionslist.Where(c => c.promotionsrelated.Any(p => p.shopid == s.shopid) && c.IsTop == true).Count() > 0)
                                      {  %>
                                    <%foreach (var pitem in epromotionslist.Where(c => c.promotionsrelated.Any(p => p.shopid == s.shopid)).OrderByDescending(c => c.enddatetime))
                                      {%>
                                    <b class="red">[促销]</b> <a href="<%=string.Format(EnUrls.PromotionsInfo, pitem.id) %>"
                                        target="_blank">
                                        <%=  TRECommon.StringOperation.CutString(pitem.title, 0, 16) %></a>
                                    <% break;
                                      }
                                      }
                                      else
                                      { %>
                                    <b class="red">[促销]</b> 欢迎来电电咨询优惠资讯！
                                    <%} %>
                                </div>
                                <div class="d2">
                                    <table border='0'>
                                        <tr>
                                            <td>
                                                <a href="<%=string.Format(EnUrls.ShopInfoProduct, s.shopid) %>" target="_blank">所有产品</a>&nbsp;
                                            </td>
                                            <td>
                                                <a href="<%=string.Format(EnUrls.ShopInfoAddress, s.shopid) %>" target="_blank">联系方式</a>&nbsp;
                                            </td>
                                            <td>
                                                <a href="<%=string.Format(EnUrls.CompanyInfoBrandList, s.BrandInfo.companyid, s.BrandInfo.id) %>"
                                                    target="_blank">品牌介绍</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </li>
                        <%} %>
                    </ul>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="false" CurrentPageButtonClass="cpb"
                        CssClass="digg" UrlPaging="true" NextPageText="&gt;" PrevPageText="&lt;" PageSize="100">
                    </webdiyer:AspNetPager>
                </div>
            </div>
            <table>
                <tr>
                    <td>
                      
                            <div class="cont-r fr">
                                <!-- 品牌查询 start-->
                                <div class="layout_a brand-bar" id="j_brandBar">
                                    <div class="tit">
                                        品牌查询</div>
                                    <div class="brand-search">
                                        <form method="get" action="/search.aspx">
                                        <input type="hidden" name="type" value="marketshop" title="onlymarketshop" id="onlymarketshop" />
                                        <input type="hidden" name="mid" value="<%=ECommon.QueryMid %>" />
                                        <input style="width: 5px; margin: 0; padding: 0; background: none; border: 0;" />
                                        <input type="text" name="key" class="txt" id="marketSearchkey" />
                                        <input type="image" src="<%=ECommon.WebResourceUrlToWeb %>/images/marketSearch.gif"
                                            onmousemove="this.src='<%=ECommon.WebResourceUrlToWeb %>/images/marketSearchhover.gif'"
                                            onmouseout="this.src='<%=ECommon.WebResourceUrlToWeb %>/images/marketSearch.gif'" />
                                        <script type="text/javascript">
                                            //                                $(function () {
                                            //                                    $('#marketSearchkey').oms_autocomplate({ url: "/ajax/search.ashx<%=Request.Url.Query %>", paramTypeSelector: "#onlymarketshop" });
                                            //                                });
                                        </script>
                                        </form>
                                    </div>
                                    <div class="clearfix alpha-list">
                                        <ul id="j_letterAlpha" class="clearfix">
                                            <%for (var i = 65; i < 91; i++)
                                              {
                                                  Response.Write(msslist.Any(c => c.BrandInfo.letter != null && c.BrandInfo.letter != "" && c.BrandInfo.letter.Substring(0, 1).Equals(((char)i).ToString(), StringComparison.OrdinalIgnoreCase))
                                                      ?
                                                      ("<li ><a href=\"#" + ((char)i) + "\">" + ((char)i) + "</a></li>")
                                                      :
                                                      ("<li class=\"none\">" + ((char)i) + "</li>"));
                                              }%>
                                        </ul>
                                    </div>
                                    <div style="height: 300px;" class="brand-alpha-list" id="j_letterTree">
                                        <ul>
                                            <% foreach (var g in msslist.Where(c => c.BrandInfo.letter != null && c.BrandInfo.letter.Length > 0).GroupBy(c => c.BrandInfo.letter[0].ToString().ToUpper()).OrderBy(c => c.Key))
                                               { %>
                                            <li id="letter1" class="root"><b>
                                                <%=g.Key%>
                                                <s>(<%=g.Count()%>)</s><a href="#" name="<%=g.Key%>"></a></b>
                                                <ul>
                                                    <% foreach (var p in g)
                                                       { %>
                                                    <li><a href="<%=string.Format(EnUrls.ShopInfoIndex, p.shopid) %>" target="_blank"><big>
                                                        <%=p.BrandInfo.title %></big><%if (p.shopareacode != null && p.shopareacode.Length > 0)
                                                                                       { %>
                                                        <div class="auto_BDBDBD auto_item_right" style="width: 45px; top: 7px;">
                                                            <%=p.storeytitle %></div>
                                                        <%} %></a></li>
                                                    <% }%>
                                                </ul>
                                            </li>
                                            <% }%>
                                        </ul>
                                    </div>
                                </div>
                                <!-- 品牌查询 end-->
                            </div>
                    
                        <div class="cont-r fr" style="display:none;">
                            <!-- 推荐店铺 start-->
                            <div class="cont-r fr" style='margin-top: 5px;'>
                                <div class="layout_a brand-bar" id="Div1">
                                    <div class="tit">
                                        店铺推荐</div>
                                    <%--<%=tuijian %>--%>
                                    <div style='padding: 15px;'>
                                        <%=tuijian %>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- 推荐店铺 end-->
        </div>
      
            <!-- 优质商家 start-->
            <div class="cont-r fr" style='margin-top: 5px;'>
                <div class="layout_a brand-bar" id="Div2">
                    <div class="tit">
                        优质商家</div>
                    <%=shangjia %>
                </div>
            </div>
            <!-- 优质商家 end-->
      
     
            <!-- 广告 start-->
             <%if (!string.IsNullOrEmpty(adv))
              { %>
            <div class="cont-r fr" style='margin-top: 5px;'>
                <%=adv %>
            </div>
    <% }%>
        <!-- 广告 end-->
        </td> </tr> </table>
    </div>
   
    <ucfooter:footer ID="header3" runat="server" />
</body>
</html>
