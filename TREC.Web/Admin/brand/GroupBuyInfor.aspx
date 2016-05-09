<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupBuyInfor.aspx.cs" Inherits="TREC.Web.Admin.shop.GroupBuyInfor" %>
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
     <script type="text/javascript" src="<%=ECommon.WebAdminResourceUrl %>/script/Aliyunfileupload.js"></script>
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
            <th colspan="3" align="left">折扣信息</th>
        </tr>
        <tr>
            <td width="120" align="right">
                品牌名称 ：
            </td>
            <td  align="left">
                <asp:TextBox ID="txttitle" runat="server" CssClass="w160 input required" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td width="120" align="right">
                团购标题：
            </td>
            <td  align="left">
                <asp:TextBox ID="txt_tgtitle" runat="server" CssClass="w160 input required"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td width="120" align="right">
                线下体验馆：
            </td>
            <td  align="left">
                <asp:TextBox ID="txt_unline" runat="server" CssClass="w160 input required"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td width="120" align="right">
                排序：
            </td>
            <td  align="left">
                <asp:TextBox ID="txt_orderby" runat="server" CssClass="w160 input required"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td width="120" align="right">
                首页推荐：
            </td>
            <td  align="left">
                <asp:CheckBox ID="check_default" runat="server" />
            </td>
        </tr>
        <tr>
            <td width="120" align="right">
                展位号：
            </td>
            <td  align="left">
                <asp:TextBox ID="txt_showpos" runat="server" CssClass="w160 input required"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td width="120" align="right">
                折数起步：
            </td>
            <td  align="left">
                <asp:TextBox ID="txt_zsbegin" runat="server" CssClass="w160 input required"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="right">
                打折信息1：
            </td>
            <td  align="left">
            <div style="float:left;">
                <asp:TextBox ID="txt_user1" runat="server" Width="50"></asp:TextBox></div>
                <div style="float:left;">元 </div>
            <div style="float:left;"><asp:TextBox ID="txt_DiscountPerson1" runat="server" CssClass="w160 input" Width="50"></asp:TextBox></div>
                <div style="float:left;">人</div>
                <div style="float:left;"><asp:TextBox ID="txt_DiscountResult1" runat="server" CssClass="w160 input" Width="50"></asp:TextBox></div>
                <div style="float:left;">折</div>
            </td>
        </tr>
        <tr>
            <td align="right">
                打折信息2：
            </td>
            <td  align="left">
              <div style="float:left;">
                <asp:TextBox ID="txt_user2" runat="server" Width="50"></asp:TextBox></div>
                <div style="float:left;">元 </div>
            <div style="float:left;"><asp:TextBox ID="txt_DiscountPerson2" runat="server" CssClass="w160 input" Width="50"></asp:TextBox></div>
                <div style="float:left;">人</div>
                <div style="float:left;"><asp:TextBox ID="txt_DiscountResult2" runat="server" CssClass="w160 input" Width="50"></asp:TextBox></div>
                <div style="float:left;">折</div>
            </td>
        </tr>
        <tr>
            <td align="right">
                logo ：
            </td>
            <td>
             <div class="fileUpload" path="">
                    <asp:HiddenField ID="hidelogimg" runat="server" />
                    <div class="fileTools" style="width: 410px">
                        <input type="text" class="input w250 filedisplay"  id="mklogimg"/>
                        <a href="javascript:;" class="files">
                            <input id="File4" type="file" class="upload" onchange="_upfileiswater(this,'0')" runat="server" /></a>
                        <span class="uploading">上传中</span>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    
    <div style="margin-top:10px; margin-left:140px">
  <asp:Button ID="btnSave" runat="server" Text="确认保存" CssClass="submit" 
            onclick="btnSave_Click" />
</div>
</form>
</body>
</html>
