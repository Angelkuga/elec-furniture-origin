<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="../Member.Master"  CodeBehind="dealerinfo.aspx.cs" Inherits="TREC.Web.Suppler.dealer.dealerinfo"
    EnableEventValidation="false" %>
    <%@ MasterType VirtualPath="../Member.Master" %>
<%@ Import Namespace="TREC.ECommerce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <style type="text/css">
        .formTable
        {
            border: 1px solid #ccc;
        }
        .formTable tr th
        {
            background: #ededed;
            text-align: left;
        }
        .formTable tr td
        {
            border: none;
            padding-top: 8px;
            padding-bottom: 8px;
        }
    </style>
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
                editor = K.create('#<%= txtdescript.ClientID %>', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=company&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
                });
            });


            $("#btnSearch").click(function () {
                $.ajax({
                    url: "<%=ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx",
                    data: "type=getnoaddmember&v=" + $("#txtSearch").val(),
                    dataType: "json",
                    success: function (data) {
                        if (data != "") {
                            $("#ddlmember").html();
                            $("#ddlmember").html("<option value=\"\">请选择</option>");
                            $.each(data, function (i) {
                                $("#ddlmember").append("<option value=\"" + data[i].id + "\">" + data[i].name + "</option>");
                            });
                        }
                    }
                })
            })

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
    <table cellpadding="6" cellspacing="1" class="formTable">
        <tr>
            <td align="right" class="tl" width="160px">
                店铺名称：
            </td>
            <td class="tr  f_red">
               <div style="float:left;"><asp:TextBox ID="txttitle" runat="server" MaxLength="20" CssClass="input required w160"></asp:TextBox></div>
               <div style="float:left;color:#666666;">如：红苹果红星美凯龙真北路店</div>

            </td>
            <td rowspan="13" class="tr  f_red" valign="top">
                
            </td>
        </tr>
        <tr >
            <td align="right" class="tl">
                联系人：
            </td>
            <td class="tr  f_red">
                <asp:TextBox ID="txtlinkman" runat="server" CssClass="input w160"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                人员规格 ：
            </td>
            <td>
                <asp:DropDownList ID="ddlstaffsize" runat="server" CssClass="select selectNone" Width="160">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                注册年份：
            </td>
            <td>
                <asp:TextBox ID="txtregyear" runat="server" CssClass="input w160 required digits"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                注册城市：
            </td>
            <td>
                <asp:DropDownList ID="ddlPro" runat="server" CssClass="select">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlregcity" runat="server" CssClass="select selectNone">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="tl">
                联系手机 ：
            </td>
            <td class="tr  f_red">
                <asp:TextBox ID="txtmphone" runat="server" CssClass="input w160 digits"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="tl">
                联系电话 ：
            </td>
            <td class="tr  f_red">
                <asp:TextBox ID="txtphone" runat="server" CssClass="input w160"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="tl">
                传真 ：
            </td>
            <td class="tr  f_red">
                <asp:TextBox ID="txtfax" runat="server" CssClass="input w160"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="tl">
                邮箱 ：
            </td>
            <td class="tr  f_red">
                <asp:TextBox ID="txtemail" runat="server" CssClass="input w160 email"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="tl" >
                实体店地址：
            </td>
            <td class="tr  f_red">
                <div class="_droparea" id="ddlareacode" title="<%=areaCode %>">
                </div>
            </td>
        </tr>
        <tr>
            <td align="right" class="tl">
                详细地址：
            </td>
            <td class="tr  f_red">
                <asp:TextBox ID="txtaddress" runat="server" CssClass="input required" Width="260"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td align="right" class="tl">
                邮编 ：
            </td>
            <td class="tr  f_red">
                <asp:TextBox ID="txtpostcode" runat="server" CssClass="input w160 digits"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 110px;">
                代理授权证书：
            </td>
            <td>
                <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Dealer, dealerInfo.id, TREC.Entity.EnFilePath.Dbook)%>">
                    <asp:HiddenField ID="hfDBook" runat="server" />
                    <div class="fileTools" style="width: 310px">
                        <input type="text" class="input w160 filedisplay" />
                        <a href="javascript:;" class="files">
                            <input id="FileDBook" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                </div>
            </td>
        </tr>

        <tr>
        <td align="right" style="width: 110px;">
         缩&nbsp;略&nbsp;&nbsp;图：
        </td>
        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Company, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
                                <asp:HiddenField ID="hfthumb" runat="server" />
                                <div class="fileTools" style="width: 310px">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files">
                                        <input id="File3" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                                    <span class="uploading">上传中</span>
                                </div>
                            </div>
                        </td>
        </tr>

        <tr>
           <td align="right">
              广告幻灯：
            </td>
         <td>
         <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Company, ECommon.QueryId, TREC.Entity.EnFilePath.Banner)%>">
           <asp:HiddenField ID="hfbannel" runat="server" />
          <div class="fileTools" style="width: 310px">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files">
                                        <input id="File4" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                                    <span class="uploading">上传中</span>
                                </div>
                            </div>
                        </td>
                    </tr>

        <tr style="display: none">
            <td align="right" class="tl">
                工厂网站 ：
            </td>
            <td class="tr  f_red">
                <asp:TextBox ID="txthomepage" runat="server" CssClass="input w160"></asp:TextBox>(以http://开始)
            </td>
        </tr>
        <tr>
            <td align="right" class="tl" valign="top">
                介绍 ：
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea required" TextMode="MultiLine"
                    Rows="5" Width="660" Height="220"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right" class="tl">
                审核：
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlauditstatus" runat="server" CssClass="select" Width="160"
                    Enabled="false">
                </asp:DropDownList>
            </td>
        </tr>
    </table>

    
    <div style="margin-top: 10px; margin-left: 80px">
        <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" OnClick="btnSave_Click" /><input
            name="重置" type="reset" class="submit" value="重置" />
    </div>
</asp:Content>