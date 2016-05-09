<%@ Page Language="C#" AutoEventWireup="true"  Inherits="TREC.Web.aspx.market.promotion" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Register src="../ascx/_headA.ascx" tagname="_headA" tagprefix="uc1" %>
<%@ Register src="../ascx/_resource.ascx" tagname="_resource" tagprefix="uc2" %>
<%@ Register src="../ascx/_marketnav.ascx" tagname="_marketnav" tagprefix="uc3" %>
<%@ Register src="../ascx/_foot.ascx" tagname="_foot" tagprefix="uc4" %>
<%@ Register src="../ascx/_marketkeys.ascx" tagname="_marketkeys" tagprefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <uc6:_marketkeys ID="_marketkeys1" Title="-家具卖场-促销信息" runat="server" />
    <uc2:_resource ID="_resource1" runat="server" />
    
    <script type="text/javascript">
        myFocus.set({
            id: 'fjwcontainer', //焦点图盒子ID
            pattern: 'mF_games_tb', //风格应用的名称
            path: '<%=ECommon.WebResourceUrl %>/script/pattern/',
            time: 6, //切换时间间隔(秒)
            trigger: 'mouseover', //触发切换模式:'click'(点击)/'mouseover'(悬停)
            width: 300, //设置图片区域宽度(像素)
            height: 225, //设置图片区域高度(像素)
            txtHeight: 0//文字层高度设置(像素),'default'为默认高度，0为隐藏
        });
</script>
</head>
<body>

<uc1:_headA ID="_headA1" runat="server" />
<uc3:_marketnav ID="_marketnav1" runat="server" />

<uc4:_foot ID="_foot1" runat="server" />
</body>
</html>
