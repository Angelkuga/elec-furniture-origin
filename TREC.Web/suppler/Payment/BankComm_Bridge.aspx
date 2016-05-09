<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankComm_Bridge.aspx.cs"
    Inherits="TREC.Web.Suppler.Payment.BankComm_Bridge" %>
    <%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
</head>
<body>
    <%=PayMentCode %>
    <script type="text/javascript">
        $(window).load(function () {
            $('form').submit();
        });
    </script>
</body>
</html>
