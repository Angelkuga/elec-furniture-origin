<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index2.aspx.cs" Inherits="TREC.Web.template.web.Dealer.index2" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="System.Linq" %>

<%@ Register Src="../ascx/HeadDealer.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register src="../ascx/DealerProduct.ascx" tagname="DealerProduct" tagprefix="uc2" %>
<%@ Register src="../ascx/New_DealerProduct.ascx" tagname="New_DealerProduct" tagprefix="uc3" %>
<%@ Register src="../ascx/Dealerteladdress.ascx" tagname="Dealerteladdress" tagprefix="uc4" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=7;IE=9;IE=8">
       <link href="/resource/content/css/core.css" rel="stylesheet" type="text/css" /> 
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/index_new.css" />
    <link rel="Stylesheet" type="text/css" href="/resource/web/css/common.css" />

    <script src="/resource/content/js/core.js"></script> 
</head>
<body>
    <form id="form1" runat="server">
   <uc1:header ID="header1" runat="server" />
    <div class="topNav992">
    <div class="nullInfo">
        <div class="nullText">
            <div class="nullTextTitle">&nbsp;&nbsp;&nbsp;</div>
            <table class="c" cellpadding="0" cellspacing="0">
                <tr>
                    <td style=" line-height:25px; height:25px;">&nbsp;</td>
                </tr>
                <tr>
                    <td><span class="i">该厂家的信息不完整</span></td>
                </tr>
                <tr>
                    <td>获得更多商业机会，建议升级会员级别</td>
                </tr>
                <tr>
                    <td>咨询电话：400-001-9211</td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
        </div>
        <div class="nullError">
            <p class="p1">对不起,您目前访问的厂家暂有部分信息不全。<br>我们将尽快完善本卖场信息资料。</p>
            <p class="p2">如需咨询，请拨打客服热线400-001-9211</p>
            <p class="p3">您也可以去其它地方逛逛: <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/market/list.aspx">卖场首页</a> | <a href="<%=TREC.ECommerce.ECommon.WebUrl.TrimEnd('/') %>/companybrandlist.aspx">品牌首页 </a></p>
        </div>
    </div>
</div>
    <ucfooter:footer ID="header2" runat="server" />
    </form>
</body>
</html>
