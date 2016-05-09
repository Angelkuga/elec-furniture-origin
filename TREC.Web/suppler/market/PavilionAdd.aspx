<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="PavilionAdd.aspx.cs" ValidateRequest="false" Inherits="TREC.Web.Suppler.market.PavilionAdd" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<%@ Import Namespace="TREC.ECommerce" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../resource/css/ymPrompt/simple_gray/ymPrompt.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/Aliyunfileupload.js"></script>
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/')%>/script/ymPrompt.js" type="text/javascript"></script>
    <style>
        .txtinput
        {
            width: 400px;
        }
        .marketlist
        {
            width: 200px;
            float: left;
        }
        .tip
        {
            color: Red;
            font-weight: bold;
        }
    </style>

    <script type="text/javascript">
        $(function () {
            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('#<%=txtdescript.ClientID %>', {
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
				'insertunorderedlist', '|', 'link', 'image', 'fullscreen']
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%=alertmsg%>
    <div class="maintitle">
        <h1>
            <u>卖场场馆：<asp:HiddenField ID="hidId" runat="server" />
            </u>
        </h1>
    </div>

     <table width="100%" border="0" cellpadding="3" cellspacing="3">
        <tr>
            <td align="right" onclick="testkk()" style="width:100px;">
                场馆名称：
            </td>
            <td align="left">
            <div style="float:left;width:160px;">
                <asp:TextBox ID="txttitle" runat="server" CssClass="input required w250" onblur="MarketCliqueCheck()"></asp:TextBox>
                </div>
                <div style="float:left;" id="divmarketmsg"></div>
                <span class="tip">*</span>
            </td>
        </tr>

        
        <tr>
            <td align="right">
                展示大图片：
            </td>
            <td align="left">
                <div class="fileUpload" path="">
                    <asp:HiddenField ID="hideBannelimg" runat="server" />
                    <div class="fileTools" style="width: 310px">
                        <input type="text" class="input w250 filedisplay"  id="mklogimg"/>
                        <a href="javascript:;" class="files">
                            <input id="File4" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                </div>
                (建议图片尺寸为：宽1200 
                * 高486像素)
            </td>
        </tr>


        <tr>
            <td align="right">
                缩略图：
            </td>
            <td align="left">
                <div class="fileUpload" path="">
                    <asp:HiddenField ID="hfthumbimg" runat="server" />
                    <div class="fileTools" style="width: 310px">
                        <input type="text" class="input w250 filedisplay"  id="mkthumbimg"/>
                        <a href="javascript:;" class="files">
                            <input id="File1" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                </div>
                (建议图片尺寸为：宽230 * 高135像素)
            </td>
        </tr>


        <tr>
            <td align="right" valign="top">
                场馆介绍：
            </td>
            <td align="left" id="tddescriptv">
                <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea required kinkeditor"
                    TextMode="MultiLine" Rows="5" Width="500" Height="220"></asp:TextBox>
            </td>
        </tr>


        <tr id="trbnt" runat="server">
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="btnl"  
                    OnClientClick="return chkForm();" onclick="btnSave_Click" />
                <input id="loadmarket" type="hidden" name="loadmarket" />
            </td>
        </tr>

        </table>
</asp:Content>
