<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="smssend.aspx.cs" Inherits="TREC.Web.Admin.sms.smssend" %>
<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/messages_cn.js"></script>
    <script type="text/javascript">
        function Validate() {
            var txtphone = $("#txtphone").val();
            var txtcontent = $("#txtcontent").val();

            if (txtphone == "") {
                alert('抱歉，发送号码不能为空！');
                $("#txtphone").focus();
                return false;
            }
            if (txtcontent == "") {
                alert('抱歉，短信内容不能为空！');
                $("#txtcontent").focus();
                return false;
            }
            if (txtcontent.length>250) {
                alert('抱歉，短信内容长度不能超过250个字！');
                $("#txtcontent").focus();
                return false;
            }
            return true;
        };
        function Reset() {
            $("#txtphone").val() = "";
            $("#txtcontent").val() = "";
        }
    </script>
</head>
<body style="padding:10px;">
<form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="smslist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 短信管理 &gt; 短信编辑</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">短信编辑</th>
        </tr>
        <tr>
	        <td width="100px" align="right">发送号码：</td>
	        <td >
		        <asp:TextBox id="txtphone" runat="server" CssClass="input w160 required" 
                    Width="480px"></asp:TextBox>
	        </td>
        </tr>
        <tr>
            <td align="right">
                短信内容 ：
            </td>
            <td height="25" width="*">
                <asp:TextBox ID="txtcontent" runat="server" CssClass="input w160 required" 
                    Height="110px" TextMode="MultiLine" Width="480px"></asp:TextBox>

            </td>
        </tr>
    </table>
    <div style="margin-top:10px; margin-left:110px">
  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
            onclick="btnSave_Click" OnClientClick="return Validate();" /><input name="重置" type="reset" onclick="Reset();" class="submit" value="重置" />
</div>
</form>
</body>
</html>
