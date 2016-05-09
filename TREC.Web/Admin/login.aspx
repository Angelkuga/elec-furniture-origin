<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TREC.Web.Admin.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>-后台登陆</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
</head>
<body>
<form id="form1" runat="server">
<div id="login_body">
	<div id="login_div">
		<div id="login_form_div">
				<table border=0 width="300">
				<tbody>
				<tr>
					<td width="170">
                    	管理员帐号<br />
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="login_input required" title="请输入登陆名！"
                            HintTitle="请输入登录帐号" HintInfo="用户名必须是字母或数字，不能包含空格或其它非法字符，不区分大小写。"></asp:TextBox>
                        <BR>   
                        管理密码<br />
                            <asp:TextBox ID="txtUserPwd" runat="server" CssClass="login_input required" title="请输入密码！" 
                            HintTitle="请输入登录密码" HintInfo="登录密码必须>=6位且是字母或数字，不能包含空格或其它非法字符，不区分大小写。" 
                            TextMode="Password"></asp:TextBox><br />
                    </td>
                    <td align="left">
                        <asp:ImageButton ID="loginsubmit" runat="server" CssClass="login_btn" 
                            ImageUrl="images/login_btn.gif" onclick="loginsubmit_Click"  />
                    </td>
                </tr>
				<tr>
				  <td colspan="2" class="tipbox" style="background:url(Images/hint.gif) 0 6px no-repeat; padding-left:15px;">提示：<asp:Label ID="lbMsg" 
                          runat="server" Text="登录失败3次，需关闭后才能重新登录"></asp:Label><br><span class="msg"></span>
                    </td>
				  </tr>
				</tbody>
                </table>
		</div>
	</div>
	<div id="login_footer">福家网 © 2010 - 2011 fujiawang.com Inc.</div>
</div>
</form>
</body>
</html>
