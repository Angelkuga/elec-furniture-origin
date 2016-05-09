<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aggregationinfo.aspx.cs" Inherits="TREC.Web.Admin.aggregation.aggregationinfo" %>
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
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/script/fileupload.js"></script>
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
      <span class="back"><a href="aggregationlist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 信息管理 &gt; 聚合信息</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">聚合信息</th>
        </tr>
        <tr>
            <td  width="160"  align="right">
                所属模块：
            </td>
            <td  align="left">
                <asp:DropDownList ID="ddltype" runat="server" CssClass="select"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td  width="160"  align="right">
                信息标题 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txttitle" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                信息副标题1 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txttitle1" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                信息副标题2 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txttitle2" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                信息副标题3 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txttitle3" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                图片 ：
            </td>
            <td  align="left">
                <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Aggregation, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
                    <asp:HiddenField ID="hfthumb" runat="server" />
                    <div class="fileTools">
                        <input type="text" class="input w160 filedisplay" />
                        <a href="javascript:;" class="files"><input id="File3" type="file" class="upload" onchange="_upfile(this)"  runat="server" /></a>
                        <span class="uploading">正在上传，请稍后……</span>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td  align="right">
                图片宽 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtthumbw" runat="server" CssClass="input" Width="60">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                图片高 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtthumbh" runat="server" CssClass="input" Width="60">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                幻灯图 ：
            </td>
            <td  align="left">
                <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Aggregation, ECommon.QueryId, TREC.Entity.EnFilePath.Banner)%>">
                    <asp:HiddenField ID="hfbannel" runat="server" />
                    <div class="fileTools">
                        <input type="text" class="input w160 filedisplay" />
                        <a href="javascript:;" class="files"><input id="File4" type="file" class="upload" onchange="_upfile(this)"  runat="server" /></a>
                        <span class="uploading">正在上传，请稍后……</span>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td  align="right">
                连接地址 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txturl" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                连接地址1 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txturl1" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr><tr>
            <td  align="right">
                连接地址2 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txturl2" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                描述 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtdescript" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                排序 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtsort" runat="server" CssClass="input" Width="60">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                点击量 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txthits" runat="server" CssClass="input" Width="60">0</asp:TextBox>
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
