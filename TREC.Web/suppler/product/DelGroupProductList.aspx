<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="DelGroupProductList.aspx.cs" Inherits="TREC.Web.Suppler.product.DelGroupProductList" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
   .outpop li{text-align:left;background:#fff;}
   .outpop{padding-bottom:20px;}
   .outpop input.btnlitl{margin-left:20px;}
   .outpop li input{margin-right:10px;}
    .pop{position:absolute;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u>已删除套组合</u></h1></div>
<div class="maincon">
<div class="sobox"><table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td align="right">大类</td>
    <td> <asp:DropDownList ID="ddlBigCategory" runat="server" CssClass="select" Width="80">
                </asp:DropDownList></td>
    <td align="right">状态</td>
    <td><select id="Status">
      <option value="">请选择</option>
      <option value="0">已下线</option>
      <option value="1">申请中</option>
      <option value="2">已上线</option>
    </select></td>
    <td rowspan="2" align="right">产品编号</td>
    <td rowspan="2"><input id="productNo" value="<%=productNo %>" maxlength="100" type="text" size="11" /></td>
    <td rowspan="2"><input type="button" value="搜索" onclick="searchGroupProduct();" class="btnso" /></td>
    </tr>
  <tr>
    <td align="right">品牌</td>
    <td> <asp:DropDownList ID="ddlbrand" runat="server" CssClass="select" Width="85">
                </asp:DropDownList> </td>
    <td align="right">系列</td>
    <td><select id="SeriesId">
    <option value="">请选择</option>
      <asp:Repeater ID="RptSeries" runat="server">
         <ItemTemplate><option value="<%#Eval("id")%>"><%#Eval("title")%></option></ItemTemplate>
      </asp:Repeater>
    </select></td>
    </tr>
</table>
</div>
<div class="msgtable">  
  <table width="100%" border="0" id="productlist" cellpadding="0" cellspacing="0">
  <tr class="titlecor">
    <th>选择</th>
    <th>店铺名&nbsp;<img src="../Images/bicon.gif" width="11" height="6" /></th>
    <th>大类</th>
    <th>图片</th>
    <th style="width:150px;">套组合名称</th>
    <th>销量<img src="../Images/xldown.gif" width="11" height="11" align="absmiddle" /></th>
    <th>库存<img src="../Images/xldown.gif" width="11" height="11" align="absmiddle" /></th>
    <th>状态<img src="../Images/xlup.gif" width="11" height="11" align="absmiddle" /></th>
    <th>还原</th>
    <th>删除</th>
  </tr>
  <asp:Repeater ID="RptProductList" runat="server">
      <ItemTemplate>
      <tr>
        <td><input type="checkbox" value="<%#Eval("gpId") %>" /></td>
        <td><%#Eval("ShopName")%></td>
        <td><%#Eval("CategoryName")%></td>
        <td>
        <img src="<%#TREC.Entity.EnFilePath.GetProductThumbPath(Eval("gpId") != null ? Eval("gpId").ToString() : "", Eval("thumb") != null ? Eval("thumb").ToString() : "","upload") %>" width="100" height="60" border="0" />
       
        </td>
        <td><%#Eval("Name")%></td>
        <td><%#Eval("Sale")%></td>
        <td><%#Eval("Stock").ToString() == "-1" ? "长期供应" : Eval("Stock").ToString()%></td>
        <td><%#GetProductStatus(Eval("Status").ToString())%></td>
        <td><a class="myhander" onclick="showRevertBox(<%#Eval("gpId")%>);"><img src="../Images/huanyuan.gif" width="16" height="16" border="0" /></a></td>
        <td><a class="myhander" onclick="showDelBox(<%#Eval("gpId")%>);"><img src="../Images/del.png" width="16" height="16" border="0" /></a></td>
      </tr>
      </ItemTemplate>
  </asp:Repeater>
</table>
</div>
<%if (!string.IsNullOrEmpty(pageStr)) { Response.Write(pageStr); } %>
<div class="btmenu">
<p>
<a class="bome" id="off" onclick="chkAll(this,'productlist');">全选</a><a class="bome" onclick="showRevertBox('');">还原</a>
<a class="bome" onclick="showDelBox('');">删除</a>&nbsp;&nbsp;<a href="groupproductlist.aspx"><span class="lookdel"><img src="../Images/back.gif" alt="返回" width="16" height="16" align="absmiddle" />&nbsp;返回</span></a></p>
</div>
</div>
<script type="text/javascript" src="../script/myPublic.js"></script>
<script type="text/javascript">
<!--
    function getQueryString(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }
    $(function () {
        //弹出的删除提示框始终位于屏幕中间
        $(window).scroll(function () {
            if ($('.mainbox .pop').size() != 0) {
                $('.mainbox .pop').css('top', ($(window).height() - $('.mainbox .pop').height()) / 2 + $(document).scrollTop() + 'px');
                $('.mainbox .pop').css('left', ($(window).width() - $('.mainbox .pop').width()) / 2 + 'px');
            }
        });
        //brand change click
        $('#<%=ddlbrand.ClientID %> ').change(function () {
            var brandId = $(this).val();
            $('#SeriesId').empty();
            if (brandId != "") {
                $.ajax({
                    url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                    data: 'type=getbrands&v=' + brandId + '&ram=' + Math.random(),
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
        });

        //选中搜索下拉菜单      
            selectedDdl();        
    });

    function searchGroupProduct() {
        var url = 'DelGroupProductList.aspx?';
        //大类
        var bigCateId = $.trim($('#<%=ddlBigCategory.ClientID %> option:selected').val());
        if (bigCateId.toString() != '') {
            url += 'bigCateId=' + bigCateId.toString() + '&';
        }
        //品牌
        var brandId = $.trim($('#<%=ddlbrand.ClientID %> option:selected').val());
        if (brandId.toString() != '') {
            url += 'brandId=' + brandId.toString() + '&';
        }
        //产品编号
        var productNo = $.trim($('#productNo').val());
        if (productNo.toString() != '') {
            url += 'productNo=' + escape(productNo) + '&';
        }
        //系列
        var SeriesId = $.trim($('#SeriesId option:selected').val());
        if (SeriesId.toString() != '') {
            url += 'SeriesId=' + SeriesId.toString() + '&';
        }
        //状态
        var Status = $.trim($('#Status option:selected').val());
        if (Status.toString() != '') {
            url += 'Status=' + Status.toString() + '&';
        }
        url = url.toString().substring(0, url.toString().length - 1);        
        location.href = url;
    }

    //选中下拉菜单
    function selectedDdl() {
        if (getQueryString("bigCateId") != null) {
            $("#<%=ddlBigCategory.ClientID %>").val(getQueryString("bigCateId"));
        }

        if (getQueryString("brandId") != null) {
            $("#<%=ddlbrand.ClientID %>").val(getQueryString("brandId"));
        }
        if (getQueryString("Status") != null) {
            $("#Status").val(getQueryString("Status"));
        }

        if (getQueryString("SeriesId") != null) {
            $("#SeriesId").val(getQueryString("SeriesId"));
        }
        if (getQueryString("productNo") != null) {
            $("#productNo").val(getQueryString("productNo"));
        }
    }

    function selectDdlByValue(objId, objValue) {
        $('#' + objId.toString() + ' option[value=\'' + objValue.toString() + '\']').attr('selected', true);
    }

    function selectSeries(SeriesId) {
        var brandId = $.trim($('#brandId option:selected').val());
        $('#SeriesId').empty();
        $('<option>读取数据中</option>').appendTo($('#SeriesId'));
        $.get('../MemberAjax/ProductHandler.ashx', { Action: 'series', brandId: brandId }, function (data) {
            if (data != null) {
                $('#SeriesId').empty();
                data = '<option value="">请选择</option>' + data;
                $(data).appendTo($('#SeriesId'));
                selectDdlByValue('SeriesId', SeriesId.toString());
            }
        });
    }

    //还原产品提示
    function showRevertBox(productId) {
        if (productId == '') {
            //判断是否选择了产品
            productId = checkSelectedObj('productlist');
            if (productId == '') {
                alert('抱歉，请选择您要还原的产品！');
                return;
            }
        }

        if ($('.mainbox .pop').size() == 0) {
            var myhtml = showDelBoxHtml('您将对这个产品进行还原操作，点击“确定”后，该产品将出来在您的产品列表里。', productId, 'revertgroupproductrecycle', '还原提示');
            $(myhtml).insertAfter($('.mainbox .maincon'));
            $('.mainbox .pop').css('top', ($(window).height() - $('.mainbox .pop').height()) / 2 + $(document).scrollTop() + 'px');
            $('.mainbox .pop').css('left', ($(window).width() - $('.mainbox .pop').width()) / 2 + 'px');
            $('.pop i').click(function () {
                hideDelBox();
            });
            $('.pop .btnlitr').click(function () {
                hideDelBox();
            });
        }
    }

    function showDelBox(productId) {
        if (productId == '') {
            //判断是否选择了产品
            productId = checkSelectedObj('productlist');
            if (productId == '') {
                alert('抱歉，请选择您要删除的产品！');
                return;
            }
        }

        if ($('.mainbox .pop').size() == 0) {
            if ($('.outpop').size() != 0) {
                $('.outpop').hide();
            }
            var myhtml = showDelBoxHtml('您将对产品进行删除操作，点击“确定”后，该产品将从您的产品列表里消失，不可还原。', productId.toString(), 'deletegroupproductrecycle', '删除确认');
            $(myhtml).insertAfter($('.mainbox .maincon'));
            $('.mainbox .pop').css('top', ($(window).height() - $('.mainbox .pop').height()) / 2 + $(document).scrollTop() + 'px');
            $('.mainbox .pop').css('left', ($(window).width() - $('.mainbox .pop').width()) / 2 + 'px');
            $('.pop i').click(function () {
                hideDelBox();
            });
            $('.pop .btnlitr').click(function () {
                hideDelBox();
            });
        }
    }

    //还原（删除）回收站中产品
    function doAboutDb(productId, Type) {        
        $.get('<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxproduct.ashx', { type: 'dorecyclegp', ppId: productId.toString(), pType: Type.toString() }, function (data) {
        //$.get('../MemberAjax/ProductHandler.ashx', { Action: 'dorecyclegp', ppId: productId.toString(), Type: Type.toString() }, function (data) {
            if (data != null && data != "") {
                var TypeName = "删除";
                if (Type.toString() == 'revertgroupproductrecycle') {
                    TypeName = '还原';
                }
                if (data == 'success') {
                    cancelCheckBoxChecked('productlist');
                    alert(TypeName.toString() + '产品成功！');
                    location.reload();
                } else if (data == 'fail') {
                    alert('抱歉，系统正忙' + TypeName.toString() + '产品失败！');
                }
            } else {
                alert('抱歉，操作失败！');
            }
        });
    }
//-->
</script>
</asp:Content>