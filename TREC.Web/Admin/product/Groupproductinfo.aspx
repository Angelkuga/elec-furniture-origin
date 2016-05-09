<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Groupproductinfo.aspx.cs"
    Inherits="TREC.Web.Admin.product.Groupproductinfo" EnableEventValidation="false" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="<%="\""+TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/')%>/altdialog/skins/default.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/fileupload.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/altdialog/artDialog.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/altdialog/plugins/iframeTools.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/json2.js"></script>
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
        #productattributelist ul
        {
            margin-left: 36px;
        }
        #productattributelist ul li
        {
            background: #f3f3f3;
            display: block;
            float: left;
            height: 30px;
            line-height: 30px;
            border-bottom: dotted 1px #bbbbbb;
            margin-bottom: 2px;
            width: 100%;
        }
        #productattributelist ul li span
        {
            display: block;
            float: left;
            padding: 0px 5px;
            line-height: 30px;
            height: 30px;
            width: 100px;
            overflow: hidden;
        }
    </style>
</head>
<body style="padding: 10px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="back"><a href="Groupproductlist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt;
            产品管理 &gt; 套组合管理</b>
    </div>
    <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="3" align="left">
                套组合信息
            </th>
        </tr>
        <tr>
            <td width="770px" valign="top">
                <table class="formTable" width="770px">
                    <tr>
                        <th colspan="2">
                            基本信息：
                        </th>
                    </tr>
                    <tr>
                        <td align="right" width="70">
                            产品名称：
                        </td>
                        <td>
                            <asp:TextBox ID="txttitle" runat="server" CssClass="input"></asp:TextBox>
                            <label>
                                &nbsp;&nbsp;&nbsp;&nbsp;产品编号：</label>
                            <asp:TextBox ID="txtsku" runat="server" CssClass="input required"></asp:TextBox>
                            <label>
                                &nbsp;&nbsp;&nbsp;&nbsp;定制：</label>
                            <asp:RadioButtonList ID="racustomize" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="是" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            产品分类：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlproductcategory" runat="server" CssClass="select selectNone">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="right">福家网对应ID：</td>
                        <td>
                            <asp:TextBox ID="txtFID" runat="server">0</asp:TextBox>
                        </td>
                    </tr>--%>
                </table>
                <div class="spClear">
                </div>
                <table class="formTable" width="770px">
                    <tr>
                        <th colspan="2">
                            品牌信息:
                        </th>
                    </tr>
                    <tr>
                        <td width="70" align="right">
                            选择品牌：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlbrand" runat="server" CssClass="select selectNone">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlstyle" runat="server" CssClass="select selectNone">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlmaterial" runat="server" CssClass="select selectNone">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlcolor" runat="server" CssClass="select selectNone">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="70" align="right">
                            系列：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlbrands" runat="server" CssClass="select selectNone">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="70" align="right">
                            活动：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPT" runat="server" CssClass="select selectNone">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">
                            图片信息:
                        </th>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            整体图：
                        </td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.ProductGroup, gpId, TREC.Entity.EnFilePath.Thumb)%>">
                                <asp:HiddenField ID="hfthumb" runat="server" />
                                <div class="fileTools" style="width: 310px">
                                    <input type="text" class="input w160 filedisplay" id="thumb" />
                                    <a href="javascript:;" class="files">
                                        <input id="File1" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                                    <span class="uploading">上传中</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="70px" align="right">
                            局部图：
                        </td>
                        <td>
                            <div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.ProductGroup, gpId, TREC.Entity.EnFilePath.Banner)%>">
                                <asp:HiddenField ID="hfbannel" runat="server" />
                                <div class="fileTools" style="width: 310px">
                                    <input type="text" id="bannel" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files">
                                        <input id="File2" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                                    <span class="uploading">上传中</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="spClear">
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table class="formTable" width="770px">
                    <tr>
                        <th colspan="3">
                            套组合产品:
                        </th>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table width="100%" border="1">
                                <tr>
                                    <th>
                                        id
                                    </th>
                                    <th>
                                        编号
                                    </th>
                                    <th>
                                        名称
                                    </th>
                                    <th>
                                        品牌
                                    </th>
                                    <th>
                                        材质
                                    </th>
                                    <th>
                                        大类
                                    </th>
                                </tr>
                                <% foreach (EnProduct items in prodlist)
                                   { %>
                                <tr>
                                    <td>
                                        <%=items.id %>
                                    </td>
                                    <td>
                                        <%=items.sku %>
                                    </td>
                                    <td>
                                        <a href="/admin/product/productinfo.aspx?edit=1&id=<%=items.id %>">
                                            <% = items.title %></a>
                                    </td>
                                    <td>
                                        <%=items.brandstitle %>
                                    </td>
                                    <td>
                                        <%=items.materialname %>
                                    </td>
                                    <td>
                                        <%=items.categorytitle %>
                                    </td>
                                </tr>
                                <%} %>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="3">
                            套组合描述:
                        </th>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescript"></asp:TextBox>
                        </td>
                        <td>
                            <table class="formTable" width="380">
                                <tr>
                                    <th colspan="2">
                                        产品分类状态:
                                    </th>
                                </tr>
                                <tr>
                                    <td align="right">
                                        推荐属性：
                                    </td>
                                    <td>
                                        <asp:CheckBoxList ID="chkattribute" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        审核状态：
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
                                        <asp:TextBox ID="txtlastedittime" runat="server" CssClass="input Wdate w160 required"
                                            onfocus="WdatePicker()"></asp:TextBox>
                                    </td>
                                </tr>
                                <%} %>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div style="margin-top: 10px; margin-left: 180px">
        <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" OnClick="btnSave_Click" /><input
            name="重置" type="reset" class="submit" value="重置" />
    </div>
    </form>
</body>
</html>
