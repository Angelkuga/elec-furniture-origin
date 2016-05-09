<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="merchantsinfo.aspx.cs"
    Inherits="TREC.Web.Suppler.information.merchantsinfo" EnableEventValidation="false" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="<%="\""+TREC.ECommerce.ECommon.WebSupplerResourceUrl%>/altdialog/skins/default.css" />
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../script/formValidator-4.1.1.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../script/formValidatorRegex.js" charset="UTF-8"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.area2.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/fileupload.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/altdialog/artDialog.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/altdialog/plugins/iframeTools.js"></script>
    <script type="text/javascript" language="javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.poshytip.min.js"></script>
    <script type="text/javascript" src="../script/supplercommon.js"></script>
    <script type="text/javascript">
        $(function () {
            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('#txtdescript', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                     <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=shop&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
                })
            });
        });
    </script>
</head>
<body style="height: auto">
    <form id="form1" runat="server">
    <asp:HiddenField ID="IsAdd" runat="server" Value="search" />
    <table width="100%" border="0" class="formTable">
    <tr>
                        <td align="right" width="70">
                            品牌：
                        </td>
                        <td>
                            <asp:RadioButtonList ID="chkbrandlist" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:RadioButtonList>
                            
                        </td>
                    </tr>
        <tr>
            <td align="right" style="width: 110px;">
                标题：
            </td>
            <td>
                <asp:TextBox ID="txttitle" runat="server" CssClass="input required w160"></asp:TextBox>
                <div id="txttitleTip" style="width: 280px; float: left" class="forTip">
                </div>
            </td>
        </tr>
        <tr>
                        <td align="right">
                            上/下线：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddllinestatus" runat="server" CssClass="select selectNone"
                                Width="160">
                            </asp:DropDownList>
                        </td>
                    </tr>
        <tr>
            <td align="right" valign="top">
                详细介绍：
            </td>
            <td>
                <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea required" TextMode="MultiLine"
                    Rows="5" Width="660" Height="200"></asp:TextBox>
                    <div id="txtdescriptTip" style="width: 280px; float: left" class="forTip">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" OnClick="btnSave_Click" />
                <input name="重置" type="reset" class="submit" value="重置" />
            </td>
        </tr>
    </table>
     <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th width="80px" align="center">
                选择
            </th>
            <th width="40px" align="center">
                编号
            </th>
            <th align="center" width="160px">
                联系人
            </th>
            <th align="center" width="160px">
                联系方式
            </th>
            <th align="center">
                地区
            </th>
            <th align="center" width="160px">
                提交时间
            </th>
        </tr>
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="center">
                        <asp:CheckBox ID="cb_id" CssClass="checkall" runat="server" />
                    </td>
                    <td align="center">
                        <%#Eval("Id")%>
                    </td>
                    <td align="center">
                        <%#Eval("Name") %>
                    </td>
                    <td align="center">
                        <%#Eval("Phone") %>
                    </td>
                    <td align="center">
                        <%#ECommon.GetAreaName(Eval("CityCode").ToString())%>
                    </td>
                    <td align="center">
                        <%#Eval("CreateTime")%>
                    </td>
                </tr>
                <tr>
                    <td>内容：</td>
                    <td colspan="5"> <%#Eval("descript")%></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="spClear">
    </div>
    <div style="line-height: 30px; height: 30px;">
        <div id="Pagination" class="right flickr">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="true" UrlPaging="true"
                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页">
            </webdiyer:AspNetPager>
        </div>
    </div>
    </form>
</body>
</html>
