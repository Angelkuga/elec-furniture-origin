<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Repay.aspx.cs" Inherits="TREC.Web.template.web.Ucenter.Repay" %>
<%@ Register Src="../ascx/header.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户定单支付</title>
     <link href="/resource/content/css/ucerter.css" rel="stylesheet" type="text/css">
    <link href="/resource/content/css/supplier.css" rel="stylesheet" type="text/css">
   <script src="/resource/content/indexnav/jquery.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
     <uc1:header ID="header1" runat="server" />
    <div class="site"><a href="#">首页</a> &gt; <a href="#">购物车</a> &gt; 用户中心</div>
  <center style="margin-top:50px;margin-bottom:50px;">  <div style="font-size:15px;">定单提交中... </div></center>
    <ucfooter:footer ID="header2" runat="server" />
    </form>
</body>
</html>
