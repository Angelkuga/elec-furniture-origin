<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotioninfo.aspx.cs" Inherits="TREC.Web.Admin.promotion.promotioninfo" %>
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
                editor2 = K.create('#txthtmltitle', {
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
						'insertunorderedlist',  'fullscreen']
                });
            });
        });
    </script>
</head>
<body style="padding:10px;">
<form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="promotionlist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 促销活动 &gt; 促销活动信息</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="3" align="left">聚合信息</th>
        </tr>
        <tr>
            <td  width="160"  align="right">
                活动类型：
            </td>
            <td  align="left" width="440px">
                <asp:DropDownList ID="ddltype" runat="server" CssClass="select" Width="160px"></asp:DropDownList>
            </td>
            <td rowspan="9" valign="top" align="left">
                <table class="formTable" width="400px">
                    <tr>
                        <td align="right" valign="top">形&nbsp;象&nbsp;&nbsp;图：</td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Promotion, ECommon.QueryId, TREC.Entity.EnFilePath.Surface)%>">
                                <asp:HiddenField ID="hfsurface" runat="server" />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay"  />
                                    <a href="javascript:;" class="files"><input id="File1" type="file" class="upload" onchange="_upfile(this)"  runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="70px" align="right">标志图：</td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Promotion, ECommon.QueryId, TREC.Entity.EnFilePath.Logo)%>">
                                <asp:HiddenField ID="hflogo" runat="server"  />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files"><input id="File2"  type="file" class="upload" onchange="_upfile(this)"  runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">缩&nbsp;略&nbsp;&nbsp;图：</td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Promotion, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
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
                        <td align="right">广告幻灯：</td>
                        <td>
                            <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Promotion, ECommon.QueryId, TREC.Entity.EnFilePath.Banner)%>">
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
                    <td align="right">详细图：</td>
                    <td>
                        <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Promotion, ECommon.QueryId, TREC.Entity.EnFilePath.DesImage)%>">
                            <asp:HiddenField ID="hfdesimage" runat="server" />
                            <div class="fileTools">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files"><input id="File5" type="file" class="upload" onchange="_upfile(this)"  runat="server" /></a>
                                <span class="uploading">正在上传，请稍后……</span>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td  align="right">
                        关键字 ：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtkeywords" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  align="right">
                        模版 ：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txttemplate" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  align="right">
                        点击量 ：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txthits" runat="server" CssClass="input" Width="40">0</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  align="right">
                        排序 ：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtsort" runat="server" CssClass="input" Width="40">0</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="90px" align="right">
                        审核：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlauditstatus" runat="server" CssClass="select selectNone"
                            Width="160">
                        </asp:DropDownList>
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
                </table>
                
            </td>
        </tr>
        <tr>
            <td  align="right">
                活动名称 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txttitle" runat="server" CssClass="input w380 required"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                HTMl标题 ：
            </td>
            <td align="left">
                <asp:TextBox id="txthtmltitle" runat="server" CssClass="textarea required" TextMode="MultiLine" heigh="100" Width="390"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                索引 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtletter" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                推荐属性 ：
            </td>
            <td align="left">
                 <asp:CheckBoxList ID="chkattribute" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td  align="right">
                开始时间 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtstartdatetime" runat="server" CssClass="input"></asp:TextBox>
                <img onclick="WdatePicker({el:'txtstartdatetime'})" src="<%=ECommon.WebAdminResourceUrl %>/My97DatePicker/skin/datePicker.gif" width="16" height="22" align="absmiddle">
            </td>
        </tr>
        <tr>
            <td  align="right">
                结束时间 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtenddatetime" runat="server" CssClass="input"></asp:TextBox>
                <img onclick="WdatePicker({el:'txtenddatetime'})" src="<%=ECommon.WebAdminResourceUrl %>/My97DatePicker/skin/datePicker.gif" width="16" height="22" align="absmiddle">
            </td>
        </tr>
        <tr>
            <td  align="right">
                地区 ：
            </td>
            <td align="left">
                <div class="_droparea" id="ddlareacode" title="<%=areaCode %>"></div>
            </td>
        </tr>
        <tr>
            <td  align="right">
                地址 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtaddress" runat="server" CssClass="input w380"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  align="right">
                活动内容 ：
            </td>
            <td align="left" colspan="2">
                <asp:TextBox id="txtdescript" runat="server" CssClass="textarea required" TextMode="MultiLine" Rows="5" Height="200" Width="820"></asp:TextBox>
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
