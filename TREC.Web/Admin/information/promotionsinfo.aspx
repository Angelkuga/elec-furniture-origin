<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="promotionsinfo.aspx.cs"
    Inherits="TREC.Web.Admin.information.promotionsinfo" %>

<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/fileupload.js"></script>
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
            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('#<%=tbDescript.ClientID %>', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                     <%if (TREC.ECommerce.ECommon.QueryId != "" && TREC.ECommerce.ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=TREC.ECommerce.ECommon.WebAdminResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=shop&id=<%=TREC.ECommerce.ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                    items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'image', 'flash', 'media', 'link', 'fullscreen']
                });
            });
        });
    </script>
</head>
<body style="padding: 10px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="back"><a href="promotionslist.aspx?display=<%=TRECommon.WebRequest.GetString("display") %>">
            返回列表</a></span><b>您当前的位置：首页 &gt; 成员管理 &gt; 登陆账号管理</b>
    </div>
    <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="3" align="left">
                促销信息
            </th>
        </tr>
        <tr>
            <td>
                <table class="formTable" width="770">
                    <tr>
                        <th colspan="2">
                            基本信息：
                        </th>
                    </tr>
                    <tr>
                        <td align="right" width="70">
                            促销标题：
                        </td>
                        <td>
                            <asp:TextBox ID="tbTitle" runat="server" Width="600"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="70">
                            索引：
                        </td>
                        <td>
                            <asp:TextBox ID="tbLetter" runat="server" Width="600"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="70">
                            推荐属性：
                        </td>
                        <td>
                            <asp:CheckBox ID="cbIsTop" runat="server" Text="置顶" Visible="false" />
                            <asp:CheckBox ID="cbIsRecommend" runat="server" Text="推荐" />
                            <asp:CheckBox ID="cbIsHot" runat="server" Text="热门" Visible="false" />
                            <asp:CheckBox ID="cbIsEssence" runat="server" Text="精华" Visible="false" />
                            <asp:CheckBox ID="cbIsSlide" runat="server" Text="幻灯" Visible="false" />
                            <asp:CheckBox ID="cbIsHighlight" runat="server" Text="高亮" Visible="false" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="70">
                            类型：
                        </td>
                        <td>
                            <asp:DropDownList ID="infoType" runat="server">
                                <asp:ListItem Value="">请选择类型</asp:ListItem>
                                <asp:ListItem Value="1">促销</asp:ListItem>
                                <asp:ListItem Value="2">活动</asp:ListItem>
                                <asp:ListItem Value="3">新闻</asp:ListItem>
                                <asp:ListItem Value="4">招商</asp:ListItem>
                                <asp:ListItem Value="5">其他</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="70">
                            活动图片：
                        </td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Promotion, ECommon.QueryId , TREC.Entity.EnFilePath.Surface)%>">
                                <asp:HiddenField ID="hfsurface" runat="server" />
                                <div class="fileTools" style="width: 310px">
                                    <input type="text" class="input w150 filedisplay" />
                                    <a href="javascript:;" class="files">
                                        <input id="File2" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                    <span class="uploading">上传中</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="70">
                            开始时间：
                        </td>
                        <td>
                            <asp:TextBox ID="tbStartdatetime" runat="server" CssClass="input"></asp:TextBox>
                            <img onclick="WdatePicker({el:'<%=tbStartdatetime.ClientID %>'})" src="<%=ECommon.WebAdminResourceUrl %>/My97DatePicker/skin/datePicker.gif"
                                width="16" height="22" align="absmiddle" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="70">
                            结束时间：
                        </td>
                        <td>
                            <asp:TextBox ID="tbEnddatetime" runat="server" CssClass="input"></asp:TextBox>
                            <img onclick="WdatePicker({el:'<%=tbEnddatetime.ClientID %>'})" src="<%=ECommon.WebAdminResourceUrl %>/My97DatePicker/skin/datePicker.gif"
                                width="16" height="22" align="absmiddle" />
                        </td>
                    </tr>
                    <%if (chkshoplist.Items.Count > 0)
                      { %>
                    <tr>
                        <td align="right" width="110">
                            所在店铺：
                        </td>
                        <td>
                            <asp:CheckBoxList ID="chkshoplist" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <%} %>
                    <%if (rmarketstoreylist.Items.Count > 0)
                      { %>
                    <tr>
                        <td align="right" width="110">
                            所在楼层：
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rmarketstoreylist" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <%} %>
                    <tr>
                        <td align="right" width="70">
                            详情介绍：
                        </td>
                        <td>
                            <asp:TextBox ID="tbDescript" runat="server" CssClass="textarea required" TextMode="MultiLine"
                                Rows="5" Height="200" Width="650"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">
                            状态：
                        </th>
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
                            <asp:TextBox ID="tbsort" runat="server" CssClass="input w160 required digits">0</asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="spClear">
                </div>
                <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">
                            会员信息（只读）：
                        </th>
                    </tr>
                    <tr>
                        <td>
                            用户类型：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlmembertype" runat="server" CssClass="select selectNone"
                                Width="160" Enabled="false">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            用户名：
                        </td>
                        <td>
                            <asp:TextBox ID="tbusername" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            会员编号：
                        </td>
                        <td>
                            <asp:TextBox ID="tbuserid" runat="server" ReadOnly="true"></asp:TextBox>
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
