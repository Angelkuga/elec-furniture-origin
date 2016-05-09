<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="merchantslist.aspx.cs"
    Inherits="TREC.Web.aspx.merchantslist" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="Haojibiz.Model" %>
<%@ Import Namespace="Haojibiz.Data" %>
<%@ Import Namespace="Haojibiz.DAL" %>
<%@ Register Src="ascx/_resource.ascx" TagName="Resource" TagPrefix="my" %>
<%@ Register Src="ascx/_head.ascx" TagName="Head" TagPrefix="my" %>
<%@ Register Src="ascx/_foot.ascx" TagName="Foot" TagPrefix="my" %>
<%@ Register Src="ascx/_nav.ascx" TagName="Nav" TagPrefix="my" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="my" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=pageTitle %></title>
    <meta name="keywords" content="家具活动专区 特价家具 家具秒杀 团购活动 促销活动" />
    <meta name="description" content="家具快搜-中国家居行业信息平台，给您最全最新的家具品牌、家具卖场、优惠促销活动资讯！" />
    <my:Resource runat="server" />
</head>
<body>
    <my:Head runat="server" />
    <my:Nav runat="server" />
    <div style="width: 1px; height: 100%; position: absolute; top: 0px; left: 0px;" id="bodyHeightBox">
    </div>
    <div style="width: 0; height: 6px;">
    </div>
    <div class="topNav992 central">
        <div class="productList1" style="margin-top: 0; min-height: 1000px;">
            <div class="productList12" style="margin-top: 0;">
                <div class="productList121">
                    <ul class="pr12-ti">
                        <li><a class="<%=UiCommon.QueryStringCur("display", "", "", "pr12-tia") %><%=UiCommon.QueryStringCur("display", "all", "", "pr12-tia") %>"
                            href="#">所有招商信息</a></li>
                    </ul>
                    <div class="pr12-fy">
                        <a href="<%=NextUrl %>" class="xyy">下一页</a><span><%=ECommon.QueryPageIndex %>/<%=pager.PageCount %></span><a
                            href="<%=PrvUrl %>" style="float: right;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/product_19.gif" /></a></div>
                </div>
                <div class="productList122">
                    <span class="s1"><%--区域搜索--%></span>
                    <%--<div class="pr_xl">
                     所有风格
                        <ul>
                        <%foreach (EnSearchItem i in _Lst.FindAll(x => x.type == "style" && x.isCur == false && x.title != null))
                            { %>
                        <li><a href="<%=string.Format(EnUrls.MerchantsSearch, i.value, 1)%>">
                            <%=i.title %></a></li>
                        <%} %>
                        </ul>
                    </div>--%>
                </div>
            </div>
            <%if (_lst.Count > 0)
              {%>
            <!--list-->
            <%foreach (EnWebMerchants item in _lst)
              { %>
            <div class="brandsgc">
                <div class="brandsgc0">
                    <div class="brandsgc01">
                        <a href="/company/271/index.aspx" title="<%=item.Title %>" target="_blank">
                            <img alt="<%=item.GetMerchantsBrandList[0].title%>" class="scrollLoading" src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/common/white.gif"
                    data-url="<%=EnFilePath.GetBrandThumbPathNew(item.Brandid.ToString(), item.GetMerchantsBrandList[0].thumb != null && item.GetMerchantsBrandList[0].thumb.IndexOf(',') > -1 ? item.GetMerchantsBrandList[0].thumb.Split(',')[0] : item.GetMerchantsBrandList[0].thumb,"141","106") %>" /></a></div>
        <div class="brandsgc02">
            <h3 style="border-bottom: 1px dotted silver;">
                <a href="<%=string.Format(EnUrls.companyMerchantsInfo,item.Cid,item.Id) %>" target="_blank">
                   <%=item.Title %></a></h3>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="zstable">
                <tbody>
                    <tr>
                        <td>
                            <strong>招商品牌：</strong><%=item.GetMerchantsBrandList[0].title%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>生产厂家：</strong><%=item.GetMerchantsCompanyList[0].title%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>风格：</strong><%=item.GetMerchantsBrandList[0].style%><span style="padding-left: 20px;"><strong>材质：</strong><%=item.GetMerchantsBrandList[0].material%></span>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="brandsgc03">
            <a href="/company/271/index.aspx" title="<%=item.GetMerchantsBrandList[0].title%>" target="_blank">
                 <img alt="<%=item.GetMerchantsBrandList[0].title %>" class="scrollLoading" src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/common/white.gif"
                                data-url="<%=EnFilePath.GetBrandLogoPath(item.Brandid.ToString(),item.GetMerchantsBrandList[0].logo) %>" /></a>
            <div class="productView" style="display: none;">
                <div class="br-gcs bd" style="padding-bottom: 0px; display: none;">
                    <ul>
                        <li><a href="#" class="btn" onclick="window.open('/company/<%=item.Cid %>/product.aspx')">查看产品</a></li>
                        <li><a href="#" class="btn" onclick="window.open('/company/<%=item.Cid %>/brand.aspx')">品牌介绍</a></li>
                        <li><a href="#" class="btn" onclick="window.open('/company/<%=item.Cid %>/address.aspx')">
                            店铺地址</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    </div>
    <% } %>
    <!--list-end--->
    <%}
              else
              { %>
    <div class="productPic productPic1">
        <div class="productPic1" style="background: url(<%=ECommon.WebResourceUrlToWeb %>/images/not.gif) no-repeat;
            height: 201px; line-height: 210px; text-align: center; font-size: 16px; font-weight: bold;
            color: #595959;">
            抱歉，暂无相关的招商信息
        </div>
    </div>
    <%} %>
    <my:AspNetPager ID="pager" runat="server" AlwaysShow="true" PageSize="20" CssClass="pager"
        CurrentPageButtonClass="cpb" UrlPaging="true" FirstPageText="首页" PrevPageText="上一页"
        NextPageText="下一页" LastPageText="尾页">
    </my:AspNetPager>
    </div>
    <%if (ECommon.QuerySearchDisplay.ToLower() != "brand" && ECommon.QuerySearchDisplay.ToLower() != "market")
      { %>
    <div class="productList2" style="margin-top: 0;">
        <div class="promotionsR1" style="height: auto; padding-bottom: 30px;">
            <div class="promotions">
                促销信息</div>
            <div class="prAd1">
                <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=14"></script>
                <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=15"></script>
            </div>
            <%if (NewList.Count == 0)
              { %>
            暂无促销信息
            <%}
              else
              { %>
            <%for (int i = 0; i < NewList.Count; i++)
              { %>
            <div class="promotions2">
                <a href="<%=string.Format("/promotionsinfo.aspx?id={0}", NewList[i].id) %>">
                    <h3>
                        <%=NewList[i].title%></h3>
                </a>
                <p class="time">
                    截至日期：<%=NewList[i].enddatetime.ToShortDateString() %></p>
                <%if (NewList[i].promotionsrelated.Count > 0)
                  { %>
                <%if (NewList[i].membertype == (int)EnumMemberType.工厂企业 || NewList[i].membertype == (int)EnumMemberType.经销商)
                  { %>
                <p class="address">
                    <%=NewList[i].promotionsrelated[0].shopaddress%></p>
                <%}
                  else if (NewList[i].membertype == (int)EnumMemberType.卖场)
                  { %>
                <p class="address">
                    <%=NewList[i].promotionsrelated[0].marketaddress%></p>
                <%} %>
                <%} %>
            </div>
            <%} %>
            <%} %>
        </div>
    </div>
    <%} %>
    </div>
    <my:Foot runat="server" />
</body>
</html>
