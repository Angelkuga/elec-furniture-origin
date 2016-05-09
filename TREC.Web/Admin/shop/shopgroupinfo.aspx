<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shopgroupinfo.aspx.cs" Inherits="TREC.Web.Admin.shop.shopgroupinfo" %>
<%@ Import Namespace="TREC.ECommerce" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/My97DatePicker/WdatePicker.js"></script>
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
        .formTable{border:1px solid #ccc;}
        .formTable tr th{background:#ededed; text-align:left;}
        .formTable tr td{border:none; padding-top:8px; padding-bottom:8px;}
    </style>
</head>
<body style="padding:10px;">
<form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="shopgrouplist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 店铺管理 &gt; 店铺组管理</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="3" align="left">卖场组信息</th>
        </tr>
        <tr>
            <td width="120" align="right">
                名称 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txttitle" runat="server" CssClass="w160 input required"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                颜色 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtcolor" runat="server" CssClass="w160 input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                组图标 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtavatar" runat="server" CssClass="w160 input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                积分 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtintegral" runat="server" CssClass="w160 input required number">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                金钱 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtmoney" runat="server" CssClass="w160 input required number">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                广告数量 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtadcount" runat="server" CssClass="w160 input required digits">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                卖场数量 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtmarketcount" runat="server" CssClass="w160 input required digits">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                品牌数量 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtbrandcount" runat="server" CssClass="w160 input required digits">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                促销数量 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtpromotioncount" runat="server" CssClass="w160 input required digits">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                广告推荐数量 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtadrecommend" runat="server" CssClass="w160 input required digits">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                卖场推荐数量 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtmarketrecommend" runat="server" CssClass="w160 input required digits">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                品牌推荐数量 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtbrandrecommend" runat="server" CssClass="w160 input required digits">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                促销推荐数量 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtpromotionrecommend" runat="server" CssClass="w160 input required digits">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                楼层数量 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtstoreycount" runat="server" CssClass="w160 input required digits">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                楼层店铺数量 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtstoreyshopcount" runat="server" CssClass="w160 input required digits">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                权限 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtpermissions" runat="server" CssClass="w160 input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                级别 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtlev" runat="server" CssClass="w160 input required digits">1</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                描述 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtdescript" runat="server" CssClass=" w380 textarea" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                排序 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txtsort" runat="server" CssClass="w160 input required digits">0</asp:TextBox>
            </td>
        </tr>
    </table>
    
    <div style="margin-top:10px; margin-left:140px">
  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
            onclick="btnSave_Click" /><input name="重置" type="reset" class="submit" value="重置" />
</div>
</form>
</body>
</html>
