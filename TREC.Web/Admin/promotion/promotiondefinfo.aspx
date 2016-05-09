<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotiondefinfo.aspx.cs" Inherits="TREC.Web.Admin.promotion.promotiondefinfo" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设置关联信息</title>
    <link rel="Stylesheet" type="text/css" href="../css/style.css" />
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

            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('#txtdescript', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=company&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
                });
            });
            var editor2;
            KindEditor.ready(function (K) {
                editor2 = K.create('#txttitle', {
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist','link', 'fullscreen']
                });
            });
        });
    </script>
    <style>
        .fileUpload{float:left; width:380px}
    </style>
</head>
<body style="padding:10px;">
<form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="promotiondeflist.aspx?pid=<%=ECommon.QueryPId %>">返回列表</a></span><b>您当前的位置：首页 &gt; 促销活动 &gt; 促销活动信息</b>
    </div>
    <div class="spClear"></div>
<div class="info">
    <span>活动：<strong><%=modelPInfo.title%></strong></span>
    <span>开始时间：<strong><%=modelPInfo.startdatetime%></strong></span>
    <span>结束时间：<strong><%=modelPInfo.enddatetime%></strong></span>
</div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">
                设置活动范围
            </th>
        </tr>
        <tr>
            <td width="70" align="right">
                活动类型：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddltype" runat="server" CssClass="select" Width="60px"></asp:DropDownList>
                <asp:TextBox ID="txtsearch" runat="server" CssClass="input"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="查找" onclick="btnSearch_Click" /><br>
                
            </td>
        </tr>
        <tr>
            <td align="right">选择结果：</td>
            <td><asp:DropDownList ID="ddlvalue" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right">推荐选项：</td>
            <td><asp:CheckBoxList ID="chkattribute" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList></td>
        </tr>
        <tr>
            <td align="right">标题：</td>
            <td>
                <asp:TextBox ID="txttitle" runat="server" CssClass="textarea" TextMode="MultiLine" style="width:660px; height:100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">缩略图：</td>
            <td>
                <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.PromotionDef, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
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
            <td align="right">幻灯图：</td>
            <td>
                <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.PromotionDef, ECommon.QueryId, TREC.Entity.EnFilePath.Banner)%>">
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
            <td align="right">描述：</td>
            <td>
                <asp:TextBox ID="txtdescript" runat="server" TextMode="MultiLine" CssClass="textarea" style="width:660px; height:220px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">排序：</td>
            <td>
                <asp:TextBox ID="txtsort" runat="server" CssClass="input" Width="40">0</asp:TextBox>
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
