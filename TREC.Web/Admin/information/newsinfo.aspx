<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsinfo.aspx.cs" Inherits="TREC.Web.Admin.information.newsinfo" %>
<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <style type="text/css">
        .formTable{border:1px solid #ccc;}
        .formTable tr th{background:#ededed; text-align:left;}
        .formTable tr td{border:none; padding-top:8px; padding-bottom:8px;}
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
<body style="padding:10px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="back"><a href="newslist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 促销信息模块 &gt; 行业资讯信息</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">行业信息</th>
        </tr>
        <tr>
            <td>
                <table class="formTable" width="770">
                    <tr>
                        <th colspan="2">基本信息：</th>
                    </tr>
                    <tr>
                        <td align="right" width="70">新闻标题：</td>
                        <td><asp:TextBox ID="tbTitle" runat="server" Width="600"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right" width="70">索引：</td>
                        <td><asp:TextBox ID="tbLetter" runat="server" Width="600"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right" width="70">导读：</td>
                        <td>
                            <asp:TextBox ID="tbIntro" runat="server" Width="600" TextMode="MultiLine" Rows="6"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="70">详情介绍：</td>
                        <td>
                            <asp:TextBox id="tbDescript" runat="server" CssClass="textarea required" TextMode="MultiLine" Rows="5" Height="200" Width="650"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">状态：</th>
                    </tr>
                    <tr>
                        <td align="right">审核状态：</td>
                        <td><asp:DropDownList ID="ddlauditstatus" runat="server" CssClass="select selectNone" Width="160"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">上/下线：</td>
                        <td><asp:DropDownList ID="ddllinestatus" runat="server" CssClass="select selectNone" Width="160"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">日期：</td>
                        <td><asp:TextBox ID="txxcreattime" runat="server" CssClass="input Wdate w160 required" onfocus="WdatePicker()"></asp:TextBox></td>
                    </tr>
                </table>
                <div class="spClear"></div>
                <table id="userinfobox" runat="server" class="formTable" width="380">
                    <tr>
                        <th colspan="2">会员信息（只读）：</th>
                    </tr>
                    <tr>
                        <td>用户类型：</td>
                        <td><asp:DropDownList ID="ddlmembertype" runat="server" CssClass="select selectNone" Width="160" Enabled="false"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>用户名：</td>
                        <td><asp:TextBox ID="tbusername" runat="server" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>会员编号：</td>
                        <td><asp:TextBox ID="tbuserid" runat="server" ReadOnly="true"></asp:TextBox></td>
                    </tr>
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
