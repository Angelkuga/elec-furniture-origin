<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setup2.aspx.cs" Inherits="TREC.Web.Suppler.f_company.setup2" %>
<%@ Register src="../ascx/head.ascx" tagname="head" tagprefix="uc1" %>
<%@ Register src="nav.ascx" tagname="nav" tagprefix="uc2" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=ECommon.WebTitle%>-商务中心</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../script/formValidator-4.1.1.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../script/formValidatorRegex.js" charset="UTF-8"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/fileupload.js"></script>
    <script type="text/javascript" src="../script/supplercommon.js"></script>
    <script type="text/javascript" src="../script/pageValitator/company-brand.js"></script>
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
                    data: "type=gettopcompany&v=" + $("#txtSearch").val(),
                    dataType: "json",
                    success: function (data) {
                        if (data != "") {
                            $("#ddlcompany").html();
                            $("#ddlcompany").html("<option value=\"\">请选择</option>");
                            $.each(data, function (i) {
                                $("#ddlcompany").append("<option value=\"" + data[i].id + "\">" + data[i].name + "</option>");
                            });
                        }
                    }
                })
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
        <%if (TREC.ECommerce.SupplerPageBase.brandList != null && TREC.ECommerce.SupplerPageBase.brandList.Count > 0)
          { %>
            <div class="info" style="width:727px"><span class="ico">&nbsp;</span><b>您己创建过</b>
                <%foreach (EnBrand b in TREC.ECommerce.SupplerPageBase.brandList)
                { %>
                &nbsp;&nbsp;<b><a href="javascript:;">[<%=b.title %>]</a></b>&nbsp;
                <%} %>
                <b><a href="setup3.aspx" class="next">点击这里</a></b>&nbsp;进入下一步
            </div>
            <%} %>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="formTable">
                <%if (memberInfo.type != (int)TREC.Entity.EnumMemberType.工厂企业)
                  { %>
                <tr>
                    <th colspan="2">
                        品牌所属工厂：
                    </th>
                </tr>
                <tr>
                    <td align="right" width="100">
                        工厂查找：
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="w160 input"></asp:TextBox>&nbsp;<input
                            type="button" class="submit" value="查找" id="btnSearch" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        选择工厂：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlcompany" runat="server" CssClass="select selectNone" Width="160">
                        </asp:DropDownList>
                        (如果没有找到品牌工厂请选择<b>无关联工厂</b>)
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td align="right" width="170">
                        品牌名称：
                    </td>
                    <td>
                        <asp:TextBox ID="txttitle" runat="server" CssClass="input w160"></asp:TextBox>
                        <div id="txttitleTip"  style="width:280px; float:left" class="forTip" ></div> 
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        名称索引：
                    </td>
                    <td>
                        <asp:TextBox ID="txtletter" runat="server" CssClass="input  w160"></asp:TextBox>
                        <div id="txtletterTip"  style="width:280px; float:left" class="forTip" ></div> 
                        <label>(请填写品牌全称的首字母)</label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:HiddenField ID="hfbannel" runat="server" />
                        <asp:HiddenField ID="hfdesimage" runat="server" />
                        <asp:HiddenField ID="hfsurface" runat="server" />
                        品牌商标或Logo：
                    </td>
                    <td>
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Brand, ECommon.QueryId, TREC.Entity.EnFilePath.Logo)%>">
                            <asp:HiddenField ID="hflogo" runat="server" />
                            <div class="fileTools" style="width:310px">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File2" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div><label>(尺寸为：宽196 * 高70像素)</label>
                        </div>
                    </td>
                </tr>
                 <tr>
                    <td align="right" valign="top">
                        品牌商标或Logo缩略图：<a href="javascript:;" class="helper" title="点击查看图片位置示意"><img src="../images/d8.gif"/></a>
                    </td>
                    <td>
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Brand, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
                            <asp:HiddenField ID="hfthumb" runat="server" />
                            <div class="fileTools" style="width:310px;">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File1" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div><label>(高410×550像素)</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        品牌档位：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlspread" runat="server" CssClass="select selectNone" Width="160">
                        </asp:DropDownList>
                        <div id="ddlspreadTip"  style="width:280px; float:left" class="forTip" ></div> 
                    </td>
                </tr>
                <tr style="display:none;">
                    <td align="right">
                        品牌材质：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlmaterial" runat="server" CssClass="select selectNone" Width="160">
                        </asp:DropDownList>
                        <div id="ddlmaterialTip"  style="width:280px; float:left" class="forTip" ></div> 
                    </td>
                </tr>
                <tr style="display:none;">
                    <td align="right">
                        品牌风格：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlstyle" runat="server" CssClass="select selectNone" Width="160">
                        </asp:DropDownList>
                        <div id="ddlstyleTip"  style="width:280px; float:left" class="forTip" ></div> 
                    </td>
                </tr>
                <tr style="display:none;">
                    <td align="right">
                        品牌色系：
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlcolor" runat="server" CssClass="select selectNone" Width="160">
                        </asp:DropDownList>
                        <div id="ddlcolorTip"  style="width:280px; float:left" class="forTip" ></div> 
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        品牌介绍：
                    </td>
                    <td>
                        <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea " TextMode="MultiLine"
                            Rows="8" Width="98%" Height="220"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                <td>&nbsp;</td>
                <td><asp:Button ID="btnSave" runat="server" CssClass="submit" OnClick="btnSave_Click" /></td>
                </tr>

            </table>
           
        </div>
    </div>
    <div class="clear"></div>
    <div class="foot" style=" position:static; left:0px; background:#f4f4f4; bottom:0px; right:0px; width:100%; height:30px; display:none">
        底部
    </div>
</form>
</body>
</html>
