<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productattribute.aspx.cs"
    Inherits="TREC.Web.Suppler.product.productattribute" %>

<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="<%="\""+TREC.ECommerce.ECommon.WebSupplerResourceUrl%>/editor/kindeditor/themes/default/default.css" />
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/fileupload.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/altdialog/artDialog.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/altdialog/plugins/iframeTools.js"></script>
    <script src="../script/ColorPanel.js" type="text/javascript"></script>
    <style type="text/css">
        td
        {
            height: 35px;
            line-height: 35px;
        }
    </style>
</head>
<body style="height: auto">
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%" >
    <tr>
                <td align="right" width="60">
                    类型：
                </td>
                <td>
<div style="position: relative;height:26px;">
<asp:DropDownList ID="ddltype" runat="server" Width="100" CssClass="select"></asp:DropDownList>
<input type="text" class="input" id="txtatypename" style="width: 94px; display: none; border-color: #f60;" />
<a href="javascript:;" id="selecttypename" style="display: inline-block; zoom: 1; *display: inline; width: 75px; line-height: 16px; margin-top: 3px;" class="btn_all">添加其它类型</a></div>
<div style="text-align:left;position: relative;height:26px;">(如下拉框内无您产品的类型，请点击添加)</div>
                </td>
            </tr>
            <tr>
                <td align="right">
                    选材：
                </td>
                <td>
                    <input type="text" class="input" id="txtamaterial" /><label>(例：金属框架+板材+软包)</label>
                </td>
            </tr>
            <tr>
            <td align="right">
            颜色名称：
            </td>
            <td>
            <input type="text" class="input" style="width:100px;" id="hfacolortitle" />
            </td>
            </tr>
            <tr>
            <td align="right">
            色板：
            </td>
            <td>
                 <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Product, ECommon.QueryId, TREC.Entity.EnFilePath.ProductAttributeColorImg)%>">
                    <asp:HiddenField ID="hfacolorimg" runat="server" />
                    <div class="fileTools" style="width:310px">
                        <input type="text" class="input w160 filedisplay" style="width:100px;" />
                        <a href="javascript:;" class="files">
                            <input id="File1" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                </div>
            </td>
            </tr>
            <tr>
            <td align="right">
            色差：
            </td>
            <td>
            <input type="text" class="input" style="width:100px;" id="hfacolor" /><div id="container" style="float:left;display:inline;"> </div> &nbsp;&nbsp;请点击左边方框选择色值
            </td>
            </tr>
            <tr>
                <td align="right">
                    长：
                </td>
                <td>
                    <input type="text" class="input" id="txtalength" value="0" style="width: 65px;" /><label>&nbsp;&nbsp;(mm)</label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    宽：
                </td>
                <td>
                    <input type="text" class="input" id="txtawidth" value="0" style="width: 65px" /><label>&nbsp;&nbsp;(mm)</label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    高：
                </td>
                <td>
                    <input type="text" class="input" id="txtaheight" value="0" style="width: 65px" /><label>&nbsp;&nbsp;(mm)</label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    体积：
                </td>
                <td>
                    <input type="text" class="input" id="txtacbm" value="0" style="width: 65px" />&nbsp;&nbsp;(打包后体积)
                </td>
            </tr>
            <tr>
                <td align="right">
                    价格：
                </td>
                <td>
                    <input type="text" class="input" id="txtmarketprice" value="0" style="width: 65px" />&nbsp;&nbsp;(市场指导价)
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td>
                    <input type="button" class="submit" value="增加" id="btnAddAttribute" />
                </td>
            </tr>
    </table>
    <script type="text/javascript">
        var cp = new ColorPanel();
        cp.size = 5; //设置精度 使用奇数
        cp.init($$("container"), $$("hfacolor"));

        $("#selecttypename").toggle(function () {
            $("#txtatypename").show();
            $(this).text("关闭添加类型").css("color", "#f60");
            $("#ddltype").val("0");
            $("#ddltype").val("");
            $("#ddltype").hide();
        }, function () {
            $("#txtatypename").hide();
            $(this).text("添加其它类型").css("color", "#282828");
            $("#ddltype").show();
        });

        $("#btnAddAttribute").click(function () {
            var htmlJson = "";
            var listHtml = "";

            var productType = "";
            var productTypeName = "";
            var productMaterial = "";
            var phfacolor = "";
            var pcolortitle = "";
            var pacolorimg = "";
            var plength = "";
            var pawidth = "";
            var paheight = "";
            var pacbm = "";
            var pmarketprice = "";

            if (($("#ddltype").val() == "" || $("#ddltype").val() == "0") && $("#txtatypename").val() == "") {
                alert("请选择分类-->选择类型,或点击其它新增");
                return false;
            }
            //add 提示
            if ($("#txtamaterial").val() == "") {
                $("#txtamaterial").focus();
                alert("请填写选材!");
                return false;
            }

            if ($("#hfacolor").val() == "" && $("#hfacolorimg").val() == "") {
                alert("请填写颜色!");
                return false;
            }

            if ($("#ddltype").val() != "" && $("#ddltype").val() != "0") {
                productType = "\"typeid\":\"" + $("#ddltype").val() + "\",";
                productTypeName = "\"typename\":\"" + $("#ddltype").find("option:selected").text() + "\",";
                listHtml += "<span  class=\"t\">" + $("#ddltype").find("option:selected").text() + "</span>";
            }
            else {
                productType = "\"typeid\":\"0\",";
                productTypeName = "\"typename\":\"" + $("#txtatypename").val() + "\",";
                listHtml += "<span class=\"t\">" + $("#txtatypename").val() + "</span>";
            }

            productMaterial = "\"pmaterial\":\"" + $("#txtamaterial").val() + "\",";
            phfacolor = "\"pacolor\":\"" + $("#hfacolor").val() + "\",";
            pcolortitle = "\"pcolortitle\":\"" + $("#hfacolortitle").val() + "\",";
            pacolorimg = "\"pcimg\":\"" + $("#hfacolorimg").val() + "\",";
            plength = "\"plength\":\"" + $("#txtalength").val() + "\",";
            pawidth = "\"pwidth\":\"" + $("#txtawidth").val() + "\",";
            paheight = "\"pheight\":\"" + $("#txtaheight").val() + "\",";
            pacbm = "\"pcbm\":\"" + $("#txtacbm").val() + "\",";
            pmarketprice = "\"pmprice\":\"" + $("#txtmarketprice").val() + "\"";

            htmlJson = '{' + productType + productTypeName + productMaterial + phfacolor + pcolortitle + pacolorimg + plength + paheight + pawidth + pacbm + pmarketprice + '},';


            parent.$("#hfproductattribute").attr("value", parent.$("#hfproductattribute").attr("value") + htmlJson);
            
            listHtml += "<div class=\"c\">";
            var urlvalue = $("#hfacolorimg").val().substring(0, $("#hfacolorimg").val().length - 1);
            if (urlvalue != '') {
                listHtml += "<img src=\"<%=ECommon.WebUploadTempUrl %>/" + urlvalue + "\" />";
            }
            listHtml += "<span style='display:block; float:left; width:40px;  color:" + $("#hfacolor").val() + "; margin-left:3px;'>" + $("#hfacolortitle").val() + "</span>";
            listHtml += "</div>";
            listHtml += "<span  class=\"m\">" + $("#txtamaterial").val() + "</span>";
            listHtml += "<span  class=\"s\">" + $("#txtalength").val();
            listHtml += "*" + $("#txtawidth").val();
            listHtml += "*" + $("#txtaheight").val() + "</span>";
            listHtml += "<span class=\"cbm\" >" + $("#txtacbm").val() + "立方米</span>";
            listHtml += "<span class=\"p\">&nbsp;￥" + $("#txtmarketprice").val() + "</span>";

            parent.$("#productattributelist >ul").append("<li title='" + htmlJson + "'>" + listHtml + "<span class='del'  onclick='delattribute(this)' >删</span><span class='up'></span></li>");

            parent.$.fancybox.close();

        });
    </script>
    </form>
</body>
</html>
