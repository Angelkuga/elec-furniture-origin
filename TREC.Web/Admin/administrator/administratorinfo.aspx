<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administratorinfo.aspx.cs" Inherits="TREC.Web.Admin.administrator.administratorinfo" %>
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
        });
    </script>
</head>
<body style="padding:10px;">
<form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="administratorlist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 系统管理 &gt; 管理员管理</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">管理员信息</th>
        </tr>
	    <tr>
	    <td width="160px" align="right">
		    登陆账号
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txtname" runat="server" CssClass="input"></asp:TextBox>
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    登陆密码
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txtpassword" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    姓名
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txtdisplayname" runat="server" CssClass="input"></asp:TextBox>
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    安全问题
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txtquestion" runat="server" CssClass="input"></asp:TextBox>
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    问题回答
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txtanswer" runat="server" CssClass="input"></asp:TextBox>
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    邮件
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txtemail" runat="server" CssClass="input"></asp:TextBox>
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    电话
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txtphone" runat="server" CssClass="input"></asp:TextBox>
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    地区
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txtareacode" runat="server" CssClass="input"></asp:TextBox>
	    </td></tr>
	    <tr>
	    <td width="160px" align="right">
		    地址
	    ：</td>
	    <td align="left">
		    <asp:TextBox id="txtaddress" runat="server" CssClass="input"></asp:TextBox>
	    </td></tr>
	    
	    <tr>
	    <td width="160px" align="right">
		    是否锁定
	    ：</td>
	    <td align="left">
		    <asp:RadioButtonList runat="server" ID="raIsLock" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Text="否" Value="0" Selected=True></asp:ListItem>
                <asp:ListItem Text="是" Value="1"></asp:ListItem>
            </asp:RadioButtonList>
	    </td></tr>
        <%if (ECommon.QueryEdit != "")
          { %>
          <tr>
	    <td width="160px" align="right">
		    其它信息
	    ：</td>
	    <td align="left">
		    <asp:Label ID="lbOther" runat="server"></asp:Label>
	    </td></tr>
        <%} %>
    </table>
    <div style="margin-top:10px; margin-left:180px">
  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
            onclick="btnSave_Click" /><input name="重置" type="reset" class="submit" value="重置" />
</div>
</form>
</body>
</html>
