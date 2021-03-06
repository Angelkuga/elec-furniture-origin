﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="articleinfo.aspx.cs" Inherits="TREC.Web.Admin.article.articleinfo" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ Import Namespace="TREC.Entity" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>文档信息</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/editor/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/fileupload.js"></script>
    <script type="text/javascript" src="../script/function.js"></script>    
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
                editor = K.create('#txtcontext', {
                    allowPreviewEmoticons: true,
                    allowImageUpload: true,
                    allowFileManager: true,
                    <%if (ECommon.QueryId != "" && ECommon.QueryEdit != "")
                    { %>
                     fileManagerJson:"<%=ECommon.WebAdminResourceUrl %>/editor/kindeditor/ashx/file_manager_json.ashx?m=article&id=<%=ECommon.QueryId %>",
                    <%} %>
                    allowMediaUpload: true,
                });
            });

            //显示关闭高级选项
            $("#upordown").toggle(function() {
                $(this).text("关闭高级选项");
                $(this).removeClass();
                $(this).addClass("up-01");
                $(".upordown").show();
            }, function() {
                $(this).text("显示高级选项");
                $(this).removeClass();
                $(this).addClass("up-02");
                $(".upordown").hide();
            });

        });
    </script>
</head>

<body style="padding:10px;">
<form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="articlelist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 文档信息 &gt; 文档信息</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">文档信息</th>
        </tr>
        <tr>
            <td align="right" width="15%">
                所属分类 ：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlcategory" runat="server" CssClass="select"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                文章标题 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txttitle" runat="server" CssClass="input w380 required" maxlength="50" minlength="3" HintTitle="信息标题" HintInfo="控制在50个字数内，标题文本尽量不要太长。"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                推荐类别 ：
            </td>
            <td align="left">
                <asp:CheckBoxList ID="chkattribute" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
                <span id="upordown" class="up-02">显示高级选项</span>
            </td>
        </tr>
        <tr class="upordown hide">
            <td align="right">
                文章作者 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtautho" runat="server" CssClass="input w250" maxlength="30" HintTitle="作者" HintInfo="控制在30个字数内，如“管理员”。">管理员</asp:TextBox>
            </td>
        </tr>
        <tr class="upordown hide">
            <td align="right">
                文章来源 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtsource" runat="server" CssClass="input w250" maxlength="30" HintTitle="信息来源" HintInfo="控制在30个字数内，如“本站”。">本站</asp:TextBox>
            </td>
        </tr>
        
        <tr  class="upordown hide">
            <td align="right">
                连接地址 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtlinkurl" runat="server" CssClass="input w250" maxlength="150" HintTitle="内容外部连接" HintInfo="当信息为站外信息时，填写连接址 例;http://www.baidu.com,地址前缀http://必须填写，长度不超过150"></asp:TextBox>
            </td>
        </tr>
        <tr class="upordown hide">
            <td align="right">
                文章排序 ：
            </td>
            <td align="left">
                    <asp:TextBox ID="txtsort" runat="server" CssClass="input required number valid" size="10" 
                maxlength="10" HintTitle="信息排序" HintInfo="纯数字，数值越大越靠前。">0</asp:TextBox>
            </td>
        </tr>
        <tr class="upordown hide">
            <td align="right">
                文章关键字 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtkeyword" runat="server" CssClass="input w250" maxlength="100" HintTitle="Meta关键字" HintInfo="用于搜索引擎，如有多个关健字请用英文的,号分隔，不填写将自动提取标题。"></asp:TextBox>
            </td>
        </tr>
        <tr class="upordown hide">
            <td align="right">
                文章描述 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtdescript" runat="server" CssClass="textarea wh380"  
            maxlength="250" HintTitle="描述" 
                    HintInfo="用于搜索引擎或内容描述，控制在250个字数内，不填写将自动提取内容前200个字符。" TextMode="MultiLine" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                文章副标题 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtsubtitle" runat="server" CssClass="input w250" ></asp:TextBox>
            </td>
        </tr>
        <tr style="display:none">
            <td align="right" >
                文章索引 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtletter" runat="server" CssClass="input w250" ></asp:TextBox>
            </td>
        </tr>
        <tr style="display:none">
            <td align="right">
                文章副分类 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtsubcategoryid" runat="server" CssClass="input w250" ></asp:TextBox>
            </td>
        </tr>
        <tr style="display:none">
            <td align="right">
                文章图标 ：
            </td>
            <td align="left">
                
                <asp:HiddenField ID="hfico" runat="server" />
                    
            </td>
        </tr>
        <tr>
            <td align="right">
                文章缩略图 ：
            </td>
            <td align="left">
                <div class="fileUpload" path="<%=string.Format(EnFilePath.Article,EnFilePath.Thumb,ECommon.QueryId)%>">
                <asp:HiddenField ID="hfthumb" runat="server" />
                    <div class="fileTools">
                        <input type="text" class="input w250 filedisplay"  />
                        <a href="javascript:;" class="files"><input id="File2" type="file" class="upload" onchange="_upfile(this)"  runat="server" /></a>
                        <span class="uploading">正在上传，请稍后……</span>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td align="right">
                文章幻灯图 ：
            </td>
            <td align="left">
                <div class="fileUpload" path="<%=string.Format(EnFilePath.Article,EnFilePath.Banner,ECommon.QueryId)%>">
                <asp:HiddenField ID="hfbanner" runat="server" />
                    <div class="fileTools">
                        <input type="text" class="input w250 filedisplay"  />
                        <a href="javascript:;" class="files"><input id="File3" type="file" class="upload" onchange="_upfile(this)"  runat="server" /></a>
                        <span class="uploading">正在上传，请稍后……</span>
                    </div>
                </div>
            </td>
        </tr>
        
        <tr>
            <td align="right">
                文章内容 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtcontext" runat="server" CssClass="textarea" TextMode="MultiLine" cols="100" rows="8" style="width:100%;height:400px;" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                浏览次数 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtclickcount" runat="server" CssClass="input required number valid" size="10" 
                maxlength="10" HintTitle="信息浏览次数" HintInfo="纯数字，本信息被阅读的次数。">0</asp:TextBox>
            </td>
        </tr>
        
    </table>
    <div style="margin-top:10px; text-align:center">
  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
            onclick="btnSave_Click" />&nbsp;<input name="重置" type="reset" class="submit" value="重置" />
</div>
</form>
</body>
</html>
