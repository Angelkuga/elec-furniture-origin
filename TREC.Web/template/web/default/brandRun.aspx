<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="brandRun.aspx.cs" Inherits="TREC.Web.template.web.brandRun" %>

<!DOCTYPE>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
     /*弹出框*/
        .topstyle
        {
            position: absolute;
            background-color: #000000;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            z-index: 99998;
            display: block;
            opacity: 0.3;
            filter:alpha(opacity=30);
	-moz-opacity:0.3;
	-khtml-opacity: 0.5;
	opacity: 0.5;
        }
        .divopenv
        {
            width: 300px;
            height: 300px;
            position: fixed;
            z-index: 9999999998;
            display: none;
            opacity: 0.0;
        }
        /*弹出框*/
    </style>

    <script language="javascript" type="text/javascript">
        document.getElementById('alertku1').style.display = 'none'; document.getElementById('alertku2').style.display = 'none';
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <%=alert%>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />

    </form>
</body>
</html>
