<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addBrandYM.aspx.cs" ValidateRequest="false" Inherits="TREC.Web.Suppler.brand.addBrandYM" %>

<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/base.css" rel="stylesheet" type="text/css" />
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/')%>/script/jquery-1.7.1.min.js"
        type="text/javascript"></script>
    <script type="text/javascript" src="../script/formValidator-4.1.1.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../script/formValidatorRegex.js" charset="UTF-8"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.area.js"></script>
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
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=brand&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'fullscreen']
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
                    data: "txttitle=" + brand.val() +"&companyid=<%= companyInfo.id%>"+"&id=<%= brandID%>",
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
</head>
<body>
    <form id="form1" runat="server">
    <%-- <div class="maintitle" style="width:595px;"><h1><u><%=myTitle%>品牌</u></h1></div> --%>
    <div style="width: 580px;">
        <div class="maintabcor">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12%" height="40" align="right">
                        &nbsp;品牌名称<span class="tip">*</span>
                    </td>
                    <td width="38%" style="text-align: left;">
                        <asp:TextBox ID="txttitle" runat="server" Width="340" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="40">
                        <asp:HiddenField ID="hfbannel" runat="server" />
                        品牌LOGO
                    </td>
                    <td>
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Brand, ECommon.QueryId, TREC.Entity.EnFilePath.Logo)%>">
                            <asp:HiddenField ID="hflogo" runat="server" />
                            <div class="fileTools" style="width: auto;">
                                <input type="text" class="input w205 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File2" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div>
                            <label>
                                (196*70像素)</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="40">
                        缩略图
                    </td>
                    <td>
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Brand, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
                            <asp:HiddenField ID="hfthumb" runat="server" />
                            <div class="fileTools" style="width: auto;">
                                <input type="text" class="input w205 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File4" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div>
                            <label>
                                (196*70像素)</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="40">
                        品牌形象广告
                    </td>
                    <td>
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Brand, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
                            <asp:HiddenField ID="hfdesimage" runat="server" />
                            <div class="fileTools" style="width: auto;">
                                <input type="text" class="input w205 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File1" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div>
                            <label>
                                (550*400像素)</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="40">
                        品牌资质
                    </td>
                    <td>
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Brand, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
                            <asp:HiddenField ID="hfsurface" runat="server" />
                            <div class="fileTools" style="width: auto;">
                                <input type="text" class="input w205 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File3" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div>
                            <label>
                                (550*400像素)</label>
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
                            Rows="8" Width="340" Height="120"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="btnone">
                            <asp:Button ID="btnSave" runat="server" CssClass="btnl" Text="提 交" OnClick="btnSave_Click"
                                OnClientClick="return checkbrand();" />
                            <input type="reset" class="btnr" value="重 填"></div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
