<%@ Page Language="C#" AutoEventWireup="true"%>

<%@ Register src="ascx/_resource.ascx" tagname="_resource" tagprefix="uc1" %>
<%@ Register src="ascx/_head.ascx" tagname="_head" tagprefix="uc2" %>
<%@ Register src="ascx/_foot.ascx" tagname="_foot" tagprefix="uc3" %>
<%@ Register src="ascx/_nav.ascx" tagname="_nav" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>家具快搜-拼团</title>
    <uc1:_resource ID="_resource1" runat="server" />
</head>
<body>
<uc2:_head ID="_head1" runat="server" />
<uc4:_nav ID="_nav1" runat="server" />
<div class="tgPart" style="margin:0 auto;width:1000px;margin-top:15px;" >
<img alt="" src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/tg1.jpg">
<img alt="" src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/tg2.jpg">
<img alt="" src="<%=TREC.ECommerce.ECommon.WebResourceUrlToWeb %>/images/tg3.gif">
<%-- <img alt="" src="<%=FordioB2B.ECommerce.ECommon.GetWebSkinUrl %>/images/tg4.jpg">
<img alt="" src="<%=FordioB2B.ECommerce.ECommon.GetWebSkinUrl %>/images/tg5.gif">
<img alt="" src="<%=FordioB2B.ECommerce.ECommon.GetWebSkinUrl %>/images/tg6.gif">
<img alt="" src="<%=FordioB2B.ECommerce.ECommon.GetWebSkinUrl %>/images/tg7.jpg">--%>
</div>

<uc3:_foot ID="_foot1" runat="server" />
    
</body>
</html>
