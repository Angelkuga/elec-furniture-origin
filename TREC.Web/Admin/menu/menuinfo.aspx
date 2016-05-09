<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menuinfo.aspx.cs" Inherits="TREC.Web.Admin.dealer.menuinfo" %>
<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            //表单验证JS
            $("#form1").validate({
                //出错时添加的标签
                errorElement: "span",
                showErrors: function (errorMap, errorList) {
                    if (errorList.length > 0) {
                        if ($("#" + errorList[0].element.id).next() != null) {
                            $("#" + errorList[0].element.id).next().remove();
                        }
                    }
                    this.defaultShowErrors();
                },
                success: function (label) {
                    //正确时的样式
                    label.text(" ").addClass("success");
                }
            });

            $("#ddlmodule").live("change", function () {
                if ($(this).val() != "" && $(this).val() != "0") {
                    $.ajax({
                        url: "../ajax/adminajax.ashx",
                        data: "type=getmodulerootmenu&v=" + $(this).val(),
                        success: function (data) {
                            if (data != "") {
                                $("#ddlparent").hide();
                                $("#ddlparent").show();
                                $("#ddlparent").html("<option value=\"\">请选择</option>");
                                $.each(data, function (i) {
                                    $("#ddlparent").append("<option value=\"" + data[i].id + "\">" + data[i].name + "</option>");
                                });
                            }
                        },
                        dataType:"json",
                        error: function (d, m) {
                            alert(m);
                        }
                    });
                }
            })


        });
    </script>
    <style type="text/css">
        .formTable{border:1px solid #ccc;}
        .formTable tr th{background:#ededed; text-align:left;}
        .formTable tr td{border:none; padding-top:8px; padding-bottom:8px;}
    </style>
</head>
<body style="padding:10px;">
<form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="menulist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 系统管理 &gt; 菜单管理</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="3" align="left">菜单信息</th>
        </tr>
        <tr>
            <td width="120" align="right">
                名称 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txttitle" runat="server" CssClass="w160 input required"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                标识 ：
            </td>
            <td >
                <asp:TextBox ID="txtmark" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                所属模块 ：
            </td>
            <td >
                <asp:DropDownList ID="ddlmodule" runat="server" CssClass="select selectNone"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                上级菜单 ：
            </td>
            <td >
                <asp:DropDownList ID="ddlparent" runat="server" CssClass="select selectNone"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                级别 ：
            </td>
            <td >
                <asp:TextBox ID="txtlev" runat="server" CssClass="input digits required"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                连接地址 ：
            </td>
            <td >
                <asp:TextBox ID="txturl" runat="server" CssClass="input w380 required"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                描述 ：
            </td>
            <td >
                <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea w380" TextMode="MultiLine" Rows="4"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                排序 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtsort" runat="server" CssClass="w160 input required digits">0</asp:TextBox>
            </td>
        </tr>
    </table>
    
    <div style="margin-top:10px; margin-left:140px">
  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
            onclick="btnSave_Click" /><input name="重置" type="reset" class="submit" value="重置" />
</div>
</form>
</body>
</html>
