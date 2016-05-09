<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true" CodeBehind="DelProductList.aspx.cs" Inherits="TREC.Web.Suppler.product.DelProductList" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="/Scripts/Common/myPublic.js"></script>
<style type="text/css">
   .outpop li,.outpop{text-align:left;background:#fff;}
   .outpop{padding-bottom:20px;}
   .outpop input.btnlitl{margin-left:20px;}
   .outpop li input{margin-right:10px;}
    .pop,.outpop{position:absolute;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="maintitle"><h1><u>已删除产品</u></h1></div>
<div class="maincon">
<div class="sobox"><table width="100%" cellspacing="0" cellpadding="0" border="0">
  <tbody><tr>
    <td align="right">大类</td>
    <td style="text-align:left;"><select id="bigCateId">
      <option value="">请选择</option>      
      <asp:Repeater ID="RptBigCate" runat="server">
      <ItemTemplate><option value="<%#Eval("id")%>"><%#Eval("title").ToString().Replace("--", "").Replace("|", "")%></option></ItemTemplate>
      </asp:Repeater>
      </select></td>
    <td align="right">品牌</td>
    <td style="text-align:left;"><select id="brandId">
        <option value="">请选择</option>      
        <asp:Repeater ID="rptBrand" runat="server">
            <ItemTemplate><option value="<%#Eval("id")%>"><%#Eval("title")%></option></ItemTemplate>
        </asp:Repeater>
      </select></td>
    <td align="right">产品编号</td>
    <td style="text-align:left;"><input type="text" size="11" maxlength="100" value="" id="productNo"></td>
    <td rowspan="2"><input type="button" class="btnso" onclick="searchProduct();" value="搜索"></td>
    </tr>
  <tr>
    <td align="right">小类</td>
    <td style="text-align:left;"><select id="smallCateId">
      <option value="">请选择</option></select></td>
    <td align="right">系列</td>
    <td style="text-align:left;"><select id="SeriesId">
      <option value="">请选择</option>      
      <asp:Repeater ID="RptSeries" runat="server">
      <ItemTemplate><option value="<%#Eval("id") %>"><%#Eval("title")%></option></ItemTemplate>
      </asp:Repeater>
      </select></td>
    <td align="right">状态</td>
    <td style="text-align:left;"><select id="Status">
      <option value="">请选择</option>
      <option value="0">已下线</option>
      <option value="1">申请中</option>
      <option value="2">已上线</option>
    </select></td>
    </tr>
</tbody></table>
</div>
<div class="msgtable">  
  <table width="100%" border="0" id="productlist" cellpadding="0" cellspacing="0">
  <tr class="titlecor">
    <th>选择</th>
    <th style="width:60px;">店铺名&nbsp;<img src="../Images/bicon.gif" width="11" height="6" /></th>
    <th>小类</th>
    <th>图片</th>
    <th style="width:150px;">产品名称</th>
    <th>尺寸(mm)</th>
    <th>销量<img src="../Images/xldown.gif" width="11" height="11" align="absmiddle" /></th>
    <th>库存<img src="../Images/xldown.gif" width="11" height="11" align="absmiddle" /></th>
    <th>状态<img src="../Images/xlup.gif" width="11" height="11" align="absmiddle" /></th>
    <th>还原</th>
    <th>删除</th>
  </tr>
  <asp:Repeater ID="RptProductList" runat="server">
      <ItemTemplate>
      <tr>
        <%--<td><input type="checkbox" value="<%#Eval("ppId")%>" /></td>--%>
         <tr id="tr">
            <td><input type="checkbox" value="<%#Eval("id") %>" /></td>
            <asp:Label ID="lb_pid" style="display:none" runat="server" Text='<%#Eval("id")%>'></asp:Label>
            </td>
            <%--<td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("sku")%>'></asp:Label></td>--%>
            <td align="center"><%# GetShopName(Eval("shopid"))%></td>
            <td align="center"><a href="#"><%#Eval("categorytitle")%></a></td>
            <td align="center" style="height:70px; line-height:70;">
            <img width="105" height="60" src='<%#TREC.Entity.EnFilePath.GetProductThumbPath(Eval("id") != null ? Eval("id").ToString() : "", Eval("thumb") != null ? Eval("thumb").ToString() : "","upload") %>' />
            </td>
            <td align="left" class="l edit"><%#Eval("title")%></td>
            <td align="center">
            <%#getProductSize(Eval("Id"))%>
            </td>
            
              <td>0</td>
                  <td><%# getProductStorage(Eval("Id"))%></td>
            <td align="center"><%#GetStatusStr(Eval("linestatus"))%></td>
          <%--  <td align="center"><%#Eval("linestatus").ToString()=="0"?"下线":"上线"%></td>     --%>
                 
        <td><a class="myhander" onclick="showRevertBox(<%#Eval("id")%>);"><img src="../Images/huanyuan.gif" width="16" height="16" border="0" /></a></td>
        <td><a class="myhander" onclick="showDelBox(<%#Eval("id")%>);"><img src="../Images/del.png" width="16" height="16" border="0" /></a></td>
      </tr>
      </ItemTemplate>
  </asp:Repeater>
</table>
</div>
<%if (!string.IsNullOrEmpty(pageStr)) { Response.Write(pageStr); } %>
<div class="btmenu">
<p>
<a class="bome" id="off" onclick="chkAll(this,'productlist');">全选</a><a  onclick="showRevertBox('');" class="bome">还原</a><a class="bome" onclick="showDelBox('');">删除</a>&nbsp;&nbsp;<a href="ProductList.aspx"><span class="lookdel"><img src="../Images/back.gif" alt="返回" width="16" height="16" align="absmiddle" />&nbsp;返回</span></a></p>
</div>
</div>
  <script src="../../Scripts/Common/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Common/myPublic.js" type="text/javascript"></script>
<script type="text/javascript" src="../script/myPublic.js"></script>
<script type="text/javascript">
   <!--
    function getQueryString(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }
    $(function () {
        //选中搜索下拉菜单      
        selectedDdl();
        //弹出的删除提示框始终位于屏幕中间
        $(window).scroll(function () {
            if ($('.mainbox .pop').size() != 0) {
                $('.mainbox .pop').css('top', ($(window).height() - $('.mainbox .pop').height()) / 2 + $(document).scrollTop() + 'px');
                $('.mainbox .pop').css('left', ($(window).width() - $('.mainbox .pop').width()) / 2 + 'px');
            }
        });
        //brand change click
        $('#brandId').change(function () {
            var brandId = $(this).val();
            if (brandId != "") {
                $.ajax({
                    url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                    data: 'type=' + type + '&v=' + id + "&ram=" + Math.random(),
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
        //big categroy change click
        $('#bigCateId').change(function () {
            var bigId = $(this).val();
            var bigId = $(this).val();
            if (bigId != "") {

                $.ajax({
                    url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                    data: 'type=getsmallcatagory&v=' + this.value + "&ram=" + Math.random(),
                    dataType: 'json',
                    success: function (data) {
                        $.each(data, function (i) {
                            if (data[i].id != "" && data[i].title != "") {
                                $("#smallCateId").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                            }
                        });
                    }
                });
            }
        });
        //选中搜索下拉菜单
        var url = location.href.toString();
        if (-1 < url.indexOf('?')) {
            url = url.toString().substring(url.toString().lastIndexOf('?') + 1);
            selectedDdl(url);
        }
    });

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
            var myhtml = showDelBoxHtml('您将对产品进行删除操作，点击“确定”后，该产品将从您的产品列表里消失，不可还原。', productId.toString(), 'deleteproductrecycle', '删除确认');
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

    //产品搜索
    function searchProduct() {
        var url = 'DelProductList.aspx?';
        //大类
        var bigCateId = $.trim($('#bigCateId option:selected').val());
        if (bigCateId.toString() != '') {
            url += 'bigCateId=' + bigCateId.toString() + '&';
        }
        //品牌
        var brandId = $.trim($('#brandId option:selected').val());
        if (brandId.toString() != '') {
            url += 'brandId=' + brandId.toString() + '&';
        }
        //产品编号
        var productNo = $.trim($('#productNo').val());
        if (productNo.toString() != '') {
            url += 'productNo=' + escape(productNo) + '&';
        }
        //小类
        var smallCateId = $.trim($('#smallCateId option:selected').val());
        if (smallCateId.toString() != '') {
            url += 'smallCateId=' + smallCateId.toString() + '&';
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
        //  alert(getQueryString("bigcateid"));
        if (getQueryString("bigcateid") != null) {
            $("#bigCateId").val(getQueryString("bigcateid"));
            //加载小类
            $.ajax({
                url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
                data: 'type=getsmallcatagory&v=' + getQueryString("bigcateid") + "&ram=" + Math.random(),
                dataType: 'json',
                success: function (data) {
                    $.each(data, function (i) {
                        if (data[i].id != "" && data[i].title != "") {
                            $("#smallCateId").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
                        }
                    });
                    if (getQueryString("smallcateid") != null) {
                        $("#smallCateId").val(getQueryString("smallcateid"));
                    }
                }
            });

        }
        if (getQueryString("brandid") != null) {
            $("#brandId").val(getQueryString("brandid"));
        }
        if (getQueryString("status") != null) {
            $("#Status").val(getQueryString("status"));
        }

        if (getQueryString("seriesid") != null) {
            $("#SeriesId").val(getQueryString("seriesid"));
        }
        if (getQueryString("productNo") != null) {
            $("#productNo").val(getQueryString("productNo"));
        }
    }
 

    function selectDdlByValue(objId, objValue) {
        $('#' + objId.toString() + ' option[value=\'' + objValue.toString() + '\']').attr('selected', true);
    }

    function selectSmallCate(smallCateId) {
        var bigId = $.trim($('#bigCateId option:selected').val());
        $('#smallCateId').empty();
        $('<option>读取数据中</option>').appendTo($('#smallCateId'));
        $.get('../MemberAjax/ProductHandler.ashx', { Action: 'categroy', bigCategroyId: bigId }, function (data) {
            if (data != null) {
                $('#smallCateId').empty();
                data = '<option value="">请选择</option>' + data;
                $(data).appendTo($('#smallCateId'));
                selectDdlByValue('smallCateId', smallCateId.toString());
            }
        });
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
            var myhtml = showDelBoxHtml('您将对这个产品进行还原操作，点击“确定”后，该产品将出来在您的产品列表里。', productId, 'revertproductrecycle', '还原提示');
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
    
       // $.get('../MemberAjax/ProductHandler.ashx', { Action: 'dorecyclepp', ppId: productId.toString(), Type: Type.toString() }, function (data) {
        $.get('<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxproduct.ashx', { type: 'dorecyclepp', pId: productId.toString(), pType: Type.toString(), ram: Math.random() },
         function (data) {
             if (data != null && data != "") {
                var TypeName = "删除";
                if (Type.toString() == 'revertproductrecycle') {
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
                alert('抱歉，系统正忙,操作失败！');
            }
        });
    }


   //-->
</script>
</asp:Content>