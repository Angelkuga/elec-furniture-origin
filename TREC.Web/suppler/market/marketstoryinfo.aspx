<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Member.Master"  CodeBehind="marketstoryinfo.aspx.cs" Inherits="TREC.Web.Suppler.market.marketstoryinfo" EnableEventValidation="false" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
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
                editor = K.create('#<%=txtdescript.ClientID %> ', {
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table class="formTable">
    <tr>
        <td align="right" width="70">
            请选择要添加的楼层：
        </td>
        <td width="200">
             <asp:DropDownList ID="droptitle" runat="server">
            <asp:ListItem Value="1楼">1楼</asp:ListItem>
            <asp:ListItem Value="2楼">2楼</asp:ListItem>
            <asp:ListItem Value="3楼">3楼</asp:ListItem>
            <asp:ListItem Value="4楼">4楼</asp:ListItem>
            <asp:ListItem Value="5楼">5楼</asp:ListItem>
            <asp:ListItem Value="6楼">6楼</asp:ListItem>
            <asp:ListItem Value="7楼">7楼</asp:ListItem>
            <asp:ListItem Value="8楼">8楼</asp:ListItem>
            <asp:ListItem Value="9楼">9楼</asp:ListItem>
            <asp:ListItem Value="10楼">10楼</asp:ListItem>
            </asp:DropDownList>
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
    <tr <%=ECommon.QueryEdit != ""?"":"style=\"display:none\"" %> >
        <td align="right">
            楼层图：<%--<a href="javascript:;" class="helper" title="点击查看产品缩略图片位置示意"><img src="../images/d10.gif"/></a>--%>
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

    <tr>
    <td>&nbsp;</td>
    <td>  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" OnClick="btnSave_Click" /> 
    <input name="重置" type="reset" class="submit" value="重置" /></td>
    </tr>
</table>
</asp:Content>