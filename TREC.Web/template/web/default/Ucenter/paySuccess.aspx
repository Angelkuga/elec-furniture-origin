<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paySuccess.aspx.cs" Inherits="TREC.Web.template.web.Ucenter.paySuccess" %>
<%@ Register Src="../ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/resource/content/css/ucerter.css" rel="stylesheet" type="text/css">
    <link href="/resource/ShoppingCss/shopping.css" rel="stylesheet" type="text/css">
   <script src="/resource/content/indexnav/jquery.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:header ID="header1" runat="server" />
    <div class="site"><a href="#">首页</a> &gt; <a href="#">购物车</a> &gt; 用户中心</div>
    
    <!--------->

    <div class="contentInner">
  <div class="inner">
    <div class="shopping">
      <div class="gwcg">
        <div class="gwcg1"><div class="gwcg11"><span>支付成功！</span><br>
订单号：<%=ordernumber%></div></div>
        <div class="gwcg2"><img width="145" height="181" alt="" src="/resource/content/images/ucenter/847.jpg">在线支付：<%=m%>元
<br>
<a href="/Ucenter/OrderListInfor.aspx?OrderNumber=<%=ordernumber%><%=pid %>">查看订单详情</a><br>
<a class="hs" href="#">继续逛逛</a></div>
<div class="gwcg3">重要提示：家具快搜平台不会以<span>订单异常、系统升级</span>为由，要求您点击任何链接进行退款。请关注家具快搜，谨防诈骗公告</div>
      </div>
      <div class="clearfix"></div>
    </div>
  </div>
  <div align="center" id="cartnoproduct" style="DISPLAY: none">
    <div class="nopro">
      <h1>我的购物车</h1>
      <div class="noprocon">
        <div class="chebg"><img src="/resource/content/images/ucenter/chebg.gif"></div>
        购物车内暂时没有产品，您可以<a href="http://www.jiajuks.com/">去首页</a>挑选喜欢的产品。</div>
    </div>
  </div>
</div>

    <!---->
  <ucfooter:footer ID="header2" runat="server" />
    </form>
</body>
</html>
