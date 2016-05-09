<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setup2.aspx.cs" Inherits="TREC.Web.Suppler.f_market.setup2" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register src="nav.ascx" tagname="nav" tagprefix="uc2" %>
<%@ Register src="../ascx/head.ascx" tagname="head" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/fileupload.js"></script>
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
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=market&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|',  'link', 'fullscreen']
                });
            });

            $("#ddlPro").live("change", function () {
                if ($(this).val() != "" && $(this).val() != "0") {
                    $.ajax({
                        url: "<%=ECommon.WebSupplerUrl %>/ajaxtools/ajaxarea.ashx",
                        data: "type=c&p=" + $(this).val(),
                        success: function (data) {
                            $("#ddlregcity").html(data)
                        },
                        error: function (d, m) {
                            alert(m);
                        }
                    });
                }
            })
        });
    </script>
</head>
<body style="height: auto">
    <form id="form1" runat="server">
     <uc1:head ID="head2" runat="server" />
<div class="Fcon setup">
        <div class="setupTitle">
            &nbsp;&nbsp;欢迎您进入家具快搜供应商管理系统，请先按顺序添加完成以下内容，以便正式上传产品。
        </div>
        <div class="setupNext">
            <uc2:nav ID="nav1" runat="server" />
        </div>
        <div class="setupCon">
    <table class="formTable">
    <tr>
        <td align="right" width="70">
            楼层数：
        </td>
        <td width="300">
            <asp:DropDownList ID="droptitle" runat="server">
            <asp:ListItem Value="1">1</asp:ListItem>
            <asp:ListItem Value="2">2</asp:ListItem>
            <asp:ListItem Value="3">3</asp:ListItem>
            <asp:ListItem Value="4">4</asp:ListItem>
            <asp:ListItem Value="5">5</asp:ListItem>
            <asp:ListItem Value="6">6</asp:ListItem>
            <asp:ListItem Value="7">7</asp:ListItem>
            <asp:ListItem Value="8">8</asp:ListItem>
            <asp:ListItem Value="9">9</asp:ListItem>
            <asp:ListItem Value="10">10</asp:ListItem>
            </asp:DropDownList>
            <label>&nbsp;&nbsp;&nbsp;请选择您的卖场一共有多少层</label>
        </td>
    </tr>
    <tr style="display:none">
        <td align="right" valign="top">
            形&nbsp;象&nbsp;&nbsp;图：
        </td>
        <td>
            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.MarketStorey, ECommon.QueryId, TREC.Entity.EnFilePath.Surface)%>">
                <asp:HiddenField ID="hfsurface" runat="server" />
                <div class="fileTools" style="width:310px">
                    <input type="text" class="input w160 filedisplay" />
                    <a href="javascript:;" class="files">
                        <input id="File1" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                    <span class="uploading">上传中</span>
                </div>
            </div>
        </td>
    </tr>
    <tr style="display:none">
        <td width="70px" align="right">
            企业标志：
        </td>
        <td>
            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.MarketStorey, ECommon.QueryId, TREC.Entity.EnFilePath.Logo)%>">
                <asp:HiddenField ID="hflogo" runat="server" />
                <div class="fileTools" style="width:310px">
                    <input type="text" class="input w160 filedisplay" />
                    <a href="javascript:;" class="files">
                        <input id="File2" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                    <span class="uploading">上传中</span>
                </div>
            </div>
        </td>
    </tr>
    <tr style="display:none">
        <td align="right">
            楼层图：<a href="javascript:;" class="helper" title="点击查看产品缩略图片位置示意"><img src="../images/d10.gif" /></a>
        </td>
        <td>
            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.MarketStorey, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
                <asp:HiddenField ID="hfthumb" runat="server" />
                <div class="fileTools" style="width:310px">
                    <input type="text" class="input w160 filedisplay" />
                    <a href="javascript:;" class="files">
                        <input id="File3" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                    <span class="uploading">上传中</span>
                </div>
            </div>
        </td>
    </tr>
    <tr style="display:none">
        <td align="right">
            广告幻灯：
        </td>
        <td>
            <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.MarketStorey, ECommon.QueryId, TREC.Entity.EnFilePath.Banner)%>">
                <asp:HiddenField ID="hfbannel" runat="server" />
                <div class="fileTools" style="width:310px">
                    <input type="text" class="input w160 filedisplay" />
                    <a href="javascript:;" class="files">
                        <input id="File4" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                    <span class="uploading">上传中</span>
                </div>
            </div>
        </td>
    </tr>
    <tr style="display:none">
        <td align="right">
            企业展示：
        </td>
        <td>
            <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.MarketStorey, ECommon.QueryId, TREC.Entity.EnFilePath.DesImage)%>">
                <asp:HiddenField ID="hfdesimage" runat="server" />
                <div class="fileTools" style="width:310px">
                    <input type="text" class="input w160 filedisplay" />
                    <a href="javascript:;" class="files">
                        <input id="File5" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                    <span class="uploading">上传中</span>
                </div>
            </div>
        </td>
    </tr>
    <tr style="display:none">
        <td align="right">
            排序：
        </td>
        <td>
            <asp:TextBox ID="txtsort" runat="server" CssClass="input required w160">0</asp:TextBox>
        </td>
    </tr>
    <tr style="display:none">
        <td align="right">
            楼层描述：
        </td>
        <td>
            <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea required" TextMode="MultiLine"
                Rows="5" Width="660" Height="220"></asp:TextBox>
        </td>
    </tr>
</table>
    <div style="margin-top: 10px; margin-left: 180px">
        <asp:Button ID="btnSave" runat="server" Text="" CssClass="submit" OnClick="btnSave_Click" />
    </div>
    <div class="clear"></div>
    <div class="foot" style=" position:static; left:0px; background:#f4f4f4; bottom:0px; right:0px; width:100%; height:30px; display:none">
        底部
    </div>
    </form>
</body>
</html>