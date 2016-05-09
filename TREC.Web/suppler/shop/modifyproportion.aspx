<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Member.Master"  CodeBehind="modifyproportion.aspx.cs" Inherits="TREC.Web.Suppler.shop.modifyproportion" %>
<%@ Import Namespace="TREC.ECommerce" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../../resource/altdialog/skins/default.css" />
    <script src="../script/formValidatorRegex.js" type="text/javascript"></script>
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="attriubteDialog">
        <table class="formTable" width="100%">
            <tr>
                <td style="border-bottom:1px #ccc solid;" align="right">
                  选中店铺：
                </td>
                <td style="border-bottom:1px #ccc solid;">
                    <asp:Label runat="server" ID="lb_shop"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 120px; *width: 150px; border-bottom:1px #ccc solid;" align="right">
                <asp:RadioButton ID="radsale" Width="20px" Checked="true" runat="server" GroupName="PriceGroup" />
                    调整销售价：
                </td>
                <td style="border-bottom:1px #ccc solid;">
                    <table>
                    <tr>
                    <td colspan="3">
                    <asp:RadioButtonList ID="rad_type" 
                        runat="server" RepeatDirection="Horizontal" Width="200px">
                        <asp:ListItem Selected="True" Value="0">根据市场价</asp:ListItem>
                        <asp:ListItem Value="1">根据销售价</asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
                    </tr>
                    <tr>
                    <td>
                    <asp:DropDownList ID="dropadjustment" runat="server">
                        <asp:ListItem Selected="True" Value="0">上调</asp:ListItem>
                        <asp:ListItem Value="1">下调</asp:ListItem>
                    </asp:DropDownList>&nbsp;
                    </td>
                    <td>
                    <asp:TextBox runat="server" ID="txtprice"  CssClass="input required" MaxLength="8" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                    <asp:Label ID="Label1" runat="server" Text="%"></asp:Label>
                    <div id="txtpriceTip" style="width: 180px; float: left" class="forTip"></div>
                    </td>
                    </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="border-bottom:1px #ccc solid;" align="right">
                <asp:RadioButton ID="radmarket" Width="20px" runat="server" GroupName="PriceGroup" />
                    调整市场价：
                </td>
                <td style="border-bottom:1px #ccc solid;">
                <table>
                <tr>
                    <td>
                    <asp:DropDownList ID="dropadjustmentmarket" runat="server">
                        <asp:ListItem Selected="True" Value="0">上调</asp:ListItem>
                        <asp:ListItem Value="1">下调</asp:ListItem>
                    </asp:DropDownList>&nbsp;
                    </td>
                    <td>
                    <asp:TextBox runat="server" ID="txtpricemarket"  CssClass="input required" MaxLength="8" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                    <asp:Label ID="Label2" runat="server" Text="%"></asp:Label>
                    <div id="txtpriceTipmarket" style="width: 180px; float: left" class="forTip"></div>
                    </td>
                    </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="border-bottom:1px #ccc solid;" align="right">
                    促销价格：
                </td>
                <td style="border-bottom:1px #ccc solid;">
                    <asp:TextBox runat="server" ID="txtdollprice"  CssClass="input required" MaxLength="8" Width="165px">0</asp:TextBox>0表示不促销
                    <div id="txtdollpriceTip" style="width: 180px; float: left" class="forTip">
                </div>
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td>
                    <asp:HiddenField runat="server" ID="ismodify" Value="0" />
                    <asp:Button ID="btnSave" runat="server" OnClientClick="return Btnok();" 
                        Text="确认保存" CssClass="submit" onclick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    <script>
        function Btnok() {
            var adjustment = $("#dropadjustment option:selected").val();
            var shopid = $("input[name='rad_type']:checked").val();
            var price = $("#txtprice").val();
            var dollprice = $("#txtdollprice").val();
            var pricemarket = $("#txtprice").val();
            var radsalecheck = $("#radsale").checked;
            var radmarketcheck = $("#radmarket").checked;
            var reg = new regexEnum();
            if (radsalecheck) {
                if (price == "") {
                    alert('抱歉，调整比例不能为空！');
                    $("#txtprice").focus();
                    return false;
                }
            }

            if (radmarketcheck) {
                if (pricemarket == "") {
                    alert('抱歉，调整比例不能为空！');
                    $("#txtpricemarket").focus();
                    return false;
                }
            }

            if (dollprice == "") {
                alert('抱歉，促销价格不能为空！');
                $("#txtdollprice").focus();
                return false;
            }

            //var a = /^[0-9]*(\.[0-9]{1,2})?$/;
            //var a = /^([0-9]*)$/;            
            var a= new RegExp(regexEnum.decmal1);
            if (radsalecheck) {
                if (!a.test(price)) {
                    alert("抱歉，调整比例的格式不正确");
                    $("#txtprice").focus();
                    return false;
                } 
            }

            if (radmarketcheck) {
                if (!a.test(pricemarket)) {
                    alert("抱歉，调整比例的格式不正确");
                    $("#txtpricemarket").focus();
                    return false;
                } 
            }

            if (!a.test(dollprice)) {
                alert("抱歉，促销价格格式不正确");
                $("#txtdollprice").focus();
                return false;
            }
            return true;
        }
    </script>
</asp:Content>