<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TREC.Web.Admin.index" %>

<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>家具快搜平台-后台管理系统</title>
    <link rel="Stylesheet" type="text/css" href="css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/common.js"></script>
    <script type="text/javascript" src="script/admin.js"></script>
    <style type="text/css">
        html, body, form
        {
            height: 100%;
        }
        table
        {
            background: #EBF5FC;
        }
        table td
        {
            vertical-align: top;
            text-align: left;
            padding: 0px;
            margin: 0px;
        }
        .navPoint
        {
            font-family: Webdings;
            color: #fff;
            font-size: 9pt;
            cursor: hand;
            cursor: pointer;
            vertical-align: middle;
        }
        td.n
        {
            vertical-align: middle;
            text-align: left;
            cursor: pointer;
            padding: 0px;
            margin: 0px;
            border: 0px;
            background: url("images/main_cen_bg.gif") repeat-x scroll 0 0 transparent;
            height: 100%;
        }
    </style>
</head>
<body style="margin: 0 0 0 0; height: 100%;">
    <table cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;" border="0">
        <tr>
            <td style="height: 60px; width: 100%" colspan="3">
                <iframe id="topFrame" style="z-index: 1; visibility: inherit; width: 100%; height: 60px"
                    src="top.aspx" frameborder="0" scrolling="no"></iframe>
            </td>
        </tr>
        <tr>
            <td width="width:100">
                <table style="height:900px; width: 100%">
                    <tr>
                        <td style="width: 159px; height: 100%;" id="tableLeftMenu">
                            <iframe id="frmLeft" name="frmLeft" style="width: 159px; height: 100%" src="menu.aspx"
                                frameborder="0" scrolling="no"></iframe>
                        </td>
                        <td width="8px;" id="tableLeftMenuBar" class="n">
                            <div style="cursor: pointer;" id="sysBar">
                                <img alt="关闭/打开左栏" src="images/butClose.gif" id="barImg"></div>
                        </td>
                        <td id="tableConvertMain" style="background: #fff;">
                            <iframe id="frmmain" name="frmmain" style="width: 100%; height: 900px" src="main.aspx"
                                frameborder="0"></iframe>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>
