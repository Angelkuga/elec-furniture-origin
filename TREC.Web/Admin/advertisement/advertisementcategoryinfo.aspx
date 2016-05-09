<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="advertisementcategoryinfo.aspx.cs" Inherits="TREC.Web.Admin.advertisement.advertisementcategoryinfo" %>
<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>广告位信息</title>
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
        });
    </script>
</head>
<body style="padding:10px;">
<form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="advertisementcategorylist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 营销互动 &gt; 广告位管理</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">广告位信息</th>
        </tr>
	    <tr>
	    <td width="160px" align="right">
		    上级广告位
	    ：</td>
	    <td align="left">
            <asp:DropDownList ID="ddlParent" runat="server" CssClass="select w250"></asp:DropDownList>
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    所属模块
	    ：</td>
	    <td align="left">
		    <asp:DropDownList ID="ddlModule" runat="server" CssClass="select selectNone  w250"></asp:DropDownList>
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    广告位名称
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txttitle" runat="server"  CssClass="input required w250"></asp:TextBox>
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    位置展示
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txtimg" runat="server"  CssClass="input  w250"></asp:TextBox>
	    </td></tr>
        <tr>
	    <td width="160px" align="right">
		    广告位类型
	    ：</td>
	    <td align="left">
		    <asp:DropDownList ID="ddlAdType" runat="server" CssClass="select selectNone  w250"></asp:DropDownList>
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    开始时间
	    ：</td>
	    <td align="left">
		    <asp:TextBox ID="txtstarttime" runat="server" CssClass="input w250" ></asp:TextBox><img onclick="WdatePicker({el:'txtstarttime'})" src="<%=ECommon.WebAdminResourceUrl %>/My97DatePicker/skin/datePicker.gif" width="16" height="22" style=" cursor:pointer" align="absmiddle">
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    结束时间
	    ：</td>
	    <td align="left">
		    <asp:TextBox ID="txtendtime" runat="server" CssClass="input w250"></asp:TextBox><img onclick="WdatePicker({el:'txtendtime'})" src="<%=ECommon.WebAdminResourceUrl %>/My97DatePicker/skin/datePicker.gif" width="16" height="22" style=" cursor:pointer" align="absmiddle">
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    高
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txtheight" runat="server"  CssClass="input required number" Width="60"></asp:TextBox>(px)
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    宽
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txtwidth" runat="server"  CssClass="input required number" Width="60"></asp:TextBox>(px)
	    </td></tr>
        <tr>
	    <td width="160px" align="right">
		    是否开启
	    ：</td>
	    <td align="left">
		    <asp:RadioButtonList runat="server" ID="raOpen" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="否" Value="0"></asp:ListItem>
            </asp:RadioButtonList>
  	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    广告位描述
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txtdescript" runat="server"  CssClass="textarea w380" TextMode="MultiLine" Rows="3"></asp:TextBox>
	    </td></tr>
	    <tr style="display:none">
	    <td width="160px" align="right">
		    模版
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txttemplate" runat="server"  CssClass="input"></asp:TextBox>
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    排序
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txtsort" runat="server"  CssClass="input required number" Width="45">0 </asp:TextBox>
	    </td></tr>
    </table>
    <div style="margin-top:10px; margin-left:180px">
  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
            onclick="btnSave_Click" /><input name="重置" type="reset" class="submit" value="重置" />
</div>
</form>
</body>
</html>
