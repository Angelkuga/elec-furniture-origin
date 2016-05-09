<%@ Page Title="" Language="C#" MasterPageFile="../Member.Master" AutoEventWireup="true"
    CodeBehind="groupproductlist.aspx.cs" Inherits="TREC.Web.Suppler.product.groupproductlist" %>

<%@ MasterType VirtualPath="../Member.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            <u>套组合管理</u></h1>
    </div>
    <div class="maincon">
        <div class="sobox">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        大类
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBigCategory" runat="server" CssClass="select" Width="80">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        状态
                    </td>
                    <td>
                        <select id="Status">
                            <option value="">请选择</option>
                            <option value="0">已下线</option>
                            <option value="1">申请中</option>
                            <option value="2">已上线</option>
                        </select>
                    </td>
                    <td align="right">
                            店铺
                        </td>
                        <td style="text-align: left;">
                            <select id="ShopID">
                                <option value="">请选择</option>
                                <asp:Repeater ID="RptShop" runat="server">
                                    <ItemTemplate>
                                        <option value="<%#Eval("id")%>">
                                            <%#Eval("title").ToString().Replace("--", "").Replace("|", "")%></option>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </select>
                        </td>
                    <%-- <td rowspan="2" align="right">产品编号</td>
  <td rowspan="2"><input id="productNo" value="<%=productNo %>" maxlength="100" type="text" size="11" /></td>--%>
                    <td rowspan="2">
                        <input type="button" value="搜索" onclick="searchGroupProduct();" class="btnso" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        品牌
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlbrand" runat="server" CssClass="select" Width="85">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        系列
                    </td>
                    <td>
                        <select id="SeriesId">
                            <option value="">请选择</option>
                            <asp:Repeater ID="RptSeries" runat="server">
                                <ItemTemplate>
                                    <option value="<%#Eval("id")%>">
                                        <%#Eval("title")%></option>
                                </ItemTemplate>
                            </asp:Repeater>
                        </select>
                    </td>
                    <td align="right">
                            活动
                        </td>
                        <td>
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
            </table>
        </div>
        <div class="msgtable">
            <input type="button" class="btnadd marbtm" onclick="location.href='issuegroupproduct.aspx';"
                value="添加新套组合" />
            <table width="100%" border="0" id="productlist" cellpadding="0" cellspacing="0">
                <tr class="titlecor">
                    <th>
                        选择
                    </th>
                    <th>
                        编号
                    </th>
                    <th>
                        店铺名&nbsp;<img src="../Images/bicon.gif" width="11" height="6" />
                    </th>
                    <th>
                        大类
                    </th>
                    <th>
                        图片
                    </th>
                    <th style="width: 150px;">
                        套组合名称
                    </th>
                    <th>
                        销量
                    </th>
                    <th>
                        库存<img src="../Images/xldown.gif" width="11" height="11" align="absmiddle" />
                    </th>
                    <th>
                        状态<img src="../Images/xlup.gif" width="11" height="11" align="absmiddle" />
                    </th>
                    <th>
                        编辑
                    </th>
                    <th>
                        删除
                    </th>
                </tr>
                <asp:Repeater ID="RptProductList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input type="checkbox" value="<%#Eval("gpId") %>" />
                            </td>
                            <td>
                                <%#Eval("No")%>
                            </td>
                            <td>
                                <%#Eval("ShopName")%>
                            </td>
                            <td>
                                <%#Eval("CategoryName")%>
                            </td>
                            <td>
                                <a>
                                    <%-- <img src="<%#Eval("OverallPicture").ToString()==""?"../Images/noshop.jpg":("/upload/temp/"+Eval("thumb").ToString()) %>" width="100" height="60" border="0" />--%>
                                    <img src="<%#TREC.Entity.EnFilePath.GetProductGroupThumbPath(Eval("gpId") != null ? Eval("gpId").ToString() : "", Eval("thumb") != null ? Eval("thumb").ToString() : "") %>"
                                        width="100" height="60" border="0" />
                                </a>
                            </td>
                            <td>
                                <%#Eval("Name")%>
                            </td>
                            <td>
                                <%#Eval("Sale")%>
                            </td>
                            <td>
                                <%#Eval("Stock").ToString() == "-1" ? "长期供应" : Eval("Stock").ToString()%>
                            </td>
                            <td>
                                <%#GetProductStatus(Eval("Status").ToString())%>
                            </td>
                            <td>
                                <a href="issuegroupproduct.aspx?gpId=<%#Eval("gpId") %>">
                                    <img src="../Images/bianji.png" width="16" height="16" border="0" /></a>
                            </td>
                            <td>
                                <a class="myhander" onclick="showDelBox(<%#Eval("gpId")%>);">
                                    <img src="../Images/del.png" width="16" height="16" border="0" /></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <%if (!string.IsNullOrEmpty(pageStr)) { Response.Write(pageStr); } %>
        <div class="btmenu">
            <p>
                <a class="bome" id="off" onclick="chkboxAll(this)">全选</a><a href="issuegroupproduct.aspx"
                    class="bome">添加</a><a class="bome" onclick="doProductStatus('up');">上线</a><a class="bome"
                        onclick="doProductStatus('down');">下线</a> <a class="bome" onclick="showDelBoxM();">删除</a><a
                            class="bome" onclick="CopyProductShop();">复制到其他店铺&nbsp;<img src="../Images/wicon.gif"
                                width="11" height="6" /></a>&nbsp;&nbsp;<span class="lookdel"><img src="../Images/ljt.gif"
                                    width="11" height="13" align="absmiddle" />&nbsp;<a href="DelGroupProductList.aspx">&nbsp;查看已删除产品</a></span></p>
        </div>
    </div>
    <script src="../script/myPublic.js" type="text/javascript"></script>
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
            //        $("#<%=ddlbrand.ClientID %>").change(function () {
            //            if (this.value != "") {
            //                $.ajax({
            //                    url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxuser.ashx',
            //                    data: 'type=getbrands&v=' + this.value + "&ram=" + Math.random(),
            //                    dataType: 'json',
            //                    success: function (data) {
            //                        $("#SeriesId").html("").hide().show();
            //                        $("#SeriesId").append("<option value=\"\">请选择</option>");
            //                        $.each(data, function (i) {
            //                            if (data[i].id != "" && data[i].title != "") {
            //                                $("#SeriesId").append("<option value=\"" + data[i].id + "\">" + data[i].title + "</option>");
            //                            }
            //                        });
            //                    }
            //                });
            //            }

            //        });

            //选中搜索下拉菜单      
            selectedDdl();

        });

        function searchGroupProduct() {
            var url = 'groupproductlist.aspx?';
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
            //店铺
            var Status = $.trim($('#ShopID option:selected').val());
            if (Status.toString() != '') {
                url += 'ShopID=' + Status.toString() + '&';
            }
            //活动
            var Status = $.trim($('#SelPT option:selected').val());
            if (Status.toString() != '') {
                url += 'SelPT=' + Status.toString() + '&';
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
            if (getQueryString("ShopID") != null) {
                $("#ShopID").val(getQueryString("ShopID"));
            }
            if (getQueryString("SelPT") != null) {
                $("#SelPT").val(getQueryString("SelPT"));
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
                        data: 'type=savegroupcopyshop&productId=' + productId + '&shopId=' + shopId + '&ram=' + Math.random(),
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
        //批量删除
        function showDelBoxM() {
            var productId = checkSelectedObj('productlist');
            if (productId == '') {
                alert('抱歉，请选择产品！');
                return;
            }
            doAboutDb(productId, 'delete');
        }

        function showDelBox(productId) {
            if (confirm("是否删除?")) {
                $.ajax({
                    url: '<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxproduct.ashx',
                    data: 'type=delGroupProduct&v=' + productId + "&ram=" + Math.random(),
                    dataType: 'html',
                    success: function (data) {
                        alert("删除成功!");
                        window.location.href = "groupproductlist.aspx";
                    }
                });
            }
        }


        //产品（上、下）线
        function doProductStatus(Type) {
            var TypeName = Type == 'down' ? '下线' : '上线';

            //判断是否选择了产品
            var productId = checkSelectedObj('productlist');
            if (productId == '') {
                alert('抱歉，请选择您要' + TypeName + '的产品！');
                return;
            }

            if (confirm("您确定把这个产品从这里" + TypeName + "吗?")) {
                doAboutDb(productId, Type);
                return true;
            } else {
                return false;
            }
        }

        //上线（下线、删除）产品
        function doAboutDb(productId, Type) {
            $.get('<%=TREC.ECommerce.ECommon.WebSupplerUrl %>/ajax/ajaxproduct.ashx', { type: 'dogp', ppId: productId.toString(), pType: Type.toString() }, function (data) {
                if (data != null) {
                    var TypeName = "删除";
                    if (Type.toString() == 'up') {
                        TypeName = '上线';
                    } else if (Type.toString() == 'down') {
                        TypeName = '下线';
                    }
                    if (data == 'success') {
                        cancelCheckBoxChecked('productlist');
                        alert(TypeName.toString() + '产品成功！');
                        location.reload();
                    } else if (data == 'fail') {
                        alert('抱歉，系统正忙' + TypeName.toString() + '产品失败！');
                    }
                }
            });
        }

        function chkboxAll(th) {

            if ($(".msgtable").find("input[type=checkbox]:checked").length > 0) {
                $(".msgtable").find("input[type=checkbox]").attr('checked', false);
                $(th).text("全选")
            } else {
                $(".msgtable").find("input[type=checkbox]").attr('checked', "checked");
                $(th).text("取消")
            }
        }
//-->
    </script>
</asp:Content>
