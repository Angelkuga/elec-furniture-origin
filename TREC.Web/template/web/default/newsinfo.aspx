<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsinfo.aspx.cs" Inherits="TREC.Web.aspx.newsinfo" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>  
<%@ Register Src="ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>

<%--<%@ Register Src="ascx/_resource.ascx" TagName="Resource" TagPrefix="my" %>
<%@ Register Src="ascx/_head.ascx" TagName="Head" TagPrefix="my" %>
<%@ Register Src="ascx/_foot.ascx" TagName="Foot" TagPrefix="my" %>
<%@ Register Src="ascx/_nav.ascx" TagName="Nav" TagPrefix="my" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>家具快搜-新闻资讯_家具行业信息官网_最全的家具品牌、厂商、店铺、家居卖场信息发布和搜素!</title>
    <meta name="keywords" content="家具网,家具品牌,网购家具,上海家具城," />
    <meta name="description" content="家具快搜专注于中高档家具品牌领域,放心选购品牌系列家具,尽在家具快搜！" />
   <%-- <my:Resource runat="server" />--%>
   <ucnewresource:newresource ID="newresource1" runat="server" />
    <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" /> 
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />  
    <script src="/resource/content/js/core.js"></script> 
</head>
<body>
    <uc1:header ID="header1" runat="server" />
     <div class="site"><a href="/">家具快搜</a> > <a href="/news/list.aspx">资讯</a> > <%=mnews.title%></div>
    <div style="width:0; height:6px;"></div>
    <div class="topNav992 central">
        <div class="productList1" style="margin-top:0;">
            
            <div style="width:0; height:6px;"></div>
            <div class="news">
                <div class="newsitem">
                    <span class="newsitemdate"><%=mnews.createtime.ToString("yyyy.MM.dd") %></span>
                    <h2><a><%=mnews.title %></a></h2>
                    <%if (mnews.ismember)
                      { %>
                    <p><span class="C50913 pleft">[品牌厂家]</span><span class="pright2"><a class="company" target="_blank" href="<%=string.Format(EnUrls.CompanyInfoIndex, mnews.companyid) %>"><%=mnews.companytitle%></a></span></p>
                    <%}
                      else
                      { %>
                    <p><span class="C848484 pleft">[导读]</span><span class="pright"><%=mnews.intro.Length > 56 ? mnews.intro.Substring(0, 56) : mnews.intro %></span></p>
                    <%} %>
                </div>
                <div class="promotionsinfodes"><%=mnews.descript %></div>
            </div>
        </div>
        <div class="productList2" style="margin-top:0;">
            <div class="promotionsR1" style="height:auto; padding-bottom:30px;">
              <div class="promotions">新闻信息</div>
              <div class="prAd1"><script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=14"></script><script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebUrl %>/ajaxtools/ajaxshow.ashx?id=15"></script></div>
                <%if (NewList.Count == 0)
                  { %>
                  <p><center>暂无促销信息</center></p>
                  <%}
                  else
                  { %>
                <%for (int i = 0; i < NewList.Count; i++)
                  { %>
                  <div class="newsitem" style="height:auto; padding-left:8px; padding-right:8px; border-bottom:none;">
                    <h2><a style="font-size:12px;" href="<%=string.Format(EnUrls.NewsInfo, NewList[i].id) %>"><%=NewList[i].title %></a></h2>
                    <%if (NewList[i].ismember)
                      { %>
                    <p><span class="C50913 pleft">[厂家]</span><span class="company"><a class="pright" target="_blank" href="<%=string.Format(EnUrls.CompanyInfoIndex, NewList[i].companyid) %>"><%=NewList[i].companytitle %></a></span></p>
                    <%}
                      else
                      {%>
                      <p><span class="C848484 pleft">[导读]</span><span class="pright"><%=NewList[i].intro.Length > 13 ? NewList[i].intro.Substring(0, 13) : NewList[i].intro %></span></p>
                     <%} %>
                  </div>
                <%} %>
                <%} %>
            </div>
        </div>
    </div>
<ucfooter:footer ID="header3" runat="server" />
</body>
</html>
