<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="../Member.Master"  CodeBehind="memberinfo.aspx.cs" Inherits="TREC.Web.Suppler.memberinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.form.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/additional-methods.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/messages_cn.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl %>/script/jquery.area.js"></script>
    <script type="text/javascript" src="../script/supplercommon.js"></script>
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
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="6" cellspacing="1" class="formTable">
        <tr>
            <td class="tl" align="right" width="160px">
                真实姓名：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtTruename" runat="server" CssClass="input required w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tl" align="right">
                性别：
            </td>
            <td class="tr">
                <asp:RadioButtonList ID="raGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="女" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr style="display: none">
            <td class="tl" align="right">
                出生日期：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtBirthDate" runat="server" CssClass="input Wdate  w250" onfocus="WdatePicker()"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tl" align="right">
                Email：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tl" align="right">
                手机：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtMobile" runat="server" CssClass="input required number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tl" align="right">
                电话：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="input required  w250"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td class="tl" align="right">
                收款银行：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtBank" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td class="tl" align="right">
                银行账号：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtAccount" runat="server" CssClass="input number  w250"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td class="tl" align="right">
                地址：
            </td>
            <td class="tr">
                <div class="_droparea" id="ddlareacode" title="<%=memberInfo.areacode%>">
                </div>
            </td>
        </tr>
        <tr style="display: none">
            <td class="tl" align="right">
                详细地址：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="input required w380"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td class="tl" align="right">
                支付宝：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtAlipay" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td class="tl" align="right">
                Msn：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtMsn" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td class="tl" align="right">
                QQ：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtQQ" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td class="tl" align="right">
                ali：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtAli" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td class="tl" align="right">
                skype：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtSkype" runat="server" CssClass="input  w250"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td class="tl" align="right">
                部门：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtDepartment" runat="server" CssClass="input "></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tl" align="right">
                职位：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtCareer" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tl" align="right">
                找回密码问题：
            </td>
            <td class="tr">
                <asp:DropDownList runat="server" ID="selquestion">
                    <asp:ListItem Value="0">--请选择--</asp:ListItem>
                    <asp:ListItem Value="1">您的生日是？</asp:ListItem>
                    <asp:ListItem Value="2">您毕业的学校是？</asp:ListItem>
                    <asp:ListItem Value="3">您父亲的名字是？</asp:ListItem>
                    <asp:ListItem Value="4">您母亲的名字是？</asp:ListItem>
                    <asp:ListItem Value="5">您的出生地是？</asp:ListItem>
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td class="tl" align="right">
                找回密码回答：
            </td>
            <td class="tr">
                <asp:TextBox ID="txtanswer" runat="server" CssClass="input"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tl" align="right">
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnEdit" runat="server" CssClass="submit" Text="保 存" OnClick="btnEdit_Click" />
                <input type="button" value=" 返 回 " class="submit" onclick="history.back(-1);" />
            </td>
        </tr>
    </table>
</asp:Content>