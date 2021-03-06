﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setup1.aspx.cs" Inherits="TREC.Web.Suppler.f_company.setup1" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register src="../ascx/head.ascx" tagname="head" tagprefix="uc1" %>
<%@ Register src="nav.ascx" tagname="nav" tagprefix="uc2" %>
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
    <script type="text/javascript" language="javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.poshytip.min.js"></script>
    <script type="text/javascript" src="../script/supplercommon.js"></script>
    <script type="text/javascript" src="../script/pageValitator/company-setup1.js"></script>
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
            });
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
</head>
<body>
<form id="form1" runat="server">
    <uc1:head ID="head1" runat="server" />
    <div class="Fcon setup">
        <div class="setupTitle">
            &nbsp;&nbsp;欢迎您进入家具快搜供应商管理系统，请先按顺序添加完成以下内容，以便正式上传产品。
        </div>
   <%--     <div class="setupNext">
            <uc2:nav ID="nav1" runat="server" />
        </div>--%>
        <div class="setupCon">
            <table class="formTable">
                <tr>
                    <td align="right" width="80">
                        厂商名称：
                    </td>
                    <td width="340">
                        <asp:TextBox ID="txttitle" runat="server" CssClass="input w160"></asp:TextBox>
                        <div id="txttitleTip"  style="width:280px; float:left" class="forTip" ></div> 
                        <label style="display:none;">&nbsp;&nbsp;(名称系统默认第一次为联系人名称，请修改)</label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width:200px;"><a href="javascript:;" class="helper" title="点击查看图片位置示意"><img src="../images/d1.gif"/></a>品牌代表性产品广告缩略图：</td>
                    <td>
                        <div class="fileUpload">
                         <%--<div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Company, companyInfo.id, TREC.Entity.EnFilePath.Thumb)%>">--%>
                            <asp:HiddenField ID="hfthumb" runat="server" />
                            <div class="fileTools" style="width:310px">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File3" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div><label>请传一张体现产品风格的图，高410×550像素</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top"><a href="javascript:;" class="helper" title="点击查看图片位置示意"><img src="../images/d2.gif"/></a>品牌代表性产品广告大图：</td>
                    <td>
                    <%--<div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Company, companyInfo.id, TREC.Entity.EnFilePath.Banner)%>">--%>
                        <div class="fileUpload m">
                            <asp:HiddenField ID="hfbannel" runat="server" />
                            <div class="fileTools" style="width:310px">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File4" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div><label>请传多张体现产品风格的图，高400×757像素</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width:110px;">
                        营业执照：
                    </td>
                    <td>
                  <%--  <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Company, companyInfo.id, TREC.Entity.EnFilePath.License)%>">--%>
                        <div class="fileUpload">
                            <asp:HiddenField ID="hflicense" runat="server" />
                            <div class="fileTools" style="width:310px">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="Fileone" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div><label>或将盖有公章的复印件传真至021-66240323</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width:110px;">
                        税务登记证：
                    </td>
                    <td>
                     <%--<div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Company, companyInfo.id, TREC.Entity.EnFilePath.Registration)%>">--%>
                        <div class="fileUpload" >
                            <asp:HiddenField ID="hfregistration" runat="server" />
                            <div class="fileTools" style="width:310px">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File1" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div><label>或将盖有公章的复印件传真至021-66240323</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width:110px;">
                        组织机构代码证：
                    </td>
                    <td>
                    <%--<div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Company, companyInfo.id, TREC.Entity.EnFilePath.Organization)%>">--%>
                        <div class="fileUpload" >
                            <asp:HiddenField ID="hforganization" runat="server" />
                            <div class="fileTools" style="width:310px">
                                <input type="text" class="input w160 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File2" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div><label>或将盖有公章的复印件传真至021-66240323</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        员工规模 ：
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
                        <asp:DropDownList ID="ddlregcity" runat="server" CssClass="select">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        联系人：
                    </td>
                    <td>
                        <asp:TextBox ID="txtlinkman" runat="server" CssClass="input w160"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        手机 ：
                    </td>
                    <td>
                        <asp:TextBox ID="txtmphone" runat="server" CssClass="input w160 digits"></asp:TextBox>
                        <div id="txtmphoneTip"  style="width:280px; float:left" class="forTip" ></div> 
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        公司联系电话 ：
                    </td>
                    <td>
                        <asp:TextBox ID="txtphone" runat="server" CssClass="input w160"></asp:TextBox>
                        <div id="txtphoneTip"  style="width:280px; float:left" class="forTip" ></div> 
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        公司传真 ：
                    </td>
                    <td>
                        <asp:TextBox ID="txtfax" runat="server" CssClass="input w160"></asp:TextBox>
                        <div id="txtfaxTip"  style="width:280px; float:left" class="forTip" ></div> 
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        联系邮箱 ：
                    </td>
                    <td>
                        <asp:TextBox ID="txtemail" runat="server" CssClass="input w160 email"></asp:TextBox>
                        <div id="txtemailTip"  style="width:280px; float:left" class="forTip" ></div> 
                    </td>
                </tr>
                <tr>
                    <td align="right" width="70px">
                        公司地址：
                    </td>
                    <td>
                        <div class="_droparea" id="ddlareacode" title="<%=areaCode %>">
                        </div>
                        <div id="ddlareacode_districtTip"  style="width:280px; float:left" class="forTip" ></div> 
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        详细地址：
                    </td>
                    <td>
                        <asp:TextBox ID="txtaddress" runat="server" CssClass="input w160"></asp:TextBox>
                        <div id="txtaddressTip"  style="width:280px; float:left" class="forTip" ></div> 
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        邮编 ：
                    </td>
                    <td>
                        <asp:TextBox ID="txtpostcode" runat="server" CssClass="input w160 digits"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        如自有网站，请填写网址 ：
                    </td>
                    <td>
                        <asp:TextBox ID="txthomepage" runat="server" CssClass="input w160"></asp:TextBox><label>&nbsp;&nbsp;(以http://开始, 例：http://www.jiajuks.com)</label>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        介绍 ：
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea required" TextMode="MultiLine"
                            Rows="5" Width="660" Height="220"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none">
                    <td width="70px" align="right">
                        审核：
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlauditstatus" runat="server" CssClass="select" Width="160"
                            Enabled="false">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                <td>&nbsp;</td>
                <td><asp:Button ID="btnSave" runat="server" CssClass="submit"  OnClick="btnSave_Click" /></td>
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
