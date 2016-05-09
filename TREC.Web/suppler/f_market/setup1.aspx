<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setup1.aspx.cs" Inherits="TREC.Web.Suppler.f_market.setup1" %>
<%@ Import Namespace="TREC.Entity" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Register src="nav.ascx" tagname="nav" tagprefix="uc2" %>
<%@ Register src="../ascx/head.ascx" tagname="head" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加卖场基本信息</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/fileupload.js"></script>
    <script type="text/javascript" language="javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.poshytip.min.js"></script>
    <script type="text/javascript" src="../script/formValidator-4.1.1.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../script/formValidatorRegex.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../script/supplercommon.js"></script>
    <script type="text/javascript" src="../script/pageValitator/marketinfo.js"></script>
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
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=market&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
                });
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
<body style="height: auto">
    <form id="form1" runat="server">

<uc1:head ID="head2" runat="server" />
<div class="Fcon setup">
        <div class="setupTitle">
            &nbsp;&nbsp;欢迎您进入家具快搜供应商管理系统，请先按顺序添加完成以下内容，以便正式上传产品。
        </div>
       <%-- <div class="setupNext">
           <%-- <uc2:nav ID="nav1" runat="server" />--%>
        </div>--%>
        <div class="setupCon">
    <table class="formTable">
        <tr>
            <th colspan="2">
                &nbsp;&nbsp;基本信息：
            </th>
        </tr>
        <tr>
            <td align="right" width="70">
                卖场名称：
            </td>
            <td>
                <asp:TextBox ID="txttitle" runat="server" CssClass="input required w250"></asp:TextBox>
                <div id="txttitleTip"  style="width:280px; float:left" class="forTip" ></div> <label>如果您是某一家连锁家具卖场，请填写完整的名称。例：红星美凯龙汶水路店</label>
            </td>
        </tr>
        <tr>
            <td align="right">
                名称索引：
            </td>
            <td>
                <asp:TextBox ID="txtletter" runat="server" CssClass="input required w250"></asp:TextBox>
                <div id="txtletterTip"  style="width:280px; float:left" class="forTip" ></div> 
                <label>(请填写卖场全称的首字母)</label>
            </td>
        </tr>
        <tr style="display:none">
            <td align="right">
                人员规格 ：
            </td>
            <td>
                <asp:DropDownList ID="ddlstaffsize" runat="server" CssClass="select selectNone" Width="160">
                </asp:DropDownList>
            </td>
        </tr>
        <tr  style="display:none">
            <td align="right">
                注册年份：
            </td>
            <td>
                <asp:TextBox ID="txtregyear" runat="server" CssClass="input w250 required digits"></asp:TextBox>
            </td>
        </tr>
        <tr  style="display:none">
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
            <td align="right">
                营业面积：
            </td>
            <td>
                <asp:TextBox ID="txtcbm" runat="server" CssClass="input number" Width="45"></asp:TextBox><label>(平方米)</label>
            </td>
        </tr>
        <tr>
            <td align="right">
                咨询电话：
            </td>
            <td>
                <asp:TextBox ID="txtlphone" runat="server" CssClass="input w250"></asp:TextBox>
                <div id="txtlphoneTip"  style="width:280px; float:left" class="forTip" ></div> 
            </td>
        </tr>
        <tr>
            <td align="right">
                招商电话：
            </td>
            <td>
                <asp:TextBox ID="txtzphone" runat="server" CssClass="input w250"></asp:TextBox>
                <div id="txtzphoneTip"  style="width:280px; float:left" class="forTip" ></div>
            </td>
        </tr>
        <tr>
            <td align="right">
                乘车路线：
            </td>
            <td>
                <asp:TextBox ID="txtbusroute" runat="server" CssClass="input w250"></asp:TextBox><label>例：51、116、541、713、810、848、江月线等直达</label>
            </td>
        </tr>
        <tr>
            <td align="right">
                营业时间：
            </td>
            <td>
                <asp:TextBox ID="txthours" runat="server" CssClass="input w380"></asp:TextBox><label>例：9:30—17:30(周一至周五)9:30-18:30(周六周日)</label>
            </td>
        </tr>
        <tr  style="display:none">
            <td align="right">
                业务描述：
            </td>
            <td>
                <asp:TextBox ID="txtbuy" runat="server" CssClass="w250 textarea" TextMode="MultiLine"
                    Rows="4"></asp:TextBox><label>长度不超过250字符,生产/销售/租凭业务描述</label>
            </td>
        </tr>
        <tr>
            <th colspan="2">
               &nbsp;&nbsp; 联系信息：
            </th>
        </tr>
        <tr>
            <td align="right" >
                地区：
            </td>
            <td>
                <div class="_droparea" id="ddlareacode" title="<%=areaCode %>">
                </div>
            </td>
        </tr>
        <tr>
            <td align="right">
                地址：
            </td>
            <td>
                <asp:TextBox ID="txtaddress" runat="server" CssClass="input w380"></asp:TextBox>
                <div id="txtaddressTip"  style="width:280px; float:left" class="forTip" ></div> 
            </td>
        </tr>
        <tr>
            <td align="right">
                联系人：
            </td>
            <td>
                <asp:TextBox ID="txtlinkman" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                手机 ：
            </td>
            <td>
                <asp:TextBox ID="txtmphone" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                电话 ：
            </td>
            <td>
                <asp:TextBox ID="txtphone" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                传真 ：
            </td>
            <td>
                <asp:TextBox ID="txtfax" runat="server" CssClass="input w250"></asp:TextBox>
                <div id="txtfaxTip"  style="width:280px; float:left" class="forTip" ></div> 
            </td>
        </tr>
        <tr>
            <td align="right">
                邮箱 ：
            </td>
            <td>
                <asp:TextBox ID="txtemail" runat="server" CssClass="input w250"></asp:TextBox>
                <div id="txtemailTip"  style="width:280px; float:left" class="forTip" ></div> 
            </td>
        </tr>
        <tr>
            <td align="right">
                邮编 ：
            </td>
            <td>
                <asp:TextBox ID="txtpostcode" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                网址 ：
            </td>
            <td>
                <asp:TextBox ID="txthomepage" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th colspan="2">
               &nbsp;&nbsp; 图片信息:
            </th>
        </tr>
        <tr>
            <td align="right" valign="top" width="88">
                形&nbsp;象&nbsp;&nbsp;图：<a href="javascript:;" class="helper" title="点击查看产品缩略图片位置示意"><img src="../images/d3.gif"/></a>
            </td>
            <td>
             <%--<div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Market, ECommon.QueryId, TREC.Entity.EnFilePath.Surface)%>">--%>
                <div class="fileUpload">
                    <asp:HiddenField ID="hfsurface" runat="server" />
                    <div class="fileTools" style="width:310px">
                        <input type="text" class="input w250 filedisplay" />
                        <a href="javascript:;" class="files">
                            <input id="File1" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div><label>请上传一张代表卖场形象的效果图，尺寸为宽992*高400像素</label>
                </div>
            </td>
        </tr>
        <tr>
            <td width="70px" align="right">
                企业标志：
            </td>
            <td>
                <%--<div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Market, ECommon.QueryId, TREC.Entity.EnFilePath.Logo)%>">--%>
                <div class="fileUpload">
                    <asp:HiddenField ID="hflogo" runat="server" />
                    <div class="fileTools" style="width:310px">
                        <input type="text" class="input w250 filedisplay" />
                        <a href="javascript:;" class="files">
                            <input id="File2" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div><label>请上传一张卖场logo/标志，尺寸为宽196*高70像素</label>
                </div>
            </td>
        </tr>
        <tr>
            <td align="right">
                缩&nbsp;略&nbsp;&nbsp;图：<a href="javascript:;" class="helper" title="点击查看产品缩略图片位置示意"><img src="../images/d4.gif"/></a>
            </td>
            <td>
            <%--<div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Market, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">--%>
                <div class="fileUpload">
                    <asp:HiddenField ID="hfthumb" runat="server" />
                    <div class="fileTools" style="width:310px">
                        <input type="text" class="input w250 filedisplay" />
                        <a href="javascript:;" class="files">
                            <input id="File3" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div><label>请上传一张代表卖场形象的缩略图，尺寸为174*高188像素</label>
                </div>
            </td>
        </tr>
        <tr style="display:none;">
            <td align="right">
                广告幻灯：<a href="javascript:;" class="helper" title="点击查看产品缩略图片位置示意"><img src="../images/d6.gif"/></a>
            </td>
            <td>
            <%--<div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Market, ECommon.QueryId, TREC.Entity.EnFilePath.Banner)%>">--%>
                <div class="fileUpload m">
                    <asp:HiddenField ID="hfbannel" runat="server" />
                    <div class="fileTools" style="width:310px">
                        <input type="text" class="input w250 filedisplay" />
                        <a href="javascript:;" class="files">
                            <input id="File4" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div><label>请上传一张代表卖场形象的缩略图，尺寸为174*高188像素</label>
                </div>
            </td>
        </tr>
        <tr  style="display: none">
            <td align="right">
                企业展示：<a href="javascript:;" class="helper" title="点击查看产品缩略图片位置示意"><img src="../images/d6.gif"/></a>
            </td>
            <td>
            <%--<div class="fileUpload m" path="<%=string.Format(TREC.Entity.EnFilePath.Market, ECommon.QueryId, TREC.Entity.EnFilePath.DesImage)%>">--%>
                <div class="fileUpload m">
                    <asp:HiddenField ID="hfdesimage" runat="server" />
                    <div class="fileTools" style="width:310px">
                        <input type="text" class="input w250 filedisplay" />
                        <a href="javascript:;" class="files">
                            <input id="File5" type="file" class="upload" onchange="_upfile(this)" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <div class="clear">
    </div>
    <table class="formTable" width="100%">
        <tr>
            <th colspan="2">
                &nbsp;&nbsp;卖场介绍:
            </th>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea required" TextMode="MultiLine"
                    Rows="5" Width="98%" Height="220"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="margin-top: 10px; margin-left: 180px">
        <asp:Button ID="btnSave" runat="server" Text="" CssClass="submit" OnClick="btnSave_Click" />&nbsp;</div>
    <div class="clear"></div>
    <div class="foot" style=" position:static; left:0px; background:#f4f4f4; bottom:0px; right:0px; width:100%; height:30px; display:none">
        底部
    </div>
    </form>
</body>
</html>