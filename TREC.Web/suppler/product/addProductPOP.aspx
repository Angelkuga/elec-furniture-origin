<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addProductPOP.aspx.cs"
    Inherits="TREC.Web.Suppler.product.addProductPOP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="<%=TREC.ECommerce.ECommon.WebSupplerResourceUrl.TrimEnd('/') %>/script/jquery-1.7.1.min.js" type="text/javascript"></script>
    <link href="../resource/css/ymPrompt/simple_gray/ymPrompt.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../css/base.css" />
</head>
<body style="margin:0;">
    <form id="form1" runat="server">
    <div>
        <input name="productNo" id="productNo"  value="<%=Request["productSKN"] %>" type="hidden"  />
        <input name="brand" id="brand"  value="<%=Request["brand"] %>" type="hidden"  />
        <input name="BigCategory" id="BigCategory"  value="<%=Request["BigCategory"] %>" type="hidden"  />
        <input name="style" id="style"  value="<%=Request["style"] %>" type="hidden"  />
        <input name="material" id="material"  value="<%=Request["material"] %>" type="hidden"  />
        <input name="SeriesId" id="SeriesId"  value="<%=Request["SeriesId"] %>" type="hidden"  />
        <input name="smallCateId" id="smallCateId"  value="<%=Request["smallCateId"] %>" type="hidden"  />
        <input name="IsGroup" id="IsGroup"  value="<%=Request["IsGroup"] %>" type="hidden"  />
        <input name="gpId" id="gpId"  value="" type="hidden"  />
        <%--<input type="button" class="btnlitl" id="searchProduct" value="搜索" onclick="Dosearch(1);" />--%>
        <div class="msgtable" style="margin:0;text-align: center;">
            <table width="100%" border="0" id="productlist" cellspacing="0" cellpadding="0">
                <tr>
                    <th align="center" nowrap>
                        <a onclick="chkboxAll(this,'msgtable');">选择</a>
                    </th>
                    <th align="center" nowrap>
                        编号
                    </th>
                    <th align="center" nowrap>
                        分类名称
                    </th>
                    <th align="center" nowrap>
                        图片
                    </th>
                    <th align="center" nowrap>
                        名称
                    </th>
                    <th align="center" nowrap>
                        尺寸
                    </th>
                    <th align="center" nowrap>
                        状态
                    </th>
                    <th align="center" nowrap>
                        上/下线
                    </th>
                </tr>
            </table>
            <a class="bome" id="addProd">添加选择的单品</a>
            <asp:HiddenField ID="hiddSingProductID" runat="server" />
        </div>
        <script type="text/javascript">
            $(function () {
                //添加单品到父级窗口
                $("#addProd").click(function () {
                    var chk_str = "";
                    var chk_value = [];
                    if ($(".msgtable").find("input[type=checkbox]:checked").length == 0) {
                        alert("请选择单品");
                        return;
                    } else {
                        $(".msgtable").find("input[type=checkbox]:checked").each(function () {
                            if ($(this).attr("checked")) {
                                if (chk_str == "")
                                    chk_str = $(this).val();
                                else
                                    chk_str += "," + $(this).val();
                            }
                            chk_value.push($(this).val());
                        });
                    }
                    if ($(".ymPrompt_close", parent.document).length > 0) {
                        var pCTRL = $("#ctl00_ContentPlaceHolder1_hiddSingProductID", parent.document);
                        var old_value_str = pCTRL.val();
                        if (old_value_str != "") {
                            old_value_str = unique((old_value_str + ',' + chk_str).split(","));
                        }
                        else {
                            old_value_str = chk_str;
                        }
                        pCTRL.val(old_value_str);
                        //$("#loadProdTest", parent.document).val(old_value_str);
                        $("#loadProd", parent.document).click();
                        window.parent.ymPrompt.doHandler('', true);
                    }
                });
                //数组去重复项
                function unique(arr) {
                    var result = [], hash = {};
                    for (var i = 0, elem; (elem = arr[i]) != null; i++) {
                        if (!hash[elem]) {
                            result.push(elem);
                            hash[elem] = true;
                        }
                    }
                    return result;
                }
                Dosearch(1);
            });
            //分页
            function singleProductPage(totalPage, currentPage) {
                var mysize = $('.msgtable .pages').size();
                if (mysize == 0) {
                    $('<div class="pages"></div>').insertAfter($('#productlist'));
                }
                var epage = currentPage + 3;
                var spage = currentPage - 2;
                if (spage <= 0 || totalPage <= 5) {
                    spage = 1;
                }
                if (totalPage < epage) {
                    epage = totalPage;
                }
                var pagehtml = '';
                for (var i = spage; i <= epage; i++) {
                    if (i == currentPage) {
                        pagehtml += '<span class="current">' + i + '</span>';
                    } else {
                        pagehtml += '<a onclick="Dosearch(' + i + ');">' + i + '</a>';
                    }
                }
                //上一页
                if (currentPage == 1) {
                    pagehtml = '<span class="disabled"> &lt; </span>' + pagehtml;
                } else {
                    pagehtml = '<a onclick="Dosearch(' + (currentPage - 1) + ');"> &lt; </a>' + pagehtml;
                }
                //下一页
                if (currentPage == totalPage) {
                    pagehtml += '<span class="disabled"> &gt; </span>';
                } else {
                    pagehtml += '<a onclick="Dosearch(' + (currentPage + 1) + ');"> &gt; </a>';
                }
                $('.msgtable .pages').html(pagehtml);
            }
            //搜索单品
            function Dosearch(pp) {
                var gpId = "";
                var productNo = $("#productNo").val();
                $('.msgtable tr:gt(0)').remove();
                $('<tr><td colspan="8" style="color:#999;text-align:center;line-height:40px;height:40px;">正在读取数据中...</td></tr>').insertAfter($('.msgtable tr:eq(0)'));
                $('.msgtable .pages').html('');
                var brandId = $("#brand").val();
                var bigCateId = $("#BigCategory").val();
                var styleId = $("#style").val();
                var MaterialId = $("#material").val();
                var SeriesId = $("#SeriesId").val();
                var smallCateId = $("#smallCateId").val();
                var IsGroup = $("#IsGroup").val();
                gpId = $("#gpId").val();
                if (IsGroup == 'undefined') {
                    IsGroup = '';
                }
                var ColorId = "";
                $.get('../ajax/MemberHandler.ashx',
                        { Action: 'searchgroupproduct',
                            brandId: brandId.toString(),
                            bigCateId: bigCateId.toString(),
                            styleId: styleId.toString(),
                            MaterialId: MaterialId.toString(),
                            SeriesId: SeriesId.toString(),
                            smallCateId: smallCateId.toString(),
                            IsGroup: IsGroup.toString(),
                            ColorId: ColorId.toString(),
                            productNo: escape(productNo.toString()), Page: pp, gpId: gpId.toString(), ran: Math.random()
                        },
                         function (data) {
                             if (data != null) {
                                 if (data.toString() == 'no' || data.toString() == '$0') {
                                     $('.msgtable tr:eq(1) td').html('抱歉，暂无找到您要的单品！');
                                     var mysize = $('.msgtable .pages').size();
                                     if (mysize == 1) {
                                         $('.msgtable .pages').remove();
                                     }
                                 } else {
                                     var phtml = data.toString().substring(0, data.toString().indexOf('$'));
                                     $('.msgtable tr:eq(1)').remove();
                                     $(phtml).insertAfter($('.msgtable tr:eq(0)'));
                                     //页数
                                     var totalpage = data.toString().substring(data.toString().lastIndexOf('$') + 1);
                                     if (1 < parseInt(totalpage.toString(), 10)) {
                                         singleProductPage(totalpage, pp);
                                     }
                                 }
                             }
                         });
                     }
                     //select all
                     function chkboxAll(th, t_class) {
                         if ($("." + t_class).find("input[type=checkbox]:checked").length > 0) {
                             $("." + t_class).find("input[type=checkbox]").attr('checked', false);
                             // $(th).text("全选")
                         } else {
                             $("." + t_class).find("input[type=checkbox]").attr('checked', "checked");
                             // $(th).text("取消")
                         }
                     } 
        </script>
    </div>
    </form>
</body>
</html>
