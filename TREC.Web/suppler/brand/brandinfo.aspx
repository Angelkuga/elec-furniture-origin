<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Member.Master" CodeBehind="brandinfo.aspx.cs"
    Inherits="TREC.Web.Suppler.brand.brandinfo" EnableEventValidation="false" ValidateRequest="false" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../script/formValidator-4.1.1.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../script/formValidatorRegex.js" charset="UTF-8"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
    <%--<script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.area.js"></script>--%>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/fileupload.js"></script>
    <script type="text/javascript" src="../script/supplercommon.js"></script>
    <script type="text/javascript" src="../script/pageValitator/company-brand.js"></script>
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
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/editor/kindeditor/ashx/file_manager_json.ashx?m=brand&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
                });
            });
        });
        function checkbrand()
        {
            var chkreturn= true;
            var brand=$("#<%=txttitle.ClientID %>");
            if(brand.val()=="") {
                alert("请输入品牌名称!");
                brand.focus();
                chkreturn = false;
            }
            if(brand.val()!=""){
                $.ajax({
                    url: "/suppler/ajax/ajaxSupplerValidator.ashx?type=checkbrandtitlecompany",
                    data: "txttitle=" + brand.val() +"&companyid=<%=companyInfoid%>"+"&id=<%=brandID%>",
                    dataType: 'html',
                    async:false,
                    success: function (data) {
                        if (data == "该品牌名称己存在!")
                        {
                            alert(data);
                            brand.focus();
                            chkreturn = false;   
                        }
                        
                    }
                }); 
            }
            var ddlspread=$("#<%=ddlspread.ClientID %> option:checked");
            if (ddlspread.val()=="") {
                alert("请选择品牌档次!");
                ddlspread.focus();
                chkreturn = false;
            }
            //品牌描述
            var descript = $.trim($(document.getElementsByTagName('iframe')[0].contentWindow.document.body).html());
            if (descript.toString() == '' || descript == '<br>') {
                alert('抱歉，请输入品牌描述！');
                chkreturn = false;
            }
            return chkreturn;
       }
    </script>
    <style type="text/css">
        .w205
        {
            width: 205px;
        }
        .fileTools a._filedel, .fileTools a._filesee
        {
            display: block;
        }
        .fileUpload label
        {
            color: #888888;
            float: left;
            display: block;
            margin-left: 5px;
        }
        .fileUpload .fileTools
        {
            overflow: hidden;
        }
        .tip
        {
            color: Red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maintitle">
        <h1>
            <u>
                <%=myTitle%>品牌</u></h1>
    </div>
    <div class="maincon">
        <div class="maintabcor">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12%" height="40" align="right">
                        &nbsp;品牌名称<span class="tip">*</span>
                    </td>
                    <td width="88%" style="text-align: left;">
                        <asp:TextBox ID="txttitle" runat="server" Width="340" MaxLength="50" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="40" valign="top">
                        <asp:HiddenField ID="hfbannel" runat="server" />
                        品牌LOGO
                    </td>
                    <td >
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Brand, ECommon.QueryId, TREC.Entity.EnFilePath.Logo)%>">
                            <asp:HiddenField ID="hflogo" runat="server" />
                            <div class="fileTools" style="width: auto;">
                                <input type="text" class="input w205 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File2" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div>
                           
                            <label>
                                (宽215 * 高50像素)</label>
                                 <br />
                                  <label style="padding-left:255px;">【对应店铺首页的品牌商标或LOGO位置】</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="40" valign="top">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                        缩略图
                    </td>
                    <td>
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Brand, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
                            <asp:HiddenField ID="hfthumb" runat="server" />
                            <div class="fileTools" style="width: auto;">
                                <input type="text" class="input w205 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File4" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div>
                           
                            <label>
                                (宽215* 高105像素)</label>
                                 <br />
                                <label style="padding-left:255px;">
                                【对应店铺首页的品牌商标或LOGO位置左侧的代表性产品缩略图】</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="40">
                        品牌形象广告
                    </td>
                    <td>
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Brand, ECommon.QueryId, TREC.Entity.EnFilePath.DesImage)%>">
                            <asp:HiddenField ID="hfdesimage" runat="server" />
                            <div class="fileTools" style="width: auto;">
                                <input type="text" class="input w205 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File1" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div>
                            <label>
                                (高947×449像素)</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="40">
                        品牌资质
                    </td>
                    <td>
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Brand, ECommon.QueryId, TREC.Entity.EnFilePath.Surface)%>">
                            <asp:HiddenField ID="hfsurface" runat="server" />
                            <div class="fileTools" style="width: auto;">
                                <input type="text" class="input w205 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File3" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div>
                            <label>
                                (高550×400像素)</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="50">
                        品牌档位<span class="tip">*</span>
                    </td>
                    <td style="text-align: left;">
                        <asp:DropDownList ID="ddlspread" runat="server" CssClass="select selectNone">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        品牌介绍<span class="tip">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea " TextMode="MultiLine"
                            Rows="8" Width="98%" Height="220"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="btnone">
                            <asp:Button ID="btnSave" OnClientClick="return checkbrand()" runat="server" CssClass="btnl"
                                Text="提 交" OnClick="btnSave_Click" /><input type="reset" class="btnr" value="重 填"></div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
