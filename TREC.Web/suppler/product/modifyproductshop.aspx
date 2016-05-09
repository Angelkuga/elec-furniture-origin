<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modifyproductshop.aspx.cs"  MasterPageFile="../Member.Master"     Inherits="TREC.Web.Suppler.product.modifyproductshop" %>
<%@ Import Namespace="TREC.ECommerce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <link rel="stylesheet" type="text/css" href="../../resource/altdialog/skins/default.css" />
    <script type="text/javascript" src="<%=ECommon.WebSupplerResourceUrl %>/script/jquery-1.7.1.min.js"></script>
    <script src="../script/formValidatorRegex.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="attriubteDialog">
        <table class="formTable" width="100%">
            <tr>
                <td align="right">
                    选中产品：
                </td>
                <td>
                    <asp:Label runat="server" ID="lb_productname"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 120px; *width: 150px;" align="right">
                    选择<b>店铺：</b>
                </td>
                <td>
                    <asp:DropDownList ID="ddlshop" runat="server" CssClass="select selectNone" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlshop_SelectedIndexChanged">
                    </asp:DropDownList>
                    <div id="ddlshopTip" style="width: 280px; float: left" class="forTip">
                </div>
                </td>
            </tr>
            <tr>
                <td align="right">
                    销售价格：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtprice"  CssClass="input required" MaxLength="8" Width="165px"></asp:TextBox>
                    <div id="txtpriceTip" style="width: 280px; float: left" class="forTip">
                </div>
                </td>
            </tr>
            <tr>
                <td align="right">
                    促销价格：
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtdollprice"  CssClass="input required" MaxLength="8" Width="165px">0</asp:TextBox>0表示不促销
                    <div id="txtdollpriceTip" style="width: 280px; float: left" class="forTip">
                </div>
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td>
                    <asp:HiddenField runat="server" ID="ismodify" Value="0" />
                    <asp:Button ID="btnSave" runat="server" OnClientClick="return Btnok();" Text="确认保存" CssClass="submit" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    <script>
        function Btnok() {

            var shopid = $("#<%=ddlshop.ClientID %>");
            var price = $("#<%=txtprice.ClientID %>");
            var dollprice = $("##<%=txtdollprice.ClientID %>");
            if (shopid.val() == "") {
                alert('抱歉，请选择店铺！');
                return false;
            }
            if (price.val() == "") {
                alert('抱歉，金额不能为空！');
                price.focus();
                return false;
            }
            if (dollprice.val() == "") {
                alert('抱歉，促销金额不能为空！');
                dollprice.focus();
                return false;
            }
            //var a = /^[0-9]*(\.[0-9]{1,2})?$/;
            var a = new RegExp(regexEnum.decmal1);         
            if (!a.test(price.val())) {
                alert("抱歉，金额格式不正确");
               price.focus();
                return false;
            }
            if (!a.test(dollprice.val())) {
                alert("抱歉，金额格式不正确");
              dollprice.focus();
                return false;
            }
            return true;
        }
    </script>
<div class="clear"></div>
</asp:Content>
