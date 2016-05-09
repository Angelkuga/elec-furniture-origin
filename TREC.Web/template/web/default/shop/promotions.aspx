<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotions.aspx.cs" Inherits="TREC.Web.aspx.shop.promotions" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/headerShop.ascx" TagName="_headerShop" TagPrefix="ucheaderShop" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>  
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>

<%--<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>
<%@ Register Src="../ascx/_shopnav.ascx" TagName="_shopnav" TagPrefix="uc3" %>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>--%>
<%@ Register Src="../ascx/_shopproduct.ascx" TagName="_shopproduct" TagPrefix="uc5" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<%@ Register src="../ascx/_shopkeys.ascx" tagname="_shopkeys" tagprefix="uc6" %>
<%@ Register src="../ascx/_shopteladdress.ascx" tagname="_shopteladdress" tagprefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <uc6:_shopkeys ID="_shopkeys1" Title="-经销店铺-促销信息" runat="server" />
    <%-- <uc2:_resource runat="server" />--%>
    <title>
        <%=pageTitle%></title>
    <ucnewresource:newresource ID="newresource1" runat="server" />
        <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" />
    <link href="/resource/content/css/factory/factory.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />

    <script src="/resource/content/js/core.js"></script>
    <script src="/resource/content/libs/slides.min.jquery.js"></script>
    <script src="/resource/content/js/_src/factory/factory.js" type="text/javascript"></script>

</head>
<body>
    <%--<uc1:_headA runat="server" />
    <uc3:_shopnav runat="server" />--%>
     <ucheaderShop:_headerShop ID="_headerShop" runat="server" />
    <div class="homebrandsc">
        <div class="topNav992">
            <%if (ShopPageBase.IsCount)
              { %>
              <div class="homebraLift" style="border:1px solid #D8D8D8; padding-bottom:30px;">

              <%for (int i = 0; i < list.Count; i++)
                { %>

                <div class="brandsDealer promove" style="margin:0 0px; border:0;">
                  <div class="brandsDealerBj" style="margin:0 10px; border-bottom:1px dashed #B2B2B2;">
                    <div class="brandsProm1" style="width:100%;">
                    <h2 class="c61f38"><a href="<%=string.Format(EnUrls.ShopInfoPromotionsInfo, ECommon.QuerySId, list[i].id) %>" target="_blank"><%=list[i].title %></a></h2>
                    <p class="lastdate">
                        <%if (DateTime.Now.Date > list[i].enddatetime.Date)
                          { %>
                        活动已经结束
                        <%}
                          else
                          { %>
                          <%=list[i].startdatetime.ToString("yy年MM月dd号")%>-<%=list[i].enddatetime.ToString("yy年MM月dd号")%>
                        <%} %>
                    </p>
                    <p><%=list[i].descript != null && TRECommon.HTMLUtils.GetAllTextFromHTML(list[i].descript).Length > 100 ? TRECommon.HTMLUtils.GetAllTextFromHTML(list[i].descript).Substring(0, 99) : TRECommon.HTMLUtils.GetAllTextFromHTML(list[i].descript) %></p>
                    </div>
                  </div>
                </div>

                <%} %>

                <webdiyer:AspNetPager ID="pager" runat="server" AlwaysShow="true" UrlPaging="true" CssClass="pager" CurrentPageButtonClass="cpb" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
              PrevPageText="上一页"></webdiyer:AspNetPager>

              </div>
              <div class="homebraRight">
                <uc5:_shopproduct ID="_shopproduct1" runat="server" />
                <uc7:_shopteladdress ID="_shopteladdress1" runat="server" />
              </div>
            <%}
              else
              { %>
              <div class="productShop productPa1" style="text-align: center;">
                该店铺或者店铺下的品牌已经被下线<br />
                您可以查询其他店铺的产品&nbsp; <a href="<%=TREC.ECommerce.ECommon.WebUrl%>product/list.aspx">去查找</a>&nbsp;
                &nbsp; <a href="<%=TREC.ECommerce.ECommon.WebUrl%>">去首页</a>
            </div>
            <%} %>
        </div>
    </div>
<%--    <uc4:_foot runat="server" />--%>
  <ucfooter:footer ID="header3" runat="server" />
</body>
</html>
