<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addBaoMing.aspx.cs" Inherits="TREC.Web.addBaoMing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>活动报名</title>
    <style>
        body
        {
            overflow: hidden;
            margin: 0px auto;
            background:#FFFFFF;
        }
html, body, div, h1, h2, h3, h4, h5, h6, ul, ol, dl, li, dt, dd, p, blockquote, pre, form, fieldset, table, th, td {
	margin: 0;
	padding: 0;
}
body {
	behavior: url(ie6hover.htc);
	font-size: 12px;
	font-family: "宋体";
_
}
*html {
	overflow: hidden;
}
html {
	overflow-x: hidden;
}
td, th, div {
	word-break: break-all;
	white-space: normal;
	word-wrap: break-word;
	overflow: hidden;
}
li, dd {
	list-style-type: none;
}
input[type=text], input[type=password] {
	background-color: #F4f4f4;
}
.xx {
	width: 292px;
	height: 359px;
	margin: 0 auto;
	padding: 160px 40px 0;
	background: url(/resource/images/kk.gif) no-repeat;
	color: #996533;
	font-family: 微软雅黑;
	font-size: 15px;
}
.xx p {
	margin: 10px 0;
}
.xx input {
	height: 24px;
	border: 1px solid #996533;
	vertical-align: middle;
	width: 200px;
	margin-left: 10px;
}
.xxinput {
	height: 64px;
	border: 1px solid #996533;
	vertical-align: middle;
	width: 200px;
	margin-left: 10px;
}
.xx1{ margin:20px auto; color:#000;text-align:center;}
.guanb
        {
            position: absolute;
            right: 10px;
            top: -1px;
        }
</style>
    <script src="/resource/content/js/core.js"></script>
    <script type="text/javascript">
        function chkvalue() {
            var uname = $("#<%=uname.ClientID%>");
            if (uname.val() == "") {
                alert("姓名必须填写！"); uname.focus(); return false;
            }
            var umobile = $("#<%=umobile.ClientID%>");
            if (umobile.val() == "") {
                alert("手机必须填写！"); umobile.focus(); return false;
            }
            if (umobile.val().length != 11) {
                alert("手机必须11位！"); umobile.focus(); return false;
            }
            var uaddress = $("#<%=uaddress.ClientID%>");
            if (uaddress.val() == "") {
                alert("送货地址必须填写！"); uaddress.focus(); return false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="xx">
        <p>
            您的姓名:
            <asp:TextBox ID="uname" runat="server"></asp:TextBox>
            <asp:HiddenField ID="uid" runat="server" />
            <asp:HiddenField ID="prodID" runat="server" Value="" />
            <asp:HiddenField ID="prodTitle" runat="server" Value="" />
            <asp:HiddenField ID="prodURL" runat="server" Value="" />
            <asp:HiddenField ID="prodCon" runat="server" Value="" />
        </p>
        <p>
            您的手机:
            <asp:TextBox ID="umobile" runat="server"></asp:TextBox>
        </p>
        <p>
            送货地址:
            <asp:TextBox ID="uaddress" runat="server"></asp:TextBox>
        </p>
        <p>
            需求产品:
            <asp:TextBox ID="uneedProduct" TextMode="MultiLine" CssClass="xxinput" runat="server"></asp:TextBox>
        </p>
        <div class="xx1">
            <p>
                <asp:ImageButton runat="server" ID="imgbtn" ImageUrl="/resource/images/bb.gif" Width="244"
                    Height="55" OnClick="submit_Click" OnClientClick="return chkvalue();" />
            </p>
            <p>
                <%if (_counts == 0)
                  { %>
                目前还没有人报名，马上抢先
                <%}
                  else
                  { %>
                目前已有<%=_counts%>人报名
                <%} %>
                <br />
                活动客服QQ：2285277787
            </p>
        </div>
    </div>
    
    <div class="guanb">
        <img src="/resource/images/close.gif" width="42" height="16" alt="" onclick="window.parent.funclose('divsj');" /></div>
    </form>
</body>
</html>
