<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="configinfo.aspx.cs" Inherits="TREC.Web.Admin.config.configinfo" EnableEventValidation="false" %>
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

            $("#ddlmodule").live("change", (function () {
                if ($(this).val() != "" && $(this).val() != "0") {
                    $.ajax({
                        url: "<%=TREC.ECommerce.ECommon.WebAdminUrl %>/ajax/ajaxconfig.ashx",
                        data: "type=getConfigModuleType&module=" + $(this).val(),
                        dataType:"json",
                        success: function (data) {
                            $("#ddltype").hide();
                            $("#ddltype").show();
                            if (data != "") {
                                $("#ddltype").html();
                                $("#ddltype").html("<option value=\"0\">请选择</option>");
                                $.each(data, function (i) {
                                    $("#ddltype").append("<option value=\"" + data[i].id + "\">" + data[i].name + "</option>");
                                });
                            }
                        }
                    });
                }

            }));


        });


    </script>
</head>

<body style="padding:10px;">
<form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="configlist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 系统管理 &gt; 配置管理</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">配置信息</th>
        </tr>
        <tr>
	        <td width="160px" align="right">配置名称：</td>
	        <td align="left">
		        <asp:TextBox id="txttitle" runat="server" CssClass="input"></asp:TextBox>
	        </td>
        </tr>
        <tr>
            <td align="right">
                配置值 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtvalue" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                所属模块 ：
            </td>
            <td  align="left">
                <asp:DropDownList ID="ddlmodule" runat="server" CssClass="select selectNone"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                配置类型 ：
            </td>
            <td  align="left">
                <asp:DropDownList ID="ddltype" runat="server"  CssClass="select selectNone"></asp:DropDownList>
            </td>
        </tr>
	   <tr>
	        <td align="right">排序：</td>
	        <td align="left">
		        <asp:TextBox id="txtsort" runat="server" Width="40px" CssClass="input">0</asp:TextBox>
	        </td>
      </tr>
    </table>
    <div style="margin-top:10px; margin-left:180px">
  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
            onclick="btnSave_Click" /><input name="重置" type="reset" class="submit" value="重置" />
</div>
</form>
</body>
</html>
