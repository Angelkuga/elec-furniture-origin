<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportProduct.aspx.cs"
    Inherits="TREC.Web.Admin.product.ImportProduct" %>

<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/My97DatePicker/WdatePicker.js"></script>
    <script>
        //品牌下拉。获得系列及绑定品牌数据
        $("#ddlbrand").live("change", function () {
            $.ajax({
                url: '<%=TREC.ECommerce.ECommon.WebAdminUrl %>/ajax/ajaxuser.ashx',
                data: 'type=getbrands&v=' + $("#ddlbrand").val(),
                dataType: 'json',
                success: function (data) {
                    $("#ddlbrands").html("").hide().show();
                    $("#ddlbrands").append("<option value=\"\">请选择</option>");
                    $.each(data, function (i) {
                        if (data[i].id != "" && data[i].title != "") {
                            $("#ddlbrands").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                        }
                    });
                }
            });
        })

        //系列下拉。获得绑定系列数据
        $("#ddlbrands").live("change", function () {
            //alert($("#ddlbrands").val());
            $.ajax({
                url: '<%=TREC.ECommerce.ECommon.WebAdminUrl %>/ajax/ajaxuser.ashx',
                data: 'type=getMSC&v=' + $("#ddlbrands").val(),
                dataType: 'json',
                success: function (data) {
                    var m = "";
                    var s = "";
                    var c = "";
                    $.each(data, function (i) {
                        s = data[i].s;
                        m = data[i].m;
                        c = data[i].c;
                    });
                    $("#ddlstyle").val(s);
                    $("#ddlmaterial").val(m);
                    $("#ddlcolor").val(c);
                }
            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="back"><a href="memberlist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 成员管理 &gt;
            导入产品</b>
    </div>
    <div class="spClear">
    </div>
    <div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="formTable">
            <tr>
                <td align="right">
                </td>
                <td>
                    <asp:Label ForeColor="red" runat="server" ID="LbMsg"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 120px; *width: 150px;" align="right">
                    选择<b>品牌：</b>
                </td>
                <td>
                    <asp:DropDownList ID="ddlbrand" runat="server" CssClass="select" Width="85">
                    </asp:DropDownList>
                    <div class="info" style="display: none;">
                        <span class="ico">&nbsp;</span> 品牌选关选项必须选择&nbsp;&nbsp;
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right">
                    选择系列：
                </td>
                <td>
                    <asp:DropDownList ID="ddlbrands" runat="server" CssClass="select" Width="80">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlstyle" runat="server" CssClass="select" Width="85">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlmaterial" runat="server" CssClass="select" Width="150">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlcolor" runat="server" CssClass="select" Width="80">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    上传产品：
                </td>
                <td>
                    <asp:FileUpload ID="FileXLS" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td>
                    <asp:Button ID="BtnSave" runat="server" Text="上传" OnClick="BtnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
