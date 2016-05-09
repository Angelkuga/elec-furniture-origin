<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_headA.ascx.cs" Inherits="TREC.Web.aspx.ascx._headA" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<div class="homebrandst zhucetop1">
  <div class="topNav992">
    <div class="homepplogo"><a href="<%=TREC.ECommerce.ECommon.WebUrl %>"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/homebrands_03.gif" /><img style=" margin-top:2px;" src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/homebrands_05.gif"/></a></div>
<%--    <div class="shengming">[福家网旗下网站]</div>--%>
    <div class="topSearch homeppSearch">
      <div class="topSearch1"><a href="#"><img src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/index_21.gif"  /></a><span id="searchTypeDisplay">搜品牌</span>
        <ol id="searchTypeList">
                        <a href="#" title="brand" class="Searcha">搜品牌</a>
                        <%--<a href="#" title="distributor">搜经销商</a>--%>
                        <a href="#" title="product">搜产品</a>
                        <a href="#" title="market">搜卖场</a>
                        <%--<a href="#" title="information">搜活动</a>--%>
                   </ol>
      </div>
      <input name="searchKey" type="text" class="topSearch2" id="searchKey" />
      <a href="#" class="topSearch3" id="topSearchBtn"></a> </div>
      <script type="text/javascript">
          $(function () {
              if ("<%=ECommon.QuerySearchKey %>" != "") {
                  $("#searchKey").val("<%=ECommon.QuerySearchKey %>");
              }
              $('#searchKey').oms_autocomplate({ url: '/ajax/search.ashx', inputWidth: 304,inputHeight:27, paramTypeSelector: "#searchTypeList a.Searcha" });
          })
          $("#topSearchBtn").click(function () {
              //window.top.location = "<%=EnUrls.Search%>".format($("#searchFootTypeList").find("a.coselia").attr("title"), $("#searchFootKey").val().replace(/\-/g, "_"));
              window.top.location = "<%=ECommon.WebUrl %>" + "/search.aspx?type=" + $("#searchTypeList").find("a.Searcha").attr("title") + "&key=" + encodeURIComponent($("#searchKey").val().replace(/\-/g, "_"));
          });
        </script>
    <div class="topLogin"><%--<img src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/index_04.gif" />--%>
         <%if (TRECommon.CookiesHelper.GetCookie("mid") != "" && TRECommon.CookiesHelper.GetCookie("mname") != "" && TRECommon.CookiesHelper.GetCookie("mpwd") != "")
              { %>
              您好：<a href="<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/suppler/index.aspx"><strong>[<%=TRECommon.CookiesHelper.GetCookie("mname") != "" && TRECommon.CookiesHelper.GetCookie("mname").Length > 7 ? TRECommon.CookiesHelper.GetCookie("mname").Substring(0, 7) + ".." : TRECommon.CookiesHelper.GetCookie("mname") %>]</strong></a>
              <%--<a href="<%=TREC.ECommerce.ECommon.WebUrl %>/suppler/index.aspx">[系统]</a>--%>
              <a href="<%=TREC.ECommerce.ECommon.WebUrl %>/loginout.aspx">[退出]</a>
            <%}else{ %>
            <a href="<%=TREC.ECommerce.ECommon.WebUrl %>/reg.aspx?r=l">供应商登录</a> &nbsp;|&nbsp; 
            <a href="<%=TREC.ECommerce.ECommon.WebUrl %>/reg.aspx">申请入驻</a>

            <%} %>
    
    </div>
  </div>
</div>