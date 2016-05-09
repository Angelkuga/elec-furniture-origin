<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SJupfile.aspx.cs" Inherits="TREC.Web.template.web.SJupfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/resource/content/js/jquery-1.4.1.min.js"></script>
</head>
<body  style="margin:0 auto;">
    <form id="form1" runat="server">
    <img src="/resource/images/12.png"  onclick="fileupclick()"/>
    <div style="display:none;" id="divload">图片上传中....</div>
    <div id="upimg">
    <table border="0" cellpadding="0" cellspacing="0"><tr><td>
    
    <asp:FileUpload ID="FileUpload1" Width="120" runat="server"  onchange="filechangeclick();" /></td><td> <asp:Button ID="bnt_upfile" runat="server" onclick="bnt_upfile_Click" Text="上传"  Width="50px"  OnClientClick="loading()"/></td></tr></table>
   
    </div>

    <script language="javascript" type="text/javascript">
        var bb = '<%=filePath%>';
        if (bb != '') {
            window.parent.document.getElementById("<%=showtxt %>").value = bb;
            window.parent.document.getElementById("divimgup").innerHTML = '<img src="' + bb + '"  style="width:100px;"/>';
            // alert(bb);
            //  window.parent.document.getElementById("<%=showtxt %>").value = bb;
            // window.parent.document.getElementById("divfileup").style.display = "none";
        }
        function fileupclick() {
            $("#FileUpload1")[0].click();
        }
        function filechangeclick() {
            $("#bnt_upfile")[0].click();
        }
        function loading() {
            window.parent.document.getElementById("divimgup").style.display = "block";
            window.parent.document.getElementById("divimgup").innerHTML = "图片上传中...";
        }
    </script>

 
    </form>
</body>
</html>
