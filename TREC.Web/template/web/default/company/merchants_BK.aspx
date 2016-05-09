
<%@ Page Language="C#" AutoEventWireup="true"  Inherits="TREC.Web.aspx.company.merchants" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register src="../ascx/_headA.ascx" tagname="_headA" tagprefix="uc1" %>
<%@ Register src="../ascx/_resource.ascx" tagname="_resource" tagprefix="uc2" %>
<%@ Register src="../ascx/_companynav.ascx" tagname="_companynav" tagprefix="uc3" %>
<%@ Register src="../ascx/_foot.ascx" tagname="_foot" tagprefix="uc4" %>
<%@ Register src="../ascx/_companyproduct.ascx" tagname="_companyproduct" tagprefix="uc5" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="my" %>
<%@ Register src="../ascx/_companykeys.ascx" tagname="_companykeys" tagprefix="uc6" %>
<%@ Register src="../ascx/_teladdress.ascx" tagname="_teladdress" tagprefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_companykeys ID="_companykeys1" Title="-厂家新闻" runat="server" />
    <uc2:_resource ID="_resource1" runat="server" />
</head>
<body>

<uc1:_headA ID="_headA1" runat="server" />
<uc3:_companynav ID="_companynav1" runat="server" />
<div style="width:0; height:6px;"></div>
<div class="homebrandsc">
  <div class="topNav992">
    <div class="homebraLift">
        <div class="productList12" style="margin-top:0;">
            <div class="productList121">
                <ul class="pr12-ti">
                    <li><a href="<%=string.Format(EnUrls.CompanyInfoNewsList, ECommon.QueryCid, ECommon.QueryPageIndex) %>" class="pr12-tia">全部新闻资讯</a></li>
                </ul>
                <div class="pr12-fy"><a href="<%=NextUrl %>" class="xyy">下一页</a><span><%=ECommon.QueryPageIndex %>/<%=pager.PageCount %></span><a href="<%=PrvUrl %>" style="float:right;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/product_19.gif" /></a></div>
            </div>
            <div class="productList122">

            </div>
        </div>
        <div style="width:0; height:6px;"></div>
        <div class="news">
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
                <a href="<%=string.Format(EnUrls.companyMerchantsInfo,item.Cid,item.Id) %>">
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
    <%}%>
            </div>
        <my:AspNetPager ID="pager" runat="server" UrlPaging="true" CssClass="pager" CurrentPageButtonClass="cpb" AlwaysShow="true" FirstPageText="首页" PrevPageText="上一页" NextPageText="下一页" LastPageText="尾页"></my:AspNetPager>
    </div>
    <div class="homebraRight">
        <uc5:_companyproduct ID="_companyproduct1" runat="server" />
        <uc7:_teladdress ID="_teladdress1" runat="server" />
    </div>
  </div>
</div>
<uc4:_foot ID="_foot1" runat="server" />
</body>
</html>
