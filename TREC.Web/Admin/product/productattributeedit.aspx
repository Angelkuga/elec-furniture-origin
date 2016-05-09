<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productattributeedit.aspx.cs" Inherits="TREC.Web.Admin.product.productattributeedit" %>
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
    <script type="text/javascript">
        $(function () {
            $("#chosetype").toggle(function () {
                $("#txttypename").css("display", "block");
                $(this).text("关闭添加").css("color", "#f60");
                $("#ddltype").val("0");
                $("#ddltype").val("");
                $("#ddltype").attr("disabled", "disabled");
            }, function () {
                $("#txttypename").css("display", "none");
                $(this).text("添加其它").css("color", "#282828");
                $("#ddltype").removeAttr("disabled");
            });

            $("#ddltype").live("change", function () {
                $("#txttypename").val($("#ddltype").find("option:selected").text());

            })

            if ('<%=model.typevalue %>' == '0') {
                $("#ddltype").attr("disabled", "disabled");
                $("#txttypename").css("display", "block");
                $(this).text("关闭添加").css("color", "#f60");
            }
        })
    </script>
</head>
<body style="padding:10px;">
<form id="form1" runat="server">
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td width="70px" align="right">类型：</td>
        <td><asp:DropDownList ID="ddltype" runat="server"></asp:DropDownList><input type="text" id="txttypename" class="input" style="display:none" value='<%=model.typename %>' /><label id="chosetype" style="cursor:pointer">添加其它</label>
            
        </td>
    </tr>
    <tr>
        <td width="70px" align="right">选材：</td>
        <td><input type="text" class="input" id="txtm" value='<%=model.productmaterial %>' /></td>
    </tr>
    <tr>
        <td width="70px" align="right">颜色名称：</td>
        <td><input type="text" class="input" id="ctitle" value='<%=model.productcolortitle %>' /></td>
    </tr>
    <tr>
        <td  align="right">颜色色值：</td>
        <td><input type="text" class="input" id="cvalue" value='<%=model.productcolorvalue %>' /></td>
    </tr>
    <tr>
        <td  align="right">颜色色板：</td>
        <td>
            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Product, ECommon.QueryId, TREC.Entity.EnFilePath.ProductAttributeColorImg)%>">
                <asp:HiddenField ID="hfcimg" runat="server" />
                <div class="fileTools">
                    <input type="text" class="input w160 filedisplay"  />
                    <a href="javascript:;" class="files"><input id="File1" type="file" class="upload" onchange="_upfile(this)"  runat="server" /></a>
                    <span class="uploading">正在上传，请稍后……</span>
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td  align="right">大小：</td>
        <td><input type="text" class="input" id="txtlength" style="width:48px" value='<%=model.productlength %>' /><label>(长)</label>
        <input type="text" class="input" id="txtwidth"  style="width:48px" value='<%=model.productwidth %>'  /><label>(宽)</label>
        <input type="text" class="input" id="txtheight"  style="width:48px" value='<%=model.productheight %>' /><label>(高)</label>
        <input type="text" class="input" id="txtcbm"  style="width:48px" value='<%=model.productcbm %>'  /><label>(体积)</label>
        </td>
    </tr>
    <tr>
        <td  align="right">市场价：</td>
        <td><input type="text" class="input" id="txtmarkprice" style="width:80px" value='<%=model.markprice %>' /></td>
    </tr>
</table>
    </form>
</body>
</html>
