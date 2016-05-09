<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="configtypeinfo.aspx.cs" Inherits="TREC.Web.Admin.config.configtypeinfo" EnableEventValidation="false" %>
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
    <script type="text/javascript">
        $(function () {
            //表单验证JS
            $("#form1").validate({
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

            $("#btnSave").click(function () {
                if ($("#txtmark").val() == "") { alert("请输入标识！")}
                $.ajax(function () {
                    url:'../ajax/adminajax.ashx',
                    data:'type=getconfigtypemarket&v='+$("#txtmark").val()+"&t=<%=ECommon.QueryId %>",
                    success:function(data){
                           if(data=="1")
                           {
                            return true;
                           }
                    }
                })

            })
        });


    </script>
</head>

<body style="padding:10px;">
<form id="form1" runat="server">
    <div class="navigation">
      <span class="back"><a href="configtypelist.aspx">返回列表</a></span><b>您当前的位置：首页 &gt; 系统管理 &gt; 配置管理</b>
    </div>
    <div class="spClear"></div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
        <tr>
            <th colspan="2" align="left">配置类型信息</th>
        </tr> 
        <tr>
	        <td width="160px" align="right">配置类型名称：</td>
	        <td align="left">
		        <asp:TextBox id="txttitle" runat="server" CssClass="input required w250"></asp:TextBox>
	        </td>
        </tr>
        <tr>
            <td align="right">
                标识 ：
            </td>
            <td >
                <asp:TextBox ID="txtmark" runat="server" CssClass="input required  w160"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                索引 ：
            </td>
            <td >
                <asp:TextBox ID="txtletter" runat="server" CssClass="input required w160"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                配置模块 ：
            </td>
            <td >
                <asp:DropDownList ID="ddltype" runat="server" CssClass="select selectNone"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td align="right">
                对象数量 ：
            </td>
            <td >
                <asp:TextBox ID="txtcount" runat="server" CssClass="input required digits" Width="40">0</asp:TextBox>
            </td>
        </tr>
	   <tr>
	        <td align="right">排序：</td>
	        <td align="left">
		        <asp:TextBox id="txtsort" runat="server" Width="40px" CssClass="input required digits">0</asp:TextBox>
	        </td>
      </tr>
       <tr>
            <td align="right">
                描述 ：
            </td>
            <td >
                <asp:TextBox id="txtdescript" runat="server" CssClass="textarea w380" TextMode="MultiLine" Rows="5"></asp:TextBox>
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
