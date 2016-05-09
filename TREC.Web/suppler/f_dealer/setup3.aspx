<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setup3.aspx.cs" Inherits="TREC.Web.Suppler.f_dealer.setup3" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>


<%@ Register Src="../ascx/headNoLog.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register src="nav.ascx" tagname="nav" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=ECommon.WebTitle%>-商务中心</title>
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
    <script type="text/javascript" src="../script/supplercommon.js"></script>

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
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=brands&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|',  'link', 'fullscreen']
                });
            });
        });
    </script>
</head>
<body>
<form id="form1" runat="server">
    <uc1:head ID="head1" runat="server" />
    <div class="Fcon setup">
        <div class="setupTitle">
            &nbsp;&nbsp;欢迎您进入家具快搜供应商管理系统，请先按顺序添加完成以下内容，以便正式上传产品。
        </div>
        <div class="setupNext">
            <uc2:nav ID="nav1" runat="server" />
        </div>
        <div class="setupCon">
            <table width="100%" class="formTable">
                <tr>
                    <td align="right" width="70">
                        选择品牌：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlbrand" runat="server" CssClass="select selectNone" Width="160">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        系列名称：
                    </td>
                    <td>
                        <asp:TextBox ID="txttitle" runat="server" CssClass="input required w160"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">风格/材质：</td>
                    <td>
                        <asp:DropDownList ID="ddlstyle" runat="server" CssClass="select"></asp:DropDownList>
                        <asp:DropDownList ID="ddlmaterial" runat="server" CssClass="select"></asp:DropDownList>
                        <%--<asp:DropDownList ID="ddlspread" runat="server" CssClass="select"></asp:DropDownList>--%>
                        <asp:DropDownList ID="ddlcolor" runat="server" CssClass="select"></asp:DropDownList>
                        <script type="text/javascript">
                            $(function () {
                                $("#btnSave").click(function () {
                                    if ($("#ddlstyle").val() == "" || $("#ddlmaterial").val() == "" || $("#ddlcolor").val() == "") {
                                        alert("品牌风格/材质/档位/色系 不能为空");
                                        return false;
                                    }

                                })
                            })
                        </script>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        介绍：
                    </td>
                    <td>
                        <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea required" TextMode="MultiLine"
                            Rows="5" Width="660" Height="200"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        排序 ：
                    </td>
                    <td>
                        <asp:TextBox ID="txtsort" runat="server" CssClass="input w160 required digits">0</asp:TextBox>
                    </td>
                </tr>
            </table>
            <div style="margin-top: 10px; margin-left: 120px">
                <asp:Button ID="btnSave" runat="server" CssClass="submit" OnClick="btnSave_Click" />
                    
            </div>
        </div>
    </div>
    <div class="clear"></div>
    <div class="foot" style=" position:static; left:0px; background:#f4f4f4; bottom:0px; right:0px; width:100%; height:30px; display:none">
        底部
    </div>
</form>
</body>
</html>
