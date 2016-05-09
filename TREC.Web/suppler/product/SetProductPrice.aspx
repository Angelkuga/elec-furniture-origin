<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="SetProductPrice.aspx.cs" Inherits="TREC.Web.Suppler.product.SetProductPrice" %>

<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.tjword em{font-style:normal;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u>调价管理</u></h1></div>
<div class="maincon">
  <div class="maintabcor"> <br />
    <br />
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="216" height="40" align="right">&nbsp;品牌</td>
    <td width="94" class="textleft"><select id="brandId">
        <option value="">请选择</option>
        <asp:Repeater ID="RptBrand" runat="server">
        <ItemTemplate><option value="<%#Eval("id") %>"><%#Eval("title") %></option></ItemTemplate>
        </asp:Repeater>
      </select></td>
    <td width="40" align="right">系列</td>
    <td width="400" class="textleft"><select id="SeriesId">
    <option value="">请选择</option>
    </select></td>
  </tr>
  <tr>
    <td height="40" align="right">店铺</td>
    <td colspan="3" class="textleft"><select id="ShopId">
        <option value="">请选择</option>
        <%=shopStr%>
      </select></td>
    </tr>
  <tr>
    <td height="40" align="center"><label></label></td>
    <td height="40" colspan="3" class="textleft"><input name="PriceType" type="radio" value="1" checked="checked" />
根据市场价调整销售价&nbsp;&nbsp;
<input type="radio" name="PriceType" value="0" />
根据销售价调整市场
&nbsp;&nbsp;
<input type="radio" name="PriceType" value="2" />
根据市场价调整促销价

</td>
    </tr>
  <tr>
    <td height="103" align="center">&nbsp;</td>
    <td height="103" colspan="3" class="tjword textleft"><em>销售价</em>=<em>市场价</em>&nbsp;X&nbsp;
      <label>
      <input id="PricePercentage" maxlength="3" type="text" size="6" />
%</label></td>
    </tr>
</table>
    <div class="btnone bordtop">
      <input type="button" onclick="SetPrice(this);" class="btnl" value="保 存" />
    </div>
  </div></div>
    <script src="../script/formValidatorRegex.js" type="text/javascript"></script>
    <script src="../script/myPublic.js" type="text/javascript"></script>

<script type="text/javascript">
<!--
    $(function () {
        $('#PricePercentage').numeral();
        $('input[name=PriceType]').click(function () {
            var myvalue = $(this).val();
            if (myvalue.toString() == '1') {
                $('.tjword>em:eq(0)').html('销售价');
                $('.tjword>em:eq(1)').html('市场价');
            } else if (myvalue.toString() == '0') {
                $('.tjword>em:eq(1)').html('销售价');
                $('.tjword>em:eq(0)').html('市场价');
            }
            else if (myvalue.toString() == '2') {
                $('.tjword>em:eq(1)').html('市场价');
                $('.tjword>em:eq(0)').html('促销价');
            }
        });
        // LoadSeriesDb('');
        //  LoadShopDb('', '');
        $('#brandId').change(function () {
            if (this.value != "") {
                $.ajax({
                    url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                    data: 'type=getbrands&v=' + this.value + "&ram=" + Math.random(),
                    dataType: 'json',
                    success: function (data) {
                        $.each(data, function (i) {
                            if (data[i].id != "" && data[i].title != "") {
                                $("#SeriesId").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                            }
                        });
                    }
                });
            }

            var myvalue = $(this).val();
            //  LoadSeriesDb(myvalue.toString());
            //  LoadShopDb(myvalue.toString(), '');
        });

        $('#SeriesId').change(function () {
            var myvalue = $(this).val();
            var brandId = $('#brandId option:selected').val();
            // LoadShopDb(brandId.toString(), myvalue.toString());
        });
    });

    function LoadSeriesDb(brandId) {
        $('#SeriesId').empty();
        $('<option>加载数据中...</option>').appendTo($('#SeriesId'));
        $.get('../ajax/MemberHandler.ashx', { Action: 'brandseries', brandId: brandId.toString() }, function (data) {
            $('#SeriesId').empty();
            $('<option value="">请选择</option>').appendTo($('#SeriesId'));
            if (data != null) {
                if (data.toString() != 'no') {
                    $(data).appendTo($('#SeriesId'));
                }
            }
        });
    }

    function LoadShopDb(brandId, seriesId) {
        $('#ShopId').empty();
        $('<option>加载数据中...</option>').appendTo($('#ShopId'));
        $.get('../MemberAjax/ProductHandler.ashx', { Action: 'productshop', brandId: brandId.toString(), seriesId: seriesId.toString(), rnd: Math.random() }, function (data) {
            $('#ShopId').empty();
            $('<option value="">请选择</option>').appendTo($('#ShopId'));
            if (data != null) {
                if (data.toString() != 'no') {
                    $(data).appendTo($('#ShopId'));
                }
            }
        });
    }

    function SetPrice(obj) {
        var brandId = $.trim($('#brandId option:selected').val());
        if (brandId == '') {
            alert('请选择品牌！');
            $('#brandId').focus();
            return;
        }
        var PP = $.trim($('#PricePercentage').val());
        if (PP == '') {
            alert('请输入调价百分比！');
            $('#PricePercentage').focus();
            return;
        }
        if (parseInt(PP.toString(), 10) == 0) {
            if (PP == '') {
                alert('调价百分比不能为0！');
                $('#PricePercentage').focus();
                return;
            }
        }
        var seriesId = $.trim($('#SeriesId option:selected').val());
        var ShopId = $.trim($('#ShopId option:selected').val());
        var PriceType = $('input[name=PriceType]:checked').val();
        //PriceType=1表示根据市场价调整销售价；PriceType=0表示根据销售价调整市场价
        $.get('../ajax/MemberHandler.ashx', { Action: 'setprice', brandId: brandId.toString(), seriesId: seriesId.toString(), shopId: ShopId.toString(), pricetype: PriceType.toString(), pp: PP.toString(), rnd: Math.random() }, function (data) {            
            var TypeName = '根据市场价调整销售价';
            if (PriceType.toString() == '0') {
                TypeName = '根据销售价调整市场价';
            }
            if (data != null) {               
                    alert('调价成功！');
                
            } else {
                alert('系统正忙，请稍后调整产品价格！');
            }
        });
    }
//-->
</script>
</asp:Content>