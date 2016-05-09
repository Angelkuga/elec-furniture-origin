<%@ Page Language="C#" AutoEventWireup="true" Inherits="TREC.Web.aspx.shop.address" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register Src="../ascx/headerShop.ascx" TagName="_headerShop" TagPrefix="ucheaderShop" %>
<%@ Register Src="../ascx/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>  
<%@ Register Src="../ascx/newresource.ascx" TagName="newresource" TagPrefix="ucnewresource" %>
<%--
<%@ Register Src="../ascx/_headA.ascx" TagName="_headA" TagPrefix="uc1" %>
<%@ Register Src="../ascx/_resource.ascx" TagName="_resource" TagPrefix="uc2" %>


<%@ Register Src="../ascx/_shopnav.ascx" TagName="_shopnav" TagPrefix="uc3" %>
<%@ Register Src="../ascx/_foot.ascx" TagName="_foot" TagPrefix="uc4" %>--%>
<%@ Register Src="../ascx/_shopproduct.ascx" TagName="_shopproduct" TagPrefix="uc5" %>
<%@ Register Src="../ascx/_shopkeys.ascx" TagName="_shopkeys" TagPrefix="uc6" %>
<%@ Register Src="../ascx/_shopteladdress.ascx" TagName="_shopteladdress" TagPrefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <uc6:_shopkeys ID="_shopkeys1" Title="-经销店铺-联系地址" runat="server" />
    <%--<uc2:_resource ID="_resource1" runat="server" />--%>
    <script type="text/javascript">
        myFocus.set({
            id: 'fjwcontainer', //焦点图盒子ID
            pattern: 'mF_taobao2010', //风格应用的名称
            path: '<%=ECommon.WebResourceUrl %>/script/pattern/',
            time: 6, //切换时间间隔(秒)
            trigger: 'mouseover', //触发切换模式:'click'(点击)/'mouseover'(悬停)
            width: 767, //设置图片区域宽度(像素)
            height: 331, //设置图片区域高度(像素)
            txtHeight: 0//文字层高度设置(像素),'default'为默认高度，0为隐藏
        });
    </script>
</head>
<body>
    <%-- <uc1:_headA ID="_headA1" runat="server" />--%>
    <%--    <uc3:_shopnav ID="_shopnav1" runat="server" />--%>
    <ucheaderShop:_headerShop ID="_headerShop" runat="server" />
    <div class="homebrandsc">
        <div class="topNav992">
            <div class="homebraLift">
                <div class="homebraLi2" style="margin-top: 0;">
                    <%--<div class="brandsDealer-map" id="maps"></div>
             <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2"></script>
            <script type="text/javascript">
                var map = new BMap.Map("maps");
                map.centerAndZoom(new BMap.Point(116.404, 39.915), 11);
                var local = new BMap.LocalSearch(map, {
                    renderOptions: { map: map }
                });
                local.search("<%=ECommon.GetAreaName(shopInfo.areacode)+shopInfo.address %>");
            </script>--%>
                    <%if (memberInfo != null && memberInfo.RegEndTime > DateTime.Now)
                      { %>
                    <div class="braAbout c61f38">
                        <div class="braabtitle">
                            联系方式</div>
                        <div class="braAboutlx">
                            所在卖场：<a href="/market/<%=shopInfo.marketid %>/index.aspx"><%=!string.IsNullOrEmpty(shopInfo.marketname) ? shopInfo.marketname : "抱歉，无记录"%></a><br />
                            店铺名称：<strong><%=shopInfo.title%></strong><br />
                            经销品牌：<a href="#"><%=shopInfo.BrandName.Replace(",", "")%></a><br />
                            店铺地址：<%=shopInfo.address%><br />
                            联系电话：<%=shopInfo.phone%><br />
                            <%--联系人：<%=shopInfo.linkman %>--%>
                        </div>
                    </div>
                    <%} %>
                </div>
            </div>
            <div class="homebraRight">
                <uc5:_shopproduct ID="_shopproduct1" runat="server" />
                <uc7:_shopteladdress ID="_shopteladdress1" runat="server" />
            </div>
        </div>
    </div>
    <%--<uc4:_foot id="_foot1" runat="server" />--%>
     <ucfooter:footer ID="header3" runat="server" />
</body>
</html>
