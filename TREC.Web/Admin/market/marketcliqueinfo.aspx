<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="marketcliqueinfo.aspx.cs"
    Inherits="TREC.Web.Admin.market.marketcliqueinfo" %>

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
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/Aliyunfileupload.js"></script>
    <style>
        .fileTools ._filedel
        {
            display: none;
        }
        .marketlist
        {
            width: 200px;
            float: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="back"><a href="marketcliquelist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 后台供应商 &gt;
            卖场集团管理</b>
    </div>
    <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="3" align="left">
                登陆账号信息
            </th>
        </tr>
        <tr>
            <td width="390px" valign="top">
                <table class="formTable" width="380px">
                    <tr>
                        <th colspan="2">
                            账号信息：
                        </th>
                    </tr>
                    <%if (ECommon.QueryId != "" && ECommon.QueryEdit != "" && _memberInfo != null)
                      { %>
                    <tr>
                        <td align="right" width="70">
                            通&nbsp;行&nbsp;&nbsp;证：
                        </td>
                        <td>
                            <%=_memberInfo.passport %>
                        </td>
                    </tr>
                    <%}
                      else
                      { %>
                    <tr>
                        <td align="right" width="70">
                            会员查找：
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="w160 input"></asp:TextBox>&nbsp;<input
                                type="button" class="submit" value="查找" id="btnSearch" />
                        </td>
                    </tr>
                    <%} %>
                    <tr>
                        <td align="right">
                            登陆账号：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlmember" runat="server" CssClass="select selectNone" Width="160">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div class="spClear">
                </div>
                <table class="formTable" width="380px">
                    <tr>
                        <th colspan="2">
                            企业信息：
                        </th>
                    </tr>
                    <tr>
                        <td align="right">
                            集团名称：
                        </td>
                        <td>
                            <asp:TextBox ID="txttitle" runat="server" CssClass="input required w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            董事长姓名 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtchairman" runat="server" CssClass="input required w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            董事长致辞 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtchairmanoration" runat="server" CssClass="input input required w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            电话 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txt_phone" runat="server" CssClass="input input required w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            地址 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txt_address" runat="server" CssClass="input input required w160"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            集团介绍：
                        </td>
                        <td>
                            <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea required kinkeditor"
                                TextMode="MultiLine" Rows="5" Width="250" Height="120"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="spClear">
                </div>
                <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">
                            图片信息:
                        </th>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            董事长照片：
                        </td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Market, _mainmarketid, TREC.Entity.EnFilePath.Chairman)%>">
                                <asp:HiddenField ID="hfchairmanimg" runat="server" />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files">
                                        <input id="File1" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="70px" align="right">
                            集团缩略图：
                        </td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Market, _mainmarketid, TREC.Entity.EnFilePath.MarketCliqueThumb)%>">
                                <asp:HiddenField ID="hfthumbimg" runat="server" />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files">
                                        <input id="File2" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            形象图：
                        </td>
                        <td>
                            <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Market, _mainmarketid, TREC.Entity.EnFilePath.MarketClique)%>">
                                <asp:HiddenField ID="hfinfoimg" runat="server" />
                                <div class="fileTools">
                                    <input type="text" class="input w160 filedisplay" />
                                    <a href="javascript:;" class="files">
                                        <input id="File3" type="file" class="upload" onchange="_upfile(this,'0')" runat="server" /></a>
                                    <span class="uploading">正在上传，请稍后……</span>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <table class="formTable" width="380px">
                    <tr>
                        <th colspan="2">
                            集团旗下的子卖场：
                        </th>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <%=_submarket %>
                        </td>
                    </tr>
                </table>
                <div class="spClear">
                </div>
                <table class="formTable" width="380">
                    <tr>
                        <th colspan="2">
                            企业状态:
                        </th>
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
                    <%if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
                      { %>
                    <tr>
                        <td align="right">
                            最后修改 ：
                        </td>
                        <td>
                            <asp:Label ID="txtlastedittime" runat="server" CssClass="input w160 required"></asp:Label>
                        </td>
                    </tr>
                    <%} %>
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
