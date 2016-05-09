<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotionsinfo.aspx.cs"
    MasterPageFile="../Member.Master" Inherits="TREC.Web.Suppler.information.promotionsinfo" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/fileupload.js"></script>
    <script type="text/javascript" src="../script/formValidatorRegex.js"></script>
    <script type="text/javascript">
        $(function () {
            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('#<%=tbDescript.ClientID %>', {
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
                });
            });
        });
        $(document).ready(function(){
            $('#<%=tbStartdatetime.ClientID %>').click(function(){
               WdatePicker({skin:'whyGreen',minDate:'%y-%M-%d'});
            }).css('margin-right','20px');
            $('#<%=tbEnddatetime.ClientID %>').click(function(){
               WdatePicker({skin:'whyGreen',minDate:'#F{$dp.$D(\'<%=tbStartdatetime.ClientID %>\')}'});
            }).css('margin-left','5px');
        });


    </script>
    <style type="text/css">
        .w380
        {
            width: 600px;
        }
        .shoplist input
        {
            margin-right: 10px;
        }
        .shoplist label
        {
            margin-right: 30px;
        }
        .tip
        {
            color: Red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%=alertmsg%>
    <div class="maintitle">
        <h1>
            <u>添加商务信息</u></h1>
    </div>
    <div class="maincon">
        <div class="maintabcor">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right" width="12%" height="40">
                        标题：
                    </td>
                    <td width="88%" class="textleft">
                        <asp:TextBox ID="tbTitle" runat="server" CssClass="input required w380"></asp:TextBox><span
                            class="tip">*</span>
                    </td>
                </tr>
                <tr>
                    <td height="40" align="right">
                        &nbsp;类型：
                    </td>
                    <td class="textleft">
                        <asp:DropDownList ID="infoType" runat="server">
                            <asp:ListItem Value="">请选择类型</asp:ListItem>
                            <asp:ListItem Value="1">促销</asp:ListItem>
                            <asp:ListItem Value="2">活动</asp:ListItem>
                            <asp:ListItem Value="3">新闻</asp:ListItem>
                            <asp:ListItem Value="4">招商</asp:ListItem>
                            <asp:ListItem Value="5">其他</asp:ListItem>
                        </asp:DropDownList>
                        <span class="tip">*</span>
                        <%-- <select id="infoType" name="infoType">
              <option value="">请选择</option>
              <option value="1">促销</option>
              <option value="2">活动</option>
              <option value="3">新闻</option>
              <option value="4">招商</option>
              <option value="5">其他</option>
            </select>--%>
                    </td>
                </tr>
                <tr>
                    <td height="40" align="right">
                        &nbsp;是否置顶：
                    </td>
                    <td class="textleft">
                        <asp:CheckBox ID="chkisTop" runat="server" />
                    </td>
                </tr>
                <%if (SupplerPageBase.memberInfo.type != 103)
                  { %>
                <tr>
                    <td align="right" height="40">
                        选择店铺：
                    </td>
                    <td class="textleft shoplist">
                        <asp:CheckBoxList ID="chkshoplist" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        </asp:CheckBoxList>
                        <asp:Label ID="lb_hidTip" runat="server" Text=""></asp:Label>
                        <span class="tip">*</span>
                    </td>
                </tr>
                <%} %>
                <%if (SupplerPageBase.memberInfo.type == 103)
                  { %>
                <tr>
                    <td align="right" width="110">
                        所在楼层：
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rmarketstoreylist" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                        </asp:RadioButtonList>
                        <span class="tip">*</span>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td align="right" width="110">
                        活动图片：
                    </td>
                    <td align="left">
                        <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Promotion, ECommon.QueryId , TREC.Entity.EnFilePath.Surface)%>">
                            <asp:HiddenField ID="hfsurface" runat="server" />
                            <div class="fileTools" style="width: 310px">
                                <input type="text" class="input w250 filedisplay" />
                                <a href="javascript:;" class="files">
                                    <input id="File2" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                <span class="uploading">上传中</span>
                            </div>
                        </div>
                        (建议图片尺寸为：宽394 * 高300像素)
                    </td>
                </tr>
                <tr>
                    <td align="right" height="40">
                        起始日期：
                    </td>
                    <td class="textleft">
                        <asp:TextBox ID="tbStartdatetime" runat="server" CssClass="input"></asp:TextBox>
                        <span class="tip">*</span> 截止日期<asp:TextBox ID="tbEnddatetime" runat="server" CssClass="input"></asp:TextBox><span
                            class="tip">*</span> <span class="nortip">(格式：2012-09-09)</span>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="110">
                        详细内容：
                    </td>
                    <td align="left">
                        <asp:TextBox ID="tbDescript" runat="server" CssClass="textarea required" TextMode="MultiLine"
                            Rows="5" Height="200" Width="600"></asp:TextBox><span class="tip">*</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="btnone">
                            <asp:Button ID="btnSave" runat="server" Text="提 交" CssClass="btnl" OnClientClick="return ckhInfoForm();"
                                OnClick="btnSave_Click" />
                            <input name="重置" type="reset" class="btnr" value="重 填" /></div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
<!--
        var type = '<%=Type %>';
        if (type.toString() != '') {
            $('#infoType option[value=' + type.toString() + ']').attr('selected', true);
        }

        function ckhInfoForm() {
            //标题
            var infoTitle = $.trim($('#<%=tbTitle.ClientID %>').val());
            if (infoTitle == '') {
                alert('抱歉，请输入信息标题！');
                $('#<%=tbTitle.ClientID %>').focus();
                return false;
            }
            var infoType = $.trim($('#<%=infoType.ClientID %>  option:selected').val());
            if (infoType == '') {
                alert('抱歉，请选择信息类型！');
                $("#<%=infoType.ClientID %>").focus();
                return false;
            }
            /*是否选择了店铺*/
//            var quantity = $('.shoplist input:checked').size();
//            if ($('.shoplist input').size() > 0) {
//                if (quantity == 0) {
//                    alert('抱歉，请选择店铺！');
//                    return false;
//                }
//            } else {
//                // $('input:radio[name="list"]:checked')
//                var maketstory = $("input[type=radio]:checked");
//                if (maketstory.length == 0) {
//                    alert("请选择楼层");
//                    return false;
//                }

//            }

            var sdate = $.trim($('#<%=tbStartdatetime.ClientID %>').val());
            var edate = $.trim($('#<%=tbEnddatetime.ClientID %>').val());
            if (sdate == '') {
                alert('抱歉，请选择起始日期！');
                $('#<%=tbStartdatetime.ClientID %>').focus();
                return false;
            }
            if (!isDate(sdate)) {
                alert('抱歉，请输入有效的起始日期！');
                $('#<%=tbStartdatetime.ClientID %>').focus();
                return false;
            }

            if (edate == '') {
                alert('抱歉，请选择截止日期！');
                $('#<%=tbEnddatetime.ClientID %>').focus();
                return false;
            }
            if (!isDate(edate)) {
                alert('抱歉，请输入有效的截止日期！');
                $('#<%=tbEnddatetime.ClientID %>').focus();
                return false;
            }
            //日期比较           
            var d1 = new Date(sdate.replace(/-/g, "/"));
            var d2 = new Date(edate.replace(/-/g, "/"));
            if (Date.parse(d1) - Date.parse(d2) > 0) {
                alert("抱歉，截止日期不能小于起始日期！");
                $('#<%=tbEnddatetime.ClientID %>').focus();
                return false;
            }

            //详细内容
            var descript = $.trim($(document.getElementsByTagName('iframe')[0].contentWindow.document.body).html());
            if (descript.toString() == '' || descript == '<br>') {
                alert('抱歉，请输入详细内容！');
                return false;
            }
            $('#txtKE').val(descript.toString());
            return true;
        }
//-->
    </script>
</asp:Content>
