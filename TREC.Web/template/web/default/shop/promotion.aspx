<%@ Page Language="C#" AutoEventWireup="true"  Inherits="TREC.Web.aspx.shop.promotion" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register src="../ascx/_headA.ascx" tagname="_headA" tagprefix="uc1" %>
<%@ Register src="../ascx/_resource.ascx" tagname="_resource" tagprefix="uc2" %>
<%@ Register src="../ascx/_shopnav.ascx" tagname="_shopnav" tagprefix="uc3" %>
<%@ Register src="../ascx/_foot.ascx" tagname="_foot" tagprefix="uc4" %>
<%@ Register src="../ascx/_shopproduct.ascx" tagname="_shopproduct" tagprefix="uc5" %>
<%@ Register src="../ascx/_shopkeys.ascx" tagname="_shopkeys" tagprefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_shopkeys ID="_shopkeys1" Title="-经销店铺-促销信息" runat="server" />
    <uc2:_resource ID="_resource1" runat="server" />
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

<uc1:_headA ID="_headA1" runat="server" />
<uc3:_shopnav ID="_shopnav1" runat="server" />

<uc4:_foot ID="_foot1" runat="server" />
</body>
</html>
