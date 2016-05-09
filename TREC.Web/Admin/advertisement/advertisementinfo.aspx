<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="advertisementinfo.aspx.cs"
    Inherits="TREC.Web.Admin.advertisement.advertisementinfo" %>

<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>广告信息</title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebAdminResourceUrl.TrimEnd('/') %>/script/fileupload.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/My97DatePicker/WdatePicker.js"></script>
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
        });
    </script>
    <style type="text/css">
        .adType
        {
            display: none;
        }
    </style>
</head>
<body style="padding: 10px;">
    <form id="form1" runat="server">
    <div class="navigation">
        <span class="back"><a href="advertisementlist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt;
            营销互动 &gt; 广告管理</b>
    </div>
    <div class="spClear">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">
                广告信息
            </th>
        </tr>
        <tr>
            <td width="160px" align="right">
                所属广告位 ：
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="select selectNone  w250"
                    onchange="SetAdType()">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                广告名称 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txttitle" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                推广产品连接地址 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtlinkurl" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <tr id="adFlash" class="adType">
            <td width="160px" align="right" style="color: #f30">
                Falsh地址 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtflashurl" runat="server" CssClass="input" Width="380px"></asp:TextBox>
            </td>
        </tr>
        <tr id="Tr1" class="adType">
            <td width="160px" align="right" style="color: #f30">
                视频地址： ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtvideourl" runat="server" CssClass="input" Width="380px"></asp:TextBox>
            </td>
        </tr>
        <tr id="adText" class="adType">
            <td align="right" style="color: #f30">
                文字广告 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtadtext" runat="server" CssClass="input" Width="380px"></asp:TextBox>
            </td>
        </tr>
        <tr id="adCode" class="adType">
            <td width="160px" align="right" style="color: #f30">
                广告代码 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtadcode" runat="server" CssClass="textarea" TextMode="MultiLine"
                    Rows="4" Width="380px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                是否开启 ：
            </td>
            <td align="left">
                <asp:RadioButtonList runat="server" ID="raOpen" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="否" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                联系人 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtadlinkman" runat="server" CssClass="input w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                联系电话 ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtadlinkphone" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                Email ：
            </td>
            <td align="left">
                <asp:TextBox ID="txtadlinkemail" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  width="160px" align="right">
                <a href="javascript:;" onclick="imgUrlChg();">图片URL方式</a>
            </td><td align="left"></td>
        </tr>
        <tr id="adImageA" <%if(_isuplodimg==0){ %>style="display:none"<%} %>>
            <td width="160px" align="right" >
                上传图片地址：
            </td>
            <td align="left">
                <div class="fileUpload" path="<%=string.Format(TREC.Entity.EnFilePath.Ad, ECommon.QueryId, TREC.Entity.EnFilePath.Thumb)%>">
                    <asp:HiddenField ID="hfimgurl" runat="server" />
                    <div class="fileTools">
                        <input type="text" class="input w160 filedisplay" id="htmltxtimg" />
                        <a href="javascript:;" class="files">
                            <input id="File1" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                        <span class="uploading">正在上传，请稍后……</span>
                    </div>
                </div>   
                <input type="button" value="清除上传连接" onclick="$('#<%=hfimgurl.ClientID%>').val('');$('#htmltxtimg').val('');" />
            </td>
        </tr>
        <tr id="adImageB" <%if(_isuplodimg==1){ %>style="display:none"<%} %>>
            <td width="160px" align="right">
                连接图片URL:
            </td>
            <td align="left">
                <asp:TextBox ID="txtimgurlfull" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                推广产品促销价:
            </td>
            <td align="left">
                <asp:TextBox ID="txtprice" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                推广产品原始价:
            </td>
            <td align="left">
                <asp:TextBox ID="txtorgprice" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                推广产品ID:
            </td>
            <td align="left">
                <asp:TextBox ID="txtprodID" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                开始时间:
            </td>
            <td align="left">
                <asp:TextBox ID="txtstarttime" runat="server" CssClass="input  w250"></asp:TextBox>
                <img onclick="WdatePicker({el:'txtstarttime'})" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/My97DatePicker/skin/datePicker.gif"
                    width="16" height="22" style="cursor: pointer" align="absmiddle">
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                结束时间:
            </td>
            <td align="left">
                <asp:TextBox ID="txtendtime" runat="server" CssClass="input  w250"></asp:TextBox>
                <img onclick="WdatePicker({el:'txtendtime'})" src="<%=ECommon.WebAdminResourceUrl.TrimEnd('/') %>/My97DatePicker/skin/datePicker.gif"
                    width="16" height="22" style="cursor: pointer" align="absmiddle">
            </td>
        </tr>
        <tr>
            <td width="160px" align="right">
                排序:
            </td>
            <td align="left">
                <asp:TextBox ID="txtsort" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <%if (ECommon.QueryEdit != "")
          { %>
        <tr>
            <td width="160px" align="right">
                其它信息 ：
            </td>
            <td align="left">
                <asp:Label ID="lbOther" runat="server"></asp:Label>
            </td>
        </tr>
        <%} %>
    </table>
    <div style="margin-top: 10px; margin-left: 180px">
        <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" OnClick="btnSave_Click" /><input
            name="重置" type="reset" class="submit" value="重置" />
    </div>
    <script type="text/javascript">
        $(function () {
            $("#adImage").removeClass("adType");
        });
        function imgUrlChg() {
            if ($("#adImageA").css("display") == "none") {
                $("#adImageA").show();
                $("#adImageB").hide();
            } else {
                $("#adImageA").hide();
                $("#adImageB").show();
            }
        }
        SetAdType();
        function SetAdType() {
            $(".adType").hide();
            if ($("#ddlCategory").val() != "" && $("#ddlCategory").val() != "0") {
                jQuery.ajax({
                    url: '<%=ECommon.WebAdminUrl %>/ajax/ajaxuser.ashx',
                    data: 'type=getadcategoryadtype&v=' + $("#ddlCategory").val(),
                    success: function (data) {
                        if (data != "") {
                            if (data == "101") {
                                $("#adText").css("display", "table-row");
                            }
                            if (data == "102") {
                                $("#adImage").css("display", "table-row");
                            }
                            if (data == "103") {
                                $("#adFlash").css("display", "table-row");
                            }
                            if (data == "104") {
                                $("#adCode").css("display", "table-row");
                            }
                        }
                        else {
                            alert("数据错误!");
                        }
                    }
                });
            }
        }
    </script>
    </form>
</body>
</html>
