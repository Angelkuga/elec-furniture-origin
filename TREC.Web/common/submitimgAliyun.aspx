<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="submitimgAliyun.aspx.cs" Inherits="TREC.Web.common.submitimgAliyun" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td>本地</td><td><asp:FileUpload ID="FileUpload1"  runat="server"   /></td><td>
        <asp:Button ID="bnt_bd" runat="server" Text="提交" Width="75px" 
            onclick="bnt_bd_Click" /></td>
    </tr>
    </table>

    <br /><br />
    <table>
    <tr>
    <td>远程</td><td>
        <asp:TextBox ID="txt_yc" runat="server" Width="622px"></asp:TextBox>  </td><td>
        <asp:Button ID="bnt_yc" runat="server" Text="提交" Width="75px" 
                onclick="bnt_yc_Click" /></td>
    </tr>
    </table>

    <br />生成地址：<br /><br />
    <%=filePath%>

    </div>
    </form>
</body>
</html>
