<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="TREC.Web.aspx.news" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="Haojibiz.Model" %>
<%@ Import Namespace="Haojibiz.Data" %>
<%@ Import Namespace="Haojibiz.DAL" %>

<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>  
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>


<%--<%@ Register Src="ascx/_resource.ascx" TagName="Resource" TagPrefix="my" %>
<%@ Register Src="ascx/_head.ascx" TagName="Head" TagPrefix="my" %>--%>
<%--<%@ Register Src="ascx/_foot.ascx" TagName="Foot" TagPrefix="my" %>--%>
<%--<%@ Register Src="ascx/_nav.ascx" TagName="Nav" TagPrefix="my" %>--%>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="my" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>家具快搜-新闻资讯_家具行业信息官网_最全的家具品牌、厂商、店铺、家居卖场信息发布和搜素!</title>
    <ucnewresource:newresource ID="newresource1" runat="server" />

    <meta name="keywords" content="家具网,家具品牌,网购家具,上海家具城," />
    <meta name="description" content="家具快搜专注于中高档家具品牌领域,放心选购品牌系列家具,尽在家具快搜！" />
 <%--   <my:Resource runat="server" />--%>
  <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" /> 
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />  
    <script src="/resource/content/js/core.js"></script> 
</head>
<body>
<%--    <my:Head runat="server" />
    <my:Nav runat="server" />--%>
    <uc1:header ID="header1" runat="server" />
     <div class="site"><a href="/">家具快搜</a> > <a href="/news/list.aspx">新闻资讯</a> > <%=getListTitle%></div>
    <div style="width: 0; height: 6px;">
    </div>
    <div class="topNav992 central">
        <div class="productList1" style="margin-top: 0;">
            <div class="productList12" style="margin-top: 0;">
                <div class="productList121">
                    <ul class="pr12-ti">
                        <li><a href="<%=string.Format(EnUrls.NewsListSearch, "all", "") %>" class="<%=UiCommon.QueryStringCur("display", "", "", "pr12-tia") %><%=UiCommon.QueryStringCur("display", "all", "", "pr12-tia") %>">
                            全部新闻资讯</a></li>
                        <li><a href="<%=string.Format(EnUrls.NewsListSearch, "admin", "") %>" class="<%=UiCommon.QueryStringCur("display", "admin", "", "pr12-tia") %>">
                            最新行业资讯</a></li>
                        <li><a href="<%=string.Format(EnUrls.NewsListSearch, "company", "") %>" class="<%=UiCommon.QueryStringCur("display", "company", "", "pr12-tia") %>">
                            品牌新闻资讯</a></li>
                    </ul>
                    <div class="pr12-fy">
                        <a href="<%=NextUrl %>" class="xyy">下一页</a><span><%=ECommon.QueryPageIndex %>/<%=pager.PageCount %></span><a
                            href="<%=PrvUrl %>" style="float: right;"><img src="<%=ECommon.WebResourceUrlToWeb %>/images/product_19.gif" /></a></div>
                </div>
                <div class="productList122">
                </div>
            </div>
            <div style="width: 0; height: 6px;">
            </div>
            <div class="news">
                <%if (list.Count > 0)
                  { %>
                <%for (int i = 0; i < list.Count(); i++)
                  { %>
                <div class="newsitem" style="border-bottom: <%=i == list.Count - 1 ? "none" : "" %>;">
                    <span class="newsitemdate">
                        <%=list[i].createtime.ToString("yyyy.MM.dd") %></span>
                    <h2>
                        <a href="<%=string.Format(EnUrls.NewsInfo, list[i].id) %>">
                            <%=list[i].title %></a></h2>
                    <%if (list[i].ismember)
                      { %>
                    <p>
                        <span class="C50913 pleft">[品牌厂家]</span><span class="pright2"><a class="company"
                            target="_blank" href="<%=string.Format(EnUrls.CompanyInfoIndex, list[i].companyid) %>"><%=list[i].companytitle %></a></span></p>
                    <%}
                      else
                      { %>
                    <p>
                        <span class="C848484 pleft">[导读]</span><span class="pright"><%=list[i].intro.Length > 56 ? list[i].intro.Substring(0, 56) : list[i].intro %></span></p>
                    <%} %>
                </div>
                <%} %>
                <%}
                  else
                  { %>
                <div class="newsitem" style="border-bottom: none;">
                    <center>
                        <h2>
                            暂无相关新闻</h2>
                    </center>
                </div>
                <%} %>
            </div>
            <my:AspNetPager ID="pager" runat="server" UrlPaging="true" CssClass="pager" CurrentPageButtonClass="cpb"
                AlwaysShow="true" FirstPageText="首页" PrevPageText="上一页" NextPageText="下一页" LastPageText="尾页">
            </my:AspNetPager>
        </div>
        <div class="productList2" style="margin-top: 0;">
            <div class="promotionsR1" style="height: auto; padding-bottom: 30px;">
                <div class="promotions">
                    新闻信息</div>
                <div class="prAd1">
                    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=14"></script>
                    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=15"></script>
                </div>
                <%if (NewList.Count == 0)
                  { %>
                <p>
                    <center>
                        暂无促销信息</center>
                </p>
                <%}
                  else
                  { %>
                <%for (int i = 0; i < NewList.Count; i++)
                  { %>
                <div class="newsitem" style="height: auto; padding-left: 8px; padding-right: 8px;
                    border-bottom: none;">
                    <h2>
                        <a style="font-size: 12px;" href="<%=string.Format(EnUrls.NewsInfo, NewList[i].id) %>">
                            <%=NewList[i].title %></a></h2>
                    <%if (NewList[i].ismember)
                      { %>
                    <p>
                        <span class="C50913 pleft">[厂家]</span><span class="company"><a class="pright" target="_blank"
                            href="<%=string.Format(EnUrls.CompanyInfoIndex, NewList[i].companyid) %>"><%=NewList[i].companytitle %></a></span></p>
                    <%}
                      else
                      {%>
                    <p>
                        <span class="C848484 pleft">[导读]</span><span class="pright"><%=NewList[i].intro.Length > 13 ? NewList[i].intro.Substring(0, 13) : NewList[i].intro %></span></p>
                    <%} %>
                </div>
                <%} %>
                <%} %>
            </div>
        </div>
    </div>
<%--    <my:Foot runat="server" />--%>
<ucfooter:footer ID="header3" runat="server" />
</body>
</html>
