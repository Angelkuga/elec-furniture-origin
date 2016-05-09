<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productattribute.aspx.cs" Inherits="TREC.Web.Admin.product.productattribute" %>
<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href=<%="\""+TREC.ECommerce.ECommon.WebAdminResourceUrl%>/editor/kindeditor/themes/default/default.css" />
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/script/fileupload.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/altdialog/artDialog.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/altdialog/plugins/iframeTools.js"></script>
    <style type="text/css">
        td{height:35px; line-height:35px;}
    </style>
</head>
<body>
<form id="form1" runat="server">
<table cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td  width="70px" align="right">名称：</td>
        <td><input type="text" class="input" id="ctitle" /></td>
    </tr>
    <tr>
        <td align="right">色值：</td>
        <td><input type="text" class="input" id="cvalue" /></td>
    </tr>
    <tr>
        <td align="right">色板：</td>
        <td>
            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Product, ECommon.QueryId, TREC.Entity.EnFilePath.ProductAttributeColorImg)%>">
                <asp:HiddenField ID="hfsurface" runat="server" />
                <div class="fileTools">
                    <input type="text" class="input w160 filedisplay"  />
                    <a href="javascript:;" class="files"><input id="File1" type="file" class="upload" onchange="_upfile(this)"  runat="server" /></a>
                    <span class="uploading">正在上传，请稍后……</span>
                </div>
            </div>
        </td>
    </tr>
</table>
    </form>
</body>
</html>
