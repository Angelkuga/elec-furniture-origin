<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productcategoryinfo.aspx.cs" Inherits="TREC.Web.Admin.product.productcategoryinfo" EnableEventValidation="false" %>
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
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/listbox/jquery.dualListBox-1.3.min.js"></script>

    <style type="text/css">
        .formTable{border:1px solid #ccc;}
        .formTable tr th{background:#ededed; text-align:left;}
        .formTable tr td{border:none; padding-top:8px; padding-bottom:8px;}
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
                editor = K.create('#txtdescript', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=productcategory&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
                });
            });
            $.configureBoxes();
        });
    </script>
</head>
<body style="padding:10px;">
<form id="form1" runat="server">
    <div class="navigation">
    
      <span class="back"><a href="productcategorylist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 产品管理 &gt; 产品分类</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="3" align="left">产品分类</th>
        </tr>
        <tr>
            <td  width="770px" valign="top">
                <table class="formTable" width="770px">
                    <tr>
                        <th colspan="2">分类信息：</th>
                    </tr>
                      <tr>
                        <td align="right" width="80">分类名称：</td>
                        <td><asp:TextBox ID="txttitle" runat="server"  CssClass="input required"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">
                            字母索引 ：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtletter" runat="server" CssClass="input required"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            重写路径 ：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtrewritetitle" runat="server" CssClass="input"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            上级分类 ：
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlparent" runat="server" CssClass="select required"></asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            关键字 ：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtkeywords" runat="server" CssClass="input"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            模版路径：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txttemplate" runat="server" CssClass="input"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="spClear"></div>
                <table class="formTable" width="770px">
                    <tr>
                        <th colspan="2">类型绑定:</th>
                    </tr>
                    <tr>
                        <td colspan="2" class="typelist">
                            <table>
                                <tr>
                                    <td><asp:ListBox ID="box1View" SelectionMode="Multiple" runat="server" Width="220" Height="280" ></asp:ListBox></td>
                                    <td>
                                        <button id="to2" type="button">&nbsp;>&nbsp;</button>

                                        <button id="allTo2" type="button">&nbsp;>>&nbsp;</button>

                                        <button id="allTo1" type="button">&nbsp;<<&nbsp;</button>

                                        <button id="to1" type="button">&nbsp;<&nbsp;</button>
                                    </td>
                                    <td>
                                         <asp:ListBox ID="box2View" SelectionMode="Multiple" runat="server" Width="220" Height="280" ></asp:ListBox>
                                    </td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">图片信息:</th>
                    </tr>
                    <tr>
                        <td align="right" valign="top">形&nbsp;象&nbsp;&nbsp;图：</td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.ProductCategory, ECommon.QueryId, TREC.Entity.EnFilePath.Surface)%>">
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
                        <td align="right">缩&nbsp;略&nbsp;&nbsp;图：</td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.ProductCategory, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
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
                            <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.ProductCategory, ECommon.QueryId, TREC.Entity.EnFilePath.Banner)%>">
                                <asp:HiddenField ID="hfbannel" runat="server" />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files"><input id="File4" type="file" class="upload" onchange="_upfile(this)"  runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                 <div class="spClear"></div>
                

                <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">产品分类介绍:</th>
                    </tr>
                    <tr>
                        <td colspan="2"><asp:TextBox id="txtdescript" runat="server" CssClass="textarea required" TextMode="MultiLine" Rows="5" Width="360"></asp:TextBox></td>
                    </tr>
                </table>
                
                
                <div class="spClear"></div>
                <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">产品分类状态:</th>
                    </tr>
                    <tr>
                        <td align="right">上/下线：</td>
                        <td><asp:DropDownList ID="ddllinestatus" runat="server" CssClass="select selectNone" Width="160"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">
                            排序 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtsort" runat="server" CssClass="input w160 required digits">0</asp:TextBox>
                        </td>
                    </tr>
                    <%if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
                  { %>
                    <tr>
                        <td align="right">
                            点击量 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txthits" runat="server" CssClass="input w160 required digits">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            最后修改 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtlastedittime" runat="server" CssClass="input Wdate w160 required" onfocus="WdatePicker()"></asp:TextBox>
                        </td>
                    </tr>
                <%} %>
                </table>
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
