<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Member.Master" CodeBehind="productlist.aspx.cs"
    Inherits="TREC.Web.Suppler.product.productlist" %>

<%@ Import Namespace="TREC.ECommerce" %>
<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../script/myPublic.js" type="text/javascript"></script>
    <style type="text/css">
        .outpop li, .outpop
        {
            text-align: left;
            background: #fff;
        }
        .outpop
        {
            padding-bottom: 20px;
        }
        .outpop input.btnlitl
        {
            margin-left: 20px;
        }
        .outpop li input
        {
            margin-right: 10px;
        }
        .pop, .outpop
        {
            position: absolute;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="maintitle">
        <h1>
            <u>产品管理</u></h1>
    </div>
    <div class="maincon">
        <div class="sobox">
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <tbody>
                    <tr>
                        <td>
                            大类
                        </td>
                        <td style="text-align: left;">
                            <select id="bigCateId">
                                <option value="">请选择</option>
                                <asp:Repeater ID="RptBigCate" runat="server">
                                    <ItemTemplate>
                                        <option value="<%#Eval("id")%>">
                                            <%#Eval("title").ToString().Replace("--", "").Replace("|", "")%></option>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </select>
                        </td>
                        <td>
                            店铺
                        </td>
                        <td style="text-align: left;">
                            <select id="ShopID">
                                <option value="0">请选择</option>
                                <asp:Repeater ID="RptShop" runat="server">
                                    <ItemTemplate>
                                        <option value="<%#Eval("id")%>">
                                            <%#Eval("title").ToString().Replace("--", "").Replace("|", "")%></option>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </select>
                        </td>
                        <td>
                            品牌
                        </td>
                        <td style="text-align: left;">
                            <select id="brandId">
                                <option value="">请选择</option>
                                <asp:Repeater ID="rptBrand" runat="server">
                                    <ItemTemplate>
                                        <option value="<%#Eval("id")%>">
                                            <%#Eval("title")%></option>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </select>
                        </td>
                        <td>
                            产品编号
                        </td>
                        <td style="text-align: left;">
                            <input type="text" size="11" maxlength="100" value="" id="productNo">
                        </td>
                        <td rowspan="2">
                            <input type="button" class="btnso" onclick="searchProduct();" value="搜索">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            小类
                        </td>
                        <td style="text-align: left;">
                            <select id="smallCateId">
                                <option value="">请选择</option>
                            </select>
                        </td>
                        <td>
                            系列
                        </td>
                        <td style="text-align: left;">
                            <select id="SeriesId">
                                <option value="">请选择</option>
                                <asp:Repeater ID="RptSeries" runat="server">
                                    <ItemTemplate>
                                        <option value="<%#Eval("id") %>">
                                            <%#Eval("title")%></option>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </select>
                        </td>
                        <td>
                            状态
                        </td>
                        <td style="text-align: left;">
                            <select id="Status">
                                <option value="">请选择</option>
                                <option value="0">已下线</option>
                                <option value="-1">申请中</option>
                                <option value="1">已上线</option>
                            </select>
                        </td>
                        <td>
                            活动
                        </td>
                        <td style="text-align: left;">
                            <select id="SelPT">
                                <option value="">请选择</option>
                                <asp:Repeater ID="RptPT" runat="server">
                                    <ItemTemplate>
                                        <option value="<%#Eval("id") %>">
                                            <%#Eval("title")%></option>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </select>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="msgtable" id="msgtable">
            <input type="button" value="添加新产品" class="btnadd marbtm" onclick="location.href='productinfo.aspx';"
                name="button2">
            <table width="100%" border="0" id="productlist" cellspacing="0" cellpadding="0" class="msgtable">
                <tr>
                    <th  align="center" nowarp>
                        <a onclick="chkboxAll(this);">全选</a>
                    </th>
                    <%--<th width="50" align="center">编号</th>--%>
                    <th align="center" nowarp>
                        店铺名称
                    </th>
                    <th align="center" nowarp >
                        分类
                    </th>
                    <th align="center" nowarp >
                        图片
                    </th>
                    <th align="center" nowarp >
                        编号 名称
                    </th>
                    <th align="center" nowarp >
                        尺寸
                    </th>
                    <%--<th align="center" width="100">品牌</th>
    <th align="center" width="100">系列</th>--%>
                    <th align="center"  nowarp>
                        库存
                    </th>
                    <%-- <th align="center" width="80">销量</th>--%>
                    <th align="center" width="50">
                        状态
                    </th>
                    <%--<th align="center" width="100">风格</th>--%>
                    <%--<th align="center" width="80">风格</th>
    <th align="center" width="80">色系</th>--%>
                    <th align="center"  nowarp>
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr id="tr" style="height:70px;">
                            <td align="center">
                                <input type="checkbox" id="productid" value="<%#Eval("id") %>" />
                                <asp:Label ID="lb_pid" Style="display: none" runat="server" Text='<%#Eval("id")%>'></asp:Label>
                            </td>
                            <%--<td align="center"><asp:Label ID="lb_id" runat="server" Text='<%#Eval("sku")%>'></asp:Label></td>--%>
                            <td align="center">
                                <%# GetShopName(Eval("shopid"))%>
                            </td>
                            <td align="center">
                                <a href="#">
                                    <%#Eval("categorytitle")%></a>
                            </td>
                            <td align="center" style="height:70px;">
                                <img width="105" height="60" src='<%#TREC.Entity.EnFilePath.GetProductThumbPath(Eval("id") != null ? Eval("id").ToString() : "", Eval("thumb") != null ? Eval("thumb").ToString() : "","upload") %>' />
                            </td>
                            <td align="left" class="l edit">
                                <%#Eval("sku")%><br />
                                <%#Eval("title")%>
                                  <asp:Label ID="label_title" Style="display: none" runat="server" Text='<%#Eval("title")%>'></asp:Label>
                            </td>
                            <td align="center">
                                <%#getProductSize(Eval("Id"))%>
                            </td>
                            <%--<td align="center"><%#Eval("brandtitle")%></td>
            <td align="center"><%#Eval("brandstitle")%></td>--%>
                            <%--  <td><%#Eval("Sale")%></td>--%>
                            <td>
                                <%# getProductStorage(Eval("Id"))%>
                            </td>
                            <%--  <td><%#Eval("sale")%></td>--%>
                            <td align="center">
                                <%#GetStatusStr(Eval("linestatus"), Eval("auditstatus"))%>
                            </td>
                            <%--<td align="center"><%#Eval("stylename")%></td>--%>
                            <%--<td align="center"><%#Eval("stylename")%></td>
            <td align="center"><%#Eval("colorname")%></td>--%>
            
                            <%--<td align="center"><a name="various3" href="modifyproductshop.aspx?id=<%#Eval("id") %>">编辑销售价</a>--%>
                            <td>
                                <a href="productinfo.aspx?edit=1&id=<%#Eval("id") %>&PageIndex=<%=currentPage %>">
                                    <img width="16" border="0" height="16" alt="编辑" src="../Images/bianji.png"></a>
                                <a class="myhander" onclick="showDelBox(<%#Eval("id")%>);">
                                    <img src="../Images/del.png" alt="删除" width="16" height="16" border="0" /></a>
                                    <input id="Hidden1" type="hidden" value="<%#Eval("id") %>" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <%if (!string.IsNullOrEmpty(pageStr)) { Response.Write(pageStr); } %>
        <div class="btmenu">
            <p>
                <span class="btn_bg">
                    <%--<asp:LinkButton ID="lbtnDel" runat="server"  class="bome"  OnClientClick="return confirm( '确定要删除这些记录吗？ ');" OnClick="lbtnDel_Click" >删 除</asp:LinkButton>--%>
                    <a class="bome" id="off" onclick="chkboxAll(this);">全选</a><a href="productinfo.aspx"
                        class="bome">添加</a> <a onclick="doProductStatus('up')" class="bome">上线</a> <a onclick="doProductStatus('down')"
                            class="bome">下线</a>
                    <%--<asp:LinkButton ID="lbtnUp" runat="server"  
            OnClientClick="return doProductStatus('up');"  class="bome" onclick="lbtnUp_Click" >上线</asp:LinkButton>--%>&nbsp;&nbsp;
                    <%--<asp:LinkButton ID="lbtnDon" runat="server"  
            OnClientClick="return doProductStatus('down');"  class="bome" onclick="lbtnDon_Click" >下线</asp:LinkButton>--%>&nbsp;&nbsp;
                    <a onclick="showDelBox('');" class="bome">删除</a> <a onclick="CopyProductShop();"
                        class="bome">复制到其他店铺&nbsp;<img width="11" height="6" src="../Images/wicon.gif"></a>&nbsp;&nbsp;
                </span><span class="lookdel">
                    <img width="11" align="absmiddle" height="13" src="../Images/ljt.gif">&nbsp;<a href="DelProductList.aspx">&nbsp;查看已删除产品</a></span></p>
        </div>
    </div>
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

                if ($('.outpop').size() != 0) {
                    $('.mainbox .outpop').css('top', ($(window).height() - $('.mainbox .outpop').height()) / 2 + $(document).scrollTop() + 'px');
                    $('.mainbox .outpop').css('left', ($(window).width() - $('.mainbox .outpop').width()) / 2 + 'px');
                }
            });
            //选中搜索下拉菜单      
            selectedDdl();

            //big categroy change click
            $('#bigCateId').change(function () {
                var bigId = $(this).val();
                if (bigId != "") {
                    $("#smallCateId").empty();
                    $("#smallCateId").append("<option value=\"\">请选择</option>");
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

        });
        //select all
        function chkboxAll(th) {

            if ($("#msgtable").find("input[type=checkbox]:checked").length > 0) {
                $("#msgtable").find("input[type=checkbox]").attr('checked', false);
                $(th).text("全选")
            } else {
                $("#msgtable").find("input[type=checkbox]").attr('checked', "checked");
                $(th).text("取消")
            }
        }
   
        //复制到其他店铺
        function CopyProductShop() {
            //check selected product
            if ($('.mainbox .pop').size() != 0) {
                hideDelBox();
            }
            //判断是否选择了产品
            var productId = checkSelectedObj('productlist');
            if (productId == '') {
                alert('抱歉，请选择产品！');
                return;
            }
            if ($('.outpop').size() == 0) {
                var html = '<div class="outpop"><h1><u>复制产品</u><i>X</i></h1><ul><li>正在加载数据中...</li></ul><input type="button" class="btnlitl" value="确定" /></div>';
                $(html).insertAfter($('.maincon'));
                $.ajax({
                    url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxproduct.ashx',
                    data: 'type=getcopyshopdb&ram=' + Math.random(),
                    dataType: 'html',
                    success: function (data) {
                        if (data != null) {
                            if (data.toString() == '') {
                                $('.outpop li').html('抱歉，您暂无店铺！');
                            } else {
                                $('.outpop ul').html(data);
                                CopyBtClick();
                            }
                        }
                    }
                });
                $('.mainbox .outpop').css('top', ($(window).height() - $('.mainbox .outpop').height()) / 2 + $(document).scrollTop() + 'px');
                $('.mainbox .outpop').css('left', ($(window).width() - $('.mainbox .outpop').width()) / 2 + 'px');
                $('.outpop i').click(function () {
                    $('.outpop').hide();
                });
            } else {
                $('.outpop').show();
            }
        }

        //复制时点击确定
        function CopyBtClick() {
            $('.outpop .btnlitl').click(function () {
                var shopId = '';
                $('.outpop li input:checked').each(function () {
                    shopId += $(this).val() + ',';
                });
                if (shopId == '') {
                    alert('抱歉，请选择店铺！');
                } else {
                    shopId = shopId.toString().substring(0, shopId.length - 1);
                    var productId = checkSelectedObj('productlist');
                    $(this).val('处理中');
                    $(this).attr('disabled', 'disabled');
                    $.ajax({
                        url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxproduct.ashx',
                        data: 'type=saveproductcopyshop&productId=' + productId + '&shopId=' + shopId + '&ram=' + Math.random(),
                        dataType: 'html',
                        success: function (data) {
                            if (data != null) {
                                alert('复制产品到店铺成功！');
                                $('.outpop').hide();
                                cancelCheckBoxChecked('productlist');
                                location.reload();
                            } else {
                                alert('抱歉，系统正忙请稍后复制！');
                            }
                        }
                    });

                }
            });
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
                var myhtml = showDelBoxHtml('您将把这个产品从这里移除，点击右下角的“查看已删除产品”可进行还原。', productId.toString(), 'delete', '删除确认');
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
            var url = 'ProductList.aspx?';
            //大类
            var ShopID = $.trim($('#ShopID option:selected').val());
            if (ShopID.toString() != '') {
                url += 'ShopID=' + ShopID.toString() + '&';
            }
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
            //活动
            var SelPT = $.trim($('#SelPT option:selected').val());
            if (SelPT.toString() != '') {
                url += 'SelPT=' + SelPT.toString() + '&';
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
            if (getQueryString("ShopID") != null) {
                $("#ShopID").val(getQueryString("ShopID"));
            }
            if (getQueryString("SelPT") != null) {
                $("#SelPT").val(getQueryString("SelPT"));
            }
        }


        function selectSmallCate(smallCateId) {
            var bigId = $.trim($('#bigCateId option:selected').val());
            $('#smallCateId').empty();
            $('&lt;option&gt;读取数据中&lt;/option&gt;').appendTo($('#smallCateId'));
            $.get('../MemberAjax/ProductHandler.ashx', { Action: 'categroy', bigCategroyId: bigId }, function (data) {
                if (data != null) {
                    $('#smallCateId').empty();
                    data = '&lt;option value=""&gt;请选择&lt;/option&gt;' + data;
                    $(data).appendTo($('#smallCateId'));
                    selectDdlByValue('smallCateId', smallCateId.toString());
                }
            });
        }

        function selectSeries(SeriesId) {
            var brandId = $.trim($('#brandId option:selected').val());
            $('#SeriesId').empty();
            $('&lt;option&gt;读取数据中&lt;/option&gt;').appendTo($('#SeriesId'));
            $.get('../MemberAjax/ProductHandler.ashx', { Action: 'series', brandId: brandId }, function (data) {
                if (data != null) {
                    $('#SeriesId').empty();
                    data = '&lt;option value=""&gt;请选择&lt;/option&gt;' + data;
                    $(data).appendTo($('#SeriesId'));
                    selectDdlByValue('SeriesId', SeriesId.toString());
                }
            });
        }

        //产品（上、下）线
        function doProductStatus(Type) {
            var TypeName = Type == 'down' ? '下线' : '上线';
            //判断是否选择了产品
            productId = checkSelectedObj('productlist');
            if (productId == '') {
                alert('抱歉，请选择您要' + TypeName + '的产品！');
                return false;
            }
            if (confirm("您确定把这个产品从这里" + TypeName + "吗?")) {
                $.get('<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxproduct.ashx', { type: 'updateupanddown', pId: productId.toString(), pType: Type, ram: Math.random() }, function (data) {
                    if (data != null && data != "") {
                        if (data == 'success') {
                            alert('产品' + TypeName + '成功！');
                            window.location.reload();
                        } else if (data == 'fail') {
                            alert('抱歉，系统正忙操作失败！');
                        }
                    } else {
                        alert('抱歉，系统正忙操作失败！');
                    }
                });
            }
        }


        //上线（下线、删除）产品
        function doAboutDb(productId, Type) {
            $.get('<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxproduct.ashx', { type: 'delProduct', pId: productId.toString(), ram: Math.random() }, function (data) {
                if (data != null && data != "") {
                    if (data == 'success') {
                        cancelCheckBoxChecked('productlist');
                        alert('删除产品成功！');
                        location.reload();
                    } else if (data == 'fail') {
                        alert('抱歉，系统正忙删除产品失败！');
                    }
                } else {
                    alert('抱歉，系统正忙删除产品失败！');
                }
            });
        }
   //-->
</script>
    <div class="clear">
    </div>
</asp:Content>
